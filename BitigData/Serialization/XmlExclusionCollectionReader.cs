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

        public List<XmlExclusionCollection> Read()
        {
            var _list = new List<XmlExclusionCollection>();
            var _directoryInfo = new DirectoryInfo(directoryPath);
            if (_directoryInfo.Exists)
            {
                var _exclusionFiles = _directoryInfo.GetFiles("*.xml", SearchOption.TopDirectoryOnly);
                foreach (var _exclusionFile in _exclusionFiles)
                {
                    var _fileName = Path.GetFileNameWithoutExtension(_exclusionFile.Name);
                    int _id;
                    if (int.TryParse(_fileName, out _id))
                    {
                        var _xmlMapping = ExclusionCollectionSerializer.ReadFromFile(_exclusionFile.FullName, _id);
                        if (_xmlMapping != null)
                        {
                            _list.Add(_xmlMapping);
                        }
                    }
                }
            }
            return _list;
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
                        //custom: test
                        File.Delete(_filePath);
                        break;
                }
            }
        }
    }
}
