using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc.Html;

namespace SDS.SDSRequest.Models
{

    public class AttributeValuePair
    {
        [Key]
        public string AttributeCode { get; set; }
        public string AttributeText { get; set; }
    }

    [Table("requeststatuses")]
    public class RequestStatus  //List of statuses stored in a database table
    {
        [Key]
        [HiddenInput]
        [Column("StatusId")]
        public int RequestStatusId { get; set; }

        [Column("StatusText")]
        public string RequestStatusText { get; set; }
    }

    public class SelectedRegion //List of regions stored in a database table
    {
        public SelectedRegion()
        {
            IsSelected = false; //default value
        }
        [Key]
        public int RegionId { get; set; }
        public string RegionText { get; set; }
        public bool IsSelected { get; set; }
    }

    [Table("requestuser")]
    public class RequestOwner //List of users in a database table
    {
        [Key]
        [Column("UserLogin")]
        public string RequestOwnerId { get; set; }
        [Column("UserText")]
        public string RequestOwnerText { get; set; }
    }

    public class ProductPhysicalState : AttributeValuePair { }
    public class BusinessUnit : AttributeValuePair { }
    public class Region : AttributeValuePair { }

    [Table("request")]
    public class Request
    {
        [Key]
        [Column(Order = 0)]
        public int RequestId { get; set; }

        [HiddenInput]
        public int RequestTypeId { get; set; }

        [Display(Name = "SDS training has been completed")]
        [Required(ErrorMessage = "You have to complete SDS training to proceed")]
        //[BooleanRequired(ErrorMessage = "You have to complete SDS training to proceed")]
        public bool IsCompletedSDSTraining { get; set; }

        [Display(Name = "Is Contract Manufacturer Formula?")]
        public bool IsContractManufacturerFormula { get; set; }

        [Display(Name = "Countries Where Product is to be placed on the market (comma-separated)")]
        //public string[] RequestCountryIdsArr { get; set; } //for use in view
        [Required(ErrorMessage = "Countries is required")]
        public string RequestCountries { get; set; } //maps to database comma-delimited column

        [Display(Name = "Request Languages (comma-separated)")]
        public string RequestLanguages { get; set; }

        [Display(Name = "Region (SDS required format)")]
        [Required(ErrorMessage = "Region is required")]
        //public short RegionId { get; set; }
        public string[] RequestRegionIdsArr { get; set; } //for use in view
        public string RequestRegionIds { get; set; } //maps to database comma-delimited column

        [Display(Name = "Product Type")]
        [Required(ErrorMessage = "Product Type is required")]
        public string ProductTypeId { get; set; }

        [Display(Name = "Product Physical State")]
        [Required(ErrorMessage = "Product Physical State is required")]
        public string ProductPhysicalStateId { get; set; }

        [Display(Name = "Business Unit")]
        [Required(ErrorMessage = "BU is required")]
        public string BUId { get; set; }

        //[HiddenInput]
        [Display(Name = "Requester First Name")]
        [Required(ErrorMessage = "Requester First Name is required")]
        public string RequesterFirstName { get; set; }

        //[HiddenInput]
        [Display(Name = "Requester Last Name")]
        [Required(ErrorMessage = "Requester Last Name is required")]
        public string RequesterLastName { get; set; }

        //[HiddenInput]
        [Display(Name = "Requester Email")]
        [Required(ErrorMessage = "Requester Email is required")]
        public string RequesterEmail { get; set; }

        [Display(Name = "Shipping Site")]
        //[Required(ErrorMessage = "Shipping Site is required")]
        public string ShippingSite { get; set; }

        [Display(Name = "Receiving Site")]
        //[Required(ErrorMessage = "Receiving Site is required")]
        public string ReceivingSite { get; set; }

        [Display(Name = "Storage Site")]
        //[Required(ErrorMessage = "Storage Site is required")]
        public string StorageSite { get; set; }

        [HiddenInput]
        [Display(Name = "Technical Contact First Name")]
        //[Required(ErrorMessage = "Technical Contact First Name is required")]
        public string TechnicalContactFirstName { get; set; }

        [HiddenInput]
        [Display(Name = "Technical Contact Last Name")]
        //[Required(ErrorMessage = "Technical Contact Last Name is required")]
        public string TechnicalContactLastName { get; set; }

        [HiddenInput]
        [Display(Name = "Technical Contact Email")]
        //[Required(ErrorMessage = "Technical Contact Email is required")]
        public string TechnicalContactEmail { get; set; }

        //[Display(Name = "Date Created")]
        //public DateTime? CreatedDate { get; set; }

        [Display(Name = "Requested By")]
        public string CreatedBy { get; set; }

        //public short Priority { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] //display as short date
        [Required(ErrorMessage = "Due Date is required")]
        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")] //display as short date
        [Display(Name = "External/Public Publish Date")]
        public DateTime? PublicPublishDate { get; set; }

        //[Display(Name = "Last Updated Date")]
        //public DateTime? LastUpdatedDate { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        public virtual ICollection<RequestActivity> RequestActivities { get; set; }

    }

    public class RequestViewModel //used to enter/edit a request
    {
        public RequestViewModel(string requestType)
        {
            SDSRequest = new Request();
            RequestTypeId = requestType;
            //SDSRequest.CreatedBy = HttpContext.User.Identity.Name.ToString(); ;
        }
        //http://stackoverflow.com/questions/14304331/mvc-4-simple-populate-dropdown-from-database-model
        public string RequestTypeId { get; set; }
        public Request SDSRequest { get; set; }
        public IEnumerable<SelectListItem> RequestStatuses { get; set; }
        public IEnumerable<SelectListItem> ProductTypes { get; set; }
        public IEnumerable<SelectListItem> ProductPhysicalStates { get; set; }
        public IEnumerable<SelectListItem> BusinessUnits { get; set; }
        public IEnumerable<SelectedRegion> AvailableRegions { get; set; }
        public IEnumerable<SelectedRegion> SelectedRegions { get; set; }
        public string[] SelectedRegionIds { get; set; }
        public IEnumerable<SelectListItem> Owners { get; set; }
    }

    public class RequestListItem //used to retrieve requests from the database
    {
        [Display(Name = "Request#")]
        public int RequestId { get; set; }

        [Display(Name = "Status")]
        public string StatusText { get; set; }

        [Display(Name = "Product Type")]
        public string ProductTypeText { get; set; }

        [Display(Name = "BU")]
        public string BUText { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }

        //public short Priority { get; set; }

        [Display(Name = "Due Date")]
        public DateTime? DueDate { get; set; }

        [Display(Name = "Last Updated Date")]
        public DateTime LastUpdatedDate { get; set; }

        [Display(Name = "Last Updated By")]
        public string LastUpdatedBy { get; set; }

        [Display(Name = "Owner")]
        public string RequestOwnerText { get; set; }

        [Display(Name = "Region")]
        public string RegionText { get; set; }
        /*
        [Display(Name = "Product GCAS")]
        public string ProductGcas { get; set; }

        [Display(Name = "Finished Product Name")]
        public string FinishedProductName { get; set; }
        */
    }
}