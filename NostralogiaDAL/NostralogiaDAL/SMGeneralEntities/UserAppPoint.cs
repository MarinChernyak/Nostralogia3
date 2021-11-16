using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.SMGeneralEntities
{
    public partial class UserAppPoint
    {
        public int UserId { get; set; }
        public short AppId { get; set; }
        public int Points { get; set; }

        public virtual User User { get; set; }
    }
}
