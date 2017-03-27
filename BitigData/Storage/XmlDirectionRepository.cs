using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bitig.Data.Model;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Storage
{
    public class XmlDirectionRepository : DirectionRepository
    {
        private readonly string path;

        private List<XmlDirection> xmlList;
        private AlifbaRepository alifbaRepo;

        public XmlDirectionRepository(string Path, AlifbaRepository AlifbaRepo)
        {
            path = Path;
            alifbaRepo = AlifbaRepo;
        }

        public override bool IsFlushable
        {
            get
            {
                return true;
            }
        }

        public override void Delete(Direction Item)
        {
            throw new NotImplementedException();
        }

        public override int GenerateID(IEnumerable<int> ExsitingIDs)
        {
            int _result = -1;
            for (int i = 0; i < int.MaxValue; i++)
            {
                if (ExsitingIDs.All(_id => _id != i))
                {
                    _result = i;
                    break;
                }
            }
            return _result;
        }

        public override Direction Get(int ID)
        {
            //if (xmlList == null)
            //{
            //    ReadListFromFile();
            //}
            //if (xmlList == null || xmlList.Count == 0)
            //{
            //    CreateDefaultConfiguration();
            //}
            //var _direction = xmlList.Find(_item => _item.ID == ID);
            //if (_direction == null)
            //    return null;
            //return MapToModel(_direction);
            return GetOrCreate(ID, true);
        }

        private Direction GetOrCreate(int ID, bool AllowCreate)
        {
            if (xmlList == null)
            {
                ReadListFromFile();
            }
            if ((xmlList == null || xmlList.Count == 0) && AllowCreate)
            {
                CreateDefaultConfiguration();
            }
            var _direction = xmlList.Find(_item => _item.ID == ID);
            if (_direction == null)
                return null;
            return MapToModel(_direction);
        }

        public override Direction GetByAlifbaIDs(int SourceID, int TargetID)
        {
            throw new NotImplementedException();
        }

        public override List<Direction> GetList()
        {
            var _list = GetListNoCreate();
            if (_list == null || _list.Count == 0)
            {
                CreateDefaultConfiguration();
                _list = GetListNoCreate();
            }
            return _list;
        }

        protected override List<Direction> GetListNoCreate()
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

        public List<Direction> GetListNoCreateDefaults()
        {
            return GetListNoCreate();
        }

        private Direction MapToModel(XmlDirection StoredDirection)
        {
            var _source = alifbaRepo.Get(StoredDirection.SourceAlifbaID);
            var _target = alifbaRepo.Get(StoredDirection.TargetAlifbaID);
            var _builtIn = DefaultConfiguration.GetBuiltInDirection(StoredDirection.BuiltInID);
            return new Direction(StoredDirection.ID, _source, _target,
                StoredDirection.AssemblyPath, StoredDirection.TypeName, _builtIn);
        }

        private void ReadListFromFile()
        {
            xmlList = DirectionSerializer.ReadFromFile(path);
            if (xmlList == null)
                xmlList = new List<XmlDirection>();
        }

        protected override void CreateDefaultConfiguration() 
        {
            xmlList = new List<XmlDirection>();
            int _count = DefaultConfiguration.BuiltInDirections.Count;
            for (int i = 0; i < _count; i++)
            {
                xmlList.Add(new XmlDirection
                (
                    i,
                    DefaultConfiguration.BuiltInDirections[i].SourceAlifbaID,
                    DefaultConfiguration.BuiltInDirections[i].TargetAlifbaID,
                    BuiltInID: DefaultConfiguration.BuiltInDirections[i].ID
                ));
            }
            SaveChanges();
        }

        public override List<Alifba> GetTargets(int SourceID)
        {
            throw new NotImplementedException();
        }

        public override void Insert(Direction Item)
        {
            if (Item == null)
                throw new ArgumentNullException("Item");
            Item.ID = GenerateDirectionID();
            if (GetOrCreate(Item.ID, false) != null)
                throw new Exception("Same ID exists.");
            xmlList.Add(MapToStorage(Item));
        }

        private int GenerateDirectionID()
        {
            if (xmlList == null)
                ReadListFromFile();
            var _existingIDs = xmlList.Select(_dir => _dir.ID);
            return GenerateID(_existingIDs);
        }

        private XmlDirection MapToStorage(Direction ModelDirection)
        {
            if (ModelDirection.Source == null)
                throw new InvalidOperationException("Source alphabet is required.");//loc
            if (ModelDirection.Target == null)
                throw new InvalidOperationException("Target alphabet is required.");//loc

            var _builtInID = ModelDirection.BuiltIn == null ? -1 : //repo: default id? (depends on repo implementation)
                ModelDirection.BuiltIn.ID;

            return new XmlDirection
            (
                ModelDirection.ID,
                ModelDirection.Source.ID,
                ModelDirection.Target.ID,
                AssemblyPath: ModelDirection.AssemblyPath,
                TypeName: ModelDirection.TypeName,
                BuiltInID: _builtInID
            );
        }

        public override void SaveChanges()
        {
            DirectionSerializer.SaveToFile(path, xmlList);
        }

        public override void Update(Direction Item)
        {
            throw new NotImplementedException();
        }

        public override bool IsInUse(int AlifbaID)
        {
            throw new NotImplementedException();
        }
    }
}
