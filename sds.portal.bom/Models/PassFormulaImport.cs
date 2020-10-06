using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Configuration;
using PG.Gps.DepotClient.Model;

namespace SDS.SDSRequest.Models
{
    /*
    public class WercsBOS
    {
        public BillOfSubstance Bos { get; set; }
        public string PartKey { get; set; }
        public string PartKeyRev { get; set; }
        public WercsBOS()
        {
            this.Bos = null;
            this.PartKey = null;
            this.PartKeyRev = null;
        }
    }
    */


/*    
    public class WercsCompositionPart : DepotCompositionPart
    {
        public string PrimaryCASNumber { get; set; }
        public string PrimaryCASRegion { get; set; }

        public WercsCompositionPart (DepotCompositionPart part)
        {
            this.AdjHigh = part.AdjHigh;
            this.AdjLow = part.AdjLow;
            this.AdjTarget = part.AdjTarget;
            this.CompositionTypeName = part.CompositionTypeName;
            //this.IsBom = part.IsBom;
            this.IsDhi = part.IsDhi;
            this.Level = part.Level;
            this.PartCasNumber = part.PartCasNumber;
            this.PartCategoryName = part.PartCategoryName;
            this.PartConfidentialTypeName = part.PartConfidentialTypeName;
            this.PartGbuName = part.PartGbuName;
            this.PartId = part.PartId;
            this.PartIngredientClassName = part.PartIngredientClassName;
            this.PartIsExperimental = part.PartIsExperimental;
            this.PartKey = part.PartKey;
            this.PartName = part.PartName;
            this.PartPlmPolicyName = part.PartPlmPolicyName;
            this.PartPlmStageName = part.PartPlmStageName;
            this.PartPlmStateName = part.PartPlmStateName;
            this.PartPlmTypeName = part.PartPlmTypeName;
            this.PartSectorName = part.PartSectorName;
            this.PartSecurityClassification = part.PartSecurityClassification;
            this.PartSegmentName = part.PartSegmentName;
            this.PartSrcKey = part.PartSrcKey;
            this.PartSrcRevision = part.PartSrcRevision;
            this.PartStatusName = part.PartStatusName;
            this.PartSubCategoryName = part.PartSubCategoryName;
            this.PartSubSectorName = part.PartSubSectorName;
            this.PartTypeCode = part.PartTypeCode;
            this.PartTypeName = part.PartTypeName;
            this.Path = part.Path;
            this.SrcHigh = part.SrcHigh;
            this.SrcLow = part.SrcLow;
            this.SrcTarget = part.SrcTarget;
            this.SrcUom = part.SrcUom;
        }
    }
 */   
    public class DepotOperationResultStatus
    {
        public string StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public string InnerException { get; set; }
        public string SuccessMessage { get; set; }
        public int RequestId { get; set; }
        public string RequestedPart { get; set; }
        public string ProcessedPartKey { get; set; }
        public string PartTypeName { get; set; }
        public int ResultCount { get; set; }
        public bool ErrorReceived { get; set; }
        public bool WarningReceived { get; set; }

        public DepotOperationResultStatus()
        {
        }

        public DepotOperationResultStatus(DepotOperationResultStatus createcopy)
        {
            StatusCode = createcopy.StatusCode;
            ErrorMessage = createcopy.ErrorMessage;
            InnerException = createcopy.InnerException;
            SuccessMessage = createcopy.SuccessMessage;
            RequestId = createcopy.RequestId;
            RequestedPart = createcopy.RequestedPart;
            ProcessedPartKey = createcopy.ProcessedPartKey;
            ResultCount = createcopy.ResultCount;
        }
    }
    public class DepotAccessRecord
    {
        public string DepotUser { get; set; }
        public string DepotPass { get; set; }
        public string DepotUrl { get; set; }
        public int DepotClientTimeoutInMinutes { get; set; }

        public DepotAccessRecord()
        {
            int configTimeout;
            DepotUser = ConfigurationManager.AppSettings["DepotUser"];
            DepotPass = ConfigurationManager.AppSettings["DepotPass"];
            DepotUrl = ConfigurationManager.AppSettings["DepotUrl"];
            if (Int32.TryParse(ConfigurationManager.AppSettings["DepotClientTimeoutInMinutes"], out configTimeout))
                DepotClientTimeoutInMinutes = configTimeout;
            else DepotClientTimeoutInMinutes = 30; //default to 30 minutes
        }
    }



    /*
    public class BaseConstituent
    {
        //[DataMember]
        public string GCAS { get; set; }
        //[DataMember]
        public string ComponentId { get; set; }
        //[DataMember]
        public string CasNo { get; set; }
        //[DataMember]
        public string Name { get; set; }
        //[DataMember]
        public decimal? Min { get; set; }
        //[DataMember]
        public decimal? Target { get; set; }
        //[DataMember]
        public decimal? Exact { get; set; } // Directly from ExESS
        //[DataMember]
        public decimal? Max { get; set; }
        public decimal WercsPercent { get; set; }
        public string WarningMessage { get; set; }
        public bool SkipWercsImport { get; set; }

        public BaseConstituent()
        {
            WarningMessage = "";
        }
    }

    public class Product
    {
        public string ProductKey { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public decimal Formula_PCT { get; set; }
    }

    public class BaseConstituentResult
    {
        public int RequestId { get; set; }
        public List<BaseConstituent> BaseConstituentList { get; set; }
        public List<Product> ProductList { get; set; }
        public PassOperationStatus ReturnStatus { get; set; }
        public int BaseConstituentResultCount { get; set; }
        public string GCASList { get; set; }

        public BaseConstituentResult()
        {
            ReturnStatus = new PassOperationStatus();
            ProductList = new List<Product>();
            BaseConstituentList = new List<BaseConstituent>();
            BaseConstituentResultCount = 0;
            RequestId = 0;
            GCASList = "";
        }
    }
    */
}