using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NCDSB_Conference_App.Models
{
    public class Conference
    {
        public int ID { get; set; }

        [Display(Name = "Conference Name")]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Display(Name = "Conference Start Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "This field is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Conference End Date")]
        [DataType(DataType.DateTime)]
        [Required(ErrorMessage = "This field is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Conference Location")]
        [Required(ErrorMessage = "This field is required")]
        public string Location { get; set; }

        [Display(Name = "Conference Description")]
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; }

        public virtual ICollection<Mileage> Mileages { get; set; }
    }

    public class Conference_Cost_Lookup
    {
        [ForeignKey("Conference")]
        public int ID { get; set; }

        [Display(Name = "Registration Cost")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Currency)]
        public decimal RegistrationCost { get; set; }

        [Display(Name = "Meal Cost")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Currency)]
        public decimal MealCost { get; set; }

        [Display(Name = "Accomodation Cost")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Currency)]
        public decimal AccomodationCost { get; set; }

        [Display(Name = "Other Cost")]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Currency)]
        public decimal OtherCost { get; set; }

        public decimal TotalCost
        {
            get
            {
                return RegistrationCost + MealCost + AccomodationCost + OtherCost;
            }
        }

        public virtual Conference Conference { get; set; }

        public virtual ICollection<ConferenceUser> Users { get; set; }

    }
}