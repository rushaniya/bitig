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

namespace Bitig.UI
{
    public partial class frmExclusionsView : Form
    {
        public frmExclusionsView()
        {
            InitializeComponent();
            //excl
           /* cmbDirection.Items.Add("(All)");
            foreach (Direction _dir in DirectionManager.DirectionsList)
            {
                cmbDirection.Items.Add(_dir);
            }
            cmbDirection.SelectedIndex = 0;
            cmbDirection.DisplayMember = "FriendlyName";
            dgvExclusions.DataSource = StorageManager.Instance.ExclusionsTable;
            colDirectionName.DataSource = DirectionManager.DirectionsList;
            colDirectionName.ValueMember = "ID";
            colDirectionName.DisplayMember = "FriendlyName";
            colDirectionName.DataPropertyName = "directionID";*/
        }

        private void frmExclusionsView_Load(object sender, EventArgs e)
        {

        }

        private void dgvExclusions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExclusionsAdd _addForm = new frmExclusionsAdd();
            _addForm.AddExclusion += new frmExclusionsAdd.AddExclusionHandler(AddForm_AddButtonClicked); 
            if (cmbDirection.SelectedItem as Direction != null) _addForm.X_DirectionID = (cmbDirection.SelectedItem as Direction).ID;
            _addForm.ShowDialog();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvExclusions.SelectedRows.Count > 0)
            {
                int? _exclID = dgvExclusions.SelectedRows[0].Cells[colExclusionID.Index].Value as int?;
                if (_exclID == null) return;

                frmExclusionEdit _editForm = new frmExclusionEdit();//(int)dgvExclusions.SelectedRows[0].Cells[colDirectionID.Index].Value);
                _editForm.X_DirectionID = (int)dgvExclusions.SelectedRows[0].Cells[colDirectionID.Index].Value;
                _editForm.X_Source = dgvExclusions.SelectedRows[0].Cells[colSourceWord.Index].FormattedValue.ToString();
                _editForm.X_Target = dgvExclusions.SelectedRows[0].Cells[colTargetWord.Index].FormattedValue.ToString();
                _editForm.X_MatchCase = (bool) dgvExclusions.SelectedRows[0].Cells[colMatchCase.Index].Value;
                _editForm.X_MatchWord = (bool) dgvExclusions.SelectedRows[0].Cells[colMatchWord.Index].Value;
                if (_editForm.ShowDialog() == DialogResult.OK)
                {
                    dgvExclusions.SelectedRows[0].Cells[colDirectionID.Index].Value = _editForm.X_DirectionID;
                    dgvExclusions.SelectedRows[0].Cells[colDirectionName.Index].Value = _editForm.X_DirectionID;
                    dgvExclusions.SelectedRows[0].Cells[colSourceWord.Index].Value = _editForm.X_Source;
                    dgvExclusions.SelectedRows[0].Cells[colTargetWord.Index].Value = _editForm.X_Target;
                    dgvExclusions.SelectedRows[0].Cells[colMatchCase.Index].Value = _editForm.X_MatchCase;
                    dgvExclusions.SelectedRows[0].Cells[colMatchWord.Index].Value = _editForm.X_MatchWord;
                    dgvExclusions.Refresh();
                }
            }

        }

        private void dgvExclusions_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(null, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow _row in dgvExclusions.SelectedRows)
            {
                dgvExclusions.Rows.Remove(_row);
            }
        }


        private void AddForm_AddButtonClicked(object sender, frmExclusionsAdd.AddExclusionArgs e)
        {
        }

        private void frmExclusionsView_FormClosing(object sender, FormClosingEventArgs e)
        {
           //excl  StorageManager.Instance.SaveExclusionsTable();
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {/*
            if (cmbDirection.SelectedItem as Direction != null)
            {
                dgvExclusions.DataSource = dgvExclusions.DataSource = StorageManager.Instance.ExclusionsTable.Select(
                    StorageManager.Instance.ExclusionsTable.directionIDColumn.ColumnName + "=" + (cmbDirection.SelectedItem as Direction).ID.ToString());
            }
            else
                dgvExclusions.DataSource = StorageManager.Instance.ExclusionsTable;*/
        }

    }
}
