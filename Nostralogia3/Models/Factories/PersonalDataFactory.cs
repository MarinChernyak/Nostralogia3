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
    public class PersonalDataFactory
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
    }
}
