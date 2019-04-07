using System.Linq;
using Bitig.Data.Serialization;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{

    public class XmlMagicKeyboard : XmlCollectionConfig<XmlMagicKeyCombination>, IDeepCloneable<XmlMagicKeyboard>
    {

        public string MagicKey { get; set; }

        public new XmlMagicKeyboard Clone()
        {
            return new XmlMagicKeyboard
            {
                ID = ID,
                MagicKey = MagicKey,
                Collection = Collection.Select(x => x.Clone()).ToList()
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
