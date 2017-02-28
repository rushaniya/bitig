
using System;
using System.Drawing;
using System.Windows.Forms;
using Bitig.Logic;
using System.Collections.Generic;

namespace Bitig.UI
{
	public partial class frmExclusionEdit : Form
	{
		private int x_DirectionID = -1;
		public int X_DirectionID
		{
			get
			{
				return x_DirectionID;
			}
			set
			{
                //repo
                throw new NotImplementedException();
               // cmbDirection.SelectedItem = DirectionManager.GetDirectionByID(value);
				x_DirectionID = value;
            }
		}
		
		private string x_Source = string.Empty;
		
		public string X_Source
		{
			get { return x_Source; }
			set
			{
				x_Source = value;
				txtSource.Text = value;
			}
		}
		
		private string x_Target = string.Empty;
		
		public string X_Target
		{
			get { return x_Target; }
			set
			{
				x_Target = value;
				txtTarget.Text = value;
			}
		}
		
		private bool x_MatchCase = false;
		
		public bool X_MatchCase
		{
			get { return x_MatchCase; }
			set
			{
				x_MatchCase = value;
				chkMatchCase.Checked = value;
			}
		}

        private bool x_MatchWord = false;

        public bool X_MatchWord
        {
            get { return x_MatchWord; }
            set
            {
                x_MatchWord = value;
                chkMatchWord.Checked = value;
            }
        }

        //repo
        public frmExclusionEdit()
		{
            throw new NotImplementedException();
            //InitializeComponent();
            //         cmbDirection.DataSource = DirectionManager.DirectionsList;
            //cmbDirection.DisplayMember = "FriendlyName";
        }

        //repo
        public frmExclusionEdit(int DirectionID)
        {
            throw new NotImplementedException();
            //InitializeComponent();
            //cmbDirection.DisplayMember = "FriendlyName";
            //bndDirection.DataSource = DirectionManager.DirectionsList;
            //cmbDirection.SelectedItem = DirectionManager.GetDirectionByID(DirectionID);
            //bndDirection.Position = DirectionID;
            //bndDirection.ResetBindings(false);
            //bndDirection.ResetCurrentItem();
            //cmbDirection.SelectedIndex = 5;
        }
		
		private void btnSave_Click(object sender, EventArgs e)
		{
            //excl
			/*bool _error = false;
			Direction _selectedDir = cmbDirection.SelectedItem as Direction;
			if (_selectedDir == null)
			{
				errorProvider1.SetError(cmbDirection, "Select the direction");
				_error = true;
			}
			if(string.IsNullOrEmpty(txtSource.Text))
			{
				errorProvider1.SetError(txtSource, "Source word must not be empty");
				_error = true;
			}
			else
			{
				if(txtSource.Text != x_Source && _selectedDir != null && StorageManager.Instance.ExlusionSourceWords(_selectedDir.ID).Contains(txtSource.Text))
				{
					errorProvider1.SetError(txtSource, "Duplicate source word");
					_error = true;
				}
			}
			if(!_error)
			{
				x_Source = txtSource.Text;
				x_Target = txtTarget.Text;
				x_DirectionID = _selectedDir.ID;
                x_MatchCase = chkMatchCase.Checked;
                x_MatchWord = chkMatchWord.Checked;
				this.DialogResult = DialogResult.OK;
			}*/
		}
		
		private void cmbDirection_SelectedIndexChanged(object sender, EventArgs e)
		{
			errorProvider1.SetError(cmbDirection, "");
		}
		
		private void txtSource_TextChanged(object sender, EventArgs e)
		{
			errorProvider1.SetError(txtSource, "");
		}
		
		private void txtTarget_TextChanged(object sender, EventArgs e)
		{
			errorProvider1.SetError(txtTarget, "");
		}

        private void frmExclusionEdit_Load(object sender, EventArgs e)
        {
            //cmbDirection.SelectedItem = DirectionManager.GetDirectionByID(x_DirectionID);
        }
	}
}
