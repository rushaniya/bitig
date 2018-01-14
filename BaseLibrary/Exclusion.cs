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
            set
            {
                matchBeginning = value;
                if (matchBeginning)
                    anyPosition = false;
            }
        }

        private bool anyPosition;
        /// <summary>
        /// 'cloth' in 'tableclothes' is a match
        /// </summary>
        public bool AnyPosition
        {
            get { return anyPosition; }
            set
            {
                anyPosition = value;
                if (anyPosition)
                    matchBeginning = false;
            }
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
            matchCase = MatchCase;
            sourceWord = SourceWord.Normalize();
            targetWord = TargetWord;
            this.MatchBeginning = MatchBeginning;
            this.AnyPosition = AnyPosition;
        }

        public override bool Equals(object obj)
        {
            var _cast = obj as Exclusion;
            if (_cast == null)
                return false;
            return _cast.sourceWord == sourceWord &&
                _cast.targetWord == targetWord &&
                _cast.matchCase == matchCase &&
                _cast.matchBeginning == matchBeginning &&
                _cast.anyPosition == anyPosition;
        }

        protected Exclusion() { }
    }
}
