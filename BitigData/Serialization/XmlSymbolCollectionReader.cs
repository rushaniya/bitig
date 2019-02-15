using System.Collections.Generic;
using System.IO;
using Bitig.Data.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{

    internal class XmlSymbolCollectionReader
    {
        private string directoryPath;

        public XmlSymbolCollectionReader(string DirectoryPath)
        {
            directoryPath = DirectoryPath;
        }

        public List<XmlSymbolCollection> Read()
        {
            var _list = new List<XmlSymbolCollection>();
            var _directoryInfo = new DirectoryInfo(directoryPath);
            if (_directoryInfo.Exists)
            {
                var _symbolFiles = _directoryInfo.GetFiles("*.xml", SearchOption.TopDirectoryOnly);
                foreach (var _symbolFile in _symbolFiles)
                {
                    var _fileName = Path.GetFileNameWithoutExtension(_symbolFile.Name);
                    int _id;
                    if (int.TryParse(_fileName, out _id))
                    {
                        var _xmlMapping = SymbolCollectionSerializer.ReadFromFile(_symbolFile.FullName, _id);
                        if (_xmlMapping != null)
                        {
                            _list.Add(_xmlMapping);
                        }
                    }
                }
            }
            return _list;
        }

        public void Save(InMemoryList<XmlSymbolCollection> ListToSave)
        {
            foreach (var _symbolList in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _symbolList.Item.ID + ".xml");
                switch (_symbolList.State)
                {
                    case ItemState.Added:
                    case ItemState.Updated:
                        SymbolCollectionSerializer.SaveToFile(_filePath, _symbolList.Item);
                        break;
                    case ItemState.Deleted:
                        File.Delete(_filePath);
                        break;
                }
            }
        }

        public void Save(List<XmlSymbolCollection> ListToSave)
        {
            foreach (var _symbolList in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _symbolList.ID + ".xml");
                SymbolCollectionSerializer.SaveToFile(_filePath, _symbolList);
            }
        }
    }
}
