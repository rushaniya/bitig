using System;
using System.ComponentModel;

namespace Bitig.UI.Controls
{
    public class ctlCustomCombo : System.Windows.Forms.ComboBox
    {
        public event EventHandler<CancelEventArgs> SelectedIndexChanging;

        private int lastAcceptedIndex = -1;

        public ctlCustomCombo()
            : base()
        {
            this.SelectedIndexChanging += new EventHandler<CancelEventArgs>(ctlCustomCombo_SelectedIndexChanging);
        }

        private void ctlCustomCombo_SelectedIndexChanging(object sender, CancelEventArgs e)
        {
            
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (lastAcceptedIndex != SelectedIndex)
            {
                CancelEventArgs _cancelArgs = new CancelEventArgs();
                SelectedIndexChanging(this, _cancelArgs);
                if (!_cancelArgs.Cancel)
                {
                    lastAcceptedIndex = SelectedIndex;
                    base.OnSelectedIndexChanged(e);
                }
                else SelectedIndex = lastAcceptedIndex;
            }
        }
    }
}
