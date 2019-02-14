using System.Linq;
using System.Xml.Serialization;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlSymbolMapping : EquatableByID<int>, IDeepCloneable<XmlSymbolMapping>
    {
        public override int ID
        {
            get; set;
        }

        public XmlDictionary<XmlTextSymbol, XmlTextSymbol> SymbolMapping { get; set; }

        public XmlSymbolMapping()
        {

        }

        public XmlSymbolMapping(int ID, ManualCommand ManualCommand)
        {
            this.ID = ID;
            SymbolMapping = new XmlDictionary<XmlTextSymbol, XmlTextSymbol>(
                ManualCommand.SymbolMapping
                        .ToDictionary(x => new XmlTextSymbol(x.Key), x => new XmlTextSymbol(x.Value)));
        }

        public XmlSymbolMapping Clone()
        {
            var _symbolMapping = new XmlDictionary<XmlTextSymbol, XmlTextSymbol>();
            _symbolMapping.AddRange(this.SymbolMapping.Select(x => new XmlKeyValuePair<XmlTextSymbol, XmlTextSymbol>(x.Key.Clone(), x.Value.Clone())));
            return new XmlSymbolMapping
            {
                ID = this.ID,
                SymbolMapping = _symbolMapping
            };
        }
    }
}
