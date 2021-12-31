using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.DataWorking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.MainActions
{
    public class DataWorking : Controller
    {
        public IActionResult DataPerson()
        {
            MPersonalData model = new MPersonalData();
            return View(model);
        }
        public IActionResult EditPersonalData()
        {
            MPersonalData model =TempData["model"] as MPersonalData;
            if (model != null)
                model = new MPersonalData();
            else
                TempData["model"] = null;

            return View(model);
        }
        public IActionResult Consulting()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(MPersonalData model)
        {
            if(ModelState.IsValid)
            {
                int Id = model.AddNew();
                model.Id = Id;
            }
            
            return View("~/Views/DataWorking/DataPerson.cshtml",model);
        }
    }
}
