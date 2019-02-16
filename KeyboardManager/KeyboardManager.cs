using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bitig.Base;

namespace KeyboardManager
{
    public class KeyboardManager
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private HashSet<Keys> _mainKeys;
        private Dictionary<KeyCombination, string> _keyCombinations;

        public KeyboardManager(KeyboardConfig config)
        {
            _keyCombinations = config.KeyCombinations.ToDictionary(x => new KeyCombination
            {
                MainKey = KeyCombination.ConvertToKeysEnum(x.MainKey),
                WithAlt = x.WithAlt,
                WithAltGr = x.WithAltGr,
                WithCtrl = x.WithCtrl,
                WithShift = x.WithShift
            }, x => x.Result);
            _mainKeys = new HashSet<Keys>(_keyCombinations.Keys.Select(x => x.MainKey).Distinct());
        }

        public void AttachTo(TextBoxBase textBox)
        {
            textBox.KeyDown += keyDown;
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBoxBase;
            if (textBox == null)
                return;
            if (isMeaningfulKey(e.KeyCode))
            {
                var keyCombination = getCurrentCombination(e.KeyCode);
                if (_keyCombinations.ContainsKey(keyCombination))
                {
                    textBox.SelectedText = _keyCombinations[keyCombination];
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }

        private KeyCombination getCurrentCombination(Keys mainKey)
        {
            var combination = new KeyCombination { MainKey = mainKey };
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)) || Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)))
                combination.WithShift = true;
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)) || Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)))
            {
                //keyboard layouts that support AltGr emit Ctrl+Alt instead of just Alt
                if (!Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)))
                    combination.WithCtrl = true;
            }
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)))
                combination.WithAlt = true;
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)))
                combination.WithAltGr = true;
            return combination;
        }

        private bool isMeaningfulKey(Keys keyCode)
        {
            /*  return keyCode == Keys.Return ||
                  keyCode == Keys.Space ||
                  keyCode >= Keys.D0 && keyCode <= Keys.D9 ||
                  keyCode >= Keys.A && keyCode <= Keys.Z ||
                  keyCode >= Keys.NumPad0 && keyCode <= Keys.Divide ||
                  keyCode >= Keys.Oemplus && keyCode <= Keys.Oemtilde ||
                  keyCode >= Keys.OemOpenBrackets && keyCode <= Keys.Oem8 ||
                  keyCode == Keys.OemBackslash;*/
            return _mainKeys.Contains(keyCode);
        }
    }
}
