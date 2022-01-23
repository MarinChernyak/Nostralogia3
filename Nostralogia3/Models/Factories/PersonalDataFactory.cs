using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Persons;
using Nostralogia3.Models.Utilities;
using NostralogiaDAL.NostradamusEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class PersonalDataFactory: BaseFactory
    {
        public static List<MVwPersonalDisplayDatum> GetPersonalDisplayDataList(int Nrecords = 10)
        {
            List<MVwPersonalDisplayDatum> lst = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                var lstrecords = context.VwPersonalDisplayData.OrderByDescending(x => x.Id).Take(Nrecords).ToList();
                lst = ModelsTransformer.TransferModelList<VwPersonalDisplayDatum, MVwPersonalDisplayDatum>(lstrecords);
            }
            return lst;
        }
        public static MVwPersonalDisplayDatum GetPersonalDisplayData(int Id)
        {
            MVwPersonalDisplayDatum mdata = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                var ldata = context.VwPersonalDisplayData.FirstOrDefault(x => x.Id==Id);
                mdata = ModelsTransformer.TransferModel<VwPersonalDisplayDatum, MVwPersonalDisplayDatum>(ldata);            }

            return mdata;
        }
        public static int AddPersonalData(MPersonalData mdata)
        {
            int Id =0;
            Person data = ModelsTransformer.TransferModel<MPersonalData, Person>(mdata);
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    context.People.Add(data);
                    context.SaveChanges();
                    Id = data.Id;
                }
                catch(Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);
                    
                }
            }
            return Id;
        }
        public static List<SelectListItem> GetDataSources()
        {
            List<SelectListItem> SourceColection = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    SourceColection = (List<SelectListItem>)context.Sources.OrderBy(x => x.SourceDescription).Select(x => new SelectListItem
                    {
                       Text=x.SourceDescription,
                       Value = x.Idsource.ToString()
                    }).ToList();
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);

                }
            }
            InsertSelectItem(SourceColection);

            return SourceColection;
        }
        public static List<SelectListItem> GetDataTypes()
        {
            List<SelectListItem> collect = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    collect = (List<SelectListItem>)context.Datatypes.OrderBy(x => x.Description).Select(x => new SelectListItem
                    {
                        Text = x.Description,
                        Value = x.Idtype.ToString()
                    }).ToList();
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);

                }
            }
            InsertSelectItem(collect);
            return collect;
        }
        public static List<SelectListItem> GetTimeShifts()
        {
            List<SelectListItem> collect = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    collect = (List<SelectListItem>)context.TimesShifts.OrderBy(x => x.Description).ToList().Select(x => new SelectListItem
                    {
                        Text = x.Description,
                        Value = x.Idtimeshift.ToString()
                    });
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);

                }
            }
            InsertSelectItem(collect);
            return collect;
        }

        public static MPersonalData GetPersonalData(int Id)
        {
            MPersonalData mdata = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                var ldata = context.People.FirstOrDefault(x => x.Id == Id);
                mdata = ModelsTransformer.TransferModel<Person, MPersonalData>(ldata);
            }

            return mdata;
        }
    }
}
