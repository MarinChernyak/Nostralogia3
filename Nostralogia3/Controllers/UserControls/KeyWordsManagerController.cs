using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Common;
using Nostralogia3.Models;
using Nostralogia3.Models.Factories;
using Nostralogia3.ViewModels.UserControls.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Nostralogia3.Controllers.UserControls
{
    public class KeyWordsManagerController : Controller
    {
        //
        // GET: /KeyWordsManager/

        public ActionResult KeyWordsManagerMain()
        {
            KeyWordsCollectionModel model = new KeyWordsCollectionModel();
            return View("~/Views/Controls/KeyWordsManager/KeyWordsManagerMain.cshtml",model);
        }
        [HttpPost]
        public JsonResult DrillDown(int id)
        {
            KeyWordsCollectionModelDD model = new KeyWordsCollectionModelDD(id);
            return Json(getSerializedOpject(model));
        }
        [HttpPost]
        public JsonResult DrillUp(int id)
        {
            KeyWordsCollectionModelDU model = new KeyWordsCollectionModelDU(id);
            return Json(getSerializedOpject(model)); 
        }
        protected RootJCollectionObject getSerializedOpject(KeyWordsCollectionModel model)
        {
            var objectToSerialize = new RootJCollectionObject();
            objectToSerialize.items = new List<JsonCollection>();
            JsonCollection lstKW = new JsonCollection() { Name = "KeyWords", items = new List<SelectListItem>() };
            lstKW.items.AddRange(model.KeyWordsCollection);
            objectToSerialize.items.Add(lstKW);

            return objectToSerialize;
        }
        [HttpPost]
        public JsonResult SaveDB(int id, string data)
        {
            bool bRez = true;
            if(id>0 && !string.IsNullOrEmpty(data))
            {
                bRez=PersonalDataFactory.UpdatePersonalKeywords(data, id); 
            }
            return Json(bRez);
        }
    }
}
