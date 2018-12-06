namespace Bitig.Logic.Model
{
    public class Exclusion : Bitig.Base.Exclusion
    {
        public Exclusion(string SourceWord, string TargetWord, bool MatchCase, bool MatchBeginning, bool AnyPosition) 
            : base(SourceWord, TargetWord, MatchCase, MatchBeginning, AnyPosition)
        {
        }

        public Exclusion()
        {

        }
    }
}
