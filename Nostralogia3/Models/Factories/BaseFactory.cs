using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class BaseFactory
    {

        public BaseFactory(IConfigurationRoot config)
        {
            CustomConfiguration.BuildConfiguration();
        }
        protected string GetConnectionString(string strName)
        {
            return CustomConfiguration.config.GetConnectionString(strName);
        }

    }
}
