using System.Collections.Generic;
using System.Xml.Serialization;
using Bitig.Data.Model;

namespace Bitig.Data.Storage
{
    [XmlRoot("DirectionsConfig")]
    public class DirectionsConfig
    {
        [XmlArray("DirectionList")]
        [XmlArrayItem("Direction")]
        public List<XmlDirection> DirectionsList { get; set; }
    }

    internal class DirectionSerializer
    {
        internal static void SaveToFile(string Path, List<XmlDirection> Directions)
        {
            ConfigSerializer<DirectionsConfig>.SaveToFile(Path, new DirectionsConfig { DirectionsList = Directions });
        }

        internal static List<XmlDirection> ReadFromFile(string Path)
        {
            var _config = ConfigSerializer<DirectionsConfig>.ReadFromFile(Path);
            return _config == null ? null : _config.DirectionsList;
        }
    }
}
