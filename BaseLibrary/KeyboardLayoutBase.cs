﻿namespace Bitig.Base
{
    public abstract class KeyboardLayoutBase
    {
        public int ID { get; set; }
        public string FriendlyName { get; set; }
        public abstract KeyboardLayoutType Type { get; }
    }

    public enum KeyboardLayoutType
    {
        Full,
        Magic
    }
}
