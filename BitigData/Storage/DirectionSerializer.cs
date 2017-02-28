using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Storage
{
    [XmlRoot("Directions")]
    public class DirectionSerializer
    {
        internal static readonly string DirectionsPath = Path.Combine(DefaultConfiguration.LocalFolder, "Directions.xml");

        private List<Direction> directionsList = new List<Direction>();

        public List<Direction> DirectionsList
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

        //repo
        private static void CreateDefaultFile()
        {
            throw new NotImplementedException();
            //instance = new DirectionSerializer();
            //int _count = DirectionManager.BuiltInDirections.Count;
            //for (int i = 0; i < _count; i++)
            //{
            //    instance.directionsList.Add(new Direction(i)
            //    {
            //        SourceAlifbaID = DirectionManager.BuiltInDirections[i].SourceAlifbaID,
            //        TargetAlifbaID = DirectionManager.BuiltInDirections[i].TargetAlifbaID,
            //        BuiltInID = DirectionManager.BuiltInDirections[i].ID
            //    });
            //}
            //instance.Save();
        }

        private void Save()
        {
            if (!Directory.Exists(DefaultConfiguration.LocalFolder))
                Directory.CreateDirectory(DefaultConfiguration.LocalFolder);
            using (StreamWriter _writer = new StreamWriter(DirectionsPath, false, Encoding.Unicode))
            {
                serializer.Serialize(_writer, this);
            }
        }

        internal static void SaveToFile(List<Direction> Directions)
        {
            if (instance == null) instance = new DirectionSerializer();
            instance.directionsList = Directions;
            instance.Save();
        }

        internal static List<Direction> ReadFromFile()
        {
            if (File.Exists(DirectionsPath))
            {
                try
                {
                    using (StreamReader _reader = new StreamReader(DirectionsPath, Encoding.Unicode))
                    {
                        deserializing = true;
                        instance = (DirectionSerializer)serializer.Deserialize(_reader);
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
            return instance.directionsList;
        }
    }
}
