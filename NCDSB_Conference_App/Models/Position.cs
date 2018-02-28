using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NCDSB_Conference_App.Models
{
    public class Position //This class might not be needed though. To be discussed
    {
        public int ID { get; set; }

        [Display(Name = "Position")]
        [Required(ErrorMessage = "Please provide position name")]
        public string Name { get; set; }

        public virtual ICollection<Security.User> Users { get; set; } //Might be replaced with a better name
    }
}