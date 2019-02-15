namespace Bitig.UI.Configuration
{
    partial class frmSymbolMapping
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dgvSymbolMapping = new System.Windows.Forms.DataGridView();
            this.colSourceLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bndSymbols = new System.Windows.Forms.BindingSource(this.components);
            this.btnFlip = new System.Windows.Forms.Button();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbolMapping)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndSymbols)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnFlip);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 448);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(629, 74);
            this.pnlBottom.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(530, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 46);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(424, 16);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 46);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvSymbolMapping
            // 
            this.dgvSymbolMapping.AutoGenerateColumns = false;
            this.dgvSymbolMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSymbolMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSymbolMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSourceLower,
            this.colSourceUpper,
            this.colTargetLower,
            this.colTargetUpper});
            this.dgvSymbolMapping.DataSource = this.bndSymbols;
            this.dgvSymbolMapping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSymbolMapping.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSymbolMapping.Location = new System.Drawing.Point(0, 0);
            this.dgvSymbolMapping.Name = "dgvSymbolMapping";
            this.dgvSymbolMapping.Size = new System.Drawing.Size(629, 448);
            this.dgvSymbolMapping.TabIndex = 1;
            // 
            // colSourceLower
            // 
            this.colSourceLower.DataPropertyName = "SourceLower";
            this.colSourceLower.HeaderText = "Source symbol";
            this.colSourceLower.Name = "colSourceLower";
            this.colSourceLower.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colSourceUpper
            // 
            this.colSourceUpper.DataPropertyName = "SourceUpper";
            this.colSourceUpper.HeaderText = "Capitalized source symbol";
            this.colSourceUpper.Name = "colSourceUpper";
            this.colSourceUpper.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTargetLower
            // 
            this.colTargetLower.DataPropertyName = "TargetLower";
            this.colTargetLower.HeaderText = "Target symbol";
            this.colTargetLower.Name = "colTargetLower";
            this.colTargetLower.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // colTargetUpper
            // 
            this.colTargetUpper.DataPropertyName = "TargetUpper";
            this.colTargetUpper.HeaderText = "Capitalized target symbol";
            this.colTargetUpper.Name = "colTargetUpper";
            this.colTargetUpper.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // bndSymbols
            // 
            this.bndSymbols.DataSource = typeof(Bitig.UI.Configuration.Model.SymbolPair);
            // 
            // btnFlip
            // 
            this.btnFlip.Location = new System.Drawing.Point(12, 16);
            this.btnFlip.Name = "btnFlip";
            this.btnFlip.Size = new System.Drawing.Size(173, 46);
            this.btnFlip.TabIndex = 2;
            this.btnFlip.Text = "Create opposite direction";
            this.btnFlip.UseVisualStyleBackColor = true;
            this.btnFlip.Click += new System.EventHandler(this.btnFlip_Click);
            // 
            // frmSymbolMapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 522);
            this.Controls.Add(this.dgvSymbolMapping);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmSymbolMapping";
            this.Text = "Symbol mapping";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbolMapping)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndSymbols)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.DataGridView dgvSymbolMapping;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.BindingSource bndSymbols;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceLower;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetLower;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetUpper;
        private System.Windows.Forms.Button btnFlip;
    }
}