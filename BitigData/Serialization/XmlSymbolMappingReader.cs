using System.Collections.Generic;
using System.IO;
using System.Linq;
using Bitig.Data.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{
    internal class XmlSymbolMappingReader
    {
        private string directoryPath;

        public XmlSymbolMappingReader(string DirectoryPath)
        {
            directoryPath = DirectoryPath;
        }

        public List<XmlSymbolMapping> Read()
        {
            var _list = new List<XmlSymbolMapping>();
            var _directoryInfo = new DirectoryInfo(directoryPath);
            if (_directoryInfo.Exists)
            {
                var _mappingFiles = _directoryInfo.GetFiles("*.xml", SearchOption.TopDirectoryOnly);
                foreach (var _mappingFile in _mappingFiles)
                {
                    var _fileName = Path.GetFileNameWithoutExtension(_mappingFile.Name);
                    int _id;
                    if (int.TryParse(_fileName, out _id))
                    {
                        var _xmlMapping = SymbolMappingSerializer.ReadFromFile(_mappingFile.FullName, _id);
                        if (_xmlMapping != null)
                        {
                            _list.Add(_xmlMapping);
                        }
                    }
                }
            }
            return _list;
        }

        public void Save(InMemoryList<XmlSymbolMapping> ListToSave)
        {
            foreach (var _mapping in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _mapping.Item.ID + ".xml");
                switch (_mapping.State)
                {
                    case ItemState.Added:
                    case ItemState.Unmodified:
                    case ItemState.Updated:
                        SymbolMappingSerializer.SaveToFile(_filePath, _mapping.Item);
                        break;
                    case ItemState.Deleted:
                        //custom: test
                        File.Delete(_filePath);
                        break;
                }
            }
        }
    }
}
