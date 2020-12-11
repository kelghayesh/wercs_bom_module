namespace PG.Gps.DepotClient.Model {
    public class DepotPartAttribute {
        public int PartId { get; set; }
        public string PartKey { get; set; }
        public int AttrTypeId { get; set; }
        public string AttrTypeName { get; set; }
        public char? AttrTypeValueType { get; set; }
        public string AttrTypeReportKey { get; set; }
        public int? AttrRegionId { get; set; }
        public string AttrRegionName { get; set; }
        public string PartAttrValue { get; set; }
        public string PartAttrCasName { get; set; }
    }
}
