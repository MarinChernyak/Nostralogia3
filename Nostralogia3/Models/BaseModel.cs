using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
