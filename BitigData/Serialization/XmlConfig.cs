using System.Collections.Generic;
using System.Xml.Serialization;

namespace Bitig.Data.Serialization
{
    [XmlRoot("Config")]
    public class XmlConfig<T>
    {
        [XmlArrayItem("Item")]
        public List<T> Collection { get; set; }

        public XmlConfig(List<T> Model)
        {
            Collection = Model;
        }

        public XmlConfig()
        {

        }
    }
}
