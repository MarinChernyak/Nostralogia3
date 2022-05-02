using Nostralogia3.Models.Factories;
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
            bool bRez = PersonalDataFactory.UpdatePersonalKeywords(_lstSelectedKeyWordsCollection, IdForKWStorage);
            return bRez;
        }

        protected override void InitCollection(int Id)
        {

        }
    }
}
