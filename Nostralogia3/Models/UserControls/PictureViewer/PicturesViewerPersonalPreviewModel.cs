using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;

namespace Nostralogia3.Models.PicturesViewer
{
    public class PicturesViewerPersonalPreviewModel : PictureViewerBaseModel
    {
        protected String _defaultPicture = "M_NoPict.JPG";
        public bool Expanded { get; set;  }
        protected const double MAX_WIDTH = 350;
        protected const double MAX_HEIGHT = 350;

        //This list and a property People are just for demo
        protected override double GetMaxHeigth()
        {
            return MAX_HEIGHT;
        }
        protected override String GeDefaultPict()
        {
            return _defaultPicture;
        }
        protected override double GetMaxWidth()
        {
            return MAX_WIDTH;
        }
        public PicturesViewerPersonalPreviewModel(int IDperson)
            : base(IDperson, 1)
        {
            Expanded = false;
        }
        public PicturesViewerPersonalPreviewModel(List<MPicture> lst, int IDRef, int index = 0)
            : base(lst, IDRef, index)
        {
            Expanded = false;
        }
        protected override void GetPictures(int IDperson)
        {


            _pictures = PersonalDataFactory.GetPictures(IDperson);
            //switch (IDperson)
            //{
            //    case 1:
            //        _pictures.Add(new MPicture(){FileName="Churchill1.jpg",ID_Reference=1,IDPicture=1});
            //        _pictures.Add(new MPicture() { FileName = "Churchill2.jpg", ID_Reference = 1, IDPicture = 2 });
            //        break;
            //    case 2:
            //        _pictures.Add(new MPicture() { FileName = "hemingway1.jpg", ID_Reference = 2, IDPicture = 3 });
            //        _pictures.Add(new MPicture() { FileName = "hemingway2.jpg", ID_Reference = 2, IDPicture = 4});
            //        break;
            //    case 3:
            //        _pictures.Add(new MPicture() { FileName = "Lawrence1.jpg", ID_Reference = 3, IDPicture = 5 });
            //        _pictures.Add(new MPicture() { FileName = "Lawrence2.jpg", ID_Reference = 3, IDPicture = 6 });
            //        break;
            //}
        }

        public String DeleteImage(int idImage)
        {
            return "OK";
        }
    }
}