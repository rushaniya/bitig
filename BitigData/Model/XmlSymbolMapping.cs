using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [XmlArrayItem("Symbol")]
        public XmlDictionary<XmlAlifbaSymbol, XmlAlifbaSymbol> SymbolMapping { get; set; }

        public XmlSymbolMapping()
        {

        }

        public XmlSymbolMapping(int ID, ManualCommand ManualCommand)
        {
            this.ID = ID;
            SymbolMapping = new XmlDictionary<XmlAlifbaSymbol, XmlAlifbaSymbol>(
                ManualCommand.SymbolMapping
                        .ToDictionary(x => new XmlAlifbaSymbol(x.Key), x => new XmlAlifbaSymbol(x.Value)));
        }

        public XmlSymbolMapping Clone()
        {
            var _symbolMapping = new XmlDictionary<XmlAlifbaSymbol, XmlAlifbaSymbol>();
            _symbolMapping.AddRange(this.SymbolMapping.Select(x => new XmlKeyValuePair<XmlAlifbaSymbol, XmlAlifbaSymbol>(x.Key.Clone(), x.Value.Clone())));
            return new XmlSymbolMapping
            {
                ID = this.ID,
                SymbolMapping = _symbolMapping
            };
        }
    }
}
