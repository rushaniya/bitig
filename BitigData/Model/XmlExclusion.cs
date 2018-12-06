using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlExclusion : IDeepCloneable<XmlExclusion>
    {

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

        public Exclusion ToModel()
        {
            return new Exclusion(SourceWord, TargetWord, MatchCase, MatchBeginning, AnyPosition);
        }

        public XmlExclusion Clone()
        {
            return new XmlExclusion
            {
                AnyPosition = AnyPosition,
                MatchCase = MatchCase,
                MatchBeginning = MatchBeginning,
                SourceWord = SourceWord,
                TargetWord = TargetWord
            };
        }

        public XmlExclusion()
        {

        }

        public XmlExclusion(Exclusion ModelExclusion)
        {
            AnyPosition = ModelExclusion.AnyPosition;
            MatchBeginning = ModelExclusion.MatchBeginning;
            MatchCase = ModelExclusion.MatchCase;
            SourceWord = ModelExclusion.SourceWord;
            TargetWord = ModelExclusion.TargetWord;
        }
    }
}
