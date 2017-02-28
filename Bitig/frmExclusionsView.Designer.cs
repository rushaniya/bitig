namespace Bitig.UI
{
    partial class frmExclusionsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblDirection = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.dgvExclusions = new System.Windows.Forms.DataGridView();
            this.bndExclusions = new System.Windows.Forms.BindingSource(this.components);
            this.colExclusionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatchCase = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMatchWord = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDirectionName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDirectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExclusions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndExclusions)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Location = new System.Drawing.Point(12, 14);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(52, 13);
            this.lblDirection.TabIndex = 0;
            this.lblDirection.Text = "Direction:";
            // 
            // cmbDirection
            // 
            this.cmbDirection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmbDirection.FormattingEnabled = true;
            this.cmbDirection.Location = new System.Drawing.Point(70, 9);
            this.cmbDirection.Name = "cmbDirection";
            this.cmbDirection.Size = new System.Drawing.Size(435, 24);
            this.cmbDirection.Sorted = true;
            this.cmbDirection.TabIndex = 1;
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblDirection);
            this.pnlTop.Controls.Add(this.cmbDirection);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(517, 42);
            this.pnlTop.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnDelete);
            this.pnlBottom.Controls.Add(this.btnEdit);
            this.pnlBottom.Controls.Add(this.btnAdd);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 332);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(517, 54);
            this.pnlBottom.TabIndex = 4;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(261, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(87, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.Location = new System.Drawing.Point(136, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 30);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.Location = new System.Drawing.Point(12, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 30);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // dgvExclusions
            // 
            this.dgvExclusions.AllowUserToAddRows = false;
            this.dgvExclusions.AllowUserToDeleteRows = false;
            this.dgvExclusions.AutoGenerateColumns = false;
            this.dgvExclusions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExclusions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExclusions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colExclusionID,
            this.colSourceWord,
            this.colTargetWord,
            this.colMatchCase,
            this.colMatchWord,
            this.colDirectionName,
            this.colDirectionID});
            this.dgvExclusions.DataSource = this.bndExclusions;
            this.dgvExclusions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExclusions.Location = new System.Drawing.Point(0, 42);
            this.dgvExclusions.Name = "dgvExclusions";
            this.dgvExclusions.ReadOnly = true;
            this.dgvExclusions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExclusions.Size = new System.Drawing.Size(517, 290);
            this.dgvExclusions.TabIndex = 5;
            this.dgvExclusions.DoubleClick += new System.EventHandler(this.dgvExclusions_DoubleClick);
            this.dgvExclusions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvExclusions_DataError);
            
            // 
            // colExclusionID
            // 
            this.colExclusionID.DataPropertyName = "exclusionID";
            this.colExclusionID.HeaderText = "exclusionID";
            this.colExclusionID.Name = "colExclusionID";
            this.colExclusionID.ReadOnly = true;
            this.colExclusionID.Visible = false;
            // 
            // colSourceWord
            // 
            this.colSourceWord.DataPropertyName = "sourceWord";
            this.colSourceWord.HeaderText = "sourceWord";
            this.colSourceWord.Name = "colSourceWord";
            this.colSourceWord.ReadOnly = true;
            // 
            // colTargetWord
            // 
            this.colTargetWord.DataPropertyName = "targetWord";
            this.colTargetWord.HeaderText = "targetWord";
            this.colTargetWord.Name = "colTargetWord";
            this.colTargetWord.ReadOnly = true;
            // 
            // colMatchCase
            // 
            this.colMatchCase.DataPropertyName = "matchCase";
            this.colMatchCase.HeaderText = "Match Case";
            this.colMatchCase.Name = "colMatchCase";
            this.colMatchCase.ReadOnly = true;
            // 
            // colMatchWord
            // 
            this.colMatchWord.DataPropertyName = "matchWholeWord";
            this.colMatchWord.HeaderText = "Match Whole Word";
            this.colMatchWord.Name = "colMatchWord";
            this.colMatchWord.ReadOnly = true;
            // 
            // colDirectionName
            // 
            this.colDirectionName.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.Nothing;
            this.colDirectionName.HeaderText = "Direction";
            this.colDirectionName.Name = "colDirectionName";
            this.colDirectionName.ReadOnly = true;
            this.colDirectionName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colDirectionName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colDirectionID
            // 
            this.colDirectionID.DataPropertyName = "directionID";
            this.colDirectionID.HeaderText = "directionID";
            this.colDirectionID.Name = "colDirectionID";
            this.colDirectionID.ReadOnly = true;
            this.colDirectionID.Visible = false;
            // 
            // frmExclusionsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(517, 386);
            this.Controls.Add(this.dgvExclusions);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmExclusionsView";
            this.Text = "Exclusions";
            this.Load += new System.EventHandler(this.frmExclusionsView_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExclusionsView_FormClosing);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExclusions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndExclusions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView dgvExclusions;
        private System.Windows.Forms.BindingSource bndExclusions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colExclusionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetWord;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMatchCase;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMatchWord;
        private System.Windows.Forms.DataGridViewComboBoxColumn colDirectionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectionID;
    }
}