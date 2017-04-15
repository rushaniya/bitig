namespace Bitig.UI.Configuration
{
    partial class frmEditDirection
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
            this.lblSource = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblAssembly = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.dlgBrowseAssembly = new System.Windows.Forms.OpenFileDialog();
            this.cmbSource = new System.Windows.Forms.ComboBox();
            this.cmbTarget = new System.Windows.Forms.ComboBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.tipAssembly = new System.Windows.Forms.ToolTip(this.components);
            this.cmbAssembly = new Bitig.UI.Controls.ctlCustomCombo();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 189);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(372, 73);
            this.pnlBottom.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(273, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 46);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(167, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 46);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(12, 21);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(88, 13);
            this.lblSource.TabIndex = 6;
            this.lblSource.Text = "Source alphabet:";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(12, 61);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(85, 13);
            this.lblTarget.TabIndex = 7;
            this.lblTarget.Text = "Target alphabet:";
            // 
            // lblAssembly
            // 
            this.lblAssembly.AutoSize = true;
            this.lblAssembly.Location = new System.Drawing.Point(12, 101);
            this.lblAssembly.Name = "lblAssembly";
            this.lblAssembly.Size = new System.Drawing.Size(41, 13);
            this.lblAssembly.TabIndex = 8;
            this.lblAssembly.Text = "Library:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(12, 141);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(63, 13);
            this.lblType.TabIndex = 9;
            this.lblType.Text = "Type name:";
            // 
            // cmbSource
            // 
            this.cmbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.FormattingEnabled = true;
            this.cmbSource.Location = new System.Drawing.Point(124, 18);
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(236, 21);
            this.cmbSource.TabIndex = 0;
            // 
            // cmbTarget
            // 
            this.cmbTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarget.FormattingEnabled = true;
            this.cmbTarget.Location = new System.Drawing.Point(124, 58);
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(236, 21);
            this.cmbTarget.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(124, 138);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(236, 21);
            this.cmbType.TabIndex = 3;
            // 
            // cmbAssembly
            // 
            this.cmbAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbAssembly.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAssembly.FormattingEnabled = true;
            this.cmbAssembly.Location = new System.Drawing.Point(124, 98);
            this.cmbAssembly.Name = "cmbAssembly";
            this.cmbAssembly.Size = new System.Drawing.Size(236, 21);
            this.cmbAssembly.TabIndex = 2;
            this.cmbAssembly.SelectedIndexChanging += new System.EventHandler<System.ComponentModel.CancelEventArgs>(this.cmbAssembly_SelectedIndexChanging);
            this.cmbAssembly.SelectedIndexChanged += new System.EventHandler(this.cmbAssembly_SelectedIndexChanged);
            // 
            // frmEditDirection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 262);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.cmbAssembly);
            this.Controls.Add(this.cmbTarget);
            this.Controls.Add(this.cmbSource);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lblAssembly);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblSource);
            this.Controls.Add(this.pnlBottom);
            this.MinimumSize = new System.Drawing.Size(388, 300);
            this.Name = "frmEditDirection";
            this.Text = "Transliteration direction";
            this.Load += new System.EventHandler(this.frmEditDirection_Load);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblAssembly;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.OpenFileDialog dlgBrowseAssembly;
        private System.Windows.Forms.ComboBox cmbSource;
        private System.Windows.Forms.ComboBox cmbTarget;
        private Bitig.UI.Controls.ctlCustomCombo cmbAssembly;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.ToolTip tipAssembly;
    }
}