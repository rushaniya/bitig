namespace Bitig.RtbControl.Utilities
{
    public class MessageArgs : System.EventArgs
    {
        private string message = string.Empty;

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        private EMessageTypes messageType;

        public EMessageTypes MessageType
        {
            get { return messageType; }
            set { messageType = value; }
        }

        public MessageArgs(string Message, EMessageTypes MessageType)
            : base()
        {
            this.message = Message;
            this.messageType = MessageType;
        }

        public enum EMessageTypes
        {
            FileNameChanged
        }
    }

    public enum ENumericListType : ushort
    {
        None = 0,
        Bullet = CRichTextBox.PFN_BULLET,
        Arabic = CRichTextBox.PFN_ARABIC,
        LCLetter = CRichTextBox.PFN_LCLETTER,
        UCLetter = CRichTextBox.PFN_UCLETTER,
        LCRoman = CRichTextBox.PFN_LCROMAN,
        UCRoman = CRichTextBox.PFN_UCROMAN
    }

    public enum ENumericListFormat : ushort
    {
        Parenthesis = CRichTextBox.PFNS_PAREN,
        Parentheses = CRichTextBox.PFNS_PARENS,
        Period = CRichTextBox.PFNS_PERIOD,
        Plain = CRichTextBox.PFNS_PLAIN,
       // NoNumber = CRichTextBox.PFNS_NONUMBER
    }

    internal enum EAlignment : ushort
    {
        Left = CRichTextBox.PFA_LEFT,
        Right = CRichTextBox.PFA_RIGHT,
        Center = CRichTextBox.PFA_CENTER,
        Justified = CRichTextBox.PFA_JUSTIFY
    }

    internal class UtilityFinctions
    {
        internal static ushort CentimetersToTwips(double Centimeters)
        {
            return (ushort)(Centimeters * 567);
        }

        internal static double TwipsToCentimeters(ushort Twips)
        {
            return (double) Twips / 567;
        }
    }
}