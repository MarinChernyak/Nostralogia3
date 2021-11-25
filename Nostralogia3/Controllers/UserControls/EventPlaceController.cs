using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.UserControls
{
    public class EventPlaceController : Controller
    {
        [HttpPost]
        public JsonResult CountryChangedValue(short? Id)
        {
            GeoFactory fact = new GeoFactory();
            List<List<SelectListItem>> lst = fact.GetStatesCitiesByCountry(Id);
            
            return Json(lst);
        }
        [HttpPost]
        public JsonResult StateChangedValue(int Id)
        {
            GeoFactory fact = new GeoFactory();
            List<SelectListItem> lst = fact.GetCitiesListCollection(0,Id);

            return Json(lst);
        }
    }
}
