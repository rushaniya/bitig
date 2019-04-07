using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{
    internal class XmlModelCollectionReader<TXmlModel> : XmlCustomCollectionReader<XmlCollectionConfig<TXmlModel>>
     where TXmlModel : class, IDeepCloneable<TXmlModel>
    {
        public XmlModelCollectionReader(string DirectoryPath) : base(DirectoryPath)
        {
        }
    }
}
