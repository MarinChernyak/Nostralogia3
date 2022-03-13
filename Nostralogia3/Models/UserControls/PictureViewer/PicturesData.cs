using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nostralogia3.Models.PicturesViewer
{
    public class PicturesData
    {

        public int IDPicture { get; set; }

        //i.e - ID of a person, whos picture is.
        public int ID_Reference { get; set; }
        //File name in a repository
        public String FileName { get; set; }
        //i.e - Nature, Portrait etc.
        public int CategoryData { get; set; }
        // optional. Included just in case.
        public int FileSize { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }
    }
}