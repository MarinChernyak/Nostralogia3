using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Geo
{
    public class EventPlaceModel
    {
        [DisplayName("Country (Optional)")]
        public short? Country { get; set; }
        [DisplayName("State/Province/Land (Optional)")]
        public int? State { get; set; }
        [DisplayName("City/Town/Village (Optional)")]
        public int? City { get; set; }

        public List<SelectListItem> Countries { get; protected set; }
        public List<SelectListItem> States { get; protected set; }
        public List<SelectListItem> Cities { get; protected set; }
        public EventPlaceModel()
        {
            FillUpCountries();
            States = new List<SelectListItem>();
            Cities = new List<SelectListItem>();
        }
        protected void FillUpCountries()
        {
            GeoFactory fact = new GeoFactory();
            Countries = fact.GetCountriesListCollection();
            Countries.Insert(0, new SelectListItem()
            {
                Text = Constants.ZeroStringComboText,
                Value = Constants.ZeroStringComboValue
            });
        }
    }
}
