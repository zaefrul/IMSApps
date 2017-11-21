using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMSApps_v1.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Ic { get; set; }
        public string FullName()
        {
            return FirstName + " " + LastName;
        }
    }
}