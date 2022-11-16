using Microsoft.AspNetCore.Mvc;
using Nostralogia3.ViewModels.Geo;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.Geo
{
    public class GeoController : BaseController
    {
        public IActionResult AddCountry()
        {
            AddCountryVM model = new AddCountryVM();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddCountry(AddCountryVM model)
        {
            bool brez = false;
            if(ModelState.IsValid)
            {
                brez = await model.AddCountry();
            }
            if (brez)
            {
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                return RedirectToAction("AddCountry");
            }
        }
        public IActionResult AddStateProvince()
        {
            AddStateProvinceVM model = new AddStateProvinceVM();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddStateProvince(AddStateProvinceVM model)
        {
            bool brez = false;
            if (ModelState.IsValid)
            {
                brez = await model.AddStateProvince();
            }
            if (brez)
            {
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                return RedirectToAction("AddStateProvince");
            }
        }
        public IActionResult AddCity()
        {
            AddCityVM model = new AddCityVM();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddCity(AddCityVM model)
        {
            bool brez = false;
            if (ModelState.IsValid)
            {
                brez = await model.AddCity();
            }
            if (brez)
            {
                return RedirectToAction("HomePage", "Home");
            }
            else
            {
                return RedirectToAction("AddStateProvince");
            }
        }
    }
}
