using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bitig.Base;
using Bitig.KeyboardManagement;

namespace KeyboardTestApp
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);


        public Form1()
        {
            InitializeComponent();
            //  textBox.KeyUp += keyUp;
            //  textBox.KeyPress += keyPress;
            //  textBox.KeyDown += keyDown;
            var keyManager = new KeyboardManager();
            keyManager.SetKeyboardLayout(new MagicKeyboardLayout
            {
                MagicKey = Keys.Enter,
                KeyCombinations = new List<MagicKeyCombination>
                {
                    new MagicKeyCombination { Symbol='f', WithMagic = "ф"},
                    new MagicKeyCombination { Symbol='F', WithMagic = "Ф"},
                }
            });
            keyManager.AttachTo(textBox);
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            label.Text += string.Format("key down: key {0} ({4}) data {1} value {2} ({3})\r\n", e.KeyCode, e.KeyData, e.KeyValue, (char)e.KeyValue, (int)e.KeyCode);
            if (isMeaningfulKey(e.KeyCode))
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                textBox.SelectedText = getCombinationName(e.KeyCode) + Environment.NewLine;
            }

        }

        private void keyPress(object sender, KeyPressEventArgs e)
        {
            label.Text += "keyPress: " + e.KeyChar.ToString() + Environment.NewLine;
        }

        public void keyUp(object sender, KeyEventArgs e)
        {
            label.Text += "keyUp: " + e.KeyData.ToString() + Environment.NewLine;
        }

        private bool isMeaningfulKey(Keys keyCode)
        {
            return keyCode == Keys.Return ||
                keyCode == Keys.Space ||
                keyCode >= Keys.D0 && keyCode <= Keys.D9 ||
                keyCode >= Keys.A && keyCode <= Keys.Z ||
                keyCode >= Keys.NumPad0 && keyCode <= Keys.Divide ||
                keyCode >= Keys.OemSemicolon && keyCode <= Keys.Oemtilde ||
                keyCode >= Keys.OemOpenBrackets && keyCode <= Keys.OemCloseBrackets;
                // ? || keyCode == Keys.OemBackslash;
        }

        private string getCombinationName(Keys keyCode)
        {
            var keyNames = new List<string>();
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.LControlKey)) || Convert.ToBoolean(GetAsyncKeyState(Keys.RControlKey)))
                keyNames.Add("Ctrl");
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)) || Convert.ToBoolean(GetAsyncKeyState(Keys.RShiftKey)))
                keyNames.Add("Shift");
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.LMenu)))
            {
                keyNames.Add("Alt");
            }
            if (Convert.ToBoolean(GetAsyncKeyState(Keys.RMenu)))
            {
                keyNames.Add("AltGr");
            }
            keyNames.Add(keyCode.ToString());
            var description = string.Join("+", keyNames.ToArray());
            return description;
        }
    }
}
