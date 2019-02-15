using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bitig.Data.Model;
using Bitig.Data.Serialization;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Storage
{
    public class XmlContext : IDataContext
    {
        private InMemoryList<XmlAlifba> alifbaCache;
        private InMemoryList<XmlDirection> directionCache;
        private InMemoryList<XmlSymbolMapping> mappingsCache;
        private InMemoryList<XmlSymbolCollection> customSymbolsCache;
        private InMemoryList<XmlExclusionCollection> exclusionsCache;

        private XmlAlifbaReader xmlAlifbaReader;
        private XmlDirectionReader xmlDirectionReader;
        private XmlSymbolMappingReader xmlSymbolMappingReader;
        private XmlSymbolCollectionReader xmlSymbolCollectionReader;
        private XmlExclusionCollectionReader xmlExclusionReader;

        private XmlAlifbaRepository alifbaRepository;
        private XmlDirectionRepository directionRepository;

        public bool IsFlushable { get { return true; } }

        internal InMemoryList<XmlAlifba> Alphabets
        {
            get
            {
                if (alifbaCache == null)
                    InitAlifbaCache();
                return alifbaCache;
            }
        }


        internal InMemoryList<XmlDirection> Directions
        {
            get
            {
                if (directionCache == null)
                    InitDirectionCache();
                return directionCache;
            }
        }

        internal InMemoryList<XmlSymbolMapping> Mappings
        {
            get
            {
                if (mappingsCache == null)
                    InitMappingsCache();
                return mappingsCache;
            }
        }

        internal InMemoryList<XmlSymbolCollection> CustomSymbols
        {
            get
            {
                if (customSymbolsCache == null)
                    InitCustomSymbolsCache();
                return customSymbolsCache;
            }
        }

        internal InMemoryList<XmlExclusionCollection> Exclusions
        {
            get
            {
                if (exclusionsCache == null)
                    InitExclusionsCache();
                return exclusionsCache;
            }
        }

        public AlifbaRepository AlifbaRepository
        {
            get
            {
                return alifbaRepository;
            }
        }

        public DirectionRepository DirectionRepository
        {
            get
            {
                return directionRepository;
            }
        }

        public XmlContext(string DirectoryPath) 
            :this(Path.Combine(DirectoryPath, "Alphabets.xml"), Path.Combine(DirectoryPath, "Directions.xml"))
        {
        }

        public XmlContext(string AlphabetsPath, string DirectionsPath)
        {
            xmlAlifbaReader = new XmlAlifbaReader(AlphabetsPath);
            alifbaRepository = new XmlAlifbaRepository(this);
            xmlDirectionReader = new XmlDirectionReader(DirectionsPath);
            directionRepository = new XmlDirectionRepository(this);
            var _alphabetsDirectory = Path.GetDirectoryName(AlphabetsPath) ?? string.Empty;
            xmlSymbolCollectionReader = new XmlSymbolCollectionReader(Path.Combine(_alphabetsDirectory, "Symbols"));
            var _directionsDirectory = Path.GetDirectoryName(DirectionsPath) ?? string.Empty;
            xmlSymbolMappingReader = new XmlSymbolMappingReader(Path.Combine(_directionsDirectory, "Mappings"));
            xmlExclusionReader = new XmlExclusionCollectionReader(Path.Combine(_directionsDirectory, "Exclusions"));
        }

        private void InitAlifbaCache()
        {
            var _xmlList = xmlAlifbaReader.Read();
            if (_xmlList == null)
            {
                _xmlList = new List<XmlAlifba>();
                var _symbolLists = new List<XmlSymbolCollection>();
                var _IDs = new List<int>();
                foreach (var _builtIn in DefaultConfiguration.BuiltInAlifbaList)
                {
                    var _id = IDGenerator.GenerateID(_IDs);
                    _IDs.Add(_id);
                    var _alifba = new Alifba(_id, _builtIn.DefaultName,null,
                        _builtIn.RightToLeft, _builtIn.DefaultFont, _builtIn.ID);
                    _xmlList.Add(new XmlAlifba(_alifba));
                    if (_builtIn.CustomSymbols != null)
                        _symbolLists.Add(new XmlSymbolCollection(_id, _builtIn.CustomSymbols));
                }
                xmlAlifbaReader.Save(_xmlList);
                xmlSymbolCollectionReader.Save(_symbolLists);
            }
            else
            {
                if (!_xmlList.Any(_alif => _alif.BuiltIn == BuiltInAlifbaType.Yanalif))
                {
                    var _id = IDGenerator.GenerateID(_xmlList.Select(_item => _item.ID));
                    var _yanalif = new Alifba(_id, DefaultConfiguration.Yanalif.DefaultName, null,
                    DefaultConfiguration.Yanalif.RightToLeft, DefaultConfiguration.Yanalif.DefaultFont, DefaultConfiguration.Yanalif.ID);
                    _xmlList.Add(new XmlAlifba(_yanalif));
                    xmlAlifbaReader.Save(_xmlList);
                    xmlSymbolCollectionReader.Save(new List<XmlSymbolCollection> { new XmlSymbolCollection(_id, DefaultConfiguration.Yanalif.CustomSymbols) });
                }
            }
            alifbaCache = new InMemoryList<XmlAlifba>(_xmlList);
            alifbaCache.IDChanged += OnAlifbaIDChanged;
        }

        private void OnAlifbaIDChanged(int OldID, int NewID)
        {
            if (directionCache != null)
            {
                var _asSource = directionCache.GetList().Where(x => x.SourceAlifbaID == OldID);
                foreach (var _direction in _asSource)
                {
                    _direction.SourceAlifbaID = NewID;
                    directionCache.Update(_direction);
                }
                var _asTarget = directionCache.GetList().Where(x => x.TargetAlifbaID == OldID);
                foreach (var _direction in _asTarget)
                {
                    _direction.TargetAlifbaID = NewID;
                    directionCache.Update(_direction);
                }
            }
            if (customSymbolsCache != null)
            {
                customSymbolsCache.ChangeID(OldID, NewID);
            }
        }
        
        private void InitDirectionCache()
        {
            if (alifbaCache == null)
                InitAlifbaCache();
            var _xmlList = xmlDirectionReader.Read();
            if (_xmlList == null)
            {
                _xmlList = new List<XmlDirection>();
                int _count = DefaultConfiguration.BuiltInDirections.Count;
                for (int i = 0; i < _count; i++)
                {
                    var _builtIn = DefaultConfiguration.BuiltInDirections[i];
                    var _alifbaList = alifbaCache.GetList();
                    var _source = _alifbaList.Find(x => x.BuiltIn == _builtIn.Source);
                    var _target = _alifbaList.Find(x => x.BuiltIn == _builtIn.Target);
                    if (_source != null && _target != null)
                    {
                        var _direction = new XmlDirection(i, _source.ID, _target.ID, null, BuiltInID: _builtIn.ID);
                        _xmlList.Add(_direction);
                    }
                }
                xmlDirectionReader.Save(_xmlList);
            }
            directionCache = new InMemoryList<XmlDirection>(_xmlList);
            directionCache.IDChanged += OnDirectionIDChanged;
        }

        private void OnDirectionIDChanged(int OldID, int NewID)
        {
            if (mappingsCache != null)
            {
                mappingsCache.ChangeID(OldID, NewID);
            }
            if (exclusionsCache != null)
            {
                exclusionsCache.ChangeID(OldID, NewID);
            }
        }

        private void InitMappingsCache()
        {
            var _xmlList = xmlSymbolMappingReader.Read();
            mappingsCache = new InMemoryList<XmlSymbolMapping>(_xmlList);
        }

        private void InitCustomSymbolsCache()
        {
            var _xmlList = xmlSymbolCollectionReader.Read();
            customSymbolsCache = new InMemoryList<XmlSymbolCollection>(_xmlList);
        }

        private void InitExclusionsCache()
        {
            var _xmlList = xmlExclusionReader.Read();
            exclusionsCache = new InMemoryList<XmlExclusionCollection>(_xmlList);
        }

        public void CancelChanges()
        {
            alifbaCache = null;
            directionCache = null;
        }

        public void SaveChanges()
        {
            if (alifbaCache != null)
                xmlAlifbaReader.Save(alifbaCache);
            if (directionCache != null)
                xmlDirectionReader.Save(directionCache);
            if (mappingsCache != null)
                xmlSymbolMappingReader.Save(mappingsCache);
            if (customSymbolsCache != null)
                xmlSymbolCollectionReader.Save(customSymbolsCache);
            if (exclusionsCache != null)
                xmlExclusionReader.Save(exclusionsCache);
        }
    }
}
