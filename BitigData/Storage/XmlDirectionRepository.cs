using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Data.Model;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Storage
{
    public class XmlDirectionRepository : IRepository<Direction, int>
    {
        private readonly string path;

        private List<XmlDirection> xmlList;

        public XmlDirectionRepository(string Path)
        {
            path = Path;
        }

        public RepositoryProvider RepositoryProvider
        {
            get;
            set;
        }

        public List<Direction> GetList()
        {
            if (xmlList == null)
                ReadListFromFile();
            var _result = new List<Direction>();
            foreach (var _xmlDir in xmlList)
            {
                _result.Add(MapToModel(_xmlDir));
            }
            return _result;
        }

        public Direction Get(int ID)
        {
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            var _direction = xmlList.Find(_item => _item.ID == ID);
            if (_direction == null)
                return null;
            return MapToModel(_direction);
        }

        //public override bool IsEmpty()
        //{
        //    if (xmlList == null)
        //    {
        //        ReadListFromFile();
        //    }
        //    return xmlList.Count == 0;
        //}

        public void Insert(Direction Item)
        {
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            xmlList.Add(MapToStorage(Item));
        }

        public void Delete(Direction Item)
        {
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            var _direction = xmlList.Find(_item => _item.ID == Item.ID);
            if (_direction != null)
                xmlList.Remove(_direction);
        }

        public void Update(Direction Item)
        {
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            var _direction = xmlList.Find(_item => _item.ID == Item.ID);
            if (_direction == null)
                throw new InvalidOperationException("Direction does not exist.");
            xmlList.Remove(_direction);
            xmlList.Add(MapToStorage(Item));
        }

        public bool IsFlushable
        {
            get
            {
                return true;
            }
        }

        public void SaveChanges()
        {
            DirectionSerializer.SaveToFile(path, xmlList);
        }

        //public override void InsertBuiltIn(int ID, BuiltInDirection BuiltIn)
        //{
        //    if (xmlList == null)
        //    {
        //        ReadListFromFile();
        //    }
        //    xmlList.Add(new XmlDirection
        //        (
        //            ID,
        //            BuiltIn.SourceAlifbaID,
        //            BuiltIn.TargetAlifbaID,
        //            BuiltInID: BuiltIn.ID,
        //            Exclusions: null
        //        ));
        //}

       /* public override Direction GetByAlifbaIDs(int SourceID, int TargetID)
        {
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            var _direction = xmlList.Find(_item =>
                _item.SourceAlifbaID == SourceID && _item.TargetAlifbaID == TargetID);
            if (_direction == null)
                return null;
            return MapToModel(_direction);
        }

        public override List<Alifba> GetTargets(int SourceID)
        {
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            var _targets = xmlList.Where(_item =>
                _item.SourceAlifbaID == SourceID).ToList();
            var _result = new List<Alifba>();
            _targets.ForEach(_target => _result.Add(_target));
            return _result;
        }*/

        private Direction MapToModel(XmlDirection StoredDirection)
        {
            if (RepositoryProvider == null)
                throw new Exception("RepositoryProvider is null. Cannot access AlifbaRepository.");
            var _source = RepositoryProvider.AlifbaRepository.Get(StoredDirection.SourceAlifbaID);
            var _target = RepositoryProvider.AlifbaRepository.Get(StoredDirection.TargetAlifbaID);
            var _builtIn = DefaultConfiguration.GetBuiltInDirection(StoredDirection.BuiltInID);
            var _exclusions = new List<Exclusion>();
            if (StoredDirection.Exclusions != null)
                StoredDirection.Exclusions.ForEach(_excl => _exclusions.Add(MapToModel(_excl)));
            return new Direction(StoredDirection.ID, _source, _target, _exclusions,
                StoredDirection.AssemblyPath, StoredDirection.TypeName, _builtIn);
        }

        private Exclusion MapToModel(XmlExclusion StoredExclusion)
        {
            return new Exclusion
            {
                AnyPosition = StoredExclusion.AnyPosition,
                MatchBeginning = StoredExclusion.MatchBeginning,
                MatchCase = StoredExclusion.MatchCase,
                SourceWord = StoredExclusion.SourceWord,
                TargetWord = StoredExclusion.TargetWord
            };
        }

        private void ReadListFromFile()
        {
            xmlList = DirectionSerializer.ReadFromFile(path);
            if (xmlList == null)
                xmlList = new List<XmlDirection>();
        }

        private XmlDirection MapToStorage(Direction ModelDirection)
        {
            if (ModelDirection.Source == null)
                throw new InvalidOperationException("Source alphabet is required.");//loc
            if (ModelDirection.Target == null)
                throw new InvalidOperationException("Target alphabet is required.");//loc

            var _builtInID = ModelDirection.BuiltIn == null ? -1 : //repo: default id? (depends on repo implementation)
                ModelDirection.BuiltIn.ID;

            var _exclusions = new List<XmlExclusion>();
            if (ModelDirection.Exclusions != null)
                ModelDirection.Exclusions.ForEach(_excl => _exclusions.Add(MapToStorage(_excl, ModelDirection.ID)));

            return new XmlDirection
            (
                ModelDirection.ID,
                ModelDirection.Source.ID,
                ModelDirection.Target.ID,
                AssemblyPath: ModelDirection.AssemblyPath,
                TypeName: ModelDirection.TypeName,
                BuiltInID: _builtInID,
                Exclusions: _exclusions
            );
        }

        private XmlExclusion MapToStorage(Exclusion ModelExclusion, int DirectionID)
        {
            return new XmlExclusion
            {
                AnyPosition = ModelExclusion.AnyPosition,
                MatchBeginning = ModelExclusion.MatchBeginning,
                MatchCase = ModelExclusion.MatchCase,
                SourceWord = ModelExclusion.SourceWord,
                TargetWord = ModelExclusion.TargetWord,
                DirectionID = DirectionID
            };
        }

        public int GenerateID(IEnumerable<int> ExistingIDs)
        {
            int _result = -1;
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (ExistingIDs.All(_id => _id != i))
                {
                    _result = i;
                    break;
                }
            }
            return _result;
        }

        //public override bool IsInUse(Alifba Alifba)
        //{
        //    if (xmlList == null)
        //    {
        //        ReadListFromFile();
        //    }
        //    var _direction = xmlList.Find(_item =>
        //        _item.SourceAlifbaID == Alifba.ID || _item.TargetAlifbaID == Alifba.ID);
        //    return _direction != null;
        //}
    }
}
