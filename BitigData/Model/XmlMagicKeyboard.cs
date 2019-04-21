using System.Linq;
using System.Xml.Serialization;
using Bitig.Base;
using Bitig.Data.Serialization;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{

    [XmlRoot("Config")]
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
        public string Symbol { get; set; }
        public string WithMagic { get; set; }

        public XmlMagicKeyCombination Clone()
        {
            return new XmlMagicKeyCombination
            {
                Symbol = Symbol,
                WithMagic = WithMagic
            };
        }

        public MagicKeyCombination ToModel()
        {
            return new MagicKeyCombination
            {
                Symbol = Symbol.Single(),
                WithMagic = WithMagic
            };
        }
    }
}
