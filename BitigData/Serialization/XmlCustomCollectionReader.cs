using System.Collections.Generic;
using System.IO;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{
    internal class XmlCustomCollectionReader<T>
        where T : EquatableByID<int>, IDeepCloneable<T>
    {
        private string directoryPath;

        public XmlCustomCollectionReader(string DirectoryPath)
        {
            directoryPath = DirectoryPath;
        }

        public T Read(int ID)
        {
            var _filePath = Path.Combine(directoryPath, ID.ToString() + ".xml");
            if (File.Exists(_filePath))
            {
                var _modelCollection = ConfigSerializer<T>.ReadFromFile(_filePath);
                if (_modelCollection == null)
                    return null;
                _modelCollection.ID = ID;
                return _modelCollection;
            }
            return null;
        }

        public void Save(InMemoryList<T> ListToSave)
        {
            foreach (var _itemToSave in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _itemToSave.Item.ID + ".xml");
                switch (_itemToSave.State)
                {
                    case ItemState.Added:
                    case ItemState.Unmodified:
                    case ItemState.Updated:
                        ConfigSerializer<T>.SaveToFile(_filePath, _itemToSave.Item);
                        break;
                    case ItemState.Deleted:
                        File.Delete(_filePath);
                        break;
                }
            }
        }

        public void Save(List<T> ListToSave)
        {
            foreach (var _itemToSave in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _itemToSave.ID + ".xml");
                ConfigSerializer<T>.SaveToFile(_filePath, _itemToSave);
            }
        }
    }
}
