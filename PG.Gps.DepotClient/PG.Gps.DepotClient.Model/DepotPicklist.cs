namespace PG.Gps.DepotClient.Model {
	public abstract class DepotPicklist {
		public int? Id { get; set; }
		public string Name { get; set; }
		public string VaultId { get; set; }
	}

	public class DepotAttributeType : DepotPicklist
	{
		public string Type { get; set; }
		public string Code { get; set; }
		public string ValueType { get; set; }
		public bool? IsDisplayable { get; set; }
		public bool? IsEditable { get; set; }
		public bool? IsForPass { get; set; }
		public string ReportKey { get; set; }
	}
	public class DepotPartStatus : DepotPicklist { }
	public class DepotPlmState : DepotPicklist { }
	public class DepotPlmStage : DepotPicklist { }
	public class DepotPartType : DepotPicklist
	{
		public string Code { get; set; }
	}
	public class DepotPlmType : DepotPicklist { }
	public class DepotPlmPolicy : DepotPicklist { }
	public class DepotPlmFormulationType : DepotPicklist { }
	public class DepotOrganization : DepotPicklist
	{
		public bool MandateSdsSpecificComposition { get; set; }
	}
	public class DepotCountry : DepotPicklist {
		public int RegionId { get; set; }
		public string RegionVaultId { get; set; }

		public string ISOCode { get; set; }
		public string ShortCode { get; set; }
	}
	public class DepotSegment : DepotPicklist { }
	public class DepotCompositionType : DepotPicklist { }
	public class DepotPackagingMaterialType : DepotPicklist { }

	public class DepotBusinessArea : DepotPicklist { }
	public class DepotProductCategoryPlatform : DepotPicklist { }
	public class DepotProductTechnologyPlatform : DepotPicklist { }

}
