using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Factories;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels.Geo
{
    public class AddStateProvinceVM
    {
        [DisplayName("Enter a State/Province name")]
        public string ProvinceName { get; set; }
        [DisplayName("Enter an acronym")]
        public string ProvinceAcr { get; set; }
        [DisplayName("Select a Country")]
        public short CountryRef { get; set; }
        public List<SelectListItem> Countries { get; protected set; }

        public AddStateProvinceVM()
        {
            GetCountryCollection();
        }
        protected void GetCountryCollection()
        {
            GeoFactory fact = new GeoFactory();
            Countries=fact.GetCountriesListCollection();
        }
        public async Task<bool> AddStateProvince()
        {
            GeoFactory fact = new GeoFactory();
            return await fact.AddStateProvince(ProvinceName, ProvinceAcr, CountryRef);
        }
    }
}
