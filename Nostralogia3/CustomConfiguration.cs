using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public static class CustomConfiguration
    {
        public static IConfigurationRoot config;

        public static void BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //.AddUserSecrets(Assembly.GetExecutingAssembly(), optional: true, reloadOnChange: true)
            //.AddEnvironmentVariables();

            config = builder.Build();
        }
    }
}
