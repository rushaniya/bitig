using System.IO;
using Bitig.Data.Model;

namespace Bitig.Data.Serialization
{
    internal class XmlKeyboardConfigReader
    {
        private string directoryPath;

        public XmlKeyboardConfigReader(string DirectoryPath)
        {
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
    }
}
