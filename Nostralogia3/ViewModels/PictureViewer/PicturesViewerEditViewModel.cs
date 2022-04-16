using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.DataWorking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Nostralogia3.ViewModels.PictureViewer
{
    public class EmployeeCreateViewModel
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        public IFormFile Photo { get; set; }
    }
    public class PicturesViewerEditViewModel /*: PictureViewerBase*/
    {
        protected String _defaultPicture = "M_NoPict.JPG";
        public bool Expanded { get; set;  }
        protected const double MAX_WIDTH = 350;
        protected const double MAX_HEIGHT = 350;

        //public PictureViewerViewModel ViewModel { get; set; }
        public IFormFile Photo { get; set; }


        //This list and a property People are just for demo
        //protected double GetMaxHeigth()
        //{
        //    return MAX_HEIGHT;
        //}
        //protected String GeDefaultPict()
        //{
        //    return _defaultPicture;
        //}
        //protected double GetMaxWidth()
        //{
        //    return MAX_WIDTH;
        //}
        public PicturesViewerEditViewModel()
        {
            //ViewModel = new PictureViewerViewModel(0);
        }

        public PicturesViewerEditViewModel(int IDperson)
        {
            Expanded = false;
            //ViewModel = new PictureViewerViewModel(IDperson);
        }
        //public PicturesViewerEditViewModel(List<MPicture> lst, int IDRef, int index = 0)
        //{
        //    Expanded = false;
        //    //ViewModel = new PictureViewerViewModel(IDRef);
        //}

        //public String DeleteImage(int idImage)
        //{
        //    return "OK";
        //}
        //protected void UpdateDimentions(int index)
        //{
        //    //double relationW = _pictures[index].Width / GetMaxWidth();
        //    //double relationH = _pictures[index].Height / GetMaxHeigth();

        //    //if (relationW > relationH)
        //    //{
        //    //    _pictures[index].Width = (int)(_pictures[index].Width / relationW);
        //    //    _pictures[index].Height = (int)(_pictures[index].Height / relationW);
        //    //}
        //    //else
        //    //{
        //    //    _pictures[index].Width = (int)(_pictures[index].Width / relationH);
        //    //    _pictures[index].Height = (int)(_pictures[index].Height / relationH);
        //    //}

        //}

        //public override bool IsEdit()
        //{
        //    return true;
        //}
    }
}