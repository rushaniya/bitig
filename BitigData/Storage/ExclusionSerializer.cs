using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Bitig.Base;
using Bitig.Logic.Repository;

namespace Bitig.Data.Storage
{
    [XmlRoot("Exclusions")]
    public class ExclusionSerializer
    {
        internal static readonly string ExclusionsPath = Path.Combine(DefaultConfiguration.LocalFolder, "Exclusions.xml");

        private static ExclusionSerializer instance;

        private static XmlSerializer serializer = new XmlSerializer(typeof(ExclusionSerializer));

        private List<Exclusion> exclusionsList = new List<Exclusion>();

        public List<Exclusion> ExclusionsList
        {
            get { return exclusionsList; }
            set { exclusionsList = value; }
        }

        private static bool deserializing;
        [XmlIgnore]
        internal static bool Deserializing //excl:needed?
        {
            get { return deserializing; }
        }

        /// <summary>
        /// Intended for xml serialization only
        /// </summary>
        public ExclusionSerializer()
        {

        }

        private static void CreateDefaultFile()
        {
            instance = new ExclusionSerializer();
            instance.Save();
        }

        private void Save()
        {
            if (!Directory.Exists(DefaultConfiguration.LocalFolder))
                Directory.CreateDirectory(DefaultConfiguration.LocalFolder);
            using (StreamWriter _writer = new StreamWriter(ExclusionsPath, false, Encoding.Unicode))
            {
                serializer.Serialize(_writer, this);
            }
        }

        internal static void SaveToFile(List<Exclusion> ExclusionCollection)
        {
            if (instance == null) instance = new ExclusionSerializer();
            instance.exclusionsList = ExclusionCollection;
            instance.Save();
        }

        internal static List<Exclusion> ReadFromFile()
        {
            if (File.Exists(ExclusionsPath))
            {
                try
                {
                    using (StreamReader _reader = new StreamReader(ExclusionsPath, Encoding.Unicode))
                    {
                        deserializing = true;
                        instance = (ExclusionSerializer)serializer.Deserialize(_reader);
                    }
                }
                catch
                {
                    CreateDefaultFile();
                }
                finally
                {
                    deserializing = false;
                }
            }
            else
            {
                CreateDefaultFile();
            }
            return instance.exclusionsList;
        }
    }
}
