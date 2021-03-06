﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Bitig.Logic.Model;
using Bitig.Logic.Repository;

namespace Bitig.UI.Configuration
{
    public partial class frmExclusions : Form
    {
        private DirectionRepository x_DirectionRepo;
        private IDataContext x_DataContext;
        private Dictionary<int, BindingList<Exclusion>> x_BindingLists = new Dictionary<int, BindingList<Exclusion>>();
        private Direction x_SelectedDirection;
        private bool x_IndependentMode;
        private int x_PreviousIndex = -1;
        private Dictionary<int, string> x_ValidationResults = new Dictionary<int, string>();
        private const int SOURCE_WORD_COLUMN = 0;
        private const int TARGET_WORD_COLUMN = 1;
        private const int MATCH_CASE_COLUMN = 2;
        private const int MATCH_BEGINNING_COLUMN = 3;
        private const int ANY_POSITION_COLUMN = 4;
        private const int VALIDATION_RESULT_COLUMN = 5;

        private bool x_Loading = true;

        public frmExclusions(Direction CurrentDirection, IDataContext DataContext, bool AllowChangeDirection = false)
        {
            InitializeComponent();
            x_DataContext = DataContext;
            x_DirectionRepo = DataContext.DirectionRepository;
            if (AllowChangeDirection)
            {
                x_IndependentMode = true;
                var _directions = x_DirectionRepo.GetList();
                x_SelectedDirection = CurrentDirection ?? _directions[0];
                cmbDirection.Items.AddRange(_directions.ToArray());
            }
            else
            {
                if (CurrentDirection == null)
                    throw new ArgumentException("Must pass current direction");
                x_SelectedDirection = CurrentDirection;
                cmbDirection.Items.Add(x_SelectedDirection);
                cmbDirection.Enabled = false;
            }
            cmbDirection.SelectedItem = x_SelectedDirection;
        }

        private void frmExclusions_Load(object sender, EventArgs e)
        {
            x_Loading = false;
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!ValidateCurrentExclusions())
            {
                if (x_PreviousIndex != -1)
                    cmbDirection.SelectedIndex = x_PreviousIndex;
                return;
            }
            GetSelectedDirection();
        }

        private bool ValidateCurrentExclusions()
        {
            for (var i = 0; i < dgvExclusions.RowCount; i++)
            {
                if (!ValidateRow(i))
                    return false;
            }
            return true;
        }

        private bool ValidateRow(int RowIndex)
        {
            if (x_Loading)
                return true;
            if (!x_BindingLists.ContainsKey(x_SelectedDirection.ID))
                return true;
            x_ValidationResults[RowIndex] = null;
            dgvExclusions.Rows[RowIndex].Cells[VALIDATION_RESULT_COLUMN].Value = null;
            var _row = dgvExclusions.Rows[RowIndex];
            if (_row.Cells[0].Value == null && _row.Cells[1].Value == null)
                return true;
            var _source = (string)_row.Cells[SOURCE_WORD_COLUMN].Value;
            if (string.IsNullOrEmpty(_source))
                return true;
            var _target = (string)_row.Cells[TARGET_WORD_COLUMN].Value;
            var _fullDirection = x_DataContext.DirectionRepository.Get(x_SelectedDirection.ID);
            _fullDirection.Exclusions = x_BindingLists[x_SelectedDirection.ID]
                .Where(_excl => !string.IsNullOrEmpty(_excl.SourceWord))
                .ToList();  
            List<string> _warnings, _errors;
            var _exclusion = new Exclusion
            (
                SourceWord: _source,
                TargetWord: _target ?? string.Empty,
                MatchBeginning: _row.Cells[MATCH_BEGINNING_COLUMN].Value == null ? false : Convert.ToBoolean(_row.Cells[MATCH_BEGINNING_COLUMN].Value),
                AnyPosition: _row.Cells[ANY_POSITION_COLUMN].Value == null ? false : Convert.ToBoolean(_row.Cells[ANY_POSITION_COLUMN].Value),
                MatchCase: _row.Cells[MATCH_CASE_COLUMN].Value == null ? false : Convert.ToBoolean(_row.Cells[MATCH_CASE_COLUMN].Value)
            );
            if (!_fullDirection.IsValidExclusion(_exclusion, out _errors, out _warnings) || _warnings.Count > 0)
            {
                x_ValidationResults[RowIndex] = _errors.Union(_warnings).Aggregate((x, y) => x + Environment.NewLine + y);
                dgvExclusions.Rows[RowIndex].Cells[VALIDATION_RESULT_COLUMN].Value = "!";
            } 
            return true;
        }

        private void GetSelectedDirection()
        {
            x_SelectedDirection = cmbDirection.SelectedItem as Direction;
            dgvExclusions.DataSource = null;
            if(!x_BindingLists.ContainsKey(x_SelectedDirection.ID))
            {
                var _fullDirection = x_DataContext.DirectionRepository.Get(x_SelectedDirection.ID);
                x_BindingLists.Add(x_SelectedDirection.ID, new BindingList<Exclusion>(_fullDirection.Exclusions));
            }
            dgvExclusions.DataSource = x_BindingLists[x_SelectedDirection.ID];
            x_PreviousIndex = cmbDirection.SelectedIndex;
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!ValidateCurrentExclusions()) return;
            foreach (var _exclList in x_BindingLists)
            {
                var _direction = x_DirectionRepo.Get(_exclList.Key);
                _direction.Exclusions = _exclList.Value.Where(_excl=>!string.IsNullOrEmpty(_excl.SourceWord)).ToList();
                x_DirectionRepo.Update(_direction);
            }
            if(x_IndependentMode)
            {
                x_DataContext.SaveChanges();
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvExclusions.CancelEdit();
            DialogResult = DialogResult.Cancel;
        }

        private void dgvExclusions_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            e.Cancel = !ValidateRow(e.RowIndex);
        }

        private void dgvExclusions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (x_ValidationResults.ContainsKey(e.RowIndex))
                {
                    MessageBox.Show(x_ValidationResults[e.RowIndex], "!", MessageBoxButtons.OK);
                }
            }
        }
    }
}
