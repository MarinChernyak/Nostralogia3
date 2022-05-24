using Microsoft.AspNetCore.Mvc.Rendering;
using NostralogiaDAL.NostradamusEntities;
using NostralogiaDAL.NostraGeoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
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
    }
}
