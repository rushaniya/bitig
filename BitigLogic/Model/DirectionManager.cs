using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Bitig.Base;
using System.Collections.Specialized;

namespace Bitig.Logic.Model
{
    public static class DirectionManager
    {
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
            get { return DirectionManager.builtInDirections; }
        }

        public static List<Direction> DirectionsList
        {
            get
            {
                if (directionsList == null) FillDirectionsList();
                return directionsList;
            }
        }

        static DirectionManager()
        {
            FillBuiltInDirections();
        }

        //public static string Test()
        //{
        //    return (new Commands.CyrillicYanalif()).GetType().ToString();
        //}

        public static Direction GetDirectionByAlifbaID(int SourceID, int TargetID)
        {
            if (directionsList == null) FillDirectionsList();
            var _query = from _dir in directionsList
                         where _dir.SourceAlifbaID == SourceID && _dir.TargetAlifbaID == TargetID
                         select _dir;
            if (_query.Count() > 0)
                return _query.First();
            return null;
        }

        public static Direction GetDirectionByID(int DirID)
        {
            if (directionsList == null) FillDirectionsList();
            var _query = from _dir in directionsList
                         where _dir.ID == DirID
                         select _dir;
            if (_query.Count() > 0)
                return _query.First();
            return null;
        }

        //repo
        private static void FillDirectionsList()
        {
            throw new NotImplementedException();
            //directionsList = DirectionSerializer.ReadFromFile();
            ////config:builtIn.IsInUse needed?
            //foreach (Direction _dir in directionsList)
            //{
            //    BuiltInDirection _builtIn = builtInDirections.Find(_item =>
            //        _item.ID == _dir.BuiltInID && _item.SourceAlifbaID == _dir.SourceAlifbaID && _item.TargetAlifbaID == _dir.TargetAlifbaID);
            //    if (_builtIn != null) _builtIn.IsInUse = true;

            //}
        }

        internal static TranslitCommand GetTranslitCommand(int BuiltInDirectionNo)
        {
            TranslitCommand _commandObject = null;
            switch (BuiltInDirectionNo)
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

        internal static int GenerateNewDirectionID()
        {
            int _result = -1;
            if (directionsList == null) FillDirectionsList();
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (!directionsList.Exists(_dir => _dir.ID == i))
                {
                    _result = i;
                    break;
                }
            }
            return _result;
        }

        //repo
        private static void FillBuiltInDirections()
        {
            throw new NotImplementedException();
            //builtInDirections = new List<BuiltInDirection>();
            //builtInDirections.Add(new BuiltInDirection(CYRILLIC_YANALIF, AlifbaManager.CYRILLIC, AlifbaManager.YANALIF));
            //builtInDirections.Add(new BuiltInDirection(CYRILLIC_ZAMANALIF, AlifbaManager.CYRILLIC, AlifbaManager.ZAMANALIF));
            //builtInDirections.Add(new BuiltInDirection(CYRILLIC_RASMALIF, AlifbaManager.CYRILLIC, AlifbaManager.RASMALIF));
            //builtInDirections.Add(new BuiltInDirection(YANALIF_ZAMANALIF, AlifbaManager.YANALIF, AlifbaManager.ZAMANALIF));
            //builtInDirections.Add(new BuiltInDirection(YANALIF_RASMALIF, AlifbaManager.YANALIF, AlifbaManager.RASMALIF));
            //builtInDirections.Add(new BuiltInDirection(ZAMANALIF_YANALIF, AlifbaManager.ZAMANALIF, AlifbaManager.YANALIF));
            //builtInDirections.Add(new BuiltInDirection(RASMALIF_YANALIF, AlifbaManager.RASMALIF, AlifbaManager.YANALIF));
        }

        //kbl:make internal, expose public methods only in DataManager?
        public static BuiltInDirection GetBuiltInDirection(int SourceID, int TargetID)
        {
            return builtInDirections.Find(_dir => _dir.SourceAlifbaID == SourceID && _dir.TargetAlifbaID == TargetID);
        }

        internal static int GetBuiltInID(int SourceID, int TargetID)
        {
            BuiltInDirection _builtIn = builtInDirections.Find(_dir => _dir.SourceAlifbaID == SourceID && _dir.TargetAlifbaID == TargetID);
            if (_builtIn == null) return -1;
            return _builtIn.ID;
        }

        internal static int GetBuiltInSourceID(int BuiltInDirectionNumber)
        {
            BuiltInDirection _builtIn = builtInDirections.Find(_dir => _dir.ID == BuiltInDirectionNumber);
            if (_builtIn != null) return _builtIn.SourceAlifbaID;
            return -1;
        }

        internal static int GetBuiltInTargetID(int BuiltInDirectionNumber)
        {
            BuiltInDirection _builtIn = builtInDirections.Find(_dir => _dir.ID == BuiltInDirectionNumber);
            if (_builtIn != null) return _builtIn.TargetAlifbaID;
            return -1;
        }
    }
}
