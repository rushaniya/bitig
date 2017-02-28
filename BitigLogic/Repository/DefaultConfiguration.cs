using System;
using System.Collections.Generic;
using System.Drawing;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public static class DefaultConfiguration
    {
        public static readonly string LocalFolder = System.IO.Path.Combine(
           Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Bitig");

        private const int CYRILLIC = 0;
        public const int YANALIF = 1;
        private const int ZAMANALIF = 2;
        private const int RASMALIF = 3;
        public const int MIN_CUSTOM_ID = 1024;

        public const string YANALIF_NAME = "Yanalif";
        private const string CYRILLIC_NAME = "Cyrillic";
        private const string ZAMANALIF_NAME = "Zamanalif";
        private const string RASMALIF_NAME = "Official 2012";//loc

        private static List<Alifba> builtInAlifbaList;
        private static Alifba yanalif;
        //private static AlifbaIDGenerator alifbaIDGenerator;

        //public static AlifbaIDGenerator AlifbaIDGenerator
        //{
        //    get
        //    {
        //        return alifbaIDGenerator;
        //    }
        //}

        public static List<Alifba> BuiltInAlifbaList
        {
            get
            {
                return builtInAlifbaList;
            }
        }

        public static Alifba Yanalif
        {
            get
            {
                return yanalif;
            }
        }

        private static AlifbaFont defaultYanalifFont = new AlifbaFont("DejaVu Sans", 12, FontStyle.Regular);

        public static AlifbaFont DefaultYanalifFont
        {
            get { return defaultYanalifFont; }
        }

        static DefaultConfiguration()
        {
            FillBuiltInList();
           // alifbaIDGenerator = new AlifbaIDGenerator();
        }

        private static void FillBuiltInList()
        {
            builtInAlifbaList = new List<Alifba>();
            yanalif = new Alifba(YANALIF, YANALIF_NAME, GetDefaultSymbols(YANALIF), false, defaultYanalifFont);
            builtInAlifbaList.Add(new Alifba(CYRILLIC, CYRILLIC_NAME, GetDefaultSymbols(CYRILLIC)));
            builtInAlifbaList.Add(yanalif);
            builtInAlifbaList.Add(new Alifba(ZAMANALIF, ZAMANALIF_NAME, GetDefaultSymbols(ZAMANALIF)));
            builtInAlifbaList.Add(new Alifba(RASMALIF, RASMALIF_NAME, GetDefaultSymbols(RASMALIF)));

        }        

        private static List<AlifbaSymbol> GetDefaultSymbols(int AlifbaID)
        {
            List<AlifbaSymbol> _result = new List<AlifbaSymbol>();
            switch (AlifbaID) 
            {
                    //excl: get alphabet symbols from directions' alphabet patterns?
                case CYRILLIC:
                    _result.Add(new AlifbaSymbol("\u04d9", "\u04d9", "\u04d8", "\u04d8"));//Ә
                    _result.Add(new AlifbaSymbol("\u04e9", "\u04e9", "\u04e8", "\u04e8"));//Ө
                    _result.Add(new AlifbaSymbol("\u04af", "\u04af", "\u04ae", "\u04ae"));//Ү
                    _result.Add(new AlifbaSymbol("\u0497", "\u0497", "\u0496", "\u0496"));//Җ
                    _result.Add(new AlifbaSymbol("\u04a3", "\u04a3", "\u04a2", "\u04a2"));//Ң
                    _result.Add(new AlifbaSymbol("\u04bb", "\u04bb", "\u04ba", "\u04ba"));//Һ
                    break;
                case ZAMANALIF:
                    _result.Add(new AlifbaSymbol("\u00e4", "\u00e4", "\u00c4", "\u00c4"));//Ä
                    _result.Add(new AlifbaSymbol("\u00e2", "\u00e2", "\u00c2", "\u00c2"));//Â
                    _result.Add(new AlifbaSymbol("\u00e1", "\u00e1", "\u00c1", "\u00c1"));//Á
                    _result.Add(new AlifbaSymbol("\u00e7", "\u00e7", "\u00c7", "\u00c7"));//Ç
                    _result.Add(new AlifbaSymbol("\u00e9", "\u00e9", "\u00c9", "\u00c9"));//É
                    _result.Add(new AlifbaSymbol("\u011f", "\u011f", "\u011e", "\u011e"));//Ğ
                    _result.Add(new AlifbaSymbol("\u0131", "\u0131", "\u0130", "\u0130"));//İı
                    _result.Add(new AlifbaSymbol("\u00ed", "\u00ed", "\u00cd", "\u00cd"));//Í
                    _result.Add(new AlifbaSymbol("\u00f1", "\u00f1", "\u00d1", "\u00d1"));//Ñ
                    _result.Add(new AlifbaSymbol("\u00f6", "\u00f6", "\u00d6", "\u00d6"));//Ö
                    _result.Add(new AlifbaSymbol("\u00f3", "\u00f3", "\u00d3", "\u00d3"));//Ó
                    _result.Add(new AlifbaSymbol("\u015f", "\u015f", "\u015e", "\u015e"));//Ş
                    _result.Add(new AlifbaSymbol("\u00fc", "\u00fc", "\u00dc", "\u00dc"));//Ü
                    _result.Add(new AlifbaSymbol("\u00fa", "\u00fa", "\u00da", "\u00da"));//Ú
                    break;
                case RASMALIF:
                    _result.Add(new AlifbaSymbol("\u00e4", "\u00e4", "\u00c4", "\u00c4"));//Ä
                    _result.Add(new AlifbaSymbol("\u00e7", "\u00e7", "\u00c7", "\u00c7"));//Ç
                    _result.Add(new AlifbaSymbol("\u0131", "\u0131", "\u0130", "\u0130"));//İı
                    _result.Add(new AlifbaSymbol("\u00f1", "\u00f1", "\u00d1", "\u00d1"));//Ñ
                    _result.Add(new AlifbaSymbol("\u00f6", "\u00f6", "\u00d6", "\u00d6"));//Ö
                    _result.Add(new AlifbaSymbol("\u015f", "\u015f", "\u015e", "\u015e"));//Ş
                    _result.Add(new AlifbaSymbol("\u00fc", "\u00fc", "\u00dc", "\u00dc"));//Ü
                    break;
                case YANALIF:
                    _result.Add(new AlifbaSymbol("\u00ab", "\u00ab"));//«
                    _result.Add(new AlifbaSymbol("\u00bb", "\u00bb"));//»
                    _result.Add(new AlifbaSymbol("\u2014", "\u2014"));//—
                    break;
            }
            return _result;
        }

        public static bool IsBuiltIn(int AlifbaID)
        {
            return AlifbaID < MIN_CUSTOM_ID;
        }

        //public static int GenerateNewAlifbaID(List<Alifba> AlifbaList)
        //{
        //    int _result = -1;
        //    for (int i = MIN_CUSTOM_ID; i < int.MaxValue; i++)
        //    {
        //        if (!AlifbaList.Exists(_alif => _alif.ID == i))
        //        {
        //            _result = i;
        //            break;
        //        }
        //    }
        //    return _result;
        //}
    }

        //public class AlifbaIDGenerator : IIDGenerator<Alifba, int>
        //{
        //public int DefaultID
        //{
        //    get
        //    {
        //        return -1;
        //    }
        //}

        //public int GenerateID(List<Alifba> List)
        //    {
        //        int _result = -1;
        //        for (int i = DefaultConfiguration.MIN_CUSTOM_ID; i < int.MaxValue; i++)
        //        {
        //            if (!List.Exists(_alif => _alif.ID == i))
        //            {
        //                _result = i;
        //                break;
        //            }
        //        }
        //        return _result;
        //    }
        //}
}
