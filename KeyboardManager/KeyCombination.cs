using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Bitig.KeyboardManagement
{
    public class KeyCombination
    {
        public Keys MainKey { get; set; }
        public bool WithShift { get; set; }
        public bool WithCtrl { get; set; }
        public bool WithAlt { get; set; }
        public bool WithAltGr { get; set; }
        public bool WithCapsLock { get; set; }

        public override bool Equals(object obj)
        {
            var target = obj as KeyCombination;
            if (target == null)
                return false;
            return target.MainKey == MainKey &&
                target.WithAlt == WithAlt &&
                target.WithAltGr == WithAltGr &&
                target.WithCtrl == WithCtrl &&
                target.WithShift == WithShift &&
                target.WithCapsLock == WithCapsLock;
        }

        public override int GetHashCode()
        {
            var hash = 0;
            hash += 3 * MainKey.GetHashCode();
            hash += 7 * WithAlt.GetHashCode();
            hash += 11 * WithAltGr.GetHashCode();
            hash += 13 * WithCtrl.GetHashCode();
            hash += 17 * WithShift.GetHashCode();
            hash += 19 * WithCapsLock.GetHashCode();
            return hash;
        }

        public static Keys ConvertToKeysEnum(string keyName)
        {
            keyName = keyName.ToUpperInvariant();
            if (keyName.Length == 1)
            {
                var unicode = (int)keyName[0];
                //A U+0041
                //Z U+005A
                if (unicode >= 0x41 && unicode <= 0x5A)
                {
                    return (Keys)Enum.Parse(typeof(Keys), keyName);
                }
                //0 U+0030
                //9 U+0039
                if (unicode >= 0x30 && unicode <= 0x0039)
                {
                    return (Keys)Enum.Parse(typeof(Keys), "D" + keyName);
                }
                switch (keyName)
                {
                    case "`":
                        return Keys.Oemtilde;
                    case "-":
                        return Keys.OemMinus;
                    case "=":
                        return Keys.Oemplus;
                    case "[":
                        return Keys.OemOpenBrackets;
                    case "]":
                        return Keys.OemCloseBrackets;
                    case "\\":
                        return Keys.Oem5;
                    case ";":
                        return Keys.OemSemicolon;
                    case "'":
                        return Keys.OemQuotes;
                    case ",":
                        return Keys.Oemcomma;
                    case ".":
                        return Keys.OemPeriod;
                    case "/":
                        return Keys.OemQuestion;
                }
            }
            switch (keyName)
            {
                case "ENTER":
                    return Keys.Return;
                case "SPACE":
                    return Keys.Space;
                case "DIVIDE":
                    return Keys.Divide;
                case "MULTIPLY":
                    return Keys.Multiply;
                case "SUBTRACT":
                    return Keys.Subtract;
                case "ADD":
                    return Keys.Add;
                case "DECIMAL":
                    return Keys.Decimal;
            }
            var numMatch = Regex.Match(keyName, @"NUM(?<digit>\d{1})");
            if (numMatch.Success)
            {
                return (Keys)Enum.Parse(typeof(Keys), "NumPad" + numMatch.Groups["digit"]);
            }
            throw new ArgumentException("Cannot convert to key: " + keyName);
        }
    }
}
