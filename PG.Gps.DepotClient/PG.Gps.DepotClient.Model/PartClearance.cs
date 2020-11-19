using System.Linq;

namespace PG.Gps.DepotClient.Model
{
	public class PartClearance
	{
		public string PartKey { get; set; }
		public string PartKeyRev { get; set; }
		public string PartName { get; set; }
        public string SupplierMaterialTradeName { get; set; }
        public string SupplierName { get; set; }
        public string ClearanceLevel { get; set; }
        public decimal? MaxClearedAmount { get; set; }
		public string MaxClearedAmountUnit { get; set; }
		public string Comments { get; set; }
		public string RequestKey { get; set; }
		public string RsrKey { get; set; }
		public string[] Regions { get; set; }

        public string[] PartBusinessAreas { get; set; }
        public string[] PartProductCategoryPlatforms { get; set; }
        public string[] PartFunctions { get; set; }

        public string PartMaterialClass { get; set; }
        public string PartMaterialSubclass { get; set; }


        public string AssessedBusinessArea { get; set; }

        public string[] AssessedProductCategoryPlatforms { get; set; }
        public string[] AssessedFunctions { get; set; }


        public bool? IsPartClearanceArchived { get; set; }
        public bool? IsPartObsolete { get; set; }

        public bool IsPartObsoleteOrIsPartClearanceArchived => IsPartClearanceArchived.GetValueOrDefault() || IsPartObsolete.GetValueOrDefault();

        public string RegionsString => (Regions != null && Regions.Any()) ? string.Join(",", Regions) : string.Empty;
        public string PartFunctionsString => (PartFunctions != null && PartFunctions.Any()) ? string.Join(",", PartFunctions) : string.Empty;
        public string PartProductCategoryPlatformsString =>
            (PartProductCategoryPlatforms != null && PartProductCategoryPlatforms.Any())
                ? string.Join(",", PartProductCategoryPlatforms)
                : string.Empty;

        public string PartBusinessAreasString => (PartBusinessAreas != null && PartBusinessAreas.Any())
            ? string.Join(",", PartBusinessAreas)
            : string.Empty;

        public string AssessedProductCategoryPlatformsString =>
            (AssessedProductCategoryPlatforms != null && AssessedProductCategoryPlatforms.Any())
                ? string.Join(",", AssessedProductCategoryPlatforms)
                : string.Empty;

        public string AssessedFunctionsString => (AssessedFunctions != null && AssessedFunctions.Any())
            ? string.Join(",", AssessedFunctions)
            : string.Empty;
    }
}
