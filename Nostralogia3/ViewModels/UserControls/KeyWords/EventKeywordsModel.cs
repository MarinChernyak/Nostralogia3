using Nostralogia3.Models.Factories;
using Nostralogia3.ViewModels.UserControls.KeyWords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Models.UserControls.KeyWords
{
    public class EventKeywordsModel : KeyWordsBase
    {

        public override bool SaveForStorage()
        {
            bool bRez = PersonalDataFactory.UpdateWorldEventKeywords(_lstSelectedKeyWordsCollection, IdForKWStorage);
            return bRez;
        }

        protected override void InitCollection(int idKW)
        {
            MKeyWord kw = KeyWordsFactory.GetKeyWord(idKW);
            kw = KeyWordsFactory.GetKeyWordByRef(kw.ReferenceId);
            if (kw != null)
            {
                _lstKeyWordsCollection = KeyWordsFactory.GetKWSelectListByRef(kw.ReferenceId);
            }
            else
            {
                _lstKeyWordsCollection = KeyWordsFactory.GetRootKWSelectList();
            }
        }
    }
}
