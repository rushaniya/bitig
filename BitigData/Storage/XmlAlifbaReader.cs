using System.Collections.Generic;
using Bitig.Data.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Storage
{

    internal class XmlAlifbaReader
    {
        private string filePath;

        public XmlAlifbaReader(string FilePath)
        {
            filePath = FilePath;
        }

        public void Save(InMemoryList<XmlAlifba> Changes)
        {
            var _xmlList = Read();
            var _listToSave = Changes.ApplyChanges(_xmlList);
            AlifbaSerializer.SaveToFile(filePath, _listToSave);
        }

        public void Save(List<XmlAlifba> ListToSave)
        {
            AlifbaSerializer.SaveToFile(filePath, ListToSave);
        }

        public List<XmlAlifba> Read()
        {
            var _xmlList = AlifbaSerializer.ReadFromFile(filePath);
            return _xmlList;
        }
    }
}
