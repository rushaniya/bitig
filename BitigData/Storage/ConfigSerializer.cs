using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Bitig.Data.Storage
{
    public class ConfigSerializer<T> where T : class
    {
        private static XmlSerializer serializer = new XmlSerializer(typeof(T));

        internal static void SaveToFile(string Path, T Instance)
        {
            var _directoryPath = System.IO.Path.GetDirectoryName(Path);
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            using (StreamWriter _writer = new StreamWriter(Path, false, Encoding.Unicode))
            {
                serializer.Serialize(_writer, Instance);
            }
        }

        internal static T ReadFromFile(string Path)
        {
            try
            {
                if (File.Exists(Path))
                {
                    using (StreamReader _reader = new StreamReader(Path, Encoding.Unicode))
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
