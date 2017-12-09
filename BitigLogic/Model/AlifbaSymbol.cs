using System;

namespace Bitig.Logic.Model
{
    public class AlifbaSymbol
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

        public AlifbaSymbol(string ActualText, string DisplayText = null, string CapitalizedText = null, string CapitilzedDisplayText = null)
        {
            if (ActualText == null)
                throw new ArgumentNullException("ActualText");
            this.actualText = ActualText.Trim();
            this.displayText = string.IsNullOrEmpty(DisplayText) ? this.actualText : DisplayText.Trim();
            this.capitalizedText = CapitalizedText == null ? null : CapitalizedText.Trim();
            this.capitalizedDisplayText = string.IsNullOrEmpty(CapitilzedDisplayText) ? this.capitalizedText : CapitilzedDisplayText.Trim();
        }

        public AlifbaSymbol()
        {

        }
    }
}
