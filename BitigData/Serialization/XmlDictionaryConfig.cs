using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Bitig.Data.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{
    [XmlRoot("Config")]
    public class XmlDictionaryConfig<T, U> : EquatableByID<int>, IDeepCloneable<XmlDictionaryConfig<T, U>>
        where T : IDeepCloneable<T>
        where U : IDeepCloneable<U>
    {
        [XmlIgnore]
        public override int ID { get; set; }

        [XmlArrayItem("Item")]
        public XmlDictionary<T, U> Dictionary { get; set; }

        public XmlDictionaryConfig<T, U> Clone()
        {
            var _dictionary = new XmlDictionary<T, U>();
            _dictionary.AddRange(Dictionary.Select(x => new XmlKeyValuePair<T, U>(x.Key.Clone(), x.Value.Clone())));
            return new XmlDictionaryConfig<T, U> { ID = ID, Dictionary = _dictionary };
        }
    }
}
