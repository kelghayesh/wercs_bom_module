using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SDS.Portal.Web.Models
{
    public class BOMRequestResultHeader
    {
        public int RequestId { get; set; }
        public string TargetKey { get; set; }
        public int? DTE_STATUS_CODE { get; set; }
        public string DTE_STATUS_MESSAGE { get; set; }
        //public string ProcessRequestUrl { get; set; }
    }

    public class BOMRequestResultErrorDetail
    {
        //[Column(Order = 0)]
        public int RequestId { get; set; }
        public string TargetKey { get; set; }
        public string MissingMaterialKey { get; set; }
        public string ErrorMessageType { get; set; }
        public string ErrorMessageText { get; set; }
    }
}