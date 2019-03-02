using System;
using System.Windows.Forms;
using Bitig.Logic.Repository;
using Bitig.Logic.Model;

namespace Bitig.UI.Configuration
{
    public partial class frmConfig : Form
    {
        private AlifbaRepository x_AlifbaRepo;
        private DirectionRepository x_DirectionRepo;
        private KeyboardRepository x_KeyboardRepo;
        private IDataContext x_DataContext;

        public frmConfig(IDataContext DataContext)
        {
            InitializeComponent();
            x_DataContext = DataContext;
            x_AlifbaRepo = DataContext.AlifbaRepository;
            x_DirectionRepo = DataContext.DirectionRepository;
            x_KeyboardRepo = DataContext.KeyboardRepository;
            DisplayAlphabets();
            DisplayDirections();
            DisplayKeyboardLayouts();
        }

        private void frmConfig_Load(object sender, EventArgs e)
        {
            GetCurrentAlphabet();
            GetCurrentDirection();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (x_AlphabetsModified || x_DirectionsModified || x_ExclusionsModified)
            {
                x_DataContext.SaveChanges();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            x_DataContext.CancelChanges();
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
            bndAlphabet.DataSource = x_AlifbaRepo.GetList();
        }

        private void btnAddAlphabet_Click(object sender, EventArgs e)
        {
            using (frmEditAlphabet _editForm = new frmEditAlphabet(x_AlifbaRepo, x_KeyboardRepo))
            {
                if (_editForm.ShowDialog() == DialogResult.OK)
                {
                    DisplayAlphabets();
                    x_AlphabetsModified = true;
                }
            }
        }

        private void btnEditAlphabet_Click(object sender, EventArgs e)
        {
            if (x_CurrentAlphabet != null)
            {
                using (frmEditAlphabet _editForm = new frmEditAlphabet(x_AlifbaRepo, x_KeyboardRepo))
                {
                    _editForm.X_AlphabetConfig = x_CurrentAlphabet;
                    if (_editForm.ShowDialog() == DialogResult.OK)
                    {
                        DisplayAlphabets();
                        DisplayDirections();
                        bndDirection.ResetBindings(false);
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
                    x_AlifbaRepo.Delete(x_CurrentAlphabet.ID);
                    DisplayAlphabets();
                    x_AlphabetsModified = true;
                }
            }
        }

        private void btnAlphabetSymbols_Click(object sender, EventArgs e)
        {
            if (x_CurrentAlphabet != null)
            {
                using (frmAlphabetSymbols _symbolsForm = new frmAlphabetSymbols(x_AlifbaRepo.Get(x_CurrentAlphabet.ID), x_AlifbaRepo))
                {
                    if (_symbolsForm.ShowDialog() == DialogResult.OK)
                    {
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

        private bool x_ExclusionsModified;

        private void btnExclusions_Click(object sender, EventArgs e)
        {
            var _exclusionsForm = new frmExclusions(x_CurrentDirection, x_DataContext);
            if (_exclusionsForm.ShowDialog() == DialogResult.OK)
            {
                x_DirectionsModified = true;
                x_ExclusionsModified = true;
                DisplayDirections();
            }
        }

        #endregion

        #region Directions

        private bool x_DirectionsModified;

        public bool X_DirectionsModified
        {
            get { return x_DirectionsModified; }
        }

        private Direction x_CurrentDirection;

        private void btnAddDirection_Click(object sender, EventArgs e)
        {
            using (frmEditDirection _editDir = new frmEditDirection(x_DataContext))
            {
                if (_editDir.ShowDialog() == DialogResult.OK)
                {
                    DisplayDirections();
                    x_DirectionsModified = true;
                }
            }
        }

        private void btnEditDirection_Click(object sender, EventArgs e)
        {
            if (x_CurrentDirection != null)
            {
                using (frmEditDirection _editDir = new frmEditDirection(x_DataContext))
                {
                    _editDir.X_Direction = x_DirectionRepo.Get(x_CurrentDirection.ID);
                    if (_editDir.ShowDialog() == DialogResult.OK)
                    {
                        DisplayDirections();
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
                if (MessageBox.Show(string.Format("Remove transliteration direction {0}?",
                    x_CurrentDirection.FriendlyName),
                    "?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    x_DirectionRepo.Delete(x_CurrentDirection.ID);
                    DisplayDirections();
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
                x_CurrentDirection = dgvDirections.Rows[e.RowIndex].DataBoundItem as Direction;
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
            bndDirection.DataSource = x_DirectionRepo.GetList();
        }

        #endregion

        #region Keyboard Layouts

        private void DisplayKeyboardLayouts()
        {
            bndKblSummary.DataSource = x_KeyboardRepo.GetSummaryList();
        }

        #endregion
    }
}
