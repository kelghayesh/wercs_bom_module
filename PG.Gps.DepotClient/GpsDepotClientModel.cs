using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Gps.DepotClient.Model
{
	

    public enum SyncKeyType { Key = 1, KeyRev = 2, Expression = 3 }

    public abstract class Picklist
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }

        public static bool Equals(Picklist picklistValue, string value, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase)
        {
            if (picklistValue == null || string.IsNullOrEmpty(picklistValue.Name))
                return string.IsNullOrEmpty(value);
            return picklistValue.Name.Equals(value, comparisonType);
        }
        public static bool Contains<PicklistType>(IEnumerable<PicklistType> picklistValues, string value, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase) where PicklistType : Picklist
        {
            return picklistValues?.Any(p => Picklist.Equals(p, value, comparisonType)) ?? false;
        }
        public static string NameOf(Picklist picklistValue, string defaultValue = null)
        {
            return picklistValue?.Name ?? defaultValue;
        }
    }

    public abstract class PicklistBag<PicklistType> where PicklistType : Picklist
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PicklistType Value { get; set; }

        public static bool Contains<PicklistBagType>(IEnumerable<PicklistBagType> picklistBagValues, string value, StringComparison comparisonType = StringComparison.OrdinalIgnoreCase) where PicklistBagType : PicklistBag<PicklistType>
        {
            return picklistBagValues?.Any(p => Picklist.Equals(p?.Value, value, comparisonType)) ?? false;
        }
    }

    //This was up top in the old version but it's getting pulled from the API twoards the bottom of this file
    //public partial class FileParameter
    //{
    //    public FileParameter(System.IO.Stream data, string fileName, string contentType)
    //    {
    //        Data = data;
    //        FileName = fileName;
    //        ContentType = contentType;
    //    }

    //    public System.IO.Stream Data { get; set; }

    //    public string FileName { get; set; }

    //    public string ContentType { get; set; }
    //}

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum IntegrationOperation
    {
        [System.Runtime.Serialization.EnumMember(Value = @"create__c")]
        Create__c = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"update__c")]
        Update__c = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"delete__c")]
        Delete__c = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class AdminControllerTroubleShootingVqlQueryContainer 
    {
        [Newtonsoft.Json.JsonProperty("query", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Query { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class User 
    {
        [Newtonsoft.Json.JsonProperty("username", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Username { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class AuthenticationControllerUserTokenResponse 
    {
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("token", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Token { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Origin 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Function 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionFunction 
    {
        [Newtonsoft.Json.JsonProperty("compId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CompId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FunctionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("composition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Composition Composition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("function", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Function Function { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SrcFunction 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionSrcFunction 
    {
        [Newtonsoft.Json.JsonProperty("compId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CompId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SrcFunctionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("composition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Composition Composition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFunction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SrcFunction SrcFunction { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class QaTarget 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Market 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompetitiveProductManufacturer 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompetitiveProductBrandt 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartCompetitiveProductBrandt 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompetitiveProductBrandt Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class EnvironmentalClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class McpClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class InternalMaterialFor 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Organization 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum ConfidentialType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"NonConfidential")]
        NonConfidential = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Gps")]
        Gps = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Perfume")]
        Perfume = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum ImportStatusValues
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Pending")]
        Pending = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Processing")]
        Processing = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"DepsPending")]
        DepsPending = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Complete")]
        Complete = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Error")]
        Error = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Legacy")]
        Legacy = 5,
    
        [System.Runtime.Serialization.EnumMember(Value = @"SeeParent")]
        SeeParent = 6,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ImportStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Feedstock 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class YesNoUnknown 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PlmType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PlmPolicy 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PlmState 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PlmStage 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class FormulationType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Vendor 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("nameKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NameKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sapCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SapCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sapName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SapName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Type { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isNonDisclosedLocation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsNonDisclosedLocation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("address1", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Address1 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("address2", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Address2 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("city", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string City { get; set; }
    
        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string State { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MarketId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("market", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Market Market { get; set; }
    
        [Newtonsoft.Json.JsonProperty("zip", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Zip { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCurrentlyActive", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCurrentlyActive { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oldCisproVendorNbr", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OldCisproVendorNbr { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oldCompassName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OldCompassName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Sector 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SubSector 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GlobalForm 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SecurityClassification 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Region 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Gbu 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SubCategory 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Category 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ReachStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SecurityProject 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class IngredientClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RegulatoryClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class AttributeType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CasGroup 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Attribute 
    {
        [Newtonsoft.Json.JsonProperty("valueText", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ValueText { get; set; }
    
        [Newtonsoft.Json.JsonProperty("casName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CasName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("casIsAllergen", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? CasIsAllergen { get; set; }
    
        [Newtonsoft.Json.JsonProperty("attributeType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AttributeType AttributeType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("casGroup", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CasGroup CasGroup { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class AttributeRegion 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartAttribute 
    {
        [Newtonsoft.Json.JsonProperty("function", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Function Function { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulatoryClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RegulatoryClass RegulatoryClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("attribute", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Attribute Attribute { get; set; }
    
        [Newtonsoft.Json.JsonProperty("attributeRegion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AttributeRegion AttributeRegion { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class BusinessArea 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartBusinessArea 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BusinessArea Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ProductCategoryPlatform 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartProductCategoryPlatform 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ProductCategoryPlatform Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ProductTechnologyChassis 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartProductTechnologyChassis 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ProductTechnologyChassis Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ProductTechnologyPlatform 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartProductTechnologyPlatform 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ProductTechnologyPlatform Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Franchise 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartFranchise 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Franchise Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Segment 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartSegment 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Segment Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum PartContactContactType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Owner")]
        Owner = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"CoOwner")]
        CoOwner = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Originator")]
        Originator = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartContact 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public PartContactContactType Type { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Brand 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartBrand 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("brandId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int BrandId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("brand", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Brand Brand { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SubBrand 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartSubBrand 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subBrandId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SubBrandId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subBrand", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SubBrand SubBrand { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartOrganization 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Organization Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class IpClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartIpClass 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IpClass Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartInciAttributeRegion 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AttributeRegion Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartNotes 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sequenceNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SequenceNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SecurityClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartSecurityClass 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SecurityClass Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartSecurityProject 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SecurityProject Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Plant 
    {
        [Newtonsoft.Json.JsonProperty("code", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Code { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartPlant 
    {
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Plant Plant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("authorizedToProduce", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? AuthorizedToProduce { get; set; }
    
        [Newtonsoft.Json.JsonProperty("authorizedToUse", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? AuthorizedToUse { get; set; }
    
        [Newtonsoft.Json.JsonProperty("authorized", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Authorized { get; set; }
    
        [Newtonsoft.Json.JsonProperty("activated", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Activated { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class AuthoringApp 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TestMethod 
    {
        [Newtonsoft.Json.JsonProperty("srcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("classification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Classification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PlmTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmType PlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PerformanceSpecTestMethod 
    {
        [Newtonsoft.Json.JsonProperty("performanceSpecId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PerformanceSpecId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethodId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TestMethodId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethod", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TestMethod TestMethod { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PerformanceSpecTestMethodReference 
    {
        [Newtonsoft.Json.JsonProperty("performanceSpecId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PerformanceSpecId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethodId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int TestMethodId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethod", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TestMethod TestMethod { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PerformanceSpec 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sequence", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Sequence { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcChangeNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcChangeNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("action", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Action { get; set; }
    
        [Newtonsoft.Json.JsonProperty("characteristic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Characteristic { get; set; }
    
        [Newtonsoft.Json.JsonProperty("characteristicSpecifics", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CharacteristicSpecifics { get; set; }
    
        [Newtonsoft.Json.JsonProperty("commonPerformanceSpecification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CommonPerformanceSpecification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethodOrigin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TestMethodOrigin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethodLogic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TestMethodLogic { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethodNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TestMethodNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethodSpecifics", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TestMethodSpecifics { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testingLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TestingLevel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reTesting", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReTesting { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantTestingUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlantTestingUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantTestingUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom PlantTestingUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantTestingLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlantTestingLevel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sampling", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Sampling { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subgroup", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Subgroup { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsReportType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsReportType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsLowLimit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsLowLimit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsLowTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsLowTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsLowRtReleaseLimit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsLowRtReleaseLimit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsHighTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsHighTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsHighRtReleaseLimit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsHighRtReleaseLimit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsHighLimit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsHighLimit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TargetsUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom TargetsUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsReportToNearest", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsReportToNearest { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsReleaseCriteria", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsReleaseCriteria { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsRtReleaseCriteria", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsRtReleaseCriteria { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetsActionRequired", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetsActionRequired { get; set; }
    
        [Newtonsoft.Json.JsonProperty("criticality", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Criticality { get; set; }
    
        [Newtonsoft.Json.JsonProperty("basis", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Basis { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testGroups", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TestGroups { get; set; }
    
        [Newtonsoft.Json.JsonProperty("application", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Application { get; set; }
    
        [Newtonsoft.Json.JsonProperty("authoringApplicationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AuthoringApplicationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("authoringApplication", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AuthoringApp AuthoringApplication { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethods", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PerformanceSpecTestMethod> TestMethods { get; set; }
    
        [Newtonsoft.Json.JsonProperty("testMethodReferences", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PerformanceSpecTestMethodReference> TestMethodReferences { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DocumentSubType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DocumentFileFormat 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DocumentFile 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("documentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DocumentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("document", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Document Document { get; set; }
    
        [Newtonsoft.Json.JsonProperty("documentFileFormatId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? DocumentFileFormatId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fileFormat", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DocumentFileFormat FileFormat { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sizeInBytes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SizeInBytes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Document 
    {
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ownerUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OwnerUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ownerUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User OwnerUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originatorUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OriginatorUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originatorUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User OriginatorUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("releasedDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ReleasedDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reasonForChange", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReasonForChange { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segmentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SegmentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Segment Segment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryOrganizationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PrimaryOrganizationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryOrganization", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Organization PrimaryOrganization { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmType PlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subtypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SubtypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subtype", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DocumentSubType Subtype { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmStateId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmState PlmState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmPolicyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmPolicy PlmPolicy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcObjectId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcObjectId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryImage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PrimaryImage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }
    
        [Newtonsoft.Json.JsonProperty("localDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LocalDescription { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketingName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MarketingName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketingText", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MarketingText { get; set; }
    
        [Newtonsoft.Json.JsonProperty("verticalSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VerticalSize { get; set; }
    
        [Newtonsoft.Json.JsonProperty("horizontalSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HorizontalSize { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("files", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DocumentFile> Files { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityClassificationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SecurityClassificationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityClassification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SecurityClassification SecurityClassification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasAts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HasAts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartDocumentType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartDocument 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("documentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DocumentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partDocumentTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartDocumentTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("document", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Document Document { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partDocumentType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartDocumentType PartDocumentType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartMarket 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MarketId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("market", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Market Market { get; set; }
    
        [Newtonsoft.Json.JsonProperty("approvalStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ApprovalStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SalesQtyUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MarketClearanceStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MarketClearance 
    {
        [Newtonsoft.Json.JsonProperty("marketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MarketId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedAnnualVolume", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ExpectedAnnualVolume { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedAnnualVolumeUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ExpectedAnnualVolumeUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedAnnualVolumeUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SalesQtyUom ExpectedAnnualVolumeUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RegionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketClearanceStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MarketClearanceStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketClearanceStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MarketClearanceStatus MarketClearanceStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmGpsApprovalStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlmGpsApprovalStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmGpsRegistrationStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlmGpsRegistrationStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sentToPlmAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? SentToPlmAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ProductForm 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartProductForm 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ProductForm Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartFamilyRef 
    {
        [Newtonsoft.Json.JsonProperty("partFamilyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartFamilyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partFamily", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartFamily PartFamily { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromSrcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FromSrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromSrcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FromSrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromPlmTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FromPlmTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromPlmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmType FromPlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromSrcObjectId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FromSrcObjectId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromPlmStateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FromPlmStateId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromPlmPolicyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FromPlmPolicyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromPlmState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmState FromPlmState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromPlmPolicy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmPolicy FromPlmPolicy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromOwnerUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FromOwnerUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromOriginatorUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FromOriginatorUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromOwner", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User FromOwner { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromOriginator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User FromOriginator { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromSrcCreatedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? FromSrcCreatedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fromSrcModifiedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? FromSrcModifiedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("toPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ToPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("toPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part ToPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartFamily 
    {
        [Newtonsoft.Json.JsonProperty("srcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmType PlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcObjectId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcObjectId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmStateId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmPolicyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmState PlmState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmPolicy PlmPolicy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ownerUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OwnerUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originatorUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OriginatorUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("owner", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User Owner { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User Originator { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcCreatedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? SrcCreatedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcModifiedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? SrcModifiedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("authoringApplication", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AuthoringApp AuthoringApplication { get; set; }
    
        [Newtonsoft.Json.JsonProperty("authoringApplicationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AuthoringApplicationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("references", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartFamilyRef> References { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SapType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class AerosolType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class BoilingPoint 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CanConstruction 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ClosedCupFlashpoint 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Color 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ColorIntensity 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CorrosivetoMetals 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class AerosolTestData 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PHAvailability 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PhDilution 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class BatteryType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class BatteryWeightUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GramsOfLithiumUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class LithiumBatteryEnergyUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class NominalVoltageUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TypicalCapacityUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DensityUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ManufacturingStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Certification 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CertificationStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MaterialCertification 
    {
        [Newtonsoft.Json.JsonProperty("materialPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MaterialPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part MaterialPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mepPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MepPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mepPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part MepPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("certificationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CertificationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("certification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Certification Certification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("certificationStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CertificationStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("certificationStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CertificationStatus CertificationStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expiration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? Expiration { get; set; }
    
        [Newtonsoft.Json.JsonProperty("transientImportPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part TransientImportPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DosageUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class FrequencyUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ModeOfProductDisposal 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PowerSource 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartSrcFunction 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SrcFunctionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFunction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SrcFunction SrcFunction { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartFunction 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Function Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MaterialClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MaterialSubclass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SpecificationSubtype 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ReviewInProcessStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ReviewedStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ReserveAlkalinityAcidityUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DangerousGoodsClassification 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PackingGroup 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ShippingName 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TechnicalName 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class UnNumber 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ConsumerUnitMarksLabels 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DangerousGoodsConsumerUnitMarks 
    {
        [Newtonsoft.Json.JsonProperty("danerousGoodsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DanerousGoodsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("danerousGoods", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DangerousGoods DanerousGoods { get; set; }
    
        [Newtonsoft.Json.JsonProperty("consumerUnitMarksLabelsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ConsumerUnitMarksLabelsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("consumerUnitMarksLabels", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ConsumerUnitMarksLabels ConsumerUnitMarksLabels { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CustomerUnitMarksLabels 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DangerousGoodsCustomerUnitMarks 
    {
        [Newtonsoft.Json.JsonProperty("danerousGoodsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DanerousGoodsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("danerousGoods", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DangerousGoods DanerousGoods { get; set; }
    
        [Newtonsoft.Json.JsonProperty("customerUnitMarksLabelsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CustomerUnitMarksLabelsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("customerUnitMarksLabels", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CustomerUnitMarksLabels CustomerUnitMarksLabels { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class HazardClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DangerousGoodsHazardClass 
    {
        [Newtonsoft.Json.JsonProperty("danerousGoodsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DanerousGoodsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("danerousGoods", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DangerousGoods DanerousGoods { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazardClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HazardClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazardClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HazardClass HazardClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PackagingRequirement 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DangerousGoodsPackagingRequirement 
    {
        [Newtonsoft.Json.JsonProperty("danerousGoodsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DanerousGoodsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("danerousGoods", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DangerousGoods DanerousGoods { get; set; }
    
        [Newtonsoft.Json.JsonProperty("packagingRequirementId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PackagingRequirementId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("packagingRequirement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PackagingRequirement PackagingRequirement { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DangerousGoods 
    {
        [Newtonsoft.Json.JsonProperty("dangerousGoodsClassifId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? DangerousGoodsClassifId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dangerousGoodsClassification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DangerousGoodsClassification DangerousGoodsClassification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("extraConsUnitMarksAndLabels", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExtraConsUnitMarksAndLabels { get; set; }
    
        [Newtonsoft.Json.JsonProperty("extraCustUnitMarksAndLabels", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExtraCustUnitMarksAndLabels { get; set; }
    
        [Newtonsoft.Json.JsonProperty("otherShippingName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OtherShippingName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maxConsUnitPartWeightOrVol", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaxConsUnitPartWeightOrVol { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maxCustUnitPartWeightOrVol", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaxCustUnitPartWeightOrVol { get; set; }
    
        [Newtonsoft.Json.JsonProperty("packingGroupId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PackingGroupId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("packingGroup", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PackingGroup PackingGroup { get; set; }
    
        [Newtonsoft.Json.JsonProperty("properShippingNameId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ProperShippingNameId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("properShippingName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ShippingName ProperShippingName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("canShipInLimitedQuantity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? CanShipInLimitedQuantity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("technicalName1Id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TechnicalName1Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("technicalName2Id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TechnicalName2Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("technicalName1", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TechnicalName TechnicalName1 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("technicalName2", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TechnicalName TechnicalName2 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("unNumberId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? UnNumberId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("unNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public UnNumber UnNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("otherUnNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OtherUnNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isUnSpecificationPackagingReq", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsUnSpecificationPackagingReq { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marksLabelsRequiredOnConsumerUnit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DangerousGoodsConsumerUnitMarks> MarksLabelsRequiredOnConsumerUnit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marksLabelsRequiredOnCustomerUnit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DangerousGoodsCustomerUnitMarks> MarksLabelsRequiredOnCustomerUnit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazardClasses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DangerousGoodsHazardClass> HazardClasses { get; set; }
    
        [Newtonsoft.Json.JsonProperty("otherPackagingRequirements", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DangerousGoodsPackagingRequirement> OtherPackagingRequirements { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartDangerousGoods 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dangerousGoodsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DangerousGoodsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dangerousGoods", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DangerousGoods DangerousGoods { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Language 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SignalWord 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class HazardClassification 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GhsHazardClassification 
    {
        [Newtonsoft.Json.JsonProperty("ghsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int GhsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Ghs Ghs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazardClassificationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HazardClassificationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazardClassification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HazardClassification HazardClassification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class HazardStatement 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GhsHazardStatement 
    {
        [Newtonsoft.Json.JsonProperty("ghsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int GhsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Ghs Ghs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazardStatementId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HazardStatementId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazardStatement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public HazardStatement HazardStatement { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Pictogram 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GhsPictogram 
    {
        [Newtonsoft.Json.JsonProperty("ghsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int GhsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Ghs Ghs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pictogramId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PictogramId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pictogram", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Pictogram Pictogram { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GhsPhraseType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GhsCode 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numberOfBlanks", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? NumberOfBlanks { get; set; }
    
        [Newtonsoft.Json.JsonProperty("statement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Statement { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghsPhraseTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GhsPhraseTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghsPhraseType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GhsPhraseType GhsPhraseType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GhsPhrase 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("celsius", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Celsius { get; set; }
    
        [Newtonsoft.Json.JsonProperty("disposalLocation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DisposalLocation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fahrenheit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Fahrenheit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghsCodeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GhsCodeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghsCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GhsCode GhsCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int GhsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Ghs Ghs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ingredient", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Ingredient { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numberOfBlanks", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? NumberOfBlanks { get; set; }
    
        [Newtonsoft.Json.JsonProperty("other", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Other { get; set; }
    
        [Newtonsoft.Json.JsonProperty("statement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Statement { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghsPhraseTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GhsPhraseTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghsPhraseType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GhsPhraseType GhsPhraseType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("weight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Weight { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GhsMarket 
    {
        [Newtonsoft.Json.JsonProperty("ghsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int GhsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MarketId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Ghs Ghs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("market", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Market Market { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Ghs 
    {
        [Newtonsoft.Json.JsonProperty("euContains", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EuContains { get; set; }
    
        [Newtonsoft.Json.JsonProperty("languageId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? LanguageId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("language", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Language Language { get; set; }
    
        [Newtonsoft.Json.JsonProperty("signalWordId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SignalWordId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("signalWord", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SignalWord SignalWord { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazardClassifications", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GhsHazardClassification> HazardClassifications { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazardStatements", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GhsHazardStatement> HazardStatements { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pictograms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GhsPictogram> Pictograms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phrases", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GhsPhrase> Phrases { get; set; }
    
        [Newtonsoft.Json.JsonProperty("markets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GhsMarket> Markets { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartGhs 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int GhsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Ghs Ghs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Part 
    {
        [Newtonsoft.Json.JsonProperty("purchasedInMarketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PurchasedInMarketId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("purchasedInMarket", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Market PurchasedInMarket { get; set; }
    
        [Newtonsoft.Json.JsonProperty("purchasedInCity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PurchasedInCity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("purchasedInStore", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PurchasedInStore { get; set; }
    
        [Newtonsoft.Json.JsonProperty("competitiveProductMfgId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CompetitiveProductMfgId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("competitiveProductMfg", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompetitiveProductManufacturer CompetitiveProductMfg { get; set; }
    
        [Newtonsoft.Json.JsonProperty("otherManufacturer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OtherManufacturer { get; set; }
    
        [Newtonsoft.Json.JsonProperty("competitiveProductBrands", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartCompetitiveProductBrandt> CompetitiveProductBrands { get; set; }
    
        [Newtonsoft.Json.JsonProperty("variant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Variant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enclosure", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Enclosure { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enclosureMaterial", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EnclosureMaterial { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numberofPackages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? NumberofPackages { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dosesPerPack", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? DosesPerPack { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isFromCompass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsFromCompass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("keyType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string KeyType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compVersion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CompVersion { get; set; }
    
        [Newtonsoft.Json.JsonProperty("feedstockId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FeedstockId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isAnimalDerived", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsAnimalDerived { get; set; }
    
        [Newtonsoft.Json.JsonProperty("beefBseTseCertificationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BeefBseTseCertificationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantDerivedPercent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? PlantDerivedPercent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("halalCertifiedYesNoUnknownId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? HalalCertifiedYesNoUnknownId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containBiocidalPreservativesId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ContainBiocidalPreservativesId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containConflictMineralId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ContainConflictMineralId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sustainableSourcingId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SustainableSourcingId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("unavoidableImpuritiesId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? UnavoidableImpuritiesId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reachSupplierCommitLetterId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ReachSupplierCommitLetterId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bprSupplierCommitmentLetterId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BprSupplierCommitmentLetterId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("crystallineFreeYesNoUnknownId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CrystallineFreeYesNoUnknownId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("asbestosFreeYesNoUnknownId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AsbestosFreeYesNoUnknownId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("acceptableforuseCosmeticDrugId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AcceptableforuseCosmeticDrugId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colorantCertificationRegId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ColorantCertificationRegId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmPolicyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmStateId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStageId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmStageId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("formulationTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FormulationTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mcpManufacturerName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string McpManufacturerName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tradeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TradeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("casNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CasNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ecNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EcNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("environmentalClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? EnvironmentalClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("environmentalClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public EnvironmentalClass EnvironmentalClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mcpClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? McpClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mcpClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public McpClass McpClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("internalMaterialForId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InternalMaterialForId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("internalMaterialFor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public InternalMaterialFor InternalMaterialFor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartType PartType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartStatus PartStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isForPass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsForPass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isAllergen", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsAllergen { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isAutoGenerateName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsAutoGenerateName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isSubmittedForBosCalculation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsSubmittedForBosCalculation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasArt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasArt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originatorUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OriginatorUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ownerUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OwnerUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryOrganizationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PrimaryOrganizationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PartStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ingredientClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? IngredientClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryOrganization", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Organization PrimaryOrganization { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gbuId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GbuId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("categoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CategoryId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subCategoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SubCategoryId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reachStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ReachStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("registrationNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RegistrationNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturerSiteId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ManufacturerSiteId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("confidentialTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ConfidentialType ConfidentialTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sectorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SectorId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subSectorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SubSectorId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("globalFormId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GlobalFormId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productFormDetail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductFormDetail { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityClassificationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SecurityClassificationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? RegionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("standardsOffice", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StandardsOffice { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityProjectId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SecurityProjectId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("importStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ImportStatusValues ImportStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("importErrorMessage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ImportErrorMessage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("importPriority", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ImportPriority { get; set; }
    
        [Newtonsoft.Json.JsonProperty("importStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ImportStatus ImportStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oldKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OldKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("releaseDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ReleaseDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("feedstock", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Feedstock Feedstock { get; set; }
    
        [Newtonsoft.Json.JsonProperty("beefBseTseCertification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown BeefBseTseCertification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("halalCertified", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown HalalCertified { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containBiocidalPreservatives", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown ContainBiocidalPreservatives { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containConflictMineral", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown ContainConflictMineral { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sustainableSourcing", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown SustainableSourcing { get; set; }
    
        [Newtonsoft.Json.JsonProperty("unavoidableImpurities", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown UnavoidableImpurities { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reachSupplierCommitmentLetter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown ReachSupplierCommitmentLetter { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bprSupplierCommitmentLetter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown BprSupplierCommitmentLetter { get; set; }
    
        [Newtonsoft.Json.JsonProperty("crystallineFree", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown CrystallineFree { get; set; }
    
        [Newtonsoft.Json.JsonProperty("asbestosFree", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown AsbestosFree { get; set; }
    
        [Newtonsoft.Json.JsonProperty("acceptableforuseCosmeticDrugs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown AcceptableforuseCosmeticDrugs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colorantCertificationRegulation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public YesNoUnknown ColorantCertificationRegulation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmType PlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmPolicy PlmPolicy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmState PlmState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmStage PlmStage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("formulationType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FormulationType FormulationType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturerSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Vendor ManufacturerSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sector", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Sector Sector { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subSector", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SubSector SubSector { get; set; }
    
        [Newtonsoft.Json.JsonProperty("globalForm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GlobalForm GlobalForm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityClassification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SecurityClassification SecurityClassification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("region", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Region Region { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gbu", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Gbu Gbu { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subCategory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SubCategory SubCategory { get; set; }
    
        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Category Category { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reachStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ReachStatus ReachStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityProject", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SecurityProject SecurityProject { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ingredientClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IngredientClass IngredientClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("attributes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartAttribute> Attributes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionBom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionBom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionRdMaterialComp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionRdMaterialComp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionBos", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionBos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionGpsBos", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionGpsBos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionSri", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionSri { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionStartingMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionStartingMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionMeps", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionMeps { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionSeps", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionSeps { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionParentSeps", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionParentSeps { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionEps", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionEps { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionParts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionParts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionFc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionFc { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionFil", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionFil { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionPcl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionPcl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionIngredients", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionIngredients { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionDefinedMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionDefinedMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionAppDppBom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionAppDppBom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionComponentMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionComponentMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionPhasePhases", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionPhasePhases { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionPhaseMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionPhaseMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionFormulationToFop", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionFormulationToFop { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionFopToFormulation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionFopToFormulation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionAlternates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionAlternates { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionAssessmentSpec", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionAssessmentSpec { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionDerivedParts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionDerivedParts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionDerivedParentParts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionDerivedParentParts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionMasterChildren", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionMasterChildren { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionMasterParents", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionMasterParents { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionRelatedSpecifications", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionRelatedSpecifications { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionProducingFormulaParents", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> CompositionProducingFormulaParents { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcObjectId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcObjectId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originatingSystemUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OriginatingSystemUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originatingSystem", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User OriginatingSystem { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User Originator { get; set; }
    
        [Newtonsoft.Json.JsonProperty("owner", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User Owner { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessAreas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartBusinessArea> BusinessAreas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartProductCategoryPlatform> ProductCategoryPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productTechnologyChassies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartProductTechnologyChassis> ProductTechnologyChassies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productTechnologyPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartProductTechnologyPlatform> ProductTechnologyPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("franchises", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartFranchise> Franchises { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartSegment> Segments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("coOwners", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartContact> CoOwners { get; set; }
    
        [Newtonsoft.Json.JsonProperty("brands", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartBrand> Brands { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subBrands", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartSubBrand> SubBrands { get; set; }
    
        [Newtonsoft.Json.JsonProperty("secondaryOrganizations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartOrganization> SecondaryOrganizations { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ipClasses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartIpClass> IpClasses { get; set; }
    
        [Newtonsoft.Json.JsonProperty("inciAttributeRegions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartInciAttributeRegion> InciAttributeRegions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("notes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartNotes> Notes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityClasses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartSecurityClass> SecurityClasses { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityProjects", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartSecurityProject> SecurityProjects { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plants", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartPlant> Plants { get; set; }
    
        [Newtonsoft.Json.JsonProperty("performanceSpecs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PerformanceSpec> PerformanceSpecs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("documents", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartDocument> Documents { get; set; }
    
        [Newtonsoft.Json.JsonProperty("relatedSpecificationDocuments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartDocument> RelatedSpecificationDocuments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("masterPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MasterPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("masterPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part MasterPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("markets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartMarket> Markets { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketClearances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<MarketClearance> MarketClearances { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productForms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartProductForm> ProductForms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partFamilyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PartFamilyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partFamily", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartFamily PartFamily { get; set; }
    
        [Newtonsoft.Json.JsonProperty("identifier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Identifier { get; set; }
    
        [Newtonsoft.Json.JsonProperty("localDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LocalDescription { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sapDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SapDescription { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sapType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SapType SapType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sapTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SapTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reasonForChange", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReasonForChange { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originationDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? OriginationDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("validStartDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ValidStartDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("validUntilDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ValidUntilDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("archiveDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ArchiveDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("archiveReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ArchiveReason { get; set; }
    
        [Newtonsoft.Json.JsonProperty("archiveComment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ArchiveComment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("unarchiveDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? UnarchiveDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("unarchiveReason", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UnarchiveReason { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enoviaObjectId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EnoviaObjectId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcCreatedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? SrcCreatedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcModifiedById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SrcModifiedById { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcModifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User SrcModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcModifiedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? SrcModifiedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsCreatedById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GpsCreatedById { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsCreatedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User GpsCreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsCreatedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? GpsCreatedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsModifiedById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GpsModifiedById { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsModifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User GpsModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsModifiedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? GpsModifiedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isProduedByFormula", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsProduedByFormula { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aerosolTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AerosolTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aerosolType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AerosolType AerosolType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("availableOxygen", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AvailableOxygen { get; set; }
    
        [Newtonsoft.Json.JsonProperty("boilingPointId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BoilingPointId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("boilingPoint", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BoilingPoint BoilingPoint { get; set; }
    
        [Newtonsoft.Json.JsonProperty("boilingPointValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BoilingPointValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("burnRate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BurnRate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("canConstructionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CanConstructionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("canConstruction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CanConstruction CanConstruction { get; set; }
    
        [Newtonsoft.Json.JsonProperty("closedCupFlashpointId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ClosedCupFlashpointId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("closedCupFlashpoint", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ClosedCupFlashpoint ClosedCupFlashpoint { get; set; }
    
        [Newtonsoft.Json.JsonProperty("closedCupFlashpointValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClosedCupFlashpointValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ColorId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("color", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Color Color { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colorIntensityId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ColorIntensityId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colorIntensity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ColorIntensity ColorIntensity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("conductivity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Conductivity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("corrosivetoMetalsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CorrosivetoMetalsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("corrosivetoMetals", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CorrosivetoMetals CorrosivetoMetals { get; set; }
    
        [Newtonsoft.Json.JsonProperty("doestheProductContainsOxidizer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DoestheProductContainsOxidizer { get; set; }
    
        [Newtonsoft.Json.JsonProperty("encSpaceIgnitTimeEquiv", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EncSpaceIgnitTimeEquiv { get; set; }
    
        [Newtonsoft.Json.JsonProperty("evaporationRate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EvaporationRate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("flameDuration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FlameDuration { get; set; }
    
        [Newtonsoft.Json.JsonProperty("flameHeight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FlameHeight { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gaugePressure", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GaugePressure { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heatOfCombustion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HeatOfCombustion { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heatOfDecomposition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HeatOfDecomposition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ignitionDistance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IgnitionDistance { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isAerosolTestDataNeededId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? IsAerosolTestDataNeededId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isAerosolTestDataNeeded", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AerosolTestData IsAerosolTestDataNeeded { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isThermallyUnstable", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsThermallyUnstable { get; set; }
    
        [Newtonsoft.Json.JsonProperty("canIncrBurnRateIntensity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? CanIncrBurnRateIntensity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isFlammableLiquidInTheSolid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsFlammableLiquidInTheSolid { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dynamicViscosity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DynamicViscosity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("odour", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Odour { get; set; }
    
        [Newtonsoft.Json.JsonProperty("organicPeroxide", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OrganicPeroxide { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oxidizerHydrogenPeroxide", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? OxidizerHydrogenPeroxide { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oxidizerSodiumPerCarbonate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? OxidizerSodiumPerCarbonate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phAvailabilityId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PhAvailabilityId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phAvailability", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PHAvailability PhAvailability { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ph", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Ph { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phDilutionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PhDilutionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phDilution", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PhDilution PhDilution { get; set; }
    
        [Newtonsoft.Json.JsonProperty("relativeDensity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RelativeDensity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reserveAcidity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ReserveAcidity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reserveAlkalinity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ReserveAlkalinity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("selfAcceleratingDecompTemp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SelfAcceleratingDecompTemp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sustainCombustion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SustainCombustion { get; set; }
    
        [Newtonsoft.Json.JsonProperty("technicalBasis", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TechnicalBasis { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaporDensity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaporDensity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaporPressure", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaporPressure { get; set; }
    
        [Newtonsoft.Json.JsonProperty("batteryTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BatteryTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("batteryType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BatteryType BatteryType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isBattery", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsBattery { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containsBattery", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? ContainsBattery { get; set; }
    
        [Newtonsoft.Json.JsonProperty("batteryChemicalComposition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BatteryChemicalComposition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numberOfCells", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? NumberOfCells { get; set; }
    
        [Newtonsoft.Json.JsonProperty("batteryWeight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BatteryWeight { get; set; }
    
        [Newtonsoft.Json.JsonProperty("batteryWeightUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BatteryWeightUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("batteryWeightUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BatteryWeightUom BatteryWeightUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gramsOfLithiumId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GramsOfLithiumId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gramsOfLithium", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GramsOfLithiumUom GramsOfLithium { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isAButtonBattery", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsAButtonBattery { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lithiumBatteryEnergy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LithiumBatteryEnergy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lithiumBatteryEnergyUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? LithiumBatteryEnergyUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lithiumBatteryEnergyUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LithiumBatteryEnergyUom LithiumBatteryEnergyUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("nominalVoltage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NominalVoltage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("nominalVoltageUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? NominalVoltageUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("nominalVoltageUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public NominalVoltageUom NominalVoltageUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numCellsShippedInsideDevice", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? NumCellsShippedInsideDevice { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numCellsShippedOutsideDevice", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? NumCellsShippedOutsideDevice { get; set; }
    
        [Newtonsoft.Json.JsonProperty("typicalCapacity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TypicalCapacity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("typicalCapacityUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TypicalCapacityUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("typicalCapacityUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TypicalCapacityUom TypicalCapacityUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("otherNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OtherNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("densityVal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? DensityVal { get; set; }
    
        [Newtonsoft.Json.JsonProperty("densityUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? DensityUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("densityUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DensityUom DensityUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("onShelfDensity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? OnShelfDensity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturingStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ManufacturingStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturingStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ManufacturingStatus ManufacturingStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("grossWeight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? GrossWeight { get; set; }
    
        [Newtonsoft.Json.JsonProperty("grossWeightUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GrossWeightUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("grossWeightUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom GrossWeightUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("grossWeightComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GrossWeightComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("authoringApplicationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AuthoringApplicationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("authoringApplication", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AuthoringApplication { get; set; }
    
        [Newtonsoft.Json.JsonProperty("configurationType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ConfigurationType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("releaseCriteriaRequired", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ReleaseCriteriaRequired { get; set; }
    
        [Newtonsoft.Json.JsonProperty("previousRevisionObsoleteDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? PreviousRevisionObsoleteDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCertificationRequired", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? ProductCertificationRequired { get; set; }
    
        [Newtonsoft.Json.JsonProperty("certifications", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Certifications { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialCertifications", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<MaterialCertification> MaterialCertifications { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPerUseDosageVal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPerUseDosageVal { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPerUseDosageUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ProductPerUseDosageUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPerUseDosageUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DosageUom ProductPerUseDosageUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedFrequencyVal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExpectedFrequencyVal { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedFrequencyUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ExpectedFrequencyUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedFrequencyUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FrequencyUom ExpectedFrequencyUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modeOfProductDisposalId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ModeOfProductDisposalId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modeOfProductDisposal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ModeOfProductDisposal ModeOfProductDisposal { get; set; }
    
        [Newtonsoft.Json.JsonProperty("powerSourceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PowerSourceId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("powerSource", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PowerSource PowerSource { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productExposedToChildren", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? ProductExposedToChildren { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketedAsChildProduct", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? MarketedAsChildProduct { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requiresChildSafeDesign", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? RequiresChildSafeDesign { get; set; }
    
        [Newtonsoft.Json.JsonProperty("template", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Template { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assemblyType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssemblyType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("majorVersion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MajorVersion { get; set; }
    
        [Newtonsoft.Json.JsonProperty("minorVersion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MinorVersion { get; set; }
    
        [Newtonsoft.Json.JsonProperty("activeStartDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ActiveStartDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("activeSinceSpecified", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ActiveSinceSpecified { get; set; }
    
        [Newtonsoft.Json.JsonProperty("activeUntilDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ActiveUntilDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("activeUntilSpecified", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ActiveUntilSpecified { get; set; }
    
        [Newtonsoft.Json.JsonProperty("safetyNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SafetyNotes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulatoryNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RegulatoryNotes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("generalComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GeneralComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isExperimental", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsExperimental { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isImplement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsImplement { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isIntermediate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsIntermediate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFunctions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartSrcFunction> SrcFunctions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartFunction> Functions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("replacedProductName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReplacedProductName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aslAllocation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AslAllocation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SubType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isTemplate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsTemplate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SecurityStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("entryBaseQuantity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EntryBaseQuantity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("technology", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Technology { get; set; }
    
        [Newtonsoft.Json.JsonProperty("formName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FormName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("clearanceNeeded", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClearanceNeeded { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gelatinSource", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GelatinSource { get; set; }
    
        [Newtonsoft.Json.JsonProperty("kosher", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Kosher { get; set; }
    
        [Newtonsoft.Json.JsonProperty("printPattern", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PrintPattern { get; set; }
    
        [Newtonsoft.Json.JsonProperty("intendedMarkets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IntendedMarkets { get; set; }
    
        [Newtonsoft.Json.JsonProperty("brandInformation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BrandInformation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productExtraVariants", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductExtraVariants { get; set; }
    
        [Newtonsoft.Json.JsonProperty("shippingHazards", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ShippingHazards { get; set; }
    
        [Newtonsoft.Json.JsonProperty("baseQuantity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? BaseQuantity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("baseUnitOfMeasureId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BaseUnitOfMeasureId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("baseUnitOfMeasure", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom BaseUnitOfMeasure { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialGroup", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaterialGroup { get; set; }
    
        [Newtonsoft.Json.JsonProperty("appearance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Appearance { get; set; }
    
        [Newtonsoft.Json.JsonProperty("attachments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Attachments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bulkStorageRequirements", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BulkStorageRequirements { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bulkTestComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BulkTestComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("formulaClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FormulaClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("designPurchase", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DesignPurchase { get; set; }
    
        [Newtonsoft.Json.JsonProperty("endItem", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EndItem { get; set; }
    
        [Newtonsoft.Json.JsonProperty("endItemOverrideEnabled", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EndItemOverrideEnabled { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fillingRequirements", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FillingRequirements { get; set; }
    
        [Newtonsoft.Json.JsonProperty("generalRequirements", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GeneralRequirements { get; set; }
    
        [Newtonsoft.Json.JsonProperty("inciDeclaration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InciDeclaration { get; set; }
    
        [Newtonsoft.Json.JsonProperty("kindOfProduct", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string KindOfProduct { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturerLines", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ManufacturerLines { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturerVendorNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ManufacturerVendorNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturingEquipment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ManufacturingEquipment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturingProcedure", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ManufacturingProcedure { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturingProcedureComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ManufacturingProcedureComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialCategory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaterialCategory { get; set; }
    
        [Newtonsoft.Json.JsonProperty("nextProcessNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NextProcessNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("packagingShipping", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PackagingShipping { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Plant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productDataView", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductDataView { get; set; }
    
        [Newtonsoft.Json.JsonProperty("qualityControlData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string QualityControlData { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sectionName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SectionName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("shelfLife", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ShelfLife { get; set; }
    
        [Newtonsoft.Json.JsonProperty("shippingInstructions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ShippingInstructions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sparePart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SparePart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("storageConditions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StorageConditions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("storageHumidityLimits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StorageHumidityLimits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("storageInformation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StorageInformation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("storageTemperatureLimits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StorageTemperatureLimits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("storagePrecautions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StoragePrecautions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vendorType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VendorType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("weighingSheet", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WeighingSheet { get; set; }
    
        [Newtonsoft.Json.JsonProperty("weight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Weight { get; set; }
    
        [Newtonsoft.Json.JsonProperty("postConsumerRecycledContent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? PostConsumerRecycledContent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaterialClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MaterialClass MaterialClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialSubclassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaterialSubclassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialSubclass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MaterialSubclass MaterialSubclass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("specificationSubtypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SpecificationSubtypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("specificationSubtype", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SpecificationSubtype SpecificationSubtype { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reviewInProcessStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ReviewInProcessStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reviewInProcessStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ReviewInProcessStatus ReviewInProcessStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reviewedStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ReviewedStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reviewedStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ReviewedStatus ReviewedStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasRxChemistry", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasRxChemistry { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isGpsBosOutDated", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsGpsBosOutDated { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reserveAlkalAcidPhTitration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReserveAlkalAcidPhTitration { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isAqueousSolution", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsAqueousSolution { get; set; }
    
        [Newtonsoft.Json.JsonProperty("deviceContainsFlammableLiquid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? DeviceContainsFlammableLiquid { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phMin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? PhMin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("phMax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? PhMax { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reserveAlkalinityAcidityUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ReserveAlkalinityAcidityUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reserveAlkalinityAcidityUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ReserveAlkalinityAcidityUom ReserveAlkalinityAcidityUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dangerousGoods", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartDangerousGoods> DangerousGoods { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ghs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartGhs> Ghs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum CompositionBosCompostionGroupEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Fragrance")]
        Fragrance = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Disclosed")]
        Disclosed = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Confidential")]
        Confidential = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"GpsAdd")]
        GpsAdd = 3,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum ActiveImpurityCarryover
    {
        [System.Runtime.Serialization.EnumMember(Value = @"None")]
        None = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Active")]
        Active = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Impurity")]
        Impurity = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Carryover")]
        Carryover = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"UnintentionalNatural")]
        UnintentionalNatural = 4,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PqrPlant 
    {
        [Newtonsoft.Json.JsonProperty("pqrId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PqrId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PlantId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pqr", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Pqr Pqr { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Plant Plant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Pqr 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PlmStateId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmState PlmState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pqrPlants", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PqrPlant> PqrPlants { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionPqr 
    {
        [Newtonsoft.Json.JsonProperty("compId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CompId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pqrId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PqrId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionRecord", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Composition CompositionRecord { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pqr", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Pqr Pqr { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Composition 
    {
        [Newtonsoft.Json.JsonProperty("parentPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ParentPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentCompId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ParentCompId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ChildPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompositionStatus CompositionStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CompositionStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OriginId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("origin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Origin Origin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oldFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OldFunctionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oldIngredientNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OldIngredientNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oldOptionalCompId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OldOptionalCompId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oldOptionalGroup", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OldOptionalGroup { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasSubstitutes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasSubstitutes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sequence", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Sequence { get; set; }
    
        [Newtonsoft.Json.JsonProperty("unflattenCombinationNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? UnflattenCombinationNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CompTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompositionType CompositionType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SrcUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom SrcUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcLoss", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcLoss { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcDryWeight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcDryWeight { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcDryPercent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcDryPercent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcWetWeight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcWetWeight { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcWetWeightLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcWetWeightLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcWetWeightHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcWetWeightHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcWeightUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SrcWeightUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcWeightUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom SrcWeightUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFilSubTotal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcFilSubTotal { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFilSubTotalUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SrcFilSubTotalUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFilSubTotalUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom SrcFilSubTotalUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcLossUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SrcLossUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcLossUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom SrcLossUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcWetPercent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcWetPercent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcNetWeight", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcNetWeight { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcNetWeightUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SrcNetWeightUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcNetWeightUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom SrcNetWeightUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("postConsumerRecyclePercent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? PostConsumerRecyclePercent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CompositionFunction> Functions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFunctions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CompositionSrcFunction> SrcFunctions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("qaTargetId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? QaTargetId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("qaTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public QaTarget QaTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("contaminant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? Contaminant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("change", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Change { get; set; }
    
        [Newtonsoft.Json.JsonProperty("processingNote", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProcessingNote { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("validStartDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ValidStartDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("validUntilDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ValidUntilDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part ParentPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part ChildPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isSds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bosCompostionGroup", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CompositionBosCompostionGroupEnum BosCompostionGroup { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substituteFor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Composition SubstituteFor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substitutes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> Substitutes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("flatSubstitutes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> FlatSubstitutes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ActiveImpurityCarryover Aic { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pqrs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CompositionPqr> Pqrs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("processingFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ProcessingFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isPartCompositionComplete", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsPartCompositionComplete { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum CalculationSourceType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"RdBos")]
        RdBos = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"GpsFlattenedBom")]
        GpsFlattenedBom = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"GpsBos")]
        GpsBos = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum CalculationSourceFlag
    {
        [System.Runtime.Serialization.EnumMember(Value = @"FromGpsComposition")]
        FromGpsComposition = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"IgnoredFromGpsComposition")]
        IgnoredFromGpsComposition = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"FromRdBos")]
        FromRdBos = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"IgnoredFragranceFromRdBos")]
        IgnoredFragranceFromRdBos = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"IgnoredConfidentialActiveFromRdBos")]
        IgnoredConfidentialActiveFromRdBos = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = @"IgnoredBomReactionDryWeightPadderFromRdBom")]
        IgnoredBomReactionDryWeightPadderFromRdBom = 5,
    
        [System.Runtime.Serialization.EnumMember(Value = @"AutomaticallyAddedMissingRdBom")]
        AutomaticallyAddedMissingRdBom = 6,
    
        [System.Runtime.Serialization.EnumMember(Value = @"FormulaCardFromAssembledProductRdBom")]
        FormulaCardFromAssembledProductRdBom = 7,
    
        [System.Runtime.Serialization.EnumMember(Value = @"IgnoredAutomaticallyAddedMissingMaterialRdSpec")]
        IgnoredAutomaticallyAddedMissingMaterialRdSpec = 8,
    
        [System.Runtime.Serialization.EnumMember(Value = @"IgnoredFromRdBom")]
        IgnoredFromRdBom = 9,
    
        [System.Runtime.Serialization.EnumMember(Value = @"OverriddenFromGpsComposition")]
        OverriddenFromGpsComposition = 10,
    
        [System.Runtime.Serialization.EnumMember(Value = @"IgnoredFromIntermediateBos")]
        IgnoredFromIntermediateBos = 11,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CalculatedCompositionSource 
    {
        [Newtonsoft.Json.JsonProperty("parentPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part ParentPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sourceType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CalculationSourceType SourceType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sourceFlag", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CalculationSourceFlag SourceFlag { get; set; }
    
        [Newtonsoft.Json.JsonProperty("composition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Composition Composition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeMin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPartRelativeMin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPartRelativeTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeMax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPartRelativeMax { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeProcessingFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ProductPartRelativeProcessingFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeMinWithProcessingFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPartRelativeMinWithProcessingFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeTargetWithProcessingFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPartRelativeTargetWithProcessingFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeMaxWithProcessingFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPartRelativeMaxWithProcessingFactor { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CalculatedComposition 
    {
        [Newtonsoft.Json.JsonProperty("containedPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part ContainedPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sources", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculatedCompositionSource> Sources { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum CalculationIssueTypes
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Error")]
        Error = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"WarnIfReactionOrLossExists")]
        WarnIfReactionOrLossExists = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Warn")]
        Warn = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CalculationIssue 
    {
        [Newtonsoft.Json.JsonProperty("issueText", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IssueText { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part ProductPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("intermediatePart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part IntermediatePart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rawMaterialPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part RawMaterialPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sriPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part SriPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substancePart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part SubstancePart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CalculationIssueTypes Type { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Timings 
    {
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, string> Data { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RawMaterialDetails 
    {
        [Newtonsoft.Json.JsonProperty("rawMaterial", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part RawMaterial { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rdSpec", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> RdSpec { get; set; }
    
        [Newtonsoft.Json.JsonProperty("asmtSpec", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> AsmtSpec { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsAdditive", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> GpsAdditive { get; set; }
    
        [Newtonsoft.Json.JsonProperty("asmtSpecOriginalPerfumes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> AsmtSpecOriginalPerfumes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsNonAdditive", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> GpsNonAdditive { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productsThisRmIsIn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Part> ProductsThisRmIsIn { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SharedCalculationContextAllCompositionsCache 
    {
        [Newtonsoft.Json.JsonProperty("byCompositionType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<Composition>> ByCompositionType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("byCompositionTypeAndParentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<Composition>>> ByCompositionTypeAndParentId { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SharedCalculationContext 
    {
        [Newtonsoft.Json.JsonProperty("timings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Timings Timings { get; set; }
    
        [Newtonsoft.Json.JsonProperty("createdWithPartIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> CreatedWithPartIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assesmentSpecValidationMarginOfError", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double AssesmentSpecValidationMarginOfError { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bosValidationMarginOfError", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double BosValidationMarginOfError { get; set; }
    
        [Newtonsoft.Json.JsonProperty("postReactionMaterial", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part PostReactionMaterial { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fragrance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Fragrance { get; set; }
    
        [Newtonsoft.Json.JsonProperty("confidentialActive", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part ConfidentialActive { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rawMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, RawMaterialDetails> RawMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierMaterialSubstanceCompositions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<Composition>> SupplierMaterialSubstanceCompositions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionCache", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SharedCalculationContextAllCompositionsCache CompositionCache { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partLookup", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, Part> PartLookup { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> Compositions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partIdsAllowedToBeReactedOut", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PartIdsAllowedToBeReactedOut { get; set; }
    
        [Newtonsoft.Json.JsonProperty("forSds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ForSds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("useSavedGpsBos", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UseSavedGpsBos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isSdsSpecific", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSdsSpecific { get; set; }
    
        [Newtonsoft.Json.JsonProperty("forMepSep", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ForMepSep { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeGpsConfidentialComposition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeGpsConfidentialComposition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeFragranceComposition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeFragranceComposition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allPrimaryOrganizations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Organization> AllPrimaryOrganizations { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartCalculationContext 
    {
        [Newtonsoft.Json.JsonProperty("calculationPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part CalculationPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sharedCalculationContext", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SharedCalculationContext SharedCalculationContext { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentPartCalculationContext", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartCalculationContext ParentPartCalculationContext { get; set; }
    
        [Newtonsoft.Json.JsonProperty("issues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> Issues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPartCalculationContexts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartCalculationContext> ChildPartCalculationContexts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> DirectIssues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directErrors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> DirectErrors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directEffectiveIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> DirectEffectiveIssues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculationIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> CalculationIssues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculationEffectiveIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> CalculationEffectiveIssues { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ProductCalculationContext 
    {
        [Newtonsoft.Json.JsonProperty("hasRootErrorAndSoDontGenerateExcel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HasRootErrorAndSoDontGenerateExcel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("intermediateBillOfSubstance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ProductCalculationContext> IntermediateBillOfSubstance { get; set; }
    
        [Newtonsoft.Json.JsonProperty("deepIntermediateBillOfSubstance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ProductCalculationContext> DeepIntermediateBillOfSubstance { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rdBom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> RdBom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rdBos", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Composition> RdBos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsAdditiveBos", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculatedComposition> GpsAdditiveBos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsNonAdditiveBos", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculatedComposition> GpsNonAdditiveBos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsCalculatedBos", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculatedComposition> GpsCalculatedBos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("everything", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculatedComposition> Everything { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rdFlattenedBom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculatedComposition> RdFlattenedBom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsCalculatedBosOld", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculatedComposition> GpsCalculatedBosOld { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containsReaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainsReaction { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containsEnvironmentalLoss", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainsEnvironmentalLoss { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directEffectiveIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> DirectEffectiveIssues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containedRawMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Part> ContainedRawMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("perfumeRoundToDecimalPlaces", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PerfumeRoundToDecimalPlaces { get; set; }
    
        [Newtonsoft.Json.JsonProperty("perfumeMarginOfError", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? PerfumeMarginOfError { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculationPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part CalculationPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sharedCalculationContext", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SharedCalculationContext SharedCalculationContext { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentPartCalculationContext", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartCalculationContext ParentPartCalculationContext { get; set; }
    
        [Newtonsoft.Json.JsonProperty("issues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> Issues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPartCalculationContexts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartCalculationContext> ChildPartCalculationContexts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> DirectIssues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directErrors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> DirectErrors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculationIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> CalculationIssues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculationEffectiveIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> CalculationEffectiveIssues { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SriCalculationContext 
    {
        [Newtonsoft.Json.JsonProperty("rawMaterialPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part RawMaterialPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sriPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part SriPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directEffectiveIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> DirectEffectiveIssues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculationPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part CalculationPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sharedCalculationContext", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SharedCalculationContext SharedCalculationContext { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentPartCalculationContext", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartCalculationContext ParentPartCalculationContext { get; set; }
    
        [Newtonsoft.Json.JsonProperty("issues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> Issues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPartCalculationContexts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartCalculationContext> ChildPartCalculationContexts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> DirectIssues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directErrors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> DirectErrors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculationIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> CalculationIssues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculationEffectiveIssues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CalculationIssue> CalculationEffectiveIssues { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SearchPartResult 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSrcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSrcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partImportStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartImportStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTradeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartTradeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypeCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartTypeCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partGbuName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartGbuName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partConfidentialTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartConfidentialTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partCasNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartCasNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partIsExperimental", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? PartIsExperimental { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSecurityClassification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSecurityClassification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partStatusName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartStatusName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmPolicyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmPolicyName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmStateName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmStateName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmStageName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmStageName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partIngredientClassName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartIngredientClassName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partCategoryName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartCategoryName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSubCategoryName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSubCategoryName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSegmentName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSegmentName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSectorName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSectorName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSubSectorName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSubSectorName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPrimaryOrganizationName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPrimaryOrganizationName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partMasterPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PartMasterPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partMasterPartKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartMasterPartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partManufacturerSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartManufacturerSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessAreas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> BusinessAreas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ProductCategoryPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partReviewedStatusName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartReviewedStatusName { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SearchCompositionResult 
    {
        [Newtonsoft.Json.JsonProperty("compId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CompId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ChildPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SearchPartResult ChildPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsituteForCompId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SubsituteForCompId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CompositionTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sequence", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Sequence { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasSubstitutes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasSubstitutes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasError", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasError { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isBom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsBom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isDhi", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsDhi { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Aic { get; set; }
    
        [Newtonsoft.Json.JsonProperty("level", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Level { get; set; }
    
        [Newtonsoft.Json.JsonProperty("path", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Path { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Functions { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotClientBillOfSubstanceSourceResult 
    {
        [Newtonsoft.Json.JsonProperty("source", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CalculationSourceType Source { get; set; }
    
        [Newtonsoft.Json.JsonProperty("flag", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public CalculationSourceFlag Flag { get; set; }
    
        [Newtonsoft.Json.JsonProperty("composition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SearchCompositionResult Composition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeMin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPartRelativeMin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPartRelativeTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPartRelativeMax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ProductPartRelativeMax { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotClientBillOfSubstanceEntryResult 
    {
        [Newtonsoft.Json.JsonProperty("sources", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DepotClientBillOfSubstanceSourceResult> Sources { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CompId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ChildPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SearchPartResult ChildPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsituteForCompId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SubsituteForCompId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CompositionTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sequence", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Sequence { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasSubstitutes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasSubstitutes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasError", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasError { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isBom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsBom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isDhi", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsDhi { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Aic { get; set; }
    
        [Newtonsoft.Json.JsonProperty("level", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Level { get; set; }
    
        [Newtonsoft.Json.JsonProperty("path", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Path { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Functions { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotClientBillOfSubstanceResult
	{
        [Newtonsoft.Json.JsonProperty("productPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SearchPartResult ProductPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containsReaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainsReaction { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containsEnvironmentalLoss", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainsEnvironmentalLoss { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isSDSSpecific", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSDSSpecific { get; set; }
    
        [Newtonsoft.Json.JsonProperty("warnings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Warnings { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Errors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("flattenedBillOfMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SearchCompositionResult> FlattenedBillOfMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculatedBillOfSubstance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<DepotClientBillOfSubstanceEntryResult> CalculatedBillOfSubstance { get; set; }
    
        [Newtonsoft.Json.JsonProperty("designBillOfSubstance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SearchCompositionResult> DesignBillOfSubstance { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotClientAssessmentSpecResult 
    {
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SearchPartResult Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculatedComponents", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SearchCompositionResult> CalculatedComponents { get; set; }
    
        [Newtonsoft.Json.JsonProperty("warnings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Warnings { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Errors { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ClearancesControllerFindPartClearancesRequest 
    {
        [Newtonsoft.Json.JsonProperty("includeArchivedPartClearances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeArchivedPartClearances { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeObsoleteParts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeObsoleteParts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKeys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartKeys { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Segments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Functions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Regions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("minimumClearanceLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MinimumClearanceLevel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maxRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MaxRows { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ClearancesControllerFindPartClearancesRequestV2 
    {
        [Newtonsoft.Json.JsonProperty("includeInactivePartClearances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeInactivePartClearances { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeOnlyReleasedParts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeOnlyReleasedParts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeUnconnectedSupplierMaterial", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeUnconnectedSupplierMaterial { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isPartKeysForRawMaterialOnly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsPartKeysForRawMaterialOnly { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKeys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartKeys { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessArea", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BusinessArea { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ProductCategoryPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Functions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaterialClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialSubclass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaterialSubclass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Regions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("minimumClearanceLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MinimumClearanceLevel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maxRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MaxRows { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartClearanceV2 
    {
        [Newtonsoft.Json.JsonProperty("partKeyRev", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKeyRev { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierMaterialTradeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierMaterialTradeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierMaterialKeyRev", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierMaterialKeyRev { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierMaterialType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierMaterialType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierMaterialPassStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierMaterialPassStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierMaterialPlmState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierMaterialPlmState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("linkedSriKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LinkedSriKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("clearanceLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClearanceLevel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maxClearedAmount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? MaxClearedAmount { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maxClearedAmountUnit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaxClearedAmountUnit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestMucSeq", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestMucSeq { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rsrNumbers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RsrNumbers { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partBusinessAreas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartBusinessAreas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partProductCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartProductCategoryPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partFunctions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartFunctions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partMaterialClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartMaterialClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partMaterialSubclass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartMaterialSubclass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessedBusinessArea", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessedBusinessArea { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessedFunctions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> AssessedFunctions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isPartClearanceInactive", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsPartClearanceInactive { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isPartReleased", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsPartReleased { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isSupplierMaterialReleased", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsSupplierMaterialReleased { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessedProductCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> AssessedProductCategoryPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Regions { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ClearancesControllerCreateAppGmrXlsxRequest 
    {
        [Newtonsoft.Json.JsonProperty("partKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatform", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductCategoryPlatform { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionControllerCompositionArguments 
    {
        [Newtonsoft.Json.JsonProperty("term", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Term { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionControllerLineageParamaters 
    {
        [Newtonsoft.Json.JsonProperty("parentPartIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> ParentPartIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childPartIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> ChildPartIds { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class LineageResult 
    {
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partCasNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartCasNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Aic { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ParentPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentPartKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ParentPartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentPartName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ParentPartName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CompositionTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isDhi", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsDhi { get; set; }
    
        [Newtonsoft.Json.JsonProperty("level", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Level { get; set; }
    
        [Newtonsoft.Json.JsonProperty("path", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Path { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isLeaf", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsLeaf { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionControllerLookupCompForKeyArguments 
    {
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> CompositionTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maxLevels", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaxLevels { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionControllerReverseLookupCompForKeyArguments 
    {
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> CompositionTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("next", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Next { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Offset { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionContainsRequest 
    {
        [Newtonsoft.Json.JsonProperty("parentsToSearch", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ParentsToSearch { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childrenToFind", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ChildrenToFind { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionContainsParentsResponse 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isActiveOrReviewed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsActiveOrReviewed { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isPartFound", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsPartFound { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isIncluded", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsIncluded { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionContainsChildrenResponse 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isPartFound", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsPartFound { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isIncluded", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsIncluded { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompositionContainsSearchResultResponse 
    {
        [Newtonsoft.Json.JsonProperty("parentKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ParentKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ChildKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("source", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Source { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CompType { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CompostionContainsResponse 
    {
        [Newtonsoft.Json.JsonProperty("parentsSearched", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CompositionContainsParentsResponse> ParentsSearched { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childrenSearchedFor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CompositionContainsChildrenResponse> ChildrenSearchedFor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("matches", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CompositionContainsSearchResultResponse> Matches { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartMatch 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }
    
        [Newtonsoft.Json.JsonProperty("commonName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CommonName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Category { get; set; }
    
        [Newtonsoft.Json.JsonProperty("application", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Application { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasConstituents", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HasConstituents { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rqNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RqNumber { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum TypeOfConcentration
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Low")]
        Low = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Target")]
        Target = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"High")]
        High = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Tpe 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("scenario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Scenario { get; set; }
    
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Type { get; set; }
    
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Label { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Calculation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("units", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Units { get; set; }
    
        [Newtonsoft.Json.JsonProperty("moe", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Moe { get; set; }
    
        [Newtonsoft.Json.JsonProperty("cpterm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Cpterm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("prop65", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Prop65 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCsl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsCsl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calcValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CalcValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("decimalCalcValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double DecimalCalcValue { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TpeHierarchyRequest 
    {
        [Newtonsoft.Json.JsonProperty("useFpc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UseFpc { get; set; }
    
        [Newtonsoft.Json.JsonProperty("cslType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CslType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfConcentration ConcentrationType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Category { get; set; }
    
        [Newtonsoft.Json.JsonProperty("product", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Product { get; set; }
    
        [Newtonsoft.Json.JsonProperty("scenario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Scenario { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FactorType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Factor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Concentration { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StudyType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maceStudyType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaceStudyType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpeValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double TpeValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("siteFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double SiteFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpe", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Tpe Tpe { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class LookupOfint 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class LookupOfstring 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class LineageGridRow 
    {
        [Newtonsoft.Json.JsonProperty("formulationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FormulationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rawMaterialId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RawMaterialId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rawMaterialLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? RawMaterialLevel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("finishedProductLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? FinishedProductLevel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("path", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Path { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class LineageGridResponse 
    {
        [Newtonsoft.Json.JsonProperty("constituentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ConstituentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("constituentName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ConstituentName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LineageGridRow> Rows { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GridResults 
    {
        [Newtonsoft.Json.JsonProperty("primaryIdentifier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PrimaryIdentifier { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }
    
        [Newtonsoft.Json.JsonProperty("cas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Cas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("conc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Conc { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numericLimit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? NumericLimit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Limit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("decimalLimit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? DecimalLimit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calcLimit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CalcLimit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("relative", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Relative { get; set; }
    
        [Newtonsoft.Json.JsonProperty("absolute", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Absolute { get; set; }
    
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Type { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bioAvail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? BioAvail { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substanceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SubstanceId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentSubstanceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ParentSubstanceId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maceComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaceComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bioComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BioComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("crfid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Crfid { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("displayType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DisplayType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rowColor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RowColor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("crfLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CrfLink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lineageLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LineageLink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("smartLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SmartLink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rqNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RqNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("empId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EmpId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("low", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Low { get; set; }
    
        [Newtonsoft.Json.JsonProperty("target", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Target { get; set; }
    
        [Newtonsoft.Json.JsonProperty("high", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double High { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maceType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaceType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dose", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Dose { get; set; }
    
        [Newtonsoft.Json.JsonProperty("units", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Units { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mos", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Mos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public TpeHierarchyRequest Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("historicPercentage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? HistoricPercentage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("historicRqNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HistoricRqNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasHistoricValues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HasHistoricValues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rawMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> RawMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rawMaterialItems", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> RawMaterialItems { get; set; }
    
        [Newtonsoft.Json.JsonProperty("smartItems", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> SmartItems { get; set; }
    
        [Newtonsoft.Json.JsonProperty("smartLinks", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfstring> SmartLinks { get; set; }
    
        [Newtonsoft.Json.JsonProperty("smartNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SmartNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lineage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LineageGridResponse Lineage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Errors { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SubGridResponse 
    {
        [Newtonsoft.Json.JsonProperty("header", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Header { get; set; }
    
        [Newtonsoft.Json.JsonProperty("results", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GridResults> Results { get; set; }
    
        [Newtonsoft.Json.JsonProperty("totalConcentration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double TotalConcentration { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PnMace 
    {
        [Newtonsoft.Json.JsonProperty("alias", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Alias { get; set; }
    
        [Newtonsoft.Json.JsonProperty("endpointName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EndpointName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StudyType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dose", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Dose { get; set; }
    
        [Newtonsoft.Json.JsonProperty("doseUnit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DoseUnit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numericDose", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? NumericDose { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ConstituentExposure 
    {
        [Newtonsoft.Json.JsonProperty("gcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gcas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryIdentifier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PrimaryIdentifier { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpe", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Tpe Tpe { get; set; }
    
        [Newtonsoft.Json.JsonProperty("conc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double Conc { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calcValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double CalcValue { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GridResponse 
    {
        [Newtonsoft.Json.JsonProperty("gcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartMatch Gcas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("results", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GridResults> Results { get; set; }
    
        [Newtonsoft.Json.JsonProperty("totalConcentration", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double TotalConcentration { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subGrid", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SubGridResponse SubGrid { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pnMaceValues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PnMace> PnMaceValues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Tpe> Tpes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("constituentExposures", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ConstituentExposure> ConstituentExposures { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class HabitsAndPractices 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }
    
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }
    
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Unit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reference", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Reference { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numericValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? NumericValue { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum TypeOfDisplay
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Constituent")]
        Constituent = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Material")]
        Material = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SaveMulitGridValuesRequest 
    {
        [Newtonsoft.Json.JsonProperty("grids", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GridResponse> Grids { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bosOnly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? BosOnly { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeAlternates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeAlternates { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Category { get; set; }
    
        [Newtonsoft.Json.JsonProperty("product", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Product { get; set; }
    
        [Newtonsoft.Json.JsonProperty("habit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Habit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FactorType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Factor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("categoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CategoryId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ProductId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("habitId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HabitId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FactorTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FactorId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sensitizationAssessmentFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double SensitizationAssessmentFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationInFormula", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ConcentrationInFormula { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpeRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Tpe> TpeRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hnpRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<HabitsAndPractices> HnpRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfConcentration ConcentrationType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("displayType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfDisplay DisplayType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeSubs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeSubs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hideGreenRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HideGreenRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeBff", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeBff { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includePnMace", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludePnMace { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeFanOut", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeFanOut { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum TypeOfRequestPart
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Unknown")]
        Unknown = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Standard")]
        Standard = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"BosReviewed")]
        BosReviewed = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"PlmAllowed")]
        PlmAllowed = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"MfgAllowed")]
        MfgAllowed = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = @"PrefixAllowed")]
        PrefixAllowed = 5,
    
        [System.Runtime.Serialization.EnumMember(Value = @"ProductFormAllowed")]
        ProductFormAllowed = 6,
    
        [System.Runtime.Serialization.EnumMember(Value = @"BusinessAreaPlmStageAllowed")]
        BusinessAreaPlmStageAllowed = 7,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PreCheckBosRequestResponse 
    {
        [Newtonsoft.Json.JsonProperty("requestPartType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfRequestPart RequestPartType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestPartTypeState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestPartTypeState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isError", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsError { get; set; }
    
        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("additionalInformation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AdditionalInformation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errorMessage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("notificationMessage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NotificationMessage { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SaveGridValuesRequest 
    {
        [Newtonsoft.Json.JsonProperty("commonName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CommonName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mainGridResults", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GridResults> MainGridResults { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subGridresults", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<GridResults> SubGridresults { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pnMaceValues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PnMace> PnMaceValues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("constituentExposures", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ConstituentExposure> ConstituentExposures { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bosOnly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? BosOnly { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeAlternates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeAlternates { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bosRequestResponse", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PreCheckBosRequestResponse BosRequestResponse { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gcas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("currentGcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CurrentGcas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gcasId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GcasId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childSubId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ChildSubId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Category { get; set; }
    
        [Newtonsoft.Json.JsonProperty("product", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Product { get; set; }
    
        [Newtonsoft.Json.JsonProperty("habit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Habit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FactorType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Factor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("categoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CategoryId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ProductId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("habitId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HabitId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FactorTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FactorId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sensitizationAssessmentFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double SensitizationAssessmentFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationInFormula", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ConcentrationInFormula { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpeRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Tpe> TpeRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hnpRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<HabitsAndPractices> HnpRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfConcentration ConcentrationType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("displayType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfDisplay DisplayType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeSubs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeSubs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hideGreenRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HideGreenRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeBff", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeBff { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includePnMace", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludePnMace { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeFanOut", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeFanOut { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CpemBioAvail 
    {
        [Newtonsoft.Json.JsonProperty("substanceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SubstanceId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryIdentifier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PrimaryIdentifier { get; set; }
    
        [Newtonsoft.Json.JsonProperty("commonName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CommonName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Category { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productForm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductForm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("scenario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Scenario { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FactorType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExpFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bioAvail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double BioAvail { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset ModDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ModUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class BioAvailFilterChangeResponse 
    {
        [Newtonsoft.Json.JsonProperty("categories", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfstring> Categories { get; set; }
    
        [Newtonsoft.Json.JsonProperty("products", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfstring> Products { get; set; }
    
        [Newtonsoft.Json.JsonProperty("scenarios", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Scenarios { get; set; }
    
        [Newtonsoft.Json.JsonProperty("exposureFactorTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfstring> ExposureFactorTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("exposureFactors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfstring> ExposureFactors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CpemBioAvail> Rows { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class BioAvailSaveRequest 
    {
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CpemBioAvail> Rows { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class BioAvailRemoveItemRequest 
    {
        [Newtonsoft.Json.JsonProperty("ids", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> Ids { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DraftDataRequest 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CslDraftParameter 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("draftId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DraftId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parameter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Parameter { get; set; }
    
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CslDraft 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ownerUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OwnerUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DraftSaveRequest 
    {
        [Newtonsoft.Json.JsonProperty("header", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CslDraft Header { get; set; }
    
        [Newtonsoft.Json.JsonProperty("data", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<CslDraftParameter> Data { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RqPartMatches 
    {
        [Newtonsoft.Json.JsonProperty("rqNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RqNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partMatches", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartMatch> PartMatches { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CslMultiplePartRequest 
    {
        [Newtonsoft.Json.JsonProperty("partMatches", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartMatch> PartMatches { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rqPartMatches", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RqPartMatches> RqPartMatches { get; set; }
    
        [Newtonsoft.Json.JsonProperty("crfLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CrfLink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("smartLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SmartLink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childSubId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ChildSubId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bosOnly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? BosOnly { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeAlternates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeAlternates { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Category { get; set; }
    
        [Newtonsoft.Json.JsonProperty("product", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Product { get; set; }
    
        [Newtonsoft.Json.JsonProperty("habit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Habit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FactorType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Factor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("categoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CategoryId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ProductId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("habitId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HabitId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FactorTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FactorId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sensitizationAssessmentFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double SensitizationAssessmentFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationInFormula", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ConcentrationInFormula { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpeRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Tpe> TpeRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hnpRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<HabitsAndPractices> HnpRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfConcentration ConcentrationType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("displayType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfDisplay DisplayType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeSubs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeSubs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hideGreenRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HideGreenRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeBff", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeBff { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includePnMace", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludePnMace { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeFanOut", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeFanOut { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SubGridRequest 
    {
        [Newtonsoft.Json.JsonProperty("subGcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SubGcas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("curConc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double CurConc { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SubName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("crfLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CrfLink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lineageLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LineageLink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bosOnly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? BosOnly { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeAlternates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeAlternates { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gcas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("currentGcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CurrentGcas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gcasId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GcasId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childSubId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ChildSubId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Category { get; set; }
    
        [Newtonsoft.Json.JsonProperty("product", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Product { get; set; }
    
        [Newtonsoft.Json.JsonProperty("habit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Habit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FactorType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Factor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("categoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CategoryId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ProductId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("habitId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HabitId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FactorTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FactorId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sensitizationAssessmentFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double SensitizationAssessmentFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationInFormula", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double ConcentrationInFormula { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpeRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Tpe> TpeRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hnpRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<HabitsAndPractices> HnpRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfConcentration ConcentrationType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("displayType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfDisplay DisplayType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeSubs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeSubs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hideGreenRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HideGreenRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeBff", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeBff { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includePnMace", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludePnMace { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeFanOut", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeFanOut { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class InitRequest 
    {
        [Newtonsoft.Json.JsonProperty("substanceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SubstanceId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gcas { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MainFormWithDraftsVm 
    {
        [Newtonsoft.Json.JsonProperty("drafts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Drafts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartMatch Gcas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("categories", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Categories { get; set; }
    
        [Newtonsoft.Json.JsonProperty("products", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Products { get; set; }
    
        [Newtonsoft.Json.JsonProperty("habits", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Habits { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sensitizationAssessmentFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double SensitizationAssessmentFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("exposureFactorTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> ExposureFactorTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("exposureFactors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> ExposureFactors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpeRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Tpe> TpeRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hnpRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<HabitsAndPractices> HnpRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("showBff", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ShowBff { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum TypeOfFilterChange
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Unknown")]
        Unknown = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Category")]
        Category = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Product")]
        Product = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Scenario")]
        Scenario = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"ExposureFactorType")]
        ExposureFactorType = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = @"ExposureFactor")]
        ExposureFactor = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class FilterChangeRequest 
    {
        [Newtonsoft.Json.JsonProperty("change", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfFilterChange Change { get; set; }
    
        [Newtonsoft.Json.JsonProperty("category", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Category { get; set; }
    
        [Newtonsoft.Json.JsonProperty("categoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? CategoryId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("product", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Product { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ProductId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("scenario", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Scenario { get; set; }
    
        [Newtonsoft.Json.JsonProperty("scenarioId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ScenarioId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("scenarioIndex", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ScenarioIndex { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FactorType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FactorTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Factor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("factorId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FactorId { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class FilterChangeResponse 
    {
        [Newtonsoft.Json.JsonProperty("change", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfFilterChange Change { get; set; }
    
        [Newtonsoft.Json.JsonProperty("categories", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Categories { get; set; }
    
        [Newtonsoft.Json.JsonProperty("products", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Products { get; set; }
    
        [Newtonsoft.Json.JsonProperty("scenarios", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Scenarios { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sensitizationAssessmentFactor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double SensitizationAssessmentFactor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("exposureFactorTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> ExposureFactorTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("exposureFactors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> ExposureFactors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tpeRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Tpe> TpeRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hnpRows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<HabitsAndPractices> HnpRows { get; set; }
    
        [Newtonsoft.Json.JsonProperty("showBff", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ShowBff { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MaxWeightValue 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Segment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segmentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SegmentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("function", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Function { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FunctionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("actualValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ActualValue { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class HnpProductValueListResponse 
    {
        [Newtonsoft.Json.JsonProperty("gcases", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartMatch> Gcases { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rqGcases", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RqPartMatches> RqGcases { get; set; }
    
        [Newtonsoft.Json.JsonProperty("weights", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<MaxWeightValue> Weights { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TmSelectDisplay 
    {
        [Newtonsoft.Json.JsonProperty("order", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Order { get; set; }
    
        [Newtonsoft.Json.JsonProperty("label", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Label { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Rows { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ColumnDefinition 
    {
        [Newtonsoft.Json.JsonProperty("headerName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HeaderName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("field", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Field { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hide", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Hide { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tooltipField", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TooltipField { get; set; }
    
        [Newtonsoft.Json.JsonProperty("width", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? Width { get; set; }
    
        [Newtonsoft.Json.JsonProperty("minWidth", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MinWidth { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maxWidth", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaxWidth { get; set; }
    
        [Newtonsoft.Json.JsonProperty("editable", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Editable { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TableMaintFilterChangeResponse 
    {
        [Newtonsoft.Json.JsonProperty("adminDisplays", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TmSelectDisplay> AdminDisplays { get; set; }
    
        [Newtonsoft.Json.JsonProperty("refDisplays", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<TmSelectDisplay> RefDisplays { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colDefs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ColumnDefinition> ColDefs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<object> Rows { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum TypeOfRole
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Unknown")]
        Unknown = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"User")]
        User = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Admin")]
        Admin = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"FissatAdmin")]
        FissatAdmin = 3,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CslUser 
    {
        [Newtonsoft.Json.JsonProperty("employeeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EmployeeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("orgId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int OrgId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("roles", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore, ItemConverterType = typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public System.Collections.Generic.ICollection<TypeOfRole> Roles { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum TypeOfTableMaintFilterRequest
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Admin")]
        Admin = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Reference")]
        Reference = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TableMaintFilterChangeRequest 
    {
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CslUser User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfTableMaintFilterRequest Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("filters", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Filters { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TableMaintTableSaveRequest 
    {
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CslUser User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfTableMaintFilterRequest Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("filters", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Filters { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<object> Rows { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TableMaintDeleteItemRequest 
    {
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CslUser User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfTableMaintFilterRequest Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("filters", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Filters { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ids", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> Ids { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class TableMaintExcelExportRequest 
    {
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CslUser User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TypeOfTableMaintFilterRequest Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("filters", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LookupOfint> Filters { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rows", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<object> Rows { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class LevelEntry 
    {
        [Newtonsoft.Json.JsonProperty("level", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Level { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ParentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("low", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Low { get; set; }
    
        [Newtonsoft.Json.JsonProperty("target", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Target { get; set; }
    
        [Newtonsoft.Json.JsonProperty("high", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? High { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class FlattenedComponentPartHierEntry 
    {
        [Newtonsoft.Json.JsonProperty("parent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Parent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ChildLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ChildTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("childHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ChildHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ParentLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ParentTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ParentHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substitueOrAlternate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool SubstitueOrAlternate { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class FlattenedComponentPart 
    {
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reportLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ReportLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reportTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ReportTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reportHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ReportHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ancestorMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Part> AncestorMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("calculationHistory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CalculationHistory { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lowCalculationHistory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LowCalculationHistory { get; set; }
    
        [Newtonsoft.Json.JsonProperty("targetCalculationHistory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TargetCalculationHistory { get; set; }
    
        [Newtonsoft.Json.JsonProperty("highCalculationHistory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HighCalculationHistory { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lineage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<System.Collections.Generic.ICollection<Composition>> Lineage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("levelEntries", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<LevelEntry> LevelEntries { get; set; }
    
        [Newtonsoft.Json.JsonProperty("flattenedComponentPartHierEntries", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, System.Collections.Generic.ICollection<FlattenedComponentPartHierEntry>> FlattenedComponentPartHierEntries { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class EnvironmentControllerBuildDateResult 
    {
        [Newtonsoft.Json.JsonProperty("creationTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CreationTime { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lastWriteTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset LastWriteTime { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotAzureActiveDirectoryConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("tenantId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TenantId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("clientId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClientId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("graphBaseEndpoint", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GraphBaseEndpoint { get; set; }
    
        [Newtonsoft.Json.JsonProperty("redirectUri", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RedirectUri { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotLocalDeveloperConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("getFilesFromDepotServerUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GetFilesFromDepotServerUrl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("getFilesFromDepotServerAuthToken", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GetFilesFromDepotServerAuthToken { get; set; }
    
        [Newtonsoft.Json.JsonProperty("getFilesFromDepotServerUsername", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GetFilesFromDepotServerUsername { get; set; }
    
        [Newtonsoft.Json.JsonProperty("getFilesFromDepotServerPassword", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GetFilesFromDepotServerPassword { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isDevelopment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsDevelopment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isSingleEndpointForDevelopment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSingleEndpointForDevelopment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userOverride", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UserOverride { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotMetadataConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("appSettingsBasePath", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AppSettingsBasePath { get; set; }
    
        [Newtonsoft.Json.JsonProperty("configurationSources", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ConfigurationSources { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hostingEnvironmentName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HostingEnvironmentName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("environmentName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EnvironmentName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("machineName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MachineName { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotApplicationConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("namedInstance", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NamedInstance { get; set; }
    
        [Newtonsoft.Json.JsonProperty("connectionString", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ConnectionString { get; set; }
    
        [Newtonsoft.Json.JsonProperty("logPath", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LogPath { get; set; }
    
        [Newtonsoft.Json.JsonProperty("storageRootPath", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StorageRootPath { get; set; }
    
        [Newtonsoft.Json.JsonProperty("schemaPrefix", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SchemaPrefix { get; set; }
    
        [Newtonsoft.Json.JsonProperty("systemName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enableHttpCors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EnableHttpCors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("syncPicklistsToVault", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SyncPicklistsToVault { get; set; }
    
        [Newtonsoft.Json.JsonProperty("environmentSnapshotFrom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EnvironmentSnapshotFrom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("graspUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GraspUrl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("notifyToMsTeamsWebHook", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NotifyToMsTeamsWebHook { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dotConnectForOracleLicense", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DotConnectForOracleLicense { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dotConnectForOracleDirectMode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool DotConnectForOracleDirectMode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("jwtKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string JwtKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("jwtIssuer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string JwtIssuer { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotGpsBosConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("workbookPath", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WorkbookPath { get; set; }
    
        [Newtonsoft.Json.JsonProperty("forceBosCalc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ForceBosCalc { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assesmentSpecValidationMarginOfError", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double AssesmentSpecValidationMarginOfError { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bosValidationMarginOfError", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double BosValidationMarginOfError { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotNServiceBusConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("instanceName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InstanceName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("connectionString", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ConnectionString { get; set; }
    
        [Newtonsoft.Json.JsonProperty("backgroundEndpointPrefix", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BackgroundEndpointPrefix { get; set; }
    
        [Newtonsoft.Json.JsonProperty("apiEndpointName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ApiEndpointName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("emptyQueueOnStartup", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EmptyQueueOnStartup { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errorQueueNameOverride", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ErrorQueueNameOverride { get; set; }
    
        [Newtonsoft.Json.JsonProperty("auditQueueNameOverride", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AuditQueueNameOverride { get; set; }
    
        [Newtonsoft.Json.JsonProperty("heartbeatEndpointName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HeartbeatEndpointName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("monitoringEndpointName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MonitoringEndpointName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("limitMessageProcessingConcurrencyTo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? LimitMessageProcessingConcurrencyTo { get; set; }
    
        [Newtonsoft.Json.JsonProperty("recoverImmediateRetries", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RecoverImmediateRetries { get; set; }
    
        [Newtonsoft.Json.JsonProperty("recoverDelayedRetries", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RecoverDelayedRetries { get; set; }
    
        [Newtonsoft.Json.JsonProperty("license", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string License { get; set; }
    
        [Newtonsoft.Json.JsonProperty("endpointWorkerCountOverride", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, int> EndpointWorkerCountOverride { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class CslConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("crfLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CrfLink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("smartLink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SmartLink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("totalProteinSubstances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TotalProteinSubstances { get; set; }
    
        [Newtonsoft.Json.JsonProperty("excelExportConstituentExposureExcludes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExcelExportConstituentExposureExcludes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("perfumeWhitelistedRegulationGroups", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PerfumeWhitelistedRegulationGroups { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rawMaterialTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RawMaterialTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("recursionDepth", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RecursionDepth { get; set; }
    
        [Newtonsoft.Json.JsonProperty("showPerfumeGcas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ShowPerfumeGcas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("purgeFilterData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool PurgeFilterData { get; set; }
    
        [Newtonsoft.Json.JsonProperty("logParts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LogParts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("leafTable", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LeafTable { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allowedPlmStages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AllowedPlmStages { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allowedMfgStatuses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AllowedMfgStatuses { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allowedPartStatuses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AllowedPartStatuses { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allowedPrefixesInBosWarningState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AllowedPrefixesInBosWarningState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allowedProductFormsInBosWarningState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AllowedProductFormsInBosWarningState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("warningStatesForAllowedPrefixes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WarningStatesForAllowedPrefixes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("warningStatesForAllowedProductForms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WarningStatesForAllowedProductForms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("cslBusinessAreaAllowedBusinessAreas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CslBusinessAreaAllowedBusinessAreas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("cslBusinessAreaAllowedPlmStages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CslBusinessAreaAllowedPlmStages { get; set; }
    
        [Newtonsoft.Json.JsonProperty("cslBusinessAreaAllowedBosStates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CslBusinessAreaAllowedBosStates { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotSchedulerConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("enabled", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Enabled { get; set; }
    
        [Newtonsoft.Json.JsonProperty("processPassChangesSchedule", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProcessPassChangesSchedule { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pullPlmUsersSchedule", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PullPlmUsersSchedule { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pollGraspForUpdateSchedule", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PollGraspForUpdateSchedule { get; set; }
    
        [Newtonsoft.Json.JsonProperty("resetDerivedCompHighLeveledPartsSchedule", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResetDerivedCompHighLeveledPartsSchedule { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPullUsersMinuteOffset", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PlmPullUsersMinuteOffset { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class VaultConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("environment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Environment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Url { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reportUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReportUrl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reportServerDeployName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ReportServerDeployName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("apiVersion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ApiVersion { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }
    
        [Newtonsoft.Json.JsonProperty("serverId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ServerId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("clientIdEnvironmentToken", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClientIdEnvironmentToken { get; set; }
    
        [Newtonsoft.Json.JsonProperty("delayIfApiBurstCountDropsBelow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? DelayIfApiBurstCountDropsBelow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("delayIfAuthBurstCountDropsBelow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? DelayIfAuthBurstCountDropsBelow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("burstDelaySleepIsSynchronous", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool BurstDelaySleepIsSynchronous { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultPgAwsPingSsoId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultPgAwsPingSsoId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("recoverHttpRetryDelays", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> RecoverHttpRetryDelays { get; set; }
    
        [Newtonsoft.Json.JsonProperty("recoverFailedVaultDelays", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> RecoverFailedVaultDelays { get; set; }
    
        [Newtonsoft.Json.JsonProperty("httpTimeout", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HttpTimeout { get; set; }
    
        [Newtonsoft.Json.JsonProperty("autoPullChanges", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AutoPullChanges { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DataHandlerConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("useCachedFiles", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UseCachedFiles { get; set; }
    
        [Newtonsoft.Json.JsonProperty("basicHttpAuthUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BasicHttpAuthUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("basicHttpAuthPassword", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BasicHttpAuthPassword { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parameterUsername", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ParameterUsername { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parameterPassword", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ParameterPassword { get; set; }
    
        [Newtonsoft.Json.JsonProperty("applicationUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ApplicationUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("applicationPassword", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ApplicationPassword { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dataHandlerUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DataHandlerUrl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("httpCallAttempts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HttpCallAttempts { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum ExportCosMode
    {
        [System.Runtime.Serialization.EnumMember(Value = @"DataHandler")]
        DataHandler = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Legacy")]
        Legacy = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MarketClearanceServiceConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }
    
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Url { get; set; }
    
        [Newtonsoft.Json.JsonProperty("cosMode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ExportCosMode CosMode { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class UserServiceConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }
    
        [Newtonsoft.Json.JsonProperty("url", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Url { get; set; }
    
        [Newtonsoft.Json.JsonProperty("httpCallAttempts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int HttpCallAttempts { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PlmConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("enoviaSystemName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EnoviaSystemName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("environment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Environment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("xmlPath", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string XmlPath { get; set; }
    
        [Newtonsoft.Json.JsonProperty("irmDocumentsPath", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IrmDocumentsPath { get; set; }
    
        [Newtonsoft.Json.JsonProperty("disableDownloadDocs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool DisableDownloadDocs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("cachedFilesPath", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CachedFilesPath { get; set; }
    
        [Newtonsoft.Json.JsonProperty("disableUserRegistrationEmailNotification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool DisableUserRegistrationEmailNotification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enableMepSepPushToPlm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EnableMepSepPushToPlm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enableMarketClearancesPushToPlm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EnableMarketClearancesPushToPlm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enableSubstancePushToPlm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EnableSubstancePushToPlm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enableDangerousGoodsAndGhsPushToPlm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EnableDangerousGoodsAndGhsPushToPlm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enableReachFieldsPushToPlm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EnableReachFieldsPushToPlm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmInitialMaterialPartStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlmInitialMaterialPartStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enableTaskProcessing", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EnableTaskProcessing { get; set; }
    
        [Newtonsoft.Json.JsonProperty("delayBeforeProcessingReceivedPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DelayBeforeProcessingReceivedPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("delayBeforeProcessingReceivedPartTimeSpan", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DelayBeforeProcessingReceivedPartTimeSpan { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dataHandler", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DataHandlerConfiguration DataHandler { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketClearanceService", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MarketClearanceServiceConfiguration MarketClearanceService { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userService", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public UserServiceConfiguration UserService { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RegulationListConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("arielUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ArielUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manualUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ManualUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("restrictionMaxSend", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RestrictionMaxSend { get; set; }
    
        [Newtonsoft.Json.JsonProperty("restrictionMaxRemove", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RestrictionMaxRemove { get; set; }
    
        [Newtonsoft.Json.JsonProperty("casAttributeTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CasAttributeTypeName { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class LdapConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("ldapHost", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LdapHost { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ldapPort", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LdapPort { get; set; }
    
        [Newtonsoft.Json.JsonProperty("configuredCredentials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.IDictionary<string, string> ConfiguredCredentials { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class WercsConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("apiUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ApiUrl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sendRequestApiMethod", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SendRequestApiMethod { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User { get; set; }
    
        [Newtonsoft.Json.JsonProperty("password", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Password { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class AzureStorageConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("uri", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Uri { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DepotConfiguration 
    {
        [Newtonsoft.Json.JsonProperty("secretAzureKeyVaultUrl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SecretAzureKeyVaultUrl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("azureActiveDirectory", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DepotAzureActiveDirectoryConfiguration AzureActiveDirectory { get; set; }
    
        [Newtonsoft.Json.JsonProperty("localDeveloper", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DepotLocalDeveloperConfiguration LocalDeveloper { get; set; }
    
        [Newtonsoft.Json.JsonProperty("configurationMetadata", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DepotMetadataConfiguration ConfigurationMetadata { get; set; }
    
        [Newtonsoft.Json.JsonProperty("depot", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DepotApplicationConfiguration Depot { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsBos", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DepotGpsBosConfiguration GpsBos { get; set; }
    
        [Newtonsoft.Json.JsonProperty("nServiceBus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DepotNServiceBusConfiguration NServiceBus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("csl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CslConfiguration Csl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("scheduler", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DepotSchedulerConfiguration Scheduler { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vault", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public VaultConfiguration Vault { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmConfiguration Plm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulationLists", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RegulationListConfiguration RegulationLists { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ldap", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LdapConfiguration Ldap { get; set; }
    
        [Newtonsoft.Json.JsonProperty("wercs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public WercsConfiguration Wercs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("azureStorage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public AzureStorageConfiguration AzureStorage { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncControllerSetPreferredPlmStateOrderArgument 
    {
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PlmStates { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncControllerSetPartTypesArgument 
    {
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartTypes { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncControllerSetCompTypesArgument 
    {
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> CompTypes { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncSystem 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncCompType 
    {
        [Newtonsoft.Json.JsonProperty("extSyncSystemId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ExtSyncSystemId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int CompTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("extSyncSystem", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ExtSyncSystem ExtSyncSystem { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompositionType CompType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SyncSystemConfig 
    {
        [Newtonsoft.Json.JsonProperty("syncSystemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SyncSystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PlmTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> CompTypes { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SyncPart 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("keyType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string KeyType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("keyExpr", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string KeyExpr { get; set; }
    
        [Newtonsoft.Json.JsonProperty("revisionExpr", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RevisionExpr { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSrcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSrcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lastModifiedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? LastModifiedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("syncAttributes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SyncAttributes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("validationErrors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ValidationErrors { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncControllerAddSyncPartsArgument 
    {
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("syncParts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SyncPart> SyncParts { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncControllerSyncKeysArgument 
    {
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("syncKeys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SyncKeys { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncControllerPartSyncAttrsArgument 
    {
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("syncKeys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SyncKeys { get; set; }
    
        [Newtonsoft.Json.JsonProperty("syncAttrs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SyncAttrs { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncControllerFindSyncPartsBySyncAttrsArgument 
    {
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("syncAttrs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SyncAttrs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("next", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Next { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ExtSyncControllerPollPartsArgument 
    {
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("startLastUpdated", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset StartLastUpdated { get; set; }
    
        [Newtonsoft.Json.JsonProperty("endLastUpdated", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset EndLastUpdated { get; set; }
    
        [Newtonsoft.Json.JsonProperty("next", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Next { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class DateRange 
    {
        [Newtonsoft.Json.JsonProperty("startDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? StartDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("endDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? EndDate { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class NewPartSearchFilter 
    {
        [Newtonsoft.Json.JsonProperty("systemKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SystemKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("next", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Next { get; set; }
    
        [Newtonsoft.Json.JsonProperty("offset", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Offset { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isForPass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsForPass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKeyTerm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKeyTerm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedRange", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DateRange ModifiedRange { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PlmTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PlmPolicies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStates", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PlmStates { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PlmStages { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ingredientClasses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> IngredientClasses { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryOrganizations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PrimaryOrganizations { get; set; }
    
        [Newtonsoft.Json.JsonProperty("categories", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Categories { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subCategories", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SubCategories { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Segments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sectors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Sectors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subSectors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SubSectors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityClassifications", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SecurityClassifications { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessAreas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> BusinessAreas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ProductCategoryPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reviewStatuses", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ReviewStatuses { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GetPartKeyResults 
    {
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ObsoletePartControllerGetBestPartsByKeysArguments 
    {
        [Newtonsoft.Json.JsonProperty("keys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Keys { get; set; }
    
        [Newtonsoft.Json.JsonProperty("passOnly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? PassOnly { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ObsoletePartControllerPartLookupArgumentsOld 
    {
        [Newtonsoft.Json.JsonProperty("term", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Term { get; set; }
    
        [Newtonsoft.Json.JsonProperty("keyPattern", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string KeyPattern { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ObsoletePartControllerGetPartsByKeysArguments 
    {
        [Newtonsoft.Json.JsonProperty("keys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Keys { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ObsoletePartControllerPartIdAttrLookupArguments 
    {
        [Newtonsoft.Json.JsonProperty("partIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PartIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("attrNameFilter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> AttrNameFilter { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ObsoletePartControllerPartKeyAttrLookupArguments 
    {
        [Newtonsoft.Json.JsonProperty("partKeys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> PartKeys { get; set; }
    
        [Newtonsoft.Json.JsonProperty("attrNameFilter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> AttrNameFilter { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartControllerGetPartsRequest 
    {
        [Newtonsoft.Json.JsonProperty("keyStartsWithChars", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string KeyStartsWithChars { get; set; }
    
        [Newtonsoft.Json.JsonProperty("keyRegexPattern", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string KeyRegexPattern { get; set; }
    
        [Newtonsoft.Json.JsonProperty("keys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Keys { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcKeys", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SrcKeys { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ids", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> Ids { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bestPartsOnly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? BestPartsOnly { get; set; }
    
        [Newtonsoft.Json.JsonProperty("passOnly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? PassOnly { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeAttributes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeAttributes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeDocuments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeDocuments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includePlants", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludePlants { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeSecurity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeSecurity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeUsers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeUsers { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeVendors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeVendors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeDangerousGoods", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeDangerousGoods { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeGhs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeGhs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeClearances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IncludeClearances { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PushObjectsToPassRequest 
    {
        [Newtonsoft.Json.JsonProperty("vaultObjectName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultObjectName { get; set; }
    
        /// <summary>A table name, like "z_depot_id" that has an "id" column that will be used to look up the depot objects to send to pass</summary>
        [Newtonsoft.Json.JsonProperty("depotIdTable", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DepotIdTable { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultObjectFields", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> VaultObjectFields { get; set; }
    
        /// <summary>For Parts: For SRIs, we almost certainly do NOT want to update lifecycle state.
        /// For Comps: The main reason to set lifecycle state as of 2020-Jun is to set "RM-to-MEP/SEP"s to "Approved"</summary>
        [Newtonsoft.Json.JsonProperty("updateVaultLifecycleState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UpdateVaultLifecycleState { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PicklistControllerPicklistValue 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PlmReceivedXmlHeader 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("receivedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset ReceivedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("xmlFileName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string XmlFileName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("xmlSchema", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string XmlSchema { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("destinationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? DestinationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("destinationTable", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DestinationTable { get; set; }
    
        [Newtonsoft.Json.JsonProperty("processedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? ProcessedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("processedResult", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? ProcessedResult { get; set; }
    
        [Newtonsoft.Json.JsonProperty("processedException", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProcessedException { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("releaseDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset ReleaseDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Status { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supersededById", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SupersededById { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PullPartForAssessmentResult 
    {
        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSrcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSrcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partImportStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartImportStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTradeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartTradeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypeCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartTypeCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partGbuName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartGbuName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partConfidentialTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartConfidentialTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partCasNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartCasNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partIsExperimental", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? PartIsExperimental { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSecurityClassification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSecurityClassification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partStatusName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartStatusName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmPolicyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmPolicyName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmStateName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmStateName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmStageName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmStageName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partIngredientClassName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartIngredientClassName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partCategoryName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartCategoryName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSubCategoryName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSubCategoryName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSegmentName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSegmentName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSectorName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSectorName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partSubSectorName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartSubSectorName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPrimaryOrganizationName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPrimaryOrganizationName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partMasterPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PartMasterPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partMasterPartKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartMasterPartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partManufacturerSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartManufacturerSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessAreas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> BusinessAreas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ProductCategoryPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partReviewedStatusName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartReviewedStatusName { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PlmImportResult 
    {
        [Newtonsoft.Json.JsonProperty("identifier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Identifier { get; set; }
    
        [Newtonsoft.Json.JsonProperty("revision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Revision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("persistXmlSuccess", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool PersistXmlSuccess { get; set; }
    
        [Newtonsoft.Json.JsonProperty("receivedXmlId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ReceivedXmlId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("processingQueued", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ProcessingQueued { get; set; }
    
        [Newtonsoft.Json.JsonProperty("exception", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public object Exception { get; set; }
    
        [Newtonsoft.Json.JsonProperty("destinationTable", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DestinationTable { get; set; }
    
        [Newtonsoft.Json.JsonProperty("destinationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? DestinationId { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum PlmSchemaTypeEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Any")]
        Any = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"ConsumerUnitPart")]
        ConsumerUnitPart = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Task")]
        Task = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"InternalMaterial")]
        InternalMaterial = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Dcoument")]
        Dcoument = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = @"PackagingSpecification")]
        PackagingSpecification = 5,
    
        [System.Runtime.Serialization.EnumMember(Value = @"StudyProtocol")]
        StudyProtocol = 6,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Artwork")]
        Artwork = 7,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Formula")]
        Formula = 8,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Material")]
        Material = 9,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ConstituentSubstanceSynonym 
    {
        [Newtonsoft.Json.JsonProperty("substanceName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SubstanceName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("synonymTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SynonymTypeName { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Property 
    {
        [Newtonsoft.Json.JsonProperty("propertyName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PropertyName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numberValue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NumberValue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RiskPhrases 
    {
        [Newtonsoft.Json.JsonProperty("hazOrRS", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HazOrRS { get; set; }
    
        [Newtonsoft.Json.JsonProperty("riskPhrase", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RiskPhrase { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rsCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RsCode { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SafetyPhrases 
    {
        [Newtonsoft.Json.JsonProperty("safetyPhrase", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SafetyPhrase { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazOrRS", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HazOrRS { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rsCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RsCode { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RiskSafetySymbol 
    {
        [Newtonsoft.Json.JsonProperty("riskSafetyPhrase", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RiskSafetyPhrase { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hazOrRS", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HazOrRS { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rsCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RsCode { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Substance 
    {
        [Newtonsoft.Json.JsonProperty("substanceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double SubstanceId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResponsibleName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("registrationDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset RegistrationDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaterialType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("commonName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CommonName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PrimaryId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("status", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Status { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gbu", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Gbu { get; set; }
    
        [Newtonsoft.Json.JsonProperty("safetyNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SafetyNotes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regNotes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RegNotes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Functions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substanceSynonyms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<ConstituentSubstanceSynonym> SubstanceSynonyms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("property", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Property> Property { get; set; }
    
        [Newtonsoft.Json.JsonProperty("riskPhrases", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RiskPhrases> RiskPhrases { get; set; }
    
        [Newtonsoft.Json.JsonProperty("safetyPhrases", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SafetyPhrases> SafetyPhrases { get; set; }
    
        [Newtonsoft.Json.JsonProperty("riskSafetySymbol", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RiskSafetySymbol> RiskSafetySymbol { get; set; }
    
        [Newtonsoft.Json.JsonProperty("groups", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Groups { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ingredientClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> IngredientClass { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class KeyValuePairOfstringAndStringValues 
    {
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PmiLoader 
    {
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fileName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FileName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pmiName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PmiName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Errors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulatoryRegions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RegulatoryRegions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("material", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Material { get; set; }
    
        [Newtonsoft.Json.JsonProperty("finalMaterialToBeOxoplastic", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool FinalMaterialToBeOxoplastic { get; set; }
    
        [Newtonsoft.Json.JsonProperty("additiveDirectOrMasterbatch", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AdditiveDirectOrMasterbatch { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directAddChemNameCasPpm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DirectAddChemNameCasPpm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("maxUsageLevelOfMasterbatch", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MaxUsageLevelOfMasterbatch { get; set; }
    
        [Newtonsoft.Json.JsonProperty("masterbatchComposition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MasterbatchComposition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("usingMineralOilMoshMoahAbove1Percent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UsingMineralOilMoshMoahAbove1Percent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mineralOilMoshMoahComposition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MineralOilMoshMoahComposition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tradeNameOrProductId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TradeNameOrProductId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("manufacturerNameCountryOfHq", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ManufacturerNameCountryOfHq { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productManufacturedAtOneSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ProductManufacturedAtOneSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlantName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantCountry", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlantCountry { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantAddress1", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlantAddress1 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantAddress2", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlantAddress2 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantCity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlantCity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlantState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantZip", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlantZip { get; set; }
    
        [Newtonsoft.Json.JsonProperty("validForAllManufacturingSites", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ValidForAllManufacturingSites { get; set; }
    
        [Newtonsoft.Json.JsonProperty("infoPersonCompletingSheetName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InfoPersonCompletingSheetName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("infoPersonCompletingSheetPhoneNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InfoPersonCompletingSheetPhoneNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("infoPersonCompletingSheetEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InfoPersonCompletingSheetEmail { get; set; }
    
        [Newtonsoft.Json.JsonProperty("typeOfMaterialComponent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TypeOfMaterialComponent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifOtherMaterialComponentType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfOtherMaterialComponentType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("multilayerNumberOfLayers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MultilayerNumberOfLayers { get; set; }
    
        [Newtonsoft.Json.JsonProperty("multilayerThicknessOfEachLayer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MultilayerThicknessOfEachLayer { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifResinChooseType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfResinChooseType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("resinType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResinType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifResinIsPostIndustrialRecycle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfResinIsPostIndustrialRecycle { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifPostConsumerRecycledWhere", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfPostConsumerRecycledWhere { get; set; }
    
        [Newtonsoft.Json.JsonProperty("inComplianceWithConeg", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool InComplianceWithConeg { get; set; }
    
        [Newtonsoft.Json.JsonProperty("anyAnimalDerivedMaterial", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AnyAnimalDerivedMaterial { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containPorcineAnimalTissues", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainPorcineAnimalTissues { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containBovineOvineDeerElkMink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainBovineOvineDeerElkMink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesProvideCommentsBovineOvineDeerElkMink", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfYesProvideCommentsBovineOvineDeerElkMink { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containOtherSpeciesAnimalTissue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainOtherSpeciesAnimalTissue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesProvideCommentsAnimalTissue", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfYesProvideCommentsAnimalTissue { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fitForHumanConsumption", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool FitForHumanConsumption { get; set; }
    
        [Newtonsoft.Json.JsonProperty("humanConsumptionComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HumanConsumptionComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sec3Annex1OfRegEc7722012", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Sec3Annex1OfRegEc7722012 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("japaneseChemicalControlCompliant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool JapaneseChemicalControlCompliant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("philippineChemicalControlCompliant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool PhilippineChemicalControlCompliant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("koreanChemicalControlCompliant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool KoreanChemicalControlCompliant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("chineseIecscCompliant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ChineseIecscCompliant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("nationalFoodPackagingCompliant", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool NationalFoodPackagingCompliant { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compliantWithIs983319811", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool CompliantWithIs983319811 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("confirmNoSvhc", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ConfirmNoSvhc { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierSvhcCommitment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierSvhcCommitment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierSvhcCommunicationAgreement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierSvhcCommunicationAgreement { get; set; }
    
        [Newtonsoft.Json.JsonProperty("alreadySignedScdInEurope", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AlreadySignedScdInEurope { get; set; }
    
        [Newtonsoft.Json.JsonProperty("confirmNoAnnexIISubstances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ConfirmNoAnnexIISubstances { get; set; }
    
        [Newtonsoft.Json.JsonProperty("confirmMinimizedNoxiousMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ConfirmMinimizedNoxiousMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("biocidalProducts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool BiocidalProducts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesAddBiocide", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfYesAddBiocide { get; set; }
    
        [Newtonsoft.Json.JsonProperty("intentionalProp65IngredientRegulatoryInformation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IntentionalProp65IngredientRegulatoryInformation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesPleaseListProp65RegulatoryInformation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfYesPleaseListProp65RegulatoryInformation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("complyWithEuropeanFramework", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ComplyWithEuropeanFramework { get; set; }
    
        [Newtonsoft.Json.JsonProperty("complyWithFdaFoodGrade", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ComplyWithFdaFoodGrade { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesProvideRegulationNumberFoodGrade", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfYesProvideRegulationNumberFoodGrade { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allChemicalsListedOnTsca", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AllChemicalsListedOnTsca { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allChemicalsListedOnDsl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AllChemicalsListedOnDsl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allChemicalsListedOnNdsl", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AllChemicalsListedOnNdsl { get; set; }
    
        [Newtonsoft.Json.JsonProperty("allChemicalsOnFdaFoodStuff", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AllChemicalsOnFdaFoodStuff { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesProvideRegulationFoodStuff", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfYesProvideRegulationFoodStuff { get; set; }
    
        [Newtonsoft.Json.JsonProperty("intentionalProp65IngredientIngredientInformation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IntentionalProp65IngredientIngredientInformation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesPleaseListProp65IngredientInformation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfYesPleaseListProp65IngredientInformation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containIntentionalAdditionOfIngredients", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainIntentionalAdditionOfIngredients { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sectionIIICasChemLevelCollection", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> SectionIIICasChemLevelCollection { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hexachlorobenzenePresent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HexachlorobenzenePresent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colorantsListedOnEcd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ColorantsListedOnEcd { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colorantsOnCfrTitle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ColorantsOnCfrTitle { get; set; }
    
        [Newtonsoft.Json.JsonProperty("colorantsListedOnCfr1783297", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ColorantsListedOnCfr1783297 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("varnishAppliedOverInks", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool VarnishAppliedOverInks { get; set; }
    
        [Newtonsoft.Json.JsonProperty("filmAppliedOverInks", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool FilmAppliedOverInks { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifNoUsingRubResistantInks", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IfNoUsingRubResistantInks { get; set; }
    
        [Newtonsoft.Json.JsonProperty("usingAnOrganicPigment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UsingAnOrganicPigment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("organicPigmentPcb50Ppm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool OrganicPigmentPcb50Ppm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("usingUvCuredInksVarnishCoatings", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UsingUvCuredInksVarnishCoatings { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containAnyPolyolefinBasedMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainAnyPolyolefinBasedMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesPolyfilmThickness17Mil", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IfYesPolyfilmThickness17Mil { get; set; }
    
        [Newtonsoft.Json.JsonProperty("otherPolyfilmThicknessM", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OtherPolyfilmThicknessM { get; set; }
    
        [Newtonsoft.Json.JsonProperty("doesAnSmlForFpmNeedToBeMet", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool DoesAnSmlForFpmNeedToBeMet { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesDoSmlsMeetLimitRqmts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IfYesDoSmlsMeetLimitRqmts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("smlDetails", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SmlDetails { get; set; }
    
        [Newtonsoft.Json.JsonProperty("whatIsIntendedPolymer", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WhatIsIntendedPolymer { get; set; }
    
        [Newtonsoft.Json.JsonProperty("whatIsRecommendedLdr", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WhatIsRecommendedLdr { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifSubjectToSmlProvideInfo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfSubjectToSmlProvideInfo { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifResinDoesItQualifyForSpi", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IfResinDoesItQualifyForSpi { get; set; }
    
        [Newtonsoft.Json.JsonProperty("usRecyclingIconQualifies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool UsRecyclingIconQualifies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("usRecyclingCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UsRecyclingCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("eimeaRecyclingIconQualifies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool EimeaRecyclingIconQualifies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("eimeaRecyclingCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EimeaRecyclingCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("japanRecyclingIconQualifies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool JapanRecyclingIconQualifies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("japanRecyclingCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string JapanRecyclingCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("koreaRecyclingIconQualifies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool KoreaRecyclingIconQualifies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("koreaRecyclingCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string KoreaRecyclingCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("taiwanRecyclingIconQualifies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool TaiwanRecyclingIconQualifies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("taiwanRecyclingCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TaiwanRecyclingCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("chinaRecyclingIconQualifies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ChinaRecyclingIconQualifies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("chinaRecyclingCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ChinaRecyclingCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ausnzRecyclingIconQualifies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AusnzRecyclingIconQualifies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ausnzRecyclingCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AusnzRecyclingCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("latamRecyclingIconQualifies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool LatamRecyclingIconQualifies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("latamRecyclingCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LatamRecyclingCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containAnyPaperBasedMaterials", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool ContainAnyPaperBasedMaterials { get; set; }
    
        [Newtonsoft.Json.JsonProperty("virginPulpFibersUsed", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool VirginPulpFibersUsed { get; set; }
    
        [Newtonsoft.Json.JsonProperty("weightOfPulpFibers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? WeightOfPulpFibers { get; set; }
    
        [Newtonsoft.Json.JsonProperty("polyflouroalkylPerfluoroalkylPresent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool PolyflouroalkylPerfluoroalkylPresent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ifYesSubstanceNameAndLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IfYesSubstanceNameAndLevel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("commentsFromSupplier", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CommentsFromSupplier { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierSignature", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierSignature { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierPrintedName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierPrintedName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierTitle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierTitle { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierPhone", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierPhone { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierFax", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierFax { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierEmail { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierEsignature", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierEsignature { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supplierSignatureDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SupplierSignatureDate { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PmiLoaderSubmitResponse 
    {
        [Newtonsoft.Json.JsonProperty("isSuccess", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSuccess { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errorMessages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ErrorMessages { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestControllerStatusRow 
    {
        [Newtonsoft.Json.JsonProperty("path", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Path { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("taskLabel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TaskLabel { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentRegion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentRegion { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assignedOn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssignedOn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assignedTo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssignedTo { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assignedToEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssignedToEmail { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dueOn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DueOn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lastModifiedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? LastModifiedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("verdict", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Verdict { get; set; }
    
        [Newtonsoft.Json.JsonProperty("summaryComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SummaryComments { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestControllerStatusResult 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("statusTree", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestControllerStatusRow> StatusTree { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestSalesSample 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestSegment 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segmentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int SegmentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Segment Segment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PackageSizeUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class QuantityShippedProducedUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum RequestFieldListTypeEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = @"ActualToAssess")]
        ActualToAssess = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"PlmToAssess")]
        PlmToAssess = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"PlmToAssessOveride")]
        PlmToAssessOveride = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestBusinessArea 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessAreaId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int BusinessAreaId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestFieldListTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public RequestFieldListTypeEnum RequestFieldListTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessArea", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BusinessArea BusinessArea { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestProductCategoryPlatform 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatformId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ProductCategoryPlatformId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestFieldListTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public RequestFieldListTypeEnum RequestFieldListTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatform", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ProductCategoryPlatform ProductCategoryPlatform { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestSrcFunction 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("oldFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int OldFunctionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestFieldListTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public RequestFieldListTypeEnum RequestFieldListTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcFunction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SrcFunction SrcFunction { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestMaterialFunction 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int FunctionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestFieldListTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public RequestFieldListTypeEnum RequestFieldListTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("function", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Function Function { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MaterialVolumeUom 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class FinishedProductImportedAs 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestStatus 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PreClearanceLevel 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GpsProductType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestGpsProductType 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsProductTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int GpsProductTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsProductType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GpsProductType GpsProductType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestLifecycleState 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestMarket 
    {
        [Newtonsoft.Json.JsonProperty("marketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MarketId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulatoryClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? RegulatoryClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestPartProductCategoryPlatform 
    {
        [Newtonsoft.Json.JsonProperty("requestPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatformId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int ProductCategoryPlatformId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RequestPart RequestPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatform", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ProductCategoryPlatform ProductCategoryPlatform { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestPart 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedFrequency", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExpectedFrequency { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedFrequencyUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ExpectedFrequencyUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedFrequencyUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FrequencyUom ExpectedFrequencyUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productDosePerUse", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductDosePerUse { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPerUseDosageUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ProductPerUseDosageUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productPerUseDosageUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public DosageUom ProductPerUseDosageUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketedAsChildProduct", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MarketedAsChildProduct { get; set; }
    
        [Newtonsoft.Json.JsonProperty("powerSource", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PowerSource { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productExposedToChildren", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductExposedToChildren { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productForm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductForm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modeProductDisposal", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ModeProductDisposal { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCertificationRequired", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductCertificationRequired { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reportedFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ReportedFunctionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("reportedFunction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Function ReportedFunction { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segmentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SegmentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("segment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Segment Segment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestPartProductCategoryPlatform> ProductCategoryPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestPartMarket 
    {
        [Newtonsoft.Json.JsonProperty("requestPartId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestPartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RequestPart RequestPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MarketId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("market", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Market Market { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulatoryClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? RegulatoryClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulatoryClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RegulatoryClass RegulatoryClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("similarAndClearProductPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SimilarAndClearProductPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isProductPartReplacement", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IsProductPartReplacement { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productReplaced", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductReplaced { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedAnnualVolume", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? ExpectedAnnualVolume { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedAnnualVolumeUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ExpectedAnnualVolumeUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expectedAnnualVolumeUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SalesQtyUom ExpectedAnnualVolumeUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestDocument 
    {
        [Newtonsoft.Json.JsonProperty("documentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DocumentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("document", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Document Document { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SecurityCategoryClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyBusinessArea 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public BusinessArea Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyFranchise 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Franchise Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyProductCategoryPlatform 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ProductCategoryPlatform Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyProductTechnologyPlatform 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ProductTechnologyPlatform Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyProductTechnologyChassis 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ProductTechnologyChassis Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyStudyType 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public StudyType Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyClass 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyPanelistType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyStudyPanelistType 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public StudyPanelistType Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StabilityTestingType 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudySupervisedProductUse 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyMarket 
    {
        [Newtonsoft.Json.JsonProperty("studyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int StudyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MarketId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("study", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Study Study { get; set; }
    
        [Newtonsoft.Json.JsonProperty("market", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Market Market { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyProductUseLocation 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyStudyProductUseLocation 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public StudyProductUseLocation Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyDistributingLocation 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyDocument 
    {
        [Newtonsoft.Json.JsonProperty("studyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int StudyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("documentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int DocumentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("document", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Document Document { get; set; }
    
        [Newtonsoft.Json.JsonProperty("study", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Study Study { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyLegPartPlant 
    {
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Plant Value { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyLegPart 
    {
        [Newtonsoft.Json.JsonProperty("studyLegId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int StudyLegId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyLeg", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public StudyLeg StudyLeg { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCode", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductCode { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sitesForProductManufacturing", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyLegPartPlant> SitesForProductManufacturing { get; set; }
    
        [Newtonsoft.Json.JsonProperty("siteIfOther", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SiteIfOther { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isUsageFrequencySameAsMarket", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsUsageFrequencySameAsMarket { get; set; }
    
        [Newtonsoft.Json.JsonProperty("usageFrequencyOfTestProduct", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UsageFrequencyOfTestProduct { get; set; }
    
        [Newtonsoft.Json.JsonProperty("washoutTimeBetweenProducts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WashoutTimeBetweenProducts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numberOfUnitsPerPanelist", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? NumberOfUnitsPerPanelist { get; set; }
    
        [Newtonsoft.Json.JsonProperty("packingSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PackingSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isNonCommSubmittedForMicroMct", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IsNonCommSubmittedForMicroMct { get; set; }
    
        [Newtonsoft.Json.JsonProperty("labelDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LabelDescription { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isProductRepackaged", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsProductRepackaged { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyLeg 
    {
        [Newtonsoft.Json.JsonProperty("studyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int StudyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("study", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Study Study { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmType PlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numOfPanelists", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NumOfPanelists { get; set; }
    
        [Newtonsoft.Json.JsonProperty("numProductsPerPanelist", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NumProductsPerPanelist { get; set; }
    
        [Newtonsoft.Json.JsonProperty("legParts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyLegPart> LegParts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StudyAttachedFile 
    {
        [Newtonsoft.Json.JsonProperty("studyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int StudyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PlmTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmType PlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcObjectId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcObjectId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originatedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? OriginatedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("format", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Format { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fileSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? FileSize { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originatorUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OriginatorUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User Originator { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Study 
    {
        [Newtonsoft.Json.JsonProperty("srcObjectId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcObjectId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ownerUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OwnerUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("owner", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User Owner { get; set; }
    
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }
    
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }
    
        [Newtonsoft.Json.JsonProperty("importStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public ImportStatusValues ImportStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("importStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public ImportStatus ImportStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmStateId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmState PlmState { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmType PlmType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PlmPolicyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PlmPolicy PlmPolicy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcCreatedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? SrcCreatedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcModifiedAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? SrcModifiedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("projectSpaceName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProjectSpaceName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityCategoryClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SecurityCategoryClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("securityCategoryClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SecurityCategoryClass SecurityCategoryClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessAreas", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyBusinessArea> BusinessAreas { get; set; }
    
        [Newtonsoft.Json.JsonProperty("franchises", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyFranchise> Franchises { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyProductCategoryPlatform> ProductCategoryPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productTechnologyPlatforms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyProductTechnologyPlatform> ProductTechnologyPlatforms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productTechnologyChassies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyProductTechnologyChassis> ProductTechnologyChassies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("objective", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Objective { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyStudyType> StudyTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyTypeFormatIfOther", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string StudyTypeFormatIfOther { get; set; }
    
        [Newtonsoft.Json.JsonProperty("totalNumberOfPanelistsAllLegs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? TotalNumberOfPanelistsAllLegs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("purchaseIntentQuestion", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? PurchaseIntentQuestion { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StudyClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public StudyClass StudyClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("overallRegulatoryClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? OverallRegulatoryClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("overallRegulatoryClass", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RegulatoryClass OverallRegulatoryClass { get; set; }
    
        [Newtonsoft.Json.JsonProperty("dataUse", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DataUse { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isThisClinicalStudy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsThisClinicalStudy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("panelistTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyStudyPanelistType> PanelistTypes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ageConstraintLowerLimit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AgeConstraintLowerLimit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ageConstraintUpperLimit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AgeConstraintUpperLimit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ageOtherCriteria", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AgeOtherCriteria { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasInclusionDefinedCrit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasInclusionDefinedCrit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasExclusionDefinedCrit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasExclusionDefinedCrit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sameUsageForPgMgmt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? SameUsageForPgMgmt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sameUsageForRdTeam", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? SameUsageForRdTeam { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasUniquePkgOrMaterial", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasUniquePkgOrMaterial { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasPanelistSupportItems", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasPanelistSupportItems { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyRequiresStabilityData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? StudyRequiresStabilityData { get; set; }
    
        [Newtonsoft.Json.JsonProperty("stabilityTestingTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StabilityTestingTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("stabilityTestingType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public StabilityTestingType StabilityTestingType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("locationOfStabilityData", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LocationOfStabilityData { get; set; }
    
        [Newtonsoft.Json.JsonProperty("panelistsInformedConsent", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? PanelistsInformedConsent { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isPanelistRequiredToSignCDA", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsPanelistRequiredToSignCDA { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supervisedProductUseId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SupervisedProductUseId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("supervisedProductUse", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public StudySupervisedProductUse SupervisedProductUse { get; set; }
    
        [Newtonsoft.Json.JsonProperty("panelistReturnsItems", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? PanelistReturnsItems { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasAttachedInstructions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? HasAttachedInstructions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isPanelistExposedToProduct", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsPanelistExposedToProduct { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestForSingleConsumerStudy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? RequestForSingleConsumerStudy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessRepetitiveTesting", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? AssessRepetitiveTesting { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestedExpirationDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? RequestedExpirationDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("taskOrNRQID", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TaskOrNRQID { get; set; }
    
        [Newtonsoft.Json.JsonProperty("legacyRqOrRef", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LegacyRqOrRef { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyPlacementMarkets", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyMarket> StudyPlacementMarkets { get; set; }
    
        [Newtonsoft.Json.JsonProperty("estimatedStudyStartDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? EstimatedStudyStartDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("durationOfStudy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string DurationOfStudy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productUseLocations", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyStudyProductUseLocation> ProductUseLocations { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productUseLocationOther", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductUseLocationOther { get; set; }
    
        [Newtonsoft.Json.JsonProperty("distributingLocationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? DistributingLocationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("distributingLocation", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public StudyDistributingLocation DistributingLocation { get; set; }
    
        [Newtonsoft.Json.JsonProperty("addressIfOtherThanPGSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddressIfOtherThanPGSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("documents", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyDocument> Documents { get; set; }
    
        [Newtonsoft.Json.JsonProperty("legs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyLeg> Legs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("attachedFiles", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<StudyAttachedFile> AttachedFiles { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestStudy 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studyId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int StudyId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("request", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Request Request { get; set; }
    
        [Newtonsoft.Json.JsonProperty("study", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Study Study { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class AssessmentPart 
    {
        [Newtonsoft.Json.JsonProperty("assessmentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int AssessmentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessment", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Assessment Assessment { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Part Part { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class MarketClearanceAssessment 
    {
        [Newtonsoft.Json.JsonProperty("marketClearanceId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MarketClearanceId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketClearanceVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MarketClearanceVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int AssessmentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentTypeIsRegional", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool AssessmentTypeIsRegional { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulatoryPriority", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? RegulatoryPriority { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulatoryClassVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RegulatoryClassVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulatoryClassId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? RegulatoryClassId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int PartId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MarketId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketClearanceStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MarketClearanceStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketClearanceStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MarketClearanceStatus MarketClearanceStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestCompletedInPassAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? RequestCompletedInPassAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("initiativeStatusName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InitiativeStatusName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("initiativeStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InitiativeStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("initiativeStatusVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string InitiativeStatusVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plantRestrictions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlantRestrictions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("comments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Comments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GpsComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("packingSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PackingSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("bulkMakingSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BulkMakingSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("registrationId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? RegistrationId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Assessment 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentTypeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int AssessmentTypeId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentTypeVaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentTypeVaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessmentNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AssessmentNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RegionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<AssessmentPart> Parts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("marketClearances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<MarketClearanceAssessment> MarketClearances { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GpsApprovalFor 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class GpsEvaluationRequestedFor 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Request 
    {
        [Newtonsoft.Json.JsonProperty("plmTaskId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PlmTaskId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("originatorName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OriginatorName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestCategoryId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("estimatedUpperLevelUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CompUom EstimatedUpperLevelUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("salesSamplesId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SalesSamplesId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("salesSamples", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RequestSalesSample SalesSamples { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? BusinessId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("statusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("stateId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? StateId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialFunctionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? MaterialFunctionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("materialFunction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("overallRegClassification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("packageSizeUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PackageSizeUom PackageSizeUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("qtyShippedProducedUomId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? QtyShippedProducedUomId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("qtyShippedProducedUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("assessBusinessArea", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("materialVolumeUom", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public MaterialVolumeUom MaterialVolumeUom { get; set; }
    
        [Newtonsoft.Json.JsonProperty("finishedProductImportedAsId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? FinishedProductImportedAsId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("finishedProductImportedAs", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public FinishedProductImportedAs FinishedProductImportedAs { get; set; }
    
        [Newtonsoft.Json.JsonProperty("initiativeStatusId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? InitiativeStatusId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("initiativeStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public RequestStatus InitiativeStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("preClearanceLevelId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PreClearanceLevelId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("preClearanceLevel", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("lifeCycleState", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("documents", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestDocument> Documents { get; set; }
    
        [Newtonsoft.Json.JsonProperty("studies", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestStudy> Studies { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<RequestPart> Parts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("assessments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Assessment> Assessments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsApprovalForId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GpsApprovalForId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsApprovalFor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GpsApprovalFor GpsApprovalFor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsEvaluationRequestedForId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? GpsEvaluationRequestedForId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gpsEvaluationRequestedFor", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public GpsEvaluationRequestedFor GpsEvaluationRequestedFor { get; set; }
    
        [Newtonsoft.Json.JsonProperty("startOfProduction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? StartOfProduction { get; set; }
    
        [Newtonsoft.Json.JsonProperty("gcasAddition", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? GcasAddition { get; set; }
    
        [Newtonsoft.Json.JsonProperty("eeaSiteDetails", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EeaSiteDetails { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tonnesRMForEachSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TonnesRMForEachSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("eeaPlantsRMSiteShippedTo", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EeaPlantsRMSiteShippedTo { get; set; }
    
        [Newtonsoft.Json.JsonProperty("eeaReceivingSites", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EeaReceivingSites { get; set; }
    
        [Newtonsoft.Json.JsonProperty("nonEEASiteDetails", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string NonEEASiteDetails { get; set; }
    
        [Newtonsoft.Json.JsonProperty("annualVolRMForRecvSite", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AnnualVolRMForRecvSite { get; set; }
    
        [Newtonsoft.Json.JsonProperty("otherDetails", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OtherDetails { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fpNotClassifiedAsArticle", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? FpNotClassifiedAsArticle { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
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
    
        [Newtonsoft.Json.JsonProperty("createdBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User CreatedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modifiedBy", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ModifiedBy { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? ResponsibleUserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responsibleUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public User ResponsibleUser { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isCreatedInThisTransaction", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsCreatedInThisTransaction { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestCommentWithUser 
    {
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("commentAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CommentAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("commentText", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CommentText { get; set; }
    
        [Newtonsoft.Json.JsonProperty("username", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Username { get; set; }
    
        [Newtonsoft.Json.JsonProperty("email", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Email { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultUserId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int VaultUserId { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class RequestComment 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int RequestId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("userId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int UserId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("commentAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CommentAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("commentText", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CommentText { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum TermType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"All")]
        All = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Name")]
        Name = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"SourceKey")]
        SourceKey = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"SourceRevision")]
        SourceRevision = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"CommonName")]
        CommonName = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = @"TradeName")]
        TradeName = 5,
    
        [System.Runtime.Serialization.EnumMember(Value = @"CASNumber")]
        CASNumber = 6,
    
        [System.Runtime.Serialization.EnumMember(Value = @"ECNumber")]
        ECNumber = 7,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Description")]
        Description = 8,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Brands")]
        Brands = 9,
    
        [System.Runtime.Serialization.EnumMember(Value = @"ProductForms")]
        ProductForms = 10,
    
        [System.Runtime.Serialization.EnumMember(Value = @"GeneralComments")]
        GeneralComments = 11,
    
        [System.Runtime.Serialization.EnumMember(Value = @"LocalDescription")]
        LocalDescription = 12,
    
        [System.Runtime.Serialization.EnumMember(Value = @"SAPDescription")]
        SAPDescription = 13,
    
        [System.Runtime.Serialization.EnumMember(Value = @"OtherNames")]
        OtherNames = 14,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Technology")]
        Technology = 15,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Attribute")]
        Attribute = 16,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Term 
    {
        [Newtonsoft.Json.JsonProperty("text", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Text { get; set; }
    
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public TermType Type { get; set; }
    
        [Newtonsoft.Json.JsonProperty("attributeId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? AttributeId { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartCriteria 
    {
        [Newtonsoft.Json.JsonProperty("any1Term", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool Any1Term { get; set; }
    
        [Newtonsoft.Json.JsonProperty("terms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Term> Terms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PartIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partStatusIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PartStatusIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypeIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PartTypeIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmTypeIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PlmTypeIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStateIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PlmStateIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmStageIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PlmStageIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmPolicyIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PlmPolicyIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("plmFormulationTypeIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PlmFormulationTypeIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryOrganizationIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> PrimaryOrganizationIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("secondaryOrganizationids", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> SecondaryOrganizationids { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulationIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> RegulationIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("regulationGroupIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> RegulationGroupIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessAreaIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> BusinessAreaIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productCategoryPlatformIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> ProductCategoryPlatformIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productTechnologyChassisIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> ProductTechnologyChassisIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productTechnologyPlatformIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> ProductTechnologyPlatformIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("clearances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Clearances { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isForPassOnly", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool? IsForPassOnly { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class PartResult 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcRevision", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcRevision { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("casNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CasNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("description", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Description { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ecNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EcNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("generalComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string GeneralComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("localDescription", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LocalDescription { get; set; }
    
        [Newtonsoft.Json.JsonProperty("otherNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OtherNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("title", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Title { get; set; }
    
        [Newtonsoft.Json.JsonProperty("productForms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ProductForms { get; set; }
    
        [Newtonsoft.Json.JsonProperty("technology", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Technology { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tradeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TradeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partStatusName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartStatusName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partPlmStateName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PartPlmStateName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryOrganizationName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PrimaryOrganizationName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("secondaryOrganizationNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SecondaryOrganizationNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("baNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string BaNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pcpNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PcpNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ptcNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PtcNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ptpNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PtpNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("ingredientClassName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string IngredientClassName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("functionNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FunctionNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vendorName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VendorName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestRegions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestRegions { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestBusinessAreaName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestBusinessAreaName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestPcpNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestPcpNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestRsrNumbers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestRsrNumbers { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestClearanceLevelName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestClearanceLevelName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestStatusName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestStatusName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestComments", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestComments { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestMaxAmount", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestMaxAmount { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestMaxAmountUomName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestMaxAmountUomName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestFunctionNames", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestFunctionNames { get; set; }
    
        [Newtonsoft.Json.JsonProperty("requestGpsProductTypes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RequestGpsProductTypes { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class BasicQuery 
    {
        [Newtonsoft.Json.JsonProperty("filter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartCriteria Filter { get; set; }
    
        [Newtonsoft.Json.JsonProperty("results", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<PartResult> Results { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeClearances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeClearances { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PageSize { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pageRequested", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PageRequested { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum WhereUsedQueryHierarchySearchType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Deep")]
        Deep = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Direct")]
        Direct = 1,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum WhereUsedQueryConcentrationFilterTypeFieldEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = @"PrimaryLow")]
        PrimaryLow = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"PrimaryTarget")]
        PrimaryTarget = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"PrimaryHigh")]
        PrimaryHigh = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"WithSubsLow")]
        WithSubsLow = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"WithSubsTarget")]
        WithSubsTarget = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = @"WithSubsHigh")]
        WithSubsHigh = 5,
    
        [System.Runtime.Serialization.EnumMember(Value = @"WithSubsAltsLow")]
        WithSubsAltsLow = 6,
    
        [System.Runtime.Serialization.EnumMember(Value = @"WithSubsAltsTarget")]
        WithSubsAltsTarget = 7,
    
        [System.Runtime.Serialization.EnumMember(Value = @"WithSubsAltsHigh")]
        WithSubsAltsHigh = 8,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum WhereUsedQueryConcentrationFilterTypeOperatorEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = @"GreaterThan")]
        GreaterThan = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"GreaterThanOrEqualTo")]
        GreaterThanOrEqualTo = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"LessThan")]
        LessThan = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"LessThanOrEqualTo")]
        LessThanOrEqualTo = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Equal")]
        Equal = 4,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum WhereUsedQueryConcentrationFilterTypeUnitEnum
    {
        [System.Runtime.Serialization.EnumMember(Value = @"Percent")]
        Percent = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Ppm")]
        Ppm = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Ppb")]
        Ppb = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class WhereUsedQueryConcentrationFilterType 
    {
        [Newtonsoft.Json.JsonProperty("value", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? Value { get; set; }
    
        [Newtonsoft.Json.JsonProperty("field", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public WhereUsedQueryConcentrationFilterTypeFieldEnum Field { get; set; }
    
        [Newtonsoft.Json.JsonProperty("operator", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public WhereUsedQueryConcentrationFilterTypeOperatorEnum Operator { get; set; }
    
        [Newtonsoft.Json.JsonProperty("unit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public WhereUsedQueryConcentrationFilterTypeUnitEnum Unit { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class WhereUsedQueryResult 
    {
        [Newtonsoft.Json.JsonProperty("containingPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartResult ContainingPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("containedPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartResult ContainedPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("compositionTypeName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CompositionTypeName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("activeImpurityCarryover", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ActiveImpurityCarryover { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryAicn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PrimaryAicn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? PrimaryLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? PrimaryTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("primaryHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? PrimaryHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsAicn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SubsAicn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SubsLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SubsTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SubsHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsAltsAicn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SubsAltsAicn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsAltsLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SubsAltsLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsAltsTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SubsAltsTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("subsAltsHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SubsAltsHigh { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class WhereUsedQuery 
    {
        [Newtonsoft.Json.JsonProperty("parentFilter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartCriteria ParentFilter { get; set; }
    
        [Newtonsoft.Json.JsonProperty("filter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public PartCriteria Filter { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeSubstitutes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeSubstitutes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("searchType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public WhereUsedQueryHierarchySearchType SearchType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("deepCompositionTypeIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> DeepCompositionTypeIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("directCompositionTypeIds", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> DirectCompositionTypeIds { get; set; }
    
        [Newtonsoft.Json.JsonProperty("concentrationFilter", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public WhereUsedQueryConcentrationFilterType ConcentrationFilter { get; set; }
    
        [Newtonsoft.Json.JsonProperty("results", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<WhereUsedQueryResult> Results { get; set; }
    
        [Newtonsoft.Json.JsonProperty("includeClearances", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IncludeClearances { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pageSize", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PageSize { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pageRequested", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? PageRequested { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SriLoaderPartChoice 
    {
        [Newtonsoft.Json.JsonProperty("lineNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LineNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("part_Id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Part_Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("casNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string CasNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("matchType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MatchType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("matchRank", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int MatchRank { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("usInciName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string UsInciName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("euInciName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EuInciName { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SriLoaderFilePart 
    {
        [Newtonsoft.Json.JsonProperty("feedstock_Origin", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Feedstock_Origin { get; set; }
    
        [Newtonsoft.Json.JsonProperty("feedstock_OriginDisplay", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Feedstock_OriginDisplay { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lineNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int LineNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("exactAttribute", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExactAttribute { get; set; }
    
        [Newtonsoft.Json.JsonProperty("exactName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExactName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("wildcardAttribute", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WildcardAttribute { get; set; }
    
        [Newtonsoft.Json.JsonProperty("wildcardName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string WildcardName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("searchTerm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SearchTerm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lowTargetHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LowTargetHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("aicnFlag", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AicnFlag { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? SrcHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjLow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjLow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjTarget", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjTarget { get; set; }
    
        [Newtonsoft.Json.JsonProperty("adjHigh", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public double? AdjHigh { get; set; }
    
        [Newtonsoft.Json.JsonProperty("srcUomName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SrcUomName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("partChoices", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SriLoaderPartChoice> PartChoices { get; set; }
    
        [Newtonsoft.Json.JsonProperty("chosenPart", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public SriLoaderPartChoice ChosenPart { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errorMessage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ErrorMessage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isWarning", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsWarning { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasSubstitutes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HasSubstitutes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("isSubstitute", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSubstitute { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substituteOf", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SubstituteOf { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substituteOfSearchTerm", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SubstituteOfSearchTerm { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substituteOfRow", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int? SubstituteOfRow { get; set; }
    
        [Newtonsoft.Json.JsonProperty("substituteOfRowGroup", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public float? SubstituteOfRowGroup { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SriLoaderFile 
    {
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sriKey", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SriKey { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fileName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FileName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sriName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SriName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fileParts", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<SriLoaderFilePart> FileParts { get; set; }
    
        [Newtonsoft.Json.JsonProperty("rowsWithSubstitutes", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<int> RowsWithSubstitutes { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Errors { get; set; }
    
        [Newtonsoft.Json.JsonProperty("canSubmit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool CanSubmit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasWarning", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HasWarning { get; set; }
    
        [Newtonsoft.Json.JsonProperty("hasSubstitute", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool HasSubstitute { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SriLoaderSubmitResponse 
    {
        [Newtonsoft.Json.JsonProperty("isSuccess", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public bool IsSuccess { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errorMessages", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ErrorMessages { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum DepotStorageType
    {
        [System.Runtime.Serialization.EnumMember(Value = @"PlmXmls")]
        PlmXmls = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"Log")]
        Log = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"IrmDocs")]
        IrmDocs = 2,
    
        [System.Runtime.Serialization.EnumMember(Value = @"GpsBosWorkbooks")]
        GpsBosWorkbooks = 3,
    
        [System.Runtime.Serialization.EnumMember(Value = @"TomcatWrite")]
        TomcatWrite = 4,
    
        [System.Runtime.Serialization.EnumMember(Value = @"PassReportLogs")]
        PassReportLogs = 5,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StorageFile 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("size", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public long Size { get; set; }
    
        [Newtonsoft.Json.JsonProperty("creationTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? CreationTime { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lastWriteTime", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? LastWriteTime { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class StorageFileHandle 
    {
        [Newtonsoft.Json.JsonProperty("handleId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string HandleId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("path", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Path { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fileId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FileId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("parentId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ParentId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("sessionId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string SessionId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("clientIp", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ClientIp { get; set; }
    
        [Newtonsoft.Json.JsonProperty("openedOn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? OpenedOn { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lastReconnectedOn", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset? LastReconnectedOn { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ValueTupleOfDepotStorageTypeAndstringAndint 
    {
        [Newtonsoft.Json.JsonProperty("item1", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public DepotStorageType Item1 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("item2", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Item2 { get; set; }
    
        [Newtonsoft.Json.JsonProperty("item3", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Item3 { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class ToxControllerToxListArg 
    {
        [Newtonsoft.Json.JsonProperty("terms", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Terms { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class Vault_membership 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("active__vd", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Active__vd { get; set; }
    
        [Newtonsoft.Json.JsonProperty("security_profile__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Security_profile__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("license_type__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string License_type__v { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class UserMetadata 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user_name__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_name__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user_email__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_email__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user_first_name__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_first_name__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user_last_name__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_last_name__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user_timezone__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_timezone__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user_locale__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_locale__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user_title__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_title__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("office_phone__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Office_phone__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("fax__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Fax__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("mobile_phone__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Mobile_phone__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("site__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Site__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("is_domain_admin__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Is_domain_admin__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("active__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Active__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("domain_active__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Domain_active__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("security_policy_id__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Security_policy_id__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user_needs_to_change_password__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_needs_to_change_password__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created_date__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Created_date__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("created_by__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Created_by__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified_date__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Modified_date__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("modified_by__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Modified_by__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("domain_id__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Domain_id__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("domain_name__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Domain_name__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("federated_id__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Federated_id__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("salesforce_user_name__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Salesforce_user_name__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("last_login__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Last_login__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("user_language__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string User_language__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("company__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Company__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("group_id__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Group_id__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("security_profile__v", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Security_profile__v { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vault_membership", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<Vault_membership> Vault_membership { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class UserWrapper 
    {
        [Newtonsoft.Json.JsonProperty("user", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public UserMetadata User { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum VaultResponseStatus
    {
        [System.Runtime.Serialization.EnumMember(Value = @"SUCCESS")]
        SUCCESS = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"FAILURE")]
        FAILURE = 1,
    
        [System.Runtime.Serialization.EnumMember(Value = @"EXCEPTION")]
        EXCEPTION = 2,
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class VaultError 
    {
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Type { get; set; }
    
        [Newtonsoft.Json.JsonProperty("message", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Message { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class UserMetadataResponse 
    {
        [Newtonsoft.Json.JsonProperty("users", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<UserWrapper> Users { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responseStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public VaultResponseStatus ResponseStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responseMessage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResponseMessage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<VaultError> Errors { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class EnoviaUser 
    {
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
        [Newtonsoft.Json.JsonProperty("emailAddress", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string EmailAddress { get; set; }
    
        [Newtonsoft.Json.JsonProperty("firstName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string FirstName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("middleInit", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string MiddleInit { get; set; }
    
        [Newtonsoft.Json.JsonProperty("lastName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string LastName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("tNumber", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string TNumber { get; set; }
    
        [Newtonsoft.Json.JsonProperty("accountType", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AccountType { get; set; }
    
        [Newtonsoft.Json.JsonProperty("externalRole", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExternalRole { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pgManagerOrSponsorName", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PgManagerOrSponsorName { get; set; }
    
        [Newtonsoft.Json.JsonProperty("pgManagerOrSponsorEmail", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string PgManagerOrSponsorEmail { get; set; }
    
        [Newtonsoft.Json.JsonProperty("applications", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Applications { get; set; }
    
        [Newtonsoft.Json.JsonProperty("businessRoles", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> BusinessRoles { get; set; }
    
        [Newtonsoft.Json.JsonProperty("enoviaRoles", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> EnoviaRoles { get; set; }
    
        [Newtonsoft.Json.JsonProperty("state", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string State { get; set; }
    
        [Newtonsoft.Json.JsonProperty("company", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Company { get; set; }
    
        [Newtonsoft.Json.JsonProperty("registrationDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string RegistrationDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("expirationDate", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ExpirationDate { get; set; }
    
        [Newtonsoft.Json.JsonProperty("approvers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> Approvers { get; set; }
    
        [Newtonsoft.Json.JsonProperty("owningSecurityCategoryClassification", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string OwningSecurityCategoryClassification { get; set; }
    
        [Newtonsoft.Json.JsonProperty("restrictedSecurityCategoryClassifications", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> RestrictedSecurityCategoryClassifications { get; set; }
    
        [Newtonsoft.Json.JsonProperty("highlyRestrictedSecurityCategoryClassifications", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> HighlyRestrictedSecurityCategoryClassifications { get; set; }
    
        [Newtonsoft.Json.JsonProperty("projectSecurityClassifications", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<string> ProjectSecurityClassifications { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class EnoviaUsers 
    {
        [Newtonsoft.Json.JsonProperty("enoviaUser", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<EnoviaUser> EnoviaUser { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class VaultIdResponse 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public int Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responseStatus", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        [Newtonsoft.Json.JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public VaultResponseStatus ResponseStatus { get; set; }
    
        [Newtonsoft.Json.JsonProperty("responseMessage", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string ResponseMessage { get; set; }
    
        [Newtonsoft.Json.JsonProperty("errors", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<VaultError> Errors { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class SynchronizePassVaultIdsResult 
    {
        [Newtonsoft.Json.JsonProperty("fixedUsers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<User> FixedUsers { get; set; }
    
        [Newtonsoft.Json.JsonProperty("newUsers", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.Collections.Generic.ICollection<User> NewUsers { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class VaultReportType 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("name", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Name { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class VaultReportRequest 
    {
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public VaultReportType Type { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public partial class VaultReportRequestItem 
    {
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("createdAt", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public System.DateTimeOffset CreatedAt { get; set; }
    
        [Newtonsoft.Json.JsonProperty("key", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Key { get; set; }
    
        [Newtonsoft.Json.JsonProperty("vaultId", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string VaultId { get; set; }
    
        [Newtonsoft.Json.JsonProperty("type", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public VaultReportType Type { get; set; }
    
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.2.0.0 (Newtonsoft.Json v9.0.0.0)")]
    public enum BomOrBos
    {
        [System.Runtime.Serialization.EnumMember(Value = @"BOM")]
        BOM = 0,
    
        [System.Runtime.Serialization.EnumMember(Value = @"BOS")]
        BOS = 1,
    
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.8.1.0 (NJsonSchema v10.2.0.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class FileParameter
    {
        public FileParameter(System.IO.Stream data)
            : this (data, null, null)
        {
        }

        public FileParameter(System.IO.Stream data, string fileName)
            : this (data, fileName, null)
        {
        }

        public FileParameter(System.IO.Stream data, string fileName, string contentType)
        {
            Data = data;
            FileName = fileName;
            ContentType = contentType;
        }

        public System.IO.Stream Data { get; private set; }

        public string FileName { get; private set; }

        public string ContentType { get; private set; }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.8.1.0 (NJsonSchema v10.2.0.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class ApiException : System.Exception
    {
        public int StatusCode { get; private set; }

        public string Response { get; private set; }

        public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
            : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
        {
            StatusCode = statusCode;
            Response = response; 
            Headers = headers;
        }

        public override string ToString()
        {
            return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
        }
    }

    [System.CodeDom.Compiler.GeneratedCode("NSwag", "13.8.1.0 (NJsonSchema v10.2.0.0 (Newtonsoft.Json v9.0.0.0))")]
    public partial class ApiException<TResult> : ApiException
    {
        public TResult Result { get; private set; }

        public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, TResult result, System.Exception innerException)
            : base(message, statusCode, response, headers, innerException)
        {
            Result = result;
        }
    }

}

#pragma warning restore 1591
#pragma warning restore 1573
#pragma warning restore  472
#pragma warning restore  114
#pragma warning restore  108