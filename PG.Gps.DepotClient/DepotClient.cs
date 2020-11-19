﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using NLog;
using PG.Gps.DepotClient.Model;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading;
using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace PG.Gps.DepotClient
{
    public class DepotClient : IDisposable
    {
        public static IEnumerable<string> RAW_MATERIAL_PART_TYPE_NAMES { get; } = new[] { "Individual Raw Material Specification", "Legacy Raw Material", "Raw Material", "Master Raw Material Part", "Master Raw Material Specification" };

        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public static string S_NULL => "null";
        public static string S_QUOTE => "\"";
        public static string SLASH => "/";

        // NOTE: these must be const for use in switch statements
        private const string CONTENT_TYPE_JSON = "application/json";
        private const string COMP_TYPE_NAME_BOM = "BOM";
        private const string COMP_TYPE_SDS_BOS = "SDS BOS";
        private const string PART_TYPE_CODE_PHASE = "PHASE";
        private const string PART_TYPE_CODE_PROC = "PROC";
        private const string PART_TYPE_CODE_FOP = "FOP";
        private const string PART_TYPE_CODE_FC = "FC";
        private const string PART_TYPE_CODE_FIL = "FIL";

        private JsonSerializerSettings JsonSettings { get; } = JsonConvert.DefaultSettings?.Invoke() ?? new JsonSerializerSettings(); // in case we later need to tweak, this can be done here

        /// <summary>
        /// Returns true if valid response. Default is call response.EnsureSuccessStatusCode().
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public delegate bool ValidateResponseHandler(HttpResponseMessage response);

        private static readonly TimeSpan DEFAULT_TIMEOUT = new TimeSpan(0, 5, 0);

        private readonly Lazy<HttpClient> _client;
        private readonly Lazy<WebClient> _stdClient;
        private AuthenticationHeaderValue _depotAuth;
        private ValidateResponseHandler _responseValidator;

        public RequestsRegion Requests { get; }
        public DangerousGoodsRegion DangerousGoods { get; }
        public PartsRegion Parts { get; }
        [Obsolete("Obsolete parts lookup, convert soon")]
        public ObsoletePartsRegion ObsoleteParts { get; }
        public CompositionsRegion Compositions { get; }
        public BillOfSubstanceRegion BillOfSubstance { get; }
        public IntegrationRegion Integration { get; }
        public SmartRegion Smart { get; }
        public SyncRegion Sync { get; }
        public ClearancesRegion Clearances { get; }
        public PicklistRegion Picklists { get; }

        public ValidateResponseHandler ResponseValidator
        {
            get
            {
                if (_responseValidator == null)
                {
                    _responseValidator = r => { r.EnsureSuccessStatusCode(); return true; };
                }
                return _responseValidator;
            }
            set
            {
                this._responseValidator = value;
            }
        }
        private HttpClient Client
        {
            get
            {
                bool isNew = !_client.IsValueCreated;
                var ret = _client.Value;
                if (isNew)
                    ret.DefaultRequestHeaders.Authorization = _depotAuth; // NOTE: Will remove auth header if _depotAuth=null
                return ret;
            }
        }

        private WebClient NonAsyncClient
        {
            get
            {
                bool isNew = !_stdClient.IsValueCreated;
                var ret = _stdClient.Value;
                if (isNew)
                    ret.Headers[HttpRequestHeader.Authorization] = _depotAuth?.ToString();
                return ret;
            }
        }

        public DepotClient(string depotBaseUrl, TimeSpan? httpTimeout = null)
        {
            Logger.Trace("DepotClient[Ctor]: baseUrl={0} httpTimeout={1}", depotBaseUrl, httpTimeout);
            var baseAddress = depotBaseUrl + (depotBaseUrl.EndsWith(SLASH) ? string.Empty : SLASH);
            httpTimeout = httpTimeout ?? DEFAULT_TIMEOUT;
            _client = new Lazy<HttpClient>(() => SetupHttpClient(baseAddress, httpTimeout ?? DEFAULT_TIMEOUT));
            _stdClient = new Lazy<WebClient>(() => SetupWebClient(baseAddress, httpTimeout ?? DEFAULT_TIMEOUT));

            Requests = new RequestsRegion(this);
            DangerousGoods = new DangerousGoodsRegion(this);
            Parts = new PartsRegion(this);
            ObsoleteParts = new ObsoletePartsRegion(this);
            Compositions = new CompositionsRegion(this);
            BillOfSubstance = new BillOfSubstanceRegion(this);
            Integration = new IntegrationRegion(this);
            Smart = new SmartRegion(this);
            Sync = new SyncRegion(this);
            Clearances = new ClearancesRegion(this);
            Picklists = new PicklistRegion(this);

            Logger.Trace("Client created: url={0}", baseAddress);
        }
        public DepotClient(string depotBaseUrl, string depotUser, string depotPass, TimeSpan? httpTimeout = null) : this(depotBaseUrl, httpTimeout)
        {
            Logger.Trace("DepotClient[Ctor]: baseUrl={0} depotUser={1} depotPass=**j/k** httpTimeout={2}", depotBaseUrl, depotUser, httpTimeout);
            SetAuthentication(depotUser, depotPass);
        }
        public DepotClient(string depotBaseUrl, AuthenticationHeaderValue depotAuth, TimeSpan? httpTimeout = null) : this(depotBaseUrl, httpTimeout)
        {
            Logger.Trace("DepotClient[Ctor]: baseUrl={0} authProvided={1} httpTimeout={2}", depotBaseUrl, depotAuth != null, httpTimeout);
            SetAuthentication(depotAuth);
        }

        #region ClientConfigs
        private HttpClient SetupHttpClient(string baseAddress, TimeSpan httpTimeout)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(baseAddress);
            httpClient.Timeout = httpTimeout;
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(CONTENT_TYPE_JSON));

            return httpClient;
        }
        private WebClient SetupWebClient(string baseAddress, TimeSpan httpTimeout)
        {
            var response = new MyWebClient();
            response.Timeout = httpTimeout;
            response.BaseAddress = new Uri(baseAddress).ToString();
            return response;
        }
        #endregion

        /// <summary>
        /// Sets the Depot Authentication Value. Will remove auth header if either is null.
        /// </summary>
        /// <param name="depotUser"></param>
        /// <param name="depotPass"></param>
        public void SetAuthentication(string depotUser, string depotPass)
        {
            AuthenticationHeaderValue depotAuth = null;
            if (!string.IsNullOrEmpty(depotUser) && !string.IsNullOrEmpty(depotPass))
            {
                Logger.Trace("Creating Authentication for {0}", depotUser);
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{depotUser}:{depotPass}"));
                depotAuth = new AuthenticationHeaderValue("Basic", credentials);
            }
            SetAuthentication(depotAuth);
        }

        /// <summary>
        /// Sets the Depot Authentication Value. Will remove auth header if null.
        /// </summary>
        /// <param name="depotAuth"></param>
        public void SetAuthentication(AuthenticationHeaderValue depotAuth)
        {
            _depotAuth = depotAuth;

            if (_client.IsValueCreated)
                _client.Value.DefaultRequestHeaders.Authorization = _depotAuth; // NOTE: Will remove auth header if _depotAuth=null

            if (_stdClient.IsValueCreated)
                _stdClient.Value.Headers[HttpRequestHeader.Authorization] = _depotAuth?.ToString();
        }

        public class RequestsRegion : ClientRegion
        {
            internal RequestsRegion(DepotClient client) : base(client) { }

            /// <summary>[Anybody]</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public RequestControllerStatusResult Status(string requestNumberOrTaskName, HttpMethod httpMethod = null)
            {
                return Task.Run(async () => await StatusAsync(requestNumberOrTaskName, httpMethod, CancellationToken.None)).GetAwaiter().GetResult();
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>[Anybody]</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public async Task<RequestControllerStatusResult> StatusAsync(string requestNumberOrTaskName, HttpMethod httpMethod = null, CancellationToken? cancellationToken = null)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append("api/v1/pass/request/status/{requestNumberOrTaskName}");
                urlBuilder_.Replace("{requestNumberOrTaskName}", Uri.EscapeDataString(ConvertToString(requestNumberOrTaskName, System.Globalization.CultureInfo.InvariantCulture)));

                if (httpMethod == HttpMethod.Post)
                    return await client.DoPostAsync<RequestControllerStatusResult>(urlBuilder_.ToString(), null, cancellationToken);

                return await client.DoGetAsync<RequestControllerStatusResult>(urlBuilder_.ToString(), cancellationToken);
            }

            /// <summary>[NoRoles]</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public Request GetRequest(string requestNumber, HttpMethod httpMethod = null)
            {
                return Task.Run(async () => await GetRequestAsync(requestNumber, httpMethod, CancellationToken.None)).GetAwaiter().GetResult();
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>[NoRoles]</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public async Task<Request> GetRequestAsync(string requestNumber, HttpMethod httpMethod = null, CancellationToken? cancellationToken = null)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append("api/v1/request/get-request?");
                if (requestNumber != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("requestNumber") + "=").Append(System.Uri.EscapeDataString(ConvertToString(requestNumber, System.Globalization.CultureInfo.InvariantCulture)));
                }

                if (httpMethod == HttpMethod.Post)
                    return await client.DoPostAsync<Request>(urlBuilder_.ToString(), null, cancellationToken);

                return await client.DoGetAsync<Request>(urlBuilder_.ToString(), cancellationToken);
            }
        }

        public class DangerousGoodsRegion : ClientRegion
        {
            internal DangerousGoodsRegion(DepotClient client) : base(client) { }

            /// <summary>[NoRoles]</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public List<DangerousGoods> DangerousGoodsByKey(string key)
            {
                return Task.Run(async () => await DangerousGoodsByKeyAsync(key)).GetAwaiter().GetResult();
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>[NoRoles]</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public async Task<List<DangerousGoods>> DangerousGoodsByKeyAsync(string key, CancellationToken? cancellationToken = null)
            {
                cancellationToken = cancellationToken ?? CancellationToken.None;

                var urlBuilder_ = new StringBuilder();
                urlBuilder_.Append("api/v1/dangerous-goods/by-key?");
                if (key != null)
                {
                    urlBuilder_.Append("key=").Append(Uri.EscapeDataString(ConvertToString(key, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                return await this.client.DoPostAsync<List<DangerousGoods>>(urlBuilder_.ToString(), null, cancellationToken);
            }

        }

        public class PartsRegion : ClientRegion
        {
            internal PartsRegion(DepotClient client) : base(client) { }

            /// <summary>Used for auto-complete. Returns an array of keys and names given the starting characters of a key.</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public List<GetPartKeyResults> GetPartKeys(string keyStartsWithChars)
            {
                return Task.Run(async () => await GetPartKeysAsync(keyStartsWithChars)).GetAwaiter().GetResult();
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>Used for auto-complete. Returns an array of keys and names given the starting characters of a key.</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public async Task<List<GetPartKeyResults>> GetPartKeysAsync(string keyStartsWithChars, CancellationToken? cancellationToken = null)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append("api/v1/part/get-part-keys?");
                if (keyStartsWithChars != null)
                {
                    urlBuilder_.Append(Uri.EscapeDataString("keyStartsWithChars") + "=").Append(Uri.EscapeDataString(ConvertToString(keyStartsWithChars, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                return await client.DoGetAsync<List<GetPartKeyResults>>(urlBuilder_.ToString(), cancellationToken);

                ////var client_ = _httpClient;
                //try {
                //	using(var request_ = new System.Net.Http.HttpRequestMessage()) {
                //		request_.Method = new System.Net.Http.HttpMethod("GET");
                //		request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                //		PrepareRequest(client_, request_, urlBuilder_);
                //		var url_ = urlBuilder_.ToString();
                //		request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                //		PrepareRequest(client_, request_, url_);

                //		var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                //		try {
                //			var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                //			if(response_.Content != null && response_.Content.Headers != null) {
                //				foreach(var item_ in response_.Content.Headers)
                //					headers_[item_.Key] = item_.Value;
                //			}

                //			ProcessResponse(client_, response_);

                //			var status_ = (int)response_.StatusCode;
                //			if(status_ == 200) {
                //				var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<GetPartKeyResults>>(response_, headers_).ConfigureAwait(false);
                //				if(objectResponse_.Object == null) {
                //					throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                //				}
                //				return objectResponse_.Object;
                //			} else {
                //				var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                //				throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                //			}
                //		} finally {
                //			if(response_ != null)
                //				response_.Dispose();
                //		}
                //	}
                //} finally {
                //}
            }

            /// <summary>returns part details for a vault id</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public Part GetPart(int? id, string vaultId, string key, string srcKey, string srcRevision, bool? includeAttributes, bool? includeDocuments, bool? includePlants, bool? includeSecurity, bool? includeUsers, bool? includeVendors)
            {
                return Task.Run(async () => await GetPartAsync(id, vaultId, key, srcKey, srcRevision, includeAttributes, includeDocuments, includePlants, includeSecurity, includeUsers, includeVendors)).GetAwaiter().GetResult();
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>returns part details for a vault id</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public async Task<Part> GetPartAsync(int? id, string vaultId, string key, string srcKey, string srcRevision, bool? includeAttributes, bool? includeDocuments, bool? includePlants, bool? includeSecurity, bool? includeUsers, bool? includeVendors, CancellationToken? cancellationToken = null)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append("api/v1/part/get-part?");
                if (id != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("id") + "=").Append(System.Uri.EscapeDataString(ConvertToString(id, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (vaultId != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("vaultId") + "=").Append(System.Uri.EscapeDataString(ConvertToString(vaultId, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (key != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("key") + "=").Append(System.Uri.EscapeDataString(ConvertToString(key, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (srcKey != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("srcKey") + "=").Append(System.Uri.EscapeDataString(ConvertToString(srcKey, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (srcRevision != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("srcRevision") + "=").Append(System.Uri.EscapeDataString(ConvertToString(srcRevision, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (includeAttributes != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeAttributes") + "=").Append(System.Uri.EscapeDataString(ConvertToString(includeAttributes, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (includeDocuments != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeDocuments") + "=").Append(System.Uri.EscapeDataString(ConvertToString(includeDocuments, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (includePlants != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includePlants") + "=").Append(System.Uri.EscapeDataString(ConvertToString(includePlants, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (includeSecurity != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeSecurity") + "=").Append(System.Uri.EscapeDataString(ConvertToString(includeSecurity, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (includeUsers != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeUsers") + "=").Append(System.Uri.EscapeDataString(ConvertToString(includeUsers, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                if (includeVendors != null)
                {
                    urlBuilder_.Append(System.Uri.EscapeDataString("includeVendors") + "=").Append(System.Uri.EscapeDataString(ConvertToString(includeVendors, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
                }
                urlBuilder_.Length--;

                return await client.DoGetAsync<Part>(urlBuilder_.ToString(), cancellationToken);

                //var client_ = _httpClient;
                //try {
                //	using(var request_ = new System.Net.Http.HttpRequestMessage()) {
                //		request_.Method = new System.Net.Http.HttpMethod("GET");
                //		request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                //		PrepareRequest(client_, request_, urlBuilder_);
                //		var url_ = urlBuilder_.ToString();
                //		request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                //		PrepareRequest(client_, request_, url_);

                //		var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                //		try {
                //			var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                //			if(response_.Content != null && response_.Content.Headers != null) {
                //				foreach(var item_ in response_.Content.Headers)
                //					headers_[item_.Key] = item_.Value;
                //			}

                //			ProcessResponse(client_, response_);

                //			var status_ = (int)response_.StatusCode;
                //			if(status_ == 200) {
                //				var objectResponse_ = await ReadObjectResponseAsync<Part>(response_, headers_).ConfigureAwait(false);
                //				if(objectResponse_.Object == null) {
                //					throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                //				}
                //				return objectResponse_.Object;
                //			} else {
                //				var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                //				throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                //			}
                //		} finally {
                //			if(response_ != null)
                //				response_.Dispose();
                //		}
                //	}
                //} finally {
                //}
            }

            /// <summary>used for to find latest keys for gcas. returns an array of LookupParts given the starting characters of the key</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public List<Part> GetParts(PartControllerGetPartsRequest body)
            {
                return Task.Run(async () => await GetPartsAsync(body)).GetAwaiter().GetResult();
            }

            /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
            /// <summary>used for to find latest keys for gcas. returns an array of LookupParts given the starting characters of the key</summary>
            /// <returns>Success</returns>
            /// <exception cref="ApiException">A server side error occurred.</exception>
            public async Task<List<Part>> GetPartsAsync(PartControllerGetPartsRequest body, CancellationToken? cancellationToken = null)
            {
                var urlBuilder_ = new System.Text.StringBuilder();
                urlBuilder_.Append("api/v1/part/get-parts") /*.Append(QueryStringBuilder.Build(body, false))*/;

                return await client.DoPostAsync<List<Part>>(urlBuilder_.ToString(), body, cancellationToken);

                //var client_ = _httpClient;
                //try {
                //	using(var request_ = new System.Net.Http.HttpRequestMessage()) {
                //		var content_ = new System.Net.Http.StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(body, _settings.Value));
                //		content_.Headers.ContentType = System.Net.Http.Headers.MediaTypeHeaderValue.Parse("application/json-patch+json");
                //		request_.Content = content_;
                //		request_.Method = new System.Net.Http.HttpMethod("POST");
                //		request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                //		PrepareRequest(client_, request_, urlBuilder_);
                //		var url_ = urlBuilder_.ToString();
                //		request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);
                //		PrepareRequest(client_, request_, url_);

                //		var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                //		try {
                //			var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                //			if(response_.Content != null && response_.Content.Headers != null) {
                //				foreach(var item_ in response_.Content.Headers)
                //					headers_[item_.Key] = item_.Value;
                //			}

                //			ProcessResponse(client_, response_);

                //			var status_ = (int)response_.StatusCode;
                //			if(status_ == 200) {
                //				var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<Part>>(response_, headers_).ConfigureAwait(false);
                //				if(objectResponse_.Object == null) {
                //					throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                //				}
                //				return objectResponse_.Object;
                //			} else {
                //				var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                //				throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                //			}
                //		} finally {
                //			if(response_ != null)
                //				response_.Dispose();
                //		}
                //	}
                //} finally {
                //}
            }

        }

        public class ObsoletePartsRegion : ClientRegion
        {
            internal ObsoletePartsRegion(DepotClient client) : base(client) { }

            /// <summary>
            /// Method: GET
            /// </summary>
            [Obsolete("Old pass routes will become obsolete.")]
            public static string ROUTE_FIND_PART_KEY => "api/v1/pass/find-part-key";
            /// <summary>
            /// Values be used as a filter in the composition lookup.
            /// </summary>
            /// <returns>A list of Part Key/Name in Depot</returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public async Task<List<FindPartKeyResult>> FindPartKeyAsync(string key)
            {
                string uri = ROUTE_FIND_PART_KEY + "?key=" + Uri.EscapeDataString(key);
                Logger.Trace("FindPartKeyAsync({0}): calling {1}", key, uri);
                return await client.DoGetAsync<List<FindPartKeyResult>>(uri);
            }

            /// <summary>
            /// Values be used as a filter in the composition lookup.
            /// </summary>
            /// <returns>A list of Part Key/Name in Depot</returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public List<FindPartKeyResult> FindPartKey(string key)
            {
                var uri = ROUTE_FIND_PART_KEY + "?key=" + Uri.EscapeDataString(key);
                Logger.Trace("FindPartKey({0}): calling {1}", key, uri);
                return client.DoGet<List<FindPartKeyResult>>(uri);
            }

            /// <summary>
            /// Method: GET
            /// </summary>
            [Obsolete("Old pass routes will become obsolete.")]
            public static string ROUTE_FIND_BEST_PART_KEY => "api/v1/pass/find-best-part";
            /// <summary>
            /// Best use for autocomplete, focusing on the latest (ie "best") versions. Key must be at least 3 chars.
            /// </summary>
            /// <param name="key">key to search on</param>
            /// <param name="passOnly">Only include results in PASS (default: true)</param>
            /// <returns>A list of Part Key/Name in Depot</returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public async Task<List<DepotPart>> FindBestPartKeysAsync(string key, bool passOnly = true)
            {
                if (string.IsNullOrEmpty(key) || key.Length < 3)
                    return new List<DepotPart>(0);
                var uri = $"{ROUTE_FIND_BEST_PART_KEY}?key={Uri.EscapeDataString(key)}&passOnly={passOnly}";
                Logger.Trace("FindBestPartKeysAsync({0}): calling {1}", key, uri);
                return await client.DoGetAsync<List<DepotPart>>(uri);
            }

            /// <summary>
            /// Best use for autocomplete, focusing on the latest (ie "best") versions. Key must be at least 3 chars.
            /// </summary>
            /// <param name="key">key to search on</param>
            /// <param name="passOnly">Only include results in PASS (default: true)</param>
            /// <returns>A list of Part Key/Name in Depot</returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public List<DepotPart> FindBestPartKeys(string key, bool passOnly = true)
            {
                if (string.IsNullOrEmpty(key) || key.Length < 3)
                    return new List<DepotPart>(0);
                var uri = $"{ROUTE_FIND_BEST_PART_KEY}?key={Uri.EscapeDataString(key)}&passOnly={passOnly}";
                Logger.Trace("FindBestPartKeys({0}): calling {1}", key, uri);
                return client.DoGet<List<DepotPart>>(uri);
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            [Obsolete("Old pass routes will become obsolete.")]
            public static string ROUTE_GET_BEST_PARTS_BY_KEYS => "api/v1/pass/get-best-parts-by-keys";
            /// <summary>
            /// List the latest (ie "best") versions for SrcKeys (ie GCAS).
            /// </summary>
            /// <param name="keys">SrcKey(s) to search on</param>
            /// <param name="passOnly">Only include results in PASS (default: true)</param>
            /// <returns>A list of "Best ObsoleteParts" in Depot</returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public async Task<List<DepotPart>> FindBestPartsByKeysAsync(IEnumerable<string> keys, bool passOnly = true)
            {
                if (!(keys?.Any() ?? false))
                    return new List<DepotPart>(0);
                Logger.Trace("FindBestPartsByKeysAsync: calling {0}", ROUTE_GET_BEST_PARTS_BY_KEYS);
                return await client.DoPostAsync<List<DepotPart>>(ROUTE_GET_BEST_PARTS_BY_KEYS, new { keys, passOnly });
            }

            /// <summary>
            /// List the latest (ie "best") versions for SrcKeys (ie GCAS).
            /// </summary>
            /// <param name="keys">SrcKey(s) to search on</param>
            /// <param name="passOnly">Only include results in PASS (default: true)</param>
            /// <returns>A list of "Best ObsoleteParts" in Depot</returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public List<DepotPart> FindBestPartsByKeys(IEnumerable<string> keys, bool passOnly = true)
            {
                if (!(keys?.Any() ?? false))
                    return new List<DepotPart>(0);

                var url = ROUTE_GET_BEST_PARTS_BY_KEYS; // + $"?Keys={string.Join("&Keys=", keys)}&PassOnly={passOnly}";
                Logger.Trace("FindBestPartsByKeysAsync: calling {0}", url);
                return client.DoPost<List<DepotPart>>(url, new { keys, passOnly });
            }

            /// <summary>
            /// Method: GET
            /// </summary>
            [Obsolete("Old pass routes will become obsolete.")]
            public static string ROUTE_PART_LOOKUP => "api/v1/pass/search-parts-key?keyPart={0}";
            /// <summary>
            /// Method: POST
            /// </summary>
            [Obsolete("Old pass routes will become obsolete.")]
            public static string ROUTE_PART_LOOKUP_SEARCH => "api/v1/pass/parts-search";
            /// <summary>
            /// 
            /// </summary>
            /// <param name="keyPart">The beginning of a part key</param>
            /// <param name="keyPattern"></param>
            /// <returns></returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public async Task<List<DepotPart>> LookupPartsByKeyAsync(string keyPart, string keyPattern = null)
            {
                Logger.Trace("LookupPartsByKeyAsync: keyPart={0} keyPattern={1}", PrepareDebugString(keyPart, Logger.IsDebugEnabled), PrepareDebugString(keyPattern, Logger.IsDebugEnabled));
                if (string.IsNullOrEmpty(keyPart))
                    return new List<DepotPart>(0);

                if (string.IsNullOrEmpty(keyPattern))
                {
                    string callPart = string.Format(ROUTE_PART_LOOKUP, Uri.EscapeDataString(keyPart));
                    Logger.Trace("LookupPartsByKeyAsync: calling={0}", callPart);
                    return await client.DoGetAsync<List<DepotPart>>(callPart);
                }

                Logger.Trace("LookupPartsByKeyAsync: calling={0}", ROUTE_PART_LOOKUP_SEARCH);
                return await client.DoPostAsync<List<DepotPart>>(ROUTE_PART_LOOKUP_SEARCH, new { term = keyPart, keyPattern });
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="keyPart">The beginning of a part key</param>
            /// <param name="keyPattern"></param>
            /// <returns></returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public List<DepotPart> LookupPartsByKey(string keyPart, string keyPattern = null)
            {
                Logger.Trace("LookupPartsByKey: keyPart={0} keyPattern={1}", PrepareDebugString(keyPart, Logger.IsDebugEnabled), PrepareDebugString(keyPattern, Logger.IsDebugEnabled));
                if (string.IsNullOrEmpty(keyPart))
                    return new List<DepotPart>(0);

                if (string.IsNullOrEmpty(keyPattern))
                {
                    string callPart = string.Format(ROUTE_PART_LOOKUP, Uri.EscapeDataString(keyPart));
                    Logger.Trace("LookupPartsByKey: calling={0}", callPart);
                    return client.DoGet<List<DepotPart>>(callPart);
                }

                Logger.Trace("LookupPartsByKey: calling={0}", ROUTE_PART_LOOKUP_SEARCH);
                return client.DoPost<List<DepotPart>>(ROUTE_PART_LOOKUP_SEARCH, new { term = keyPart, keyPattern });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            [Obsolete("Old pass routes will become obsolete.")]
            public static string ROUTE_GET_PARTS_BY_KEYS => "api/v1/pass/get-parts-by-keys";
            /// <summary>
            /// Gets a list of DepotPart(s) by Key
            /// </summary>
            /// <param name="keys">The part keys</param>
            /// <returns></returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public async Task<List<DepotPart>> GetPartsByKeysAsync(IEnumerable<string> keys)
            {
                Logger.Trace("GetPartsByKeysAsync: calling={0}", ROUTE_GET_PARTS_BY_KEYS);
                return await client.DoPostAsync<List<DepotPart>>(ROUTE_GET_PARTS_BY_KEYS, new { keys });
            }

            /// <summary>
            /// Gets a list of DepotPart(s) by Key
            /// </summary>
            /// <param name="keys">The part keys</param>
            /// <returns></returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public List<DepotPart> GetPartsByKeys(IEnumerable<string> keys)
            {
                Logger.Trace("LookupPartsByKeys: calling={0}", ROUTE_GET_PARTS_BY_KEYS);
                return client.DoPost<List<DepotPart>>(ROUTE_GET_PARTS_BY_KEYS, new { keys });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            [Obsolete("Old pass routes will become obsolete.")]
            public static string ROUTE_GET_PART_ATTRS_BY_PART_ID => "api/v1/pass/search-part-attrs-id";
            /// <summary>
            /// 
            /// </summary>
            /// <param name="partIds"></param>
            /// <param name="attrNameFilter">(optional) List of attribute names to search for.</param>
            /// <returns></returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public async Task<List<DepotPartAttribute>> GetPartAttributesByPartIdsAsync(IEnumerable<int> partIds, IEnumerable<string> attrNameFilter = null)
            {
                if (partIds == null)
                    return new List<DepotPartAttribute>(0);

                Logger.Trace("GetPartAttributesByPartIdsAsync: calling={0}", ROUTE_GET_PART_ATTRS_BY_PART_ID);
                return await client.DoPostAsync<List<DepotPartAttribute>>(ROUTE_GET_PART_ATTRS_BY_PART_ID, new { partIds, attrNameFilter });
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="partIds"></param>
            /// <param name="attrNameFilter">(optional) List of attribute names to search for.</param>
            /// <returns></returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public List<DepotPartAttribute> GetPartAttributesByPartIds(IEnumerable<int> partIds, IEnumerable<string> attrNameFilter = null)
            {
                if (partIds == null)
                    return new List<DepotPartAttribute>(0);

                Logger.Trace("GetPartAttributesByPartIds: calling={0}", ROUTE_GET_PART_ATTRS_BY_PART_ID);
                return client.DoPost<List<DepotPartAttribute>>(ROUTE_GET_PART_ATTRS_BY_PART_ID, new { partIds, attrNameFilter });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            [Obsolete("Old pass routes will become obsolete.")]
            public static string ROUTE_GET_PART_ATTRS_BY_PART_KEY => "api/v1/pass/search-part-attrs-key";
            /// <summary>
            /// 
            /// </summary>
            /// <param name="partKeys"></param>
            /// <param name="attrNameFilter">(optional) List of attribute names to search for.</param>
            /// <returns></returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public async Task<List<DepotPartAttribute>> GetPartAttributesByPartKeysAsync(IEnumerable<string> partKeys, IEnumerable<string> attrNameFilter = null)
            {
                if (partKeys == null)
                    return new List<DepotPartAttribute>(0);

                Logger.Trace("GetPartAttributesByPartKeysAsync: calling={0}", ROUTE_GET_PART_ATTRS_BY_PART_KEY);
                return await client.DoPostAsync<List<DepotPartAttribute>>(ROUTE_GET_PART_ATTRS_BY_PART_KEY, new { partKeys, attrNameFilter });
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="partKeys"></param>
            /// <param name="attrNameFilter">(optional) List of attribute names to search for.</param>
            /// <returns></returns>
            [Obsolete("Old pass routes will become obsolete.")]
            public List<DepotPartAttribute> GetPartAttributesByPartKeys(IEnumerable<string> partKeys, IEnumerable<string> attrNameFilter = null)
            {
                if (partKeys == null)
                    return new List<DepotPartAttribute>(0);

                Logger.Trace("GetPartAttributesByPartKeys: calling={0}", ROUTE_GET_PART_ATTRS_BY_PART_KEY);
                return client.DoPost<List<DepotPartAttribute>>(ROUTE_GET_PART_ATTRS_BY_PART_KEY, new { partKeys, attrNameFilter });
            }

        }

        public class CompositionsRegion : ClientRegion
        {
            internal CompositionsRegion(DepotClient client) : base(client) { }

            /// <summary>
            /// Method: GET
            /// </summary>
            public static string ROUTE_LIST_COMP_TYPES => "api/v1/pass/list-comp-types";
            /// <summary>
            /// Values be used as a filter in the composition lookup.
            /// </summary>
            /// <returns>A list of CompositionTypes in Depot</returns>
            public async Task<List<string>> ListCompositionTypesAsync()
            {
                Logger.Trace("ListCompositionTypesAsync(): calling {0}", ROUTE_LIST_COMP_TYPES);
                return await client.DoGetAsync<List<string>>(ROUTE_LIST_COMP_TYPES);
            }


            /// <summary>
            /// Values be used as a filter in the composition lookup.
            /// </summary>
            /// <returns>A list of CompositionTypes in Depot</returns>
            public List<string> ListCompositionTypes()
            {
                //return ListCompositionTypesAsync().Result;
                return client.DoGet<List<string>>(ROUTE_LIST_COMP_TYPES);
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_GET_COMPOSITION => "api/v1/composition/by-key";
            /// <summary>
            /// Gets the full composition
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public async Task<List<DepotCompositionPart>> GetCompositionForPartKeyAsync(string key)
            {
                Logger.Trace("GetCompositionForPartKeyAsync[{0}]: calling={1}", key, ROUTE_GET_COMPOSITION);
                return await client.DoPostAsync<List<DepotCompositionPart>>(ROUTE_GET_COMPOSITION, new { term = key });
            }

            /// <summary>
            /// Gets the full composition
            /// </summary>
            /// <param name="key"></param>
            /// <returns></returns>
            public List<DepotCompositionPart> GetCompositionForPartKey(string key)
            {
                Logger.Trace("LookupCompositionForPartKey[{0}]: calling={1}", key, ROUTE_GET_COMPOSITION);
                return client.DoPost<List<DepotCompositionPart>>(ROUTE_GET_COMPOSITION, new { term = key });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_LOOKUP_COMPOSITION => "api/v1/pass/search-comp";
            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <param name="compositionTypes"></param>
            /// <param name="maxLevels"></param>
            /// <returns></returns>
            public async Task<List<DepotCompositionPart>> LookupCompositionForPartKeyAsync(string key, IEnumerable<string> compositionTypes = null, int? maxLevels = null)
            {
                Logger.Trace("LookupCompositionForPartKeyAsync: calling={0}", ROUTE_LOOKUP_COMPOSITION);
                return await client.DoPostAsync<List<DepotCompositionPart>>(ROUTE_LOOKUP_COMPOSITION, new { key, compositionTypes, maxLevels });
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="key"></param>
            /// <param name="compositionTypes"></param>
            /// <param name="maxLevels"></param>
            /// <returns></returns>
            public List<DepotCompositionPart> LookupCompositionForPartKey(string key, IEnumerable<string> compositionTypes = null, int? maxLevels = null)
            {
                Logger.Trace("LookupCompositionForPartKey: calling={0}", ROUTE_LOOKUP_COMPOSITION);
                return client.DoPost<List<DepotCompositionPart>>(ROUTE_LOOKUP_COMPOSITION, new { key, compositionTypes, maxLevels });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_LOOKUP_REVERSE_COMPOSITION => "api/v1/composition/reverse-search";
            /// <summary>
            /// Returns single level by ChildPart.Key, reversed path (child->parent) with ParentPart info.
            /// </summary>
            /// <param name="key"></param>
            /// <param name="compositionTypes"></param>
            /// <param name="next"></param>
            /// <param name="offset"></param>
            /// <returns></returns>
            public async Task<List<DepotCompositionPart>> ReversLookupCompForChildKeyAsync(string key, IEnumerable<string> compositionTypes = null, int? next = null, int? offset = null)
            {
                Logger.Trace("ReversLookupCompForChildKeyAsync: calling={0}", ROUTE_LOOKUP_REVERSE_COMPOSITION);
                return await client.DoPostAsync<List<DepotCompositionPart>>(ROUTE_LOOKUP_REVERSE_COMPOSITION, new { key, compositionTypes, next, offset });
            }

            /// <summary>
            /// Returns single level by ChildPart.Key, reversed path (child->parent) with ParentPart info.
            /// </summary>
            /// <param name="key"></param>
            /// <param name="compositionTypes"></param>
            /// <param name="next"></param>
            /// <param name="offset"></param>
            /// <returns></returns>
            public List<DepotCompositionPart> ReversLookupCompForChildKey(string key, IEnumerable<string> compositionTypes = null, int? next = null, int? offset = null)
            {
                Logger.Trace("ReversLookupCompForChildKey: calling={0}", ROUTE_LOOKUP_REVERSE_COMPOSITION);
                return client.DoPost<List<DepotCompositionPart>>(ROUTE_LOOKUP_REVERSE_COMPOSITION, new { key, compositionTypes, next, offset });
            }

        }

        public class BillOfSubstanceRegion : ClientRegion
        {
            internal BillOfSubstanceRegion(DepotClient client) : base(client) { }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_BOS_CALCULATE => "api/v1/billofsubstance/calculate?key={0}&forSDS={1}&requireSDSSpecific={2}";
            /// <summary>
            /// calculate the GPS BOS real time (for depot api only)
            /// </summary>
            /// <param name="key">key for the FOP</param>
            /// <param name="forSDS">indicate whether the SDS BOS is desired or the "normal" BOS</param>
            /// <param name="requireSDSSpecific">indicate if SDS is desired but no SDS specific composition is found, should the "normal" bos be returned instead</param>
            /// <returns></returns>
            public async Task<T> CalculateAsync<T>(string key, bool forSDS = false, bool requireSDSSpecific = false)
            {
                if (string.IsNullOrEmpty(key))
                    return default(T);

                string uri = string.Format(ROUTE_BOS_CALCULATE, new object[] { Uri.EscapeDataString(key), forSDS, requireSDSSpecific });
                Logger.Trace("CalculateAsync: key={0} forSDS={1} requireSDSSpecific={2}", key, forSDS, requireSDSSpecific);
                return await client.DoPostAsync<T>(uri, null);
            }

            /// <summary>
            /// calculate the GPS BOS real time (for depot api only)
            /// </summary>
            /// <param name="key">key for the FOP</param>
            /// <param name="forSDS">indicate whether the SDS BOS is desired or the "normal" BOS</param>
            /// <param name="requireSDSSpecific">indicate if SDS is desired but no SDS specific composition is found, should the "normal" bos be returned instead</param>
            /// <returns></returns>
            public T Calculate<T>(string key, bool forSDS = false, bool requireSDSSpecific = false)
            {
                if (string.IsNullOrEmpty(key))
                    return default(T);

                string uri = string.Format(ROUTE_BOS_CALCULATE, new object[] { Uri.EscapeDataString(key), forSDS, requireSDSSpecific });
                Logger.Trace("Calculate: key={0} forSDS={1} requireSDSSpecific={2}", key, forSDS, requireSDSSpecific);
                return client.DoPost<T>(uri, null);
            }

            /// <summary>
            /// Method: GET
            /// </summary>
            public static string ROUTE_BOS_CALCULATE_EXTERNAL => "api/v1/billofsubstance/get-calculated-bos?key={0}&forSDS={1}&requireSDSSpecific={2}&includeFragranceComposition={3}&allowResultWhenBosErrors={4}";

            /// <summary>
            /// calculate the GPS BOS real time (for external apps)
            /// </summary>
            /// <param name="key">key for the FOP</param>
            /// <param name="forSDS">indicate whether the SDS BOS is desired or the "normal" BOS</param>
            /// <param name="requireSDSSpecific">indicate if SDS is desired but no SDS specific composition is found, should the "normal" bos be returned instead</param>
            /// <param name="includeFragranceComposition"></param>
            /// <param name="allowResultWhenBosErrors"></param>
            /// <returns></returns>
            public async Task<BillOfSubstance> CalculateExternalAsync(string key, bool forSDS = false, bool requireSDSSpecific = false, bool includeFragranceComposition = false, bool allowResultWhenBosErrors = false)
            {
                if (string.IsNullOrEmpty(key))
                    return null;

                string uri = string.Format(ROUTE_BOS_CALCULATE_EXTERNAL, new object[] { Uri.EscapeDataString(key), forSDS, requireSDSSpecific, includeFragranceComposition, allowResultWhenBosErrors });
                Logger.Trace("CalculateExternal: {0}", new object[] { uri });
                return await client.DoGetAsync<BillOfSubstance>(uri);
            }

            /// <summary>
            /// calculate the GPS BOS real time (for external apps)
            /// </summary>
            /// <param name="key">key for the FOP</param>
            /// <param name="forSDS">indicate whether the SDS BOS is desired or the "normal" BOS</param>
            /// <param name="requireSDSSpecific">indicate if SDS is desired but no SDS specific composition is found, should the "normal" bos be returned instead</param>
            /// <param name="includeFragranceComposition"></param>
            /// <param name="allowResultWhenBosErrors"></param>
            /// <returns></returns>
            public BillOfSubstance CalculateExternal(string key, bool forSDS = false, bool requireSDSSpecific = false, bool includeFragranceComposition = false, bool allowResultWhenBosErrors = false)
            {
                if (string.IsNullOrEmpty(key))
                    return null;

                string uri = string.Format(ROUTE_BOS_CALCULATE_EXTERNAL, new object[] { Uri.EscapeDataString(key), forSDS, requireSDSSpecific, includeFragranceComposition, allowResultWhenBosErrors });
                Logger.Trace("CalculateExternal: {0}", new object[] { uri });
                return client.DoGet<BillOfSubstance>(uri);
            }

            internal class QueueCalculateResult
            {
                public int Sent { get; set; }
            }
            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_BOS_ENQUEUE_CALCULATE => "api/v1/billofsubstance/enqueue?keyList={0}";
            /// <summary>
            /// queue recalculation of a list of parts
            /// </summary>
            /// <param name="keyList">part keys should be the full part key (usually gcas.rev) from depot</param>
            /// <returns>number of recalcs queued (if less than specified, key was not found)</returns>
            public async Task<int?> QueueCalculateAsync(IEnumerable<string> keyList)
            {
                if (keyList == null || !keyList.Any())
                    return 0;

                keyList = keyList.Where(key => !string.IsNullOrWhiteSpace(key));
                if (!keyList.Any())
                    return 0;

                var joined = string.Join(",", keyList.Select(Uri.EscapeDataString));
                string uri = string.Format(ROUTE_BOS_ENQUEUE_CALCULATE, new object[] { joined });
                Logger.Trace("QueueCalculateAsync: keys={0}", joined);

                var response = await client.DoPostAsync<QueueCalculateResult>(uri, null);
                return response?.Sent;
            }

            /// <summary>
            /// queue recalculation of a list of parts
            /// </summary>
            /// <param name="keyList">part keys should be the full part key (usually gcas.rev) from depot</param>
            /// <returns>number of recalcs queued (if less than specified, key was not found)</returns>
            public int? QueueCalculate(IEnumerable<string> keyList)
            {
                if (keyList == null || !keyList.Any())
                    return 0;

                keyList = keyList.Where(key => !string.IsNullOrWhiteSpace(key));
                if (!keyList.Any())
                    return 0;

                var joined = Uri.EscapeDataString(string.Join(",", keyList));
                string uri = string.Format(ROUTE_BOS_ENQUEUE_CALCULATE, new object[] { joined });
                Logger.Trace("QueueCalculate: keys={0}", joined);

                var response = client.DoPost<QueueCalculateResult>(uri, null);
                return response?.Sent;
            }


            /// <summary>
            /// Method: GET
            /// </summary>
            public static string ROUTE_BOS_CALCULATE_XLSX => "api/v1/billofsubstance/calculate/xlsx/{0}";
            /// <summary>
            /// calculate a GPS-BOS adhoc, export to excel
            /// results are not persisted
            /// </summary>
            /// <param name="key">depot part key for which to calcualte the bos</param>
            /// <param name="destFolder">Folder to download file to (default=temp)</param>
            /// <param name="destFileName">Name of file to create (default=from download, or random temp file)</param>
            /// <returns>xlsx file</returns>
            public async Task<FileInfo> CalculateExcelAsync(string key, string destFolder = null, string destFileName = null)
            {
                var uri = string.Format(ROUTE_BOS_CALCULATE_XLSX, new object[] { Uri.EscapeDataString(key) });
                return await client.DoGetReadAsFileAsync(uri, destFolder, destFileName);
            }

            /// <summary>
            /// calculate a GPS-BOS adhoc, export to excel
            /// results are not persisted
            /// </summary>
            /// <param name="key">depot part key for which to calcualte the bos</param>
            /// <returns>xlsx file</returns>
            public FileInfo CalculateExcel(string key)
            {
                // TODO: client methods for fetching bytes
                // TODO: need to return object type { string Name, byte[] Data }
                throw new NotImplementedException("CalculateExcel has not been implemented");
            }

            public static string ROUTE_BOS_CALCULATE_ASSESSMENT_SPEC => "api/v1/billofsubstance/calculate-assessment-spec?partKey={0}&forSds={1}&includeFragranceComposition={2}&includeGpsConfidentialComposition=True";
            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T">List&lt;CompositionDto&gt;</typeparam>
            /// <param name="partKey"></param>
            /// <param name="forSds"></param>
            /// <param name="includeFragranceComposition"></param>
            /// <returns>List&lt;CompositionDto&gt;</returns>
            public async Task<T> CalculateAssessmentSpecAsync<T>(string partKey, bool forSds = false, bool includeFragranceComposition = false)
            {
                if (string.IsNullOrEmpty(partKey))
                    return default(T);

                string uri = string.Format(ROUTE_BOS_CALCULATE_ASSESSMENT_SPEC, new object[] { Uri.EscapeDataString(partKey), forSds, includeFragranceComposition });
                Logger.Trace("CalculateAssessmentSpecAsync: partKey={0} forSds={1} includeFragranceComposition={2}", partKey, forSds, includeFragranceComposition);
                return await client.DoGetAsync<T>(uri);
            }


            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="T">List&lt;CompositionDto&gt;</typeparam>
            /// <param name="partKey"></param>
            /// <param name="forSds"></param>
            /// <param name="includeFragranceComposition"></param>
            /// <returns>List&lt;CompositionDto&gt;</returns>
            public T CalculateAssessmentSpec<T>(string partKey, bool forSds = false, bool includeFragranceComposition = false)
            {
                if (string.IsNullOrEmpty(partKey))
                    return default(T);

                string uri = string.Format(ROUTE_BOS_CALCULATE_ASSESSMENT_SPEC, new object[] { Uri.EscapeDataString(partKey), forSds, includeFragranceComposition });
                Logger.Trace("CalculateAssessmentSpec: partKey={0} forSds={1} includeFragranceComposition={2}", partKey, forSds, includeFragranceComposition);
                return client.DoGet<T>(uri);
            }

            public static string ROUTE_BOS_GET_CALCULATED_ASSESSMENT_SPEC => "api/v1/billofsubstance/get-calculated-assessment-spec?partKey={0}&forSds={1}&includeFragranceComposition={2}&includeGpsConfidentialComposition={3}";
            /// <summary>
            /// 
            /// </summary>
            /// <param name="partKey"></param>
            /// <param name="forSds"></param>
            /// <param name="includeFragranceComposition"></param>
            /// <returns></returns>
            public async Task<AssessmentSpecResult> GetCalculatedAssessmentSpecAsync(string partKey, bool forSds = false, bool includeFragranceComposition = false, bool includeGpsConfidentialComposition = false)
            {
                if (string.IsNullOrEmpty(partKey))
                    return null;

                //KE7777 updated uri line from github on 20201015
                //string uri = string.Format(ROUTE_BOS_GET_CALCULATED_ASSESSMENT_SPEC, new object[] { Uri.EscapeDataString(partKey), forSds, includeFragranceComposition, includeGpsConfidentialComposition });
                string uri = string.Format(ROUTE_BOS_GET_CALCULATED_ASSESSMENT_SPEC, new object[] { Uri.EscapeDataString(partKey), forSds.ToString().ToLower(), includeFragranceComposition.ToString().ToLower(), includeGpsConfidentialComposition.ToString().ToLower() });
                Logger.Trace("GetCalculatedAssessmentSpecAsync: partKey={0} forSds={1} includeFragranceComposition={2} includeGpsConfidentialComposition={3}", partKey, forSds, includeFragranceComposition, includeGpsConfidentialComposition);
                return await client.DoPostAsync<AssessmentSpecResult>(uri, null);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="partKey"></param>
            /// <param name="forSds"></param>
            /// <param name="includeFragranceComposition"></param>
            /// <returns></returns>
            public AssessmentSpecResult GetCalculatedAssessmentSpec(string partKey, bool forSds = false, bool includeFragranceComposition = false, bool includeGpsConfidentialComposition = false)
            {
                if (string.IsNullOrEmpty(partKey))
                    return null;

                //KE7777 updated uri line from github on 20201015
                //string uri = string.Format(ROUTE_BOS_GET_CALCULATED_ASSESSMENT_SPEC, new object[] { Uri.EscapeDataString(partKey), forSds, includeFragranceComposition, includeGpsConfidentialComposition });
                string uri = string.Format(ROUTE_BOS_GET_CALCULATED_ASSESSMENT_SPEC, new object[] { Uri.EscapeDataString(partKey), forSds.ToString().ToLower(), includeFragranceComposition.ToString().ToLower(), includeGpsConfidentialComposition.ToString().ToLower() });
                Logger.Trace("GetCalculatedAssessmentSpec: partKey={0} forSds={1} includeFragranceComposition={2} includeGpsConfidentialComposition={3}", partKey, forSds, includeFragranceComposition, includeGpsConfidentialComposition);
                return client.DoPost<AssessmentSpecResult>(uri, null);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="part"></param>
            /// <param name="forSds">indicate whether the SDS BOS is desired or the "normal" BOS</param>
            /// <param name="includeFragranceComposition">Break down perfumes if possible</param>
            /// <param name="requireSDSSpecific">indicate if SDS is desired but no SDS specific composition is found, should the "normal" calculation be returned instead (always null for assessment spec)</param>
            /// <param name="partTypesForAssessmentSpecs">Part types here will return a calculated assessment spec, otherwise will return a calculated BOS.</param>
            /// <param name="allowResultWhenBosErrors">Returns a result even if there are BOS errors.</param>
            /// <returns></returns>
            public async Task<ICalculatedComponentsResult> GetCalculatedComponentsForPartAsync(DepotPart part, bool forSds = false, bool includeFragranceComposition = false, bool requireSDSSpecific = false, IEnumerable<string> partTypesForAssessmentSpecs = null, bool allowResultWhenBosErrors = false)
            {
                var partKey = part?.PartKey;
                if (string.IsNullOrEmpty(partKey))
                    return new BillOfSubstance { ProductPart = part, IsSDSSpecific = false, Errors = new List<string> { "PartKey was empty" } };

                var usesAssessmentSpec = !string.IsNullOrEmpty(part?.PartTypeName)
                    && (partTypesForAssessmentSpecs ?? RAW_MATERIAL_PART_TYPE_NAMES)
                            .Any(n => !string.IsNullOrEmpty(n) && n.Equals(part.PartTypeName, StringComparison.OrdinalIgnoreCase));

                if (usesAssessmentSpec)
                {
                    // Calculate Assessment Spec
                    return await GetCalculatedAssessmentSpecAsync(partKey, forSds, includeFragranceComposition);
                }
                else
                {
                    // Calculate BOS
                    return await CalculateExternalAsync(partKey, forSds, requireSDSSpecific, includeFragranceComposition, allowResultWhenBosErrors);
                }
            }

            //KE77777 on 20201013
            /*
            public async Task<ICalculatedComponentsResult> GetCalculatedComponentsForPartAsync(Part part, bool forSds = false, bool includeFragranceComposition = false, bool requireSDSSpecific = false, IEnumerable<string> partTypesForAssessmentSpecs = null, bool allowResultWhenBosErrors = false)
            {
                var partKey = part?.Key;
                if (string.IsNullOrEmpty(partKey))
                    return new BillOfSubstance { ProductPart = part, IsSDSSpecific = false, Errors = new List<string> { "PartKey was empty" } };

                //var usesAssessmentSpec = !string.IsNullOrEmpty(part?.PartTypeName)
                var usesAssessmentSpec = !string.IsNullOrEmpty(part?.PartType)

                    && (partTypesForAssessmentSpecs ?? RAW_MATERIAL_PART_TYPE_NAMES)
                            .Any(n => !string.IsNullOrEmpty(n) && n.Equals(part.PartTypeName, StringComparison.OrdinalIgnoreCase));

                if (usesAssessmentSpec)
                {
                    // Calculate Assessment Spec
                    return await GetCalculatedAssessmentSpecAsync(partKey, forSds, includeFragranceComposition);
                }
                else
                {
                    // Calculate BOS
                    return await CalculateExternalAsync(partKey, forSds, requireSDSSpecific, includeFragranceComposition, allowResultWhenBosErrors);
                }
            }
            */
            //END KE77777 on 20201013

            /// <summary>GET /api/v1/billofsubstance/get-warnings-by-part-id/{id}</summary>
            public static string ROUTE_BOS_GET_WARNINGS_BY_PART_ID => "api/v1/billofsubstance/get-warnings-by-part-id/{0}";

            /// <summary>
            /// Gets the Calculation warnings for a Part (ie for "GPS BOS" or "Assessment Spec")
            /// </summary>
            /// <param name="partId">The Depot part Id</param>
            /// <returns>List of warnings, if any.</returns>
            public async Task<List<string>> GetWarningsByPartIdAsync(int partId)
            {
                if (partId == 0)
                    return new List<string>(0);

                string uri = string.Format(ROUTE_BOS_GET_WARNINGS_BY_PART_ID, new object[] { partId });
                Logger.Trace("CalculateAssessmentSpecAsync: partId={0}", partId);
                return (await client.DoGetAsync<List<string>>(uri)) ?? new List<string>(0);
            }

            /// <summary>
            /// Gets the Calculation warnings for a Part (ie for "GPS BOS" or "Assessment Spec")
            /// </summary>
            /// <param name="partId">The Depot part Id</param>
            /// <returns>List of warnings, if any.</returns>
            public List<string> GetWarningsByPartId(int partId)
            {
                if (partId == 0)
                    return new List<string>(0);

                string uri = string.Format(ROUTE_BOS_GET_WARNINGS_BY_PART_ID, new object[] { partId });
                Logger.Trace("CalculateAssessmentSpecAsync: partId={0}", partId);
                return client.DoGet<List<string>>(uri);
            }
        }

        public class IntegrationRegion : ClientRegion
        {
            internal IntegrationRegion(DepotClient client) : base(client) { }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_PULL_PART => "api/v1/plm/pull-part?srcKey={0}&srcRevision={1}&plmTypeName={2}";
            /// <summary>
            ///  Pull a specific gcas revision from PLM
            /// </summary>
            /// <param name="srcKey"></param>
            /// <param name="srcRevision"></param>
            /// <param name="plmTypeName"></param>
            /// <returns></returns>
            public async Task PullPartAsync(string srcKey, string srcRevision = null, string plmTypeName = null)
            {
                if (string.IsNullOrEmpty(srcKey))
                    return;

                string uri = string.Format(ROUTE_PULL_PART, Uri.EscapeDataString(srcKey), Uri.EscapeDataString(srcRevision ?? ""), Uri.EscapeDataString(plmTypeName ?? ""));
                Logger.Trace("PullPartAsync: srcKey={0} srcRev={1} plmType={2}", srcKey, srcRevision, plmTypeName);
                await client.DoPostAsync(uri, null);
            }

            /// <summary>
            ///  Pull a specific gcas revision from PLM
            /// </summary>
            /// <param name="srcKey"></param>
            /// <param name="srcRevision"></param>
            /// <param name="plmTypeName"></param>
            /// <returns></returns>
            public void PullPart(string srcKey, string srcRevision = null, string plmTypeName = null)
            {
                if (string.IsNullOrEmpty(srcKey))
                    return;

                string uri = string.Format(ROUTE_PULL_PART, Uri.EscapeDataString(srcKey), Uri.EscapeDataString(srcRevision ?? ""), Uri.EscapeDataString(plmTypeName ?? ""));
                Logger.Trace("PullPart: srcKey={0} srcRev={1} plmType={2}", srcKey, srcRevision, plmTypeName);
                client.DoPost(uri, null);
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_PULL_PARTS => "api/v1/plm/pull-parts?keys={0}&plmTypeName={1}";
            /// <summary>
            /// 
            /// </summary>
            /// <param name="keys">comma or whitespace delimited list of keys</param>
            /// <param name="plmTypeName"></param>
            /// <returns></returns>
            public async Task PullPartsAsync(string keys, string plmTypeName = null)
            {
                if (string.IsNullOrEmpty(keys))
                    return;

                string uri = string.Format(ROUTE_PULL_PARTS, Uri.EscapeDataString(keys), Uri.EscapeDataString(plmTypeName ?? ""));
                Logger.Trace("PullPartsAsync: srcKey={0} plmType={1} uri={2}", keys, plmTypeName, uri);
                await client.DoPostAsync(uri, null);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="keys">comma or whitespace delimited list of keys</param>
            /// <param name="plmTypeName"></param>
            /// <returns></returns>
            public void PullParts(string keys, string plmTypeName = null)
            {
                if (string.IsNullOrEmpty(keys))
                    return;

                string uri = string.Format(ROUTE_PULL_PARTS, Uri.EscapeDataString(keys), Uri.EscapeDataString(plmTypeName ?? ""));
                Logger.Trace("PullPart: srcKey={0} plmType={1} uri={2}", keys, plmTypeName, uri);
                client.DoPost(uri, null);
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_PULL_FORUMLA_FROM_ENGINUITY => "api/v1/enginuity/pull-formula?formulaNumber={0}";
            /// <summary>
            /// Pulls formula from enginuity and persists to Depot (DOES NOT send to PASS)
            /// </summary>
            /// <param name="formulaNumber"></param>
            /// <returns></returns>
            public async Task<EnginuityFormula> PullForumulaFromEnginuityAsync(string formulaNumber)
            {
                if (string.IsNullOrEmpty(formulaNumber) || formulaNumber.Length <= 3) // Formula numbers start with "F00", does not include version!
                    return null;

                string uri = string.Format(ROUTE_PULL_FORUMLA_FROM_ENGINUITY, Uri.EscapeDataString(formulaNumber));
                Logger.Trace("PullForumulaFromEnginuityAsync: formulaNumber={0} calling={1}", formulaNumber, uri);
                return await client.DoPostAsync<EnginuityFormula>(uri, null);
            }

            /// <summary>
            /// Pulls formula from enginuity and persists to Depot (DOES NOT send to PASS)
            /// </summary>
            /// <param name="formulaNumber"></param>
            /// <returns></returns>
            public EnginuityFormula PullForumulaFromEnginuity(string formulaNumber)
            {
                if (string.IsNullOrEmpty(formulaNumber) || formulaNumber.Length <= 3) // Formula numbers start with "F00", does not include version!
                    return null;

                string uri = string.Format(ROUTE_PULL_FORUMLA_FROM_ENGINUITY, Uri.EscapeDataString(formulaNumber));
                Logger.Trace("PullForumulaFromEnginuity: formulaNumber={0} calling={1}", formulaNumber, uri);
                return client.DoPost<EnginuityFormula>(uri, null);
            }

            /// <summary>
            /// Method: GET
            /// </summary>
            public static string ROUTE_PULL_ENGINUITY_FORUMLA_TO_PASS => "api/v1/pass/pull-enginuity-formula?formulaNumber={0}";
            /// <summary>
            /// Pulls formula from enginuity, persists to Depot, sends to PASS
            /// </summary>
            /// <param name="formulaNumber"></param>
            /// <returns></returns>
            public async Task<EnginuityFormula> PullEnginuityForumulaToPassAsync(string formulaNumber)
            {
                if (string.IsNullOrEmpty(formulaNumber) || formulaNumber.Length <= 3) // Formula numbers start with "F00", does not include version!
                    return null;

                string uriPart = string.Format(ROUTE_PULL_ENGINUITY_FORUMLA_TO_PASS, new object[] { Uri.EscapeDataString(formulaNumber) });
                Logger.Trace("PullEnginuityForumulaToPassAsync: formulaNumber={0} calling={1}", formulaNumber, uriPart);
                return await client.DoGetAsync<EnginuityFormula>(uriPart);
            }

            /// <summary>
            /// Pulls formula from enginuity, persists to Depot, sends to PASS
            /// </summary>
            /// <param name="formulaNumber"></param>
            /// <returns></returns>
            public EnginuityFormula PullEnginuityForumulaToPass(string formulaNumber)
            {
                if (string.IsNullOrEmpty(formulaNumber) || formulaNumber.Length <= 3) // Formula numbers start with "F00", does not include version!
                    return null;

                var uriPart = string.Format(ROUTE_PULL_ENGINUITY_FORUMLA_TO_PASS, new object[] { Uri.EscapeDataString(formulaNumber) });
                Logger.Trace("PullForumulaFromEnginuity: formulaNumber={0} calling={1}", formulaNumber, uriPart);
                return client.DoGet<EnginuityFormula>(uriPart);
            }

        }

        public class SmartRegion : ClientRegion
        {
            internal SmartRegion(DepotClient client) : base(client) { }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ReceiveCompletedSmartRequestUrl => "api/v1/pass/receive-completed-smart-request?partnumber={0}&rqnumber={1}";
            /// <summary>
            /// Allows Depot to receive a completed RQ# and attach it to a part number.
            /// </summary>
            /// <param name="partnumber"></param>
            /// <param name="rqnumber"></param>
            /// <returns></returns>
            public async Task<DepotPart> ReceiveCompletedSmartRequestAsync(string partnumber, string rqnumber)
            {
                var uri = string.Format(ReceiveCompletedSmartRequestUrl, Uri.EscapeDataString(partnumber), Uri.EscapeDataString(rqnumber));
                Logger.Trace($"ReceiveCompletedSmartRequestAsync: partnumber={partnumber} rqnumber={rqnumber} ");
                var response = await client.DoPostAsync<DepotPart>(uri, null);
                return response;
            }

            /// <summary>
            /// Allows Depot to receive a completed RQ# and attach it to a part number.
            /// </summary>
            /// <param name="partnumber"></param>
            /// <param name="rqnumber"></param>
            /// <returns></returns>
            public DepotPart ReceiveCompletedSmartRequest(string partnumber, string rqnumber)
            {
                var uri = string.Format(ReceiveCompletedSmartRequestUrl, Uri.EscapeDataString(partnumber), Uri.EscapeDataString(rqnumber));
                Logger.Trace($"ReceiveCompletedSmartRequest: partnumber={partnumber} rqnumber={rqnumber} ");
                var response = client.DoPost<DepotPart>(uri, null);
                return response;
            }


            public static string RoutePullPartForAssessment => "api/v1/plm/pull-part-for-assessment?srcKey={0}&srcRevision={1}";
            public static string RoutePullPartForAssessmentExt => "api/v1/plm/pull-part-for-assessment?srcKey={0}&srcRevision={1}&onBehalfOfUser={2}";

            /// <summary>
            /// Allows Depot to receive a completed RQ# and attach it to a part number.
            /// </summary>
            /// <param name="srcKey"></param>
            /// <param name="srcRevision"></param>
            /// <returns></returns>
            public async Task<DepotPartWithMessage> PullPartForAssessmentAsync(string srcKey, string srcRevision)
            {
                var uri = string.Format(RoutePullPartForAssessment, Uri.EscapeDataString(srcKey), Uri.EscapeDataString(srcRevision));
                Logger.Trace($"PullPartForAssessmentAsync: partnumber={srcKey} rqnumber={srcRevision} ");
                var response = await client.DoPostAsync<DepotPartWithMessage>(uri, null);
                return response;
            }
            /// <summary>
            /// Allows Depot to receive a completed RQ# and attach it to a part number.
            /// </summary>
            /// <param name="srcKey"></param>
            /// <param name="srcRevision"></param>
            /// <param name="onBehalfOfUser"></param>
            /// <returns></returns>
            public async Task<DepotPartWithMessage> PullPartForAssessmentAsync(string srcKey, string srcRevision, string onBehalfOfUser)
            {
                var uri = string.Format(RoutePullPartForAssessmentExt, Uri.EscapeDataString(srcKey), Uri.EscapeDataString(srcRevision), Uri.EscapeDataString(onBehalfOfUser));
                Logger.Trace($"PullPartForAssessmentAsync: partnumber={srcKey} rqnumber={srcRevision} onBehalfOfUser={onBehalfOfUser}");
                var response = await client.DoPostAsync<DepotPartWithMessage>(uri, null);
                return response;
            }

            /// <summary>
            /// Allows Depot to receive a completed RQ# and attach it to a part number.
            /// </summary>
            /// <param name="srcKey"></param>
            /// <param name="srcRevision"></param>
            /// <returns></returns>
            public DepotPartWithMessage PullPartForAssessment(string srcKey, string srcRevision)
            {
                var uri = string.Format(RoutePullPartForAssessment, Uri.EscapeDataString(srcKey), Uri.EscapeDataString(srcRevision));
                Logger.Trace($"PullPartForAssessment: partnumber={srcKey} rqnumber={srcRevision} ");
                var response = client.DoPost<DepotPartWithMessage>(uri, null);
                return response;
            }
            public DepotPartWithMessage PullPartForAssessment(string srcKey, string srcRevision, string onBehalfOfUser)
            {
                var uri = string.Format(RoutePullPartForAssessmentExt, Uri.EscapeDataString(srcKey), Uri.EscapeDataString(srcRevision), Uri.EscapeDataString(onBehalfOfUser));
                Logger.Trace($"PullPartForAssessmentAsync: partnumber={srcKey} rqnumber={srcRevision} onBehalfOfUser={onBehalfOfUser}");
                var response = client.DoPost<DepotPartWithMessage>(uri, null);
                return response;
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string RemoveCancelledSmartRequestUrl => "api/v1/pass/remove-cancelled-smart-request?partnumber={0}&rqnumber={1}";
            /// <summary>
            /// Allows Depot to receive a completed RQ# and attach it to a part number.
            /// </summary>
            /// <param name="partnumber"></param>
            /// <param name="rqnumber"></param>
            /// <returns></returns>
            public async Task<DepotPart> RemoveCancelledSmartRequestAsync(string partnumber, string rqnumber)
            {
                var uri = string.Format(RemoveCancelledSmartRequestUrl, Uri.EscapeDataString(partnumber), Uri.EscapeDataString(rqnumber));
                Logger.Trace($"ReceiveCompletedSmartRequestAsync: partnumber={partnumber} rqnumber={rqnumber} ");
                var response = await client.DoPostAsync<DepotPart>(uri, null);
                return response;
            }

            /// <summary>
            /// Allows Depot to receive a completed RQ# and attach it to a part number.
            /// </summary>
            /// <param name="partnumber"></param>
            /// <param name="rqnumber"></param>
            /// <returns></returns>
            public DepotPart RemoveCancelledSmartRequest(string partnumber, string rqnumber)
            {
                var uri = string.Format(RemoveCancelledSmartRequestUrl, Uri.EscapeDataString(partnumber), Uri.EscapeDataString(rqnumber));
                Logger.Trace($"ReceiveCompletedSmartRequest: partnumber={partnumber} rqnumber={rqnumber} ");
                var response = client.DoPost<DepotPart>(uri, null);
                return response;
            }

        }

        public class SyncRegion : ClientRegion
        {
            internal SyncRegion(DepotClient client) : base(client) { }

            #region SyncMethodsRegion

            /// <summary>
            /// Method: GET
            /// </summary>
            public static string ROUTE_SYNC_LIST_PLM_STATES => "api/v1/sync/list-plm-states";
            /// <summary>
            /// Returns a List&lt;string&gt; of PlmStates
            /// </summary>
            /// <returns></returns>
            public async Task<List<string>> ListPlmStatesAsync()
            {
                Logger.Trace("ListPlmStatesAsync: calling={0}", ROUTE_SYNC_LIST_PLM_STATES);
                return await client.DoGetAsync<List<string>>(ROUTE_SYNC_LIST_PLM_STATES);
            }

            /// <summary>
            /// Returns a List&lt;string&gt; of PlmStates
            /// </summary>
            /// <returns></returns>
            public List<string> ListPlmStates()
            {
                Logger.Trace("ListPlmStates: calling={0}", ROUTE_SYNC_LIST_PLM_STATES);
                return client.DoGet<List<string>>(ROUTE_SYNC_LIST_PLM_STATES);
            }

            /// <summary>
            /// Method: GET
            /// </summary>
            public static string ROUTE_SYNC_LIST_PART_TYPES => "api/v1/sync/list-part-types";
            /// <summary>
            /// Returns a List&lt;string&gt; of PartTypes
            /// </summary>
            /// <returns></returns>
            public async Task<List<string>> ListPartTypesAsync()
            {
                Logger.Trace("ListPartTypesAsync: calling={0}", ROUTE_SYNC_LIST_PART_TYPES);
                return await client.DoGetAsync<List<string>>(ROUTE_SYNC_LIST_PART_TYPES);
            }

            /// <summary>
            /// Returns a List&lt;string&gt; of PartTypes
            /// </summary>
            /// <returns></returns>
            public List<string> ListPartTypes()
            {
                Logger.Trace("ListPartTypes: calling={0}", ROUTE_SYNC_LIST_PART_TYPES);
                return client.DoGet<List<string>>(ROUTE_SYNC_LIST_PART_TYPES);
            }

            /// <summary>
            /// Method: GET
            /// </summary>
            public static string ROUTE_SYNC_LIST_COMP_TYPES => "api/v1/sync/list-comp-types";
            /// <summary>
            /// Returns a List&lt;{string PartType, string Name}&gt; of CompositionTypes
            /// </summary>
            /// <returns></returns>
            public async Task<List<string>> ListCompTypesAsync()
            {
                Logger.Trace("ListCompTypesAsync: calling={0}", ROUTE_SYNC_LIST_COMP_TYPES);
                return await client.DoGetAsync<List<string>>(ROUTE_SYNC_LIST_COMP_TYPES);
            }

            /// <summary>
            /// Returns a List&lt;{string PartType, string Name}&gt; of CompositionTypes
            /// </summary>
            /// <returns></returns>
            public List<string> ListCompTypes()
            {
                Logger.Trace("ListCompTypes: calling={0}", ROUTE_SYNC_LIST_COMP_TYPES);
                return client.DoGet<List<string>>(ROUTE_SYNC_LIST_COMP_TYPES);
            }

            /// <summary>
            /// Method: GET
            /// </summary>
            public static string ROUTE_SYNC_LIST_SYNC_ATTRS => "api/v1/sync/list-sync-attrs";
            /// <summary>
            /// Returns a List&lt;string&gt; of sync attribute names
            /// </summary>
            /// <returns></returns>
            public async Task<List<string>> ListSyncAttributesAsync()
            {
                Logger.Trace("ListSyncAttributesAsync: calling={0}", ROUTE_SYNC_LIST_SYNC_ATTRS);
                return await client.DoGetAsync<List<string>>(ROUTE_SYNC_LIST_SYNC_ATTRS);
            }

            /// <summary>
            /// Returns a List&lt;string&gt; of sync attribute names
            /// </summary>
            /// <returns></returns>
            public List<string> ListSyncAttributes()
            {
                Logger.Trace("ListSyncAttributes: calling={0}", ROUTE_SYNC_LIST_SYNC_ATTRS);
                return client.DoGet<List<string>>(ROUTE_SYNC_LIST_SYNC_ATTRS);
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_SET_PREFERRED_PLM_STATE_ORDER => "api/v1/sync/set-preferred-plm-state-order";
            public async Task SetSyncPreferredPlmStateOrderAsync(string systemKey, IEnumerable<string> plmStates)
            {
                Logger.Trace("SetSyncPreferredPlmStateOrderAsync: calling={0}", ROUTE_SYNC_SET_PREFERRED_PLM_STATE_ORDER);
                await client.DoPostAsync(ROUTE_SYNC_SET_PREFERRED_PLM_STATE_ORDER, new { systemKey, plmStates });
            }

            public void SetSyncPreferredPlmStateOrder(string systemKey, IEnumerable<string> plmStates)
            {
                Logger.Trace("SetSyncPreferredPlmStateOrder: calling={0}", ROUTE_SYNC_SET_PREFERRED_PLM_STATE_ORDER);
                client.DoPost(ROUTE_SYNC_SET_PREFERRED_PLM_STATE_ORDER, new { systemKey, plmStates });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_SET_PART_TYPES => "api/v1/sync/set-part-types";
            public async Task SetPartTypesAsync(string systemKey, IEnumerable<string> partTypes)
            {
                Logger.Trace("SetPartTypesAsync: calling={0}", ROUTE_SYNC_SET_PART_TYPES);
                await client.DoPostAsync(ROUTE_SYNC_SET_PART_TYPES, new { systemKey, partTypes });
            }

            public void SetPartTypes(string systemKey, IEnumerable<string> partTypes)
            {
                Logger.Trace("SetPartTypes: calling={0}", ROUTE_SYNC_SET_PART_TYPES);
                client.DoPost(ROUTE_SYNC_SET_PART_TYPES, new { systemKey, partTypes });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_SET_COMP_TYPES => "api/v1/sync/set-comp-types";
            public async Task SetCompTypesAsync(string systemKey, IEnumerable<StringComparison> compTypes)
            {
                Logger.Trace("SetCompTypesAsync: calling={0}", ROUTE_SYNC_SET_COMP_TYPES);
                await client.DoPostAsync(ROUTE_SYNC_SET_COMP_TYPES, new { systemKey, compTypes });
            }

            public void SetCompTypes(string systemKey, IEnumerable<string> compTypes)
            {
                Logger.Trace("SetCompTypes: calling={0}", ROUTE_SYNC_SET_COMP_TYPES);
                client.DoPost(ROUTE_SYNC_SET_COMP_TYPES, new { systemKey, compTypes });
            }

            /// <summary>
            /// Method: GET
            /// </summary>
            public static string ROUTE_SYNC_GET_SYS_CONFIG => "api/v1/sync/get-sys-config";
            public async Task<SyncSystemConfig> GetSystemConfigAsync(string systemKey)
            {
                string uri = $"{ROUTE_SYNC_GET_SYS_CONFIG}?systemKey={Uri.EscapeDataString(systemKey)}";
                Logger.Trace("GetSystemConfigAsync: calling={0}", uri);
                return await client.DoGetAsync<SyncSystemConfig>(uri);
            }

            public SyncSystemConfig GetSystemConfig(string systemKey)
            {
                var uri = $"{ROUTE_SYNC_GET_SYS_CONFIG}?systemKey={Uri.EscapeDataString(systemKey)}";
                Logger.Trace("GetSystemConfig: calling={0}", uri);
                return client.DoGet<SyncSystemConfig>(uri);
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_ADD_SYNC_PARTS => "api/v1/sync/add-sync-parts";
            public async Task<List<SyncPart>> AddSyncPartsAsync(string systemKey, IEnumerable<SyncPart> syncParts)
            {
                Logger.Trace("AddSyncPartsAsync: calling={0}", ROUTE_SYNC_ADD_SYNC_PARTS);
                return await client.DoPostAsync<List<SyncPart>>(ROUTE_SYNC_ADD_SYNC_PARTS, new { systemKey, syncParts });
            }

            public List<SyncPart> AddSyncParts(string systemKey, IEnumerable<SyncPart> syncParts)
            {
                Logger.Trace("AddSyncParts: calling={0}", ROUTE_SYNC_ADD_SYNC_PARTS);
                return client.DoPost<List<SyncPart>>(ROUTE_SYNC_ADD_SYNC_PARTS, new { systemKey, syncParts });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_REMOVE_SYNC_KEYS => "api/v1/sync/remove-sync-keys";
            public async Task RemoveSyncKeysAsync(string systemKey, IEnumerable<string> syncKeys)
            {
                Logger.Trace("RemoveSyncKeysAsync: calling={0}", ROUTE_SYNC_REMOVE_SYNC_KEYS);
                await client.DoPostAsync(ROUTE_SYNC_REMOVE_SYNC_KEYS, new { systemKey, syncKeys });
            }

            public void RemoveSyncKeys(string systemKey, IEnumerable<string> syncKeys)
            {
                Logger.Trace("RemoveSyncKeys: calling={0}", ROUTE_SYNC_REMOVE_SYNC_KEYS);
                client.DoPost(ROUTE_SYNC_REMOVE_SYNC_KEYS, new { systemKey, syncKeys });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_FIND_SYNC_PARTS_BY_KEYS => "api/v1/sync/find-sync-parts-by-keys";
            public async Task<List<SyncPart>> FindSyncPartsBySyncKeysAsync(string systemKey, IEnumerable<string> syncKeys)
            {
                Logger.Trace("FindSyncPartsBySyncKeysAsync: calling={0}", ROUTE_SYNC_FIND_SYNC_PARTS_BY_KEYS);
                return await client.DoPostAsync<List<SyncPart>>(ROUTE_SYNC_FIND_SYNC_PARTS_BY_KEYS, new { systemKey, syncKeys });
            } // List the sync records for specified keys

            public List<SyncPart> FindSyncPartsBySyncKeys(string systemKey, IEnumerable<string> syncKeys)
            {
                Logger.Trace("FindSyncPartsBySyncKeys: calling={0}", ROUTE_SYNC_FIND_SYNC_PARTS_BY_KEYS);
                return client.DoPost<List<SyncPart>>(ROUTE_SYNC_FIND_SYNC_PARTS_BY_KEYS, new { systemKey, syncKeys });
            } // List the sync records for specified keys

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_ADD_PART_SYNC_ATTRS => "api/v1/sync/add-part-sync-attrs";
            public async Task AddPartSyncAttrsAsync(string systemKey, IEnumerable<string> syncKeys, IEnumerable<string> syncAttrs)
            {
                Logger.Trace("AddPartSyncAttrsAsync: calling={0}", ROUTE_SYNC_ADD_PART_SYNC_ATTRS);
                await client.DoPostAsync(ROUTE_SYNC_ADD_PART_SYNC_ATTRS, new { systemKey, syncKeys, syncAttrs });
            }

            public void AddPartSyncAttrs(string systemKey, IEnumerable<string> syncKeys, IEnumerable<string> syncAttrs)
            {
                Logger.Trace("AddPartSyncAttrs: calling={0}", ROUTE_SYNC_ADD_PART_SYNC_ATTRS);
                client.DoPost(ROUTE_SYNC_ADD_PART_SYNC_ATTRS, new { systemKey, syncKeys, syncAttrs });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_REMOVE_PART_SYNC_ATTRS => "api/v1/sync/remove-part-sync-attrs";
            public async Task RemovePartSyncAttrsAsync(string systemKey, IEnumerable<string> syncKeys, IEnumerable<string> syncAttrs)
            {
                Logger.Trace("RemovePartSyncAttrsAsync: calling={0}", ROUTE_SYNC_REMOVE_PART_SYNC_ATTRS);
                await client.DoPostAsync(ROUTE_SYNC_REMOVE_PART_SYNC_ATTRS, new { systemKey, syncKeys, syncAttrs });
            }

            public void RemovePartSyncAttrs(string systemKey, IEnumerable<string> syncKeys, IEnumerable<string> syncAttrs)
            {
                Logger.Trace("RemovePartSyncAttrs: calling={0}", ROUTE_SYNC_REMOVE_PART_SYNC_ATTRS);
                client.DoPost(ROUTE_SYNC_REMOVE_PART_SYNC_ATTRS, new { systemKey, syncKeys, syncAttrs });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_LIST_SYNC_PARTS_BY_ATTRS => "api/v1/sync/list-sync-parts-by-attrs";
            public async Task<List<SyncPart>> FindSyncPartsBySyncAttrsAsync(string systemKey, IEnumerable<string> syncAttrs, int next, int offset)
            {
                Logger.Trace("FindSyncPartsBySyncAttrsAsync: calling={0}", ROUTE_SYNC_LIST_SYNC_PARTS_BY_ATTRS);
                return await client.DoPostAsync<List<SyncPart>>(ROUTE_SYNC_LIST_SYNC_PARTS_BY_ATTRS, new { systemKey, syncAttrs, next, offset });
            } // List the sync records with all options set

            public List<SyncPart> FindSyncPartsBySyncAttrs(string systemKey, IEnumerable<string> syncAttrs, int next, int offset)
            {
                Logger.Trace("FindSyncPartsBySyncAttrs: calling={0}", ROUTE_SYNC_LIST_SYNC_PARTS_BY_ATTRS);
                return client.DoPost<List<SyncPart>>(ROUTE_SYNC_LIST_SYNC_PARTS_BY_ATTRS, new { systemKey, syncAttrs, next, offset });
            } // List the sync records with all options set

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_POLL_SYNC_PARTS => "api/v1/sync/poll-sync-parts";
            public async Task<List<SyncPart>> PollPartsAsync(string systemKey, DateTime startLastUpdated, DateTime endLastUpdated, int next, int offset)
            {
                Logger.Trace("PollPartsAsync: calling={0}", ROUTE_SYNC_POLL_SYNC_PARTS);
                return await client.DoPostAsync<List<SyncPart>>(ROUTE_SYNC_POLL_SYNC_PARTS, new { systemKey, startLastUpdated, endLastUpdated, next, offset });
            }

            public List<SyncPart> PollParts(string systemKey, DateTime startLastUpdated, DateTime endLastUpdated, int next, int offset)
            {
                Logger.Trace("PollParts: calling={0}", ROUTE_SYNC_POLL_SYNC_PARTS);
                return client.DoPost<List<SyncPart>>(ROUTE_SYNC_POLL_SYNC_PARTS, new { systemKey, startLastUpdated, endLastUpdated, next, offset });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_LOOK_FOR_PART_UPDATES => "api/v1/sync/look-for-part-updates";
            public async Task<List<SyncPart>> LookForPartUpdatesAsync(string systemKey, IEnumerable<string> syncKeys = null)
            {
                Logger.Trace("LookForPartUpdatesAsync: calling={0}", ROUTE_SYNC_LOOK_FOR_PART_UPDATES);
                return await client.DoPostAsync<List<SyncPart>>(ROUTE_SYNC_LOOK_FOR_PART_UPDATES, new { systemKey, syncKeys });
            }

            public List<SyncPart> LookForPartUpdates(string systemKey, IEnumerable<string> syncKeys = null)
            {
                Logger.Trace("LookForPartUpdates: calling={0}", ROUTE_SYNC_LOOK_FOR_PART_UPDATES);
                return client.DoPost<List<SyncPart>>(ROUTE_SYNC_LOOK_FOR_PART_UPDATES, new { systemKey, syncKeys });
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string ROUTE_SYNC_SEARCH_FOR_NEW_PARTS => "api/v1/sync/search-for-new-parts";
            public async Task<List<DepotPart>> SearchForNewPartsAsync(NewPartsSearchFilter filter)
            {
                Logger.Trace("SearchForNewPartsAsync: calling={0}", ROUTE_SYNC_SEARCH_FOR_NEW_PARTS);
                return await client.DoPostAsync<List<DepotPart>>(ROUTE_SYNC_SEARCH_FOR_NEW_PARTS, filter);
            }

            public List<DepotPart> SearchForNewParts(NewPartsSearchFilter filter)
            {
                Logger.Trace("SearchForNewParts: calling={0}", ROUTE_SYNC_SEARCH_FOR_NEW_PARTS);
                return client.DoPost<List<DepotPart>>(ROUTE_SYNC_SEARCH_FOR_NEW_PARTS, filter);
            }
            #endregion
        }

        public class ClearancesRegion : ClientRegion
        {
            internal ClearancesRegion(DepotClient client) : base(client) { }

            #region ClearanceController
            /// <summary>
            /// Method: GET
            /// </summary>
            public static string GetAssesmbledMaterialFunctions_ => "api/v1/clearances/assembled-material-functions";

            public async Task<List<string>> GetAssesmbledMaterialFunctionsAsync(List<string> segments = null)
            {
                var uri = GetAssesmbledMaterialFunctions_;
                if (segments != null && segments.Any())
                {
                    uri += $"?segments={string.Join(";", segments)}";
                }
                Logger.Trace($"GetAssesmbledMaterialFunctionsAsync: {uri}");
                var response = await client.DoGetAsync<List<string>>(uri);
                return response;
            }
            public List<string> GetAssesmbledMaterialFunctions(List<string> segments = null)
            {
                var uri = GetAssesmbledMaterialFunctions_;
                if (segments != null && segments.Any())
                {
                    uri += $"?segments={string.Join(";", segments)}";
                }
                Logger.Trace($"GetAssesmbledMaterialFunctions: {uri}");
                var response = client.DoGet<List<string>>(uri);
                return response;
            }

            /// <summary>
            /// Method: POST
            /// </summary>
            public static string MaterialClearancesSearch_ => "api/v1/clearances/find-part-clearances";

            public async Task<IEnumerable<PartClearance>> FindPartClearances(IEnumerable<FindPartClearancesRequest> searchItems)
            {
                var uri = MaterialClearancesSearch_;
                Logger.Trace($"FindPartClearances: {uri}");
                var response = (await client.DoPostAsync<IEnumerable<PartClearance>>(uri, searchItems)).ToList();
                response = DecodePartClearanceResponse(response);
                return response;
            }
            public IEnumerable<PartClearance> FindPartClearancesNonAsync(IEnumerable<FindPartClearancesRequest> searchItems)
            {
                var uri = MaterialClearancesSearch_;
                Logger.Trace($"FindPartClearancesNonAsync: {uri}");
                var response = (client.DoPost<IEnumerable<PartClearance>>(uri, searchItems)).ToList();
                response = DecodePartClearanceResponse(response);
                return response;
            }

            private List<PartClearance> DecodePartClearanceResponse(List<PartClearance> response)
            {
                foreach (var clearance in response)
                {
                    clearance.AssessedBusinessArea = WebUtility.HtmlDecode(clearance.AssessedBusinessArea);
                    clearance.ClearanceLevel = WebUtility.HtmlDecode(clearance.ClearanceLevel);
                    clearance.Comments = WebUtility.HtmlDecode(clearance.Comments);
                    clearance.MaxClearedAmountUnit = WebUtility.HtmlDecode(clearance.MaxClearedAmountUnit);
                    clearance.PartKey = WebUtility.HtmlDecode(clearance.PartKey);
                    clearance.PartKeyRev = WebUtility.HtmlDecode(clearance.PartKeyRev);
                    clearance.PartMaterialClass = WebUtility.HtmlDecode(clearance.PartMaterialClass);
                    clearance.PartMaterialSubclass = WebUtility.HtmlDecode(clearance.PartMaterialSubclass);
                    clearance.PartName = WebUtility.HtmlDecode(clearance.PartName);
                    clearance.RequestKey = WebUtility.HtmlDecode(clearance.RequestKey);
                    clearance.RsrKey = WebUtility.HtmlDecode(clearance.RsrKey);
                    clearance.SupplierMaterialTradeName = WebUtility.HtmlDecode(clearance.SupplierMaterialTradeName);
                    clearance.SupplierName = WebUtility.HtmlDecode(clearance.SupplierName);
                }

                return response;
            }
            #endregion
        }

        public class PicklistRegion : ClientRegion
        {
            internal PicklistRegion(DepotClient client) : base(client) { }

            public static string ROUTE_PICKLIST_ATTRIBUTES => "api/v1/picklists/attributes";
            public async Task<List<DepotAttributeType>> ListDepotAttributeTypesAsync()
            {
                Logger.Trace("ListDepotAttributeTypes: calling {0}", ROUTE_PICKLIST_ATTRIBUTES);
                return await client.DoGetAsync<List<DepotAttributeType>>(ROUTE_PICKLIST_ATTRIBUTES);
            }
            public List<DepotAttributeType> ListDepotAttributeTypes()
            {
                Logger.Trace("ListDepotAttributeTypes: calling {0}", ROUTE_PICKLIST_ATTRIBUTES);
                return client.DoGet<List<DepotAttributeType>>(ROUTE_PICKLIST_ATTRIBUTES);
            }

            public static string ROUTE_PICKLIST_PART_STATUSES => "api/v1/picklists/part-statuses";
            public async Task<List<DepotPartStatus>> ListDepotPartStatusesAsync()
            {
                Logger.Trace("ListDepotPartStatuss: calling {0}", ROUTE_PICKLIST_PART_STATUSES);
                return await client.DoGetAsync<List<DepotPartStatus>>(ROUTE_PICKLIST_PART_STATUSES);
            }
            [Obsolete("This method is obsolete. Use ListDepotPartStatusesAsync instead.")]
            public async Task<List<DepotPartStatus>> ListDepotPartStatussAsync() => await ListDepotPartStatusesAsync();

            public List<DepotPartStatus> ListDepotPartStatuses()
            {
                Logger.Trace("ListDepotPartStatuss: calling {0}", ROUTE_PICKLIST_PART_STATUSES);
                return client.DoGet<List<DepotPartStatus>>(ROUTE_PICKLIST_PART_STATUSES);
            }
            [Obsolete("This method is obsolete. Use ListDepotPartStatuses instead.")]
            public List<DepotPartStatus> ListDepotPartStatuss() => ListDepotPartStatuses();

            public static string ROUTE_PICKLIST_PLM_STATES => "api/v1/picklists/plm-states";
            public async Task<List<DepotPlmState>> ListDepotPlmStatesAsync()
            {
                Logger.Trace("ListDepotPlmStates: calling {0}", ROUTE_PICKLIST_PLM_STATES);
                return await client.DoGetAsync<List<DepotPlmState>>(ROUTE_PICKLIST_PLM_STATES);
            }
            public List<DepotPlmState> ListDepotPlmStates()
            {
                Logger.Trace("ListDepotPlmStates: calling {0}", ROUTE_PICKLIST_PLM_STATES);
                return client.DoGet<List<DepotPlmState>>(ROUTE_PICKLIST_PLM_STATES);
            }

            public static string ROUTE_PICKLIST_PLM_STAGES => "api/v1/picklists/plm-stages";
            public async Task<List<DepotPlmStage>> ListDepotPlmStagesAsync()
            {
                Logger.Trace("ListDepotPlmStages: calling {0}", ROUTE_PICKLIST_PLM_STAGES);
                return await client.DoGetAsync<List<DepotPlmStage>>(ROUTE_PICKLIST_PLM_STAGES);
            }
            public List<DepotPlmStage> ListDepotPlmStages()
            {
                Logger.Trace("ListDepotPlmStages: calling {0}", ROUTE_PICKLIST_PLM_STAGES);
                return client.DoGet<List<DepotPlmStage>>(ROUTE_PICKLIST_PLM_STAGES);
            }

            public static string ROUTE_PICKLIST_PART_TYPES => "api/v1/picklists/part-types";
            public async Task<List<DepotPartType>> ListDepotPartTypesAsync()
            {
                Logger.Trace("ListDepotPartTypes: calling {0}", ROUTE_PICKLIST_PART_TYPES);
                return await client.DoGetAsync<List<DepotPartType>>(ROUTE_PICKLIST_PART_TYPES);
            }
            public List<DepotPartType> ListDepotPartTypes()
            {
                Logger.Trace("ListDepotPartTypes: calling {0}", ROUTE_PICKLIST_PART_TYPES);
                return client.DoGet<List<DepotPartType>>(ROUTE_PICKLIST_PART_TYPES);
            }

            public static string ROUTE_PICKLIST_PLM_TYPES => "api/v1/picklists/plm-types";
            public async Task<List<DepotPlmType>> ListDepotPlmTypesAsync()
            {
                Logger.Trace("ListDepotPlmTypes: calling {0}", ROUTE_PICKLIST_PLM_TYPES);
                return await client.DoGetAsync<List<DepotPlmType>>(ROUTE_PICKLIST_PLM_TYPES);
            }
            public List<DepotPlmType> ListDepotPlmTypes()
            {
                Logger.Trace("ListDepotPlmTypes: calling {0}", ROUTE_PICKLIST_PLM_TYPES);
                return client.DoGet<List<DepotPlmType>>(ROUTE_PICKLIST_PLM_TYPES);
            }

            public static string ROUTE_PICKLIST_PLM_POLICIES => "api/v1/picklists/plm-policies";
            public async Task<List<DepotPlmPolicy>> ListDepotPlmPolicysAsync()
            {
                Logger.Trace("ListDepotPlmPolicys: calling {0}", ROUTE_PICKLIST_PLM_POLICIES);
                return await client.DoGetAsync<List<DepotPlmPolicy>>(ROUTE_PICKLIST_PLM_POLICIES);
            }
            public List<DepotPlmPolicy> ListDepotPlmPolicys()
            {
                Logger.Trace("ListDepotPlmPolicys: calling {0}", ROUTE_PICKLIST_PLM_POLICIES);
                return client.DoGet<List<DepotPlmPolicy>>(ROUTE_PICKLIST_PLM_POLICIES);
            }

            public static string ROUTE_PICKLIST_BUSINESS_AREAS => "api/v1/picklists/business-areas";
            public async Task<List<DepotBusinessArea>> ListBusniessAreasAsync()
            {
                Logger.Trace("ListBusniessAreasAsync: calling {0}", ROUTE_PICKLIST_BUSINESS_AREAS);
                return await client.DoGetAsync<List<DepotBusinessArea>>(ROUTE_PICKLIST_BUSINESS_AREAS);
            }
            public List<DepotBusinessArea> ListBusniessAreas()
            {
                Logger.Trace("ListBusniessAreas: calling {0}", ROUTE_PICKLIST_BUSINESS_AREAS);
                return client.DoGet<List<DepotBusinessArea>>(ROUTE_PICKLIST_BUSINESS_AREAS);
            }

            public static string ROUTE_PICKLIST_PRODUCT_CATEGORY_PLATFORMS => "api/v1/picklists/product-category-platforms";
            public async Task<List<DepotProductCategoryPlatform>> ListProductCategoryPlatformsAsync()
            {
                Logger.Trace("ListProductCategoryPlatformsAsync: calling {0}", ROUTE_PICKLIST_PRODUCT_CATEGORY_PLATFORMS);
                return await client.DoGetAsync<List<DepotProductCategoryPlatform>>(ROUTE_PICKLIST_PRODUCT_CATEGORY_PLATFORMS);
            }
            public List<DepotProductCategoryPlatform> ListProductCategoryPlatforms()
            {
                Logger.Trace("ListProductCategoryPlatforms: calling {0}", ROUTE_PICKLIST_PRODUCT_CATEGORY_PLATFORMS);
                return client.DoGet<List<DepotProductCategoryPlatform>>(ROUTE_PICKLIST_PRODUCT_CATEGORY_PLATFORMS);
            }

            public static string ROUTE_PICKLIST_PRODUCT_TECHNOLOGY_PLATFORMS => "api/v1/picklists/product-technology-platforms";
            public async Task<List<DepotProductTechnologyPlatform>> ListProductTechnologyPlatformsAsync()
            {
                Logger.Trace("ListProductTechnologyPlatformsAsync: calling {0}", ROUTE_PICKLIST_PRODUCT_TECHNOLOGY_PLATFORMS);
                return await client.DoGetAsync<List<DepotProductTechnologyPlatform>>(ROUTE_PICKLIST_PRODUCT_TECHNOLOGY_PLATFORMS);
            }
            public List<DepotProductTechnologyPlatform> ListProductTechnologyPlatforms()
            {
                Logger.Trace("ListProductTechnologyPlatforms: calling {0}", ROUTE_PICKLIST_PRODUCT_TECHNOLOGY_PLATFORMS);
                return client.DoGet<List<DepotProductTechnologyPlatform>>(ROUTE_PICKLIST_PRODUCT_TECHNOLOGY_PLATFORMS);
            }

            public static string ROUTE_PICKLIST_PLM_FORMULATION_TYPES => "api/v1/picklists/plm-formulation-types";
            public async Task<List<DepotPlmFormulationType>> ListDepotPlmFormulationTypesAsync()
            {
                Logger.Trace("ListDepotPlmFormulationTypes: calling {0}", ROUTE_PICKLIST_PLM_FORMULATION_TYPES);
                return await client.DoGetAsync<List<DepotPlmFormulationType>>(ROUTE_PICKLIST_PLM_FORMULATION_TYPES);
            }
            public List<DepotPlmFormulationType> ListDepotPlmFormulationTypes()
            {
                Logger.Trace("ListDepotPlmFormulationTypes: calling {0}", ROUTE_PICKLIST_PLM_FORMULATION_TYPES);
                return client.DoGet<List<DepotPlmFormulationType>>(ROUTE_PICKLIST_PLM_FORMULATION_TYPES);
            }

            public static string ROUTE_PICKLIST_ORGANIZATIONS => "api/v1/picklists/organizations";
            public async Task<List<DepotOrganization>> ListDepotOrganizationsAsync()
            {
                Logger.Trace("ListDepotOrganizations: calling {0}", ROUTE_PICKLIST_ORGANIZATIONS);
                return await client.DoGetAsync<List<DepotOrganization>>(ROUTE_PICKLIST_ORGANIZATIONS);
            }
            public List<DepotOrganization> ListDepotOrganizations()
            {
                Logger.Trace("ListDepotOrganizations: calling {0}", ROUTE_PICKLIST_ORGANIZATIONS);
                return client.DoGet<List<DepotOrganization>>(ROUTE_PICKLIST_ORGANIZATIONS);
            }

            public static string ROUTE_PICKLIST_SEGMENTS => "api/v1/picklists/segments";
            public async Task<List<DepotSegment>> ListDepotSegmentsAsync()
            {
                Logger.Trace("ListDepotSegments: calling {0}", ROUTE_PICKLIST_SEGMENTS);
                return await client.DoGetAsync<List<DepotSegment>>(ROUTE_PICKLIST_SEGMENTS);
            }
            public List<DepotSegment> ListDepotSegments()
            {
                Logger.Trace("ListDepotSegments: calling {0}", ROUTE_PICKLIST_SEGMENTS);
                return client.DoGet<List<DepotSegment>>(ROUTE_PICKLIST_SEGMENTS);
            }

            public static string ROUTE_PICKLIST_DIRECT_COMPOSITION_TYPES => "api/v1/picklists/direct-composition-types";
            public async Task<List<DepotCompositionType>> ListDepotCompositionTypesAsync()
            {
                Logger.Trace("ListDepotCompositionTypes: calling {0}", ROUTE_PICKLIST_DIRECT_COMPOSITION_TYPES);
                return await client.DoGetAsync<List<DepotCompositionType>>(ROUTE_PICKLIST_DIRECT_COMPOSITION_TYPES);
            }
            public List<DepotCompositionType> ListDepotCompositionTypes()
            {
                Logger.Trace("ListDepotCompositionTypes: calling {0}", ROUTE_PICKLIST_DIRECT_COMPOSITION_TYPES);
                return client.DoGet<List<DepotCompositionType>>(ROUTE_PICKLIST_DIRECT_COMPOSITION_TYPES);
            }

            public static string ROUTE_PICKLIST_DEEP_COMPOSITION_TYPES => "api/v1/picklists/deep-composition-types";
            public async Task<List<DepotCompositionType>> ListDeepDepotCompositionTypesAsync()
            {
                Logger.Trace("ListDepotCompositionTypes: calling {0}", ROUTE_PICKLIST_DEEP_COMPOSITION_TYPES);
                return await client.DoGetAsync<List<DepotCompositionType>>(ROUTE_PICKLIST_DEEP_COMPOSITION_TYPES);
            }
            public List<DepotCompositionType> ListDeepDepotCompositionTypes()
            {
                Logger.Trace("ListDepotCompositionTypes: calling {0}", ROUTE_PICKLIST_DEEP_COMPOSITION_TYPES);
                return client.DoGet<List<DepotCompositionType>>(ROUTE_PICKLIST_DEEP_COMPOSITION_TYPES);
            }

            public static string ROUTE_PICKLIST_PACKAGING_MATERIAL_TYPE => "api/v1/picklists/packaging-material-type";
            public async Task<List<DepotPackagingMaterialType>> ListDepotPackagingMaterialTypesAsync()
            {
                Logger.Trace("ListDepotPackagingMaterialTypes: calling {0}", ROUTE_PICKLIST_PACKAGING_MATERIAL_TYPE);
                return await client.DoGetAsync<List<DepotPackagingMaterialType>>(ROUTE_PICKLIST_PACKAGING_MATERIAL_TYPE);
            }
            public List<DepotPackagingMaterialType> ListDepotPackagingMaterialTypes()
            {
                Logger.Trace("ListDepotPackagingMaterialTypes: calling {0}", ROUTE_PICKLIST_PACKAGING_MATERIAL_TYPE);
                return client.DoGet<List<DepotPackagingMaterialType>>(ROUTE_PICKLIST_PACKAGING_MATERIAL_TYPE);
            }

        }

        public virtual void Dispose()
        {
            if (_client.IsValueCreated)
                _client.Value.Dispose();

            if (_stdClient.IsValueCreated)
                _stdClient.Value.Dispose();
        }

        #region PrivateMethodsRegion

        #region Async Calls
        public async Task<T> DoGetAsync<T>(string webMethodUrlPart, CancellationToken? cancellationToken = null)
        {
            try
            {
                var response = await Client.GetAsync(webMethodUrlPart, cancellationToken ?? CancellationToken.None);
                return await HandleResponseAsync<T>(response);
            }
            catch (Exception e)
            {
                var serverMessage = GetInternalServerError(e);
                if (string.IsNullOrEmpty(serverMessage))
                {
                    Logger.Error($"DoGetAsync<{typeof(T)}>[{Client.BaseAddress}{webMethodUrlPart}]: An error occured: {e.Message}\n{e}");
                    throw;
                }

                serverMessage = $"Server returned internal error: {serverMessage}";
                Logger.Error($"DoGetAsync<{typeof(T)}>[{Client.BaseAddress}{webMethodUrlPart}]: {serverMessage}\n{e}");
                throw new Exception(serverMessage, e);
            }
        }
        public async Task DoGetAsync(string webMethodUrlPart, CancellationToken? cancellationToken = null)
        {
            try
            {
                var response = await Client.GetAsync(webMethodUrlPart, cancellationToken ?? CancellationToken.None);
                ValidateResponse(response);
            }
            catch (Exception e)
            {
                var serverMessage = GetInternalServerError(e);
                if (string.IsNullOrEmpty(serverMessage))
                {
                    Logger.Error($"DoGetAsync[{Client.BaseAddress}{webMethodUrlPart}]: An error occured: {e.Message}\n{e}");
                    throw;
                }

                serverMessage = $"Server returned internal error: {serverMessage}";
                Logger.Error($"DoGetAsync[{Client.BaseAddress}{webMethodUrlPart}]: {serverMessage}\n{e}");
                throw new Exception(serverMessage, e);
            }
        }
        public async Task<T> DoPostAsync<T>(string webMethodUrlPart, object requestObject = null, CancellationToken? cancellationToken = null)
        {
            string jsonRequest = null;
            try
            {
                HttpContent content = null;
                if (requestObject != null)
                {
                    jsonRequest = JsonConvert.SerializeObject(requestObject, JsonSettings);
                    Logger.Trace("DoPostAsync: url={0} data={1}", webMethodUrlPart, PrepareDebugString(jsonRequest, Logger.IsTraceEnabled, false));
                    content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                }
                var response = await Client.PostAsync(webMethodUrlPart, content, cancellationToken ?? CancellationToken.None);
                return await HandleResponseAsync<T>(response);
            }
            catch (Exception e)
            {
                var serverMessage = GetInternalServerError(e);
                var data = jsonRequest ?? PrepareDebugString(requestObject, Logger.IsTraceEnabled, false);
                if (string.IsNullOrEmpty(serverMessage))
                {
                    Logger.Error($"DoPostAsync<{typeof(T)}>[{Client.BaseAddress}{webMethodUrlPart}]: An error occured: {e.Message}\nData:\t{data}\n{e}");
                    throw;
                }

                serverMessage = $"Server returned internal error: {serverMessage}";
                Logger.Error($"DoPostAsync<{typeof(T)}>[{Client.BaseAddress}{webMethodUrlPart}]: {serverMessage}\nData:\t{data}\n{e}");
                throw new Exception(serverMessage, e);
            }
        }

        public async Task DoPostAsync(string webMethodUrlPart, object requestObject, CancellationToken? cancellationToken = null)
        {
            string jsonRequest = null;
            try
            {
                HttpContent content = null;
                if (requestObject != null)
                {
                    jsonRequest = JsonConvert.SerializeObject(requestObject, JsonSettings);
                    Logger.Trace("DoPostAsync: url={0} data={1}", webMethodUrlPart, PrepareDebugString(jsonRequest, Logger.IsTraceEnabled, false));
                    content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                }
                var response = await Client.PostAsync(webMethodUrlPart, content, cancellationToken ?? CancellationToken.None);
                Logger.Trace("HandleResponse StatusCode: {0} {1}", (int)response.StatusCode, response.StatusCode);
                ResponseValidator.Invoke(response);
            }
            catch (Exception e)
            {
                var serverMessage = GetInternalServerError(e);
                var data = jsonRequest ?? PrepareDebugString(requestObject, Logger.IsTraceEnabled, false);
                if (string.IsNullOrEmpty(serverMessage))
                {
                    Logger.Error($"DoPostAsync[{Client.BaseAddress}{webMethodUrlPart}]: An error occured: {e.Message}\nData:\t{data}\n{e}");
                    throw;
                }

                serverMessage = $"Server returned internal error: {serverMessage}";
                Logger.Error($"DoPostAsync[{Client.BaseAddress}{webMethodUrlPart}]: {serverMessage}\nData:\t{data}\n{e}");
                throw new Exception(serverMessage, e);
            }
        }

        private async Task<FileInfo> DoGetReadAsFileAsync(string webMethodUrlPart, string destPath = null, string destName = null, CancellationToken? cancellationToken = null)
        {
            var response = await Client.GetAsync(webMethodUrlPart, cancellationToken ?? CancellationToken.None);

            Logger.Trace("DoGetReadAsFileAsync Status: {0} {1}", (int)response.StatusCode, response.StatusCode);
            if (!ResponseValidator.Invoke(response))
                return null;

            destPath = destPath ?? Path.GetTempPath();
            destName = destName ?? GetFileNameFromContentDispositionHeader(response) ?? Path.GetRandomFileName();
            var fileInfo = new FileInfo(Path.Combine(destPath, destName));
            Logger.Trace("DoGetReadAsFileAsync Writing to: {0}", fileInfo.FullName);
            await response.Content.CopyToAsync(fileInfo.OpenWrite());
            return fileInfo;
        }

        private string GetFileNameFromContentDispositionHeader(HttpResponseMessage response)
        {
            if (response == null)
                return null;

            var header = response.Headers.GetValues("Content-Disposition")?.FirstOrDefault();
            if (string.IsNullOrEmpty(header))
                return null;

            return new System.Net.Mime.ContentDisposition(header).FileName;
        }

        private async Task<T> HandleResponseAsync<T>(HttpResponseMessage response)
        {
            if (!ValidateResponse(response))
                return default(T);

            var result = await response.Content.ReadAsStringAsync();
            Logger.Trace("HandleResponseAsync<{0}>: returned={1}", new object[] { typeof(T).Name, result });
            if (typeof(T) != typeof(string) && (result?.StartsWith("\"") ?? false) && result.EndsWith("\""))
            {
                // sometimes Depot re-serializes the whole value as a string :/
                Logger.Trace("HandleResponseAsync<{0}>: attempting to escape json string", new object[] { typeof(T).Name });
                result = JsonConvert.DeserializeObject<string>(result, JsonSettings);
            }
            var ret = await Task<T>.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(result, JsonSettings));
            Logger.Trace("HandleResponseAsync[DeserializeObject]: type={0}", (ret == null ? S_NULL : ret.GetType().FullName));
            return ret;
        }

        private bool ValidateResponse(HttpResponseMessage response)
        {
            Logger.Trace("HandleResponseAsync StatusCode: {0} {1}", (int)response.StatusCode, response.StatusCode);
            return ResponseValidator.Invoke(response);
        }

        #endregion
        private static string PrepareDebugString(object val, bool isEnabled = true, bool isWrapWithQuotes = true)
        {
            if (!isEnabled)
                return string.Empty;

            if (val != null)
                return isWrapWithQuotes ? string.Concat(new[] { S_QUOTE, val, S_QUOTE }) : val.ToString();

            return S_NULL;
        }

        #region Synchronous Calls
        public T DoGet<T>(string webMethodUrlPart)
        {
            var response = DoGet(webMethodUrlPart);
            try
            {
                var ret = JsonConvert.DeserializeObject<T>(response, JsonSettings);
                Logger.Trace("DoGet[DeserializeObject]: type={0}", (ret?.GetType().FullName ?? S_NULL));
                return ret;
            }
            catch (Exception e)
            {
                Logger.Error($"DoGet<{typeof(T)}>[{NonAsyncClient.BaseAddress}{webMethodUrlPart}]: An error occured: {e.Message}\n{e}");
                throw;
            }
        }

        public string DoGet(string webMethodUrlPart)
        {
            try
            {
                NonAsyncClient.Headers.Remove(HttpRequestHeader.ContentEncoding);
                NonAsyncClient.Headers.Remove(HttpRequestHeader.ContentType);
                NonAsyncClient.Headers.Set(HttpRequestHeader.Accept, CONTENT_TYPE_JSON);
                var response = NonAsyncClient.DownloadString(webMethodUrlPart);
                Logger.Trace("DoGet: returned={0}", new object[] { response });
                return response;
            }
            catch (Exception e)
            {
                var serverMessage = GetInternalServerError(e);
                if (string.IsNullOrEmpty(serverMessage))
                {
                    Logger.Error($"DoGet[{NonAsyncClient.BaseAddress}{webMethodUrlPart}]: An error occured: {e.Message}\n{e}");
                    throw;
                }

                serverMessage = $"Server returned internal error: {serverMessage}";
                Logger.Error($"DoGet[{NonAsyncClient.BaseAddress}{webMethodUrlPart}]: {serverMessage}\n{e}");
                throw new Exception(serverMessage, e);
            }
        }

        public void DoPost(string webMethodUrlPart, object requestObject)
        {
            string jsonRequest = null;
            try
            {
                jsonRequest = JsonConvert.SerializeObject(requestObject, JsonSettings);
                Logger.Trace("DoPost: url={0} data={1}", webMethodUrlPart, PrepareDebugString(jsonRequest, Logger.IsTraceEnabled, false));
                var uri = new Uri($"{NonAsyncClient.BaseAddress}{webMethodUrlPart}");

                // prep headers
                NonAsyncClient.Headers.Set(HttpRequestHeader.ContentEncoding, Encoding.UTF8.WebName);
                NonAsyncClient.Headers.Set(HttpRequestHeader.ContentType, CONTENT_TYPE_JSON);
                NonAsyncClient.Headers.Remove(HttpRequestHeader.Accept);

                NonAsyncClient.UploadData(uri, Encoding.UTF8.GetBytes(jsonRequest));
                // NonAsyncClient.UploadString(uri, jsonRequest);
            }
            catch (Exception e)
            {
                var serverMessage = GetInternalServerError(e);
                var data = jsonRequest ?? PrepareDebugString(requestObject, Logger.IsTraceEnabled, false);
                if (string.IsNullOrEmpty(serverMessage))
                {
                    Logger.Error($"DoPost[{NonAsyncClient.BaseAddress}{webMethodUrlPart}]: An error occured: {e.Message}\nData:\t{data}\n{e}");
                    throw;
                }

                serverMessage = $"Server returned internal error: {serverMessage}";
                Logger.Error($"DoPost[{NonAsyncClient.BaseAddress}{webMethodUrlPart}]: {serverMessage}\nData:\t{data}\n{e}");
                throw new Exception(serverMessage, e);
            }
        }
        public T DoPost<T>(string webMethodUrlPart, object requestObject)
        {
            string jsonRequest = null;
            try
            {
                jsonRequest = JsonConvert.SerializeObject(requestObject, JsonSettings);
                Logger.Trace("DoPost: url={0} data={1}", webMethodUrlPart, PrepareDebugString(jsonRequest, Logger.IsTraceEnabled, false));
                NonAsyncClient.Headers.Add(HttpRequestHeader.Accept, "application/json");
                var uri = new Uri($"{NonAsyncClient.BaseAddress}{webMethodUrlPart}");
                // var response = NonAsyncClient.UploadString(uri, jsonRequest);

                // prep headers
                NonAsyncClient.Headers.Set(HttpRequestHeader.ContentEncoding, Encoding.UTF8.WebName);
                NonAsyncClient.Headers.Set(HttpRequestHeader.ContentType, CONTENT_TYPE_JSON);
                NonAsyncClient.Headers.Set(HttpRequestHeader.Accept, CONTENT_TYPE_JSON);

                var response = Encoding.UTF8.GetString(NonAsyncClient.UploadData(uri, Encoding.UTF8.GetBytes(jsonRequest)));
                Logger.Trace("DoPost: returned: {0}", response);
                var ret = JsonConvert.DeserializeObject<T>(response, JsonSettings);
                Logger.Trace("DoPost[DeserializeObject]: type={0}", (ret == null ? S_NULL : ret.GetType().FullName));
                return ret;
            }
            catch (Exception e)
            {
                var serverMessage = GetInternalServerError(e);
                var data = jsonRequest ?? PrepareDebugString(requestObject, Logger.IsTraceEnabled, false);
                if (string.IsNullOrEmpty(serverMessage))
                {
                    Logger.Error($"DoPost<{typeof(T)}>[{NonAsyncClient.BaseAddress}{webMethodUrlPart}]: An error occured: {e.Message}\nData:\t{data}\n{e}");
                    throw;
                }
                else
                {
                    serverMessage = $"Server returned internal error: {serverMessage}";
                    Logger.Error($"DoPost<{typeof(T)}>[{NonAsyncClient.BaseAddress}{webMethodUrlPart}]: {serverMessage}\nData:\t{data}\n{e}");
                    throw new Exception(serverMessage, e);
                }
            }
        }
        #endregion
        #endregion

        private static string GetInternalServerError(Exception e)
        {
            if (e is WebException we
                    && we.Response is HttpWebResponse hwr
                    && hwr.StatusCode == HttpStatusCode.InternalServerError)
            {
                try
                {
                    using (var stream = hwr.GetResponseStream())
                        if (stream != null)
                            return new StreamReader(stream).ReadToEnd();
                }
                catch (Exception) { /* SWALLOW */ }
            }
            return null;
        }

        public abstract class ClientRegion
        {
            internal DepotClient client { get; }
            internal ClientRegion(DepotClient client)
            {
                this.client = client;
            }
        }

        private class MyWebClient : WebClient
        {
            public TimeSpan Timeout { get; set; } = DEFAULT_TIMEOUT;
            protected override WebRequest GetWebRequest(Uri uri)
            {
                WebRequest w = base.GetWebRequest(uri);
                if (w != null)
                    w.Timeout = (int)Timeout.TotalMilliseconds;
                return w;
            }
        }

        /*
		/// <summary>
		/// ONLY FOR TESTING!
		/// </summary>
		/// <param name="args"></param>
		static void Main(string[] args) {
			
			var lookupKeys = new[] { "90880507", "91109889", "91364906", "91460925", "91680747", "91698799", "91700363", "91826086", "91826087", "91884684", "92303903", "92312521", "92343064", "95242880", "96860246", "98851450", "99321176" };
			// lookupKeys = new[] { "99321176", "91700363", "90880507", "91109889", "91364906", "91460925", "91680747" };
			lookupKeys = new[] { "90880507" };
			
			try {
				Dictionary<string, DepotPart> results;
				using(var depot = new DepotClient("http://gps-apps-dev.pg.com/depot/", "gpsexess.im", "E046F1A55d3B42AD9F8BEC61CEE8317E", new TimeSpan(0, 30, 0))) {
					results = (depot.ObsoleteParts.FindBestPartsByKeys(lookupKeys) ?? new List<DepotPart>(0))
							  .ToDictionary(p => p.PartSrcKey, p => p, StringComparer.OrdinalIgnoreCase);

					foreach(string key in lookupKeys) {
						if(!results.ContainsKey(key)) {
							Console.WriteLine($"No ObsoleteParts for {key}");
							continue;
						}
						var part = results[key];
						Console.WriteLine($"Part[{key}]: Key={part.PartKey} Type={part.PartTypeCode} Name={part.PartName}");

						Console.WriteLine($"Fetching composition for {part.PartKey}");
						var comp = depot.Compositions.LookupCompositionForPartKey(part.PartKey, new[] { COMP_TYPE_NAME_BOM }, 99)
													 ?.OrderBy(x=>x.Path).ToList() ?? new List<DepotCompositionPart>(0);
						Console.WriteLine($"Found {comp.Count} comps for {part.PartKey}");

						//foreach(var c in comp)
						//	Console.WriteLine($"\t{c.PartKey}[{c.PartTypeCode}]:(L/T/H/U) Level={c.Level} Src=({c.SrcLow}/{c.SrcTarget}/{c.SrcHigh}/{c.SrcUom}) Adj=({c.AdjLow}/{c.AdjTarget}/{c.AdjHigh}/%) Path={c.Path}");

						// CompositionsRegion.NormalizeComponents(part, comp);
						PrintComp(part.PartKey, comp);
						Console.WriteLine($"Squashing BOM for {part.PartKey}");
						
						CompositionsRegion.SquashBomIngredients(part.PartTypeCode, comp);
						CompositionsRegion.NormalizeComponents(part, comp);
						if(comp.Count<1)
						{
							Console.WriteLine($"No compositions after normalization");
							continue;
						}
						
						PrintComp(part.PartKey, comp);
					}
				}

			} catch (Exception e)
			{
				Console.WriteLine($"Error: {e.Message}");
				Console.WriteLine(e.ToString());
			} finally
			{
				Console.WriteLine();
				Console.WriteLine("Press any key to exit");
				Console.ReadKey();
			}
		}
		
		private static void PrintComp(string partKey, IEnumerable<DepotCompositionPart> comp)
		{
			var compList = comp?.ToList() ?? new List<DepotCompositionPart>(0);
			Console.WriteLine($"Print comp for {partKey} ({compList.Count})");
			DepotCompositionPart t = new DepotCompositionPart();
			foreach(var c in compList) {
				Console.WriteLine($"\t{c.PartKey}[{c.PartTypeCode}]:(L/T/H/U) Level={c.Level} Src=({c.SrcLow}/{c.SrcTarget}/{c.SrcHigh}/{c.SrcUom}) Adj=({c.AdjLow}/{c.AdjTarget}/{c.AdjHigh}/%) Path={c.Path}");
				if(c.Level>1)
					continue;
				
				t.SrcUom = t.SrcUom ?? c.SrcUom;
				t.SrcLow = !c.SrcLow.HasValue ? t.SrcLow : (!t.SrcLow.HasValue ? c.SrcLow : c.SrcLow + t.SrcLow);
				t.SrcTarget = !c.SrcTarget.HasValue ? t.SrcTarget : (!t.SrcTarget.HasValue ? c.SrcTarget : c.SrcTarget + t.SrcTarget);
				t.SrcHigh = !c.SrcHigh.HasValue ? t.SrcHigh : (!t.SrcHigh.HasValue ? c.SrcHigh : c.SrcHigh + t.SrcHigh);
				t.AdjLow = !c.AdjLow.HasValue ? t.AdjLow : (!t.AdjLow.HasValue ? c.AdjLow : c.AdjLow + t.AdjLow);
				t.AdjTarget = !c.AdjTarget.HasValue ? t.AdjTarget : (!t.AdjTarget.HasValue ? c.AdjTarget : c.AdjTarget + t.AdjTarget);
				t.AdjHigh = !c.AdjHigh.HasValue ? t.AdjHigh : (!t.AdjHigh.HasValue ? c.AdjHigh : c.AdjHigh + t.AdjHigh);
			}
			Console.WriteLine($"Totals[{partKey}](L/T/H/U): Src=({t.SrcLow}/{t.SrcTarget}/{t.SrcHigh}/{t.SrcUom}) Adj=({t.AdjLow}/{t.AdjTarget}/{t.AdjHigh}/%)");

		}
		 */


        private static string PATH_JSON_SPEC => "swagger/v1/swagger.json";
        public T GenerateBaseClient<T>(Func<string, T> worker, bool isLogSwaggerJson = false)
        {
            try
            {
                var jsonSpec = DoGet(PATH_JSON_SPEC);
                if (isLogSwaggerJson)
                    Logger.Debug("JSON spec:\n" + jsonSpec);
                var document = WaitFor(
                                       OpenApiDocument.FromJsonAsync(jsonSpec)
                                       );

                var settings = new CSharpClientGeneratorSettings
                {
                    ClassName = "GpsDepotClient",
                    CSharpGeneratorSettings =
                                                                     {
                                                                         Namespace = "PG.Gps.DepotClient"
                                                                     },
                    GenerateSyncMethods = true
                };

                var generator = new CSharpClientGenerator(document, settings);
                return worker.Invoke(generator.GenerateFile());
            }
            catch (Exception e)
            {
                Logger.Error($"An error occurred generating BaseDepotClient: {e.Message}\n{e}");
                throw;
            }
        }

        private static T WaitFor<T>(Task<T> task)
        {
            if (task == null)
                throw new ArgumentNullException($"WaitFor<{typeof(T).Name}> called with null Task");
            // task.RunSynchronously();
            task.Wait();
            return task.Result;
        }

        private static string ConvertToString(object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return null;
            }

            if (value is string strValue)
            {
                return strValue;
            }

            if (value is Enum)
            {
                var name = Enum.GetName(value.GetType(), value);
                if (name != null)
                {
                    var field = IntrospectionExtensions.GetTypeInfo(value.GetType()).GetDeclaredField(name);
                    if (field != null)
                    {
                        if (CustomAttributeExtensions.GetCustomAttribute(field, typeof(EnumMemberAttribute)) is EnumMemberAttribute attribute)
                        {
                            return attribute.Value ?? name;
                        }
                    }

                    return Convert.ToString(Convert.ChangeType(value, Enum.GetUnderlyingType(value.GetType()), cultureInfo));
                }
            }
            else if (value is bool boolValue)
            {
                return Convert.ToString(boolValue, cultureInfo).ToLowerInvariant();
            }
            else if (value is byte[] bytes)
            {
                return Convert.ToBase64String(bytes);
            }
            else if (value.GetType().IsArray)
            {
                var array = ((Array)value).OfType<object>();
                return string.Join(",", array.Select(o => ConvertToString(o, cultureInfo)));
            }

            return Convert.ToString(value, cultureInfo) ?? string.Empty;
        }
    }
}
