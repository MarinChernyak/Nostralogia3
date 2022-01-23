using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.UserControls.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.UserControls
{
    public class PersonalEventController : Controller
    {
        public ActionResult PersonalEventEdit(int IdPerson)
        {
            PersonalEventModel model = new PersonalEventModel(IdPerson);
            return View("~/Views/DataWorking/EditPersonalEventView.cshtml", model);
        }
        [HttpPost]
        public JsonResult EventCategoryChangedValue(short Id)
        {
            List<SelectListItem> lst = EventsDataFactory.GetPersonalEventsKinds(Id);
            return Json(lst);
        }
        [HttpPost]
        public ActionResult SaveEvent(PersonalEventModel model)
        {
            List<SelectListItem> lst = EventsDataFactory.GetPersonalEventsKinds(Id);
            return Json(lst);
        }
    }
}
