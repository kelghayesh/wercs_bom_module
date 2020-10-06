namespace PG.Gps.LocalDepotClient.Model {
	public class DepotPart {
		public int PartId { get; set; }
		public string PartKey { get; set; }
		public string PartSrcKey { get; set; }
		public string PartSrcRevision { get; set; }
		public string PartName { get; set; }
		public string PartTypeCode { get; set; }
		public string PartTypeName { get; set; }
		public string PartGbuName { get; set; }
		public string PartConfidentialTypeName { get; set; }
		public string PartCasNumber { get; set; }
		public bool? PartIsExperimental { get; set; }
		public string PartSecurityClassification { get; set; }
		public string PartStatusName { get; set; }
		public string PartPlmTypeName { get; set; }
		public string PartPlmPolicyName { get; set; }
		public string PartPlmStateName { get; set; }
		public string PartPlmStageName { get; set; }
		public string PartIngredientClassName { get; set; }
		public string PartCategoryName { get; set; }
		public string PartSubCategoryName { get; set; }
		public string PartSegmentName { get; set; }
		public string PartSectorName { get; set; }
		public string PartSubSectorName { get; set; }
	}
}
