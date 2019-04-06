using System.Windows.Forms;
using Bitig.Base;

namespace Bitig.KeyboardManagement
{
    public class KeyboardManager
    {
        private bool _isAttached;

        IKeyDownHandler _currentKeyDownHandler;

        public bool IsAttached
        {
            get { return _isAttached; }
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
            if (_currentKeyDownHandler == null)
                return;
            var textBox = sender as TextBoxBase;
            if (textBox == null)
                return;
            _currentKeyDownHandler.HandleKeyDown(textBox, e);
        }
    }
}
