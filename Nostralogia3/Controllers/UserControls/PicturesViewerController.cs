
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Nostralogia3.Models.PicturesViewer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Sadalmelik3.Controllers
{
    public class PicturesViewerController : Controller
    {

        public ActionResult PictureViewerMain(int id)
        {

            PicturesViewerPersonalPreviewModel    _model = new PicturesViewerPersonalPreviewModel(id);
            return PartialView(_model);
        }
        [HttpPost]
        public PartialViewResult GetPictureViewer(int id)
        {
            PicturesViewerPersonalPreviewModel _model = new PicturesViewerPersonalPreviewModel(id);
            return PartialView("~/Views/Controls/PicturesViewer/PictureViewerMain.cshtml",_model);
        }
        //
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /PicturesViewer/Create
        [HttpPost]
        public JsonResult UpdatePicture()
        {
            var err = new { src = "error" };
            //int iduser = -1;
            //int iNumPict=0;
            String fname = String.Empty;
            //if (Request.Files.Count > 0)
            //{
            //    try
            //    {
            //        HttpFileCollectionBase files = Request.Files;
            //        var formkeys = Request.Form;
            //        if (formkeys.AllKeys.Contains("iduser"))
            //        {
            //            iduser = Convert.ToInt32(formkeys.Get(0));
            //        }
            //        if (formkeys.AllKeys.Contains("numberpict"))
            //        {
            //            iNumPict = Convert.ToInt32(formkeys.Get(1));
            //        }
            //        //for (int i = 0; i < files.Count; i++)
            //        //{
            //            //HttpPostedFileBase file = files[i];
                    
            //        //since we are always sending justr one file:
            //        HttpPostedFileBase file = files[0];
            //        int iSize = file.ContentLength;
            //        if (iSize < Constants.MAX_PICTURE_SIZE)
            //        {
            //            // ---- For refernce in a future. DO NOT CLEAR! --------------------
            //            /*
            //            if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INERNETEXPLORER")
            //            {
            //                string[] testfiles = file.FileName.Split(new char[] { '\\' });
            //                fname = testfiles[testfiles.Length - 1];
            //            }
            //            else
            //            {
            //                fname = file.FileName;
            //            }
            //            */
            //            String fdir = Server.MapPath("~/Data/Repository/PeopleImages/");
            //            string isss = DateTime.Now.ToOADate().ToString().Replace('.','_');
            //            fname = String.Format("{0}_{1}.jpg", iduser, isss);
                
            //            /// Save a new picture here. Should be changed!
            //            /// 

                       

            //            PicturesViewerPersonalPreviewModel _model = new PicturesViewerPersonalPreviewModel(iduser);
            //            int index = _model.NumPictures - 1;
            //            String src = _model.GetImgPath(index);
            //            var dataOK = new { src = src, width = _model.GetImgWidth(index), height = _model.GetImgHeight(index),  pictid = _model.GetID(index), pictamount = _model.NumPictures };

            //            return Json(dataOK);
            //        }
                    
            //    }
            //    catch
            //    {
                   
            //    }
            //}
            return Json(err);
            //return RedirectToAction("Test", "AddPersonalData", new { id = iduser });
        }

        [HttpPost]
        public JsonResult DeletePicture()
        {
            var dataOut = new { src = "error" };
            string json=string.Empty;
            //using (var reader = new StreamReader(Request.InputStream))
            //{
            //    json = reader.ReadToEnd();
            //}

            //try
            //{
            //    JObject jObject = JObject.Parse(json);
            //    //List<int> arr = GetYearArr(jObject);
            //    if (jObject["iduser"] == null)
            //    {
            //        return Json(dataOut);
            //    }
            //    else
            //    {
            //        int iduser = Convert.ToInt32(jObject["iduser"].ToString());
            //        int pictid = 0;
            //        if (jObject["pictid"] != null)
            //        {
            //            pictid = Convert.ToInt32(jObject["pictid"].ToString());
            //        }
            //        else
            //            return Json(dataOut);

            //        String origSrc = "";
            //        if (jObject["src"] != null)
            //            origSrc = jObject["src"].ToString();

            //        PicturesViewerPersonalPreviewModel _model = new PicturesViewerPersonalPreviewModel(iduser);
            //        String src= _model.DeleteImage(pictid);
            //        dataOut = new { src = "deleted" };
            //        if (!String.IsNullOrEmpty(origSrc))
            //        {
            //            try
            //            {
            //                //DELETE FILE HERE!

            //                //String fname = Server.MapPath(String.Format("~{0}", origSrc));
            //                //if (System.IO.File.Exists(fname))
            //                //{
            //                //    FileInfo file = new FileInfo(fname);
            //                //    file.Delete();
            //                //    //System.IO.File.Delete(fname);


            //                //}
            //            }
            //            catch
            //            {

            //            }
            //        }


            //        return Json(dataOut);
            //    }

            //}
            //catch
            //{
            //    return Json(dataOut);
            //}
            return Json(json);
        }



        protected JsonResult GetJsonData(bool IsNext, String json)
        {
            var dataOut = new { src = "error" };
 
            return Json(dataOut);
        }
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //
        // GET: /PicturesViewer/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /PicturesViewer/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
