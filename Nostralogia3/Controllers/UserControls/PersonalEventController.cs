using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers.UserControls
{
    public class PersonalEventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
