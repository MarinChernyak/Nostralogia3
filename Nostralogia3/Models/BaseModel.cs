using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Nostralogia3.Models
{
    public class BaseModel
    {
        protected int _Index { get; }
        public BaseModel()
        {
            _Index = Constants.Values.Counter;
        }
        protected ISession _session { get; set; }
        public bool IsOnline { get; protected set; }

        public void SetSession(ISession session)
        {
            _session = session;
        }
        protected async Task SetContextValuesAsync(ISession session)
        {
            SetSession(session);
            await SetOnlineStatusAsync();
        }
        protected async Task SetOnlineStatusAsync()
        {
            try
            {
                var myClient = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true });
                var response = await myClient.GetAsync("www.google.ca");
                

                //var request = WebRequest.Create("www.google.ca");
                //using (var response = request.GetResponse())
                //{
                //    IsOnline = true;
                //}
            }
            catch
            {
                IsOnline = false;
            }
        }
    }
}
