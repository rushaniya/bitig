namespace Bitig.UI.Utilities
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

    internal enum ENumericListStyle
    {
        Arabic = 2,
        LCLetter = 3,
        UCLetter = 4,
        LCRoman = 5,
        UCRoman = 6
    }

    internal enum ENumericListFormat
    {
        Parenthesis,
        Parentheses = 0x100,
        Period = 0x200,
        Plain = 0x300
    }

    internal enum EAlignment
    {
        Left,
        Right,
        Center,
        Justified
    }

    internal class UtilityFinctions
    {
        internal static int CentimetersToTwips(double Centimeters)
        {
            return (int)(Centimeters * 567);
        }

        internal static double TwipsToCentimeters(int Twips)
        {
            return (double) Twips / 567;
        }
    }
}