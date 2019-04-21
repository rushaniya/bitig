using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Bitig.Data.Serialization
{
    internal class ConfigSerializer<T> where T : class
    {
        private static XmlSerializer serializer = new XmlSerializer(typeof(T));

        public static void SaveToFile(string Path, T Instance)
        {
            var _directoryPath = System.IO.Path.GetDirectoryName(Path);
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            using (StreamWriter _writer = new StreamWriter(Path, false, Encoding.UTF8))
            {
                serializer.Serialize(_writer, Instance);
            }
        }

        public static T ReadFromFile(string Path)
        {
            try
            {
                if (File.Exists(Path))
                {
                    using (StreamReader _reader = new StreamReader(Path, Encoding.UTF8))
                    {
                        return (T)serializer.Deserialize(_reader);
                    }
                }
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Debug.Fail("Something is wrong with XML file.");
                return null;
            }
        }
    }
}
