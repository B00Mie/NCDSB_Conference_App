using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace NCDSB_Conference_App.Models.Security
{
    public class User : IdentityUser
    {   
        public User(string userName) : base(userName)
        {

        }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please provide your first name")]
        public string FirstName { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please provide your first name")]
        public string LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ". 0").ToUpper()) + LastName;
            }
        }

        public string FormalName
        {
            get
            {
                return LastName + ", " + FirstName + (string.IsNullOrEmpty(MiddleName) ? "" : (" " + (char?)MiddleName[0] + ". ").ToUpper());
            }
        }
        
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please provide email")]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        public string eMail { get; set; }

        [Display(Name = "Gender")]
        //May also be required. Just afraid to be punished for not recognizing "not bi-gender folks"
        public string Gender { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }

        [Display(Name = "Age")]
        public int Age { get; set; }

        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Please provide the phone number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("^\\d{10}$", ErrorMessage = "Please provide a valid 10-digit phone number")]
        public Int64 Phone { get; set; }

        public virtual Position Position { get; set; }

        public virtual ICollection<ConferenceUser> Conferences { get; set; }

        public int PositionID { get; set; } //To be discussed

        public int ImageID { get; set; } //To be discussed

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<Security.User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}