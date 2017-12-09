using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Bitig.UI.Classes;
using Bitig.Logic.Model;

namespace Bitig.UI.Controls
{
    partial class ctlAlifba : UserControl
    {
        internal event EventHandler<SymbolEventArgs> SymbolPressed;

        private List<AlifbaSymbol> x_Symbols;
        private ToolStripButton[] x_Buttons;

        private Size x_ButtonSize = new Size(30, 30);//config

        private bool x_HoldCapitalizeButton;

        //internal ctlAlifba()
        //{
        //    InitializeComponent();
        //    SymbolPressed += new EventHandler<SymbolEventArgs>(ctlAlifba_SymbolPressed);
        //}

        internal ctlAlifba(List<AlifbaSymbol> Symbols)
        {
            InitializeComponent();
            SymbolPressed += new EventHandler<SymbolEventArgs>(ctlAlifba_SymbolPressed);
            x_Symbols = Symbols;
            SetSymbols();
        }

        private void ctlAlifba_SymbolPressed(object sender, SymbolEventArgs e)
        {
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                AlifbaSymbol _symbol = (sender as ToolStripButton).Tag as AlifbaSymbol;
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

        private void btnCapitalize_CheckedChanged(object sender, EventArgs e)
        {
            if (btnCapitalize.Checked)
            {
                foreach (ToolStripButton _btn in x_Buttons)
                {
                    AlifbaSymbol _symbol = _btn.Tag as AlifbaSymbol;
                    if (_symbol != null && !string.IsNullOrEmpty(_symbol.CapitalizedDisplayText))
                        _btn.Text = _symbol.CapitalizedDisplayText;
                }
            }
            else
            {
                foreach (ToolStripButton _btn in x_Buttons)
                {
                    AlifbaSymbol _symbol = _btn.Tag as AlifbaSymbol;
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
            tlsAlifba.Items.Clear();
            tlsAlifba.Items.Add(btnCapitalize);
            if (x_Symbols != null && x_Symbols.Count > 0)
            {
                List<ToolStripButton> _buttons = new List<ToolStripButton>();
                if (x_Symbols.Exists(_symbol => !string.IsNullOrEmpty(_symbol.CapitalizedText)))
                {
                    btnCapitalize.Visible = true;
                }
                else btnCapitalize.Visible = false;
                foreach (AlifbaSymbol _symbol in x_Symbols)
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
                    _buttons.Add(_btn);
                }
                x_Buttons = _buttons.ToArray();
                tlsAlifba.Items.AddRange(x_Buttons);
            }
        }

        public int CalculateHeight()
        {
            return tlsAlifba.GetPreferredSize(this.Size).Height;
            /*if (x_Buttons != null && x_Buttons.Length > 0)
            {
                int _totalButtons = x_Buttons.Length;
                if (btnCapitalize.Visible) _totalButtons++;
                int _buttonsPerLine = tlsAlifba.Width / (btnCapitalize.Width + btnCapitalize.Margin.Horizontal);
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
