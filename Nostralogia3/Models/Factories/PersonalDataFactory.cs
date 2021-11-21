using Nostralogia3.Models.Persons;
using NostralogiaDAL.NostradamusEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.Factories
{
    public class PersonalDataFactory 
    {
        public static List<MVwPersonalDisplayDatum> GetPersonalDisplayDataList(int Nrecords=10)
        {
            List<MVwPersonalDisplayDatum> lst = null;
            using (NostradamusContext context = new NostradamusContext())
            {
          
                
                
                var lstrecords = context.VwPersonalDisplayData.OrderByDescending(x => x.Id).Take(Nrecords).ToList();


                lst = ModelsTransformer.TransferModelList<VwPersonalDisplayDatum, MVwPersonalDisplayDatum>(lstrecords);
            }

            return lst;
        }
    }
}
