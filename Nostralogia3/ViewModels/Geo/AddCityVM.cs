using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Common;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Geo;
using NostralogiaDAL.NostraGeoEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels.Geo
{
    public class AddCityVM : ViewModelBase 
    {
        public short CountryRef { get; set; } = 0;
        public int StateRegionRef { get; set; } = 0;
        public string CityName { get; set; }
        public CoordinatesModel Coordinates { get; set; }   = new CoordinatesModel();
        public short TimeZone { get; set; }
        
        public List<SelectListItem> StatesRegions { get; set; }=new List<SelectListItem>();
        public List<SelectListItem> Countries { get; set; }
        public List<SelectListItem> TimeZonesCollection { get; set; }
        public AddCityVM()
        {
            GeoFactory fact = new GeoFactory();
            
            Countries = fact.GetCountriesListCollection();
            TimeZonesCollection = fact.GetTimeZones();
          
        }
        protected void SetStatesCollections()
        {
            GeoFactory fact = new GeoFactory();
            StatesRegions = fact.GetStatesListCollection(CountryRef);
        }
        public async Task<bool> AddCity()
        {
            GeoFactory fact = new GeoFactory();
            City ct = new City()
            {
                CityName = CityName,
                Country = CountryRef,
                Latitude = Coordinates.GetLaitude(),
                Longitude = Coordinates.GetLongitude(),
                RegionState = StateRegionRef<0? 0: StateRegionRef,
                TimeZone = TimeZone
            };
            int err= await fact.AddCity(ct);
            //if(err>0)
            //{
            //    ErrMessagesCollection errcol = new ErrMessagesCollection();
            //    ErrorMessage = errcol.GetMessage(err);
            //}
            return err== (int)ErrMessagesCollection.Errors.NoErrors;
        }

    }
}
