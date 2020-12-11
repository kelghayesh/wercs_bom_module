using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PG.Gps.DepotClient
{
	public class QueryStringBuilder
	{
		public static string Build(Dictionary<string, object> qParams, bool includeNullParameters = true)
		{
			var q = new StringBuilder();

			if(qParams?.Any()??false) {
				const char eq = '=';
				const char amp = '&';
				foreach(var p in qParams) {
					char joinChar = q.Length == 0 ? '?' : amp;
					var key = Escape(p.Key);
					
					if(p.Value == null) {
						if(includeNullParameters)
							q.Append(joinChar).Append(key).Append(eq);

						continue;
					}

					var list = p.Value as IEnumerable;

					string val = string.Empty;
					if(p.Value is int intVal) {
						val = intVal.ToString("F0");
					} else if(p.Value is long longVal) {
						val = longVal.ToString("F0");
					} else if(p.Value is string strVal) {
						val = Escape(strVal);
					} else if(p.Value is IEnumerable enumerableVal) {
						foreach(var oVal in enumerableVal) {
							q.Append(joinChar).Append(key).Append(eq);
							if(oVal is int eIntVal) {
								q.Append(eIntVal.ToString("F0"));
							} else if (oVal is long eLongVal) {
								q.Append(eLongVal.ToString("F0"));
							} else if (oVal!=null || includeNullParameters) {
								q.Append(Escape(oVal?.ToString()??string.Empty));
							}
						}
						continue;
					} else {
						val = Escape(p.Value.ToString());
					}

					q.Append(joinChar).Append(key).Append(eq).Append(val);
				}
			}

			return q.ToString();
		}
		
		public static string Build(object paramObject, bool includeNullParameters = true)
		{
			if(paramObject == null)
				return null;

			var valDict = paramObject.GetType()
									 .GetProperties()
									 .Where(p => p.GetMethod?.IsPublic ?? false)
									 .ToDictionary(pi => pi.Name, pi => pi.GetValue(paramObject));
			
			return Build(valDict, includeNullParameters);
		}
		
		private static string Escape(string val) {
			return Uri.EscapeDataString(val)
					  .Replace(".", "%2E");
		}
	}
}
