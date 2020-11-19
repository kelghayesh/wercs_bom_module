using System.Collections.Generic;

namespace PG.Gps.DepotClient.Model {
	public interface ICalculatedComponentsResult {
		/// <summary>The source parts used to calculate the components results</summary>
		List<DepotPart> SourceParts { get; } 
		/// <summary>true if calculation is SDS specific</summary>
		bool? IsSDSSpecific { get; }
		/// <summary>The results of the calculation</summary>
		List<DepotCompositionPart> CalculatedComponents { get; }
		/// <summary>Warnings generated during calculation (for end users)</summary>
		List<string> Warnings { get; }
		/// <summary>Any hard errors during the calculation (if exists: all results should be ignored)</summary>
		List<string> Errors { get; }
	}
}
