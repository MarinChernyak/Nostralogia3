using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.Geo;
using Nostralogia3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.MainActions
{
    public class WorldEventController : Controller
    {
        public IActionResult Index()
        {
            EventDataVM model = new EventDataVM(HttpContext.Session);
            return View("~/Views/DataWorking/DataEventView.cshtml", model);
        }
        [HttpPost]
        public PartialViewResult GetPlaceDataView(int idPlacedata)
        {
            switch(idPlacedata)
            {
                case (int)PlaceDataCommon.PlaceDataType.City:
                    return PartialView("~/Views/UserControls/_EventPlaceView.cshtml", new EventPlaceModel(@"City\Vilage of the Event"));                   
                case (int)PlaceDataCommon.PlaceDataType.Coordinates:
                    return PartialView("~/Views/UserControls/_EventCoordinatesView.cshtml", new CoordinatesModel("Coordinates of the Event"));
                case (int)PlaceDataCommon.PlaceDataType.Expansion:
                    return PartialView("~/Views/UserControls/_EventExpansionView.cshtml", new ExpansionModel("Expansion of the Event"));
                default:
                    return PartialView("~/Views/UserControls/_EventPlaceView.cshtml", new EventPlaceModel());
            };
        }
    }
}
