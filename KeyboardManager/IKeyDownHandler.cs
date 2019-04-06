using System.Windows.Forms;

namespace Bitig.KeyboardManagement
{
    interface IKeyDownHandler
    {
        void HandleKeyDown(TextBoxBase textBox, KeyEventArgs e);
    }
}
