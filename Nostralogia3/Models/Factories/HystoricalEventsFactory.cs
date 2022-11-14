using Microsoft.AspNetCore.Mvc.Rendering;
using NostralogiaDAL.NostradamusEntities;
using NostralogiaDAL.NostraGeoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class ComboHelpData
    {
        public List<SelectListItem> DropDownItems { get; set; }
        public Dictionary<object, string> HelpTexts { get; set; }

    }

    public class HystoricalEventsFactory : BaseFactory
    {

        public static List<SelectListItem> GetPlaceDataTypes()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            using (NostradamusContext context = new NostradamusContext())
            {
                List<EventPlaceType> lstTypes = context.EventPlaceTypes.OrderBy(x => x.Comment).ToList();
                foreach (EventPlaceType c in lstTypes)
                {
                    lst.Add(new SelectListItem()
                    {
                        Text = c.Comment,
                        Value = c.Id.ToString()
                    });
                }
            }
            return lst;
        }
        public static List<SelectListItem> GetPotentialSeverity()
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            using (NostradamusContext context = new NostradamusContext())
            {
                List<PotentialSeverity> lstTypes = context.PotentialSeverities.OrderBy(x => x.Id).ToList();
                foreach (PotentialSeverity c in lstTypes)
                {
                    lst.Add(new SelectListItem()
                    {
                        Text = c.Description,
                        Value = c.Id.ToString()
                    });
                }
            }
            return lst;
        }
        public static ComboHelpData GetImpactRelatedSectors()
        {
            ComboHelpData data = new ComboHelpData()
            {
                DropDownItems = new List<SelectListItem>(),
                HelpTexts = new Dictionary<object, string>()
            };
            using (NostradamusContext context = new NostradamusContext())
            {
                List<ImpactRelatedSector> lst = context.ImpactRelatedSectors.OrderBy(x => x.Id).ToList();
                foreach(ImpactRelatedSector item in lst)
                {
                    data.DropDownItems.Add(new SelectListItem()
                    {
                        Value = item.Id.ToString(),
                        Text = item.ImpactDescr
                    });
                    data.HelpTexts[item.Id] = item.DetailsDescr;
                }
            }

            return data;
        }
        public static List<SelectListItem> GetHystoricalScales()
        {
            List<SelectListItem> data = new List<SelectListItem>();

            using (NostradamusContext context = new NostradamusContext())
            {
                List<EventHistorScale> lst = context.EventHistorScales.OrderBy(x=>x.DescrScale).ToList();
                foreach (EventHistorScale item in lst)
                {
                    data.Add(new SelectListItem()
                    {
                        Text = item.DescrScale,
                        Value = item.Id.ToString()
                    });
                }
            }

            return data;
        }

        public static List<SelectListItem> GetHystoricalScaleValues(int id)
        {
            List<SelectListItem> lst = new List<SelectListItem>();
            using (NostradamusContext context = new NostradamusContext())
            {
                EventHistorScale scale = context.EventHistorScales.FirstOrDefault(x=>x.Id==id);
                for(int index=0; index<11; ++index)
                {
                    string propName = $"Descr{index}";
                    var propValue = GetValObjectByPropName(scale, propName);
                    if( propValue != null)
                    {
                        lst.Add(new SelectListItem()
                        {
                            Value = index.ToString(),
                            Text = propValue.ToString()

                        });                        
                    }
                }
            }
            return lst;
        }

        #region internal
        public static object GetValObjectByPropName(object obj, string propName)
        {
            object outobj = null;
            var prop = obj.GetType().GetProperty(propName);
            if (prop != null)
            {
                outobj = prop.GetValue(obj, null);
            }
            return outobj;
        }
        #endregion
    }
}
