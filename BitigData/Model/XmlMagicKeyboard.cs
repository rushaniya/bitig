using System.Collections.Generic;
using System.Linq;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{

    public class XmlMagicKeyboard : EquatableByID<int>, IDeepCloneable<XmlMagicKeyboard>
    {
        public override int ID
        {
            get; set;
        }

        public List<XmlMagicKeyCombination> MagicKeyCombinations { get; set; }

        public string MagicKey { get; set; }

        public XmlMagicKeyboard Clone()
        {
            return new XmlMagicKeyboard
            {
                ID = ID,
                MagicKey = MagicKey,
                MagicKeyCombinations = MagicKeyCombinations.Select(x => x.Clone()).ToList()
            };
        }
    }
    public class XmlMagicKeyCombination : IDeepCloneable<XmlMagicKeyCombination>
    {
        public char Symbol { get; set; }
        public string WithMagic { get; set; }

        public XmlMagicKeyCombination Clone()
        {
            return new XmlMagicKeyCombination
            {
                Symbol = Symbol,
                WithMagic = WithMagic
            };
        }
    }
}
