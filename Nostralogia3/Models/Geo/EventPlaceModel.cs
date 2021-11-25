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
        public short? CountryId { get; set; }
        [DisplayName("State/Province/Land (Optional)")]
        public int? StateId { get; set; }
        [DisplayName("City/Town/Village (Optional)")]
        public int? PlaceId { get; set; }


        public List<SelectListItem> Countries { get; protected set; }
        public List<SelectListItem> States { get; protected set; }
        public List<SelectListItem> Cities { get; protected set; }
        public EventPlaceModel()
        {
            FillUpCountries();
            States = new List<SelectListItem>();
            Cities = new List<SelectListItem>();
        }
        public EventPlaceModel(short? countryId, int? stateId, int? cityId)
        {

            CountryId =countryId??0;
            StateId = stateId??0;
            PlaceId = cityId??0;

            FillUpCountries();
            if (CountryId > 0)
            {
                UpdateStates();
            }
            else
            {
                States = new List<SelectListItem>();
                Cities = new List<SelectListItem>();
            }
            if(StateId > 0)
            {
                UpdateCitiesByStates();
            }
            else if(Cities == null)
            {
                Cities = new List<SelectListItem>();
            }
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
            SelectListItem item = Countries.FirstOrDefault(x => x.Value == CountryId.ToString());
            if(item!=null)
            {
                item.Selected = true;
            }
        }
        public void UpdateStates()
        {
            GeoFactory fact = new GeoFactory();
            List<List<SelectListItem>> list = fact.GetStatesCitiesByCountry(CountryId);
            States = list[0];
            if (StateId > 0)
            {
                SelectListItem item = States.FirstOrDefault(x => x.Value == StateId.ToString());
                if(item!=null)
                {
                    item.Selected = true;
                    
                }
            }
            else
            {
                Cities = list[1];
                if (PlaceId > 0)
                {
                    SelectListItem item = Cities.FirstOrDefault(x => x.Value == PlaceId.ToString());
                    if (item != null)
                    {
                        item.Selected = true;
                    }
                }
            }
        }
        public void UpdateCitiesByStates()
        {
            GeoFactory fact = new GeoFactory();
            Cities = fact.GetCitiesListCollection(0,(int)StateId);
            if (PlaceId > 0)
            {

                SelectListItem item = Cities.FirstOrDefault(x => x.Value == PlaceId.ToString());
                if (item != null)
                {
                    item.Selected = true;
                }
            }
        }
    }
}
