using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Bitig.Logic;
using Bitig.Data.Model;

namespace Bitig.Data.Storage
{
    [XmlRoot(ElementName = "Alphabets")]
    public class AlifbaSerializer
    {

        private const string NOTE = "Reserved Alifba IDs: 0 - Cyrillic, 1 - Yanalif, 2 - Zamanalif, 3 - Official 2012 Alphabet. Custom IDs start at 1024.";

        private string note = NOTE;

        public string Note
        {
            get { return NOTE; }
            set {  }
        }
        
        private static AlifbaSerializer instance;

        private static XmlSerializer serializer = new XmlSerializer(typeof(AlifbaSerializer));

        private List<XmlAlifba> alifbaList = new List<XmlAlifba>();

        public List<XmlAlifba> AlifbaList
        {
            get { return alifbaList; }
            set { alifbaList = value; }
        }

        private static bool deserializing;
        [XmlIgnore]
        internal static bool Deserializing
        {
            get { return deserializing; }
        }

        /// <summary>
        /// Intended for xml serialization only
        /// </summary>
        public AlifbaSerializer()
        {

        }
        
        private void Save(string Path)
        {
            var _directoryPath = System.IO.Path.GetDirectoryName(Path);
            if (!Directory.Exists(_directoryPath))
                Directory.CreateDirectory(_directoryPath);
            using (StreamWriter _writer = new StreamWriter(Path, false, Encoding.Unicode))
            {
                serializer.Serialize(_writer, this);
            }
        }

        internal static void SaveToFile(string Path, List<XmlAlifba> AlifbaCollection)
        {
            if (instance == null)
                instance = new AlifbaSerializer();
            instance.alifbaList = AlifbaCollection;
            instance.Save(Path);
        }

        internal static List<XmlAlifba> ReadFromFile(string Path)
        {
            try
            {
                if (File.Exists(Path))
                {
                    using (StreamReader _reader = new StreamReader(Path, Encoding.Unicode))
                    {
                        deserializing = true;
                        instance = (AlifbaSerializer)serializer.Deserialize(_reader);
                    }
                    return instance.alifbaList;
                }
                return null;
            }
            finally
            {
                deserializing = false;
            }
        }
    }
}
