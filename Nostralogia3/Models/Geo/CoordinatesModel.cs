using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Geo
{
    public class CoordinatesModel : PlaceDataCommon
    {

       // public bool IsDecimal { get; set; }

        #region DECIMAL
        [DisplayName("Longitude")]
        public double Longitude { get; set; }
        [DisplayName("Latitude")]
        public double Latitude { get; set; }
        #endregion
        #region Min_Sec
        public int LongDegrees { get; set; }
        public int LongMinutes { get; set; }
        public int LongSeconds { get; set; }
        public int LatDegrees { get; set; }
        public int LatMinutes { get; set; }
        public int LatSeconds { get; set; }
        #endregion

        public List<SelectListItem> NS { get; set; }
        public List<SelectListItem> WE { get; set; }
        public List<SelectListItem> CoordFormats { get; set; }
        public string LongSemiSphere { get; set; }
        public string LatSemiSphere { get; set; }
        public string LongSemiSphere2 { get; set; }
        public string LatSemiSphere2 { get; set; }
        public short CoordFormatSelected { get; set; }

        public CoordinatesModel()
        {
            MainLabel = "Coordinates:";
            InitCombos();
        }
        public CoordinatesModel(string mainlabel)
        {
            MainLabel = mainlabel;
            InitCombos();
        }
        public override void InitCombos()
        {
            NS = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Select...",Value="0",Selected=true},
                new SelectListItem(){Text="N",Value="1"},
                new SelectListItem(){Text="S",Value="-1"}
            };
            WE = new List<SelectListItem>()
            {
                new SelectListItem(){Text="Select...",Value="0",Selected=true},
                new SelectListItem(){Text="E",Value="1"},
                new SelectListItem(){Text="W",Value="-1"}
            };
            CreateCoordFormatCollection();
        }
        protected void CreateCoordFormatCollection()
        {
            CoordFormats = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text= "Decimal degrees",
                    Value="1"
                },
                new SelectListItem()
                {
                    Text= "Degrees/Minutes/Seconds",
                    Value="2",
                    Selected=true
                }
            };
            CoordFormatSelected = 2;
        }
        public override bool SaveData()
        {
            return false ;
        }
        public double GetLongitude()
        {
            int ilong = int.Parse(LongSemiSphere=="0"? LongSemiSphere2: LongSemiSphere);
            double vallong = Longitude;
            if(CoordFormatSelected==2)
            {
                vallong = LongDegrees + LongMinutes / 60.0 + LongSeconds / 3600.0;
            }
            return vallong * ilong;

        }
        public double GetLaitude()
        {
            int ilat = int.Parse(LatSemiSphere == "0" ? LatSemiSphere2 : LatSemiSphere);
            double vallat = Latitude;
            if (CoordFormatSelected==2)
            {
                vallat = LatDegrees + LatMinutes / 60.0 + LatSeconds / 3600.0;
            }
            return vallat * ilat;
        }
    }
}
