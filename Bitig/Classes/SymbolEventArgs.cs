using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitig.UI.Classes
{
    class SymbolEventArgs : EventArgs
    {
        string text = string.Empty;

        public string Text
        {
            get { return text; }
            set { text = value ?? string.Empty; }
        }

        internal SymbolEventArgs(string Text)
        {
            this.text = Text ?? string.Empty;
        }
    }
}
