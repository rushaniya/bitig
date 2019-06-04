using System.Collections.Generic;
using System.Windows.Forms;
using Bitig.Base;

namespace Bitig.KeyboardManagement
{
    class MagicKeyboardHandler : IKeyDownHandler
    {

        private Keys _magicKey;
        private Dictionary<char, string> _magicCombinations = new Dictionary<char, string>();

        public MagicKeyboardHandler(MagicKeyboardLayout config)
        {
            _magicKey = config.MagicKey;
            _magicCombinations.Clear();
            foreach (var magicCombination in config.KeyCombinations)
            {
                _magicCombinations.Add(magicCombination.Symbol, magicCombination.WithMagic);
            }
        }

        public void HandleKeyDown(TextBoxBase textBox, KeyEventArgs e)
        {
            if (e.KeyCode == _magicKey && textBox.SelectionStart > 0 && textBox.SelectionLength == 0)
            {
                var previousLetter = textBox.Text[textBox.SelectionStart - 1];
                if (_magicCombinations.ContainsKey(previousLetter))
                {
                    textBox.Select(textBox.SelectionStart - 1, 1);
                    textBox.SelectedText = _magicCombinations[previousLetter];
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
        }
    }
}
