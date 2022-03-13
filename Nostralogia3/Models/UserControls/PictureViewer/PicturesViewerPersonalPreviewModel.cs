using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;


namespace Nostralogia3.Models.PicturesViewer
{
    public class PicturesViewerPersonalPreviewModel : PictureViewerBaseModel
    {
        protected String _defaultPicture = "M_NoPict.JPG";

        protected const double MAX_WIDTH = 350;
        protected const double MAX_HEIGHT = 350;

        //This list and a property People are just for demo
        protected List<SelectListItem> _lstPeople;
        public List<SelectListItem> People
        {
            get
            {
                if (_lstPeople == null)
                {
                    _lstPeople = new List<SelectListItem>();
                    _lstPeople.Add(new SelectListItem {Text="W.Churchill",Value="1",Selected= RefID==1?true:false});
                    _lstPeople.Add(new SelectListItem { Text = "E.Hemingway", Value = "2",Selected= RefID==2?true:false });
                    _lstPeople.Add(new SelectListItem { Text = "T.Lawrence", Value = "3",Selected= RefID==3?true:false });
                 }
                return _lstPeople;
            }
        }
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
        
        }
        public PicturesViewerPersonalPreviewModel(List<PicturesData> lst, int IDRef, int index = 0)
            : base(lst, IDRef, index)
        {

        }
        protected override void GetPictures(int IDperson)
        {
           
            /// It is a fake data creation. You should substutute this code by something real
            _pictures = new List<PicturesData>();
            switch (IDperson)
            {
                case 1:
                    _pictures.Add(new PicturesData(){FileName="Churchill1.jpg",ID_Reference=1,IDPicture=1});
                    _pictures.Add(new PicturesData() { FileName = "Churchill2.jpg", ID_Reference = 1, IDPicture = 2 });
                    break;
                case 2:
                    _pictures.Add(new PicturesData() { FileName = "hemingway1.jpg", ID_Reference = 2, IDPicture = 3 });
                    _pictures.Add(new PicturesData() { FileName = "hemingway2.jpg", ID_Reference = 2, IDPicture = 4});
                    break;
                case 3:
                    _pictures.Add(new PicturesData() { FileName = "Lawrence1.jpg", ID_Reference = 3, IDPicture = 5 });
                    _pictures.Add(new PicturesData() { FileName = "Lawrence2.jpg", ID_Reference = 3, IDPicture = 6 });
                    break;
            }
        }

        public String DeleteImage(int idImage)
        {
            return "OK";
        }
    }
}