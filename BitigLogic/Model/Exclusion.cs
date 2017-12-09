using Bitig.Logic.Repository;

namespace Bitig.Logic.Model
{
    public class Exclusion : Bitig.Base.Exclusion, IDeepCloneable<Exclusion>
    {
        //private int id = -1;

        //public int ID
        //{
        //    get { return id; }
        //    set
        //    {
        //        id = value;
        //    }
        //}

       // public Direction Direction { get; set; }

        public Exclusion Clone()
        {
            return new Exclusion
            {
                AnyPosition = AnyPosition,
                MatchCase = MatchCase,
                MatchBeginning = MatchBeginning,
                SourceWord = SourceWord,
                TargetWord = TargetWord
            };
        }

        //public override bool Equals(object obj)
        //{
        //    var cast = obj as Exclusion;
        //    if (cast == null)
        //        return false;
        //    return cast.ID.Equals(this.ID);
        //}
    }
}
