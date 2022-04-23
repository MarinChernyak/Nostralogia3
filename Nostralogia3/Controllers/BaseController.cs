using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nostralogia3.Models.Authentication;
using Nostralogia3.Models.Helpers;
using Nostralogia3.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Controllers
{
    public class BaseController : Controller
    {
        protected void UpdateUserData(ViewModelBase model)
        {
            string userid = SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionUID);
            if (!string.IsNullOrEmpty(userid))
            {
                model.UserId = Convert.ToInt32(userid);
            }
            string userlevel = SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionULevel);
            if (!string.IsNullOrEmpty(userlevel))
            {
                model.SetUserLevel(Convert.ToInt32(userlevel));
            }
        }
        protected int GetUserLevel()
        {
            int ilevel = 0;
            string userlevel = SessionHelper.GetObjectFromJson(HttpContext.Session, Constants.SessionCoockies.SessionULevel);
            if(!string.IsNullOrEmpty(userlevel))
            {
                ilevel = Convert.ToInt32(userlevel);
            }
            return ilevel;
        }
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
}
