using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.Base
{
    public class Exclusion
    {
        
        protected bool matchCase;

        public bool MatchCase
        {
            get { return matchCase; }
            set { matchCase = value; }
        }

        /// <summary>
        /// 'tableclothes' in 'tableclothes' is a match
        /// </summary>
        public bool MatchWholeWord
        {
            get { return !matchBeginning && !anyPosition; }
        }

        private bool matchBeginning = true;
        /// <summary>
        /// 'table' in 'tableclothes' is a match; 'clothe' is not
        /// </summary>
        public bool MatchBeginning
        {
            get { return matchBeginning; }
            set { matchBeginning = value; }
        }

        private bool anyPosition;
        /// <summary>
        /// 'cloth' in 'tableclothes' is a match
        /// </summary>
        public bool AnyPosition
        {
            get { return anyPosition; }
            set { anyPosition = value; }
        }
        
        protected string sourceWord;

        public string SourceWord
        {
            get { return sourceWord; }
            set { sourceWord = value; }
        }

        protected string targetWord;

        public string TargetWord
        {
            get { return targetWord; }
            set { targetWord = value; }
        }


        public Exclusion(string SourceWord, string TargetWord, bool MatchCase, bool MatchBeginning, bool AnyPosition)
        {
            this.matchCase = MatchCase;
            this.sourceWord = SourceWord.Normalize();
            this.targetWord = TargetWord;
            this.matchBeginning = MatchBeginning;
            this.anyPosition = AnyPosition;
        }

        protected Exclusion() { }
    }
}
