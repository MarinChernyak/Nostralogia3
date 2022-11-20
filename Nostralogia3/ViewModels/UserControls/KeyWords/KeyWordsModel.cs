using Microsoft.AspNetCore.Mvc.Rendering;
using Nostralogia3.Models.Factories;
using NostralogiaDAL.NostradamusEntities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Nostralogia3.ViewModels.UserControls.KeyWords
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
        public KeyWordsCollectionModelDD(int id)
            :base(id, 0)
        {

        }
        protected override void InitCollection(int idKW)
        {
            if (_lstMainKWCollection == null || _lstMainKWCollection.Count == 0)
            {
                _lstMainKWCollection = KeyWordsFactory.GetRootKWList();
            }

            _lstKeyWordsCollection = KeyWordsFactory.GetKWSelectListByRef(idKW);
        }
    }
    public class KeyWordsCollectionModelDU : KeyWordsCollectionModel
    {
        public KeyWordsCollectionModelDU(int id)
            : base(id, 0)
        {

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
    public class KeyWordsCollectionModel :KeyWordsBase
    {
        public KeyWordsCollectionModel(int id = 0, int idforstorage = 0)
            :base(id,idforstorage)
        {

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
                InitCollection(0);
        }
        protected override void InitCollection(int idRef)
        {
            /// Here add your code to obtain a full collection. "dbo" - is a default schems in your DB in SQL Server.
            if (_lstSelectedKeyWordsCollection == null || _lstSelectedKeyWordsCollection.Count==0)
            {
                _lstSelectedKeyWordsCollection = KeyWordsFactory.GetPersonalKWList(IdForKWStorage);        
            }
            if (_lstKeyWordsCollection == null || _lstKeyWordsCollection.Count() == 0)
            {
                _lstKeyWordsCollection = KeyWordsFactory.GetRootKWSelectList();

            }
        }

        public override bool SaveForStorage()
        {
            bool bRez = PersonalDataFactory.UpdatePersonalKeywords(_lstSelectedKeyWordsCollection,IdForKWStorage);
            return bRez;
        }
    }
}