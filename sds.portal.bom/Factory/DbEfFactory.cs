using System;
using System.Collections.Generic;
using System.Linq;
//using System.Web;
//using System.Data;
using System.Data.SqlClient;
using SDS.SDSRequest.Models;
using SDS.Portal.Web.Models;
using SDS.SDSRequest.DAL;
using System.Web.Mvc;
using PG.Gps.DepotClient.Model;
using System.Xml;
using System.Text.RegularExpressions;
//using PG.Gps.DepotClient.Model;
using PG.Gps.DepotClient;
using System.Data;
using Newtonsoft.Json;

namespace SDS.SDSRequest.Factory
{
    public class DbEfFactory
    {

        //UserManagerFactory = () => new UserManager<IdentityUser>(new UserStore<IdentityUser>(new MyDbContext()));

        //private static SDSRequestDbContext db = new SDSRequestDbContext();
        //private static WercsDbContext dbwercs = new WercsDbContext();

        private static string GetDepotBOSMessagesXMLString(string requestedGcas, string productKey, List<string> formulaWarnings)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode root = xmldoc.CreateNode(XmlNodeType.Element, "formulaMessage", null);
            xmldoc.AppendChild(root);
            //var attribute;
            foreach (string comp in formulaWarnings)
            {
                XmlElement baseWarning = xmldoc.CreateElement("Message");

                XmlElement requestedGCASElement = xmldoc.CreateElement("Requested_Part");
                XmlText requestedGCASText = xmldoc.CreateTextNode(requestedGcas.Trim());
                requestedGCASElement.AppendChild(requestedGCASText);
                baseWarning.AppendChild(requestedGCASElement);

                XmlElement productKeyElement = xmldoc.CreateElement("Processed_PartKey");
                XmlText productKeyText = xmldoc.CreateTextNode((productKey ?? requestedGcas).Trim());
                
                productKeyElement.AppendChild(productKeyText);
                baseWarning.AppendChild(productKeyElement);

                XmlElement warningElement = xmldoc.CreateElement("MessageText");
                XmlText warningText = xmldoc.CreateTextNode(comp.Trim());
                warningElement.AppendChild(warningText);
                baseWarning.AppendChild(warningElement);

                root.AppendChild(baseWarning);
            }

            string xmlresult = xmldoc.OuterXml; //.Replace("\", ""); //newline in constant error
            return xmlresult.Replace("'", "''");
        }

        private static string GetDepotMultiCASAttributesXMLString(string RequestedGcas, string ProcessedPartKey, List<DepotPartAttribute> partMultiCASAttributes)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode root = xmldoc.CreateNode(XmlNodeType.Element, "FormulaAttributes", null);
            xmldoc.AppendChild(root);
            //var attribute;
            //DepotCompositionPart comp = formulaResult;
            foreach (DepotPartAttribute attr in partMultiCASAttributes)
            {
                XmlElement basecomp = xmldoc.CreateElement("DepotAttribute");

                XmlElement gcasElement = xmldoc.CreateElement("Requested_Part");
                XmlText gcasText = xmldoc.CreateTextNode(RequestedGcas.Trim());
                gcasElement.AppendChild(gcasText);
                basecomp.AppendChild(gcasElement);
                XmlElement productKeyElement = xmldoc.CreateElement("Processed_PartKey");
                XmlText productKeyText = xmldoc.CreateTextNode(ProcessedPartKey.Trim());
                productKeyElement.AppendChild(productKeyText);
                basecomp.AppendChild(productKeyElement);

                // Create Node
                XmlElement CompositionTypeNameElement = xmldoc.CreateElement("PartKey");
                XmlText CompositionTypeNameText = xmldoc.CreateTextNode(attr.PartKey.Trim());
                CompositionTypeNameElement.AppendChild(CompositionTypeNameText);
                basecomp.AppendChild(CompositionTypeNameElement);

                XmlElement TargetAttrKey = xmldoc.CreateElement("AttributeKey");
                XmlText TargetAttrKeyText = xmldoc.CreateTextNode(attr.AttrTypeReportKey?.ToString().Trim());
                TargetAttrKey.AppendChild(TargetAttrKeyText);
                basecomp.AppendChild(TargetAttrKey);

                XmlElement PartAttrValueElement = xmldoc.CreateElement("AttributeValue");
                XmlText PartAttrValueText = xmldoc.CreateTextNode(attr.PartAttrValue?.ToString().Trim());
                PartAttrValueElement.AppendChild(PartAttrValueText);
                basecomp.AppendChild(PartAttrValueElement);

                XmlElement IsSdsElement = xmldoc.CreateElement("RegionName");
                XmlText IsSdsText = xmldoc.CreateTextNode(attr.AttrRegionName?.ToString().Trim());
                IsSdsElement.AppendChild(IsSdsText);
                basecomp.AppendChild(IsSdsElement);

                //string x = attr.
                XmlElement levelElement = xmldoc.CreateElement("AttributeName");
                XmlText levelText = xmldoc.CreateTextNode(attr.AttrTypeName?.ToString().Trim());
                levelElement.AppendChild(levelText);
                basecomp.AppendChild(levelElement);
                root.AppendChild(basecomp);
            }
            if (partMultiCASAttributes.Count() > 0)
            {
                string xmlresult = xmldoc.OuterXml; //.Replace("\", ""); //newline in constant error
                return xmlresult.Replace("'", "''");
            }
            else return "";
        }

        private static string GetDepotCompositionXMLString(string requestedGcas, string productKey, List<DepotCompositionPart> formulaResult)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode root = xmldoc.CreateNode(XmlNodeType.Element, "formulaResult", null);
            xmldoc.AppendChild(root);
            //var attribute;
            //DepotCompositionPart comp = formulaResult;
            foreach (DepotCompositionPart comp in formulaResult)
            {
                XmlElement basecomp = xmldoc.CreateElement("DepotComponent");

                XmlElement gcasElement = xmldoc.CreateElement("Requested_Part");
                XmlText gcasText = xmldoc.CreateTextNode(requestedGcas.Trim());
                gcasElement.AppendChild(gcasText);
                basecomp.AppendChild(gcasElement);

                XmlElement productKeyElement = xmldoc.CreateElement("Processed_PartKey");
                XmlText productKeyText = xmldoc.CreateTextNode(productKey.Trim());
                productKeyElement.AppendChild(productKeyText);
                basecomp.AppendChild(productKeyElement);

                // Create Node
                XmlElement CompositionTypeNameElement = xmldoc.CreateElement("CompositionTypeName");
                XmlText CompositionTypeNameText = xmldoc.CreateTextNode(comp.CompositionTypeName?.ToString().Trim());
                CompositionTypeNameElement.AppendChild(CompositionTypeNameText);
                basecomp.AppendChild(CompositionTypeNameElement);

                XmlElement MinElement = xmldoc.CreateElement("AdjLow");
                XmlText MinText = xmldoc.CreateTextNode(comp.AdjLow?.ToString().Trim());
                MinElement.AppendChild(MinText);
                basecomp.AppendChild(MinElement);

                XmlElement TargetElement = xmldoc.CreateElement("AdjTarget");
                XmlText TargetText = xmldoc.CreateTextNode(comp.AdjTarget?.ToString().Trim());
                TargetElement.AppendChild(TargetText);
                basecomp.AppendChild(TargetElement);

                XmlElement HighElement = xmldoc.CreateElement("AdjHigh");
                XmlText HighText = xmldoc.CreateTextNode(comp.AdjHigh?.ToString().Trim());
                HighElement.AppendChild(HighText);
                basecomp.AppendChild(HighElement);

                XmlElement IsSdsElement = xmldoc.CreateElement("IsDhi");
                XmlText IsSdsText = xmldoc.CreateTextNode(comp.IsDhi?.ToString());
                IsSdsElement.AppendChild(IsSdsText);
                basecomp.AppendChild(IsSdsElement);

                XmlElement levelElement = xmldoc.CreateElement("Level");
                XmlText levelText = xmldoc.CreateTextNode(comp.Level.ToString());
                levelElement.AppendChild(levelText);
                basecomp.AppendChild(levelElement);

                XmlElement PathElement = xmldoc.CreateElement("Path");
                XmlText PathText = xmldoc.CreateTextNode(comp.Path?.ToString().Trim());
                PathElement.AppendChild(PathText);
                basecomp.AppendChild(PathElement);

                // componentId Node
                XmlElement PartKeyElement = xmldoc.CreateElement("PartKey");
                XmlText PartKeyText = xmldoc.CreateTextNode(comp.ChildPart?.PartKey?.Trim()); //comp.PartKey >> comp.ChildPart?.PartKey
                PartKeyElement.AppendChild(PartKeyText);
                basecomp.AppendChild(PartKeyElement);

                // Create Node
                XmlElement PartCasNumberElement = xmldoc.CreateElement("PartCasNumber");
                XmlText PartCasNumberText = xmldoc.CreateTextNode(comp.ChildPart?.PartCasNumber?.Trim()); //comp.PartCasNumber >> comp.ChildPart?.PartCasNumber
                PartCasNumberElement.AppendChild(PartCasNumberText);
                basecomp.AppendChild(PartCasNumberElement);

                ///////////////////////////
                /*
                XmlElement PrimaryCASNumberElement = xmldoc.CreateElement("PrimaryCASNumber");
                XmlText PrimaryCASNumberText = xmldoc.CreateTextNode(comp.PrimaryCASNumber?.Trim());
                PrimaryCASNumberElement.AppendChild(PrimaryCASNumberText);
                basecomp.AppendChild(PrimaryCASNumberElement);

                XmlElement PrimaryCASRegionElement = xmldoc.CreateElement("PrimaryCASRegion");
                XmlText PrimaryCASRegionText = xmldoc.CreateTextNode(comp.PrimaryCASRegion?.Trim());
                PrimaryCASRegionElement.AppendChild(PrimaryCASRegionText);
                basecomp.AppendChild(PrimaryCASRegionElement);
                */
                //////////////

                // ChemName Node
                XmlElement PartNameElement = xmldoc.CreateElement("PartName");
                XmlText PartNameText = xmldoc.CreateTextNode(comp.ChildPart?.PartName?.Trim()); //comp.PartName >> comp.ChildPart?.PartName
                PartNameElement.AppendChild(PartNameText);
                basecomp.AppendChild(PartNameElement);

                XmlElement PartTypeCodeElement = xmldoc.CreateElement("PartTypeCode");
                XmlText PartTypeCodeText = xmldoc.CreateTextNode(comp.ChildPart?.PartTypeCode?.Trim()); //comp.PartTypeCode >> comp.ChildPart?.PartTypeCode
                PartTypeCodeElement.AppendChild(PartTypeCodeText);
                basecomp.AppendChild(PartTypeCodeElement);

                XmlElement PartTypeNameElement = xmldoc.CreateElement("PartTypeName");
                XmlText PartTypeNameText = xmldoc.CreateTextNode(comp.ChildPart?.PartTypeName?.Trim());  //comp.PartTypeName >> comp.ChildPart?.PartTypeName
                PartTypeNameElement.AppendChild(PartTypeNameText);
                basecomp.AppendChild(PartTypeNameElement);

                XmlElement PartConfidentialTypeNameElement = xmldoc.CreateElement("PartConfidentialTypeName");
                XmlText PartConfidentialTypeNameText = xmldoc.CreateTextNode(comp.ChildPart?.PartConfidentialTypeName?.Trim());  //comp.PartConfidentialTypeName >> comp.ChildPart?.PartConfidentialTypeName
                PartConfidentialTypeNameElement.AppendChild(PartConfidentialTypeNameText);
                basecomp.AppendChild(PartConfidentialTypeNameElement);

                XmlElement PartPlmTypeNameElement = xmldoc.CreateElement("PartPlmTypeName");
                XmlText PartPlmTypeNameText = xmldoc.CreateTextNode(comp.ChildPart?.PartPlmTypeName?.Trim());  //comp.PartPlmTypeName >> comp.ChildPart?.PartPlmTypeName
                PartPlmTypeNameElement.AppendChild(PartPlmTypeNameText);
                basecomp.AppendChild(PartPlmTypeNameElement);

                XmlElement PartPlmPolicyNameElement = xmldoc.CreateElement("PartPlmPolicyName");
                XmlText PartPlmPolicyNameText = xmldoc.CreateTextNode(comp.ChildPart?.PartPlmPolicyName?.Trim());  //comp.PartPlmPolicyName >> comp.ChildPart?.PartPlmPolicyName
                PartPlmPolicyNameElement.AppendChild(PartPlmPolicyNameText);
                basecomp.AppendChild(PartPlmPolicyNameElement);

                XmlElement PartPlmStateNameElement = xmldoc.CreateElement("PartPlmStateName");
                XmlText PartPlmStateNameText = xmldoc.CreateTextNode(comp.ChildPart?.PartPlmStateName?.Trim()); //comp.PartPlmStateName >> comp.ChildPart?.PartPlmStateName
                PartPlmStateNameElement.AppendChild(PartPlmStateNameText);
                basecomp.AppendChild(PartPlmStateNameElement);

                root.AppendChild(basecomp);
            }

            string xmlresult = xmldoc.OuterXml; //.Replace("\", ""); //newline in constant error
            return xmlresult.Replace("'", "''");
        }

        public static int AddRequest(Request sdsrequest)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();

            SqlParameter newRequestId = new SqlParameter("@requestId", System.Data.SqlDbType.Int);
            newRequestId.Direction = System.Data.ParameterDirection.Output;

            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(
                        @"EXEC usp_SDSREQ_AddRequest @BUId, @CreatedBy, @DueDate, @LastUpdatedBy,
                            @ProductTypeId, @RequestRegionIds, @TypeId, @RequestCountries, 
                            @RequesterFirstName, @RequesterLastName, @RequesterEmail, 
                            @TechnicalContactFistName, @TechnicalContactLastName, @TechnicalContactEmail,
                            @RequestLanguages, @ProductPhysicalStateId, @IsContractManufacturerFormula, @IsCompletedSDSTraining,
                            @requestId output",
                        new SqlParameter("@BUId", sdsrequest.BUId),
                        new SqlParameter("@CreatedBy", sdsrequest.CreatedBy),
                        new SqlParameter("@DueDate", (object)sdsrequest.DueDate ?? DBNull.Value),
                        //new SqlParameter("@RequestProducts", sdsrequest.RequestProducts),
                        new SqlParameter("@LastUpdatedBy", sdsrequest.CreatedBy),
                        //new SqlParameter("@ProductGcas", sdsrequest.ProductGcas),
                        new SqlParameter("@ProductTypeId", sdsrequest.ProductTypeId),
                        new SqlParameter("@RequestRegionIds", sdsrequest.RequestRegionIds),
                        //new SqlParameter("@RequestOwnerId", sdsrequest.RequestOwnerId),
                        new SqlParameter("@TypeId", sdsrequest.RequestTypeId),
                        new SqlParameter("@RequestCountries", sdsrequest.RequestCountries),
                        new SqlParameter("@RequesterFirstName", (object)sdsrequest.RequesterFirstName ?? DBNull.Value),
                        new SqlParameter("@RequesterLastName", (object)sdsrequest.RequesterLastName ?? DBNull.Value),
                        new SqlParameter("@RequesterEmail", (object)sdsrequest.RequesterEmail ?? DBNull.Value),
                        new SqlParameter("@TechnicalContactFistName", (object)sdsrequest.TechnicalContactFirstName ?? DBNull.Value),
                        new SqlParameter("@TechnicalContactLastName", (object)sdsrequest.TechnicalContactLastName ?? DBNull.Value),
                        new SqlParameter("@TechnicalContactEmail", (object)sdsrequest.TechnicalContactEmail ?? DBNull.Value),
                        new SqlParameter("@RequestLanguages", (object)sdsrequest.RequestLanguages ?? DBNull.Value),
                        new SqlParameter("@ProductPhysicalStateId", (object)sdsrequest.ProductPhysicalStateId ?? DBNull.Value),
                        new SqlParameter("@IsContractManufacturerFormula", (object)sdsrequest.IsContractManufacturerFormula ?? DBNull.Value),
                        new SqlParameter("@IsCompletedSDSTraining", (object)sdsrequest.IsCompletedSDSTraining ?? DBNull.Value),
                        newRequestId
                    );
            }
            return Convert.ToInt32(newRequestId.Value);

        }

        public static void UpdateRequest(Request sdsrequest)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(
                        @"EXEC usp_SDSREQ_UpdateRequest @RequestId, @BUId, @DueDate, @LastUpdatedBy,
                            @ProductTypeId, @RequestRegionIds, @TypeId, @RequestCountries, 
                            @RequesterFirstName, @RequesterLastName, @RequesterEmail, 
                            @TechnicalContactFistName, @TechnicalContactLastName, @TechnicalContactEmail,
                            @RequestLanguages, @ProductPhysicalStateId, @IsContractManufacturerFormula, @IsCompletedSDSTraining",
                        new SqlParameter("@RequestId", sdsrequest.RequestId),
                        new SqlParameter("@BUId", sdsrequest.BUId),
                        //new SqlParameter("@CreatedBy", sdsrequest.CreatedBy),
                        new SqlParameter("@DueDate", (object)sdsrequest.DueDate ?? DBNull.Value),
                        new SqlParameter("@LastUpdatedBy", sdsrequest.LastUpdatedBy),
                        new SqlParameter("@ProductTypeId", sdsrequest.ProductTypeId),
                        new SqlParameter("@RequestRegionIds", sdsrequest.RequestRegionIds),
                        new SqlParameter("@TypeId", sdsrequest.RequestTypeId),
                        new SqlParameter("@RequestCountries", sdsrequest.RequestCountries),
                        new SqlParameter("@RequesterFirstName", sdsrequest.RequesterFirstName),
                        new SqlParameter("@RequesterLastName", sdsrequest.RequesterLastName),
                        new SqlParameter("@RequesterEmail", sdsrequest.RequesterEmail),
                        new SqlParameter("@TechnicalContactFistName", sdsrequest.TechnicalContactFirstName),
                        new SqlParameter("@TechnicalContactLastName", sdsrequest.TechnicalContactLastName),
                        new SqlParameter("@TechnicalContactEmail", sdsrequest.TechnicalContactEmail),
                        new SqlParameter("@RequestLanguages", (object)sdsrequest.RequestLanguages ?? DBNull.Value),
                        new SqlParameter("@ProductPhysicalStateId", (object)sdsrequest.ProductPhysicalStateId ?? DBNull.Value),
                        new SqlParameter("@IsContractManufacturerFormula", (object)sdsrequest.IsContractManufacturerFormula ?? DBNull.Value),
                        new SqlParameter("@IsCompletedSDSTraining", (object)sdsrequest.IsCompletedSDSTraining ?? DBNull.Value)
            );
            }
        }



        public static List<RequestListItem> GetRequestsList(string requestTypeId)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestTypeIdParam = new SqlParameter { ParameterName = "requestTypeId", Value = requestTypeId };
            //requests = await db.Database.SqlQuery<RequestListItem>("exec usp_SDSREQ_GetRequests @requestTypeId ", requestTypeIdParam).ToList<RequestListItem>();
            //return View(requests);
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<RequestListItem>("exec usp_SDSREQ_GetRequestsList @requestTypeId ", requestTypeIdParam).ToList<RequestListItem>();
            }
        }


        public static List<FormulaImportRequestListItem> GetFormulaImportRequestsList(Enum ft)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            int formulaImportRequestType = Convert.ToInt32(ft); // ft.GetTypeCode(); //Enum.GetValues(ft.GetType());
            //int formulaImportRequest = Convert.ToInt32(ft);

            SqlParameter formulaImportRequestTypeParam = new SqlParameter { ParameterName = "@formulaImportRequestType", Value = int.Parse(formulaImportRequestType.ToString()) };

            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<FormulaImportRequestListItem>("exec usp_FORMULAREQ_GetFormulaImportRequestsListByType @formulaImportRequestType ", formulaImportRequestTypeParam).ToList<FormulaImportRequestListItem>();
            }
        }

        public static List<FormulaImportRequestQueueItem> GetFormulaImportRequestQueue(int requestId, string sourceSystem)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestIdParam = new SqlParameter { ParameterName = "@requestId", Value = requestId };
            SqlParameter sourceSystemIdParam = new SqlParameter { ParameterName = "@sourceSystem", Value = sourceSystem };
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<FormulaImportRequestQueueItem>("exec usp_FORMULAREQ_GetFormulaImportRequestQueue @requestId, @sourceSystem ", requestIdParam, sourceSystemIdParam).ToList<FormulaImportRequestQueueItem>();
            }
        }

        public static List<BOMRequestQueueItem> GetBOMRequestQueue(int requestId, string sourceSystem)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestIdParam = new SqlParameter { ParameterName = "@requestId", Value = requestId };
            SqlParameter sourceSystemIdParam = new SqlParameter { ParameterName = "@sourceSystem", Value = sourceSystem };
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<BOMRequestQueueItem>("exec usp_FORMULAREQ_FormulaImportRequest_BOMRequest_GetQueue @requestId, @sourceSystem ", requestIdParam, sourceSystemIdParam).ToList<BOMRequestQueueItem>();
            }
        }

        private static DataTable CastFormulaImportRequestQueueToTable(List<FormulaImportResultReport> rq)
        {
            DataTable dt = new DataTable("RequestQueueItems");

            dt.Columns.AddRange(new DataColumn[14] { new DataColumn("RequestId"),
                                            new DataColumn("Requested_Part"),
                                            new DataColumn("Processed_PartKey"),
                                            new DataColumn("PartTypeName"),
                                            new DataColumn("PartStatusName"),
                                            new DataColumn("WERCS_Part"),
                                            new DataColumn("LowerPercentValidation"),
                                            new DataColumn("UpperPercentValidation"),
                                            new DataColumn("SourceSystemPercent"),
                                            new DataColumn("WercsStagingPercent"),
                                            new DataColumn("ValidationStatus"),
                                            new DataColumn("ValidationMessage"),
                                            new DataColumn("WercsDTEStatus"),
                                            new DataColumn("WercsDTERemarks")
                                                });

            foreach (FormulaImportResultReport row in rq)
            {
                dt.Rows.Add(row.RequestId, row.Requested_Part, row.Processed_PartKey
                    , row.PartTypeName, row.PartStatusName, row.Wercs_Part
                    , row.LowerPercentValidation, row.UpperPercentValidation
                    , row.SourceSystemPercent, row.WercsStagingPercent
                    , row.ValidationStatus, row.ValidationMessage
                    , row.WercsDTEStatus, row.WercsDTERemarks);

            }
            return dt;
        }

        public static DataTable GetFormulaImportResultReport(int requestId, string sourceSystem)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestIdParam = new SqlParameter { ParameterName = "@requestId", Value = requestId, DbType = DbType.Int32 };
            SqlParameter sourceSystemIdParam = new SqlParameter { ParameterName = "@sourceSystem", Value = sourceSystem };

            using (WercsDbContext dbwercs = new WercsDbContext())
            {
                List<FormulaImportResultReport> col = dbwercs.Database.SqlQuery<FormulaImportResultReport>("exec Xusp_FORMULAREQ_GetDepotRequestReport @RequestId, @SourceSystem ", requestIdParam, sourceSystemIdParam).ToList<FormulaImportResultReport>();
                return CastFormulaImportRequestQueueToTable(col);
            }
        }

        public static List<FormulaImportRequestActivity> GetFormulaImportRequestActivities(int requestQueueId)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestIdParam = new SqlParameter { ParameterName = "@requestQueueId", Value = requestQueueId };
            //requests = await db.Database.SqlQuery<RequestListItem>("exec usp_SDSREQ_GetRequests @requestTypeId ", requestTypeIdParam).ToList<RequestListItem>();
            //return View(requests);
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<FormulaImportRequestActivity>("exec usp_FORMULAREQ_GetFormulaImportRequestActivities @requestQueueId ", requestIdParam).ToList<FormulaImportRequestActivity>();
            }
        }

        public static List<SDSBOS> GetRequestQueueItemBOS(int requestQueueId)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestQueueIdParam = new SqlParameter { ParameterName = "@requestQueueId", Value = requestQueueId };
            //requests = await db.Database.SqlQuery<RequestListItem>("exec usp_SDSREQ_GetRequests @requestTypeId ", requestTypeIdParam).ToList<RequestListItem>();
            //return View(requests);
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<SDSBOS>("exec usp_FORMULAREQ_GetFormulaImportRequestQueueItemBOS @requestQueueId ", requestQueueIdParam).ToList<SDSBOS>();
            }
            }

        public static List<FormulaImportRequestQueueItem> GetFormulaImportRequestQueueByProductList(string ProductKeyList, string sourceSystem)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestQueueIdSearchParam = new SqlParameter { ParameterName = "@requestQueueSearchList", Value = ProductKeyList };
            SqlParameter requestSourceSystem = new SqlParameter { ParameterName = "@sourceSystem", Value = sourceSystem };
            //requests = await db.Database.SqlQuery<RequestListItem>("exec usp_SDSREQ_GetRequests @requestTypeId ", requestTypeIdParam).ToList<RequestListItem>();
            //return View(requests);
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<FormulaImportRequestQueueItem>("exec usp_FORMULAREQ_GetFormulaImportRequestQueueSearch @requestQueueSearchList, @sourceSystem ", requestQueueIdSearchParam, requestSourceSystem).ToList<FormulaImportRequestQueueItem>();
            }
        }

        public static List<FormulaImportRequestMessage> GetRequestQueueItemMessages(int requestQueueId)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestQueueIdParam = new SqlParameter { ParameterName = "@requestQueueId", Value = requestQueueId };

            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<FormulaImportRequestMessage>("exec usp_FORMULAREQ_GetFormulaImportRequestItemMessages @requestQueueId ", requestQueueIdParam).ToList<FormulaImportRequestMessage>();
            }
        }

        public static List<AttributeValuePair> GetPAttributeValuePairs(string attributeName)
        {
            /*
             * IMFG:    Product/SDS Type
             * BU:      Business unit
             * PYST:    Product Physical State
            */
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter ptxt_attribute = new SqlParameter { ParameterName = "@ptxt_attribute", Value = attributeName };
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<AttributeValuePair>("exec usp_SDSREQ_GetPAttributeValuePairs @ptxt_attribute", ptxt_attribute).ToList<AttributeValuePair>();
                //return db.Database.SqlQuery<ProductType>("exec usp_SDSREQ_GetPAttributeValuePairs @ptxt_attribute", ptxt_attribute).ToList<ProductType>();
            }
            }

        public static List<RequestActivityListItem> GetRequestActivities(int requestId)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestIdParam = new SqlParameter { ParameterName = "requestId", Value = requestId };
            //requests = await db.Database.SqlQuery<RequestListItem>("exec usp_SDSREQ_GetRequests @requestTypeId ", requestTypeIdParam).ToList<RequestListItem>();
            //return View(requests);
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                return db.Database.SqlQuery<RequestActivityListItem>("exec usp_SDSREQ_GetRequestActivities @requestId ", requestIdParam).ToList<RequestActivityListItem>();
            }
        }


        public static Request GetRequest(int requestId)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            SqlParameter requestIdParam = new SqlParameter { ParameterName = "requestId", Value = requestId };
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                var sdsrequests = db.Database.SqlQuery<Request>("exec usp_SDSREQ_GetRequest @requestId ", requestIdParam); //.ToList<RequestListItem>());
                return sdsrequests.Single();
            }
        }

        public static void SubmitRequest(int requestId, string userName)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(
                @"EXEC usp_SDSREQ_SubmitRequest @RequestId, @UpdatedBy",
                new SqlParameter("@RequestId", requestId),
                new SqlParameter("@UpdatedBy", userName)
                );
            }
        }

        public static void AddRequestActivity(RequestActivity requestactivity)
        {
            //SqlParameter newRequestId = new SqlParameter("@requestId", System.Data.SqlDbType.Int);
            //newRequestId.Direction = System.Data.ParameterDirection.Output;

            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(
                        @"EXEC usp_SDSREQ_AddRequestActivity @RequestId, @RequestStatusId,
                            @RequestOwnerId, @ActivityComment, @UpdatedBy",
                        new SqlParameter("@RequestId", requestactivity.RequestId),
                        new SqlParameter("@RequestStatusId", requestactivity.RequestStatusId),
                        new SqlParameter("@RequestOwnerId", requestactivity.RequestOwnerId),
                        new SqlParameter("@ActivityComment", requestactivity.ActivityComment),
                        new SqlParameter("@UpdatedBy", requestactivity.UpdatedBy)
                    );
            }
        }

        private static string GetRequestProductsXML(string requestedProducts, Dictionary<string, DepotPart> depotResults)
        {
            string[] requestedProductsArr;
            string prodKeysCommaDelimited = Regex.Replace(requestedProducts, @"\r\n?|\n", ",");
            requestedProductsArr = prodKeysCommaDelimited.Replace(" ", "").Split(','); //allow only one or no spaces between commas


            XmlDocument xmldoc = new XmlDocument();
            XmlNode root = xmldoc.CreateNode(XmlNodeType.Element, "RequestProducts", null);
            xmldoc.AppendChild(root);

            foreach (string key in requestedProductsArr)
            {
                XmlElement product = xmldoc.CreateElement("DepotPart");
                XmlElement gcasElement = xmldoc.CreateElement("Requested_Part");
                XmlText gcasText = xmldoc.CreateTextNode(key.Trim());
                gcasElement.AppendChild(gcasText);
                product.AppendChild(gcasElement);


                XmlElement processedPartKeyElement = xmldoc.CreateElement("Processed_PartKey");
                XmlText processedPartKeyText;

                XmlElement processedPartNameElement = xmldoc.CreateElement("Processed_PartName");
                XmlText processedPartNameText;

                XmlElement partTypeCodeElement = xmldoc.CreateElement("PartTypeCode");
                XmlText partTypeCodeText;

                XmlElement partTypeNameElement = xmldoc.CreateElement("PartTypeName");
                XmlText partTypeNameText;

                XmlElement partStatusNameElement = xmldoc.CreateElement("PartStatusName");
                XmlText partStatusNameText;

                if (depotResults.ContainsKey(key))
                {
                    processedPartKeyText = xmldoc.CreateTextNode(depotResults[key].PartKey?.Trim());
                    processedPartNameText = xmldoc.CreateTextNode(depotResults[key].PartName?.Trim());

                    //20190813
                    partTypeCodeText = xmldoc.CreateTextNode(depotResults[key].PartTypeCode?.Trim());
                    partTypeNameText = xmldoc.CreateTextNode(depotResults[key].PartTypeName?.Trim());
                    partStatusNameText = xmldoc.CreateTextNode(depotResults[key].PartStatusName?.Trim());

                    /*
                    string PartTypeCode = depotResults[key].PartTypeCode;
                    string PartTypeName = depotResults[key].PartTypeName;
                    string PartStatusName = depotResults[key].PartStatusName;
                    //string PartPrimaryOrganizationName = depotResults[key].PartPrimaryOrganizationName;
                    //string PartGbuName = depotResults[key].PartGbuName;
                    //string PartPlmStateName = depotResults[key].PartPlmStateName;
                    */
                }
                else
                {
                    processedPartKeyText = xmldoc.CreateTextNode("");
                    processedPartNameText = xmldoc.CreateTextNode("");

                    partTypeCodeText = xmldoc.CreateTextNode("");
                    partTypeNameText = xmldoc.CreateTextNode("");
                    partStatusNameText = xmldoc.CreateTextNode("");
                }
                processedPartKeyElement.AppendChild(processedPartKeyText);
                product.AppendChild(processedPartKeyElement);

                processedPartNameElement.AppendChild(processedPartNameText);
                product.AppendChild(processedPartNameElement);

                //
                partTypeCodeElement.AppendChild(partTypeCodeText);
                product.AppendChild(partTypeCodeElement);

                partTypeNameElement.AppendChild(partTypeNameText);
                product.AppendChild(partTypeNameElement);

                partStatusNameElement.AppendChild(partStatusNameText);
                product.AppendChild(partStatusNameElement);


                root.AppendChild(product);
            }
            string xmlresult = xmldoc.OuterXml; //.Replace("\", ""); //newline in constant error
            return xmlresult.Replace("'", "''");
        }

        private static string GetRequestBOMProductsXML(string targetKey, List<BOMIngredient> bomRequestIngredients)
        //, Dictionary<string, DepotPart> depotResults
        {
            //string[] requestedProductsArr;
            //string prodKeysCommaDelimited = Regex.Replace(requestedProducts, @"\r\n?|\n", ",");
            //requestedProductsArr = prodKeysCommaDelimited.Replace(" ", "").Split(','); //allow only one or no spaces between commas


            XmlDocument xmldoc = new XmlDocument();
            XmlNode root = xmldoc.CreateNode(XmlNodeType.Element, "RequestProducts", null);
            xmldoc.AppendChild(root);

            foreach (BOMIngredient key in bomRequestIngredients)
            {
                XmlElement product = xmldoc.CreateElement("BOMPart");
                XmlElement gcasElement = xmldoc.CreateElement("BOMTargetKey");
                XmlText gcasText = xmldoc.CreateTextNode(targetKey.Trim());
                gcasElement.AppendChild(gcasText);
                product.AppendChild(gcasElement);


                XmlElement rmSourceElement = xmldoc.CreateElement("RMSource");
                XmlText rmSourceText = xmldoc.CreateTextNode(key.RMSource.Trim());
                rmSourceElement.AppendChild(rmSourceText);
                product.AppendChild(rmSourceElement);

                XmlElement rmKeyElement = xmldoc.CreateElement("RMKey");
                XmlText rmKeyText = xmldoc.CreateTextNode(key.RMKey.Trim());
                rmKeyElement.AppendChild(rmKeyText);
                product.AppendChild(rmKeyElement);

                XmlElement rmPercentElement = xmldoc.CreateElement("RMPercent");
                XmlText rmPercentText = xmldoc.CreateTextNode(key.RMPercent.ToString().Trim());
                rmPercentElement.AppendChild(rmPercentText);
                product.AppendChild(rmPercentElement);

                XmlElement processedPartKeyElement = xmldoc.CreateElement("Processed_PartKey");
                XmlText processedPartKeyText;

                XmlElement processedPartNameElement = xmldoc.CreateElement("Processed_PartName");
                XmlText processedPartNameText;

                XmlElement partTypeCodeElement = xmldoc.CreateElement("PartTypeCode");
                XmlText partTypeCodeText;

                XmlElement partTypeNameElement = xmldoc.CreateElement("PartTypeName");
                XmlText partTypeNameText;

                XmlElement partStatusNameElement = xmldoc.CreateElement("PartStatusName");
                XmlText partStatusNameText;

                /*
                if (depotResults.ContainsKey(key.RMKey))
                {
                    processedPartKeyText = xmldoc.CreateTextNode(depotResults[key.RMKey].PartKey?.Trim());
                    processedPartNameText = xmldoc.CreateTextNode(depotResults[key.RMKey].PartName?.Trim());

                    partTypeCodeText = xmldoc.CreateTextNode(depotResults[key.RMKey].PartTypeCode?.Trim());
                    partTypeNameText = xmldoc.CreateTextNode(depotResults[key.RMKey].PartTypeName?.Trim());
                    partStatusNameText = xmldoc.CreateTextNode(depotResults[key.RMKey].PartStatusName?.Trim());

                }
                else
                {
                    processedPartKeyText = xmldoc.CreateTextNode("");
                    processedPartNameText = xmldoc.CreateTextNode("");

                    partTypeCodeText = xmldoc.CreateTextNode("");
                    partTypeNameText = xmldoc.CreateTextNode("");
                    partStatusNameText = xmldoc.CreateTextNode("");
                }
                */
                processedPartKeyText = xmldoc.CreateTextNode("");
                processedPartNameText = xmldoc.CreateTextNode("");

                partTypeCodeText = xmldoc.CreateTextNode("");
                partTypeNameText = xmldoc.CreateTextNode("");
                partStatusNameText = xmldoc.CreateTextNode("");

                processedPartKeyElement.AppendChild(processedPartKeyText);
                product.AppendChild(processedPartKeyElement);

                processedPartNameElement.AppendChild(processedPartNameText);
                product.AppendChild(processedPartNameElement);

                //
                partTypeCodeElement.AppendChild(partTypeCodeText);
                product.AppendChild(partTypeCodeElement);

                partTypeNameElement.AppendChild(partTypeNameText);
                product.AppendChild(partTypeNameElement);

                partStatusNameElement.AppendChild(partStatusNameText);
                product.AppendChild(partStatusNameElement);


                root.AppendChild(product);
            }
            string xmlresult = xmldoc.OuterXml; //.Replace("\", ""); //newline in constant error
            return xmlresult.Replace("'", "''");
        }


        public static DepotOperationResultStatus AddDepotBOMRequest(string targetKey, List<BOMIngredient> bomRequestIngredients, int rmFormulaLowerLimitValidation, int rmFormulaUpperLimitValidation, string requestDescr, string updatedBy, string RequestSourceSystem)
        //sourceSystem, targetFormulaKey, List<BOMIngredient> bomIngredients, rmFormulaLowerLimitValidation, rmFormulaUpperLimitValidation, bestparts, "Depot", "BOM Request", UpdatedBy
        {
            DepotOperationResultStatus ret = new DepotOperationResultStatus();

            //gcasList.Replace("\r\n", ",");
            //string gcasListReady = Regex.Replace(gcasList, @"\r\n?|\n", ",");

            //string fpcOverrideFlag = null; //y/n
            int requestStatusId = 0;
            string requestType = "BOM Request";
            SqlParameter newRequestId = new SqlParameter("@requestId", System.Data.SqlDbType.Int);
            newRequestId.Direction = System.Data.ParameterDirection.Output;

            string BOMProductsXML = GetRequestBOMProductsXML(targetKey, bomRequestIngredients);
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();

            //List<BOMIngredient> depotParts = bomRequestIngredients.ToString((p => p.RMKey).ToList<BOMIngredient>();
            //List<BOMIngredient> depotParts = bomIngredients.Where(p => p.RMSource.ToLower().Contains("depot")).ToList<BOMIngredient>();

            string request_data = targetKey + " :: " + JsonConvert.SerializeObject(bomRequestIngredients).ToString().Replace("\"", "");
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {

                db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_FormulaImportRequest_BOMRequest_Add @RequestDescr, @RequestType, @TargetKey, @BOMKeyList, @LowerPercentValidation, @UpperPercentValidation, @BOMProductsXML, @RequestStatusId, @UpdatedBy, @SourceSystem, @requestId output",
                new SqlParameter("@RequestDescr", (object)requestDescr ?? DBNull.Value),
                new SqlParameter("@RequestType", requestType),
                new SqlParameter("@TargetKey", targetKey),
                new SqlParameter("@BOMKeyList", request_data),
                new SqlParameter("@LowerPercentValidation", rmFormulaLowerLimitValidation),
                new SqlParameter("@UpperPercentValidation", rmFormulaUpperLimitValidation),
                new SqlParameter("@BOMProductsXML", BOMProductsXML),
                new SqlParameter("@RequestStatusId", requestStatusId),
                new SqlParameter("@UpdatedBy", updatedBy),
                new SqlParameter("@SourceSystem", (object)RequestSourceSystem ?? DBNull.Value),
                //new SqlParameter("@FPCOverride", (object)fpcOverrideFlag ?? DBNull.Value),
                newRequestId
            );
                ret.RequestId = Convert.ToInt32(newRequestId.Value);
                ret.SuccessMessage = "BOM request saved successfully.";
                return ret;
            }
            // use requestDescr as RequestType to identify requests as BOM or Formula??  
        }

        public static DepotOperationResultStatus AddDepotFormulaRequest(string requestedProducts, int formulaLowerPercentValidation, int formulaUpperPercentValidation, Dictionary<string, DepotPart> depotResults, string source, string requestDescr, string updatedBy)
        {
            DepotOperationResultStatus ret = new DepotOperationResultStatus();

            //gcasList.Replace("\r\n", ",");
            //string gcasListReady = Regex.Replace(gcasList, @"\r\n?|\n", ",");

            string fpcOverrideFlag = null; //y/n
            int requestStatusId = 0;
            SqlParameter newRequestId = new SqlParameter("@requestId", System.Data.SqlDbType.Int);
            newRequestId.Direction = System.Data.ParameterDirection.Output;

            string RequestProductsXML = GetRequestProductsXML(requestedProducts, depotResults);
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_FormulaImportRequest_Add @RequestDescr, @GCASCodeList, @LowerPercentValidation, @UpperPercentValidation, @RequestProductsXML, @RequestStatusId, @UpdatedBy, @SourceSystem, @FPCOverride, @requestId output",
                new SqlParameter("@RequestDescr", (object)requestDescr ?? DBNull.Value),
                new SqlParameter("@GCASCodeList", requestedProducts),
                new SqlParameter("@LowerPercentValidation", formulaLowerPercentValidation),
                new SqlParameter("@UpperPercentValidation", formulaUpperPercentValidation),
                new SqlParameter("@RequestProductsXML", RequestProductsXML),
                new SqlParameter("@RequestStatusId", requestStatusId),
                new SqlParameter("@UpdatedBy", updatedBy),
                new SqlParameter("@SourceSystem", source),
                new SqlParameter("@FPCOverride", (object)fpcOverrideFlag ?? DBNull.Value),
                newRequestId
                );
                ret.RequestId = Convert.ToInt32(newRequestId.Value);
                return ret;
            }
        }

        public static DepotOperationResultStatus UpdateBOMRequestDepotFormula(string requestedProducts, int formulaLowerPercentValidation, int formulaUpperPercentValidation, Dictionary<string, DepotPart> depotResults, string source, int BOMRequestId, string BOMRequestTargetKey, string updatedBy)
        {
            DepotOperationResultStatus ret = new DepotOperationResultStatus();

            //gcasList.Replace("\r\n", ",");
            //string gcasListReady = Regex.Replace(gcasList, @"\r\n?|\n", ",");

            string fpcOverrideFlag = null; //y/n
            int requestStatusId = 0;

            string RequestProductsXML = GetRequestProductsXML(requestedProducts, depotResults);
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_FormulaImportRequest_BOMRequestUpdate @GCASCodeList, @LowerPercentValidation, @UpperPercentValidation, @RequestProductsXML, @RequestStatusId, @SourceSystem, @FPCOverride, @BOMRequestId, @BOMRequestTargetKey, @UpdatedBy",
                new SqlParameter("@GCASCodeList", requestedProducts),
                new SqlParameter("@LowerPercentValidation", formulaLowerPercentValidation),
                new SqlParameter("@UpperPercentValidation", formulaUpperPercentValidation),
                new SqlParameter("@RequestProductsXML", RequestProductsXML),
                new SqlParameter("@RequestStatusId", requestStatusId),
                new SqlParameter("@SourceSystem", source),
                new SqlParameter("@FPCOverride", (object)fpcOverrideFlag ?? DBNull.Value),
                new SqlParameter("@BOMRequestId", BOMRequestId),
                new SqlParameter("@BOMRequestTargetKey", (object)BOMRequestTargetKey ?? DBNull.Value),
                new SqlParameter("@UpdatedBy", updatedBy)


                );
                ret.RequestId = BOMRequestId;
                return ret;
            }
        }

        public static DepotOperationResultStatus DeleteDepotFormulaRequest(int requestId, string SourceSystem)
        {
            DepotOperationResultStatus ret = new DepotOperationResultStatus();
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();

            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_FormulaImportRequest_Delete @RequestId, @SourceSystem",
                        new SqlParameter("@requestId", requestId),
                        new SqlParameter("@SourceSystem", SourceSystem)
            );
            }
            return ret;
        }

        public static DepotOperationResultStatus StageBOMRequest(int requestId, string TargetPart, string SourceSystem)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            DepotOperationResultStatus ret = new DepotOperationResultStatus();

            using (WercsDbContext dbwercs = new WercsDbContext())
            {
                dbwercs.Database.CommandTimeout = 3000;
                dbwercs.Database.ExecuteSqlCommand(@"EXEC Xusp_FORMULAREQ_BOMRequest_Process @RequestId,  @TargetPart, @SourceSystem, @populateWercsStaging ",
                            new SqlParameter("@RequestId", requestId),
                            new SqlParameter("@TargetPart", TargetPart),
                            new SqlParameter("@SourceSystem", SourceSystem),
                            new SqlParameter("@populateWercsStaging", 1)

                //,new SqlParameter("@populateWercsStaging", 1)
                );
                ret.RequestId = requestId;
                ret.SuccessMessage = "Saved BOM Request details.";
                return ret;
            }
        }

        public static void StartDTE()
        {
            DepotOperationResultStatus ret = new DepotOperationResultStatus();

            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            using (WercsDbContext dbwercs = new WercsDbContext())
            {
                dbwercs.Database.ExecuteSqlCommand(@"EXEC Xusp_FORMULAREQ_StartDTE ");
            }
        }

        public static string[] GetUnprocessedRequestParts(int existingRequestId)
        {
            string prodKeys = "X,Y,Z";
            return prodKeys.Replace(" ", "").Split(',');
        }
        public static void UpdateBOSLoadStatus(string uploadStatus, string updatedBy, DepotOperationResultStatus bos_ret)
        {
            string bosLoadMessage = null;
            int uploadStage = 0;
            switch (uploadStatus.ToLower())
            {
                case "bos_load_started":
                    uploadStage = 1;
                    bosLoadMessage = "BOS Load for " + bos_ret.ProcessedPartKey + " started";
                    break;
                case "bos_load_completed":
                    uploadStage = 10;
                    bosLoadMessage = "BOS Load for " + bos_ret.ProcessedPartKey + " completed. Count=" + bos_ret.ResultCount;
                    break;
                case "bos_load_missing":
                    uploadStage = 90;
                    bosLoadMessage = "BOS missing: " + bos_ret.ErrorMessage;
                    break;
                case "bos_load_completed_with_errors":
                    uploadStage = 95;
                    bosLoadMessage = "BOS for " + bos_ret.ProcessedPartKey + " loaded with errors: " + bos_ret.ErrorMessage;
                    break;
                //case string b when b.Contains("bos_load_failed"):
                case "bos_load_failed":
                    uploadStage = 99;
                    bosLoadMessage = "BOS Load for " + bos_ret.ProcessedPartKey + " failed: " + bos_ret.ErrorMessage;
                    break;
                case "bom_load_failed":
                    uploadStage = 100;
                    bosLoadMessage = "BOS Load for " + bos_ret.ProcessedPartKey + " failed: " + bos_ret.ErrorMessage;
                    break;
                case "bos_request_failed":
                    uploadStage = 101;
                    bosLoadMessage = "Request failed: " + bos_ret.ErrorMessage;
                    break;
            }
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();

            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_UpdateBOSLoadStatus @RequestId, @UploadStage, @RequestedPart, @ProcessedPartKey,@StatusMessage, @UpdatedBy",
                        new SqlParameter("@RequestId", bos_ret.RequestId),
                        new SqlParameter("@UploadStage", uploadStage),
                        new SqlParameter("@RequestedPart", bos_ret.RequestedPart ?? ""),
                        new SqlParameter("@ProcessedPartKey", bos_ret.ProcessedPartKey ?? ""),
                        new SqlParameter("@StatusMessage", bosLoadMessage),
                        new SqlParameter("@UpdatedBy", updatedBy)
                    );
            }
        }

        public static void UpdateRequestQueueField_IsSDSSpecificBOS(int RequestId, string RequestedPart, string ProcessedPartKey, string UpdatedBy, bool? fieldValue)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();

            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_UpdateRequestQueueItem_IsSDSSpecificBOS @RequestId, @RequestedPart, @ProcessedPartKey, @UpdatedBy, @IsSDSSpecificBOS",
                            new SqlParameter("@RequestId", RequestId),
                            new SqlParameter("@RequestedPart", RequestedPart),
                            new SqlParameter("@ProcessedPartKey", ProcessedPartKey),
                            new SqlParameter("@UpdatedBy", UpdatedBy),
                            new SqlParameter("@IsSDSSpecificBOS", fieldValue)
                            );
            }
        }

        public static DepotOperationResultStatus SaveDepotRequestBos(int RequestId, string RequestedPart, string sourceSystem, string UpdatedBy, ICalculatedComponentsResult bos, List<DepotPartAttribute> partMultiCASAttributes)
        {
            //Save/update part name in request queue... you need it to run DTE...
            DepotPart Part = bos?.SourceParts?.FirstOrDefault();
            string RequestedGcas = (Part?.PartSrcKey ?? RequestedPart); //Part?.PartSrcKey;
            string ProcessedPartKey = Part?.PartKey; //part.PartSrcKey + "." + part.PartSrcRevision;
            string PartName = Part?.PartName;
            //part.PartGbuName

            DepotOperationResultStatus ret = new DepotOperationResultStatus();
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();
            ret.RequestId = RequestId;
            if (bos==null)
            {
                List<string> errors = new List<string>();
                errors.Add("No Parts for " + RequestedGcas);
                string errorXML = GetDepotBOSMessagesXMLString(RequestedGcas, ProcessedPartKey, errors);

                using (SDSRequestDbContext db = new SDSRequestDbContext())
                {
                    db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_AddFomulaMessageFromDepotXML @RequestId, @SourceSystem, @UpdatedBy, @MessageType, @Formulae",
                                new SqlParameter("@RequestId", RequestId),
                                new SqlParameter("@SourceSystem", sourceSystem),
                                new SqlParameter("@UpdatedBy", UpdatedBy),
                                new SqlParameter("@MessageType", "Error"),
                                new SqlParameter("@Formulae", errorXML)
                              );
                    ret.ErrorMessage = "Errors logged and exited: BOS is null";
                    return ret;
                }
            }
            if (bos?.Errors?.Any() ?? false)
            {

                string errorXML = GetDepotBOSMessagesXMLString(RequestedGcas, ProcessedPartKey, bos.Errors);

                using (SDSRequestDbContext db = new SDSRequestDbContext())
                {
                    db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_AddFomulaMessageFromDepotXML @RequestId, @SourceSystem, @UpdatedBy, @MessageType, @Formulae",
                                new SqlParameter("@RequestId", RequestId),
                                new SqlParameter("@SourceSystem", sourceSystem),
                                new SqlParameter("@UpdatedBy", UpdatedBy),
                                new SqlParameter("@MessageType", "Error"),
                                new SqlParameter("@Formulae", errorXML)
                              );
                    ret.ErrorMessage = "Errors logged and exited: " + errorXML;
                    ret.ResultCount = -1;
                    return ret;
                }
            }
            //bool IsSDSBOS = bos.IsSDSSpecific;
            //var bosCount = bos.CalculatedBillOfSubstance?.Count ?? 0;
            var bosCount = bos.CalculatedComponents?.Count ?? 0;
            
            if (int.Parse(bosCount.ToString()) == 0)
            {
                List<string> errors = new List<string>();
                errors.Add("Composition count for " + RequestedGcas + "-" + ProcessedPartKey + " is 0");
                string errorXML = GetDepotBOSMessagesXMLString(RequestedGcas, ProcessedPartKey, errors);
                using (SDSRequestDbContext db = new SDSRequestDbContext())
                {
                    db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_AddFomulaMessageFromDepotXML @RequestId, @SourceSystem, @UpdatedBy, @MessageType, @Formulae",
                                new SqlParameter("@RequestId", RequestId),
                                new SqlParameter("@SourceSystem", sourceSystem),
                                new SqlParameter("@UpdatedBy", UpdatedBy),
                                new SqlParameter("@MessageType", "Error"),
                                new SqlParameter("@Formulae", errorXML)
                              );
                    ret.ErrorMessage = "Composition count for " + RequestedGcas + "-" + ProcessedPartKey + " is 0";
                    return ret;
                }
            }

            // NOTE: you should pay attention to the warnings that are generated as well
            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                if (bos?.Warnings?.Any() ?? false)
                {

                    string warningXML = GetDepotBOSMessagesXMLString(RequestedGcas, ProcessedPartKey, bos.Warnings);
                    db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_AddFomulaMessageFromDepotXML @RequestId, @SourceSystem, @UpdatedBy, @MessageType, @Formulae",
                                new SqlParameter("@RequestId", RequestId),
                                new SqlParameter("@SourceSystem", sourceSystem),
                                new SqlParameter("@UpdatedBy", UpdatedBy),
                                new SqlParameter("@MessageType", "Warning"),
                                new SqlParameter("@Formulae", warningXML)
                                );
                }
                if (int.Parse(bosCount.ToString()) > 0)
                {
                    if (bos.IsSDSSpecific != null) UpdateRequestQueueField_IsSDSSpecificBOS(RequestId, RequestedGcas, ProcessedPartKey, UpdatedBy, bos.IsSDSSpecific);
                    string compXML = GetDepotCompositionXMLString(RequestedGcas, ProcessedPartKey, bos.CalculatedComponents);

                    db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_AddFomulaFromDepotXML @RequestId, @SourceSystem, @UpdatedBy, @Formulae",
                                    new SqlParameter("@RequestId", RequestId),
                                    new SqlParameter("@SourceSystem", sourceSystem),
                                    new SqlParameter("@UpdatedBy", UpdatedBy),
                                    new SqlParameter("@Formulae", compXML)
                                );
                }
                string multiCASAttributes;
                if ((partMultiCASAttributes?.Count() ?? 0) > 0)
                {
                    multiCASAttributes = GetDepotMultiCASAttributesXMLString(RequestedGcas, ProcessedPartKey, partMultiCASAttributes);
                    if (multiCASAttributes.Length > 0)
                    {
                        db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_AddFormulaAttributesFromDepotXML @RequestId, @SourceSystem, @UpdatedBy, @Attributes",
                                        new SqlParameter("@RequestId", RequestId),
                                        new SqlParameter("@SourceSystem", sourceSystem),
                                        new SqlParameter("@UpdatedBy", UpdatedBy),
                                        new SqlParameter("@Attributes", multiCASAttributes)
                                    );
                    }
                }
                ret.ErrorMessage = null;
                ret.SuccessMessage = "Calculated BOS Saved.";
                return ret;
            }
        }

        public static List<BOMRequestResultHeader> GetBOMRequestResultHeader(int requestId, string targetPart)
        {
            SqlParameter requestIdParam = new SqlParameter { ParameterName = "requestId", Value = requestId };
            SqlParameter requestTargetParam = new SqlParameter { ParameterName = "TargetPart", Value = targetPart };
            SqlParameter requestResultTypeParam = new SqlParameter { ParameterName = "ResultType", Value = "header" };
            //requests = await db.Database.SqlQuery<RequestListItem>("exec usp_SDSREQ_GetRequests @requestTypeId ", requestTypeIdParam).ToList<RequestListItem>();
            //return View(requests);

            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();

            using (WercsDbContext dbwercs = new WercsDbContext())
            {
                return dbwercs.Database.SqlQuery<BOMRequestResultHeader>("exec Xusp_FORMULAREQ_BOMRequest_GetProcessingStatus @RequestId, @TargetPart, @ResultType", requestIdParam, requestTargetParam, requestResultTypeParam).ToList<BOMRequestResultHeader>();
            }
        }

        public static string GetBOMRequestTargetKey(int requestId)
        {
            string BOMRequestTargetKey = "";
            SqlParameter requestIdParam = new SqlParameter { ParameterName = "RequestId", Value = requestId };
            SqlParameter BOMRequestTargetKeyOutParam = new SqlParameter("TargetKey", System.Data.SqlDbType.VarChar, 50);
            //BOMRequestTargetKeyOutParam.
            BOMRequestTargetKeyOutParam.Direction = System.Data.ParameterDirection.Output;

            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();

            using (SDSRequestDbContext db = new SDSRequestDbContext())
            {
                db.Database.ExecuteSqlCommand(@"EXEC usp_FORMULAREQ_FormulaImportRequest_BOMRequest_GetTargetKey @RequestId, @TargetKey output",
                requestIdParam,
                BOMRequestTargetKeyOutParam
            );
                BOMRequestTargetKey = BOMRequestTargetKeyOutParam.Value.ToString();
                return BOMRequestTargetKey;
            }
        }
        public static List<BOMRequestResultErrorDetail> GetBOMRequestResultErrorDetail(int requestId, string targetPart)
        {
            //SDSRequestDbContext db = new SDSRequestDbContext();
            //WercsDbContext dbwercs = new WercsDbContext();

            SqlParameter requestIdParam = new SqlParameter { ParameterName = "requestId", Value = requestId };
            SqlParameter requestTargetParam = new SqlParameter { ParameterName = "TargetPart", Value = targetPart };
            SqlParameter requestResultTypeParam = new SqlParameter { ParameterName = "ResultType", Value = "error_details" };
            //requests = await db.Database.SqlQuery<RequestListItem>("exec usp_SDSREQ_GetRequests @requestTypeId ", requestTypeIdParam).ToList<RequestListItem>();
            //return View(requests);
            using (WercsDbContext dbwercs = new WercsDbContext())
            {
                return dbwercs.Database.SqlQuery<BOMRequestResultErrorDetail>("exec Xusp_FORMULAREQ_BOMRequest_GetProcessingStatus @RequestId, @TargetPart, @ResultType", requestIdParam, requestTargetParam, requestResultTypeParam).ToList<BOMRequestResultErrorDetail>();
            }
        }
    }
}