using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.SMGeneralEntities
{
    public partial class TempPass
    {
        public int Iduser { get; set; }
        public int Idapp { get; set; }
        public string TempPass1 { get; set; }
        public DateTime DateExpired { get; set; }
    }
}
