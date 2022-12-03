using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Helpers;
using Nostralogia3.ViewModels.MapNotes;
using System;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.UserControls
{
    public class PersonalNotesController : Controller
    {
        [HttpPost]
        public ActionResult CreateNewMapNote(int IdRef)
        {
            if (!string.IsNullOrEmpty(SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionUID)))
            {
                int userid = Convert.ToInt32(SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionUID));
                MapNoteBase model = new MapNoteBase(IdRef);
                return View("~/Views/UserControls/MapNotes/EditMapNote.cshtml", model);
            }
            else
                return RedirectToAction("EditPersonalData", "DataWorking", new { id = IdRef });
        }
        [HttpPost]
        public async Task<ActionResult> SaveNote(MapNoteBase model)
        {
            if(ModelState.IsValid)
            {
                model.SetSession(HttpContext.Session);
                await model.SaveNote();

            }
            return RedirectToAction("EditPersonalData", "DataWorking", new { id = model.MapNote.IdPerson });
        }
        [HttpPost]
        public ActionResult UpdateMapNote(int id, int IdRef)
        {
            if (!string.IsNullOrEmpty(SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionUID)))
            {
                MapNoteBase model = new MapNoteBase(id, IdRef);
                return View("~/Views/UserControls/MapNotes/EditMapNote.cshtml", model);
            }
            else
                return RedirectToAction("EditPersonalData", "DataWorking", new { id = IdRef });
        }

        [HttpPost]
        public async Task<JsonResult> ActivateMapNote(int id, bool activate)
        {
            //int userid = Convert.ToInt32(SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionUID));
            bool brez = await PersonalDataFactory.ActivateMapNote(id, activate);
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
