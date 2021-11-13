using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Picture1
    {
        public int Idpicture { get; set; }
        public int IdReference { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }

        public virtual Worldevent IdReferenceNavigation { get; set; }
    }
}
