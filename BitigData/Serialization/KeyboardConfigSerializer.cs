using System;
using System.Collections.Generic;
using System.Linq;
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

    [XmlRoot("KeyboardSummaries")]
    public class KeyboardSummaryList
    {
        [XmlArray("KeyboardSummaryList")]
        [XmlArrayItem("KeyboardSummary")]
        public List<XmlKeyboardSummary> KeyboardSummaries { get; set; }
    }

    internal class KeyboardConfigSerializer
    {
        internal static void SaveToFile(string Path, XmlKeyboardConfig KeyboardConfig)
        {
            ConfigSerializer<XmlKeyboardConfig>.SaveToFile(Path, KeyboardConfig);
        }

        internal static XmlKeyCombinationCollection ReadFromFile(string Path, int ID)
        {
            var _config = ConfigSerializer<XmlKeyboardConfig>.ReadFromFile(Path);
            var _collection = _config == null ? null : new XmlKeyCombinationCollection
            {
                KeyCombinations = _config.KeyCombinations.Where(x => !string.IsNullOrEmpty(x.Combination)).ToList()
            };
            return _collection;
        }

        internal static List<XmlKeyboardSummary> ReadSummariesFromFile(string SummariesPath)
        {
            var _summaryList = ConfigSerializer<KeyboardSummaryList>.ReadFromFile(SummariesPath);
            if (_summaryList == null)
                return null;
            return _summaryList.KeyboardSummaries;
        }

        internal static void SaveSummariesToFile(string Path, List<XmlKeyboardSummary> SummariesList)
        {
            ConfigSerializer<KeyboardSummaryList>.SaveToFile(Path, new KeyboardSummaryList { KeyboardSummaries = SummariesList });
        }
    }
}
