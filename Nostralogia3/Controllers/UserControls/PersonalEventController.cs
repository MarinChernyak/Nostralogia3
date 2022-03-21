using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.UserControls.Tables;
using Nostralogia3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.UserControls
{
    public class PersonalEventController : Controller
    {
        protected ISession _session { get; set; }
        public PersonalEventController()
        {
            _session = HttpContext.Session;
        }
        public ActionResult AddPersonalEvent(int IdPerson)
        {
            PersonalEventModel model = new PersonalEventModel(IdPerson,0);
            return View("~/Views/DataWorking/EditPersonalEventView.cshtml", model);
        }
        public ActionResult EditPersonalEvent(int Id)
        {
            PersonalEventModel model = new PersonalEventModel(0,Id);
            return View("~/Views/DataWorking/EditPersonalEventView.cshtml", model);
        }
        [HttpPost]
        public JsonResult EventCategoryChangedValue(short Id)
        {
            List<SelectListItem> lst = EventsDataFactory.GetPersonalEventsKinds(Id);
            return Json(lst);
        }
        public ActionResult DeleteEvent(int Id)
        {
            int personId = EventsDataFactory.DeleteEvent(Id).Result;
            PersonalDataVM pmodel = new PersonalDataVM(personId, _session);
            return View("~/Views/DataWorking/DataPerson.cshtml", pmodel);
        }
        [HttpPost]
        public ActionResult SaveEvent(PersonalEventModel model)
        {
            bool brez = false;
            if(ModelState.IsValid)
            {
                brez=EventsDataFactory.SavePersonalEvent(model).Result;
            }
            if (brez)
            {
                PersonalDataVM pmodel = new PersonalDataVM(model.IdPerson, _session);
                //MPersonalData pmodel = PersonalDataFactory.GetPersonalData(model.IdPerson);
                return View("~/Views/DataWorking/DataPerson.cshtml", pmodel);
            }
            else
            {
                return View("~/Views/DataWorking/EditPersonalEventView.cshtml", model);
            }
        }
    }
}
