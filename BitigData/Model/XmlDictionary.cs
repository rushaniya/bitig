using System.Collections.Generic;
using System.Linq;

namespace Bitig.Data.Model
{
    public class XmlKeyValuePair<T, U>
    {
        public T Key { get; set; }
        public U Value { get; set; }

        public XmlKeyValuePair()
        {

        }

        public XmlKeyValuePair(T Key, U Value)
        {
            this.Key = Key;
            this.Value = Value;
        }
    }

    public class XmlDictionary<T, U> : List<XmlKeyValuePair<T, U>>
    {
        public XmlDictionary()
        {

        }

        public XmlDictionary(Dictionary<T, U> Dictionary)
        {
            AddRange(Dictionary.Select(x => new XmlKeyValuePair<T, U>(x.Key, x.Value)));
        }
    }
}
