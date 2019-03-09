using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bitig.Base;

namespace Bitig.KeyboardManagement
{
    public class KeyboardManager
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private HashSet<Keys> _mainKeys;
        private Dictionary<KeyCombination, string> _keyCombinations;
        private bool _isAttached;

        public bool IsAttached
        {
            get { return _isAttached; }
        }

        public void SetKeyboardLayout(KeyboardLayout config)
        {
            _keyCombinations = convertToKeyDictionary(config.KeyCombinations);
            _mainKeys = new HashSet<Keys>(_keyCombinations.Keys.Select(x => x.MainKey).Distinct());
        }

        private Dictionary<KeyCombination, string> convertToKeyDictionary(List<Base.KeyCombination> keyCombinations)
        {
            var dictionary = new Dictionary<KeyCombination, string>();
            foreach (var keyCombination in keyCombinations)
            {
                var mainKey = KeyCombination.ConvertToKeysEnum(keyCombination.MainKey);
                dictionary.Add(new KeyCombination
                {
                    MainKey = mainKey,
                    WithAlt = keyCombination.WithAlt,
                    WithAltGr = keyCombination.WithAltGr,
                    WithCtrl = keyCombination.WithCtrl,
                    WithShift = keyCombination.WithShift
                }, keyCombination.Result);
                if (!string.IsNullOrEmpty(keyCombination.Capital))
                {
                    //kbl: check duplicates?
                    dictionary.Add(new KeyCombination
                    {
                        MainKey = mainKey,
                        WithAlt = keyCombination.WithAlt,
                        WithAltGr = keyCombination.WithAltGr,
                        WithCtrl = keyCombination.WithCtrl,
                        WithShift = true
                    }, keyCombination.Capital);
                    dictionary.Add(new KeyCombination
                    {
                        MainKey = mainKey,
                        WithAlt = keyCombination.WithAlt,
                        WithAltGr = keyCombination.WithAltGr,
                        WithCtrl = keyCombination.WithCtrl,
                        WithCapsLock = true
                    }, keyCombination.Capital);
                    dictionary.Add(new KeyCombination
                    {
                        MainKey = mainKey,
                        WithAlt = keyCombination.WithAlt,
                        WithAltGr = keyCombination.WithAltGr,
                        WithCtrl = keyCombination.WithCtrl,
                        WithShift = true,
                        WithCapsLock = true
                    }, keyCombination.Result);
                }
            }
            return dictionary;
        }

        public void AttachTo(TextBoxBase textBox)
        {
            textBox.KeyDown += keyDown;
            _isAttached = true;
        }

        public void DetachFrom(TextBoxBase textBox)
        {
            textBox.KeyDown -= keyDown;
            _isAttached = false;
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
            if (Control.IsKeyLocked(Keys.CapsLock))
                combination.WithCapsLock = true;
            return combination;
        }

        private bool isMeaningfulKey(Keys keyCode)
        {
            return _mainKeys.Contains(keyCode);
        }
    }
}
