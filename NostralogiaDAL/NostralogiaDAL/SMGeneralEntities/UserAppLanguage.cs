using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.SMGeneralEntities
{
    public partial class UserAppLanguage
    {
        public int UserId { get; set; }
        public short AppId { get; set; }
        public short LanguageId { get; set; }

        public virtual Application App { get; set; }
        public virtual User User { get; set; }
    }
}
