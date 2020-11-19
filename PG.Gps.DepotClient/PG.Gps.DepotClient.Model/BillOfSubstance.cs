using System.Collections.Generic;

namespace PG.Gps.DepotClient.Model {
	public enum BillOfSubstanceSourceType {
		PlmSubstancesAndMaterials,
		GpsMaterialComposition
	}

	public enum BillOfSubstanceSourceFlag {
		PlaceholderSubstanceFromPlm,
		MissingFromPlmSubstancesAndMaterials,
		NewInPlmSubstancesAndMaterials,
		FromGpsComposition,

		//errors
		MissingMaterialComposition,
	}

	public class BillOfSubstance : ICalculatedComponentsResult {

		public DepotPart ProductPart { get; set; }

		//outputs
		public bool? ContainsReaction { get; set; }
		public bool? ContainsEnvironmentalLoss { get; set; }
		public bool? IsSDSSpecific { get; set; }
		public List<string> Warnings { get; set; }
		public List<string> Errors { get; set; }
		public List<DepotCompositionPart> FlattenedBillOfMaterials { get; set; }
		public List<BillOfSubstanceEntry> CalculatedBillOfSubstance { get; set; }
		public List<DepotCompositionPart> DesignBillOfSubstance { get; set; }

		// Interface implementation
		public List<DepotPart> SourceParts => ProductPart==null ? null : new List<DepotPart> { ProductPart };
		public List<DepotCompositionPart> CalculatedComponents => CalculatedBillOfSubstance==null ? null : new List<DepotCompositionPart>(CalculatedBillOfSubstance);
	}

	public class BillOfSubstanceEntry : DepotCompositionPart {
		public List<BillOfSubstanceSource> Sources { get; set; }
	}

	public class BillOfSubstanceSource {
		public BillOfSubstanceSourceType Source { get; set; }
		public BillOfSubstanceSourceFlag? Flag { get; set; }
		public DepotCompositionPart Composition { get; set; }
		public decimal? ProductPartRelativeMin { get; set; }
		public decimal? ProductPartRelativeTarget { get; set; }
		public decimal? ProductPartRelativeMax { get; set; }

	}

}
