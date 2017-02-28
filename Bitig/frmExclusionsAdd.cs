using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bitig.Logic;

namespace Bitig.UI
{
    public partial class frmExclusionsAdd : Form
    {
        internal delegate void AddExclusionHandler(object Sender, AddExclusionArgs e);
        internal event AddExclusionHandler AddExclusion;

        public int X_DirectionID
        {
            //repo
            set {
                throw new NotImplementedException();
                // cmbDirection.SelectedItem = DirectionManager.GetDirectionByID(value);
            }
        }

        //repo
        public frmExclusionsAdd()
        {
            throw new NotImplementedException();
            //InitializeComponent();
            //foreach (Direction _dir in DirectionManager.DirectionsList)
            //{
            //    cmbDirection.Items.Add(_dir);
            //}
            //cmbDirection.SelectedIndex = 0;
            //cmbDirection.DisplayMember = "FriendlyName";
            //cmbDirection.ValueMember = "ID";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {//excl
            /*bool _errorsFound = false;
            foreach (DataGridViewRow _row in dgvNewExclusions.Rows)
            {
                if (_row.IsNewRow) continue;
                bool _error = false;
                Direction _selectedDir = cmbDirection.SelectedItem as Direction;
                if (_selectedDir == null)
                {
                    errorProvider1.SetError(cmbDirection, "Select the direction");
                    _error = true;
                }
                if (_row.Cells[colSourceWord.Index].Value == null || string.IsNullOrEmpty(_row.Cells[colSourceWord.Index].Value.ToString()))
                {
                    if (_row.Cells[colTargetWord.Index].Value == null || string.IsNullOrEmpty(_row.Cells[colTargetWord.Index].Value.ToString()))
                    {
                        dgvNewExclusions.Rows.Remove(_row);
                    }
                    else
                    {
                        _row.ErrorText = "Source word must not be empty";
                    }
                    _error = true;
                }
                else
                {
                    if (_selectedDir != null && StorageManager.Instance.ExlusionSourceWords(_selectedDir.ID).Contains(_row.Cells[colSourceWord.Index].FormattedValue.ToString()))
                    {
                        _row.ErrorText = "Duplicate source word";
                        _error = true;
                    }
                }
                if (!_error)
                {
                    AddExclusion(this, new AddExclusionArgs(_row.Cells[colSourceWord.Index].FormattedValue.ToString(), _row.Cells[colTargetWord.Index].FormattedValue.ToString(),
                                                            (bool) _row.Cells[colMatchCase.Index].Value, (bool) _row.Cells[colMatchWord.Index].Value, _selectedDir.ID));
                    dgvNewExclusions.Rows.Remove(_row);
                }
                if (!_errorsFound) _errorsFound = _error;
            }
            if (!_errorsFound) this.Close();*/
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.SetError(cmbDirection, "");
        }

        private void dgvNewExclusions_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        private void dgvNewExclusions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvNewExclusions.Rows[e.RowIndex].ErrorText = "";
        }


        internal class AddExclusionArgs : EventArgs
        {
            private string sourceWord;

            public string SourceWord
            {
                get { return sourceWord; }
                set { sourceWord = value; }
            }
            private string targetWord;

            public string TargetWord
            {
                get { return targetWord; }
                set { targetWord = value; }
            }
            private int directionID;

            public int DirectionID
            {
                get { return directionID; }
                set { directionID = value; }
            }

            private bool matchCase;

            public bool MatchCase
            {
                get { return matchCase; }
                set { matchCase = value; }
            }

            private bool matchWholeWord;

            public bool MatchWholeWord
            {
                get { return matchWholeWord; }
                set { matchWholeWord = value; }
            }

            internal AddExclusionArgs(string Source, string Target, bool MatchCase, bool MatchWord, int DirID)
            {
                this.directionID = DirID;
                this.sourceWord = Source;
                this.targetWord = Target;
                this.matchCase = MatchCase;
                this.matchWholeWord = MatchWord;
            }
        }
    }
}
