using System.Collections.Generic;
using System.IO;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{
    internal class XmlModelCollectionReader<TXmlModelCollection>
        where TXmlModelCollection : EquatableByID<int>, IDeepCloneable<TXmlModelCollection>
    {
        private string directoryPath;

        public XmlModelCollectionReader(string DirectoryPath)
        {
            directoryPath = DirectoryPath;
        }

        public TXmlModelCollection Read(int ID)
        {
            var _filePath = Path.Combine(directoryPath, ID.ToString() + ".xml");
            if (File.Exists(_filePath))
            {
                var _modelCollection = ConfigSerializer<TXmlModelCollection>.ReadFromFile(_filePath);
                _modelCollection.ID = ID;
            }
            return null;
        }

        public void Save(InMemoryList<TXmlModelCollection> ListToSave)
        {
            foreach (var _itemToSave in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _itemToSave.Item.ID + ".xml");
                switch (_itemToSave.State)
                {
                    case ItemState.Added:
                    case ItemState.Unmodified:
                    case ItemState.Updated:
                        ConfigSerializer<TXmlModelCollection>.SaveToFile(_filePath, _itemToSave.Item);
                        break;
                    case ItemState.Deleted:
                        File.Delete(_filePath);
                        break;
                }
            }
        }

        public void Save(List<TXmlModelCollection> ListToSave)
        {
            foreach (var _itemToSave in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _itemToSave.ID + ".xml");
                ConfigSerializer<TXmlModelCollection>.SaveToFile(_filePath, _itemToSave);
            }
        }
    }
}
