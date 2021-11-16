using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.Authentication;
using Nostralogia3.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.Authentication
{
    public class LogInController : Controller
    {
        public IActionResult ReLogIn()
        {
            string cockie = CoockiesHelper.GetCockie(HttpContext, Constants.CoockieUName);
            if(!string.IsNullOrEmpty(cockie))
            {
                return RedirectToAction("Index", "Home"); 
            }
            LogInModel model = new LogInModel();
            return View("~/Views/Authentication/LogInStandAlone.cshtml", model);
        }
        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            bool brez = model.TryLogIn();
            if (!brez)
                return RedirectToAction("ReLogIn");
            else
            {
                if(model.ShouldRemember)
                {
                    CoockiesHelper.SetCockies(HttpContext, Constants.CoockieUName, model.UserName);
                }
                return RedirectToAction("Index", "Home");
            }
        }
        public ActionResult Registration()
        {
            RegistrationModel model = new RegistrationModel();
            return View("~/Views/Authentication/RegistrationForm.cshtml", model); 
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            
            if (ModelState.IsValid)
            {
                bool brez=model.SaveUser();
                if (brez)
                {
                    return View("~/Views/Authentication/LogInStandAlone.cshtml", new LogInModel());
                }
            }

             return View("~/Views/Authentication/RegistrationForm.cshtml", model);

            
        }
    }
}
