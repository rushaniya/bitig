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

        public XmlAlifbaSymbol()
        {

        }
    }
}
