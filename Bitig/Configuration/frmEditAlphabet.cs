using System;
using System.Drawing;
using System.Windows.Forms;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.UI.Configuration
{
    public partial class frmEditAlphabet : Form
    {
        private Alifba x_AlphabetConfig;

        public Alifba X_AlphabetConfig
        {
            get { return x_AlphabetConfig; }
            set
            {
                x_AlphabetConfig = value;
                if (value != null)
                {
                    txtDisplayName.Text = x_AlphabetConfig.FriendlyName;
                    //kbl cmbLayout.Text = x_AlphabetConfig.KeyboardLayoutName;
                    x_SelectedFont = x_AlphabetConfig.DefaultFont;
                    chkRightToLeft.Checked = x_AlphabetConfig.RightToLeft;
                }
            }
        }

        private AlifbaFont x_SelectedFont;// = new Font("DejaVu Sans", 10F);

        private IRepository<Alifba, int> x_AlifbaRepository;

        public frmEditAlphabet(IRepository<Alifba, int> AlifbaRepo)
        {
            InitializeComponent();
            x_AlifbaRepository = AlifbaRepo;
        }

        private void frmEditAlphabet_Load(object sender, EventArgs e)
        {
            if (x_SelectedFont == null)
                lblFont.Text = "Font: (not set)";//loc
            else
                lblFont.Text = "Font: " + x_SelectedFont.ToString();

        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            dlgFont.Font = (Font)x_SelectedFont;
            if (dlgFont.ShowDialog() == DialogResult.OK)
            {
                x_SelectedFont = (AlifbaFont) dlgFont.Font;
                lblFont.Text = "Font: " + x_SelectedFont.ToString();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //kbl: LayoutID, LayoutName
            if (txtDisplayName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Display name is empty", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);//loc
                return;
            }
            if (x_AlphabetConfig == null)
            {
                x_AlphabetConfig = new Alifba(-1, txtDisplayName.Text.Trim(), 
                    RightToLeft: chkRightToLeft.Checked, DefaultFont: (AlifbaFont)x_SelectedFont);
                    
                x_AlifbaRepository.Insert(x_AlphabetConfig);
            }
            else
            {
                x_AlphabetConfig.DefaultFont = (AlifbaFont)x_SelectedFont;
                x_AlphabetConfig.FriendlyName = txtDisplayName.Text.Trim();
                //kbl x_AlphabetConfig.KeyboardLayoutName = string.Empty;
                x_AlphabetConfig.RightToLeft = chkRightToLeft.Checked;
                x_AlifbaRepository.Update(x_AlphabetConfig);
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
