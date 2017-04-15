namespace Bitig.UI
{
    partial class frmExclusions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvExclusions = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matchCaseDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.matchBeginningDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mainDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDirection = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExclusions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSetBindingSource)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvExclusions
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dgvExclusions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvExclusions.AutoGenerateColumns = false;
            this.dgvExclusions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExclusions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExclusions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.matchCaseDataGridViewCheckBoxColumn,
            this.matchBeginningDataGridViewCheckBoxColumn});
            this.dgvExclusions.DataSource = this.mainDataSetBindingSource;
            this.dgvExclusions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExclusions.Location = new System.Drawing.Point(0, 42);
            this.dgvExclusions.Name = "dgvExclusions";
            this.dgvExclusions.Size = new System.Drawing.Size(524, 366);
            this.dgvExclusions.TabIndex = 1;
            this.dgvExclusions.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            this.dgvExclusions.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dgvExclusions.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dgvExclusions.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SourceWord";
            this.dataGridViewTextBoxColumn1.HeaderText = "SourceWord";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TargetWord";
            this.dataGridViewTextBoxColumn2.HeaderText = "TargetWord";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // matchCaseDataGridViewCheckBoxColumn
            // 
            this.matchCaseDataGridViewCheckBoxColumn.DataPropertyName = "MatchCase";
            this.matchCaseDataGridViewCheckBoxColumn.HeaderText = "MatchCase";
            this.matchCaseDataGridViewCheckBoxColumn.Name = "matchCaseDataGridViewCheckBoxColumn";
            // 
            // matchBeginningDataGridViewCheckBoxColumn
            // 
            this.matchBeginningDataGridViewCheckBoxColumn.DataPropertyName = "MatchBeginning";
            this.matchBeginningDataGridViewCheckBoxColumn.HeaderText = "MatchBeginning";
            this.matchBeginningDataGridViewCheckBoxColumn.Name = "matchBeginningDataGridViewCheckBoxColumn";
            // 
            // mainDataSetBindingSource
            // 
            this.mainDataSetBindingSource.DataSource = typeof(Bitig.Logic.Model.Exclusion);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblDirection);
            this.pnlTop.Controls.Add(this.cmbDirection);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(524, 42);
            this.pnlTop.TabIndex = 4;
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
            this.cmbDirection.Size = new System.Drawing.Size(442, 24);
            this.cmbDirection.Sorted = true;
            this.cmbDirection.TabIndex = 1;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 335);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(524, 73);
            this.pnlBottom.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(425, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 46);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(319, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 46);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // frmExclusions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(524, 408);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvExclusions);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmExclusions";
            this.Text = "frmExclusions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExclusions_FormClosing);
            this.Load += new System.EventHandler(this.frmExclusions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExclusions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSetBindingSource)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvExclusions;
        private System.Windows.Forms.BindingSource mainDataSetBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceWordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetWordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn directionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn matchCaseDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn matchBeginningDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn matchMiddleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}