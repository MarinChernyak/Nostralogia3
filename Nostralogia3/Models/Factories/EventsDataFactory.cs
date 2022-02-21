using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Events;
using Nostralogia3.Models.Persons;
using Nostralogia3.Models.UserControls.Tables;
using Nostralogia3.Models.Utilities;
using NostralogiaDAL.NostradamusEntities;
using NostralogiaDAL.NostraGeoEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class EventsDataFactory : BaseFactory
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


                    foreach (VwPeopleEvent item in lstrecords)
                    {
                        int idplace = item.PlaceEvent ?? 0;
                        string fordisplay = string.Empty;
                        if (idplace > 0)
                        {
                            City place = geocontext.Cities.FirstOrDefault(x => x.Id == idplace);
                            Country country = null;
                            if (place.Country > 0)
                            {
                                country = geocontext.Countries.FirstOrDefault(x => x.Id == place.Country);
                            }
                            if (place != null)
                            {
                                fordisplay = place.CityName;
                            }
                            if (country != null)
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

        public static List<SelectListItem> GetPersonalEventsKinds(int idCategory)
        {
            List<SelectListItem> myColection = new List<SelectListItem>();
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    IQueryable<Eventslist> colection = context.Eventslists.Where(x => x.CategoryId == (byte)idCategory);
                    if(colection.Any())
                    {
                        myColection =(List < SelectListItem >) colection.OrderBy(x => x.Description).Select(x => new SelectListItem
                        {
                            Text = x.Description,
                            Value = x.Idevent.ToString()
                        }).ToList();                        
                    }
                    InsertSelectItem(myColection);
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);

                }
            }
            return myColection;
        }

        public static List<SelectListItem> GetPersonalEventsCategory()
        {
            List<SelectListItem> myColection = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    myColection = (List<SelectListItem>)context.EventsCategories.OrderBy(x => x.Description).Select(x => new SelectListItem
                    {
                        Text = x.Description,
                        Value = x.Idcat.ToString()
                    }).ToList();
                    InsertSelectItem(myColection);
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);

                }
            }
            InsertSelectItem(myColection);
            return myColection;
        }

        public static bool SavePersonalEvent(PersonalEventModel model)
        {
            bool bRez = true;
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    Peopleevent pe = new Peopleevent()
                    {
                        AcessLevel = model.DataType,
                        DayFrom = model.DateFrom.Day,
                        DayTo = model.DateTo.Day,
                        Event = model.IdeventKind,
                        Id = model.Id,
                        Idcontributor = model.Idcontributor,
                        Idperson = model.IdPerson,
                        IsActive = true,
                        MonthFrom = model.DateFrom.Month,
                        MonthTo = model.DateTo.Month,
                        Notes = model.Notes,
                        PlaceEvent = model.EventPlace.PlaceId,
                        Source = model.Idsource,
                        YearFrom = model.DateFrom.Year,
                        YearTo = model.DateTo.Year,
                    };
                    if (pe.Id == 0)
                    {
                        context.Peopleevents.Add(pe);
                        
                    }
                    else
                    {
                        context.Peopleevents.Update(pe);
                    }
                    context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);
                    bRez = false;
                }

                return bRez;
            }
        }

    }
}
