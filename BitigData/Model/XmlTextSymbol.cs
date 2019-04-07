using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlTextSymbol : IDeepCloneable<XmlTextSymbol>
    {

        public string ActualText
        {
            get; set;
        }

        public string CapitalizedText
        {
            get; set;
        }

        public XmlTextSymbol()
        {

        }

        public XmlTextSymbol(TextSymbol ModelSymbol)
        {
            ActualText = ModelSymbol.ActualText;
            CapitalizedText = ModelSymbol.CapitalizedText;
        }

        internal TextSymbol ToModel()
        {
            return new TextSymbol(ActualText, CapitalizedText);
        }

        public XmlTextSymbol Clone()
        {
            return new XmlTextSymbol
            {
                ActualText = ActualText,
                CapitalizedText = CapitalizedText
            };
        }
    }
}
