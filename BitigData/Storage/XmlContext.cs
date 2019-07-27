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
        private InMemoryList<XmlAlphabet> alphabetCache;
        private InMemoryList<XmlDirection> directionCache;
        private InMemoryList<XmlDictionaryConfig<XmlTextSymbol, XmlTextSymbol>> mappingsCache;
        private InMemoryList<XmlCollectionConfig<XmlAlphabetSymbol>> customSymbolsCache;
        private InMemoryList<XmlCollectionConfig<XmlExclusion>> exclusionsCache;
        private InMemoryList<XmlCollectionConfig<XmlKeyCombination>> keyboardsCache;
        private InMemoryList<XmlMagicKeyboard> magicKeyboardsCache;
        private InMemoryList<XmlKeyboardSummary> keyboardSummariesCache;

        private XmlModelReader<XmlAlphabet> xmlAlphabetReader;
        private XmlModelReader<XmlDirection> xmlDirectionReader;
        private XmlModelDictionaryReader<XmlTextSymbol, XmlTextSymbol> xmlSymbolMappingReader;
        private XmlModelCollectionReader<XmlAlphabetSymbol> xmlSymbolCollectionReader;
        private XmlModelCollectionReader<XmlExclusion> xmlExclusionReader;
        private XmlModelReader<XmlKeyboardSummary> xmlKeyboardSummaryReader;
        private XmlModelCollectionReader<XmlKeyCombination> xmlKeyboardReader;
        private XmlCustomCollectionReader<XmlMagicKeyboard> xmlMagicKeyboardReader;

        private XmlAlphabetRepository alphabetRepository;
        private XmlDirectionRepository directionRepository;
        private XmlKeyboardRepository keyboardRepository;

        public bool IsFlushable { get { return true; } }

        internal InMemoryList<XmlAlphabet> Alphabets
        {
            get
            {
                if (alphabetCache == null)
                    InitAlphabetCache();
                return alphabetCache;
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

        internal InMemoryList<XmlCollectionConfig<XmlAlphabetSymbol>> CustomSymbols
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

        public AlphabetRepository AlphabetRepository
        {
            get
            {
                return alphabetRepository;
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
            xmlAlphabetReader = new XmlModelReader<XmlAlphabet>(AlphabetsPath);
            alphabetRepository = new XmlAlphabetRepository(this);
            xmlDirectionReader = new XmlModelReader<XmlDirection>(DirectionsPath);
            directionRepository = new XmlDirectionRepository(this);
            keyboardRepository = new XmlKeyboardRepository(this);
            var _alphabetsDirectory = Path.GetDirectoryName(AlphabetsPath) ?? string.Empty;
            xmlSymbolCollectionReader = new XmlModelCollectionReader<XmlAlphabetSymbol>(Path.Combine(_alphabetsDirectory, "Symbols"));
            xmlKeyboardSummaryReader = new XmlModelReader<XmlKeyboardSummary>(Path.Combine(_alphabetsDirectory, "KeyboardSummaries.xml"));
            var _keyboardsPath = Path.Combine(_alphabetsDirectory, "Keyboards");
            xmlKeyboardReader = new XmlModelCollectionReader<XmlKeyCombination>(_keyboardsPath);
            xmlMagicKeyboardReader = new XmlCustomCollectionReader<XmlMagicKeyboard>(_keyboardsPath);
            var _directionsDirectory = Path.GetDirectoryName(DirectionsPath) ?? string.Empty;
            xmlSymbolMappingReader = new XmlModelDictionaryReader<XmlTextSymbol, XmlTextSymbol>(Path.Combine(_directionsDirectory, "Mappings"));
            xmlExclusionReader = new XmlModelCollectionReader<XmlExclusion>(Path.Combine(_directionsDirectory, "Exclusions"));
        }

        private void InitAlphabetCache()
        {
            var _xmlList = xmlAlphabetReader.Read();
            if (_xmlList == null)
            {
                _xmlList = new List<XmlAlphabet>();
            }
            alphabetCache = new InMemoryList<XmlAlphabet>(_xmlList);
            alphabetCache.IDChanged += OnAlphabetIDChanged;
        }

        private void OnAlphabetIDChanged(int OldID, int NewID)
        {
            if (directionCache != null)
            {
                var _asSource = directionCache.GetList().Where(x => x.SourceAlphabetID == OldID);
                foreach (var _direction in _asSource)
                {
                    _direction.SourceAlphabetID = NewID;
                    directionCache.Update(_direction);
                }
                var _asTarget = directionCache.GetList().Where(x => x.TargetAlphabetID == OldID);
                foreach (var _direction in _asTarget)
                {
                    _direction.TargetAlphabetID = NewID;
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
            if (alphabetCache == null)
                InitAlphabetCache();
            var _xmlList = xmlDirectionReader.Read();
            if (_xmlList == null)
            {
                _xmlList = new List<XmlDirection>();
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
            customSymbolsCache = new InMemoryList<XmlCollectionConfig<XmlAlphabetSymbol>>();
            customSymbolsCache.NotFound += xmlSymbolCollectionReader.Read;
        }

        private void InitExclusionsCache()
        {
            exclusionsCache = new InMemoryList<XmlCollectionConfig<XmlExclusion>>();
            exclusionsCache.NotFound += xmlExclusionReader.Read;
        }

        private void ClearCaches()
        {
            alphabetCache = null;
            directionCache = null;
            mappingsCache = null;
            customSymbolsCache = null;
            exclusionsCache = null;
            keyboardsCache = null;
            keyboardSummariesCache = null;
        }

        public void CancelChanges()
        {
            ClearCaches();
        }

        public void SaveChanges()
        {
            if (alphabetCache != null)
                xmlAlphabetReader.Save(alphabetCache);
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
            ClearCaches();
        }
    }
}
