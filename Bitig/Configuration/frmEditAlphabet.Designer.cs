namespace Bitig.UI.Configuration
{
    partial class frmEditAlphabet
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
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.txtDisplayName = new System.Windows.Forms.TextBox();
            this.lblLayout = new System.Windows.Forms.Label();
            this.cmbLayout = new System.Windows.Forms.ComboBox();
            this.lblFont = new System.Windows.Forms.Label();
            this.btnFont = new System.Windows.Forms.Button();
            this.dlgFont = new System.Windows.Forms.FontDialog();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.chkRightToLeft = new System.Windows.Forms.CheckBox();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(12, 21);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Size = new System.Drawing.Size(85, 13);
            this.lblDisplayName.TabIndex = 0;
            this.lblDisplayName.Text = "Displayed name:";
            // 
            // txtDisplayName
            // 
            this.txtDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDisplayName.Location = new System.Drawing.Point(125, 18);
            this.txtDisplayName.Name = "txtDisplayName";
            this.txtDisplayName.Size = new System.Drawing.Size(279, 20);
            this.txtDisplayName.TabIndex = 0;
            // 
            // lblLayout
            // 
            this.lblLayout.AutoSize = true;
            this.lblLayout.Location = new System.Drawing.Point(12, 61);
            this.lblLayout.Name = "lblLayout";
            this.lblLayout.Size = new System.Drawing.Size(86, 13);
            this.lblLayout.TabIndex = 2;
            this.lblLayout.Text = "Keyboard layout:";
            // 
            // cmbLayout
            // 
            this.cmbLayout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbLayout.Enabled = false;
            this.cmbLayout.FormattingEnabled = true;
            this.cmbLayout.Location = new System.Drawing.Point(125, 57);
            this.cmbLayout.Name = "cmbLayout";
            this.cmbLayout.Size = new System.Drawing.Size(279, 21);
            this.cmbLayout.TabIndex = 1;
            // 
            // lblFont
            // 
            this.lblFont.AutoEllipsis = true;
            this.lblFont.AutoSize = true;
            this.lblFont.Location = new System.Drawing.Point(12, 101);
            this.lblFont.Name = "lblFont";
            this.lblFont.Size = new System.Drawing.Size(31, 13);
            this.lblFont.TabIndex = 4;
            this.lblFont.Text = "Font:";
            // 
            // btnFont
            // 
            this.btnFont.Location = new System.Drawing.Point(15, 131);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(111, 28);
            this.btnFont.TabIndex = 2;
            this.btnFont.Text = "Select font...";
            this.btnFont.UseVisualStyleBackColor = true;
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 214);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(416, 73);
            this.pnlBottom.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(317, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 46);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(211, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 46);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // chkRightToLeft
            // 
            this.chkRightToLeft.AutoSize = true;
            this.chkRightToLeft.Location = new System.Drawing.Point(15, 179);
            this.chkRightToLeft.Name = "chkRightToLeft";
            this.chkRightToLeft.Size = new System.Drawing.Size(80, 17);
            this.chkRightToLeft.TabIndex = 3;
            this.chkRightToLeft.Text = "Right to left";
            this.chkRightToLeft.UseVisualStyleBackColor = true;
            // 
            // frmEditAlphabet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 287);
            this.Controls.Add(this.chkRightToLeft);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.btnFont);
            this.Controls.Add(this.lblFont);
            this.Controls.Add(this.cmbLayout);
            this.Controls.Add(this.lblLayout);
            this.Controls.Add(this.txtDisplayName);
            this.Controls.Add(this.lblDisplayName);
            this.Name = "frmEditAlphabet";
            this.Text = "Alphabet";
            this.Load += new System.EventHandler(this.frmEditAlphabet_Load);
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.TextBox txtDisplayName;
        private System.Windows.Forms.Label lblLayout;
        private System.Windows.Forms.ComboBox cmbLayout;
        private System.Windows.Forms.Label lblFont;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.FontDialog dlgFont;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkRightToLeft;
    }
}