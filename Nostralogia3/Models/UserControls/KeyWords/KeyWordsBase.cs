using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls.KeyWords
{
    public abstract class KeyWordsBase
    {
        protected IEnumerable<SelectListItem> _lstKeyWordsCollection;
        protected List<SelectListItem> _lstSelectedKeyWordsCollection;
        protected List<MKeyWord> _lstMainKWCollection;
        //for example - Id of person, or Id of Event
        public int IdForKWStorage { get; set; }
        public List<SelectListItem> KeyWordsCollection
        {
            get
            {
                return _lstKeyWordsCollection.ToList();
            }
        }
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
        public KeyWordsBase(int id = 0, int idforstorage = 0)
        {
            IdForKWStorage = idforstorage;
            InitCollection(id);

        }
        protected abstract void InitCollection(int Id);
        public abstract bool SaveForStorage();
    }
}
