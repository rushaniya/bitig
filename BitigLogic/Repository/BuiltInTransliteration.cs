using System.Collections.Generic;
using Bitig.Base;
using Bitig.Logic.Model;

namespace Bitig.Logic.Repository
{
    public static class BuiltInTransliteration
    {
        static BuiltInTransliteration()
        {
            FillBuiltInDirections();
        }

        #region Alphabets

        private const string YANALIF_NAME = "Yanalif";
        private const string CYRILLIC_NAME = "Cyrillic";
        private const string ZAMANALIF_NAME = "Zamanalif";
        private const string RASMALIF_NAME = "Official 2012";//loc

        public static string GetBuiltInAlphabetName(BuiltInAlphabetType AlphabetType)
        {
            switch (AlphabetType)
            {
                case BuiltInAlphabetType.Cyrillic:
                    return CYRILLIC_NAME;
                case BuiltInAlphabetType.Rasmalif:
                    return RASMALIF_NAME;
                case BuiltInAlphabetType.Yanalif:
                    return YANALIF_NAME;
                case BuiltInAlphabetType.Zamanalif:
                    return ZAMANALIF_NAME;
                default:
                    return "None"; //loc
            }
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
            builtInDirections.Add(new BuiltInDirection(BuiltInDirectionType.CyrillicYanalif, BuiltInAlphabetType.Cyrillic, BuiltInAlphabetType.Yanalif));
            builtInDirections.Add(new BuiltInDirection(BuiltInDirectionType.CyrillicZamanalif, BuiltInAlphabetType.Cyrillic, BuiltInAlphabetType.Zamanalif));
            builtInDirections.Add(new BuiltInDirection(BuiltInDirectionType.CyrillicRasmalif, BuiltInAlphabetType.Cyrillic, BuiltInAlphabetType.Rasmalif));
            builtInDirections.Add(new BuiltInDirection(BuiltInDirectionType.YanalifZamanalif, BuiltInAlphabetType.Yanalif, BuiltInAlphabetType.Zamanalif));
            builtInDirections.Add(new BuiltInDirection(BuiltInDirectionType.YanalifRasmalif, BuiltInAlphabetType.Yanalif, BuiltInAlphabetType.Rasmalif));
            builtInDirections.Add(new BuiltInDirection(BuiltInDirectionType.ZamanalifYanalif, BuiltInAlphabetType.Zamanalif, BuiltInAlphabetType.Yanalif));
            builtInDirections.Add(new BuiltInDirection(BuiltInDirectionType.RasmalifYanalif, BuiltInAlphabetType.Rasmalif, BuiltInAlphabetType.Yanalif));
        }

        public static BuiltInDirection GetBuiltInDirection(BuiltInAlphabetType Source, BuiltInAlphabetType Target)
        {
            return builtInDirections.Find(_dir => _dir.Source == Source && _dir.Target == Target);
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
