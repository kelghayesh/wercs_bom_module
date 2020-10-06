using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SDS.SDSRequest.Models
{
    public enum FormulaImportRequestType : int //enum
    {
        DEPOT_REQUEST=1,
        EXESS_REQUEST=2,
        BOM_REQUEST=3
    }

    public class FormulaImportRequest
    {
        [Key]
        [Column(Order = 0)]
        public int RequestId { get; set; }
        //public string RequestDescr { get; set; }
        public string SourceSystem { get; set; }

        [HiddenInput]
        public int RequestStatusId { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class FormulaImportRequestDetail
    {
        public FormulaImportRequest formulaImportRequestData { get; set; }
        public FormulaImportRequestDetail(string SourceSystem)
        {
            formulaImportRequestData = new FormulaImportRequest();
        }
        public IEnumerable<SelectListItem> RequestStatuses { get; set; }
    }

    public class FormulaImportRequestListItem
    {
        [Key]
        [Column(Order = 0)]
        [Display(Name = "Request#")]
        public int RequestId { get; set; }
        //public string RequestDescr { get; set; }

        [Display(Name = "Source System")]
        public string SourceSystem { get; set; }

        public string BOMTargetKey { get; set; }

        [Display(Name = "Requested Parts")]
        public string RequestedParts { get; set; }

        [Display(Name = "Request Status")]
        public string RequestStatus { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        //public string LastReportedActivity { get; set; }
        //public DateTime? LastReportedActivityTimestamp { get; set; }
    }

    public class FormulaImportRequestActivity
    {
        [Key]
        [Column(Order = 0)]
        public int ActivityId { get; set; }
        public int RequestId { get; set; }
        public int RequestStatusId { get; set; }
        public string ActivityMsg { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }

    public class BOMRequestQueueItem
    {
        public int RequestQueueId { get; set; }
        public int RequestId { get; set; }
        public string BOMTargetKey { get; set; }
        public int ValidationStatus { get; set; }
        public string MaterialKey { get; set; }
        public string MaterialSource { get; set; }
        public decimal? MaterialPercent { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? CreatedTimestamp { get; set; }

    }

    public class FormulaImportRequestQueueItem
    {
        [Key]
        [Column(Order = 0)]
        public int RequestQueueId { get; set; }
        public int RequestId { get; set; }
        public string Requested_Part { get; set; }
        public string Processed_PartKey { get; set; }        
        public string Processed_PartName { get; set; }
        public bool? IsSDSSpecificBOS { get; set; }
        public DateTime? CreatedTimestamp { get; set; }
        public DateTime? StartTimestamp { get; set; }
        public DateTime? CompleteTimestamp { get; set; }
        public DateTime? ExitTimestamp { get; set; }
        public string LoadStatusMessage { get; set; }

        //start added on 20190814
        public string PartTypeCode { get; set; }
        public string PartTypeName { get; set; }
        public string PartStatusName { get; set; }
        //end added on 20190814

        public int? ValidationStatus { get; set; }

        [Display(Name = "PN Composition Percent")]
        public double? BOSSubCompPercent { get; set; } //Substance Composition Percent: sum(target) for all PNs in the formula
        public List<FormulaImportRequestMessage> RequestQueueItemMessages { get; set; }
        public string UpdatedBy { get; set; }
        public List<SDSBOS> RequestQueueItemBOS { get; set; }
    }
    public class FormulaImportRequestMessage
    {
        [Key, Column(Order = 0)]
        public int RequestQueueId { get; set; }
        [Key, Column(Order = 1)]
        public int RequestId { get; set; }
        [Key, Column(Order = 2)]

        public string SourceSystem { get; set; }
        public string Requested_Part { get; set; }
        public string Processed_PartKey { get; set; }
        public string MessageType { get; set; }
        public string MessageText { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDatestamp { get; set; }
    }

    public class FormulaImportResultReport
    {
        public int RequestId { get; set; }
        public string Requested_Part { get; set; }
        public string Processed_PartKey { get; set; }
        public string Processed_PartName { get; set; }
        public string PartTypeName { get; set; }
        public string PartStatusName { get; set; }
        public string Wercs_Part { get; set; }
        public int LowerPercentValidation { get; set; }
        public int UpperPercentValidation { get; set; }
        public decimal? SourceSystemPercent { get; set; }
        public decimal? WercsStagingPercent { get; set; }
        public int? ValidationStatus { get; set; }
        public string ValidationMessage { get; set; }
        public int? WercsDTEStatus { get; set; }
        public string WercsDTERemarks { get; set; }
    }

    public class BOMIngredient
    {
        public string RMKey { get; set; }
        public decimal RMPercent { get; set; }
        public string RMSource { get; set; }
    }
    public class SDSBOS
    {
        [Key, Column(Order = 0)]
        public int RequestQueueId { get; set; }
        [Key, Column(Order = 1)]
        public int RequestId { get; set; }
        [Key, Column(Order = 2)]

        public string SourceSystem { get; set; }
        public string UpdatedBy { get; set; }
        public string Requested_Part { get; set; }
        public string Processed_PartKey { get; set; }
        public string CompositionTypeName { get; set; }
        //public float AdjLow { get; set; }
        //public float AdjTarget { get; set; }
        //public float AdjHigh { get; set; } 
        public string AdjLow { get; set; }
        public string AdjTarget { get; set; }
        public string AdjHigh { get; set; } 
        public bool? IsDhi { get; set; }
        public int Level { get; set; }
        public string Path { get; set; }
        public string PartKey { get; set; }
        public string PartCasNumber { get; set; }
        public string PartName { get; set; }
        public string PartTypeCode { get; set; }
        public string PartTypeName { get; set; }
        public string PartConfidentialTypeName { get; set; }
        public string PartPlmTypeName { get; set; }
        public string PartPlmPolicyName { get; set; }
        public string PartPlmStateName { get; set; }
        public string PrimaryCASNumber { get; set; }
        public string PrimaryCASRegion { get; set; }
        public DateTime? Datestamp { get; set; }
    }
}