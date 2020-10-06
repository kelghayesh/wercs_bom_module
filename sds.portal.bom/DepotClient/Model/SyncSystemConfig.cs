using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Gps.LocalDepotClient.Model {
    public class SyncSystemConfig {
        public string SyncSystemKey { get; set; }
        public List<string> PlmTypes { get; set; }
        public List<string> PartTypes { get; set; }
        public List<SyncCompositionType> CompTypes { get; set; }
    }
}
