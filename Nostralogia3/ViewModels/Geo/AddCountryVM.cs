using Nostralogia3.Models.Factories;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels.Geo
{
    public class AddCountryVM
    {
        [DisplayName("Enter a country name")]
        public string CountryName { get; set; }
        [DisplayName("Enter an acronym")]
        public string CountryAcr { get; set; }


        public async Task<bool> AddCountry()
        {
            GeoFactory fact = new GeoFactory();
            return await fact.AddCountry(CountryName,CountryAcr);            
        }
    }
}
