﻿using System;
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
            var _source = xmlContext.Alphabets.Get(StoredDirection.SourceAlifbaID);
            var _target = xmlContext.Alphabets.Get(StoredDirection.TargetAlifbaID);
            var _builtIn = DefaultConfiguration.GetBuiltInDirection(StoredDirection.BuiltInID);
            var _exclusions = new List<Exclusion>();
            if (StoredDirection.Exclusions != null)
                StoredDirection.Exclusions.ForEach(_excl => _exclusions.Add(_excl.ToModel()));
            ManualCommand _manualCommand = null;
            if (StoredDirection.ManualCommand != null && StoredDirection.ManualCommand.SymbolMapping != null)
            {
                _manualCommand = new ManualCommand(StoredDirection.ManualCommand.SymbolMapping
                    .ToDictionary(x => x.Key.ToModel(), x => x.Value.ToModel()));
            }
            return new Direction(StoredDirection.ID, _source.ToModel(), _target.ToModel(), _exclusions,
                StoredDirection.AssemblyPath, StoredDirection.TypeName, _builtIn, _manualCommand);
        }

        public override List<Direction> GetList()
        {
            var _xmlList = xmlContext.Directions.GetList();
            return _xmlList.Select(MapWithReferences).ToList();
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
        }

        public override void Delete(int ID)
        {
            xmlContext.Directions.Delete(ID);
        }

        public override void Update(Direction Item)
        {
            var _sameAlphabets = xmlContext.Directions.GetList().Find(x =>
              x.ID != Item.ID && x.SourceAlifbaID == Item.Source.ID && x.TargetAlifbaID == Item.Target.ID);
            if (_sameAlphabets != null)
                throw new Exception("Direction with same source and target exists.");
            xmlContext.Directions.Update(new XmlDirection(Item));
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
