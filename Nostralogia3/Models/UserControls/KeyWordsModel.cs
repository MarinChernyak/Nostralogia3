using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Factories;
using NostralogiaDAL.NostradamusEntities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Nostralogia3.Models
{
    public class  MKeyWord
    {
        public short Idkw { get; set; }
        public short ReferenceId { get; set; }
        public byte AccessLevel { get; set; }
        public string AdvKeyWord { get; set; }
        public string KeyWordDescription { get; set; }
    }
    public class KeyWordsCollectionModelDD : KeyWordsCollectionModel
    {
        public KeyWordsCollectionModelDD(int id,string schema = "dbo")
            :base(id, 0,schema)
        {

        }
        protected override void InitCollection(int idKW, string schema = "dbo")
        {
            if (_lstMainKWCollection == null || _lstMainKWCollection.Count == 0)
                base.InitCollection(idKW, schema);

            _lstKeyWordsCollection = _lstMainKWCollection.Where(x => x.ReferenceId == idKW).Select(c => new SelectListItem()
            {
                Text = c.KeyWordDescription,
                Value = c.Idkw.ToString()
            });
        }
    }
    public class KeyWordsCollectionModelDU : KeyWordsCollectionModel
    {
        public KeyWordsCollectionModelDU(int id,  String schema = "dbo")
            : base(id, 0, schema)
        {

        }
        protected override void InitCollection(int idKW, string schema = "dbo")
        {
            if (_lstMainKWCollection == null || _lstMainKWCollection.Count == 0)
                InitCollection(idKW, schema);

            MKeyWord kw = _lstMainKWCollection.Where(x => x.Idkw == idKW).First();

            kw = _lstMainKWCollection.Where(x => x.Idkw == kw.ReferenceId).FirstOrDefault();
            if (kw != null)
            {
                _lstKeyWordsCollection = _lstMainKWCollection.Where(x => x.ReferenceId == kw.ReferenceId).Select(c => new SelectListItem()
                {
                    Text = c.KeyWordDescription,
                    Value = c.Idkw.ToString()
                });
            }
            else
            {
                _lstKeyWordsCollection = _lstMainKWCollection.Where(x => x.ReferenceId == 0).Select(c => new SelectListItem()
                {
                    Text = c.KeyWordDescription,
                    Value = c.Idkw.ToString()
                });
            }

        }
    }
    public class KeyWordsCollectionModel :BaseModel
    {
        //for example - Id of eprson, or Id of Event
       public  int IdForKWStorage { get; protected set; }
        //Irt is a data source just for the DEMO puprose
        protected static List<MKeyWord> _lstMainKWCollection;
        
        protected IEnumerable<SelectListItem> _lstKeyWordsCollection;
        public List<SelectListItem> KeyWordsCollection
        {
            get{
                return _lstKeyWordsCollection.ToList();
            }
        }
        protected List<SelectListItem> _lstSelectedKeyWordsCollection;
        public List<SelectListItem> SelectedKeyWordsCollection
        {
            get
            {
                if (_lstSelectedKeyWordsCollection == null)
                {
                    _lstSelectedKeyWordsCollection = new List<SelectListItem>();
                }
                return _lstSelectedKeyWordsCollection;
            }
        }
        public override string ToString()
        {

            String sOut = "No keword(s) selected...";
            if (SelectedKeyWordsCollection != null && _lstSelectedKeyWordsCollection.Count > 0)
            {
                sOut = String.Empty;
                foreach (SelectListItem sli in SelectedKeyWordsCollection)
                {
                    sOut = String.Format("{0}, {1}", sOut, sli.Text);
                }
                if (!String.IsNullOrEmpty(sOut))
                {
                    sOut = sOut.Substring(2);
                }
            }
            return sOut;
        }
        public KeyWordsCollectionModel(int id=0, int idforstorage=0, String schema = "dbo")
        {
            IdForKWStorage = idforstorage;
            InitCollection(id,schema);

        }
        public KeyWordsCollectionModel(List<MKeyWord> lstKW, int idforstorage = 0)
        {

            IdForKWStorage = idforstorage;
            if (lstKW != null)
            {
                _lstKeyWordsCollection = from c in lstKW
                                                 select new SelectListItem
                                                 {
                                                     Text = c.KeyWordDescription,
                                                     Value = c.Idkw.ToString()
                                                 };
            }
            else
                InitCollection(0, "dbo");
        }
        protected virtual void InitCollection(int idRef,String schema = "dbo")
        {
            /// Here add your code to obtain a full collection. "dbo" - is a default schems in your DB in SQL Server.
            if(_lstMainKWCollection==null || _lstMainKWCollection.Count==0)
            {
                
                using(NostradamusContext context = new NostralogiaDAL.NostradamusEntities.NostradamusContext())
                {
                    List<Keyword> lst = context.Keywords.Where(x=>x.Idkw > 0).ToList();
                    _lstMainKWCollection = ModelsTransformer.TransferModelList<Keyword, MKeyWord>(lst);

                    if (IdForKWStorage > 0)
                    {
                        _lstSelectedKeyWordsCollection = context.Peoplekeywordsstores.Join(context.Keywords, pks=>pks.KeyWord,kw=>kw.Idkw, (pks,kw)=>new {Pks = pks, Kw = kw}).
                            Where(x=>x.Pks.IdPerson== IdForKWStorage).Select(c => new SelectListItem()
                        {
                            Text = c.Kw.KeyWordDescription,
                            Value = c.Kw.Idkw.ToString()
                        }).ToList();
                    }
                }                 
            }
          _lstKeyWordsCollection = _lstMainKWCollection.Where(x => x.ReferenceId == 0).Select(c => new SelectListItem()
            {
                Text = c.KeyWordDescription,
                Value = c.Idkw.ToString()
            });





        }

        protected void GetUpdatedKeyWordsCollection(MKeyWord[] lstKeyWordsCollection)
        {
            if (lstKeyWordsCollection != null)
            {
                _lstKeyWordsCollection = from c in lstKeyWordsCollection                                         
                                         select new SelectListItem
                                         {
                                             Text = c.KeyWordDescription,
                                             Value = c.Idkw.ToString()
                                         };
            }

        }
        public virtual bool SaveForStorage()
        {
            bool bRez = PersonalDataFactory.UpdatePersonalKeywords(_lstSelectedKeyWordsCollection,IdForKWStorage);
            return bRez;
        }
    }
}