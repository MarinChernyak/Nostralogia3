using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.DataWorking
{

    public class MPicture
    {
        public int Idpicture { get; set; }
        public int IdReference { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public bool? IsAvailable { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Comments { get; set; }
    }
}
