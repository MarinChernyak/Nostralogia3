using Nostralogia3.Models.Events;
using Nostralogia3.Models.Persons;
using NostralogiaDAL.NostradamusEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class EventsDataFactory
    {
        public static List<MVwWorldEvent> GetEventslDisplayDataList(int Nrecords = 10)
        {
            List<MVwWorldEvent> lst = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                var lstrecords = context.VwWorldEvents.OrderByDescending(x => x.Id).Take(Nrecords).ToList();
                lst = ModelsTransformer.TransferModelList<VwWorldEvent, MVwWorldEvent>(lstrecords);
            }
            return lst;
        }
    }
}
