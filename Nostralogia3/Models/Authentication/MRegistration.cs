using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Authentication
{
    public class MRegistration : MUserBase
    {
        [DisplayName("User Name")]
        [Required(ErrorMessage = "User Name cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public short? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }
        public string  FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public DateTime? DOB { get; set; }
        public byte? Sex { get; set; }
    }
}
