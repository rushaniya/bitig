namespace Bitig.Base
{
    public abstract class KeyboardLayoutBase
    {
        public int ID { get; set; }
        public string FriendlyName { get; set; }
        public abstract KeyboardLayoutType Type { get; }

        public override string ToString()
        {
            return FriendlyName ?? string.Empty;
        }
    }

    public enum KeyboardLayoutType
    {
        Full,
        Magic
    }
}
