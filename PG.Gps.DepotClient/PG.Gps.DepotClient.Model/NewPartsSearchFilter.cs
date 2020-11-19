using System.Collections.Generic;

namespace PG.Gps.DepotClient.Model {
	public class NewPartsSearchFilter {
		public string SystemKey { get; set; }
		public int next { get; set; }
		public int offset { get; set; }
		// Filters
		public bool? IsForPass { get; set; }
		public string PartKeyTerm { get; set; }
		public DateRange ModifiedRange { get; set; }
		public List<string> PartStatus { get; set; }
		public List<string> PlmTypes { get; set; }
		public List<string> PlmPolicies { get; set; }
		public List<string> PlmStates { get; set; }
		public List<string> PlmStages { get; set; }
		public List<string> IngredientClasses { get; set; }
		public List<string> PartTypes { get; set; }
		public List<string> PrimaryOrganizations { get; set; }
		public List<string> Categories { get; set; }
		public List<string> SubCategories { get; set; }
		public List<string> Segments { get; set; }
		public List<string> Sectors { get; set; }
		public List<string> SubSectors { get; set; }
		public List<string> SecurityClassifications { get; set; }
		public List<string> BusinessAreas { get; set; }
		public List<string> ProductCategoryPlatforms { get; set; }
		public List<string> ReviewStatuses { get; set; }
	}
}
