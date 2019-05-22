using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bitig.KeyboardManagement
{
    public static class KeysParser
    {
        private static Dictionary<string, Keys> _keyNameDictionary;
        private static Dictionary<Keys, string> _keyEnumDictionary;

        static KeysParser()
        {
            _keyNameDictionary = new Dictionary<string, Keys>();
            _keyEnumDictionary = new Dictionary<Keys, string>();
            //A U+0041
            //Z U+005A
            for (char i = (char)0x41; i <= 0x5A; i++)
            {
                var keyName = i.ToString();
                var keyEnum = (Keys)Enum.Parse(typeof(Keys), keyName);
                _keyNameDictionary.Add(keyName, keyEnum);
            }
            for (int i = 0; i <= 9; i++)
            {
                var keyName = i.ToString();
                var keyEnum = (Keys)Enum.Parse(typeof(Keys), "D" + keyName);
                _keyNameDictionary.Add(keyName, keyEnum);
                var numKeyName = "NUM" + i;
                var numKeyEnum = (Keys)Enum.Parse(typeof(Keys), "NumPad" + keyName);
                _keyNameDictionary.Add(numKeyName, numKeyEnum);
            }
            _keyNameDictionary.Add("`", Keys.Oemtilde);
            _keyNameDictionary.Add("-", Keys.OemMinus);
            _keyNameDictionary.Add("=", Keys.Oemplus);
            _keyNameDictionary.Add("[", Keys.OemOpenBrackets);
            _keyNameDictionary.Add("]", Keys.OemCloseBrackets);
            _keyNameDictionary.Add("\\", Keys.Oem5);
            _keyNameDictionary.Add(";", Keys.OemSemicolon);
            _keyNameDictionary.Add("'", Keys.OemQuotes);
            _keyNameDictionary.Add(",", Keys.Oemcomma);
            _keyNameDictionary.Add(".", Keys.OemPeriod);
            _keyNameDictionary.Add("/", Keys.OemQuestion);
            _keyNameDictionary.Add("ENTER", Keys.Return);
            _keyNameDictionary.Add("SPACE", Keys.Space);
            _keyNameDictionary.Add("DIVIDE", Keys.Divide);
            _keyNameDictionary.Add("MULTIPLY", Keys.Multiply);
            _keyNameDictionary.Add("SUBTRACT", Keys.Subtract);
            _keyNameDictionary.Add("ADD", Keys.Add);
            _keyNameDictionary.Add("DECIMAL", Keys.Decimal);
            foreach (var keyName in _keyNameDictionary)
            {
                _keyEnumDictionary.Add(keyName.Value, keyName.Key);
            }
        }

        public static Keys ConvertToKeysEnum(string keyName)
        {
            var keyNameUpper = keyName.ToUpperInvariant();
            if (_keyNameDictionary.ContainsKey(keyNameUpper))
                return _keyNameDictionary[keyNameUpper];
            //throw new ArgumentException("Invalid key name.");
            return (Keys)Enum.Parse(typeof(Keys), keyName);
        }

        public static string ConvertKeysToString(Keys key)
        {
            if (_keyEnumDictionary.ContainsKey(key))
                return _keyEnumDictionary[key];
            return key.ToString();
        }

        public static string KeyStrokeToString(KeyStroke keyStroke)
        {
            var keyNames = new List<string>();
            if (keyStroke.WithCtrl)
                keyNames.Add("Ctrl");
            if (keyStroke.WithShift)
                keyNames.Add("Shift");
            if (keyStroke.WithAlt)
            {
                keyNames.Add("Alt");
            }
            if (keyStroke.WithAltGr)
            {
                keyNames.Add("AltGr");
            }
            keyNames.Add(ConvertKeysToString(keyStroke.MainKey));
            var description = string.Join("+", keyNames.ToArray());
            return description;
        }

        public static KeyStroke ParseKeyStroke(string combination)
        {
            var result = new KeyStroke();
            var combinationUpper = combination.ToUpperInvariant();
            var splitted = combinationUpper.Split(new[] { '+' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitted.Length == 1)
                result.MainKey = ConvertToKeysEnum(splitted[0]);
            else
            {
                foreach (var part in splitted)
                {
                    switch (part)
                    {
                        case "ALT":
                            result.WithAlt = true;
                            break;
                        case "ALTGR":
                            result.WithAltGr = true;
                            break;
                        case "CTRL":
                            result.WithCtrl = true;
                            break;
                        case "SHIFT":
                            result.WithShift = true;
                            break;
                        default:
                            result.MainKey = ConvertToKeysEnum(part);
                            break;
                    }
                }
            }
            return result;
        }
    }
}
