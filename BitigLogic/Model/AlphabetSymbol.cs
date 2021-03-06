﻿using System;

namespace Bitig.Logic.Model
{
    public class TextSymbol
    {

        protected string actualText = string.Empty;

        public string ActualText
        {
            get { return actualText; }
            set { actualText = value; }
        }

        protected string capitalizedText = string.Empty;

        public string CapitalizedText
        {
            get { return capitalizedText; }
            set { capitalizedText = value; }
        }

        public TextSymbol()
        {

        }

        public TextSymbol(string ActualText, string CapitalizedText = null, string DisplayText = null, string CapitilzedDisplayText = null)
        {
            if (ActualText == null)
                throw new ArgumentNullException("ActualText");
            this.actualText = ActualText.Trim();
            this.capitalizedText = CapitalizedText == null ? null : CapitalizedText.Trim();
        }

        public override bool Equals(object obj)
        {
            var _cast = obj as TextSymbol;
            if (_cast == null)
                return false;
            return _cast.actualText == actualText &&
                _cast.capitalizedText == capitalizedText;
        }

        public override int GetHashCode()
        {
            var _hash = 0;
            if (actualText != null) _hash += 7 * actualText.GetHashCode();
            if (capitalizedText != null) _hash += 13 * capitalizedText.GetHashCode();
            return _hash;
        }

    }
    public class AlphabetSymbol : TextSymbol
    {
        public bool IsOnScreen { get; set; }

        private string displayText = string.Empty;

        public string DisplayText
        {
            get { return displayText; }
            set { displayText = value; }
        }

        private string capitalizedDisplayText = string.Empty;

        public string CapitalizedDisplayText
        {
            get { return capitalizedDisplayText; }
            set { capitalizedDisplayText = value; }
        }

        //ctor needed for data grids
        public AlphabetSymbol()
        {
            IsOnScreen = true;
        }

        public AlphabetSymbol(string ActualText, string CapitalizedText = null, string DisplayText = null, string CapitalizedDisplayText = null, bool IsOnScreen = true)
            : base (ActualText, CapitalizedText, DisplayText, CapitalizedDisplayText)
        {
            this.IsOnScreen = IsOnScreen;
            this.displayText = string.IsNullOrEmpty(DisplayText) ? this.ActualText : DisplayText.Trim();
            this.capitalizedDisplayText = string.IsNullOrEmpty(CapitalizedDisplayText) ? this.capitalizedText : CapitalizedDisplayText.Trim();
        }

        public override bool Equals(object obj)
        {
            var _cast = obj as AlphabetSymbol;
            if (_cast == null)
                return false;
            return _cast.actualText == actualText &&
                _cast.displayText == displayText &&
                _cast.capitalizedText == capitalizedText &&
                _cast.capitalizedDisplayText == capitalizedDisplayText;
        }

        public override int GetHashCode()
        {
            var _hash = 0;
            if (actualText != null) _hash += 7 * actualText.GetHashCode();
            if (displayText != null) _hash += 11 * displayText.GetHashCode();
            if (capitalizedText != null) _hash += 13 * capitalizedText.GetHashCode();
            if (capitalizedDisplayText != null) _hash += 17 * capitalizedDisplayText.GetHashCode();
            return _hash;
        }
    }
}
