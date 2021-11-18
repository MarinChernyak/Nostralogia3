using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.SMGeneralEntities
{
    public partial class User
    {
        public User()
        {
            UserAppRoles = new HashSet<UserAppRole>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
        public short? CountryId { get; set; }
        public int? StateId { get; set; }
        public int? PlaceId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public DateTime? Dob { get; set; }
        public byte? Sex { get; set; }
        public string Token { get; set; }

        public virtual ICollection<UserAppRole> UserAppRoles { get; set; }
    }
}
