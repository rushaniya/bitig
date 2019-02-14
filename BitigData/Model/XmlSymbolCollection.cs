using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlSymbolCollection : EquatableByID<int>, IDeepCloneable<XmlSymbolCollection>
    {
        public override int ID { get; set; }

        public List<XmlAlifbaSymbol> Symbols { get; set; }

        public XmlSymbolCollection Clone()
        {
            return new XmlSymbolCollection { ID = ID, Symbols = Symbols.Select(x => x.Clone()).ToList() };
        }

        public XmlSymbolCollection()
        {

        }

        public XmlSymbolCollection(int ID, List<AlifbaSymbol> Symbols)
        {
            this.ID = ID;
            this.Symbols = Symbols.Select(x => new XmlAlifbaSymbol(x)).ToList();
        }
    }
}
