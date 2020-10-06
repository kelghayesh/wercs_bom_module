using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using NLog;
//using System.Diagnostics;
using PG.Gps.DepotClient.Model;

namespace PG.Gps.LocalDepotClient
{
    public class DepotClient : IDisposable
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private const string S_NULL = "null";
        private const string S_QUOTE = "\"";
        private const string SLASH = "/";

        /// <summary>
        /// Returns true if valid response. Default is call response.EnsureSuccessStatusCode().
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public delegate bool ValidateResponseHandler(HttpResponseMessage response);

        private readonly TimeSpan DEFAULT_TIMEOUT = new TimeSpan(0, 5, 0);

        private readonly HttpClient _client;
        private ValidateResponseHandler _responseValidator;

        public DepotClient(string depotBaseUrl, TimeSpan? httpTimeout = null)
        {
            Logger.Trace("DepotClient[Ctor]: baseUrl={0} httpTimeout={1}", depotBaseUrl, httpTimeout);
            //Trace.WriteLine("DepotClient[Ctor]: baseUrl={0} httpTimeout={1}" + depotBaseUrl);
            _client = new HttpClient();
            string baseAddress = depotBaseUrl + (depotBaseUrl.EndsWith(SLASH) ? string.Empty : SLASH);
            _client.BaseAddress = new Uri(baseAddress);
            _client.Timeout = httpTimeout ?? DEFAULT_TIMEOUT;
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Logger.Trace("Client created: url={0}", baseAddress);
            //Trace.WriteLine("Client created: url={0}");
        }

        public DepotClient(string depotBaseUrl, string depotUser, string depotPass, TimeSpan? httpTimeout = null) : this(depotBaseUrl, httpTimeout)
        {
            Logger.Trace("DepotClient[Ctor]: baseUrl={0} depotUser={1} depotPass=**j/k** httpTimeout={2}", depotBaseUrl, depotUser, httpTimeout);
            //Trace.WriteLine("DepotClient[Ctor]: baseUrl={0} depotUser={1} depotPass=**j/k** httpTimeout={2}");
            SetAuthentication(depotUser, depotPass);
        }

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

        /// <summary>
        /// Sets the Depot Authentication Value. Will remove auth header if either is null.
        /// </summary>
        /// <param name="auth"></param>
        public void SetAuthentication(string depotUser, string depotPass)
        {
            AuthenticationHeaderValue depotAuth = null;
            if (!string.IsNullOrEmpty(depotUser) && !string.IsNullOrEmpty(depotPass))
            {
                Logger.Trace("Creating Authentication for {0}", depotUser);
                //Trace.WriteLine("Creating Authentication for {0}");
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
            _client.DefaultRequestHeaders.Authorization = depotAuth; // NOTE: Will remove auth header if _depotAuth=null
        }

        private const string F_LIST_COMP_TYPES = "api/v1/pass/list-comp-types"; // GET
                                                                                /// <summary>
                                                                                /// Values be used as a filter in the composition lookup.
                                                                                /// </summary>
                                                                                /// <returns>A list of CompositionTypes in Depot</returns>
        public async Task<List<string>> ListCompositionTypes()
        {
            Logger.Trace("ListCompositionTypes(): calling {0}", F_LIST_COMP_TYPES);
            //Trace.WriteLine("ListCompositionTypes(): calling {0}");
            return await DoGet<List<string>>(F_LIST_COMP_TYPES);
        }

        private const string F_FIND_PART_KEY = "api/v1/pass/find-part-key"; // GET
                                                                            /// <summary>
                                                                            /// Values be used as a filter in the composition lookup.
                                                                            /// </summary>
                                                                            /// <returns>A list of CompositionTypes in Depot</returns>
        public async Task<List<FindPartKeyResult>> FindPartKey(string key)
        {
            string uri = F_FIND_PART_KEY + "?key=" + Uri.EscapeDataString(key);
            Logger.Trace("FindPartKey({0}): calling {1}", key, uri);
            return await DoGet<List<FindPartKeyResult>>(uri);
        }

        private const string F_PART_LOOKUP = "api/v1/pass/search-parts-key?keyPart={0}"; // GET
        private const string F_PART_LOOKUP_SEARCH = "api/v1/pass/parts-search"; // POST
                                                                                /// <summary>
                                                                                /// 
                                                                                /// </summary>
                                                                                /// <param name="keyPart">The beginning of a part key</param>
                                                                                /// <param name="keyPattern"></param>
                                                                                /// <returns></returns>
        public async Task<List<DepotPart>> LookupPartsByKey(string keyPart, string keyPattern = null)
        {
            Logger.Trace("LookupPartsByKey: keyPart={0} keyPattern={1}", PrepareDebugString(keyPart, Logger.IsDebugEnabled), PrepareDebugString(keyPattern, Logger.IsDebugEnabled));
            if (string.IsNullOrEmpty(keyPart))
                return new List<DepotPart>(0);

            if (string.IsNullOrEmpty(keyPattern))
            {
                string callPart = string.Format(F_PART_LOOKUP, Uri.EscapeDataString(keyPart));
                Logger.Trace("LookupPartsByKey: calling={0}", callPart);
                return await DoGet<List<DepotPart>>(callPart);
            }

            Logger.Trace("LookupPartsByKey: calling={0}", F_PART_LOOKUP_SEARCH);
            return await DoPost<List<DepotPart>>(F_PART_LOOKUP_SEARCH, new { term = keyPart, keyPattern });
        }

        private const string F_GET_COMPOSITION = "api/v1/pass/composition"; // POST
                                                                            /// <summary>
                                                                            /// Gets the full composition
                                                                            /// </summary>
                                                                            /// <param name="key"></param>
                                                                            /// <returns></returns>
        public async Task<List<DepotCompositionPart>> GetCompositionForPartKey(string key)
        {
            Logger.Trace("LookupCompositionForPartKey{0}: calling={1}", key, F_GET_COMPOSITION);
            return await DoPost<List<DepotCompositionPart>>(F_GET_COMPOSITION, new { term = key });
        }

        private const string F_LOOKUP_COMPOSITION = "api/v1/pass/search-comp"; // POST
                                                                               /// <summary>
                                                                               /// 
                                                                               /// </summary>
                                                                               /// <param name="key"></param>
                                                                               /// <param name="compositionTypes"></param>
                                                                               /// <param name="maxLevels"></param>
                                                                               /// <returns></returns>
        public async Task<List<DepotCompositionPart>> LookupCompositionForPartKey(string key, IEnumerable<string> compositionTypes = null, int? maxLevels = null)
        {
            Logger.Trace("LookupCompositionForPartKey: calling={0}", F_LOOKUP_COMPOSITION);
            //Trace.WriteLine("LookupCompositionForPartKey: calling={0}");
            return await DoPost<List<DepotCompositionPart>>(F_LOOKUP_COMPOSITION, new { key, compositionTypes, maxLevels });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="keyPart"></param>
        /// <param name="keyPattern"></param>
        /// <param name="compositionTypes"></param>
        /// <param name="maxLevels"></param>
        /// <returns></returns>
        public async Task<List<DepotCompositionPart>> LookupCompositionForFirstPartKey(string keyPart, string keyPattern, IEnumerable<string> compositionTypes = null, int? maxLevels = null)
        {
            var part = (await LookupPartsByKey(keyPart, keyPattern))?.First();
            if (string.IsNullOrEmpty(part?.PartKey))
                return null;

            return await LookupCompositionForPartKey(part.PartKey, compositionTypes, maxLevels);
        }

        private const string F_GET_PART_ATTRS_BY_PART_ID = "api/v1/pass/search-part-attrs-id"; // POST
        /// <summary>
        /// 
        /// </summary>
        /// <param name="partIds"></param>
        /// <param name="attrNameFilter">(optional) List of attribute names to search for.</param>
        /// <returns></returns>
        public async Task<List<DepotPartAttribute>> GetPartAttributesByPartIds(IEnumerable<int> partIds, IEnumerable<string> attrNameFilter = null)
        {
            if (partIds == null)
                return new List<DepotPartAttribute>(0);

            Logger.Trace("GetPartAttributesByPartIds: calling={0}", F_GET_PART_ATTRS_BY_PART_ID);
            return await DoPost<List<DepotPartAttribute>>(F_GET_PART_ATTRS_BY_PART_ID, new { partIds, attrNameFilter });
        }

        private const string F_GET_PART_ATTRS_BY_PART_KEY = "api/v1/pass/search-part-attrs-key"; // POST
        /// <summary>
        /// 
        /// </summary>
        /// <param name="keys"></param>
        /// <param name="attrNameFilter">(optional) List of attribute names to search for.</param>
        /// <returns></returns>
        public async Task<List<DepotPartAttribute>> GetPartAttributesByPartKeys(IEnumerable<string> partKeys, IEnumerable<string> attrNameFilter = null)
        {
            if (partKeys == null)
                return new List<DepotPartAttribute>(0);

            Logger.Trace("GetPartAttributesByPartKeys: calling={0}", F_GET_PART_ATTRS_BY_PART_KEY);
            return await DoPost<List<DepotPartAttribute>>(F_GET_PART_ATTRS_BY_PART_KEY, new { partKeys, attrNameFilter });
        }



        private const string F_PULL_PART = "api/v1/plm/pull-part?srcKey={0}&srcRevision={1}&plmTypeName={2}"; // POST
                                                                                                              /// <summary>
                                                                                                              ///  Pull a specific gcas revision from PLM
                                                                                                              /// </summary>
                                                                                                              /// <param name="srcKey"></param>
                                                                                                              /// <param name="srcRevision"></param>
                                                                                                              /// <param name="plmTypeName"></param>
                                                                                                              /// <returns></returns>
        public async Task PullPart(string srcKey, string srcRevision = null, string plmTypeName = null)
        {
            if (string.IsNullOrEmpty(srcKey))
                return;

            string uri = string.Format(F_PULL_PART, Uri.EscapeDataString(srcKey), Uri.EscapeDataString(srcRevision ?? ""), Uri.EscapeDataString(plmTypeName ?? ""));
            Logger.Trace("PullPart: srcKey={0} srcRev={1} plmType={2}", srcKey, srcRevision, plmTypeName);
            await DoPost(uri, null);
        }

        private const string F_PULL_PARTS = "api/v1/plm/pull-parts?keys={0}&plmTypeName={1}"; // POST
                                                                                              /// <summary>
                                                                                              /// 
                                                                                              /// </summary>
                                                                                              /// <param name="keys">comma or whitespace delimited list of keys</param>
                                                                                              /// <param name="plmTypeName"></param>
                                                                                              /// <returns></returns>
        public async Task PullParts(string keys, string plmTypeName = null)
        {
            if (string.IsNullOrEmpty(keys))
                return;

            string uri = string.Format(F_PULL_PARTS, Uri.EscapeDataString(keys), Uri.EscapeDataString(plmTypeName ?? ""));
            Logger.Trace("PullPart: srcKey={0} plmType={1} uri={2}", keys, plmTypeName, uri);
            await DoPost(uri, null);
        }


        private const string F_PULL_FORUMLA_FROM_ENGINUITY = "api/v1/enginuity/pull-formula?formulaNumber={0}"; // POST
                                                                                                                /// <summary>
                                                                                                                /// Pulls formula from enginuity and persists to Depot (DOES NOT send to PASS)
                                                                                                                /// </summary>
                                                                                                                /// <param name="formulaNumber"></param>
                                                                                                                /// <returns></returns>
        public async Task<EnginuityFormula> PullForumulaFromEnginuity(string formulaNumber)
        {
            if (string.IsNullOrEmpty(formulaNumber) || formulaNumber.Length <= 3) // Formula numbers start with "F00", does not include version!
                return null;

            string uri = string.Format(F_PULL_FORUMLA_FROM_ENGINUITY, Uri.EscapeDataString(formulaNumber));
            Logger.Trace("PullForumulaFromEnginuity: formulaNumber={0} calling={1}", formulaNumber, uri);
            return await DoPost<EnginuityFormula>(uri, null);
        }

        private const string F_PULL_ENGINUITY_FORUMLA_TO_PASS = "api/v1/pass/pull-enginuity-formula?formulaNumber={0}"; // GET
                                                                                                                        /// <summary>
                                                                                                                        /// Pulls formula from enginuity, persists to Depot, sends to PASS
                                                                                                                        /// </summary>
                                                                                                                        /// <param name="formulaNumber"></param>
                                                                                                                        /// <returns></returns>
        public async Task<EnginuityFormula> PullEnginuityForumulaToPass(string formulaNumber)
        {
            if (string.IsNullOrEmpty(formulaNumber) || formulaNumber.Length <= 3) // Formula numbers start with "F00", does not include version!
                return null;

            string uriPart = string.Format(F_PULL_ENGINUITY_FORUMLA_TO_PASS, new object[] { Uri.EscapeDataString(formulaNumber) });
            Logger.Trace("PullForumulaFromEnginuity: formulaNumber={0} calling={1}", formulaNumber, uriPart);
            return await DoGet<EnginuityFormula>(uriPart);
        }

        private const string ReceiveCompletedSmartRequestUrl = "api/v1/pass/receive-completed-smart-request?partnumber={0}&rqnumber={1}";
        /// <summary>
        /// Allows Depot to receive a completed RQ# and attach it to a part number.
        /// </summary>
        /// <param name="partnumber"></param>
        /// <param name="rqnumber"></param>
        /// <returns></returns>
	    public async Task<DepotPart> ReceiveCompletedSmartRequest(string partnumber, string rqnumber)
        {
            var uri = string.Format(ReceiveCompletedSmartRequestUrl, Uri.EscapeDataString(partnumber), Uri.EscapeDataString(rqnumber));
            Logger.Trace($"ReceiveCompletedSmartRequest: partnumber={partnumber} rqnumber={rqnumber} ");
            var response = await DoPost<DepotPart>(uri, null);
            return response;
        }

        #region SyncMethodsRegion

        const string ROUTE_SYNC_LIST_PLM_STATES = "api/v1/sync/list-plm-states";
        /// <summary>
        /// Returns a List&lt;string&gt; of PlmStates
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> ListPlmStates()
        {
            Logger.Trace("ListPlmStates: calling={0}", ROUTE_SYNC_LIST_PLM_STATES);
            return await DoGet<List<string>>(ROUTE_SYNC_LIST_PLM_STATES);
        }

        const string ROUTE_SYNC_LIST_PART_TYPES = "api/v1/sync/list-part-types";
        /// <summary>
        /// Returns a List&lt;string&gt; of PartTypes
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> ListPartTypes()
        {
            Logger.Trace("ListPartTypes: calling={0}", ROUTE_SYNC_LIST_PART_TYPES);
            return await DoGet<List<string>>(ROUTE_SYNC_LIST_PART_TYPES);
        }

        const string ROUTE_SYNC_LIST_COMP_TYPES = "api/v1/sync/list-comp-types";
        /// <summary>
        /// Returns a List&lt;{string PartType, string Name}&gt; of CompositionTypes
        /// </summary>
        /// <returns></returns>
        public async Task<List<SyncCompositionType>> ListCompTypes()
        {
            Logger.Trace("ListCompTypes: calling={0}", ROUTE_SYNC_LIST_COMP_TYPES);
            return await DoGet<List<SyncCompositionType>>(ROUTE_SYNC_LIST_COMP_TYPES);
        }

        const string ROUTE_SYNC_LIST_COMP_TYPES_BY_PART_TYPES = "api/v1/sync/list-comp-types-by-part-types";
        /// <summary>
        /// Returns a List&lt;{string PartType, string Name}&gt; of CompositionTypes for the specified PartTypes
        /// </summary>
        /// <returns></returns>
        public async Task<List<SyncCompositionType>> ListCompTypes(IEnumerable<string> partTypeNames)
        {
            Logger.Trace("ListPartTypes: calling={0}", ROUTE_SYNC_LIST_COMP_TYPES_BY_PART_TYPES);
            return await DoPost<List<SyncCompositionType>>(ROUTE_SYNC_LIST_COMP_TYPES_BY_PART_TYPES, new { partTypeNames });
        }

        const string ROUTE_SYNC_LIST_SYNC_ATTRS = "api/v1/sync/list-sync-attrs";
        /// <summary>
        /// Returns a List&lt;string&gt; of sync attribute names
        /// </summary>
        /// <returns></returns>
        public async Task<List<string>> ListSyncAttributes()
        {
            Logger.Trace("ListSyncAttributes: calling={0}", ROUTE_SYNC_LIST_SYNC_ATTRS);
            return await DoGet<List<string>>(ROUTE_SYNC_LIST_SYNC_ATTRS);
        }

        const string ROUTE_SYNC_SET_PREFERRED_PLM_STATE_ORDER = "api/v1/sync/set-preferred-plm-state-order";
        public async Task SetSyncPreferredPlmStateOrder(string systemKey, IEnumerable<string> plmStates)
        {
            Logger.Trace("SetSyncPreferredPlmStateOrder: calling={0}", ROUTE_SYNC_SET_PREFERRED_PLM_STATE_ORDER);
            await DoPost(ROUTE_SYNC_SET_PREFERRED_PLM_STATE_ORDER, new { systemKey, plmStates });
        }

        const string ROUTE_SYNC_SET_PART_TYPES = "api/v1/sync/set-part-types";
        public async Task SetPartTypes(string systemKey, IEnumerable<string> partTypes)
        {
            Logger.Trace("SetPartTypes: calling={0}", ROUTE_SYNC_SET_PART_TYPES);
            await DoPost(ROUTE_SYNC_SET_PART_TYPES, new { systemKey, partTypes });
        }

        const string ROUTE_SYNC_SET_COMP_TYPES = "api/v1/sync/set-comp-types";
        public async Task SetCompTypes(string systemKey, IEnumerable<SyncCompositionType> compTypes)
        {
            Logger.Trace("SetCompTypes: calling={0}", ROUTE_SYNC_SET_COMP_TYPES);
            await DoPost(ROUTE_SYNC_SET_COMP_TYPES, new { systemKey, compTypes });
        }

        const string ROUTE_SYNC_GET_SYS_CONFIG = "api/v1/sync/get-sys-config";
        public async Task<SyncSystemConfig> GetSystemConfig(string systemKey)
        {
            string uri = $"{ROUTE_SYNC_GET_SYS_CONFIG}?systemKey={Uri.EscapeDataString(systemKey)}";
            Logger.Trace("GetSystemConfig: calling={0}", uri);
            return await DoGet<SyncSystemConfig>(uri);
        }

        const string ROUTE_SYNC_ADD_SYNC_PARTS = "api/v1/sync/add-sync-parts";
        public async Task<List<SyncPart>> AddSyncParts(string systemKey, IEnumerable<SyncPart> syncParts)
        {
            Logger.Trace("AddSyncParts: calling={0}", ROUTE_SYNC_ADD_SYNC_PARTS);
            return await DoPost<List<SyncPart>>(ROUTE_SYNC_ADD_SYNC_PARTS, new { systemKey, syncParts });
        }

        const string ROUTE_SYNC_REMOVE_SYNC_KEYS = "api/v1/sync/remove-sync-keys";
        public async Task RemoveSyncKeys(string systemKey, IEnumerable<string> syncKeys)
        {
            Logger.Trace("RemoveSyncKeys: calling={0}", ROUTE_SYNC_REMOVE_SYNC_KEYS);
            await DoPost(ROUTE_SYNC_REMOVE_SYNC_KEYS, new { systemKey, syncKeys });
        }

        const string ROUTE_SYNC_FIND_SYNC_PARTS_BY_KEYS = "api/v1/sync/find-sync-parts-by-keys";
        public async Task<List<SyncPart>> FindSyncPartsBySyncKeys(string systemKey, IEnumerable<string> syncKeys)
        {
            Logger.Trace("FindSyncPartsBySyncKeys: calling={0}", ROUTE_SYNC_FIND_SYNC_PARTS_BY_KEYS);
            return await DoPost<List<SyncPart>>(ROUTE_SYNC_FIND_SYNC_PARTS_BY_KEYS, new { systemKey, syncKeys });
        } // List the sync records for specified keys

        const string ROUTE_SYNC_ADD_PART_SYNC_ATTRS = "api/v1/sync/add-part-sync-attrs";
        public async Task AddPartSyncAttrs(string systemKey, IEnumerable<string> syncKeys, IEnumerable<string> syncAttrs)
        {
            Logger.Trace("AddPartSyncAttrs: calling={0}", ROUTE_SYNC_ADD_PART_SYNC_ATTRS);
            await DoPost(ROUTE_SYNC_ADD_PART_SYNC_ATTRS, new { systemKey, syncKeys, syncAttrs });
        }

        const string ROUTE_SYNC_REMOVE_PART_SYNC_ATTRS = "api/v1/sync/remove-part-sync-attrs";
        public async Task RemovePartSyncAttrs(string systemKey, IEnumerable<string> syncKeys, IEnumerable<string> syncAttrs)
        {
            Logger.Trace("RemovePartSyncAttrs: calling={0}", ROUTE_SYNC_REMOVE_PART_SYNC_ATTRS);
            await DoPost(ROUTE_SYNC_REMOVE_PART_SYNC_ATTRS, new { systemKey, syncKeys, syncAttrs });
        }

        const string ROUTE_SYNC_LIST_SYNC_PARTS_BY_ATTRS = "api/v1/sync/list-sync-parts-by-attrs";
        public async Task<List<SyncPart>> FindSyncPartsBySyncAttrs(string systemKey, IEnumerable<string> syncAttrs, int next, int offset)
        {
            Logger.Trace("FindSyncPartsBySyncAttrs: calling={0}", ROUTE_SYNC_LIST_SYNC_PARTS_BY_ATTRS);
            return await DoPost<List<SyncPart>>(ROUTE_SYNC_LIST_SYNC_PARTS_BY_ATTRS, new { systemKey, syncAttrs, next, offset });
        } // List the sync records with all options set

        const string ROUTE_SYNC_POLL_SYNC_PARTS = "api/v1/sync/poll-sync-parts";
        public async Task<List<SyncPart>> PollParts(string systemKey, DateTime startLastUpdated, DateTime endLastUpdated, int next, int offset)
        {
            Logger.Trace("PollParts: calling={0}", ROUTE_SYNC_POLL_SYNC_PARTS);
            return await DoPost<List<SyncPart>>(ROUTE_SYNC_POLL_SYNC_PARTS, new { systemKey, startLastUpdated, endLastUpdated, next, offset });
        }

        const string ROUTE_SYNC_LOOK_FOR_PART_UPDATES = "api/v1/sync/look-for-part-updates";
        public async Task<List<SyncPart>> LookForPartUpdates(string systemKey, IEnumerable<string> syncKeys = null)
        {
            Logger.Trace("LookForPartUpdates: calling={0}", ROUTE_SYNC_LOOK_FOR_PART_UPDATES);
            return await DoPost<List<SyncPart>>(ROUTE_SYNC_LOOK_FOR_PART_UPDATES, new { systemKey, syncKeys });
        }

        #endregion

        public void Dispose()
        {
            this._client.Dispose();
        }

        #region PrivateMethodsRegion

        private HttpClient Client
        {
            get
            {
                // prepwork if needed
                return _client;
            }
        }

        private async Task<T> DoGet<T>(string webMethodUrlPart)
        {
            try
            {
                var response = await Client.GetAsync(webMethodUrlPart);
                return await HandleResponse<T>(response);
            }
            catch (Exception e)
            {
                //Logger.Error("DoGet{0}: An error occured: {1}\n{2}", webMethodUrlPart, e.Message, e.ToString());
                throw;
            }
        }

        private async Task<T> DoPost<T>(string webMethodUrlPart, object requestObject)
        {
            try
            {
                string jsonRequest = JsonConvert.SerializeObject(requestObject);
                Logger.Trace("DoPost: url={0} data={1}", webMethodUrlPart, PrepareDebugString(jsonRequest, Logger.IsTraceEnabled, false));
                HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(webMethodUrlPart, content);
                return await HandleResponse<T>(response);
            }
            catch (Exception e)
            {
                //Logger.Error("DoPost{0}: An error occured: {1}\n{2}", webMethodUrlPart, e.Message, e.ToString());
                throw;
            }
        }

        private async Task DoPost(string webMethodUrlPart, object requestObject)
        {
            try
            {
                string jsonRequest = JsonConvert.SerializeObject(requestObject);
                Logger.Trace("DoPost: url={0} data={1}", webMethodUrlPart, PrepareDebugString(jsonRequest, Logger.IsTraceEnabled, false));
                HttpContent content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");
                var response = await Client.PostAsync(webMethodUrlPart, content);
                Logger.Trace("HandleResponse: StatusCode={0}", response.StatusCode);
            }
            catch (Exception e)
            {
                //Logger.Error("DoPost{0}: An error occured: {1}\n{2}", webMethodUrlPart, e.Message, e.ToString());
                throw;
            }
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            Logger.Trace("HandleResponse StatusCode: {0} {1}", (int)response.StatusCode, response.StatusCode);
            if (!ResponseValidator.Invoke(response))
                return default(T);

            var result = await response.Content.ReadAsStringAsync();
            Logger.Trace("HandleResponse: returned={0}", result);
            var ret = JsonConvert.DeserializeObject<T>(result);
            Logger.Trace("HandleResponse[DeserializeObject]: type={0}", (ret == null ? S_NULL : ret.GetType().FullName));
            return ret;
        }

        private static string PrepareDebugString(object val, bool isEnabled = true, bool isWrapWithQuotes = true)
        {
            if (!isEnabled)
                return string.Empty;

            if (val != null)
                return isWrapWithQuotes ? string.Concat(new[] { S_QUOTE, val, S_QUOTE }) : val.ToString();

            return S_NULL;
        }

    }

    #endregion
}
