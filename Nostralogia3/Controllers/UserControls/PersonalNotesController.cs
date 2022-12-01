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
                //int idnote = await PersonalDataFactory.CreaNewMapNote(id, newNote, userid);
                MapNoteBase model = new MapNoteBase(IdRef);
                return View("~/Views/UserControls/MapNotes/NewMapNote.cshtml", model);
            }
            else
                return RedirectToAction("EditPersonalData", "DataWorking", new { id = IdRef });
        }
        [HttpPost]
        public async Task<ActionResult> SaveNewNote(MapNoteBase model)
        {
            if(ModelState.IsValid)
            {
                model.SetSession(HttpContext.Session);
                await model.SaveNewNote();
            }
            return RedirectToAction("EditPersonalData", "DataWorking", new { id = model.MapNote.IdPerson });
        }
    }
}
