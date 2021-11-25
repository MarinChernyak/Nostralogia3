using NostralogiaDAL.SMGeneralEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Authentication
{
    public class SMGeneralBaseModel
    {
        public SMGeneralBaseModel()
        {
        }
        protected string StrWraper(string str)
        {
            return string.IsNullOrEmpty(str) ? string.Empty : str;
        }
    }
}
