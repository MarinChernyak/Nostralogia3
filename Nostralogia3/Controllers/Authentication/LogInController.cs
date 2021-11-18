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
            string token = CoockiesHelper.GetCockie(HttpContext, Constants.CoockieToken);
            if(!string.IsNullOrEmpty(token))
            {
                EncryptDataUpdater updater = new EncryptDataUpdater();
                token = updater.CheckToken(token);
                if(!string.IsNullOrEmpty(token))
                {
                    CoockiesHelper.SetCockie(HttpContext, Constants.CoockieToken, token);
                    return RedirectToAction("Index", "Home");
                }                
            }
            LogInModel model = new LogInModel();
            return View("~/Views/Authentication/LogInStandAlone.cshtml", model);
        }
        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {
            string token = string.Empty;
            bool brez = model.TryLogIn(out token);
            if (!brez)
                return RedirectToAction("ReLogIn");
            else
            {
                if(model.ShouldRemember && !string.IsNullOrEmpty(token))
                {
                    CoockiesHelper.SetCockie(HttpContext, Constants.CoockieToken, token);
                    string tt = CoockiesHelper.GetCockie(HttpContext, Constants.CoockieToken);
                }
                return RedirectToAction("HomePage", "Home");
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
                bool UserNameExists = model.UserNameExists();
                bool EmailExists = model.EmailExists();
                if (UserNameExists)
                {
                    ModelState.AddModelError("UserName", "This User name already exists");
                }
                if(EmailExists)
                {
                    ModelState.AddModelError("Email", "This email already exists");
                }

                if(!UserNameExists && !EmailExists)
                {
                    bool brez = model.SaveUser();
                    if (brez)
                    {
                        return View("~/Views/Authentication/LogInStandAlone.cshtml", new LogInModel());
                    }
                }
                
            }

             return View("~/Views/Authentication/RegistrationForm.cshtml", model);            
        }
    }
}
