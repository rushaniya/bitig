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

        public XmlSymbolCollection Read(int ID)
        {
            var _filePath = Path.Combine(directoryPath, ID.ToString() + ".xml");
            if (File.Exists(_filePath))
            {
                var _collection = SymbolCollectionSerializer.ReadFromFile(_filePath, ID);
                return _collection;
            }
            return null;
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
