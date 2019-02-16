using System.Collections.Generic;
using System.IO;
using Bitig.Data.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{
    internal class XmlExclusionCollectionReader
    {
        private string directoryPath;

        public XmlExclusionCollectionReader(string DirectoryPath)
        {
            directoryPath = DirectoryPath;
        }

        public XmlExclusionCollection Read(int ID)
        {
            var _filePath = Path.Combine(directoryPath, ID.ToString() + ".xml");
            if (File.Exists(_filePath))
            {
                var _collection = ExclusionCollectionSerializer.ReadFromFile(_filePath, ID);
                return _collection;
            }
            return null;
        }

        public void Save(InMemoryList<XmlExclusionCollection> ListToSave)
        {
            foreach (var _exclusionList in ListToSave)
            {
                var _filePath = Path.Combine(directoryPath, _exclusionList.Item.ID + ".xml");
                switch (_exclusionList.State)
                {
                    case ItemState.Added:
                    case ItemState.Unmodified:
                    case ItemState.Updated:
                        ExclusionCollectionSerializer.SaveToFile(_filePath, _exclusionList.Item);
                        break;
                    case ItemState.Deleted:
                        File.Delete(_filePath);
                        break;
                }
            }
        }
    }
}
