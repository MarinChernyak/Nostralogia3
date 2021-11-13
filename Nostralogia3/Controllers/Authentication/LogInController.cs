using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.Authentication
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogIn(LogInModel model)
        {

            return null;
        }
    }
}
