using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlAlphabetSymbol : XmlTextSymbol, IDeepCloneable<XmlAlphabetSymbol>
    {

        public string DisplayText
        {
            get; set;
        }

        public string CapitalizedDisplayText
        {
            get; set;
        }

        public bool IsOnScreen { get; set; }

        public XmlAlphabetSymbol()
        {

        }

        public XmlAlphabetSymbol(AlphabetSymbol ModelSymbol)
        {
            ActualText = ModelSymbol.ActualText;
            DisplayText = ModelSymbol.DisplayText;
            CapitalizedText = ModelSymbol.CapitalizedText;
            CapitalizedDisplayText = ModelSymbol.CapitalizedDisplayText;
            IsOnScreen = ModelSymbol.IsOnScreen;
        }

        internal new AlphabetSymbol ToModel()
        {
            return new AlphabetSymbol(ActualText, CapitalizedText,
                DisplayText, CapitalizedDisplayText, IsOnScreen);
        }

        public new XmlAlphabetSymbol Clone()
        {
            return new XmlAlphabetSymbol
            {
                ActualText = ActualText,
                DisplayText = DisplayText,
                CapitalizedText = CapitalizedText,
                CapitalizedDisplayText = CapitalizedDisplayText,
                IsOnScreen = IsOnScreen
            };
        }
    }
}
