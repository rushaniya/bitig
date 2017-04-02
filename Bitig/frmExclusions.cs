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
using Bitig.Logic.Repository;

namespace Bitig.UI
{
    public partial class frmExclusions : Form
    {
        private DirectionRepository x_DirectionRepo;

        public frmExclusions(DirectionRepository DirectionRepo, Direction DefaultDirection)
        {
            InitializeComponent();
            var _bindingList = new BindingList<Exclusion>(DefaultDirection.Exclusions);
            dataGridView1.DataSource = _bindingList;
            x_DirectionRepo = DirectionRepo;
        }

        //excl
        private void frmExclusions_Load(object sender, EventArgs e)
        {
           /* dataGridView1.DataSource = Logic.StorageManager.Instance.ExclusionsTable;
            colSource.DataSource = Logic.StorageManager.Instance.AlifbaTable;
            foreach (DataGridViewRow _row in dataGridView1.Rows)
            {
                if (_row.Cells[colDirectionID.Index].Value != null)
                {
                    DataGridViewCellEventArgs _e = new DataGridViewCellEventArgs(colDirectionID.Index, _row.Index);
                    dataGridView1_CellValueChanged(null, _e);
                }
                if (_row.Cells[colSource.Index].Value != null)
                {
                    DataGridViewCellEventArgs _e = new DataGridViewCellEventArgs(colSource.Index, _row.Index);
                    dataGridView1_CellValueChanged(null, _e);
                }
            }
            */
        }

        private void frmExclusions_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  StorageManager.Instance.SaveExclusionsTable();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //excl: update directions' exclusions
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {/*
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == colDirectionID.Index)
                {
                    var _query = from _dir in StorageManager.Instance.DirectionsTable
                                 where _dir.directionID == (int)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                                 select _dir.sourceAlifbaID;
                    dataGridView1.Rows[e.RowIndex].Cells[colSource.Index].Value = _query.First();
                    LoadTargetList(e.RowIndex, _query.First());

                    _query = from _dir in StorageManager.Instance.DirectionsTable
                             where _dir.directionID == (int)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value
                             select _dir.targetAlifbaID;
                    dataGridView1.Rows[e.RowIndex].Cells[colTarget.Index].Value = _query.First();
                }

                else if (e.ColumnIndex == colSource.Index && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value as int? != null)
                {
                    LoadTargetList(e.RowIndex, (int)dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                }

                else if (e.ColumnIndex == colTarget.Index)
                {
                    var _query = from _dir in StorageManager.Instance.DirectionsTable
                                 where _dir.targetAlifbaID == (int)dataGridView1.Rows[e.RowIndex].Cells[colTarget.Index].Value
                                 && _dir.sourceAlifbaID == (int)dataGridView1.Rows[e.RowIndex].Cells[colSource.Index].Value
                                 select _dir;
                    dataGridView1.Rows[e.RowIndex].Cells[colDirectionID.Index].Value = _query.First().directionID;
                }
            }*/
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

 
        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

        }


        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void LoadTargetList(int RowIndex, int SourceID)
        {/*
            DataGridViewComboBoxCell _cell = (DataGridViewComboBoxCell)dataGridView1.Rows[RowIndex].Cells[colTarget.Index];
            var _queryList = Logic.StorageManager.Instance.DirectionsTable.Join(Logic.StorageManager.Instance.AlifbaTable, _direction => _direction.targetAlifbaID,
            _alifba => _alifba.alifbaID, (_direction, _alifba) => new { _friendlyName = _alifba.friendlyName, _targetID = _direction.targetAlifbaID, _sourceID = _direction.sourceAlifbaID }).ToList();
            _cell.DataSource = _queryList.Where(_item => _item._sourceID == SourceID).ToList();
            _cell.DisplayMember = "_friendlyName";
            _cell.ValueMember = "_targetID";*/
        }
    }
}
