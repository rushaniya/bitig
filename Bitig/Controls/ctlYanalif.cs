using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bitig.Logic.Model;
using Bitig.UI.Configuration;
using Bitig.UI.Logic;

namespace Bitig.UI.Controls
{
    public partial class ctlYanalif : UserControl
    {
        internal event EventHandler<SymbolEventArgs> SymbolPressed;
        private List<ToolStripButton> x_CustomButtons = new List<ToolStripButton>();

        private bool x_CapitalizeYanalif;
        private bool x_HoldCapitalizeButton;

        public List<AlphabetSymbol> X_CustomSymbols
        {
            get; set;
        }

        public ctlYanalif()
        {
            InitializeComponent();
            this.SymbolPressed += new EventHandler<SymbolEventArgs>(ctlYanalif_SymbolPressed);
        }

        private void ctlYanalif_Load(object sender, EventArgs e)
        {
            SetAlphabetTags();
            SetKeyboard();
        }

        public void ResetLetters()
        {
            btnCapitalize.Checked = false;
            SetKeyboard();
        }

        private void ctlYanalif_SymbolPressed(object sender, SymbolEventArgs e)
        {
            
        }

        private void btnCustomLetters_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                AlphabetSymbol _symbol = (sender as ToolStripButton).Tag as AlphabetSymbol;
                if (_symbol != null)
                {
                    if (btnCapitalize.Visible && btnCapitalize.Checked)
                    {
                        if (string.IsNullOrEmpty(_symbol.CapitalizedText))
                            SymbolPressed(this, new SymbolEventArgs(_symbol.ActualText));
                        else
                            SymbolPressed(this, new SymbolEventArgs(_symbol.CapitalizedText));
                        if (!x_HoldCapitalizeButton) btnCapitalize.Checked = false;
                    }
                    else
                    {
                        SymbolPressed(this, new SymbolEventArgs(_symbol.ActualText));
                    }
                }
            }
        }

        private void btnYanalifLetters_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                SymbolPressed(this, new SymbolEventArgs((string)(sender as ToolStripButton).Tag));
                if (btnCapitalize.Checked && !x_HoldCapitalizeButton) btnCapitalize.Checked = false;
            }
        }

        private void btnCapitalize_CheckedChanged(object sender, EventArgs e)
        {
            if (x_CapitalizeYanalif) SetAlphabetCapitals();
            if (btnCapitalize.Checked)
            {
                foreach (ToolStripButton _btn in x_CustomButtons)
                {
                    AlphabetSymbol _symbol = _btn.Tag as AlphabetSymbol;
                    if (_symbol != null && !string.IsNullOrEmpty(_symbol.CapitalizedDisplayText))
                        _btn.Text = _symbol.CapitalizedDisplayText;
                }
            }
            else
            {
                foreach (ToolStripButton _btn in x_CustomButtons)
                {
                    AlphabetSymbol _symbol = _btn.Tag as AlphabetSymbol;
                    if (_symbol != null)
                        _btn.Text = _symbol.DisplayText;
                }
                x_HoldCapitalizeButton = false;
            }
        }

        private void btnCapitalize_DoubleClick(object sender, EventArgs e)
        {
            x_HoldCapitalizeButton = true;
        }

        private void SetKeyboard()
        {
            //config:remove 'user button visible' settings
            SetCustomButtons();
            SetCapitalizeButton();
            x_CapitalizeYanalif = !TempConfig.ShowAllYanalifSymbols && btnCapitalize.Visible;
            if (x_CapitalizeYanalif && btnCapitalize.Visible)
                SetAlphabetCapitals();
        }

        private void SetAlphabetTags()
        {
            btnAlifA.Tag = "\u0259";
            btnAlifAzur.Tag = "\u018f";
            btnAlifC.Tag = "\u00e7";
            btnAlifCzur.Tag = "\u00c7";
            btnAlifG.Tag = "\u011f";
            btnAlifGzur.Tag = "\u011e";
            btnAlifI.Tag = "\u0131";
            btnAlifIzur.Tag = "\u0130";
            btnAlifN.Tag = "\ua791";
            btnAlifNzur.Tag = "\ua790";
            btnAlifO.Tag = "\u0275";
            btnAlifOzur.Tag = "\u019f";
            btnAlifS.Tag = "\u015f";
            btnAlifSzur.Tag = "\u015e";
            btnAlifU.Tag = "\u00fc";
            btnAlifUzur.Tag = "\u00dc";
        }

        private void SetAlphabetCapitals()
        {
            if (btnCapitalize.Checked)
            {
                btnAlifA.Visible = false;
                btnAlifAzur.Visible = true;
                btnAlifC.Visible = false;
                btnAlifCzur.Visible = true;
                btnAlifG.Visible = false;
                btnAlifGzur.Visible = true;
                btnAlifI.Visible = false;
                btnAlifIzur.Visible = true;
                btnAlifN.Visible = false;
                btnAlifNzur.Visible = true;
                btnAlifO.Visible = false;
                btnAlifOzur.Visible = true;
                btnAlifS.Visible = false;
                btnAlifSzur.Visible = true;
                btnAlifU.Visible = false;
                btnAlifUzur.Visible = true;
            }
            else
            {
                btnAlifA.Visible = true;
                btnAlifAzur.Visible = false;
                btnAlifC.Visible = true;
                btnAlifCzur.Visible = false;
                btnAlifG.Visible = true;
                btnAlifGzur.Visible = false;
                btnAlifI.Visible = true;
                btnAlifIzur.Visible = false;
                btnAlifN.Visible = true;
                btnAlifNzur.Visible = false;
                btnAlifO.Visible = true;
                btnAlifOzur.Visible = false;
                btnAlifS.Visible = true;
                btnAlifSzur.Visible = false;
                btnAlifU.Visible = true;
                btnAlifUzur.Visible = false;
            }
        }

        private void SetCustomButtons()
        {
            for (int i = 0; i < x_CustomButtons.Count; i++)
            {
                tlsAlifba.Items.Remove(x_CustomButtons[i]);
                x_CustomButtons[i].Dispose();
            }
            x_CustomButtons.Clear();
            if (X_CustomSymbols == null)
                return;
            foreach(AlphabetSymbol _symbol in X_CustomSymbols)
            {
                AddAlphabetButton(_symbol);
            }
        }

        private void SetCapitalizeButton()
        {
            if (X_CustomSymbols != null && X_CustomSymbols.Exists(_symbol => !string.IsNullOrEmpty(_symbol.CapitalizedText)))
            {
                btnCapitalize.Visible = true;
            }
        }

        private void AddAlphabetButton(AlphabetSymbol ButtonSymbol)
        {
            if (ButtonSymbol == null)
                return;
            ToolStripButton _newButton = new ToolStripButton();
            _newButton.ForeColor = System.Drawing.Color.Gray;
            _newButton.Image = global::Bitig.UI.Properties.Resources.blank;
            _newButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            _newButton.ImageTransparentColor = System.Drawing.Color.Transparent;
            _newButton.Size = new System.Drawing.Size(36, 36);
            _newButton.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            _newButton.Tag = ButtonSymbol;
            _newButton.Text = ButtonSymbol.DisplayText;
            this.tlsAlifba.Items.Add(_newButton);
            _newButton.Click += new EventHandler(btnCustomLetters_Click);
            x_CustomButtons.Add(_newButton);
        }

        public int CalculateHeight()
        {
            return tlsAlifba.GetPreferredSize(this.Size).Height;
           /* var _visibleButtons = from ToolStripItem _item in tlsAlphabet.Items
                                  where _item.Visible
                                  select _item;
            int _totalButtons = _visibleButtons.Count();
            if (_totalButtons > 0)
            {
                int _buttonsPerLine = tlsAlphabet.Width / (btnAlifA.Width + btnAlifA.Margin.Horizontal);
                if (_buttonsPerLine > 0)
                {
                    int _lines = _totalButtons / _buttonsPerLine;
                    if (_totalButtons % _buttonsPerLine > 0) _lines++;
                    int _height = _lines * (btnAlifA.Height + btnAlifA.Margin.Vertical);
                    return _height;
                }
            }
            return this.Height;*/
        }
    }
}
