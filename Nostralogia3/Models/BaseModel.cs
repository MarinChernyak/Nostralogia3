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
        public void SetSession(ISession session)
        {
            _session = session;
            
        }
        protected void SetContextValuesAsync(ISession session)
        {
            SetSession(session);
            //await SetOnlineStatusAsync();
        }

    }
}
