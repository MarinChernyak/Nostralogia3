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
        public IActionResult Consulting()
        {
            return View();
        }
    }
}
