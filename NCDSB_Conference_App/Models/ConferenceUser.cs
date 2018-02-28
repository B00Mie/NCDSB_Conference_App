using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NCDSB_Conference_App.Models
{
    public class ConferenceUser
    {
        public int ConferenceID { get; set; }

        public int UserID { get; set; }

        public virtual Conference Conference { get; set; }

        public virtual Security.User User { get; set; }

        public bool mileageSubmitted { get; set; }
    }
}