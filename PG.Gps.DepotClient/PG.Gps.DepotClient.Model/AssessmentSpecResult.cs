using System.Collections.Generic;

namespace PG.Gps.DepotClient.Model {
	public class AssessmentSpecResult : ICalculatedComponentsResult {
		public DepotPart Part { get; set; }
		public List<DepotCompositionPart> CalculatedComponents { get; set; }
		public List<string> Warnings { get; set; }
		public List<string> Errors { get; set; }

		// Interface implementation
		public List<DepotPart> SourceParts => Part==null ? null : new List<DepotPart>() { Part };
		public bool? IsSDSSpecific { get; } = null;
	}
}
