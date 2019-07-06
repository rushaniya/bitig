using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Bitig.UI.Logic;
using Bitig.Logic.Model;

namespace Bitig.UI.Controls
{
    partial class ctlAlphabet : UserControl
    {
        internal event EventHandler<SymbolEventArgs> SymbolPressed;

        private List<AlphabetSymbol> x_Symbols;
        private ToolStripButton[] x_Buttons;

        private Size x_ButtonSize = new Size(30, 30);//config
        private float x_FontSize = 12;

        private bool x_HoldCapitalizeButton;

        internal ctlAlphabet(List<AlphabetSymbol> Symbols)
        {
            InitializeComponent();
            SymbolPressed += new EventHandler<SymbolEventArgs>(ctlAlphabet_SymbolPressed);
            x_Symbols = Symbols;
            SetSymbols();
        }

        private void ctlAlphabet_SymbolPressed(object sender, SymbolEventArgs e)
        {
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                AlphabetSymbol _symbol = (sender as ToolStripButton).Tag as AlphabetSymbol;
                if (_symbol != null)
                {
                    if (btnCapitalize.Visible && btnCapitalize.Checked)
                    {
                        if (string.IsNullOrEmpty(_symbol.CapitalizedText))
                            SymbolPressed(this, new SymbolEventArgs(_symbol.ActualText.ToUpperInvariant()));
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

        private void btnCapitalize_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCapitalize.Checked)
            {
                foreach (ToolStripButton _btn in x_Buttons)
                {
                    AlphabetSymbol _symbol = _btn.Tag as AlphabetSymbol;
                    if (_symbol != null && !string.IsNullOrEmpty(_symbol.CapitalizedDisplayText))
                        _btn.Text = _symbol.CapitalizedDisplayText;
                }
            }
            else
            {
                foreach (ToolStripButton _btn in x_Buttons)
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

        private void SetSymbols()
        {
            tlsAlphabet.Items.Clear();
            tlsAlphabet.Items.Add(btnCapitalize);
            if (x_Symbols != null && x_Symbols.Count > 0)
            {
                List<ToolStripButton> _buttons = new List<ToolStripButton>();
                if (x_Symbols.Exists(_symbol => !string.IsNullOrEmpty(_symbol.CapitalizedText)))
                {
                    btnCapitalize.Visible = true;
                }
                else btnCapitalize.Visible = false;
                foreach (AlphabetSymbol _symbol in x_Symbols)
                {
                    ToolStripButton _btn = new System.Windows.Forms.ToolStripButton();
                    _btn.ForeColor = System.Drawing.Color.Gray;
                    _btn.Image = global::Bitig.UI.Properties.Resources.blank;
                    _btn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
                    _btn.ImageTransparentColor = System.Drawing.Color.Transparent;
                    _btn.Size = x_ButtonSize;
                    _btn.Margin = btnCapitalize.Margin;
                    _btn.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
                    _btn.Tag = _symbol;
                    _btn.Text = _symbol.DisplayText;
                    _btn.Click += new EventHandler(Btn_Click);
                    _btn.Font = new Font(_btn.Font.FontFamily, x_FontSize);
                    _buttons.Add(_btn);
                }
                x_Buttons = _buttons.ToArray();
                tlsAlphabet.Items.AddRange(x_Buttons);
            }
        }

        public int CalculateHeight()
        {
            return tlsAlphabet.GetPreferredSize(this.Size).Height;
            /*if (x_Buttons != null && x_Buttons.Length > 0)
            {
                int _totalButtons = x_Buttons.Length;
                if (btnCapitalize.Visible) _totalButtons++;
                int _buttonsPerLine = tlsAlphabet.Width / (btnCapitalize.Width + btnCapitalize.Margin.Horizontal);
                if (_buttonsPerLine > 0)
                {
                    int _lines = _totalButtons / _buttonsPerLine;
                    if (_totalButtons % _buttonsPerLine > 0) _lines++;
                    int _height = _lines * (btnCapitalize.Height + btnCapitalize.Margin.Vertical);
                    return _height;
                }
            }
            return this.Height;*/
        }
    }
}
