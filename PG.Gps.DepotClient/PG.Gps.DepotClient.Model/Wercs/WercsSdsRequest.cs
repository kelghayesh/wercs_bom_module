using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG.Gps.DepotClient.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace PG.Gps.DepotClient.Model.Wercs
{
    //[Table("SdsRequest")]
    public class WercsSdsRequest
    {
        //[Newtonsoft.Json.JsonProperty("plmTaskId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        //public string PlmTaskId { get; set; }

        //[Newtonsoft.Json.JsonProperty("originatorName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OriginatorName { get; set; }

        //[Newtonsoft.Json.JsonProperty("requestCategoryId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestCategoryId { get; set; }

        //[Newtonsoft.Json.JsonProperty("assessmentCategory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentCategory { get; set; }

        //[Newtonsoft.Json.JsonProperty("estimatedDuration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? EstimatedDuration { get; set; }

        //[Newtonsoft.Json.JsonProperty("reasonForChange", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReasonForChange { get; set; }

        //[Newtonsoft.Json.JsonProperty("submissionDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? SubmissionDate { get; set; }

        //[Newtonsoft.Json.JsonProperty("requestedCompletionDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? RequestedCompletionDate { get; set; }

        //[Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }

        //[Newtonsoft.Json.JsonProperty("requestNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestNumber { get; set; }

        //[Newtonsoft.Json.JsonProperty("estimatedUpperLevelUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? EstimatedUpperLevelUomId { get; set; }

        //[Newtonsoft.Json.JsonProperty("estimatedUpperLevelUom", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstimatedUpperLevelUomPickName { get; set; }

        //[Newtonsoft.Json.JsonProperty("salesSamplesId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SalesSamplesId { get; set; }

        //[Newtonsoft.Json.JsonProperty("salesSamples", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SalesSamplesPickName { get; set; }

        //[Newtonsoft.Json.JsonProperty("businessId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BusinessId { get; set; }

        //[Newtonsoft.Json.JsonProperty("statusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StatusId { get; set; }

        //[Newtonsoft.Json.JsonProperty("stateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StateId { get; set; }

        //[Newtonsoft.Json.JsonProperty("materialFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaterialFunctionId { get; set; }

        //[Newtonsoft.Json.JsonProperty("materialFunction", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaterialFunctionPickName { get; set; }

        //[Newtonsoft.Json.JsonProperty("owner", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Owner { get; set; }

        //[Newtonsoft.Json.JsonProperty("estimatedUpperLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstimatedUpperLevel { get; set; }

        //[Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        //[Newtonsoft.Json.JsonProperty("projectName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProjectName { get; set; }

        //[Newtonsoft.Json.JsonProperty("lastDateOfShipmentProduction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? LastDateOfShipmentProduction { get; set; }

        //[Newtonsoft.Json.JsonProperty("maxQtyShippedProduced", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaxQtyShippedProduced { get; set; }

        //[Newtonsoft.Json.JsonProperty("originatorEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OriginatorEmail { get; set; }

        //[Newtonsoft.Json.JsonProperty("originator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Originator { get; set; }

        //[Newtonsoft.Json.JsonProperty("rdTeamLeader", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RdTeamLeader { get; set; }

        //[Newtonsoft.Json.JsonProperty("overallRegClassificationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OverallRegClassificationId { get; set; }

        //[Newtonsoft.Json.JsonProperty("overallRegClassification", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OverallRegClassificationPickName { get; set; }

        //[Newtonsoft.Json.JsonProperty("relatedProjects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RelatedProjects { get; set; }

        //[Newtonsoft.Json.JsonProperty("relatedRequestNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RelatedRequestNumber { get; set; }

        //[Newtonsoft.Json.JsonProperty("startOfShipment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? StartOfShipment { get; set; }

        //[Newtonsoft.Json.JsonProperty("vendorContactName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VendorContactName { get; set; }

        //[Newtonsoft.Json.JsonProperty("vendorContactEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VendorContactEmail { get; set; }

        //[Newtonsoft.Json.JsonProperty("vendorContactPhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VendorContactPhone { get; set; }

        //[Newtonsoft.Json.JsonProperty("requestNumberSentAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? RequestNumberSentAt { get; set; }

        //[Newtonsoft.Json.JsonProperty("packagingMaterialTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PackagingMaterialTypeId { get; set; }

        //[Newtonsoft.Json.JsonProperty("relatedNRQId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RelatedNRQId { get; set; }

        //[Newtonsoft.Json.JsonProperty("isImportEeaFppNotArticle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsImportEeaFppNotArticle { get; set; }

        //[Newtonsoft.Json.JsonProperty("legacyRQId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LegacyRQId { get; set; }

        //[Newtonsoft.Json.JsonProperty("estimatedProductSegments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstimatedProductSegmentsNames { get; set; }

        //[Newtonsoft.Json.JsonProperty("manufacturer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Manufacturer { get; set; }

        //[Newtonsoft.Json.JsonProperty("arePackagesSameSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ArePackagesSameSize { get; set; }

        //[Newtonsoft.Json.JsonProperty("packagingPartIdForLargestSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PackagingPartIdForLargestSize { get; set; }

        //[Newtonsoft.Json.JsonProperty("largestConsumerPackageSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LargestConsumerPackageSize { get; set; }

        //[Newtonsoft.Json.JsonProperty("packageSizeUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PackageSizeUomId { get; set; }

        [Newtonsoft.Json.JsonProperty("packageSizeUom", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PackageSizeUomPickName { get; set; }

        //[Newtonsoft.Json.JsonProperty("qtyShippedProducedUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? QtyShippedProducedUomId { get; set; }

        //[Newtonsoft.Json.JsonProperty("qtyShippedProducedUom", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string QtyShippedProducedUomPickName { get; set; }

        //[Newtonsoft.Json.JsonProperty("isAlternateDosageApplicable", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IsAlternateDosageApplicable { get; set; }

        //[Newtonsoft.Json.JsonProperty("productCategoryPlatformId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ProductCategoryPlatformId { get; set; }

        //[Newtonsoft.Json.JsonProperty("reportedFunctionToBeAssessed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ReportedFunctionToBeAssessed { get; set; }

        //[Newtonsoft.Json.JsonProperty("currentMaterialFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CurrentMaterialFunctionId { get; set; }

        //[Newtonsoft.Json.JsonProperty("businessAreas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BusinessAreasNames { get; set; }

        //[Newtonsoft.Json.JsonProperty("productCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductCategoryPlatformsNames { get; set; }

        //[Newtonsoft.Json.JsonProperty("srcFunctions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcFunctionsNames { get; set; }

        //[Newtonsoft.Json.JsonProperty("functions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FunctionsNames { get; set; }

        //[Newtonsoft.Json.JsonProperty("assessBusinessAreaId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AssessBusinessAreaId { get; set; }

        [Newtonsoft.Json.JsonProperty("assessBusinessArea", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BusinessArea AssessBusinessArea { get; set; }

        [Newtonsoft.Json.JsonProperty("isBffRawMaterialRequest", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsBffRawMaterialRequest { get; set; }

        [Newtonsoft.Json.JsonProperty("arePackageShapesComposSame", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ArePackageShapesComposSame { get; set; }

        [Newtonsoft.Json.JsonProperty("estimatedMaterialVolume", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstimatedMaterialVolume { get; set; }

        [Newtonsoft.Json.JsonProperty("estUpperLevelMatInPackage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstUpperLevelMatInPackage { get; set; }

        [Newtonsoft.Json.JsonProperty("estUpperLevelMatInProduct", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstUpperLevelMatInProduct { get; set; }

        [Newtonsoft.Json.JsonProperty("isSalesSamplesUnderPgControl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsSalesSamplesUnderPgControl { get; set; }

        [Newtonsoft.Json.JsonProperty("salesSamplesDistributedTo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SalesSamplesDistributedTo { get; set; }

        [Newtonsoft.Json.JsonProperty("materialVolumeUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaterialVolumeUomId { get; set; }

        [Newtonsoft.Json.JsonProperty("materialVolumeUom", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MaterialVolumeUom MaterialVolumeUom { get; set; }

        [Newtonsoft.Json.JsonProperty("finishedProductImportedAsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FinishedProductImportedAsId { get; set; }

        [Newtonsoft.Json.JsonProperty("finishedProductImportedAs", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FinishedProductImportedAs FinishedProductImportedAs { get; set; }

        [Newtonsoft.Json.JsonProperty("initiativeStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InitiativeStatusId { get; set; }

        [Newtonsoft.Json.JsonProperty("initiativeStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RequestStatus InitiativeStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("preClearanceLevelId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PreClearanceLevelId { get; set; }

        [Newtonsoft.Json.JsonProperty("preClearanceLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PreClearanceLevel PreClearanceLevel { get; set; }

        [Newtonsoft.Json.JsonProperty("completedInPassAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? CompletedInPassAt { get; set; }

        [Newtonsoft.Json.JsonProperty("gpsProductTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GpsProductTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty("gpsProductTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestGpsProductType> GpsProductTypes { get; set; }

        [Newtonsoft.Json.JsonProperty("doesMaterialVolTracked", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DoesMaterialVolTracked { get; set; }

        [Newtonsoft.Json.JsonProperty("lifeCycleStateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? LifeCycleStateId { get; set; }

        [Newtonsoft.Json.JsonProperty("lifeCycleState", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RequestLifecycleState LifeCycleState { get; set; }

        [Newtonsoft.Json.JsonProperty("regions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Regions { get; set; }

        [Newtonsoft.Json.JsonProperty("bffMsprComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BffMsprComments { get; set; }

        [Newtonsoft.Json.JsonProperty("studyPlacementMarketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StudyPlacementMarketId { get; set; }

        [Newtonsoft.Json.JsonProperty("markets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestMarket> Markets { get; set; }

        [Newtonsoft.Json.JsonProperty("partMarkets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestPartMarket> PartMarkets { get; set; }

        [Newtonsoft.Json.JsonProperty("studies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestStudy> Studies { get; set; }

        [Newtonsoft.Json.JsonProperty("parts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestPart> Parts { get; set; }

        //[Newtonsoft.Json.JsonProperty("assessments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentsNumbers { get; set; }
        public System.Collections.Generic.ICollection<Assessment> Assessments { get; set; }

        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }

        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("createdById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CreatedById { get; set; }

        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ModifiedById { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ModifiedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Version { get; set; }

        [Newtonsoft.Json.JsonProperty("createdChangeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CreatedChangeId { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedChangeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ModifiedChangeId { get; set; }

        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }

        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }

        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }

        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }


    }

    public class RequestDto
    {
        [Newtonsoft.Json.JsonProperty("plmTaskId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlmTaskId { get; set; }

        [Newtonsoft.Json.JsonProperty("originatorName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OriginatorName { get; set; }

        [Newtonsoft.Json.JsonProperty("requestCategoryId", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestCategoryId { get; set; }

        [Newtonsoft.Json.JsonProperty("assessmentCategory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentCategory { get; set; }

        [Newtonsoft.Json.JsonProperty("estimatedDuration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? EstimatedDuration { get; set; }

        [Newtonsoft.Json.JsonProperty("reasonForChange", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReasonForChange { get; set; }

        [Newtonsoft.Json.JsonProperty("submissionDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? SubmissionDate { get; set; }

        [Newtonsoft.Json.JsonProperty("requestedCompletionDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? RequestedCompletionDate { get; set; }

        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }

        [Newtonsoft.Json.JsonProperty("requestNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("estimatedUpperLevelUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? EstimatedUpperLevelUomId { get; set; }

        [Newtonsoft.Json.JsonProperty("estimatedUpperLevelUom", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom EstimatedUpperLevelUom { get; set; }

        [Newtonsoft.Json.JsonProperty("salesSamplesId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SalesSamplesId { get; set; }

        [Newtonsoft.Json.JsonProperty("salesSamples", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RequestSalesSample SalesSamples { get; set; }

        [Newtonsoft.Json.JsonProperty("businessId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BusinessId { get; set; }

        [Newtonsoft.Json.JsonProperty("statusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StatusId { get; set; }

        [Newtonsoft.Json.JsonProperty("stateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StateId { get; set; }

        [Newtonsoft.Json.JsonProperty("materialFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaterialFunctionId { get; set; }

        [Newtonsoft.Json.JsonProperty("materialFunction", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Function MaterialFunction { get; set; }

        [Newtonsoft.Json.JsonProperty("owner", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Owner { get; set; }

        [Newtonsoft.Json.JsonProperty("estimatedUpperLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstimatedUpperLevel { get; set; }

        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }

        [Newtonsoft.Json.JsonProperty("projectName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProjectName { get; set; }

        [Newtonsoft.Json.JsonProperty("lastDateOfShipmentProduction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? LastDateOfShipmentProduction { get; set; }

        [Newtonsoft.Json.JsonProperty("maxQtyShippedProduced", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaxQtyShippedProduced { get; set; }

        [Newtonsoft.Json.JsonProperty("originatorEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OriginatorEmail { get; set; }

        [Newtonsoft.Json.JsonProperty("originator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Originator { get; set; }

        [Newtonsoft.Json.JsonProperty("rdTeamLeader", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RdTeamLeader { get; set; }

        [Newtonsoft.Json.JsonProperty("overallRegClassificationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OverallRegClassificationId { get; set; }

        [Newtonsoft.Json.JsonProperty("overallRegClassification", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RegulatoryClass OverallRegClassification { get; set; }

        [Newtonsoft.Json.JsonProperty("relatedProjects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RelatedProjects { get; set; }

        [Newtonsoft.Json.JsonProperty("relatedRequestNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RelatedRequestNumber { get; set; }

        [Newtonsoft.Json.JsonProperty("startOfShipment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? StartOfShipment { get; set; }

        [Newtonsoft.Json.JsonProperty("vendorContactName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VendorContactName { get; set; }

        [Newtonsoft.Json.JsonProperty("vendorContactEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VendorContactEmail { get; set; }

        [Newtonsoft.Json.JsonProperty("vendorContactPhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VendorContactPhone { get; set; }

        [Newtonsoft.Json.JsonProperty("requestNumberSentAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? RequestNumberSentAt { get; set; }

        [Newtonsoft.Json.JsonProperty("packagingMaterialTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PackagingMaterialTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty("relatedNRQId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RelatedNRQId { get; set; }

        [Newtonsoft.Json.JsonProperty("isImportEeaFppNotArticle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsImportEeaFppNotArticle { get; set; }

        [Newtonsoft.Json.JsonProperty("legacyRQId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LegacyRQId { get; set; }

        [Newtonsoft.Json.JsonProperty("estimatedProductSegments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestSegment> EstimatedProductSegments { get; set; }

        [Newtonsoft.Json.JsonProperty("manufacturer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Manufacturer { get; set; }

        [Newtonsoft.Json.JsonProperty("arePackagesSameSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ArePackagesSameSize { get; set; }

        [Newtonsoft.Json.JsonProperty("packagingPartIdForLargestSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PackagingPartIdForLargestSize { get; set; }

        [Newtonsoft.Json.JsonProperty("largestConsumerPackageSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LargestConsumerPackageSize { get; set; }

        [Newtonsoft.Json.JsonProperty("packageSizeUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PackageSizeUomId { get; set; }

        [Newtonsoft.Json.JsonProperty("packageSizeUom", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PackageSizeUom PackageSizeUom { get; set; }

        [Newtonsoft.Json.JsonProperty("qtyShippedProducedUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? QtyShippedProducedUomId { get; set; }

        [Newtonsoft.Json.JsonProperty("qtyShippedProducedUom", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public QuantityShippedProducedUom QtyShippedProducedUom { get; set; }

        [Newtonsoft.Json.JsonProperty("isAlternateDosageApplicable", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IsAlternateDosageApplicable { get; set; }

        [Newtonsoft.Json.JsonProperty("productCategoryPlatformId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ProductCategoryPlatformId { get; set; }

        [Newtonsoft.Json.JsonProperty("reportedFunctionToBeAssessed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ReportedFunctionToBeAssessed { get; set; }

        [Newtonsoft.Json.JsonProperty("currentMaterialFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CurrentMaterialFunctionId { get; set; }

        [Newtonsoft.Json.JsonProperty("businessAreas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestBusinessArea> BusinessAreas { get; set; }

        [Newtonsoft.Json.JsonProperty("productCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestProductCategoryPlatform> ProductCategoryPlatforms { get; set; }

        [Newtonsoft.Json.JsonProperty("srcFunctions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestSrcFunction> SrcFunctions { get; set; }

        [Newtonsoft.Json.JsonProperty("functions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestMaterialFunction> Functions { get; set; }

        [Newtonsoft.Json.JsonProperty("assessBusinessAreaId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AssessBusinessAreaId { get; set; }

        [Newtonsoft.Json.JsonProperty("assessBusinessArea", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BusinessArea AssessBusinessArea { get; set; }

        [Newtonsoft.Json.JsonProperty("isBffRawMaterialRequest", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsBffRawMaterialRequest { get; set; }

        [Newtonsoft.Json.JsonProperty("arePackageShapesComposSame", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ArePackageShapesComposSame { get; set; }

        [Newtonsoft.Json.JsonProperty("estimatedMaterialVolume", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstimatedMaterialVolume { get; set; }

        [Newtonsoft.Json.JsonProperty("estUpperLevelMatInPackage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstUpperLevelMatInPackage { get; set; }

        [Newtonsoft.Json.JsonProperty("estUpperLevelMatInProduct", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EstUpperLevelMatInProduct { get; set; }

        [Newtonsoft.Json.JsonProperty("isSalesSamplesUnderPgControl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsSalesSamplesUnderPgControl { get; set; }

        [Newtonsoft.Json.JsonProperty("salesSamplesDistributedTo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SalesSamplesDistributedTo { get; set; }

        [Newtonsoft.Json.JsonProperty("materialVolumeUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaterialVolumeUomId { get; set; }

        [Newtonsoft.Json.JsonProperty("materialVolumeUom", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MaterialVolumeUom MaterialVolumeUom { get; set; }

        [Newtonsoft.Json.JsonProperty("finishedProductImportedAsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FinishedProductImportedAsId { get; set; }

        [Newtonsoft.Json.JsonProperty("finishedProductImportedAs", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FinishedProductImportedAs FinishedProductImportedAs { get; set; }

        [Newtonsoft.Json.JsonProperty("initiativeStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InitiativeStatusId { get; set; }

        [Newtonsoft.Json.JsonProperty("initiativeStatus", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RequestStatus InitiativeStatus { get; set; }

        [Newtonsoft.Json.JsonProperty("preClearanceLevelId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PreClearanceLevelId { get; set; }

        [Newtonsoft.Json.JsonProperty("preClearanceLevel", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PreClearanceLevel PreClearanceLevel { get; set; }

        [Newtonsoft.Json.JsonProperty("completedInPassAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? CompletedInPassAt { get; set; }

        [Newtonsoft.Json.JsonProperty("gpsProductTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GpsProductTypeId { get; set; }

        [Newtonsoft.Json.JsonProperty("gpsProductTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestGpsProductType> GpsProductTypes { get; set; }

        [Newtonsoft.Json.JsonProperty("doesMaterialVolTracked", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DoesMaterialVolTracked { get; set; }

        [Newtonsoft.Json.JsonProperty("lifeCycleStateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? LifeCycleStateId { get; set; }

        [Newtonsoft.Json.JsonProperty("lifeCycleState", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RequestLifecycleState LifeCycleState { get; set; }

        [Newtonsoft.Json.JsonProperty("regions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Regions { get; set; }

        [Newtonsoft.Json.JsonProperty("bffMsprComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BffMsprComments { get; set; }

        [Newtonsoft.Json.JsonProperty("studyPlacementMarketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StudyPlacementMarketId { get; set; }

        [Newtonsoft.Json.JsonProperty("markets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestMarket> Markets { get; set; }

        [Newtonsoft.Json.JsonProperty("partMarkets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestPartMarket> PartMarkets { get; set; }

         [Newtonsoft.Json.JsonProperty("studies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestStudy> Studies { get; set; }

        [Newtonsoft.Json.JsonProperty("parts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestPart> Parts { get; set; }

        [Newtonsoft.Json.JsonProperty("assessments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Assessment> Assessments { get; set; }

        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }

        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }

        [Newtonsoft.Json.JsonProperty("createdById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CreatedById { get; set; }

        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? CreatedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ModifiedById { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ModifiedAt { get; set; }

        [Newtonsoft.Json.JsonProperty("version", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Version { get; set; }

        [Newtonsoft.Json.JsonProperty("createdChangeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CreatedChangeId { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedChangeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ModifiedChangeId { get; set; }

        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }

        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }

        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }

        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }

        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }


    }

}
