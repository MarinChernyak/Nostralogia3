using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.SMGeneralEntities
{
    public partial class Application
    {
        public Application()
        {
            Roles = new HashSet<Role>();
        }

        public short Id { get; set; }
        public string AppName { get; set; }
        public string Url { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
