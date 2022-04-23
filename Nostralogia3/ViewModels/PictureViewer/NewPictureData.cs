using Microsoft.AspNetCore.Http;
using Nostralogia3.Models.DataWorking;
using Nostralogia3.Models.Factories;
using Nostralogia3.Models.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.ViewModels.PictureViewer
{
    public class NewPictureData
    {
        public int IdRef { get; set; }
        public IFormFile Photo { get; set; }
        public string Comments { get; set; }

        public string FullPath { get; protected set; }
        public NewPictureData()
        {
            FullPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), Constants.Paths.ImageRepository));
        }
        public NewPictureData(int id)
        {
            IdRef = id;
            FullPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), Constants.Paths.ImageRepository));
        }
        public async Task<int> UploadFile()
        {
            int newid =0;
            try
            {
                if (Photo.Length > 0)
                {
                    int inum = await PersonalDataFactory.GetValidPictNum(IdRef);
                    string filename = $"{IdRef}_{inum}{ Path.GetExtension(Photo.FileName)}";
                    if (Directory.Exists(FullPath))
                    {
                        using (var filestream = new FileStream(Path.Combine(FullPath, filename), FileMode.Create))
                        {
                            await Photo.CopyToAsync(filestream);
                        }
                        MPicture mp = new MPicture()
                        {
                            FileName = filename,
                            FileSize = (int)(Photo.Length / 1000),
                            IdReference = IdRef,
                            Comments = Comments
                        };
                        newid = PersonalDataFactory.AddNewPicture(mp);
                    }
                }
            }
            catch (Exception e)
            {
                LogMaster lm = new LogMaster();
                lm.SetLog(e.Message);
            }
            return newid ;
        }
    }
}
