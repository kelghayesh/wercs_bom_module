using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDS.SDSRequest.Factory
{
    public class HttpFactory
    {
        public static string GetQSParamValue(string param)
        {
            string requestId = HttpContext.Current.Request.QueryString[param] == null ? string.Empty : HttpContext.Current.Request.QueryString[param].ToString();
            if (string.IsNullOrEmpty(requestId)) requestId = HttpContext.Current.Session[param] == null ? string.Empty : HttpContext.Current.Session[param].ToString();
            return requestId.Trim();
        }
    }
}