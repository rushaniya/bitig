using System.Collections.Generic;
using System.Xml.Serialization;
using Bitig.Data.Model;

namespace Bitig.Data.Storage
{
    [XmlRoot("SymbolsConfig")]
    public class SymbolCollectionConfig
    {
        [XmlArray("SymbolList")]
        [XmlArrayItem("Symbol")]
        public List<XmlAlifbaSymbol> Symbols { get; set; }
    }

    internal class SymbolCollectionSerializer
    {
        internal static void SaveToFile(string Path, XmlSymbolCollection SymbolCollection)
        {
            ConfigSerializer<SymbolCollectionConfig>.SaveToFile(Path, new SymbolCollectionConfig { Symbols = SymbolCollection.Symbols });
        }

        internal static XmlSymbolCollection ReadFromFile(string Path, int ID)
        {
            var _config = ConfigSerializer<SymbolCollectionConfig>.ReadFromFile(Path);
            var _mapping = _config == null ? null : new XmlSymbolCollection { Symbols = _config.Symbols, ID = ID };
            return _mapping;
        }
    }
}
