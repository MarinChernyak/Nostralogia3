using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Nostralogia3.Models.Utilities
{
    public class LogMaster
    {
        protected string Path { get; }
        public LogMaster()
        {
            Path = @"C:\Nostradamus\Data\Logs";
            if(!Directory.Exists(Path))
            {
                Directory.CreateDirectory(Path);
            }
        }
        public void SetLog(string log)
        {
            DateTime dt = DateTime.Now;
            string filename = $"Nostralogia3_{dt.ToShortDateString().Replace("/","_")}.log";
            if(!File.Exists($"{Path}\\{filename}"))
            {
                using (StreamWriter sw = File.CreateText($"{Path}\\{filename}"))
                {
                    sw.WriteLine(log);
                }
            }
        }
        public void SetLogException(string classfrom, string function, string exception)
        {
            string msg = $"{classfrom}->{function}->{exception}";
            SetLog(msg);
        } 

    }
}
