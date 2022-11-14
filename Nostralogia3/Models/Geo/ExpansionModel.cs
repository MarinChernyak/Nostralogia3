using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Geo
{
    public class ExpansionModel : CountriesStatesCommon
    {

        public List<SelectListItem> SelectedIGeoItemsCollection { get; set; } = new();
        public override bool SaveData()
        {
            return false;
        }
        public ExpansionModel() { }
        public ExpansionModel(string label)
        {
            InitCombos();
            MainLabel = label;
        }
    }
}
