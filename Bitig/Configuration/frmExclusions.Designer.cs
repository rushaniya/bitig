namespace Bitig.UI.Configuration
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
            this.dgvExclusions = new System.Windows.Forms.DataGridView();
            this.bndExclusions = new System.Windows.Forms.BindingSource(this.components);
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblDirection = new System.Windows.Forms.Label();
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.colSourceWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatchCase = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMatchBeginning = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colAnyPosition = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colValidationResult = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExclusions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndExclusions)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvExclusions
            // 
            this.dgvExclusions.AutoGenerateColumns = false;
            this.dgvExclusions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvExclusions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExclusions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSourceWord,
            this.colTargetWord,
            this.colMatchCase,
            this.colMatchBeginning,
            this.colAnyPosition,
            this.colValidationResult});
            this.dgvExclusions.DataSource = this.bndExclusions;
            this.dgvExclusions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvExclusions.Location = new System.Drawing.Point(0, 42);
            this.dgvExclusions.Name = "dgvExclusions";
            this.dgvExclusions.Size = new System.Drawing.Size(807, 366);
            this.dgvExclusions.TabIndex = 1;
            this.dgvExclusions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExclusions_CellContentClick);
            this.dgvExclusions.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvExclusions_RowValidating);
            // 
            // bndExclusions
            // 
            this.bndExclusions.DataSource = typeof(Bitig.Logic.Model.Exclusion);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblDirection);
            this.pnlTop.Controls.Add(this.cmbDirection);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(807, 42);
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
            this.cmbDirection.Size = new System.Drawing.Size(725, 24);
            this.cmbDirection.Sorted = true;
            this.cmbDirection.TabIndex = 1;
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 335);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(807, 73);
            this.pnlBottom.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(708, 15);
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
            this.btnOK.Location = new System.Drawing.Point(602, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 46);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // colSourceWord
            // 
            this.colSourceWord.DataPropertyName = "SourceWord";
            this.colSourceWord.HeaderText = "Source word";
            this.colSourceWord.Name = "colSourceWord";
            // 
            // colTargetWord
            // 
            this.colTargetWord.DataPropertyName = "TargetWord";
            this.colTargetWord.HeaderText = "Target word";
            this.colTargetWord.Name = "colTargetWord";
            // 
            // colMatchCase
            // 
            this.colMatchCase.DataPropertyName = "MatchCase";
            this.colMatchCase.HeaderText = "Match case";
            this.colMatchCase.Name = "colMatchCase";
            // 
            // colMatchBeginning
            // 
            this.colMatchBeginning.DataPropertyName = "MatchBeginning";
            this.colMatchBeginning.HeaderText = "Match in beginning";
            this.colMatchBeginning.Name = "colMatchBeginning";
            // 
            // colAnyPosition
            // 
            this.colAnyPosition.DataPropertyName = "AnyPosition";
            this.colAnyPosition.HeaderText = "Any position";
            this.colAnyPosition.Name = "colAnyPosition";
            // 
            // colValidationResult
            // 
            this.colValidationResult.HeaderText = "Warnings";
            this.colValidationResult.Name = "colValidationResult";
            this.colValidationResult.ReadOnly = true;
            this.colValidationResult.Text = "";
            // 
            // frmExclusions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(807, 408);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.dgvExclusions);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmExclusions";
            this.Text = "Exclusions";
            this.Load += new System.EventHandler(this.frmExclusions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvExclusions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndExclusions)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvExclusions;
        private System.Windows.Forms.BindingSource bndExclusions;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceWordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetWordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn directionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn matchMiddleDataGridViewCheckBoxColumn;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetWord;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMatchCase;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMatchBeginning;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colAnyPosition;
        private System.Windows.Forms.DataGridViewButtonColumn colValidationResult;
    }
}