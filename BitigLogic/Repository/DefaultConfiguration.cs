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

        public const string YANALIF_NAME = "Yanalif";
        private const string CYRILLIC_NAME = "Cyrillic";
        private const string ZAMANALIF_NAME = "Zamanalif";
        private const string RASMALIF_NAME = "Official 2012";//loc

        private static List<BuiltInAlifba> builtInAlifbaList;
        private static BuiltInAlifba yanalif;

        public static List<BuiltInAlifba> BuiltInAlifbaList
        {
            get
            {
                return builtInAlifbaList;
            }
        }

        public static BuiltInAlifba Yanalif
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
            builtInAlifbaList = new List<BuiltInAlifba>();
            yanalif = new BuiltInAlifba(BuiltInAlifbaType.Yanalif, YANALIF_NAME, 
                GetDefaultSymbols(BuiltInAlifbaType.Yanalif), false, defaultYanalifFont);
            builtInAlifbaList.Add(new BuiltInAlifba(BuiltInAlifbaType.Cyrillic, CYRILLIC_NAME,
                GetDefaultSymbols(BuiltInAlifbaType.Cyrillic)));
            builtInAlifbaList.Add(yanalif);
            builtInAlifbaList.Add(new BuiltInAlifba(BuiltInAlifbaType.Zamanalif, ZAMANALIF_NAME, 
                GetDefaultSymbols(BuiltInAlifbaType.Zamanalif)));
            builtInAlifbaList.Add(new BuiltInAlifba(BuiltInAlifbaType.Rasmalif, RASMALIF_NAME, 
                GetDefaultSymbols(BuiltInAlifbaType.Rasmalif)));
        }

        private static List<AlifbaSymbol> GetDefaultSymbols(BuiltInAlifbaType AlifbaID)
        {
            List<AlifbaSymbol> _result = new List<AlifbaSymbol>();
            switch (AlifbaID)
            {
                //excl: get alphabet symbols from directions' alphabet patterns?
                case BuiltInAlifbaType.Cyrillic:
                    _result.Add(new AlifbaSymbol("\u04d9", "\u04d8", "\u04d9", "\u04d8"));//Ә
                    _result.Add(new AlifbaSymbol("\u04e9", "\u04e8", "\u04e9", "\u04e8"));//Ө
                    _result.Add(new AlifbaSymbol("\u04af", "\u04ae", "\u04af", "\u04ae"));//Ү
                    _result.Add(new AlifbaSymbol("\u0497", "\u0496", "\u0497", "\u0496"));//Җ
                    _result.Add(new AlifbaSymbol("\u04a3", "\u04a2", "\u04a3", "\u04a2"));//Ң
                    _result.Add(new AlifbaSymbol("\u04bb", "\u04ba", "\u04bb", "\u04ba"));//Һ
                    break;
                case BuiltInAlifbaType.Zamanalif:
                    _result.Add(new AlifbaSymbol("\u00e4", "\u00c4", "\u00e4", "\u00c4"));//Ä
                    _result.Add(new AlifbaSymbol("\u00e2", "\u00c2", "\u00e2", "\u00c2"));//Â
                    _result.Add(new AlifbaSymbol("\u00e1", "\u00c1", "\u00e1", "\u00c1"));//Á
                    _result.Add(new AlifbaSymbol("\u00e7", "\u00c7", "\u00e7", "\u00c7"));//Ç
                    _result.Add(new AlifbaSymbol("\u00e9", "\u00c9", "\u00e9", "\u00c9"));//É
                    _result.Add(new AlifbaSymbol("\u011f", "\u011e", "\u011f", "\u011e"));//Ğ
                    _result.Add(new AlifbaSymbol("\u0131", "\u0130", "\u0131", "\u0130"));//İı
                    _result.Add(new AlifbaSymbol("\u00ed", "\u00cd", "\u00ed", "\u00cd"));//Í
                    _result.Add(new AlifbaSymbol("\u00f1", "\u00d1", "\u00f1", "\u00d1"));//Ñ
                    _result.Add(new AlifbaSymbol("\u00f6", "\u00d6", "\u00f6", "\u00d6"));//Ö
                    _result.Add(new AlifbaSymbol("\u00f3", "\u00d3", "\u00f3", "\u00d3"));//Ó
                    _result.Add(new AlifbaSymbol("\u015f", "\u015e", "\u015f", "\u015e"));//Ş
                    _result.Add(new AlifbaSymbol("\u00fc", "\u00dc", "\u00fc", "\u00dc"));//Ü
                    _result.Add(new AlifbaSymbol("\u00fa", "\u00da", "\u00fa", "\u00da"));//Ú
                    break;
                case BuiltInAlifbaType.Rasmalif:
                    _result.Add(new AlifbaSymbol("\u00e4", "\u00c4", "\u00e4", "\u00c4"));//Ä
                    _result.Add(new AlifbaSymbol("\u00e7", "\u00c7", "\u00e7", "\u00c7"));//Ç
                    _result.Add(new AlifbaSymbol("\u0131", "\u0130", "\u0131", "\u0130"));//İı
                    _result.Add(new AlifbaSymbol("\u00f1", "\u00d1", "\u00f1", "\u00d1"));//Ñ
                    _result.Add(new AlifbaSymbol("\u00f6", "\u00d6", "\u00f6", "\u00d6"));//Ö
                    _result.Add(new AlifbaSymbol("\u015f", "\u015e", "\u015f", "\u015e"));//Ş
                    _result.Add(new AlifbaSymbol("\u00fc", "\u00dc", "\u00fc", "\u00dc"));//Ü
                    break;
                case BuiltInAlifbaType.Yanalif: //config: add all yanalif symbols and let UI decide? 
                    _result.Add(new AlifbaSymbol("\u00ab", DisplayText: "\u00ab"));//«
                    _result.Add(new AlifbaSymbol("\u00bb", DisplayText: "\u00bb"));//»
                    _result.Add(new AlifbaSymbol("\u2014", DisplayText: "\u2014"));//—
                    break;
            }
            return _result;
        }

        #endregion


        #region Directions

        private static List<BuiltInDirection> builtInDirections;

        public static List<BuiltInDirection> BuiltInDirections
        {
            get { return builtInDirections; }
        }

        private static void FillBuiltInDirections()
        {
            builtInDirections = new List<BuiltInDirection>();
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.CyrillicYanalif, BuiltInAlifbaType.Cyrillic, BuiltInAlifbaType.Yanalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.CyrillicZamanalif, BuiltInAlifbaType.Cyrillic, BuiltInAlifbaType.Zamanalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.CyrillicRasmalif, BuiltInAlifbaType.Cyrillic, BuiltInAlifbaType.Rasmalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.YanalifZamanalif, BuiltInAlifbaType.Yanalif, BuiltInAlifbaType.Zamanalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.YanalifRasmalif, BuiltInAlifbaType.Yanalif, BuiltInAlifbaType.Rasmalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.ZamanalifYanalif, BuiltInAlifbaType.Zamanalif, BuiltInAlifbaType.Yanalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.RasmalifYanalif, BuiltInAlifbaType.Rasmalif, BuiltInAlifbaType.Yanalif));
        }

        private static BuiltInDirection CreateBuiltInDirection(BuiltInDirectionType ID, BuiltInAlifbaType Source, BuiltInAlifbaType Target)
        {
            var _source = builtInAlifbaList.Find(_alif => _alif.ID == Source);
            var _target = builtInAlifbaList.Find(_alif => _alif.ID == Target);
            return new Model.BuiltInDirection(ID, _source, _target);
        }

        public static BuiltInDirection GetBuiltInDirection(BuiltInAlifbaType Source, BuiltInAlifbaType Target)
        {
            return builtInDirections.Find(_dir => _dir.Source == Source && _dir.Target == Target);
        }

        internal static BuiltInDirectionType GetBuiltInID(BuiltInAlifbaType Source, BuiltInAlifbaType Target)
        {
            var _builtIn = GetBuiltInDirection(Source, Target);
            if (_builtIn == null)
                return BuiltInDirectionType.None;
            return _builtIn.ID;
        }

        public static TranslitCommand GetTranslitCommand(BuiltInDirectionType BuiltInID)
        {
            TranslitCommand _commandObject = null;
            switch (BuiltInID)
            {
                case BuiltInDirectionType.CyrillicYanalif:
                    _commandObject = new Commands.CyrillicYanalif();
                    break;
                case BuiltInDirectionType.CyrillicZamanalif:
                    _commandObject = new Commands.CyrillicZamanalif();
                    break;
                case BuiltInDirectionType.CyrillicRasmalif:
                    _commandObject = new Commands.CyrillicRasmalif();
                    break;
                case BuiltInDirectionType.YanalifZamanalif:
                    _commandObject = new Commands.YanalifZamanalif();
                    break;
                case BuiltInDirectionType.YanalifRasmalif:
                    _commandObject = new Commands.YanalifRasmalif();
                    break;
                case BuiltInDirectionType.ZamanalifYanalif:
                    _commandObject = new Commands.ZamanalifYanalif();
                    break;
                case BuiltInDirectionType.RasmalifYanalif:
                    _commandObject = new Commands.RasmalifYanalif();
                    break;
            }
            return _commandObject;
        }

        public static BuiltInDirection GetBuiltInDirection(BuiltInDirectionType BuiltInID)
        {
            return builtInDirections.Find(_dir => _dir.ID == BuiltInID);
        }

        #endregion
    }
    
}
