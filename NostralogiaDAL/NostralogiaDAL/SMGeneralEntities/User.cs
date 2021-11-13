using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.SMGeneralEntities
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool? IsActive { get; set; }
        public DateTime ActivationDate { get; set; }
        public short? Country { get; set; }
        public int? State { get; set; }
        public int? City { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MidleName { get; set; }
        public DateTime? Dob { get; set; }
        public byte? Sex { get; set; }
    }
}
