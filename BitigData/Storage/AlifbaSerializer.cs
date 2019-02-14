using System.Collections.Generic;
using System.Xml.Serialization;
using Bitig.Data.Model;

namespace Bitig.Data.Storage
{
    [XmlRoot(ElementName = "AlphabetsConfig")]
    public class AlphabetsConfig
    {
        [XmlArray("AlphabetList")]
        [XmlArrayItem("Alphabet")]
        public List<XmlAlifba> AlifbaList { get; set; }
    }

    internal class AlifbaSerializer
    {
        internal static void SaveToFile(string Path, List<XmlAlifba> AlifbaCollection)
        {
            ConfigSerializer<AlphabetsConfig>.SaveToFile(Path, new AlphabetsConfig { AlifbaList = AlifbaCollection });
        }

        internal static List<XmlAlifba> ReadFromFile(string Path)
        {
            var _config = ConfigSerializer<AlphabetsConfig>.ReadFromFile(Path);
            return _config == null ? null : _config.AlifbaList;
        }
    }
}
