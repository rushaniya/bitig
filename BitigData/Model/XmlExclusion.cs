using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Data.Model
{
    public class XmlExclusion
    {
        private int id = -1;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private int directionID = -1;

        public int DirectionID
        {
            get { return directionID; }
            set { directionID = value; }
        }

        private string sourceWord;

        public string SourceWord
        {
            get { return sourceWord; }
            set { sourceWord = value; }
        }

        private string targetWord;

        public string TargetWord
        {
            get { return targetWord; }
            set { targetWord = value; }
        }

        private bool matchCase;

        public bool MatchCase
        {
            get { return matchCase; }
            set { matchCase = value; }
        }

        private bool matchBeginning;

        public bool MatchBeginning
        {
            get { return matchBeginning; }
            set { matchBeginning = value; }
        }

        private bool matchMiddle;

        public bool MatchMiddle
        {
            get { return matchMiddle; }
            set { matchMiddle = value; }
        }
        public XmlExclusion()
        {

        }
    }
}
