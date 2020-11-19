using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using AutoMapper;
using NLog;
//using PgExessCommon.PG.CVT.Model;

namespace SDS.SDSRequest.Common {
    public static class MapUtil {
		private static HashSet<string> SkipAssemblyNames { get; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "AutoMapper" };
		private static Logger LOG { get; } = LogManager.GetLogger("MapUtil");

        
        private static Lazy<IMapper> Lazy { get; } = new Lazy<IMapper>(() =>
		{
			var profiles = ScanForProfiles();
			LOG.Trace("Using AutoMapper Profiles found in AppDomain: {0}", new object[]{string.Join(", ", profiles.Select(p=> $"{p.Assembly.GetName().Name}:{p.Name}"))});
			var config = new MapperConfiguration(cfg => {
                cfg.AddProfiles(profiles);
                //cfg.AddMaps(profiles);
			});
			var mapper = config.CreateMapper();
			return mapper;
		});
		

		private static IEnumerable<Type> ScanForProfiles() {
			return AppDomain.CurrentDomain
							.GetAssemblies()
							.Where(assy=> !SkipAssemblyNames.Contains(assy.GetName().Name))
							.SelectMany(assy => assy.GetTypes())
							.Where(type => type.IsSubclassOf(typeof(Profile)));
		}

        
        public static IMapper Mapper => Lazy.Value;

        public static TDest Map<TDest>(this object source) {
			return WrapReflectionException(() => Mapper.Map<TDest>(source));
        }

		public static TDest Map<TDest>(this object source, TDest dest) {
			return WrapReflectionException(() => Mapper.Map(source, dest));
        }

		public static TDest Map<TSource, TDest>(this TSource source) {
			return WrapReflectionException(() => Mapper.Map<TSource, TDest>(source));
        }

		public static TDest Map<TSource, TDest>(this TSource source, TDest dest) {
			return WrapReflectionException(() => Mapper.Map(source, dest) );
        }

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
			try {
				return func.Invoke();
			} catch(ReflectionTypeLoadException ex) {
				StringBuilder sb = new StringBuilder();
				foreach(Exception exSub in ex.LoaderExceptions) {
					sb.AppendLine(exSub.Message);
					FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
					if(!string.IsNullOrEmpty(exFileNotFound?.FusionLog)) {
						sb.AppendLine("Fusion Log:");
						sb.AppendLine(exFileNotFound.FusionLog);
					}
					sb.AppendLine();
				}
				LOG.Error("ReflectionTypeLoadException found: {0}", new object[] { sb });
				throw;
			}
		}
    }
}
