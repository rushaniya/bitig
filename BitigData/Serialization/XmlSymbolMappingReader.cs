using System.IO;
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

        public XmlSymbolMapping Read(int ID)
        {
            var _filePath = Path.Combine(directoryPath, ID.ToString() + ".xml");
            if (File.Exists(_filePath))
            {
                var _collection = SymbolMappingSerializer.ReadFromFile(_filePath, ID);
                return _collection;
            }
            return null;
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
                        File.Delete(_filePath);
                        break;
                }
            }
        }
    }
}
