using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SDS.SDSRequest.Models
{
    [Table("requestactivity")]
    public class RequestActivity
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int RequestActivityId { get; set; } //int

        [Column(Order = 1)]
        [Required]
        [Display(Name = "Request#")]
        public int RequestId { get; set; }   //int

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status is required")]
        public short RequestStatusId { get; set; }

        [Display(Name = "Owner")]
        [Required(ErrorMessage = "Owner is required")]
        public string RequestOwnerId { get; set; }

        [Display(Name = "Activity Comment")]
        //[StringLength(1000, ErrorMessage = "Activity Comment is required")]
        [Required(ErrorMessage = "Activity Comment is required")]
        public string ActivityComment { get; set; }   //varchar(100)

        //[Required]
        public DateTime UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }   //varchar(100)
    }

    public class RequestActivityViewModel
    {
        public RequestActivityViewModel()
        {
            RequestActivity = new RequestActivity();
            //RequestActivity.RequestId = requestId;
        }
        //http://stackoverflow.com/questions/14304331/mvc-4-simple-populate-dropdown-from-database-model
        //public int RequestId { get; set; }
        public RequestActivity RequestActivity { get; set; }
        public IEnumerable<SelectListItem> RequestStatuses { get; set; }
        public IEnumerable<SelectListItem> Owners { get; set; }
    }
    public class RequestActivityListItem
    {
        [Key]
        [Required]
        public int RequestActivityId { get; set; } //int

        [Required]
        public int RequestId { get; set; }   //int

        [Display(Name = "Status")]
        public string StatusText { get; set; }

        [Display(Name = "Owner")]
        public string RequestOwnerText { get; set; }

        [Required]
        [Display(Name = "Activity Comment")]
        [StringLength(1000, ErrorMessage = "Activity Comment is required")]
        public string ActivityComment { get; set; }   //varchar(100)

        [Required]
        [Display(Name = "Update Date")]
        public DateTime UpdatedDate { get; set; }

        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }   //varchar(100)
    }
}