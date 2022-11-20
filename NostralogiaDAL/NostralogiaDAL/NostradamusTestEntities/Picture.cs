using System;
using System.Collections.Generic;

#nullable disable

namespace NostralogiaDAL.NostradamusEntities
{
    public partial class Picture
    {
        public int Idpicture { get; set; }
        public int IdReference { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public bool? IsAvailable { get; set; }
        public string Comments { get; set; }

        public virtual Person IdReferenceNavigation { get; set; }
    }
}
