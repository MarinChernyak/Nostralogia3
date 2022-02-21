using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.DataWorking;
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
        public ActionResult AddPersonalEvent(int IdPerson)
        {
            PersonalEventModel model = new PersonalEventModel(IdPerson,0);
            return View("~/Views/DataWorking/EditPersonalEventView.cshtml", model);
        }
        public ActionResult EditPersonalEvent(int IdEvent)
        {
            PersonalEventModel model = new PersonalEventModel(0,IdEvent);
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
            bool brez = false;
            if(ModelState.IsValid)
            {
                brez=EventsDataFactory.SavePersonalEvent(model);
            }
            if (brez)
            {
                MPersonalData pmodel = PersonalDataFactory.GetPersonalData(model.IdPerson);
                return View("~/Views/DataWorking/DaataPerson.cshtml", pmodel);
            }
            else
            {
                return View("~/Views/DataWorking/EditPersonalEventView.cshtml", model);
            }
        }
    }
}
