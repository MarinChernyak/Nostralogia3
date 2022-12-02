using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels.UserControls.KeyWords
{
    public class AddNewKeywordVM : VisualBaseVM
    {
        public string Keyword { get; set; }
        public int AccessLevel { get; set; }
        public int RefKW { get; set; }
        public int MapId { get; set; }
        public List<SelectListItem> KeyWordsCollection { get; protected set; }
        public List<SelectListItem> AccessLevelCollection { get; protected set; }
        public AddNewKeywordVM()
        {

            InitCollections();
        }
        public AddNewKeywordVM(int mapid)
        {
            MapId = mapid;
            InitCollections();
        }
        private void InitCollections()
        {
            AccessLevelCollection = PersonalDataFactory.GetDataTypes();
            KeyWordsCollection = KeyWordsFactory.GetRootKWSelectList();
        }

        public async Task<bool> CreateNewKeyword()
        {
            //string kw, int accessLevel, int refid
            return await KeyWordsFactory.CreateNewKeyword(Keyword, AccessLevel, RefKW);
        }
    }
}
