using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nostralogia3.Utilities
{
    public class StringGenerator
    {
        private const int default_string_length = 8;
        protected string _genstr = "";
        public string GenericString { get { return _genstr; } }
        protected int NumberSymbols { get; set; }
        protected bool Numbers { get; set; }
        protected bool SpecialSymbols { get; set; }
        protected bool CapitalsLetters { get; set; }
        protected bool SmallLetters { get; set; }

        public StringGenerator(int iNumSymb= default_string_length, bool bNum=true, bool bSpecSymb=true, bool CapLetters=true, bool SmLetters=true)
        {
            NumberSymbols = iNumSymb;
            Numbers = bNum;
            SpecialSymbols = bSpecSymb;
            CapitalsLetters = CapLetters;
            SmallLetters = SmLetters;
            Generate();
        }
        public void Generate()
        {
            _genstr = String.Empty;
            if (NumberSymbols == 0)
                NumberSymbols = default_string_length;

            int NumSections = 0;
            if (Numbers)
                NumSections++;
            if (SmallLetters)
                NumSections++;
            if (CapitalsLetters)
                NumSections++;
            if (SmallLetters)
                NumSections++;
            if (SpecialSymbols)
                NumSections++;

            if (NumSections == 0)
            {
                NumSections = 1;
                SmallLetters = true;
            }
            int iNumSymbolsInSec = NumberSymbols / NumSections;
            if (iNumSymbolsInSec * NumSections < NumberSymbols)
                iNumSymbolsInSec++;


            Random rnd = new Random();
            int iCount = 0;
            int[] iAll = new int[4];
            for (int i = 0; i < 4; i++)
            {
                iAll[i] = 0;
            }
            int iCh = 0;

            if (!Numbers)
                iAll[1] = 1;
            if (!SpecialSymbols)
                iAll[0] = 1;
            if (!SmallLetters)
                iAll[3] = 1;
            if (!CapitalsLetters)
                iAll[2] = 1;

            while (iCount < NumberSymbols || iAll[0] == 0 || iAll[1] == 0 || iAll[2] == 0 || iAll[3] == 0)
            {
                iCh = rnd.Next(35, 122);
                if ((iCh < 37
                    || iCh == 43/*+*/
                    || iCh == 45/*-*/
                    || iCh == 61 /*=*/
                    || iCh == 64 /*@*/
                    || iCh == 94/*^*/
                    || iCh == 95/*_*/) && iAll[0] < iNumSymbolsInSec && SpecialSymbols)
                {
                    iAll[0]++;
                    _genstr += Convert.ToChar(iCh);
                    iCount++;
                }
                else if (iCh < 58 && iCh > 47 && iAll[1] < iNumSymbolsInSec && Numbers)
                {
                    iAll[1]++;
                    _genstr += Convert.ToChar(iCh);
                    iCount++;
                }
                else if (iCh > 64 && iCh < 91 && iAll[2] < iNumSymbolsInSec && CapitalsLetters)
                {
                    iAll[2]++;
                    _genstr += Convert.ToChar(iCh);
                    iCount++;
                }
                else if (iCh > 96 && iAll[3] < iNumSymbolsInSec && SmallLetters)
                {
                    iAll[3]++;
                    _genstr += Convert.ToChar(iCh);
                    iCount++;
                }
            }
        }
    }
}
