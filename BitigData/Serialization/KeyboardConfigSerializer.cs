using System.Collections.Generic;
using System.Xml.Serialization;
using Bitig.Data.Model;

namespace Bitig.Data.Serialization
{

    [XmlRoot("KeyboardConfig")]
    public class XmlKeyboardConfig
    {
        [XmlArray("KeyCombinations")]
        [XmlArrayItem("KeyCombination")]
        public List<XmlKeyCombination> KeyCombinations { get; set; }
    }

    internal class KeyboardConfigSerializer
    {
        internal static void SaveToFile(string Path, XmlKeyCombinationCollection KeyCombinationCollection)
        {
            ConfigSerializer<XmlKeyboardConfig>.SaveToFile(Path, new XmlKeyboardConfig { KeyCombinations = KeyCombinationCollection.KeyCombinations });
        }

        internal static XmlKeyCombinationCollection ReadFromFile(string Path, int ID)
        {
            var _config = ConfigSerializer<XmlKeyboardConfig>.ReadFromFile(Path);
            var _collection = _config == null ? null : new XmlKeyCombinationCollection { KeyCombinations = _config.KeyCombinations, ID = ID };
            return _collection;
        }
    }
}
