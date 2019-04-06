using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bitig.Base;

namespace Bitig.KeyboardManagement
{
    class KeyboardHandler : IKeyDownHandler
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

        private HashSet<Keys> _mainKeys;
        private Dictionary<KeyCombination, string> _keyCombinations = new Dictionary<KeyCombination, string>();
        private HashSet<Keys> _considerCapsLock = new HashSet<Keys>();

        public KeyboardHandler(KeyboardLayout config)
        {
            fillKeyDictionary(config.KeyCombinations);
            _mainKeys = new HashSet<Keys>(_keyCombinations.Keys.Select(x => x.MainKey).Distinct());
        }

        public void HandleKeyDown(TextBoxBase textBox, KeyEventArgs e)
        {
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

        private void fillKeyDictionary(List<Base.KeyCombination> keyCombinations)
        {
            _keyCombinations.Clear();
            _considerCapsLock.Clear();
            foreach (var keyCombination in keyCombinations)
            {
                var mainKey = KeyCombination.ConvertToKeysEnum(keyCombination.MainKey);
                _keyCombinations.Add(new KeyCombination
                {
                    MainKey = mainKey,
                    WithAlt = keyCombination.WithAlt,
                    WithAltGr = keyCombination.WithAltGr,
                    WithCtrl = keyCombination.WithCtrl,
                    WithShift = keyCombination.WithShift
                }, keyCombination.Result);
                if (!string.IsNullOrEmpty(keyCombination.Capital))
                {
                    _considerCapsLock.Add(mainKey);
                    //kbl: check duplicates?
                    _keyCombinations.Add(new KeyCombination
                    {
                        MainKey = mainKey,
                        WithAlt = keyCombination.WithAlt,
                        WithAltGr = keyCombination.WithAltGr,
                        WithCtrl = keyCombination.WithCtrl,
                        WithShift = true
                    }, keyCombination.Capital);
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
            if (Control.IsKeyLocked(Keys.CapsLock) && _considerCapsLock.Contains(mainKey))
            {
                combination.WithShift = !combination.WithShift;
            }
            return combination;
        }

        private bool isMeaningfulKey(Keys keyCode)
        {
            return _mainKeys.Contains(keyCode);
        }
    }
}
