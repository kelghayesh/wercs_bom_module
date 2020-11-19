using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using System.Threading.Tasks;
using PG.Gps.DepotClient.Model;
using PG.Gps.DepotClient;
using AutoMapper;
using System.Reflection;
using System.IO;

namespace PG.Gps.DepotClient
{
	//public partial class DepotClientBillOfSubstanceResult : ICalculatedComponentsResult
	//{
	//	public List<DepotPart> SourceParts => throw new NotImplementedException();

	//	public bool? IsSDSSpecific => throw new NotImplementedException();

	//	public List<DepotCompositionPart> CalculatedComponents => CalculatedBillOfSubstance == null ? null : new List<DepotCompositionPart>(CalculatedBillOfSubstance);

	//	public List<string> Warnings => throw new NotImplementedException();

	//	public List<string> Errors => throw new NotImplementedException();
	//}

	public partial class GpsDepotClient
	{
		public static IEnumerable<string> RAW_MATERIAL_PART_TYPE_NAMES { get; } = new[] { "Individual Raw Material Specification", "Legacy Raw Material", "Raw Material", "Master Raw Material Part", "Master Raw Material Specification" };

		private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
		public static string S_NULL => "null";
		public static string S_QUOTE => "\"";
		public static string SLASH => "/";


		private static HashSet<string> SkipAssemblyNames { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "AutoMapper" };
		private static Logger LOG { get; } = LogManager.GetLogger("MapUtil");


		private static Lazy<IMapper> Lazy { get; } = new Lazy<IMapper>(() =>
		{
			var profiles = ScanForProfiles();
			LOG.Trace("Using AutoMapper Profiles found in AppDomain: {0}", new object[] { string.Join(", ", profiles.Select(p => $"{p.Assembly.GetName().Name}:{p.Name}")) });
			var config = new MapperConfiguration(cfg => {
				cfg.AddProfiles(profiles);
				//cfg.AddMaps(profiles);
			});
			var mapper = config.CreateMapper();
			return mapper;
		});


		private static IEnumerable<Type> ScanForProfiles()
		{
			return AppDomain.CurrentDomain
							.GetAssemblies()
							.Where(assy => !SkipAssemblyNames.Contains(assy.GetName().Name))
							.SelectMany(assy => assy.GetTypes())
							.Where(type => type.IsSubclassOf(typeof(Profile)));
		}


		private static IMapper Mapper => Lazy.Value;

		//private static TDest Map<TDest>(this object source)
		//{
		//	return WrapReflectionException(() => Mapper.Map<TDest>(source));
		//}

		//private static TDest Map<TDest>(this object source, TDest dest)
		//{
		//	return WrapReflectionException(() => Mapper.Map(source, dest));
		//}

		//private static TDest Map<TSource, TDest>(this TSource source)
		//{
		//	return WrapReflectionException(() => Mapper.Map<TSource, TDest>(source));
		//}

		//private static TDest Map<TSource, TDest>(this TSource source, TDest dest)
		//{
		//	return WrapReflectionException(() => Mapper.Map(source, dest));
		//}

		/*
		public static TDest MergeFrom<TSource, TDest>(this TDest dest, TSource source, bool allowOverrideWithNulls = true, IEnumerable<string> explicitMemberNames = null)
		{
			if (source == null)
				return dest;

			return WrapReflectionException(() => {
				var src = Mapper.Map<TDest>(source);
				return dest.Merge(src, allowOverrideWithNulls, explicitMemberNames);
				});
		}
        */

		private static T WrapReflectionException<T>(Func<T> func)
		{
			try
			{
				return func.Invoke();
			}
			catch (ReflectionTypeLoadException ex)
			{
				StringBuilder sb = new StringBuilder();
				foreach (Exception exSub in ex.LoaderExceptions)
				{
					sb.AppendLine(exSub.Message);
					FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
					if (!string.IsNullOrEmpty(exFileNotFound?.FusionLog))
					{
						sb.AppendLine("Fusion Log:");
						sb.AppendLine(exFileNotFound.FusionLog);
					}
					sb.AppendLine();
				}
				LOG.Error("ReflectionTypeLoadException found: {0}", new object[] { sb });
				throw;
			}
		}

		// NOTE: these must be const for use in switch statements
		private const string CONTENT_TYPE_JSON = "application/json";
		private const string COMP_TYPE_NAME_BOM = "BOM";
		private const string COMP_TYPE_SDS_BOS = "SDS BOS";
		private const string PART_TYPE_CODE_PHASE = "PHASE";
		private const string PART_TYPE_CODE_PROC = "PROC";
		private const string PART_TYPE_CODE_FOP = "FOP";
		private const string PART_TYPE_CODE_FC = "FC";
		private const string PART_TYPE_CODE_FIL = "FIL";
		/// <summary>
		/// 
		/// </summary>
		/// <param name="part"></param>
		/// <param name="forSds">indicate whether the SDS BOS is desired or the "normal" BOS</param>
		/// <param name="includeFragranceComposition">Break down perfumes if possible</param>
		/// <param name="requireSDSSpecific">indicate if SDS is desired but no SDS specific composition is found, should the "normal" calculation be returned instead (always null for assessment spec)</param>
		/// <param name="partTypesForAssessmentSpecs">Part types here will return a calculated assessment spec, otherwise will return a calculated BOS.</param>
		/// <param name="allowResultWhenBosErrors">Returns a result even if there are BOS errors.</param>
		/// <returns></returns>
		public async Task<ICalculatedComponentsResult> GetCalculatedComponentsForPartAsync(DepotPart part, bool forSds = false, bool includeFragranceComposition = false, bool includeGpsConfidentialComposition = false, bool requireSDSSpecific = false, IEnumerable<string> partTypesForAssessmentSpecs = null, bool allowResultWhenBosErrors = false)
		{
			var partKey = part?.PartKey;
			if (string.IsNullOrEmpty(partKey))
				return new BillOfSubstance { ProductPart = part, IsSDSSpecific = false, Errors = new List<string> { "PartKey was empty" } };

			var usesAssessmentSpec = !string.IsNullOrEmpty(part?.PartTypeName)
				&& (partTypesForAssessmentSpecs ?? RAW_MATERIAL_PART_TYPE_NAMES)
						.Any(n => !string.IsNullOrEmpty(n) && n.Equals(part.PartTypeName, StringComparison.OrdinalIgnoreCase));

			if (usesAssessmentSpec)
			{
				// Calculate Assessment Spec
				var result = await GetCalculatedAssessmentSpecAsync(partKey, forSds, includeFragranceComposition, includeGpsConfidentialComposition);
				AssessmentSpecResult assessmentSpecResult = Mapper.Map<AssessmentSpecResult>(result);
				return assessmentSpecResult;
			}
			else
			{
				// Calculate BOS
				var result = await GetCalculatedBosAsync(partKey, forSds, includeFragranceComposition, allowResultWhenBosErrors);
				//IMapper mapper = MapUtil.Mapper;
				BillOfSubstance billOfSubstance = Mapper.Map<BillOfSubstance>(result);
				return billOfSubstance;// as ICalculatedComponentsResult;
			}
		}
	}
}
