using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Helpers
{
    public static class CoockiesHelper
    {
        public static void SetCockies(HttpContext context, string name, string value)
        {
            if (context != null && !context.Request.Cookies.ContainsKey("first_request"))
            {
                CookieOptions cookieOptions = new CookieOptions();
                cookieOptions.Expires = new DateTimeOffset(DateTime.Now.AddDays(30));
                context.Response.Cookies.Append(name, value, cookieOptions);
                
            }
        }
        public static string GetCockie(HttpContext context, string name)
        {
            string cookie = string.Empty;
            if (context != null && !context.Request.Cookies.ContainsKey(name))
            {
                context.Request.Cookies.TryGetValue(name, out cookie);

            }
            return cookie;
        }
    }
}
