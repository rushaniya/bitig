using System.Windows.Forms;
using Bitig.Base;

namespace Bitig.KeyboardManagement
{
    public class KeyboardManager
    {
        private TextBoxBase _textBox;

        IKeyDownHandler _currentKeyDownHandler;

        public bool IsAttached
        {
            get { return _textBox != null; }
        }

        public void SetKeyboardLayout(KeyboardLayoutBase config)
        {
            if (config is KeyboardLayout)
                _currentKeyDownHandler = new KeyboardHandler(config as KeyboardLayout);
            else if (config is MagicKeyboardLayout)
                _currentKeyDownHandler = new MagicKeyboardHandler(config as MagicKeyboardLayout);
        }

        public void AttachTo(TextBoxBase textBox)
        {
            _textBox = textBox;
            textBox.KeyDown += keyDown;
        }

        public void Detach()
        {
            if (_textBox == null)
                return;
            _textBox.KeyDown -= keyDown;
            _textBox = null;
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (_currentKeyDownHandler == null)
                return;
            var textBox = sender as TextBoxBase;
            if (textBox == null)
                return;
            _currentKeyDownHandler.HandleKeyDown(textBox, e);
        }
    }
}
