using System;
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
        private IRepository<Direction,int> x_DirectionRepo;
        private Dictionary<int, BindingList<Exclusion>> x_BindingLists = new Dictionary<int, BindingList<Exclusion>>();
        private Direction x_Direction;
        private bool x_IndependentMode;

        public frmExclusions(Direction CurrentDirection, IRepository<Direction, int> DirectionRepo, bool AllowChangeDirection = false)
        {
            InitializeComponent();
            if (AllowChangeDirection)
            {
                x_IndependentMode = true;
                var _directions = DirectionRepo.GetList();
                x_Direction = CurrentDirection ?? _directions[0];
                cmbDirection.Items.AddRange(_directions.ToArray());
            }
            else
            {
                if (CurrentDirection == null)
                    throw new InvalidOperationException("Must pass current direction");
                x_Direction = CurrentDirection;
                cmbDirection.Items.Add(x_Direction);
                cmbDirection.Enabled = false;
            }
            cmbDirection.SelectedItem = x_Direction;
            x_DirectionRepo = DirectionRepo;
        }

        private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSelectedDirection();
        }

        private void GetSelectedDirection()
        {
            x_Direction = cmbDirection.SelectedItem as Direction;
            dgvExclusions.DataSource = null;
            if (x_Direction == null)
                return;
            if(!x_BindingLists.ContainsKey(x_Direction.ID))
            {
                x_BindingLists.Add(x_Direction.ID, new BindingList<Exclusion>(x_Direction.Exclusions));
            }
            dgvExclusions.DataSource = x_BindingLists[x_Direction.ID];
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

 
        private void dataGridView1_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //excl: validate
            foreach (var _exclList in x_BindingLists)
            {
                var _direction = x_DirectionRepo.Get(_exclList.Key);
                _direction.Exclusions = _exclList.Value.ToList();
                x_DirectionRepo.Update(_direction);
            }
            if(x_IndependentMode)
            {
                x_DirectionRepo.SaveChanges();
            }
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
