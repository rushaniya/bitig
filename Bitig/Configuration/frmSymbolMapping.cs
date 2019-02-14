using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using Bitig.Logic.Model;
using Bitig.UI.Configuration.Model;

namespace Bitig.UI.Configuration
{
    public partial class frmSymbolMapping : Form
    {
        public Dictionary<TextSymbol, TextSymbol> SymbolMapping { get; private set; }

        private BindingList<SymbolPair> x_Symbols = new BindingList<SymbolPair>();

        public frmSymbolMapping(Dictionary<TextSymbol, TextSymbol> SymbolMapping, List<AlifbaSymbol> DefaultSourceSymbols)
        {
            InitializeComponent();
            this.SymbolMapping = new Dictionary<TextSymbol, TextSymbol>();
            bndSymbols.DataSource = x_Symbols;
            if (SymbolMapping == null)
            {
                //pre-fill with symbols of the source alphabet
                if (DefaultSourceSymbols != null)
                {
                    foreach (var _symbol in DefaultSourceSymbols)
                    {
                        x_Symbols.Add(new SymbolPair
                        {
                            SourceLower = _symbol.ActualText,
                            SourceUpper = _symbol.CapitalizedText,
                            TargetLower = string.Empty,
                            TargetUpper = string.Empty
                        });
                    }
                }
            }
            else
            {
                foreach (var _symbol in SymbolMapping)
                {
                    x_Symbols.Add(new SymbolPair
                    {
                        SourceLower = _symbol.Key.ActualText,
                        SourceUpper = _symbol.Key.CapitalizedText,
                        TargetLower = _symbol.Value.ActualText,
                        TargetUpper = _symbol.Value.CapitalizedText
                    });
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SymbolMapping.Clear();
            foreach (var _symbolPair in x_Symbols)
            {
                if (string.IsNullOrEmpty(_symbolPair.SourceLower))
                    continue;
                var _key = new TextSymbol(_symbolPair.SourceLower, _symbolPair.SourceUpper);
                if (SymbolMapping.ContainsKey(_key))
                {
                    //loc
                    MessageBox.Show("Duplicate key: " + _key.ActualText);
                    return;
                }
                SymbolMapping.Add(_key,
                    new TextSymbol(_symbolPair.TargetLower, _symbolPair.TargetUpper));
            }
            DialogResult = DialogResult.OK;
        }
    }
}
