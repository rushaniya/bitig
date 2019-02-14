using System.Collections.Generic;
using System.Xml.Serialization;
using Bitig.Data.Model;

namespace Bitig.Data.Serialization
{
    [XmlRoot("ExclusionsConfig")]
    public class ExclusionCollectionConfig
    {
        [XmlArray("ExclusionList")]
        [XmlArrayItem("Exclusion")]
        public List<XmlExclusion> Exclusions { get; set; }
    }

    internal class ExclusionCollectionSerializer
    {
        internal static void SaveToFile(string Path, XmlExclusionCollection ExclusionCollection)
        {
            ConfigSerializer<ExclusionCollectionConfig>.SaveToFile(Path, new ExclusionCollectionConfig { Exclusions = ExclusionCollection.Exclusions });
        }

        internal static XmlExclusionCollection ReadFromFile(string Path, int ID)
        {
            var _config = ConfigSerializer<ExclusionCollectionConfig>.ReadFromFile(Path);
            var _mapping = _config == null ? null : new XmlExclusionCollection { Exclusions = _config.Exclusions, ID = ID };
            return _mapping;
        }
    }
}
