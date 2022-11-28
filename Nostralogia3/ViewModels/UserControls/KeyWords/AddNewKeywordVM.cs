using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Factories;
using System;
using System.Collections.Generic;

namespace Nostralogia3.ViewModels.UserControls.KeyWords
{
    public class AddNewKeywordVM : VisualBaseVM
    {
        public string Keyword { get; set; }
        public int AccessLevel { get; set; }
        public int RefKW { get; set; }
        public int  MapId { get; set; }
        public List<SelectListItem> KeyWordsCollection { get; protected set; }
        public List<SelectListItem> AccessLevelCollection { get; protected set; }
        public AddNewKeywordVM()
        {

        }
        public AddNewKeywordVM(int idmap)
        {
            MapId=idmap;
            InitCollections();
        }

        private void InitCollections()
        {
            AccessLevelCollection = PersonalDataFactory.GetDataTypes();
        }

        public void CreateNewKeyword()
        {

        }
    }
}
