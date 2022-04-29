using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Helpers;
using Nostralogia3.ViewModels;
using Nostralogia3.ViewModels.MapNotes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.MainActions
{
    public class DataWorking : BaseController
    {
        protected ISession _session { get
            {
                return HttpContext.Session;
            }
        }
        public IActionResult DataPerson()
        {
            PersonalDataVM model = new PersonalDataVM(_session);
            UpdatePersonalData(model);
            return View(model);
        }
        public IActionResult EditPersonalData(int id)
        {
            PersonalDataVM model = new PersonalDataVM(id, _session);
            return View("~/Views/DataWorking/DataPerson.cshtml",model);
        }
        public IActionResult Consulting()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UpdatePersonalData(PersonalDataVM model)
        {
            int Id = 0;
            if (ModelState.IsValid)
            {
                if(model._model.Id==0)
                {
                    Id = model.AddNew();
                }
                else
                {
                    model.SetSession(HttpContext.Session);
                    model.UpdateData();
                }
                model = new PersonalDataVM(model._model.Id, HttpContext.Session);
            }          
            return View("~/Views/DataWorking/DataPerson.cshtml", model);
        }
        public IActionResult DeletePersonalData(int id)
        {
            bool brez = true;
            if(ModelState.IsValid)
            {
                brez = PersonalDataFactory.DeletePersonalData(id);
            }
            return RedirectToAction("HomePage", "Home");
        }
        [HttpPost]
        public async Task<JsonResult> CreateNewMapNote(int idRef, string newNote)
        {
            int userid = Convert.ToInt32(SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionUID));
            int id=await PersonalDataFactory.CreaNewMapNote(idRef,newNote, userid);
            return Json(id);
        }
        [HttpPost]
        public async Task<JsonResult> SaveMapNote(int id, string newNote)
        {
            int userid = Convert.ToInt32(SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionUID));
            bool brez=await PersonalDataFactory.UpdatewMapNote(id,newNote, userid);
            return Json(brez);
        }

        [HttpPost]
        public async Task<JsonResult> ActivateMapNote(int id, bool activate)
        {
            //int userid = Convert.ToInt32(SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionUID));
            bool brez=await PersonalDataFactory.ActivateMapNote(id,activate);
            return Json(brez);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteMapNote(int id)
        {
            //int userid = Convert.ToInt32(SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionUID));
            bool brez = await PersonalDataFactory.DeleteMapNote(id);
            return Json(brez);
        }
    }
}
