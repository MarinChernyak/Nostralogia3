using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nostralogia3.Models;
using Nostralogia3.Models.Authentication;
using Nostralogia3.Models.Helpers;
using System;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers
{

    public class BaseSessionController: Controller
    {
        protected void SetSessionVariables(MUserBase model)
        {
            HttpContext.Session.SetString(Constants.SessionCoockies.SessionUName, model.UserName);
            HttpContext.Session.SetString(Constants.SessionCoockies.SessionUID, model.UserId.ToString());
            HttpContext.Session.SetString(Constants.SessionCoockies.SessionULevel, model.UserLevel.ToString());
        }
        protected void DeleteSessionVariables()
        {
            HttpContext.Session.Remove(Constants.SessionCoockies.SessionUName);
            HttpContext.Session.Remove(Constants.SessionCoockies.SessionULevel);
            HttpContext.Session.Remove(Constants.SessionCoockies.SessionUID);
        }
    }
    public class HomeController : BaseSessionController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

        }

        public IActionResult Index()
        {            
            string token = CoockiesHelper.GetCockie(HttpContext, Constants.SessionCoockies.CoockieToken);
            LogInModel model = new LogInModel(token);
            if(!string.IsNullOrEmpty(model.UserName)&& model.Id>0)
            {
                SetSessionVariables(model);
            }

            return View(model);
        }

        public IActionResult HomePage()
        {
            string token = CoockiesHelper.GetCockie(HttpContext, Constants.SessionCoockies.CoockieToken);
            LogInModel model = new LogInModel(token);
            if (model!=null && model.UserId>0)
            {
                SetSessionVariables(model);
            }
            HomePageModel mopdel = new HomePageModel(HttpContext.Session);
            return View(mopdel);
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
