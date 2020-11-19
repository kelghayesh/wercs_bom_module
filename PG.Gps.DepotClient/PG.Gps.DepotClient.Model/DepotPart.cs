using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace PG.Gps.DepotClient.Model
{
    public class DepotPart : SearchPartResult
    {

        [JsonIgnore] // used for client processing only
        public Dictionary<string, List<DepotCompositionPart>> Compositions { get; set; }

        public bool IsPartIdStub => PartId != 0 && string.IsNullOrEmpty(PartKey);
    }

    public class DepotPartWithMessage : DepotPart
    {
        public string Message { get; set; }
    }

}
