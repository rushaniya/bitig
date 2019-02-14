using System.Xml.Serialization;
using Bitig.Data.Model;

namespace Bitig.Data.Serialization
{
    [XmlRoot("SymbolMappingsConfig")]
    public class SymbolMappingConfig
    {
        [XmlArray("SymbolMappingDictionary")]
        [XmlArrayItem("SymbolMapping")]
        public XmlDictionary<XmlTextSymbol, XmlTextSymbol> SymbolMapping { get; set; }
    }

    internal class SymbolMappingSerializer
    {
        internal static void SaveToFile(string Path, XmlSymbolMapping SymbolMapping)
        {
            ConfigSerializer<SymbolMappingConfig>.SaveToFile(Path, new SymbolMappingConfig { SymbolMapping = SymbolMapping.SymbolMapping });
        }

        internal static XmlSymbolMapping ReadFromFile(string Path, int ID)
        {
            var _config = ConfigSerializer<SymbolMappingConfig>.ReadFromFile(Path);
            var _mapping = _config == null ? null : new XmlSymbolMapping { SymbolMapping = _config.SymbolMapping, ID = ID };
            return _mapping;
        }
    }
}
