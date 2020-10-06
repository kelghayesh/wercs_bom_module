using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Gps.LocalDepotClient.Model {

    public enum SyncKeyType { Key = 1, KeyRev = 2, Expression = 3 }

    public class SyncPart {
        public int Id { get; set; }
        public string SystemKey { get; set; }
        public string Key { get; set; }

        public string KeyType { get; set; }
        public string KeyExpr { get; set; }
        public string RevisionExpr { get; set; }

        public int? PartId { get; set; }
        public string PartKey { get; set; }
        public string PartSrcKey { get; set; }
        public string PartSrcRevision { get; set; }

        public DateTime? LastModifiedAt { get; set; }

        public List<string> SyncAttributes { get; set; }
        public List<string> ValidationErrors { get; set; }

    }
}
