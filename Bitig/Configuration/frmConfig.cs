using System;
using System.Drawing;
using System.Windows.Forms;
using Bitig.Logic;
using Bitig.Logic.Repository;
using Bitig.Logic.Model;
using System.Collections.Generic;

namespace Bitig.UI.Configuration
{
    public partial class frmConfig : Form
    {
        //private AlifbaRepository x_AlifbaRepository;
        private InMemoryRepository<Alifba, int> x_EditableAlifbaRepo;

        public frmConfig(AlifbaRepository AlifbaRepository)
        {
            InitializeComponent();
            // x_AlifbaRepository = AlifbaRepository;
            x_EditableAlifbaRepo = new InMemoryRepository<Alifba, int>(AlifbaRepository);
            DisplayAlphabets();
            DisplayDirections();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            GetCurrentAlphabet();
            GetCurrentDirection();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (x_AlphabetsModified || x_DirectionsModified || x_ExclusionsModified)
                x_EditableAlifbaRepo.SaveChanges();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        #region Alphabets

        private Alifba x_CurrentAlphabet;

        private bool x_AlphabetsModified;

        public bool X_AlphabetsModified
        {
            get { return x_AlphabetsModified; }
        }

        private void DisplayAlphabets()
        {
            bndAlphabet.DataSource = x_EditableAlifbaRepo.GetList();
        }

        private void btnAddAlphabet_Click(object sender, EventArgs e)
        {
            using (frmEditAlphabet _editForm = new frmEditAlphabet())
            {
                if (_editForm.ShowDialog() == DialogResult.OK)
                {
                    bndAlphabet.ResetBindings(false);
                    x_AlphabetsModified = true;
                }
            }
        }

        private void btnEditAlphabet_Click(object sender, EventArgs e)
        {
            if (x_CurrentAlphabet != null)
            {
                using (frmEditAlphabet _editForm = new frmEditAlphabet())
                {
                    _editForm.X_AlphabetConfig = x_CurrentAlphabet;
                    if (_editForm.ShowDialog() == DialogResult.OK)
                    {
                        bndAlphabet.ResetBindings(false);
                        x_AlphabetsModified = true;
                    }
                }
            }
        }

        private void btnDeleteAlphabet_Click(object sender, EventArgs e)
        {
            if (x_CurrentAlphabet != null && !x_CurrentAlphabet.IsYanalif)
            {//loc
                if (MessageBox.Show(string.Format("Remove {0} alphabet?", x_CurrentAlphabet.FriendlyName), "?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    x_EditableAlifbaRepo.Delete(x_CurrentAlphabet);
                    bndAlphabet.ResetBindings(false);
                    x_AlphabetsModified = true;
                }
            }
        }

        private void btnAlphabetSymbols_Click(object sender, EventArgs e)
        {
            if (x_CurrentAlphabet != null)
            {
                using (frmAlphabetSymbols _symbolsForm = new frmAlphabetSymbols())
                {
                    if (x_CurrentAlphabet.IsYanalif)
                    {
                        _symbolsForm.X_Yanalif = true;
                        _symbolsForm.Text = string.Format("Custom {0} Symbols", x_CurrentAlphabet.FriendlyName);
                    }
                    _symbolsForm.X_Symbols = x_CurrentAlphabet.CustomSymbols;
                    if (x_CurrentAlphabet.DefaultFont != null)
                        _symbolsForm.X_DefaultFont = (Font)x_CurrentAlphabet.DefaultFont;
                    if (_symbolsForm.ShowDialog() == DialogResult.OK)
                    {
                        x_CurrentAlphabet.CustomSymbols = _symbolsForm.X_Symbols;
                        x_AlphabetsModified = true;
                    }
                }
            }
        }

        private void dgvAlphabets_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow _row = dgvAlphabets.Rows[e.RowIndex];
            if (_row == null) x_CurrentAlphabet = null;
            else
            {
                x_CurrentAlphabet = dgvAlphabets.Rows[e.RowIndex].DataBoundItem as Alifba;
            }
            GetCurrentAlphabet();
        }

        private void GetCurrentAlphabet()
        {
            if (x_CurrentAlphabet == null) 
            {
                btnAlphabetSymbols.Enabled = false;
                btnDeleteAlphabet.Enabled = false;
                btnEditAlphabet.Enabled = false;
            }
            else if (x_CurrentAlphabet.IsYanalif)
            {
                btnAlphabetSymbols.Enabled = true;
                btnDeleteAlphabet.Enabled = false;
                btnEditAlphabet.Enabled = true;
            }
            else
            {
                btnAlphabetSymbols.Enabled = true;
                btnDeleteAlphabet.Enabled = true;
                btnEditAlphabet.Enabled = true;
            }
        }

        #endregion

        #region Directions

        private bool x_DirectionsModified;

        public bool X_DirectionsModified
        {
            get { return x_DirectionsModified; }
        } 

        private DirectionConfig x_CurrentDirection;

        private void btnAddDirection_Click(object sender, EventArgs e)
        {
            using (frmEditDirection _editDir = new frmEditDirection())
            {
                if (_editDir.ShowDialog() == DialogResult.OK)
                {
                    bndDirection.ResetBindings(false);
                    x_DirectionsModified = true;
                }
            }
        }

        private void btnEditDirection_Click(object sender, EventArgs e)
        {
            if (x_CurrentDirection != null)
            {
                using (frmEditDirection _editDir = new frmEditDirection())
                {
                    _editDir.X_DirectionConfig = x_CurrentDirection;
                    if (_editDir.ShowDialog() == DialogResult.OK)
                    {
                        bndDirection.ResetBindings(false);
                        x_DirectionsModified = true;
                    }
                }
            }
        }

        private void btnRemoveDirection_Click(object sender, EventArgs e)
        {
            if (x_CurrentDirection != null)
            {
                //loc
                if (MessageBox.Show(string.Format("Remove transliteration direction {0} - {1}?", x_CurrentDirection.SourceName, x_CurrentDirection.TargetName),
                    "?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    BitigConfigManager.DeleteDirectionConfig(x_CurrentDirection);
                    bndDirection.ResetBindings(false);
                    x_DirectionsModified = true;
                }
            }
        }

        private void dgvDirections_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow _row = dgvDirections.Rows[e.RowIndex];
            if (_row == null) x_CurrentDirection = null;
            else
            {
                x_CurrentDirection = dgvDirections.Rows[e.RowIndex].DataBoundItem as DirectionConfig;
            }
            GetCurrentDirection();
        }

        private void GetCurrentDirection()
        {
            if (x_CurrentDirection == null)
            {
                btnEditDirection.Enabled = false;
                btnRemoveDirection.Enabled = false;
            }
            else
            {
                btnRemoveDirection.Enabled = true;
                btnEditDirection.Enabled = true;
            }
        }

        private void DisplayDirections()
        {
            bndDirection.DataSource = BitigConfigManager.DirectionConfigurations;
        }

        #endregion

        private bool x_ExclusionsModified;
    }
}
