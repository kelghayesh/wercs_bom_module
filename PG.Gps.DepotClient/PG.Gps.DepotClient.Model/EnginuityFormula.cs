using System;
using System.Collections.Generic;

namespace PG.Gps.DepotClient.Model {
	public class EnginuityFormula {
		public string FormulaName { get; set; }
		public string FormulaNnumber { get; set; }
		public string ProcessName { get; set; }
		public string ProcessNumber { get; set; }
		public string Version { get; set; }
		public string IPClassification { get; set; }
		public string CreateID { get; set; }
		public DateTime CreateDT { get; set; }
		public string BatchNumber { get; set; }
		public decimal? TotalWeight { get; set; }
		public string TotalWeightUnits { get; set; }
		// public PartDto Part { get; set; }
		public IList<EnginuityIngredient> Ingredients { get; set; }
		public string FullFormulaWithVersion => $"{FormulaNnumber} V{Version}";
		public decimal? TargetTotal { get; set; }
		public int? IPClassificationId { get; set; }
		public string FormulaType { get; set; }
		public string SecurityClassification { get; set; }
		public IList<EnginuitySubstitution> Substitution { get; set; }
	}
}
