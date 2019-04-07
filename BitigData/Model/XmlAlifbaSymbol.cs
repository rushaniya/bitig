﻿using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.Data.Model
{
    public class XmlAlifbaSymbol : XmlTextSymbol, IDeepCloneable<XmlAlifbaSymbol>
    {

        public string DisplayText
        {
            get; set;
        }

        public string CapitalizedDisplayText
        {
            get; set;
        }

        public bool IsAlphabetic { get; set; }

        public bool IsOnScreen { get; set; }

        public XmlAlifbaSymbol()
        {

        }

        public XmlAlifbaSymbol(AlifbaSymbol ModelSymbol)
        {
            ActualText = ModelSymbol.ActualText;
            DisplayText = ModelSymbol.DisplayText;
            CapitalizedText = ModelSymbol.CapitalizedText;
            CapitalizedDisplayText = ModelSymbol.CapitalizedDisplayText;
            IsAlphabetic = ModelSymbol.IsAlphabetic;
            IsOnScreen = ModelSymbol.IsOnScreen;
        }

        internal new AlifbaSymbol ToModel()
        {
            return new AlifbaSymbol(ActualText, CapitalizedText,
                DisplayText, CapitalizedDisplayText, IsAlphabetic, IsOnScreen);
        }

        public new XmlAlifbaSymbol Clone()
        {
            return new XmlAlifbaSymbol
            {
                ActualText = ActualText,
                DisplayText = DisplayText,
                CapitalizedText = CapitalizedText,
                CapitalizedDisplayText = CapitalizedDisplayText,
                IsAlphabetic = IsAlphabetic,
                IsOnScreen = IsOnScreen
            };
        }
    }
}
