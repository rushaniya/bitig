using System.Collections.Generic;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{
    internal class XmlModelReader<TXmlModel>
         where TXmlModel : EquatableByID<int>, IDeepCloneable<TXmlModel>
    {
        private string filePath;

        public XmlModelReader(string FilePath)
        {
            filePath = FilePath;
        }

        public List<TXmlModel> Read()
        {
            var _storageInstance = ConfigSerializer<XmlConfig<TXmlModel>>.ReadFromFile(filePath);
            return _storageInstance == null ? null : _storageInstance.Collection;
        }


        public void Save(List<TXmlModel> ListToSave)
        {
            ConfigSerializer<XmlConfig<TXmlModel>>.SaveToFile(filePath, new XmlConfig<TXmlModel>(ListToSave));
        }

        public void Save(InMemoryList<TXmlModel> ListToSave)
        {
            var _stored = Read();
            var _listToSave = ListToSave.ApplyChanges(_stored);
            Save(_listToSave);
        }
    }
}
