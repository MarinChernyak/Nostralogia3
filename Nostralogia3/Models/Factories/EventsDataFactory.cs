using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Events;
using Nostralogia3.Models.Persons;
using NostralogiaDAL.NostradamusEntities;
using NostralogiaDAL.NostraGeoEntities;
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
        public static List<MPeopleevent> GetPersonalEventslList(int idPerson)
        {
            List<MPeopleevent> lst = new List<MPeopleevent>();
            using (NostradamusContext context = new NostradamusContext())
            {
                using (NostraGeoContext geocontext = new NostraGeoContext())
                {
                    List<VwPeopleEvent> lstrecords = context.VwPeopleEvents.Where(x => x.Idperson == idPerson).ToList();
                                     //join cit in geocontext.Cities on pe.PlaceEvent equals cit.Id
                                     //join cnt in geocontext.Countries on cit.Country equals cnt.Id
                                     //where pe.Idperson == idPerson
                                     //select new { pe, cit.CityName, cnt.Acronym }).OrderBy(x=>x.pe.YearFrom).ThenBy(x=>x.pe.MonthFrom).ThenBy(x=>x.pe.DayFrom).ToList();
                    
                    foreach(VwPeopleEvent item in lstrecords)
                    {
                        int idplace = item.PlaceEvent??0;
                        string fordisplay = string.Empty;
                        if(idplace>0)
                        {
                            City place = geocontext.Cities.FirstOrDefault(x => x.Id == idplace);
                            //StateRegion state = null;
                            //if(place.RegionState>0)
                            //{
                            //    state = geocontext.StateRegions.FirstOrDefault(x => x.Id == place.RegionState);
                            //}
                            Country country = null;
                            if(place.Country>0)
                            {
                                country = geocontext.Countries.FirstOrDefault(x => x.Id == place.Country);
                            }
                            if (place!=null)
                            {
                                fordisplay = place.CityName;
                            }
                            if(country!=null)
                            {
                                fordisplay = $"{fordisplay} ({country.Acronym})";
                            }
                        }
                        
                        MPeopleevent mpe = ModelsTransformer.TransferModel<VwPeopleEvent, MPeopleevent>(item);
                        mpe.EventPlaceDisplay = fordisplay;
                        lst.Add(mpe);
                    }
                }
            }
            return lst;
        }
    }
}
