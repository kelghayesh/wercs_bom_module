using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG.Gps.DepotClient.Model;

namespace PG.Gps.DepotClient.Model.Wercs
{

    public class WercsDangerousGoods  //PG.Gps.DepotClient.Model.DangerousGoods (GpsDepotClientModel.cs)
    {
        public string SrcKey { get; set; }
        public string SrcRevision { get; set; }
        public string Key { get; set; }

        public int? DangerousGoodsClassifId { get; set; }

        public string DangerousGoodsClassificationPickName { get; set; }

        //public string OtherShippingName { get; set; }

        //public string MaxConsUnitPartWeightOrVol { get; set; }

        //public string MaxCustUnitPartWeightOrVol { get; set; }

        public int? PackingGroupId { get; set; }

        public string PackingGroupPickName { get; set; }

        public int? ProperShippingNameId { get; set; }

        public string ProperShippingNamePickName { get; set; }

        public bool? CanShipInLimitedQuantity { get; set; }

        public int? TechnicalName1Id { get; set; }

        public int? TechnicalName2Id { get; set; }

        public string TechnicalName1PickName { get; set; }

        public string TechnicalName2PickName { get; set; }

        public int? UnNumberId { get; set; }

        public string UnNumberPickName { get; set; }

        public string OtherUnNumber { get; set; }

        //public bool? IsUnSpecificationPackagingReq { get; set; }

        //public System.Collections.Generic.ICollection<DangerousGoodsConsumerUnitMarks> MarksLabelsRequiredOnConsumerUnit { get; set; }

        //public System.Collections.Generic.ICollection<DangerousGoodsCustomerUnitMarks> MarksLabelsRequiredOnCustomerUnit { get; set; }

        public System.Collections.Generic.ICollection<DangerousGoodsHazardClass> HazardClasses { get; set; }

        //public System.Collections.Generic.ICollection<DangerousGoodsPackagingRequirement> OtherPackagingRequirements { get; set; }


        public System.DateTimeOffset? CreatedAt { get; set; }

        public System.DateTimeOffset? ModifiedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Version { get; set; }

    }

    public partial class WercsPartDangerousGoods //PG.Gps.DepotClient.Model.PartDangerousGoods (GpsDepotClientModel.cs)
    {
        public string SrcKey { get; set; }
        public string SrcRevision { get; set; }
        public string Key { get; set; }

        public DangerousGoods DangerousGoods { get; set; }

        public System.DateTimeOffset? ModifiedAt { get; set; }
    }

}
