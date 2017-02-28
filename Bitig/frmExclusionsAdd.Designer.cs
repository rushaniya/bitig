namespace Bitig.UI
{
    partial class frmExclusionsAdd
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
            this.cmbDirection = new System.Windows.Forms.ComboBox();
            this.lblDirection = new System.Windows.Forms.Label();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.dgvNewExclusions = new System.Windows.Forms.DataGridView();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.colSourceWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetWord = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMatchCase = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colMatchWord = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewExclusions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.cmbDirection.Size = new System.Drawing.Size(409, 24);
            this.cmbDirection.Sorted = true;
            this.cmbDirection.TabIndex = 1;
            this.cmbDirection.SelectedIndexChanged += new System.EventHandler(this.cmbDirection_SelectedIndexChanged);
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
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnAdd);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 288);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(491, 54);
            this.pnlBottom.TabIndex = 7;
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
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.lblDirection);
            this.pnlTop.Controls.Add(this.cmbDirection);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(491, 42);
            this.pnlTop.TabIndex = 6;
            // 
            // dgvNewExclusions
            // 
            this.dgvNewExclusions.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNewExclusions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNewExclusions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSourceWord,
            this.colTargetWord,
            this.colMatchCase,
            this.colMatchWord});
            this.dgvNewExclusions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNewExclusions.Location = new System.Drawing.Point(0, 42);
            this.dgvNewExclusions.Name = "dgvNewExclusions";
            this.dgvNewExclusions.Size = new System.Drawing.Size(491, 246);
            this.dgvNewExclusions.TabIndex = 8;
            this.dgvNewExclusions.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvNewExclusions_CellValidating);
            this.dgvNewExclusions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvNewExclusions_CellEndEdit);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // colSourceWord
            // 
            this.colSourceWord.HeaderText = "Source Word";
            this.colSourceWord.Name = "colSourceWord";
            // 
            // colTargetWord
            // 
            this.colTargetWord.HeaderText = "Target Word";
            this.colTargetWord.Name = "colTargetWord";
            // 
            // colMatchCase
            // 
            this.colMatchCase.HeaderText = "Match Case";
            this.colMatchCase.Name = "colMatchCase";
            this.colMatchCase.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colMatchCase.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // colMatchWord
            // 
            this.colMatchWord.HeaderText = "Match Whole Word";
            this.colMatchWord.Name = "colMatchWord";
            // 
            // frmExclusionsAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 342);
            this.Controls.Add(this.dgvNewExclusions);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "frmExclusionsAdd";
            this.Text = "Add Exclusions";
            this.pnlBottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNewExclusions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.ErrorProvider errorProvider1;

        #endregion

        private System.Windows.Forms.ComboBox cmbDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.DataGridView dgvNewExclusions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceWord;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetWord;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMatchCase;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colMatchWord;
    }
}