using System;
using System.Collections.Generic;
using System.IO;
using Bitig.Data.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Serialization
{
    internal class XmlKeyboardConfigReader
    {
        private string directoryPath;
        private string summariesPath;

        public XmlKeyboardConfigReader(string SummariesPath, string DirectoryPath)
        {
            summariesPath = SummariesPath;
            directoryPath = DirectoryPath;
        }

        public XmlKeyCombinationCollection Read(int ID)
        {
            var _filePath = Path.Combine(directoryPath, ID.ToString() + ".xml");
            if (File.Exists(_filePath))
            {
                var _xmlKeyboard = KeyboardConfigSerializer.ReadFromFile(_filePath, ID);
                return _xmlKeyboard;
            }
            return null;
        }

        internal List<XmlKeyboardSummary> ReadSummaryList()
        {
            var _xmlList = KeyboardConfigSerializer.ReadSummariesFromFile(summariesPath);
            return _xmlList;
        }

        internal void SaveSummaryList(InMemoryList<XmlKeyboardSummary> SummaryCache)
        {
            var _xmlList = ReadSummaryList();
            var _listToSave = SummaryCache.ApplyChanges(_xmlList);
            KeyboardConfigSerializer.SaveSummariesToFile(summariesPath, _listToSave);
        }
    }
}
