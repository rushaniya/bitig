using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{
    [XmlRoot("Config")]
    public class XmlCollectionConfig<T> : EquatableByID<int>, IDeepCloneable<XmlCollectionConfig<T>>
        where T : IDeepCloneable<T>
    {
        [XmlIgnore]
        public override int ID { get; set; }

        [XmlArrayItem("Item")]
        public List<T> Collection { get; set; }

        public XmlCollectionConfig<T> Clone()
        {
            return new XmlCollectionConfig<T> { ID = ID, Collection = Collection.Select(x => x.Clone()).ToList() };
        }
    }
}
