using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NCDSB_Conference_App.Models
{
    public class Mileage
    {
        public int ID { get; set; }

        [Display(Name = "Estimated Cost")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Currency)]
        public decimal EstimatedCost { get; set; }

        [Display(Name = "Actual Cost")]
        [DataType(DataType.Currency)]
        public decimal ActualCost { get; set; }

        public virtual Conference Conference { get; set; }

        [Display(Name = "Confirmation receipt")]
        public int ReceiptImageID{ get; set; }

        [Display(Name = "Applicant")]
        public int UserID { get; set;}

        [Display(Name = "Conference")]
        public int ConferenceID { get; set; }
    }
}