using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bitig.Logic;
using Bitig.Logic.Model;

namespace Bitig.UI.Configuration
{
    public partial class frmAlphabetSymbols : Form
    {
        private bool x_Yanalif;

        public bool X_Yanalif
        {
            get { return x_Yanalif; }
            set
            {
                x_Yanalif = value;
                //colDisplayUpper.Visible = !value;
                //colUpper.Visible = !value;
                pnlYanalifSettings.Visible = value;
                if (value)
                {
                    chkShowAllYanalifLetters.Checked = Classes.TempConfig.ShowAllYanalifSymbols;//config:enable checkbox
                }
            }
        }

        private List<AlifbaSymbol> x_TemporaryList = new List<AlifbaSymbol>();

        private List<AlifbaSymbol> x_Symbols;

        public List<AlifbaSymbol> X_Symbols
        {
            get { return x_Symbols; }
            set
            {
                x_Symbols = value;
                x_TemporaryList.Clear();
                if (value != null)
                {
                    foreach (AlifbaSymbol _symbol in value)
                    {
                        AlifbaSymbol _copy = new AlifbaSymbol(_symbol.ActualText, _symbol.DisplayText, _symbol.CapitalizedText, _symbol.CapitalizedDisplayText);
                        x_TemporaryList.Add(_copy);
                    }
                }
                bndSymbol.DataSource = x_TemporaryList;
            }
        }

        public Font X_DefaultFont
        {
            set
            {
                dgvSymbols.RowsDefaultCellStyle.Font = value;
            }
        }

        public frmAlphabetSymbols()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            x_Symbols = new List<AlifbaSymbol>();
            int _counter = 0;
            foreach (AlifbaSymbol _symbol in x_TemporaryList)
            {
                if (x_Yanalif && _counter >= _maxRows) break;
                if (_symbol.ActualText != null && _symbol.ActualText.Trim() != string.Empty)
                {
                    x_Symbols.Add(new AlifbaSymbol(_symbol.ActualText, _symbol.DisplayText, _symbol.CapitalizedText, _symbol.CapitalizedDisplayText));
                }
                _counter++;
            }
            if (x_Yanalif)
            {
                Classes.TempConfig.ShowAllYanalifSymbols = chkShowAllYanalifLetters.Checked;//config
            }
        }

        int _maxRows = 30;//config

        private void bndSymbol_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (x_Yanalif)
            {
                bndSymbol.AllowNew = bndSymbol.Count < _maxRows;
            }
        }
    }
}
