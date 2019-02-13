using Bitig.Data.Model;

namespace Bitig.Data.Storage
{
    internal class SymbolMappingSerializer
    {
        internal static void SaveToFile(string Path, XmlSymbolMapping SymbolMapping)
        {
            ConfigSerializer<XmlDictionary<XmlAlifbaSymbol, XmlAlifbaSymbol>>.SaveToFile(Path, SymbolMapping.SymbolMapping);
        }

        internal static XmlSymbolMapping ReadFromFile(string Path, int ID)
        {
            var _config = ConfigSerializer<XmlDictionary<XmlAlifbaSymbol, XmlAlifbaSymbol>>.ReadFromFile(Path);
            var _mapping = _config == null ? null : new XmlSymbolMapping { SymbolMapping = _config, ID = ID };
            return _mapping;
        }
    }
}
