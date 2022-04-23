using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.Factories;
using Nostralogia3.ViewModels.PictureViewer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.UserControls
{

    public class PicturesViewerController : Controller
    {
        public ActionResult PictureViewerEdit(int id)
        {
            NewPictureData _model = new NewPictureData(id);
            return View("~/Views/DataWorking/UploadPicture.cshtml", _model);
        }
        [HttpPost]
        public ActionResult PictureViewerMain(int id)
        {

            PicturesViewerEditViewModel    _model = new PicturesViewerEditViewModel(id);
            return RedirectToAction("PictureViewerEdit", new { id = id });
        }
        [HttpPost]
        public JsonResult DeletePicture(int id)
        {
            int idRef =  PersonalDataFactory.DeletePicturePsonal(id);
            string jsonout = string.Empty;
            if(idRef>0)
            {
                PicturesViewerEditViewModel model = new PicturesViewerEditViewModel(idRef);
                jsonout = JsonSerializer.Serialize(model._pictures);
            }
            return new JsonResult(jsonout);
        }



        public async Task<IActionResult> CreateAsync(NewPictureData model)
        {

            if (ModelState.IsValid)
            {
                if (model.Photo != null)
                {
                    int id = await model.UploadFile();
                }

            }
            return RedirectToAction("EditPersonalData", "DataWorking", new { id=model.IdRef });
        }
    }
}
