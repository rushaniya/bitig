using Bitig.Logic.Model;

namespace Bitig.Data.Model
{
    public class XmlTextSymbol
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

        internal XmlTextSymbol Clone()
        {
            return new XmlTextSymbol
            {
                ActualText = ActualText,
                CapitalizedText = CapitalizedText
            };
        }
    }
}
