using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels.PictureViewer
{
    public class PicturesViewerEditViewModel : ViewModelBase
    {
        protected String _defaultPicture = "M_NoPict.JPG";
        public bool Expanded { get; set;  }
        protected const double MAX_WIDTH = 300;
        protected const double MAX_HEIGHT = 350;
        public NewPictureData NewPictureData { get; set; } = new();
        public int IdRef { get; set; }
        public bool IsEdit { get; set; }

        public List<MPictureView> _pictures { get; protected set; } = new();

        //This list and a property People are just for demo
        protected double GetMaxHeigth()
        {
            return MAX_HEIGHT;
        }
        protected String GeDefaultPict()
        {
            return _defaultPicture;
        }
        protected double GetMaxWidth()
        {
            return MAX_WIDTH;
        }
        public PicturesViewerEditViewModel()
        {
            IsEdit = false;
        }

        public PicturesViewerEditViewModel(int IDperson, ISession session)
        {
            IsEdit = false;
            Expanded = false;
            IdRef = IDperson;
            _session = session;
            InitCollection();
        }

        protected void InitCollection()
        {
            int ilevel = GetUserLevel();
            var pict = PersonalDataFactory.GetPicturesCollection(IdRef, ilevel > 2);
            UpdatePictures(pict);
        }
        public String DeleteImage(int idImage)
        {
            return "OK";
        }
        protected void UpdatePictures(List<MPicture> pict)
        {
            if (pict != null && pict.Count > 0)
            {
                for (int i = 0; i < pict.Count; ++i)
                {
                    System.Drawing.Image img = System.Drawing.Image.FromFile($"{NewPictureData.FullPath}\\{pict[i].FileName}");
                    if (img != null)
                    {
                        double relationW = img.Width / GetMaxWidth();
                        double relationH = img.Height / GetMaxHeigth();

                        if (relationW > relationH)
                        {
                            pict[i].Width = (int)(img.Width / relationW);
                            pict[i].Height = (int)(img.Height / relationW);
                        }
                        else
                        {
                            pict[i].Width = (int)(img.Width / relationH);
                            pict[i].Height = (int)(img.Height / relationH);
                        }
                    }
                    MPictureView mpv = new MPictureView()
                    {
                        Comments = pict[i].Comments,
                        FileName = pict[i].FileName,
                        FileSize = pict[i].FileSize,
                        Height = pict[i].Height.ToString(),
                        Idpicture = pict[i].Idpicture,
                        IdReference = pict[i].IdReference,
                        IsAvailable = pict[i].IsAvailable,
                        Width = pict[i].Width.ToString()
                    };

                    _pictures.Add(mpv);
                }
            }
        }
    }
}