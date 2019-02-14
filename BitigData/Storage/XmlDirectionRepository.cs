using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Data.Model;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Storage
{
    public class XmlDirectionRepository : DirectionRepository
    {
        private XmlContext xmlContext;

        public override IDataContext DataContext
        {
            get
            {
                return xmlContext;
            }
        }

        public XmlDirectionRepository(XmlContext XmlContext)
        {
            xmlContext = XmlContext;
        }

        private Direction MapWithReferences(XmlDirection StoredDirection)
        {
            //custom: exclusions from separate file
            ManualCommand _manualCommand = null;
            if (StoredDirection.UseManualCommand)
            {
                var _mapping = xmlContext.Mappings.Get(StoredDirection.ID);
                if (_mapping != null)
                    _manualCommand = new ManualCommand(_mapping.SymbolMapping
                        .ToDictionary(x => x.Key.ToModel(), x => x.Value.ToModel()));
            }
            var _shallowDirection = ShallowMap(StoredDirection);
            return new Direction(StoredDirection.ID, _shallowDirection.Source, _shallowDirection.Target, _shallowDirection.Exclusions,
                _shallowDirection.AssemblyPath, _shallowDirection.TypeName, _shallowDirection.BuiltIn, _manualCommand);
        }

        private Direction ShallowMap(XmlDirection StoredDirection)
        {
            var _source = xmlContext.Alphabets.Get(StoredDirection.SourceAlifbaID);
            var _target = xmlContext.Alphabets.Get(StoredDirection.TargetAlifbaID);
            var _builtIn = DefaultConfiguration.GetBuiltInDirection(StoredDirection.BuiltInID);
            var _exclusions = new List<Exclusion>();
            if (StoredDirection.Exclusions != null)
                StoredDirection.Exclusions.ForEach(_excl => _exclusions.Add(_excl.ToModel()));
            return new Direction(StoredDirection.ID, _source.ToShallowModel(), _target.ToShallowModel(), _exclusions,
                StoredDirection.AssemblyPath, StoredDirection.TypeName, _builtIn, null);

        }

        public override List<Direction> GetList()
        {
            var _xmlList = xmlContext.Directions.GetList();
            return _xmlList.Select(ShallowMap).ToList();
        }

        public override Direction Get(int ID)
        {
            var _xmlItem = xmlContext.Directions.Get(ID);
            return _xmlItem == null ? null : MapWithReferences(_xmlItem);
        }

        public override void Insert(Direction Item)
        {
            var _sameAlphabets = xmlContext.Directions.GetList().Find(x =>
              x.SourceAlifbaID == Item.Source.ID && x.TargetAlifbaID == Item.Target.ID);
            if (_sameAlphabets != null)
                throw new Exception("Direction with same source and target exists.");
            var _xmlItem = new XmlDirection(Item);
            xmlContext.Directions.Insert(_xmlItem);
            Item.ID = _xmlItem.ID;
            if (Item.ManualCommand != null)
            {
                var _mapping = new XmlSymbolMapping(Item.ID, Item.ManualCommand);
                xmlContext.Mappings.InsertOrUpdate(_mapping);
            }
        }

        public override void Delete(int ID)
        {
            xmlContext.Directions.Delete(ID);
            xmlContext.Mappings.Delete(ID);
        }

        public override void Update(Direction Item)
        {
            var _sameAlphabets = xmlContext.Directions.GetList().Find(x =>
              x.ID != Item.ID && x.SourceAlifbaID == Item.Source.ID && x.TargetAlifbaID == Item.Target.ID);
            if (_sameAlphabets != null)
                throw new Exception("Direction with same source and target exists.");
            xmlContext.Directions.Update(new XmlDirection(Item));
            if (Item.ManualCommand != null)
            {
                var _mapping = new XmlSymbolMapping(Item.ID, Item.ManualCommand);
                xmlContext.Mappings.InsertOrUpdate(_mapping);
            }
        }

        public override Direction GetByAlifbaIDs(int SourceID, int TargetID)
        {
            var _direction = xmlContext.Directions.GetList().Find(_item =>
                 _item.SourceAlifbaID == SourceID && _item.TargetAlifbaID == TargetID);
            if (_direction == null)
                return null;
            return MapWithReferences(_direction);
        }

        public override List<Alifba> GetTargets(int SourceID)
        {
            var _targets = xmlContext.Directions.GetList()
                .Where(_item => _item.SourceAlifbaID == SourceID)
                .Select(MapWithReferences)
                .Select(_dir => _dir.Target)
                .ToList();
            return _targets;
        }
    }
}
