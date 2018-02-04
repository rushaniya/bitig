using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.UI.Configuration
{
    public partial class frmAlphabetSymbols : Form
    {
        private bool x_Yanalif;
        private Alifba x_CurrentAlphabet;
        private IRepository<Alifba, int> x_AlifbaRepository;

        private List<AlifbaSymbol> x_TemporaryList = new List<AlifbaSymbol>();

        private List<AlifbaSymbol> x_Symbols;

        public frmAlphabetSymbols(Alifba CurrentAlphabet, IRepository<Alifba, int> AlifbaRepo)
        {
            InitializeComponent();
            x_CurrentAlphabet = CurrentAlphabet;
            x_AlifbaRepository = AlifbaRepo;
            if (x_CurrentAlphabet.IsYanalif)
            {
                x_Yanalif = true;
                chkShowAllYanalifLetters.Checked = Configuration.TempConfig.ShowAllYanalifSymbols;//config:enable checkbox
            }
            Text = string.Format("Custom {0} Symbols", x_CurrentAlphabet.FriendlyName);
            pnlYanalifSettings.Visible = x_Yanalif;
            x_Symbols = x_CurrentAlphabet.CustomSymbols;
            x_TemporaryList.Clear();
            if (x_Symbols != null)
            {
                foreach (AlifbaSymbol _symbol in x_Symbols)
                {
                    AlifbaSymbol _copy = new AlifbaSymbol(_symbol.ActualText, _symbol.DisplayText, _symbol.CapitalizedText, _symbol.CapitalizedDisplayText);
                    x_TemporaryList.Add(_copy);
                }
            }
            bndSymbol.DataSource = x_TemporaryList;
            if (x_CurrentAlphabet.DefaultFont != null)
                dgvSymbols.RowsDefaultCellStyle.Font = (Font)x_CurrentAlphabet.DefaultFont;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            x_Symbols = new List<AlifbaSymbol>();
            int _counter = 0;
            foreach (AlifbaSymbol _symbol in x_TemporaryList)
            {
                if (x_Yanalif && _counter >= _maxRows)
                    break;
                if (_symbol.ActualText != null && _symbol.ActualText.Trim() != string.Empty)
                {
                    x_Symbols.Add(new AlifbaSymbol(_symbol.ActualText, _symbol.DisplayText, _symbol.CapitalizedText, _symbol.CapitalizedDisplayText));
                }
                _counter++;
            }
            if (x_Yanalif)
            {
                Configuration.TempConfig.ShowAllYanalifSymbols = chkShowAllYanalifLetters.Checked;//config
            }

            x_CurrentAlphabet.CustomSymbols = x_Symbols;
            x_AlifbaRepository.Update(x_CurrentAlphabet);
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
