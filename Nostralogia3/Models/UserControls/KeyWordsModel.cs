using Microsoft.AspNetCore.Mvc.Rendering;
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
        public KeyWordsCollectionModelDD(int id, String schema = "dbo")
            :base(id,schema)
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
        public KeyWordsCollectionModelDU(int id, String schema = "dbo")
            : base(id,schema)
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
        //Irt is a data source just for the DEMO puprose
        protected static List<MKeyWord> _lstMainKWCollection;
        
        protected IEnumerable<SelectListItem> _lstKeyWordsCollection;
        public List<SelectListItem> KeyWordsCollection
        {
            get{
                return _lstKeyWordsCollection.ToList();
            }
        }
        protected IEnumerable<SelectListItem> _lstSelectedKeyWordsCollection;
        public IEnumerable<SelectListItem> SelectedKeyWordsCollection
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

            String sOut = "Nothing selected...";
            if (SelectedKeyWordsCollection != null)
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
        public KeyWordsCollectionModel(int id=0, String schema = "dbo")
        {
            InitCollection(id,schema);

        }
        public KeyWordsCollectionModel(List<MKeyWord> lstKW)
        {
            
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
                }
                 
            }
          _lstKeyWordsCollection = _lstMainKWCollection.Where(x => x.ReferenceId == 0).Select(c => new SelectListItem()
            {
                Text = c.KeyWordDescription,
                Value = c.Idkw.ToString()
            });



        }
        protected void InintMainCollection_JUST_FOR_DEMO()
        {
            //_lstMainKWCollection = new List<KeyWord>();
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 1, KeyWordDescription = "Plants",  ReferenceID = 0});
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 2, KeyWordDescription = "Animals", ReferenceID = 0 });

            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 3, KeyWordDescription = "Flowers", ReferenceID = 1});
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 4, KeyWordDescription = "Trees", ReferenceID = 1 });

            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 5, KeyWordDescription = "Carnation", ReferenceID = 3 });
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 6, KeyWordDescription = "Camomile", ReferenceID = 3 });
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 7, KeyWordDescription = "Oak", ReferenceID = 4 });
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 8, KeyWordDescription = "Pine", ReferenceID = 4 });

            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 9, KeyWordDescription = "Mammals", ReferenceID = 2});
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 10, KeyWordDescription = "Birds", ReferenceID = 2 });

            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 11, KeyWordDescription = "Elephant", ReferenceID = 9 });
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 12, KeyWordDescription = "Mouse", ReferenceID = 9 });
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 13, KeyWordDescription = "Eagle", ReferenceID = 10 });
            //_lstMainKWCollection.Add(new KeyWord() { IDKW = 14, KeyWordDescription = "Sparrow", ReferenceID = 10 });

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
    }
}