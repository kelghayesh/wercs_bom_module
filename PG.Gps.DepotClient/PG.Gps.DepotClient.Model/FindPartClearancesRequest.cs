namespace PG.Gps.DepotClient.Model
{
	public class FindPartClearancesRequest
	{
        public FindPartClearancesRequest()
        {
            MaxRows = 1000;
        }
		public string PartName { get; set; }
		public string SupplierName { get; set; }

		public string[] PartKeys { get; set; }

        public bool IncludeArchivedPartClearances;
        public bool IncludeObsoleteParts;

		//public string Revision { get; set; }
        public string BusinessArea { get; set; }
		public string[] ProductCategoryPlatforms { get; set; }
		public string[] Functions { get; set; }
        public string MaterialClass { get; set; }
        public string MaterialSubclass { get; set; }

		public string[] Regions { get; set; }
		public string RequestKey { get; set; }
        public int MinimumClearanceLevel { get; set; }
        public int MaxRows { get; set; }
	}
}
