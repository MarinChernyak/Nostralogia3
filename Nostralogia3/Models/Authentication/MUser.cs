using Microsoft.AspNetCore.Mvc.Rendering;
using NostralogiaDAL.NostradamusEntities;
using NostralogiaDAL.SMGeneralEntities;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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
        public short? Sex { get; set; }

        public List<SelectListItem> SexCollection { get; protected set; }
        public MUser()
        {
            FillUpSexCollection();
        }
        protected void FillUpSexCollection()
        {
            using(NostradamusContext context = new NostradamusContext())
            {
                SexCollection = new List<SelectListItem>();
                List<SexDatum> lst = context.SexData.ToList();
                foreach(SexDatum sd in lst)
                {
                    SexCollection.Add(new SelectListItem()
                    {
                        Text = sd.SexDescription,
                        Value = sd.SexId.ToString(),
                        Selected = sd.SexId == 3 ? true : false
                    });
                }
            }
        }
    }
}
