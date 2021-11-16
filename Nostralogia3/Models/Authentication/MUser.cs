using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nostralogia3.Models.Authentication
{
    public class MUser : MUserBase
    {
        [DisplayName("Enter Email")]
        [Required(ErrorMessage = "Email cannot be empty")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [DisplayName("Country (Optional)")]
        public short? Country { get; set; }
        [DisplayName("State/Province/Land (Optional)")]
        public int? State { get; set; }
        [DisplayName("City/Town (Optional)")]
        public int? City { get; set; }
        [DisplayName("First Name (Optional)")]
        public string  FirstName { get; set; }
        [DisplayName("Last Name (Optional)")]
        public string LastName { get; set; }
        [DisplayName("Midle Name (Optional)")]
        public string MidleName { get; set; }
        [DisplayName("Gender (Optional)")]
        public byte? Sex { get; set; }
    }
}
