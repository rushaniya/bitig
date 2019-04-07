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
        private InMemoryList<XmlDictionaryConfig<XmlTextSymbol, XmlTextSymbol>> mappingsCache;
        private InMemoryList<XmlCollectionConfig<XmlAlifbaSymbol>> customSymbolsCache;
        private InMemoryList<XmlCollectionConfig<XmlExclusion>> exclusionsCache;
        private InMemoryList<XmlCollectionConfig<XmlKeyCombination>> keyboardsCache;
        private InMemoryList<XmlMagicKeyboard> magicKeyboardsCache;
        private InMemoryList<XmlKeyboardSummary> keyboardSummariesCache;

        private XmlModelReader<XmlAlifba> xmlAlifbaReader;
        private XmlModelReader<XmlDirection> xmlDirectionReader;
        private XmlModelDictionaryReader<XmlTextSymbol, XmlTextSymbol> xmlSymbolMappingReader;
        private XmlModelCollectionReader<XmlAlifbaSymbol> xmlSymbolCollectionReader;
        private XmlModelCollectionReader<XmlExclusion> xmlExclusionReader;
        private XmlModelReader<XmlKeyboardSummary> xmlKeyboardSummaryReader;
        private XmlModelCollectionReader<XmlKeyCombination> xmlKeyboardReader;
        private XmlCustomCollectionReader<XmlMagicKeyboard> xmlMagicKeyboardReader;

        private XmlAlifbaRepository alifbaRepository;
        private XmlDirectionRepository directionRepository;
        private XmlKeyboardRepository keyboardRepository;

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

        internal InMemoryList<XmlDictionaryConfig<XmlTextSymbol, XmlTextSymbol>> Mappings
        {
            get
            {
                if (mappingsCache == null)
                    InitMappingsCache();
                return mappingsCache;
            }
        }

        internal InMemoryList<XmlCollectionConfig<XmlAlifbaSymbol>> CustomSymbols
        {
            get
            {
                if (customSymbolsCache == null)
                    InitCustomSymbolsCache();
                return customSymbolsCache;
            }
        }

        internal InMemoryList<XmlCollectionConfig<XmlExclusion>> Exclusions
        {
            get
            {
                if (exclusionsCache == null)
                    InitExclusionsCache();
                return exclusionsCache;
            }
        }

        internal InMemoryList<XmlCollectionConfig<XmlKeyCombination>> Keyboards
        {
            get
            {
                if (keyboardsCache == null)
                {
                    keyboardsCache = new InMemoryList<XmlCollectionConfig<XmlKeyCombination>>();
                    keyboardsCache.NotFound += xmlKeyboardReader.Read;
                }
                return keyboardsCache;
            }
        }

        internal InMemoryList<XmlMagicKeyboard> MagicKeyboards
        {
            get
            {
                if (magicKeyboardsCache == null)
                {
                    magicKeyboardsCache = new InMemoryList<XmlMagicKeyboard>();
                    magicKeyboardsCache.NotFound += xmlMagicKeyboardReader.Read;
                }
                return magicKeyboardsCache;
            }
        }

        internal InMemoryList<XmlKeyboardSummary> KeyboardSummaries
        {
            get
            {
                if (keyboardSummariesCache == null)
                {
                    var _xmlList = xmlKeyboardSummaryReader.Read();
                    keyboardSummariesCache = new InMemoryList<XmlKeyboardSummary>(_xmlList);
                }
                return keyboardSummariesCache;
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

        public KeyboardRepository KeyboardRepository
        {
            get { return keyboardRepository; }
        }

        public XmlContext(string DirectoryPath) 
            :this(Path.Combine(DirectoryPath, "Alphabets.xml"), Path.Combine(DirectoryPath, "Directions.xml"))
        {
        }

        public XmlContext(string AlphabetsPath, string DirectionsPath)
        {
            xmlAlifbaReader = new XmlModelReader<XmlAlifba>(AlphabetsPath);
            alifbaRepository = new XmlAlifbaRepository(this);
            xmlDirectionReader = new XmlModelReader<XmlDirection>(DirectionsPath);
            directionRepository = new XmlDirectionRepository(this);
            keyboardRepository = new XmlKeyboardRepository(this);
            var _alphabetsDirectory = Path.GetDirectoryName(AlphabetsPath) ?? string.Empty;
            xmlSymbolCollectionReader = new XmlModelCollectionReader<XmlAlifbaSymbol>(Path.Combine(_alphabetsDirectory, "Symbols"));
            xmlKeyboardSummaryReader = new XmlModelReader<XmlKeyboardSummary>(Path.Combine(_alphabetsDirectory, "KeyboardSummaries.xml"));
            var _keyboardsPath = Path.Combine(_alphabetsDirectory, "Keyboards");
            xmlKeyboardReader = new XmlModelCollectionReader<XmlKeyCombination>(_keyboardsPath);
            xmlMagicKeyboardReader = new XmlCustomCollectionReader<XmlMagicKeyboard>(_keyboardsPath);
            var _directionsDirectory = Path.GetDirectoryName(DirectionsPath) ?? string.Empty;
            xmlSymbolMappingReader = new XmlModelDictionaryReader<XmlTextSymbol, XmlTextSymbol>(Path.Combine(_directionsDirectory, "Mappings"));
            xmlExclusionReader = new XmlModelCollectionReader<XmlExclusion>(Path.Combine(_directionsDirectory, "Exclusions"));
        }

        private void InitAlifbaCache()
        {
            var _xmlList = xmlAlifbaReader.Read();
            if (_xmlList == null)
            {
                _xmlList = new List<XmlAlifba>();
                var _symbolLists = new List<XmlCollectionConfig<XmlAlifbaSymbol>>();
                var _IDs = new List<int>();
                foreach (var _builtIn in DefaultConfiguration.BuiltInAlifbaList)
                {
                    var _id = IDGenerator.GenerateID(_IDs);
                    _IDs.Add(_id);
                    var _alifba = new Alifba(_id, _builtIn.DefaultName,null,
                        _builtIn.RightToLeft, _builtIn.DefaultFont, _builtIn.ID);
                    _xmlList.Add(new XmlAlifba(_alifba));
                    if (_builtIn.CustomSymbols != null)
                        _symbolLists.Add(new XmlCollectionConfig<XmlAlifbaSymbol> { ID = _id, Collection = _builtIn.CustomSymbols.Select(x => new XmlAlifbaSymbol(x)).ToList() });
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
                    xmlSymbolCollectionReader.Save(new List<XmlCollectionConfig<XmlAlifbaSymbol>>
                    {
                        new XmlCollectionConfig<XmlAlifbaSymbol>
                        {
                            ID = _id,
                            Collection = DefaultConfiguration.Yanalif.CustomSymbols.Select(x=>new XmlAlifbaSymbol(x)).ToList()
                        }
                    });
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
            mappingsCache = new InMemoryList<XmlDictionaryConfig<XmlTextSymbol, XmlTextSymbol>>();
            mappingsCache.NotFound += xmlSymbolMappingReader.Read;
        }

        private void InitCustomSymbolsCache()
        {
            customSymbolsCache = new InMemoryList<XmlCollectionConfig<XmlAlifbaSymbol>>();
            customSymbolsCache.NotFound += xmlSymbolCollectionReader.Read;
        }

        private void InitExclusionsCache()
        {
            exclusionsCache = new InMemoryList<XmlCollectionConfig<XmlExclusion>>();
            exclusionsCache.NotFound += xmlExclusionReader.Read;
        }

        public void CancelChanges()
        {
            alifbaCache = null;
            directionCache = null;
            mappingsCache = null;
            customSymbolsCache = null;
            exclusionsCache = null;
            keyboardsCache = null;
            keyboardSummariesCache = null;
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
            if (keyboardSummariesCache != null)
                xmlKeyboardSummaryReader.Save(keyboardSummariesCache);
            if (keyboardsCache != null)
                xmlKeyboardReader.Save(keyboardsCache);
            if (magicKeyboardsCache != null)
                xmlMagicKeyboardReader.Save(magicKeyboardsCache);
        }
    }
}
