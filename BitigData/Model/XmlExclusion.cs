using Bitig.Data.Storage;

namespace Bitig.Data.Model
{
    public class XmlExclusion
    {
        //private int id = -1;

        //public int ID
        //{
        //    get { return id; }
        //    set
        //    {
        //        if (ExclusionSerializer.Deserializing)
        //            id = value;
        //        else System.Diagnostics.Debug.Fail("XmlExclusion.ID set");
        //    }
        //}

        private int directionID = -1;

        public int DirectionID
        {
            get { return directionID; }
            set { directionID = value; }
        }

        public string SourceWord
        {
            get;
            set;
        }

        public string TargetWord
        {
            get;
            set;
        }

        public bool MatchCase
        {
            get;
            set;
        }

        public bool MatchBeginning
        {
            get;
            set;
        }

        public bool AnyPosition
        {
            get;
            set;
        }

        public XmlExclusion()
        {

        }
    }
}
