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
        public Dictionary<AlifbaSymbol, AlifbaSymbol> SymbolMapping { get; private set; }

        private BindingList<SymbolPair> x_Symbols = new BindingList<SymbolPair>();

        public frmSymbolMapping(Dictionary<AlifbaSymbol, AlifbaSymbol> SymbolMapping)
        {
            InitializeComponent();
            this.SymbolMapping = new Dictionary<AlifbaSymbol, AlifbaSymbol>();
            bndSymbols.DataSource = x_Symbols;
            if (SymbolMapping != null)
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
                var _key = new AlifbaSymbol(_symbolPair.SourceLower, _symbolPair.SourceUpper);
                if (SymbolMapping.ContainsKey(_key))
                {
                    //loc
                    MessageBox.Show("Duplicate key: " + _key.ActualText);
                    return;
                }
                SymbolMapping.Add(_key,
                    new AlifbaSymbol(_symbolPair.TargetLower, _symbolPair.TargetUpper));
            }
            DialogResult = DialogResult.OK;
        }
    }
}
