using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.SMGeneralEntities
{
    public partial class SecurityProtocol
    {
        public long Id { get; set; }
        public string Salt { get; set; }
        public string Passcode { get; set; }
        public string Initvector { get; set; }
        public DateTime DateCreation { get; set; }
        public string UserName { get; set; }
    }
}
