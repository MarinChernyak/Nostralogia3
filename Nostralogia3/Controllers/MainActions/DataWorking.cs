using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.ViewModels;
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
            UpdatePersonalData(model);
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
                    model.UpdateData();
                }
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
