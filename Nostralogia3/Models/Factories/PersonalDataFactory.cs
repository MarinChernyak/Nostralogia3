﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Persons;
using Nostralogia3.Models.PicturesViewer;
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
                    //context.People.Add(data);
                    context.Entry(data).State = EntityState.Added;
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
            //InsertSelectItem(collect);
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
        public static bool DeletePersonalData(int id)
        {
            bool bRez = true;            

            using (NostradamusContext context = new NostradamusContext())
            {
                using var transaction = context.Database.BeginTransaction();
                try
                {
                    var keywords = context.Peoplekeywordsstores.Where(x => x.IdPerson == id);
                    context.RemoveRange(keywords);

                    var events = context.Peopleevents.Where(x => x.Idperson == id);
                    context.RemoveRange(events);

                    var notes = context.MapNotes.Where(x => x.IdPerson == id);
                    context.RemoveRange(notes);

                    var pictures = context.Pictures.Where(x => x.IdReference == id);
                    //DELETE FILES
                    context.RemoveRange(notes);

                    var person = context.People.FirstOrDefault(x => x.Id == id);
                    context.Remove(person);
                    context.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);
                    bRez = false;
                    transaction.Rollback();
                }
            }

            return bRez;
        }
        public static bool UpdatePersonalKeywords(string data, int IdPerson)
        {
            bool bRez = true;
            if (!string.IsNullOrEmpty(data) && IdPerson > 0)
            {
                string[] arrdata = data.Split(new char[] { ',' });
                if (arrdata.Length > 0)
                {
                    using (NostradamusContext context = new NostradamusContext())
                    {
                        try
                        {
                            List<Peoplekeywordsstore> toadd = new List<Peoplekeywordsstore>();
                            List<Peoplekeywordsstore> toremove = context.Peoplekeywordsstores.Where(x => x.IdPerson == IdPerson).ToList();
                            context.Peoplekeywordsstores.RemoveRange(toremove);
                            foreach (string item in arrdata)
                            {
                                toadd.Add(new Peoplekeywordsstore()
                                {
                                    IdPerson = IdPerson,
                                    IsAvailable = true,
                                    KeyWord = Convert.ToInt16(item)
                                });
                            }
                            context.Peoplekeywordsstores.AddRange(toadd);
                            context.SaveChanges();
                        }
                        catch (Exception e)
                        {
                            LogMaster lm = new LogMaster();
                            lm.SetLog(e.Message);
                            bRez = false;
                        }
                    }
                }
            }

            return bRez;
        }
        public static List<SexDatum> GetSexCollection()
        {
            List<SexDatum> lst = null; ;
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    lst = context.SexData.ToList();
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);                    
                }
            }
            return lst;
        }
        public static byte GetPersonDataType(int IdPerson)
        {
            byte iDataType = 0;
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    iDataType = context.People.FirstOrDefault(x => x.Id == IdPerson).DataType;
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);
                }
            }
            return iDataType;
        }
        public static bool UpdatePersonalData(MPersonalData model)
        {
            bool bRez = true;
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    Person p = ModelsTransformer.TransferModel<MPersonalData, Person>(model);
                    context.Entry(p).State = EntityState.Modified;
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);
                    bRez = false;
                }
            }
            return bRez;
        }
        public static List<MPicture> GetPictures(int IdPerson)
        {
            List<MPicture> pictures = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                try
                {
                    List<Picture> lst = context.Pictures.Where(x => x.IdReference == IdPerson).ToList();
                    pictures =  ModelsTransformer.TransferModelList<Picture, MPicture>(lst);                    
                }
                catch (Exception e)
                {
                    LogMaster lm = new LogMaster();
                    lm.SetLog(e.Message);
                }
            }
            return pictures;
        }
        public static bool UpdatePersonalKeywords(List<SelectListItem>lstKW, int IdPerson)
        {
            bool bRez = true;
            if (lstKW != null && lstKW.Count > 0 && IdPerson>0)
            {
                using (NostradamusContext context = new NostradamusContext())
                {
                    try
                    {
                        List<Peoplekeywordsstore> toadd = new List<Peoplekeywordsstore>();
                        List<Peoplekeywordsstore> toremove = context.Peoplekeywordsstores.Where(x => x.IdPerson == IdPerson).ToList();
                        context.Peoplekeywordsstores.RemoveRange(toremove);
                        foreach(SelectListItem item in lstKW)
                        {
                            toadd.Add(new Peoplekeywordsstore()
                            {
                                IdPerson = IdPerson,
                                IsAvailable = true,
                                KeyWord = Convert.ToInt16(item.Value)
                            });
                        }
                        context.Peoplekeywordsstores.AddRange(toadd);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        LogMaster lm = new LogMaster();
                        lm.SetLog(e.Message);
                        bRez = false;
                    }
                }
            }
            return bRez;
        }
    }
}
