using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.UserControls.KeyWords;
using Nostralogia3.ViewModels.UserControls.KeyWords;
using NostralogiaDAL.NostradamusEntities;
using System.Collections.Generic;
using System.Linq;

namespace Nostralogia3.Models.Factories
{
    public class KeyWordsFactory
    {
        public static List<MKeyWord> GetRootKWList()
        {
            return GetKWListByRef(0);
        }
        public static List<SelectListItem> GetRootKWSelectList()
        {
            List<SelectListItem> lst = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                lst = context.Keywords.Where(x => x.Idkw > 0 && x.ReferenceId == 0).Select(c => new SelectListItem()
                {
                    Text = c.KeyWordDescription,
                    Value = c.Idkw.ToString()
                }).ToList();
            }
            return lst;
        }
        public static List<MKeyWord> GetKWListByRef(int IdRef)
        {
            List<Keyword> lst = null;
            List<MKeyWord> lstOut = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                lst = context.Keywords.Where(x => x.Idkw > 0 && x.ReferenceId == IdRef).OrderBy(x => x.KeyWordDescription).ToList();
                lstOut = ModelsTransformer.TransferModelList<Keyword, MKeyWord>(lst);
            }
            return lstOut;
        }
        public static List<SelectListItem> GetKWSelectListByRef(int IdRef)
        {
            List<SelectListItem> lstOut = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                lstOut = context.Keywords.Where(x => x.Idkw > 0 && x.ReferenceId == IdRef).OrderBy(x=>x.KeyWordDescription).Select(c => new SelectListItem()
                {
                    Text = c.KeyWordDescription,
                    Value = c.Idkw.ToString()
                }).ToList(); ;
                
            }
            return lstOut;
        }
        public static List<SelectListItem> GetPersonalKWList(int IdForKWStorage)
        {
            List<SelectListItem> lstSelectedKeyWordsCollection = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                List<Keyword> lst = context.Keywords.Where(x => x.Idkw > 0).ToList();
                List<MKeyWord> lstMainKWCollection = ModelsTransformer.TransferModelList<Keyword, MKeyWord>(lst);

                if (IdForKWStorage > 0)
                {
                    lstSelectedKeyWordsCollection = context.Peoplekeywordsstores.Join(context.Keywords, pks => pks.KeyWord, kw => kw.Idkw, (pks, kw) => new { Pks = pks, Kw = kw }).
                    Where(x => x.Pks.IdPerson == IdForKWStorage).Select(c => new SelectListItem()
                    {
                        Text = c.Kw.KeyWordDescription,
                        Value = c.Kw.Idkw.ToString()
                    }).ToList();
                }
            }
            return lstSelectedKeyWordsCollection;
        }
        public static MKeyWord GetKeyWord(int IdKW)
        {
            MKeyWord mkw = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                Keyword kw = context.Keywords.FirstOrDefault(x => x.Idkw == IdKW);
                mkw = ModelsTransformer.TransferModel<Keyword, MKeyWord>(kw);
            }

            return mkw;
        }
        public static MKeyWord GetKeyWordByRef(int IdKWRef)
        {
            MKeyWord mkw = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                Keyword kw = context.Keywords.FirstOrDefault(x => x.Idkw == IdKWRef);
                mkw = ModelsTransformer.TransferModel<Keyword, MKeyWord>(kw);
            }
            return mkw;
        }
        public static MKeyWord GetWorldEventKeyWordByRef(int IdKWRef)
        {
            MKeyWord mkw = null;
            using (NostradamusContext context = new NostradamusContext())
            {
                KeyWord1 kw = context.KeyWords1.FirstOrDefault(x => x.Idkw == IdKWRef);
                mkw = ModelsTransformer.TransferModel<KeyWord1, MKeyWord>(kw);
            }
            return mkw;
        }
    }
}
