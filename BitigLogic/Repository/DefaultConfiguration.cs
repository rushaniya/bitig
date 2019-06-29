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
            FillBuiltInDirections();
        }

        #region Alphabets

        public const string YANALIF_NAME = "Yanalif";
        private const string CYRILLIC_NAME = "Cyrillic";
        private const string ZAMANALIF_NAME = "Zamanalif";
        private const string RASMALIF_NAME = "Official 2012";//loc

        private static AlphabetFont defaultYanalifFont = new AlphabetFont("DejaVu Sans", 12, FontStyle.Regular);

        public static AlphabetFont DefaultYanalifFont
        {
            get { return defaultYanalifFont; }
        }

       /* private static List<AlphabetSymbol> GetDefaultSymbols(BuiltInAlphabetType AlphabetID)
        {
            List<AlphabetSymbol> _result = new List<AlphabetSymbol>();
            switch (AlphabetID)
            {
                //excl: get alphabet symbols from directions' alphabet patterns?
                case BuiltInAlphabetType.Cyrillic:
                    _result.Add(new AlphabetSymbol("\u04d9", "\u04d8", "\u04d9", "\u04d8"));//Ә
                    _result.Add(new AlphabetSymbol("\u04e9", "\u04e8", "\u04e9", "\u04e8"));//Ө
                    _result.Add(new AlphabetSymbol("\u04af", "\u04ae", "\u04af", "\u04ae"));//Ү
                    _result.Add(new AlphabetSymbol("\u0497", "\u0496", "\u0497", "\u0496"));//Җ
                    _result.Add(new AlphabetSymbol("\u04a3", "\u04a2", "\u04a3", "\u04a2"));//Ң
                    _result.Add(new AlphabetSymbol("\u04bb", "\u04ba", "\u04bb", "\u04ba"));//Һ
                    break;
                case BuiltInAlphabetType.Zamanalif:
                    _result.Add(new AlphabetSymbol("\u00e4", "\u00c4", "\u00e4", "\u00c4"));//Ä
                    _result.Add(new AlphabetSymbol("\u00e2", "\u00c2", "\u00e2", "\u00c2"));//Â
                    _result.Add(new AlphabetSymbol("\u00e1", "\u00c1", "\u00e1", "\u00c1"));//Á
                    _result.Add(new AlphabetSymbol("\u00e7", "\u00c7", "\u00e7", "\u00c7"));//Ç
                    _result.Add(new AlphabetSymbol("\u00e9", "\u00c9", "\u00e9", "\u00c9"));//É
                    _result.Add(new AlphabetSymbol("\u011f", "\u011e", "\u011f", "\u011e"));//Ğ
                    _result.Add(new AlphabetSymbol("\u0131", "\u0130", "\u0131", "\u0130"));//İı
                    _result.Add(new AlphabetSymbol("\u00ed", "\u00cd", "\u00ed", "\u00cd"));//Í
                    _result.Add(new AlphabetSymbol("\u00f1", "\u00d1", "\u00f1", "\u00d1"));//Ñ
                    _result.Add(new AlphabetSymbol("\u00f6", "\u00d6", "\u00f6", "\u00d6"));//Ö
                    _result.Add(new AlphabetSymbol("\u00f3", "\u00d3", "\u00f3", "\u00d3"));//Ó
                    _result.Add(new AlphabetSymbol("\u015f", "\u015e", "\u015f", "\u015e"));//Ş
                    _result.Add(new AlphabetSymbol("\u00fc", "\u00dc", "\u00fc", "\u00dc"));//Ü
                    _result.Add(new AlphabetSymbol("\u00fa", "\u00da", "\u00fa", "\u00da"));//Ú
                    break;
                case BuiltInAlphabetType.Rasmalif:
                    _result.Add(new AlphabetSymbol("\u00e4", "\u00c4", "\u00e4", "\u00c4"));//Ä
                    _result.Add(new AlphabetSymbol("\u00e7", "\u00c7", "\u00e7", "\u00c7"));//Ç
                    _result.Add(new AlphabetSymbol("\u0131", "\u0130", "\u0131", "\u0130"));//İı
                    _result.Add(new AlphabetSymbol("\u00f1", "\u00d1", "\u00f1", "\u00d1"));//Ñ
                    _result.Add(new AlphabetSymbol("\u00f6", "\u00d6", "\u00f6", "\u00d6"));//Ö
                    _result.Add(new AlphabetSymbol("\u015f", "\u015e", "\u015f", "\u015e"));//Ş
                    _result.Add(new AlphabetSymbol("\u00fc", "\u00dc", "\u00fc", "\u00dc"));//Ü
                    break;
                case BuiltInAlphabetType.Yanalif: //config: add all yanalif symbols and let UI decide? 
                    _result.Add(new AlphabetSymbol("\u00ab", DisplayText: "\u00ab"));//«
                    _result.Add(new AlphabetSymbol("\u00bb", DisplayText: "\u00bb"));//»
                    _result.Add(new AlphabetSymbol("\u2014", DisplayText: "\u2014"));//—
                    break;
            }
            return _result;
        }*/

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
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.CyrillicYanalif, BuiltInAlphabetType.Cyrillic, BuiltInAlphabetType.Yanalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.CyrillicZamanalif, BuiltInAlphabetType.Cyrillic, BuiltInAlphabetType.Zamanalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.CyrillicRasmalif, BuiltInAlphabetType.Cyrillic, BuiltInAlphabetType.Rasmalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.YanalifZamanalif, BuiltInAlphabetType.Yanalif, BuiltInAlphabetType.Zamanalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.YanalifRasmalif, BuiltInAlphabetType.Yanalif, BuiltInAlphabetType.Rasmalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.ZamanalifYanalif, BuiltInAlphabetType.Zamanalif, BuiltInAlphabetType.Yanalif));
            builtInDirections.Add(CreateBuiltInDirection(BuiltInDirectionType.RasmalifYanalif, BuiltInAlphabetType.Rasmalif, BuiltInAlphabetType.Yanalif));
        }

        private static BuiltInDirection CreateBuiltInDirection(BuiltInDirectionType Type, BuiltInAlphabetType Source, BuiltInAlphabetType Target)
        {
            return new BuiltInDirection(Type, Source, Target);
        }

        public static BuiltInDirection GetBuiltInDirection(BuiltInAlphabetType Source, BuiltInAlphabetType Target)
        {
            return builtInDirections.Find(_dir => _dir.Source == Source && _dir.Target == Target);
        }

        internal static BuiltInDirectionType GetBuiltInDirectionType(BuiltInAlphabetType Source, BuiltInAlphabetType Target)
        {
            var _builtIn = GetBuiltInDirection(Source, Target);
            if (_builtIn == null)
                return BuiltInDirectionType.None;
            return _builtIn.Type;
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
            return builtInDirections.Find(_dir => _dir.Type == BuiltInID);
        }

        #endregion
    }

}
