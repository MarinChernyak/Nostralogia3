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

        public bool IsDecimal { get; set; }

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
        public int LongSemiSphere { get; set; }
        public int LatSemiSphere { get; set; }

        public CoordinatesModel()
        {
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
        }

        public override bool SaveData()
        {
            return false ;
        }
    }
}
