using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nostralogia3.Models;
using Nostralogia3.Models.Authentication;
using Nostralogia3.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {

            LogInModel model = new LogInModel();
            string token = CoockiesHelper.GetCockie(HttpContext, Constants.CoockieToken);
            if(!string.IsNullOrEmpty(token))
            {
                EncryptDataUpdater updater = new EncryptDataUpdater();
                token = updater.CheckToken(token);
                if (!string.IsNullOrEmpty(token))
                {
                    ViewBag.IsLoggedIn = model.IsLoggedIn;
                    CoockiesHelper.SetCockie(HttpContext, Constants.CoockieToken,token);
                }

            }



            return View(model);
        }

        public IActionResult HomePage()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
