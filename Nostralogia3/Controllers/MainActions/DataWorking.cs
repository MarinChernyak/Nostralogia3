using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
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
        public IActionResult EditPersonalData(int id)
        {
            MPersonalData model = PersonalDataFactory.GetPersonalData(id);
            return View("~/Views/DataWorking/DataPerson.cshtml",model);
        }
        public IActionResult Consulting()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(MPersonalData model)
        {
            int Id = 0;
            if (ModelState.IsValid)
            {
                 Id=model.AddNew();                
            }
            if(Id>0)
            {
                model = new MPersonalData(Id);
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
    }
}
