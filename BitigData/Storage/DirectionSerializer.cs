using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Bitig.Data.Model;

namespace Bitig.Data.Storage
{
    [XmlRoot("Directions")]
    public class DirectionSerializer
    {
        private List<XmlDirection> directionsList = new List<XmlDirection>();

        public List<XmlDirection> DirectionsList
        {
            get { return directionsList; }
            set { directionsList = value; }
        }

        private static DirectionSerializer instance;

        private static XmlSerializer serializer = new XmlSerializer(typeof(DirectionSerializer));

        private static bool deserializing;
        [XmlIgnore]
        internal static bool Deserializing
        {
            get { return deserializing; }
        }

        /// <summary>
        /// Intended for xml serialization only
        /// </summary>
        public DirectionSerializer()
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

        internal static void SaveToFile(string Path, List<XmlDirection> Directions)
        {
            if (instance == null) instance = new DirectionSerializer();
            instance.directionsList = Directions;
            instance.Save(Path);
        }

        internal static List<XmlDirection> ReadFromFile(string Path)
        {
            try
            {
                if (File.Exists(Path))
                {
                    using (StreamReader _reader = new StreamReader(Path, Encoding.Unicode))
                    {
                        deserializing = true;
                        instance = (DirectionSerializer)serializer.Deserialize(_reader);
                    }
                    return instance.directionsList;
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
