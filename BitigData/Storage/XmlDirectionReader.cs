using System.Collections.Generic;
using Bitig.Data.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Storage
{
    internal class XmlDirectionReader
    {
        private string filePath;

        public XmlDirectionReader(string FilePath)
        {
            filePath = FilePath;
        }

        public List<XmlDirection> Read()
        {
            var _xmlList = DirectionSerializer.ReadFromFile(filePath);
            return _xmlList;
        }

        public void Save(List<XmlDirection> ListToSave)
        {
            DirectionSerializer.SaveToFile(filePath, ListToSave);
        }

        public void Save(InMemoryList<XmlDirection> DirectionCache)
        {
            var _xmlList = Read();
            var _listToSave = DirectionCache.ApplyChanges(_xmlList);
            DirectionSerializer.SaveToFile(filePath, _listToSave);
        }
    }
}
