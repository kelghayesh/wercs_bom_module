using System;
using System.Collections.Generic;
using System.Text;

namespace PG.Gps.DepotClient.Model
{
    public class DepotCompositionPart : SearchCompositionResult
    {
        //KE7777 added following json tag line from github on 20201015
        [Newtonsoft.Json.JsonProperty("childPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]

        public new DepotPart ChildPart { get; set; }

        public string ParentPartKey { get; private set; }
        public string ParentPath { get; private set; }
        public string PartKeyPath { get; private set; }
        public string CompositionTypePath { get; private set; }

        private string _path;
        public string Path
        {
            get => _path;
            set
            {
                _path = value;
                var parts = value?.Split('/');
                ParentPartKey = CalcParentPartKey(parts);
                ParentPath = CalcParentPath(parts);
                PartKeyPath = JoinPathParts(parts, 0);
                CompositionTypePath = JoinPathParts(parts, 1);
            }
        }

        private static string CalcParentPartKey(string[] pathParts)
        {
            return (pathParts == null || pathParts.Length < 3) ? string.Empty : pathParts[pathParts.Length - 3];
        }

        private static string CalcParentPath(string[] pathParts)
        {
            var parentPartCount = (pathParts?.Length ?? 0) - 2;
            return parentPartCount < 1 ? string.Empty : string.Join("/", pathParts, 0, parentPartCount);
        }

        private static string JoinPathParts(string[] pathParts, int offset)
        {
            if (pathParts == null || offset >= pathParts.Length)
                return string.Empty;

            StringBuilder ret = new StringBuilder(pathParts[offset]);
            for (int i = offset + 2; i < pathParts.Length; i += 2)
            {
                ret.Append("/").Append(pathParts[i]);
            }
            return ret.ToString();
        }
    }
}
