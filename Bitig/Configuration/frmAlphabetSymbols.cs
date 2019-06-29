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
        private Alphabet x_CurrentAlphabet;
        private AlphabetRepository x_AlphabetRepository;

        private BindingList<AlphabetSymbol> x_TemporaryList = new BindingList<AlphabetSymbol>();

        private List<AlphabetSymbol> x_Symbols;

        public frmAlphabetSymbols(Alphabet CurrentAlphabet, AlphabetRepository AlphabetRepo)
        {
            InitializeComponent();
            x_CurrentAlphabet = CurrentAlphabet;
            x_AlphabetRepository = AlphabetRepo;
            Text = string.Format("Custom {0} Symbols", x_CurrentAlphabet.FriendlyName);
            //noyan del chkShowAllYanalifLetters, pnlYanalifSettings
            x_Symbols = x_CurrentAlphabet.CustomSymbols;
            x_TemporaryList.Clear();
            if (x_Symbols != null)
            {
                foreach (AlphabetSymbol _symbol in x_Symbols)
                {
                    AlphabetSymbol _copy = new AlphabetSymbol(_symbol.ActualText, _symbol.CapitalizedText, _symbol.DisplayText, _symbol.CapitalizedDisplayText, _symbol.IsAlphabetic, _symbol.IsOnScreen);
                    x_TemporaryList.Add(_copy);
                }
            }
            bndSymbol.DataSource = x_TemporaryList;
            if (x_CurrentAlphabet.DefaultFont != null)
                dgvSymbols.RowsDefaultCellStyle.Font = (Font)x_CurrentAlphabet.DefaultFont;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            x_Symbols = new List<AlphabetSymbol>();
            int _counter = 0;
            foreach (AlphabetSymbol _symbol in x_TemporaryList)
            {
                if (_symbol.ActualText != null && _symbol.ActualText.Trim() != string.Empty)
                {
                    x_Symbols.Add(new AlphabetSymbol(_symbol.ActualText, _symbol.CapitalizedText, _symbol.DisplayText, _symbol.CapitalizedDisplayText, _symbol.IsAlphabetic, _symbol.IsOnScreen));
                }
                _counter++;
            }

            x_CurrentAlphabet.CustomSymbols = x_Symbols;
            x_AlphabetRepository.Update(x_CurrentAlphabet);
        }
    }
}
