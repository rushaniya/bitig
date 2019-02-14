﻿using Bitig.Logic.Model;

namespace Bitig.Data.Model
{
    public class XmlAlifbaSymbol
    {

        private string actualText = string.Empty;

        public string ActualText
        {
            get { return actualText; }
            set { actualText = value; }
        }

        private string displayText = string.Empty;

        public string DisplayText
        {
            get { return displayText; }
            set { displayText = value; }
        }

        private string capitalizedText = string.Empty;

        public string CapitalizedText
        {
            get { return capitalizedText; }
            set { capitalizedText = value; }
        }

        private string capitalizedDisplayText = string.Empty;

        public string CapitalizedDisplayText
        {
            get { return capitalizedDisplayText; }
            set { capitalizedDisplayText = value; }
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

        internal AlifbaSymbol ToModel()
        {
            return new AlifbaSymbol(ActualText, CapitalizedText,
                DisplayText, CapitalizedDisplayText, IsAlphabetic, IsOnScreen);
        }

        internal XmlAlifbaSymbol Clone()
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
