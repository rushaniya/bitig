using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{


    internal class XmlModelDictionaryReader<T, U>
        where T : class, IDeepCloneable<T>
        where U : class, IDeepCloneable<U>
    {
        private string directoryPath;

        public XmlModelDictionaryReader(string DirectoryPath)
        {
            directoryPath = DirectoryPath;
        }

        public XmlDictionaryConfig<T, U> Read(int ID)
        {
            var _filePath = Path.Combine(directoryPath, ID.ToString() + ".xml");
            if (File.Exists(_filePath))
            {
                var _modelCollection = ConfigSerializer<XmlDictionaryConfig<T, U>>.ReadFromFile(_filePath);
                if (_modelCollection == null)
                    return null;
                _modelCollection.ID = ID;
                return _modelCollection;
            }
            return null;
        }

        public void Save(InMemoryList<XmlDictionaryConfig<T, U>> ListToSave)
        {
            foreach (var _itemToSave in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _itemToSave.Item.ID + ".xml");
                switch (_itemToSave.State)
                {
                    case ItemState.Added:
                    case ItemState.Unmodified:
                    case ItemState.Updated:
                        ConfigSerializer<XmlDictionaryConfig<T, U>>.SaveToFile(_filePath, _itemToSave.Item);
                        break;
                    case ItemState.Deleted:
                        File.Delete(_filePath);
                        break;
                }
            }
        }

        public void Save(List<XmlDictionaryConfig<T, U>> ListToSave)
        {
            foreach (var _itemToSave in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _itemToSave.ID + ".xml");
                ConfigSerializer<XmlDictionaryConfig<T, U>>.SaveToFile(_filePath, _itemToSave);
            }
        }
    }
}
