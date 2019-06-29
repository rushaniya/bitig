using System;
using System.Drawing;
using System.Windows.Forms;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.UI.Configuration
{
    public partial class frmEditAlphabet : Form
    {
        private Alphabet x_AlphabetConfig;

        public Alphabet X_AlphabetConfig
        {
            get { return x_AlphabetConfig; }
            set
            {
                x_AlphabetConfig = value;
                if (value != null)
                {
                    txtDisplayName.Text = x_AlphabetConfig.FriendlyName;
                    x_SelectedFont = x_AlphabetConfig.DefaultFont;
                    chkRightToLeft.Checked = x_AlphabetConfig.RightToLeft;
                }
            }
        }

        private AlphabetFont x_SelectedFont;

        private AlphabetRepository x_AlphabetRepository;
        private KeyboardRepository x_KeyboardRepository;

        public frmEditAlphabet(AlphabetRepository AlphabetRepo, KeyboardRepository KeyboardRepo)
        {
            InitializeComponent();
            x_AlphabetRepository = AlphabetRepo;
            x_KeyboardRepository = KeyboardRepo;
        }

        private void frmEditAlphabet_Load(object sender, EventArgs e)
        {
            if (x_SelectedFont == null)
                lblFont.Text = "Font: (not set)";//loc
            else
                lblFont.Text = "Font: " + x_SelectedFont.ToString();
            FillLayoutsCombo();
        }

        private void FillLayoutsCombo()
        {
            cmbLayout.Items.Add("None"); //loc
            int _index = 0;
            var _summaryList = x_KeyboardRepository.GetSummaryList();
            for (int i = 0; i < _summaryList.Count; i++)
            {
                var _item = _summaryList[i];
                cmbLayout.Items.Add(_item);
                if (x_AlphabetConfig != null && x_AlphabetConfig.KeyboardLayout != null &&
                    x_AlphabetConfig.KeyboardLayout.ID == _item.ID)
                {
                    _index = i + 1;
                }
            }
            cmbLayout.SelectedIndex = _index;
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            dlgFont.Font = (Font)x_SelectedFont;
            if (dlgFont.ShowDialog() == DialogResult.OK)
            {
                x_SelectedFont = (AlphabetFont) dlgFont.Font;
                lblFont.Text = "Font: " + x_SelectedFont.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDisplayName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Display name is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                return;
            }
            var _layoutID = cmbLayout.SelectedItem is KeyboardLayoutSummary ? (int?) ((KeyboardLayoutSummary)cmbLayout.SelectedItem).ID : null;
            var _id = x_AlphabetConfig == null ? -1 : x_AlphabetConfig.ID;
            var _summary = new AlphabetSummary(_id, txtDisplayName.Text.Trim(),
                 chkRightToLeft.Checked, x_SelectedFont, _layoutID);
            if (x_AlphabetConfig == null)
            {
                    
                x_AlphabetRepository.Insert(_summary);
            }
            else
            {
                x_AlphabetRepository.Update(_summary);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
