using System;
using System.Windows.Forms;
using Bitig.Logic.Repository;
using Bitig.Logic.Model;

namespace Bitig.UI.Configuration
{
    public partial class frmConfig : Form
    {
        private AlphabetRepository x_AlphabetRepo;
        private DirectionRepository x_DirectionRepo;
        private KeyboardRepository x_KeyboardRepo;
        private IDataContext x_DataContext;

        public frmConfig(IDataContext DataContext)
        {
            InitializeComponent();
            dgvAlphabets.AutoGenerateColumns = false;
            dgvAlphabets.DataSource = bndAlphabet;
            x_DataContext = DataContext;
            x_AlphabetRepo = DataContext.AlphabetRepository;
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
            if (x_AlphabetsModified || x_DirectionsModified)
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

        private AlphabetSummary x_CurrentAlphabet;

        private bool x_AlphabetsModified;

        public bool X_AlphabetsModified
        {
            get { return x_AlphabetsModified; }
        }

        private void DisplayAlphabets()
        {
            bndAlphabet.DataSource = x_AlphabetRepo.GetList();
        }

        private void btnAddAlphabet_Click(object sender, EventArgs e)
        {
            using (frmEditAlphabet _editForm = new frmEditAlphabet(x_KeyboardRepo.GetSummaryList()))
            {
                if (_editForm.ShowDialog() == DialogResult.OK)
                {
                    x_AlphabetRepo.Insert(_editForm.X_AlphabetConfig);
                    DisplayAlphabets();
                    x_AlphabetsModified = true;
                }
            }
        }

        private void btnEditAlphabet_Click(object sender, EventArgs e)
        {
            if (x_CurrentAlphabet != null)
            {
                using (frmEditAlphabet _editForm = new frmEditAlphabet(x_KeyboardRepo.GetSummaryList()))
                {
                    _editForm.X_AlphabetConfig = x_CurrentAlphabet;
                    if (_editForm.ShowDialog() == DialogResult.OK)
                    {
                        x_AlphabetRepo.Update(_editForm.X_AlphabetConfig);
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
            if (x_CurrentAlphabet != null)
            {//loc
                if (x_AlphabetRepo.IsInUse(x_CurrentAlphabet.ID))
                {
                    MessageBox.Show("This alphabet is in use.", "!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (MessageBox.Show(string.Format("Remove {0} alphabet?", x_CurrentAlphabet.FriendlyName), "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    x_AlphabetRepo.Delete(x_CurrentAlphabet.ID);
                    DisplayAlphabets();
                    x_AlphabetsModified = true;
                }
            }
        }

        private void btnAlphabetSymbols_Click(object sender, EventArgs e)
        {
            if (x_CurrentAlphabet != null)
            {
                using (frmAlphabetSymbols _symbolsForm = new frmAlphabetSymbols(x_AlphabetRepo.Get(x_CurrentAlphabet.ID), x_AlphabetRepo))
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
                x_CurrentAlphabet = dgvAlphabets.Rows[e.RowIndex].DataBoundItem as AlphabetSummary;
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
            else
            {
                btnAlphabetSymbols.Enabled = true;
                btnDeleteAlphabet.Enabled = true;
                btnEditAlphabet.Enabled = true;
            }
        }

        private void btnExclusions_Click(object sender, EventArgs e)
        {
            var _exclusionsForm = new frmExclusions(x_CurrentDirection, x_DataContext);
            if (_exclusionsForm.ShowDialog() == DialogResult.OK)
            {
                x_DirectionsModified = true;
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
                    "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private KeyboardLayoutSummary x_CurrentKeyboardSummary;

        private void DisplayKeyboardLayouts()
        {
            bndKblSummary.DataSource = x_KeyboardRepo.GetSummaryList();
        }

        private void dgvKeyboardLayouts_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow _row = dgvKeyboardLayouts.Rows[e.RowIndex];
            if (_row == null) x_CurrentKeyboardSummary = null;
            else
            {
                x_CurrentKeyboardSummary = dgvKeyboardLayouts.Rows[e.RowIndex].DataBoundItem as KeyboardLayoutSummary;
            }
            GetCurrentKeyboardSummary();
        }

        private void GetCurrentKeyboardSummary()
        {
            if (x_CurrentKeyboardSummary == null)
            {
                btnEditKeyboard.Enabled = false;
                btnRemoveKeyboard.Enabled = false;
            }
            else
            {
                btnEditKeyboard.Enabled = true;
                btnRemoveKeyboard.Enabled = true;
            }
        }

        private void btnNewKeboard_Click(object sender, EventArgs e)
        {
            using (var _editKeyboard = new frmKeyboardLayout(x_DataContext))
            {
                if (_editKeyboard.ShowDialog() == DialogResult.OK)
                {
                    x_AlphabetsModified = true;
                    DisplayKeyboardLayouts();
                }
            }
        }

        private void btnEditKeyboard_Click(object sender, EventArgs e)
        {
            if (x_CurrentKeyboardSummary != null)
            {
                using (var _editKeyboard = new frmKeyboardLayout(x_DataContext))
                {
                    _editKeyboard.X_KeyboardLayout = x_KeyboardRepo.Get(x_CurrentKeyboardSummary.ID);
                    if (_editKeyboard.ShowDialog() == DialogResult.OK)
                    {
                        x_AlphabetsModified = true;
                        DisplayKeyboardLayouts();
                    }
                }
            }
        }

        private void btnRemoveKeyboard_Click(object sender, EventArgs e)
        {
            if (x_CurrentKeyboardSummary != null)
            {
                //loc
                if (MessageBox.Show(string.Format("Remove keyboard layout {0}?",
                    x_CurrentKeyboardSummary.FriendlyName),
                    "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    x_KeyboardRepo.Delete(x_CurrentKeyboardSummary.ID);
                    x_AlphabetsModified = true;
                    DisplayKeyboardLayouts();
                }
            }
        }

        #endregion
    }
}
