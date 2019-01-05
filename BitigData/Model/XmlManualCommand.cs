using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Bitig.Data.Model
{
    public class XmlManualCommand
    {
        [XmlArrayItem("Symbol")]
        public XmlDictionary<XmlAlifbaSymbol, XmlAlifbaSymbol> SymbolMapping { get; set; }
    }
}
