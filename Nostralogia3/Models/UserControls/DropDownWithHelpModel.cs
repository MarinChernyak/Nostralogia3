using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls
{
    public class DropDownWithHelpModel
    {
        public List<SelectListItem> DropDownItems { get; set; }
        public Dictionary<object,string> HelpTexts { get; set; }
        [DisplayName("Impact Related Sectors")]
        public int SelectedImpact { get; set; }

        public DropDownWithHelpModel()
        {
            InitCollections();
        }
        public void InitCollections()
        {
            ComboHelpData data = HystoricalEventsFactory.GetImpactRelatedSectors();
            DropDownItems = data.DropDownItems;
            HelpTexts = data.HelpTexts;
        }
        public string getId(int id)
        {
            return $"SelFromMain{id}";
        }
    }
}
