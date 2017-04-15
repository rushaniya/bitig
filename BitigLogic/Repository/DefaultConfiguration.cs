using System;
using System.Collections.Generic;
using System.Drawing;
using Bitig.Base;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public static class DefaultConfiguration
    {
        public static readonly string LocalFolder = System.IO.Path.Combine(
           Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Bitig");

        static DefaultConfiguration()
        {
            FillBuiltInLists();
        }

        private static void FillBuiltInLists()
        {
            FillBuiltInAlifbas();
            FillBuiltInDirections();
        }

        #region Alifbas

        public const int CYRILLIC = 0; //repo: what if repo does not support zero IDs? 
        public const int YANALIF = 1;
        public const int ZAMANALIF = 2;
        public const int RASMALIF = 3;
        public const int MIN_CUSTOM_ID = 1024;

        public const string YANALIF_NAME = "Yanalif";
        private const string CYRILLIC_NAME = "Cyrillic";
        private const string ZAMANALIF_NAME = "Zamanalif";
        private const string RASMALIF_NAME = "Official 2012";//loc

        private static List<Alifba> builtInAlifbaList;
        private static Alifba yanalif;

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

        private static void FillBuiltInAlifbas()
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
                case YANALIF: //config: add all yanalif symbols and let UI decide?
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

        #endregion


        #region Directions

        private const int CYRILLIC_YANALIF = 0;
        private const int CYRILLIC_ZAMANALIF = 1;
        private const int CYRILLIC_RASMALIF = 2;
        private const int YANALIF_ZAMANALIF = 3;
        private const int YANALIF_RASMALIF = 4;
        private const int ZAMANALIF_YANALIF = 5;
        private const int RASMALIF_YANALIF = 6;

        private static List<Direction> directionsList;

        private static List<BuiltInDirection> builtInDirections;

        public static List<BuiltInDirection> BuiltInDirections
        {
            get { return builtInDirections; }
        }

        private static void FillBuiltInDirections()
        {
            builtInDirections = new List<BuiltInDirection>();
            builtInDirections.Add(CreateBuiltInDirection(CYRILLIC_YANALIF, CYRILLIC, YANALIF));
            builtInDirections.Add(CreateBuiltInDirection(CYRILLIC_ZAMANALIF, CYRILLIC, ZAMANALIF));
            builtInDirections.Add(CreateBuiltInDirection(CYRILLIC_RASMALIF, CYRILLIC, RASMALIF));
            builtInDirections.Add(CreateBuiltInDirection(YANALIF_ZAMANALIF, YANALIF, ZAMANALIF));
            builtInDirections.Add(CreateBuiltInDirection(YANALIF_RASMALIF, YANALIF, RASMALIF));
            builtInDirections.Add(CreateBuiltInDirection(ZAMANALIF_YANALIF, ZAMANALIF, YANALIF));
            builtInDirections.Add(CreateBuiltInDirection(RASMALIF_YANALIF, RASMALIF, YANALIF));
        }

        private static BuiltInDirection CreateBuiltInDirection(int ID, int SourceID, int TargetID)
        {
            var _source = builtInAlifbaList.Find(_alif => _alif.ID == SourceID);
            var _target = builtInAlifbaList.Find(_alif => _alif.ID == TargetID);
            return new Model.BuiltInDirection(ID, _source, _target);
        }

        public static BuiltInDirection GetBuiltInDirection(int SourceID, int TargetID)
        {
            return builtInDirections.Find(_dir => _dir.Source.ID == SourceID && _dir.Target.ID == TargetID);
        }

        internal static int GetBuiltInID(int SourceID, int TargetID)
        {
            BuiltInDirection _builtIn = builtInDirections.Find(_dir => _dir.Source.ID == SourceID && _dir.Target.ID == TargetID);
            if (_builtIn == null) return -1;
            return _builtIn.ID;
        }

        public static int GetBuiltInSourceID(int BuiltInID)
        {
            BuiltInDirection _builtIn = builtInDirections.Find(_dir => _dir.ID == BuiltInID);
            if (_builtIn != null)
                return _builtIn.Source.ID;
            return -1;
        }

        public static int GetBuiltInTargetID(int BuiltInID)
        {
            BuiltInDirection _builtIn = builtInDirections.Find(_dir => _dir.ID == BuiltInID);
            if (_builtIn != null)
                return _builtIn.Target.ID;
            return -1;
        }

        public static TranslitCommand GetTranslitCommand(int BuiltInID)
        {
            TranslitCommand _commandObject = null;
            switch (BuiltInID)
            {
                case CYRILLIC_YANALIF:
                    _commandObject = new Commands.CyrillicYanalif();
                    break;
                case CYRILLIC_ZAMANALIF:
                    _commandObject = new Commands.CyrillicZamanalif();
                    break;
                case CYRILLIC_RASMALIF:
                    _commandObject = new Commands.CyrillicRasmalif();
                    break;
                case YANALIF_ZAMANALIF:
                    _commandObject = new Commands.YanalifZamanalif();
                    break;
                case YANALIF_RASMALIF:
                    _commandObject = new Commands.YanalifRasmalif();
                    break;
                case ZAMANALIF_YANALIF:
                    _commandObject = new Commands.ZamanalifYanalif();
                    break;
                case RASMALIF_YANALIF:
                    _commandObject = new Commands.RasmalifYanalif();
                    break;
            }
            return _commandObject;
        }

        public static BuiltInDirection GetBuiltInDirection(int BuiltInID)
        {
            return builtInDirections.Find(_dir => _dir.ID == BuiltInID);
        }

        #endregion
    }
    
}
