using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
        public IActionResult Consulting()
        {
            return View();
        }
    }
}
