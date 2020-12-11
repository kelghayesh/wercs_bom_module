using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Converters;

namespace PG.Gps.DepotClient {
	/// <summary>
	/// A Simple, readable, sortable DateTime format: yyyyMMdd-HH:mm:ss
	/// </summary>
	public class ReadableDateTimeConverter : IsoDateTimeConverter {
		public const string TIMESTAMP_FORMAT = "yyyyMMdd-HH:mm:ss";
		/// <summary>
		/// A Simple, readable, sortable DateTime format: yyyyMMdd-HH:mm:ss
		/// </summary>
		public ReadableDateTimeConverter() {
			base.DateTimeFormat = TIMESTAMP_FORMAT;
		}
	}
}
