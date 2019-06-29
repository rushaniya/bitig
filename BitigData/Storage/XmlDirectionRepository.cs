using System;
using System.Collections.Generic;
using System.Linq;
using Bitig.Data.Model;
using Bitig.Data.Serialization;
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
            ManualCommand _manualCommand = null;
            if (StoredDirection.UseManualCommand)
            {
                var _mapping = xmlContext.Mappings.Get(StoredDirection.ID);
                if (_mapping != null)
                    _manualCommand = new ManualCommand(_mapping.Dictionary
                        .ToDictionary(x => x.Key.ToModel(), x => x.Value.ToModel()));
            }
            var _xmlExclusionList = xmlContext.Exclusions.Get(StoredDirection.ID);
            var _exclusions = _xmlExclusionList == null
                ? null
                : _xmlExclusionList.Collection.Select(x => x.ToModel()).ToList();
            var _shallowDirection = ShallowMap(StoredDirection);
            return new Direction(StoredDirection.ID, _shallowDirection.Source, _shallowDirection.Target, _exclusions,
                _shallowDirection.AssemblyPath, _shallowDirection.TypeName, _shallowDirection.BuiltInType, _manualCommand);
        }

        private Direction ShallowMap(XmlDirection StoredDirection)
        {
            var _source = xmlContext.Alphabets.Get(StoredDirection.SourceAlphabetID);
            var _target = xmlContext.Alphabets.Get(StoredDirection.TargetAlphabetID);
            var _exclusions = new List<Exclusion>();
            return new Direction(StoredDirection.ID, _source.ToSummary(), _target.ToSummary(), _exclusions,
                StoredDirection.AssemblyPath, StoredDirection.TypeName, StoredDirection.BuiltInType, null);

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
              x.SourceAlphabetID == Item.Source.ID && x.TargetAlphabetID == Item.Target.ID);
            if (_sameAlphabets != null)
                throw new Exception("Direction with same source and target exists.");
            var _xmlItem = new XmlDirection(Item);
            xmlContext.Directions.Insert(_xmlItem);
            Item.ID = _xmlItem.ID;
            if (Item.ManualCommand != null && Item.ManualCommand.SymbolMapping != null)
            {
                var _mapping = new XmlDictionary<XmlTextSymbol, XmlTextSymbol>(
                Item.ManualCommand.SymbolMapping
                        .ToDictionary(x => new XmlTextSymbol(x.Key), x => new XmlTextSymbol(x.Value)));
                xmlContext.Mappings.InsertOrUpdate(new XmlDictionaryConfig<XmlTextSymbol, XmlTextSymbol> { ID = _xmlItem.ID, Dictionary = _mapping });
            }
            if (Item.Exclusions != null && Item.Exclusions.Count > 0)
            {
                var _exclusionList = new XmlCollectionConfig<XmlExclusion> { ID = Item.ID, Collection = Item.Exclusions.Select(x=>new XmlExclusion(x)).ToList() };
                xmlContext.Exclusions.InsertOrUpdate(_exclusionList);
            }
        }

        public override void Delete(int ID)
        {
            xmlContext.Directions.Delete(ID);
            xmlContext.Mappings.Delete(ID);
            xmlContext.Exclusions.Delete(ID);
        }

        public override void Update(Direction Item)
        {
            var _sameAlphabets = xmlContext.Directions.GetList().Find(x =>
              x.ID != Item.ID && x.SourceAlphabetID == Item.Source.ID && x.TargetAlphabetID == Item.Target.ID);
            if (_sameAlphabets != null)
                throw new Exception("Direction with same source and target exists.");
            xmlContext.Directions.Update(new XmlDirection(Item));
            if (Item.ManualCommand != null && Item.ManualCommand.SymbolMapping != null)
            {
                var _mapping = new XmlDictionary<XmlTextSymbol, XmlTextSymbol>(
                Item.ManualCommand.SymbolMapping
                        .ToDictionary(x => new XmlTextSymbol(x.Key), x => new XmlTextSymbol(x.Value)));
                xmlContext.Mappings.InsertOrUpdate(new XmlDictionaryConfig<XmlTextSymbol, XmlTextSymbol> { Dictionary = _mapping, ID = Item.ID });
            }
            if (Item.Exclusions != null && Item.Exclusions.Count > 0)
            {
                var _exclusionList = new XmlCollectionConfig<XmlExclusion> { ID = Item.ID, Collection = Item.Exclusions.Select(x => new XmlExclusion(x)).ToList() };
                xmlContext.Exclusions.InsertOrUpdate(_exclusionList);
            }
        }

        public override Direction GetByAlphabetIDs(int SourceID, int TargetID)
        {
            var _direction = xmlContext.Directions.GetList().Find(_item =>
                 _item.SourceAlphabetID == SourceID && _item.TargetAlphabetID == TargetID);
            if (_direction == null)
                return null;
            return MapWithReferences(_direction);
        }

        public override List<AlphabetSummary> GetTargets(int SourceID)
        {
            var _targets = xmlContext.Directions.GetList()
                .Where(_item => _item.SourceAlphabetID == SourceID)
                .Select(MapWithReferences)
                .Select(_dir => _dir.Target)
                .ToList();
            return _targets;
        }

        public override Dictionary<TextSymbol, TextSymbol> GetSymbolMapping(int ID)
        {
            var _mapping = xmlContext.Mappings.Get(ID);
            if (_mapping != null)
            {
                return _mapping.Dictionary
                     .ToDictionary(x => x.Key.ToModel(), x => x.Value.ToModel());
            }
            return null;
        }
    }
}
