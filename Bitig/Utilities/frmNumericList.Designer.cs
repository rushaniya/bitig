namespace Bitig.UI.Utilities
{
    partial class frmNumericList
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
            this.lblStart = new System.Windows.Forms.Label();
            this.grpStyle = new System.Windows.Forms.GroupBox();
            this.grpFormat = new System.Windows.Forms.GroupBox();
            this.rdbArabic = new System.Windows.Forms.RadioButton();
            this.rdbLCLetter = new System.Windows.Forms.RadioButton();
            this.rdbUCLetter = new System.Windows.Forms.RadioButton();
            this.rdbLCRoman = new System.Windows.Forms.RadioButton();
            this.rdbUCRoman = new System.Windows.Forms.RadioButton();
            this.rdbParen = new System.Windows.Forms.RadioButton();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.chkHideNumbers = new System.Windows.Forms.CheckBox();
            this.rdbPeriod = new System.Windows.Forms.RadioButton();
            this.rdbParens = new System.Windows.Forms.RadioButton();
            this.rdbPlain = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblIndent = new System.Windows.Forms.Label();
            this.nudStart = new System.Windows.Forms.NumericUpDown();
            this.nudIndent = new System.Windows.Forms.NumericUpDown();
            this.grpStyle.SuspendLayout();
            this.grpFormat.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndent)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(3, 48);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(54, 13);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Start with:";
            // 
            // grpStyle
            // 
            this.grpStyle.Controls.Add(this.rdbUCRoman);
            this.grpStyle.Controls.Add(this.rdbLCRoman);
            this.grpStyle.Controls.Add(this.rdbUCLetter);
            this.grpStyle.Controls.Add(this.rdbLCLetter);
            this.grpStyle.Controls.Add(this.rdbArabic);
            this.grpStyle.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStyle.Location = new System.Drawing.Point(0, 0);
            this.grpStyle.Name = "grpStyle";
            this.grpStyle.Size = new System.Drawing.Size(377, 99);
            this.grpStyle.TabIndex = 0;
            this.grpStyle.TabStop = false;
            this.grpStyle.Text = "Style";
            // 
            // grpFormat
            // 
            this.grpFormat.Controls.Add(this.rdbPlain);
            this.grpFormat.Controls.Add(this.rdbParens);
            this.grpFormat.Controls.Add(this.rdbPeriod);
            this.grpFormat.Controls.Add(this.rdbParen);
            this.grpFormat.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFormat.Location = new System.Drawing.Point(0, 99);
            this.grpFormat.Name = "grpFormat";
            this.grpFormat.Size = new System.Drawing.Size(377, 53);
            this.grpFormat.TabIndex = 1;
            this.grpFormat.TabStop = false;
            this.grpFormat.Text = "Format";
            // 
            // rdbArabic
            // 
            this.rdbArabic.AutoSize = true;
            this.rdbArabic.Location = new System.Drawing.Point(6, 19);
            this.rdbArabic.Name = "rdbArabic";
            this.rdbArabic.Size = new System.Drawing.Size(64, 17);
            this.rdbArabic.TabIndex = 0;
            this.rdbArabic.TabStop = true;
            this.rdbArabic.Text = "1, 2, 3...";
            this.rdbArabic.UseVisualStyleBackColor = true;
            // 
            // rdbLCLetter
            // 
            this.rdbLCLetter.AutoSize = true;
            this.rdbLCLetter.Location = new System.Drawing.Point(6, 42);
            this.rdbLCLetter.Name = "rdbLCLetter";
            this.rdbLCLetter.Size = new System.Drawing.Size(64, 17);
            this.rdbLCLetter.TabIndex = 1;
            this.rdbLCLetter.TabStop = true;
            this.rdbLCLetter.Text = "a, b, c...";
            this.rdbLCLetter.UseVisualStyleBackColor = true;
            // 
            // rdbUCLetter
            // 
            this.rdbUCLetter.AutoSize = true;
            this.rdbUCLetter.Location = new System.Drawing.Point(6, 65);
            this.rdbUCLetter.Name = "rdbUCLetter";
            this.rdbUCLetter.Size = new System.Drawing.Size(67, 17);
            this.rdbUCLetter.TabIndex = 2;
            this.rdbUCLetter.TabStop = true;
            this.rdbUCLetter.Text = "A, B, C...";
            this.rdbUCLetter.UseVisualStyleBackColor = true;
            // 
            // rdbLCRoman
            // 
            this.rdbLCRoman.AutoSize = true;
            this.rdbLCRoman.Location = new System.Drawing.Point(99, 19);
            this.rdbLCRoman.Name = "rdbLCRoman";
            this.rdbLCRoman.Size = new System.Drawing.Size(58, 17);
            this.rdbLCRoman.TabIndex = 3;
            this.rdbLCRoman.TabStop = true;
            this.rdbLCRoman.Text = "i, ii, iii...";
            this.rdbLCRoman.UseVisualStyleBackColor = true;
            // 
            // rdbUCRoman
            // 
            this.rdbUCRoman.AutoSize = true;
            this.rdbUCRoman.Location = new System.Drawing.Point(99, 42);
            this.rdbUCRoman.Name = "rdbUCRoman";
            this.rdbUCRoman.Size = new System.Drawing.Size(64, 17);
            this.rdbUCRoman.TabIndex = 4;
            this.rdbUCRoman.TabStop = true;
            this.rdbUCRoman.Text = "I, II, III...";
            this.rdbUCRoman.UseVisualStyleBackColor = true;
            // 
            // rdbParen
            // 
            this.rdbParen.AutoSize = true;
            this.rdbParen.Location = new System.Drawing.Point(6, 19);
            this.rdbParen.Name = "rdbParen";
            this.rdbParen.Size = new System.Drawing.Size(34, 17);
            this.rdbParen.TabIndex = 0;
            this.rdbParen.TabStop = true;
            this.rdbParen.Text = "1)";
            this.rdbParen.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.nudIndent);
            this.pnlBottom.Controls.Add(this.nudStart);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Controls.Add(this.chkHideNumbers);
            this.pnlBottom.Controls.Add(this.lblIndent);
            this.pnlBottom.Controls.Add(this.lblStart);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBottom.Location = new System.Drawing.Point(0, 152);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(377, 143);
            this.pnlBottom.TabIndex = 2;
            // 
            // chkHideNumbers
            // 
            this.chkHideNumbers.AutoSize = true;
            this.chkHideNumbers.Location = new System.Drawing.Point(6, 83);
            this.chkHideNumbers.Name = "chkHideNumbers";
            this.chkHideNumbers.Size = new System.Drawing.Size(86, 17);
            this.chkHideNumbers.TabIndex = 3;
            this.chkHideNumbers.Text = "Hide number";
            this.chkHideNumbers.UseVisualStyleBackColor = true;
            // 
            // rdbPeriod
            // 
            this.rdbPeriod.AutoSize = true;
            this.rdbPeriod.Location = new System.Drawing.Point(195, 19);
            this.rdbPeriod.Name = "rdbPeriod";
            this.rdbPeriod.Size = new System.Drawing.Size(34, 17);
            this.rdbPeriod.TabIndex = 2;
            this.rdbPeriod.TabStop = true;
            this.rdbPeriod.Text = "1.";
            this.rdbPeriod.UseVisualStyleBackColor = true;
            // 
            // rdbParens
            // 
            this.rdbParens.AutoSize = true;
            this.rdbParens.Location = new System.Drawing.Point(99, 19);
            this.rdbParens.Name = "rdbParens";
            this.rdbParens.Size = new System.Drawing.Size(37, 17);
            this.rdbParens.TabIndex = 1;
            this.rdbParens.TabStop = true;
            this.rdbParens.Text = "(1)";
            this.rdbParens.UseVisualStyleBackColor = true;
            // 
            // rdbPlain
            // 
            this.rdbPlain.AutoSize = true;
            this.rdbPlain.Location = new System.Drawing.Point(288, 19);
            this.rdbPlain.Name = "rdbPlain";
            this.rdbPlain.Size = new System.Drawing.Size(31, 17);
            this.rdbPlain.TabIndex = 3;
            this.rdbPlain.TabStop = true;
            this.rdbPlain.Text = "1";
            this.rdbPlain.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(195, 103);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(290, 103);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblIndent
            // 
            this.lblIndent.AutoSize = true;
            this.lblIndent.Location = new System.Drawing.Point(3, 15);
            this.lblIndent.Name = "lblIndent";
            this.lblIndent.Size = new System.Drawing.Size(60, 13);
            this.lblIndent.TabIndex = 0;
            this.lblIndent.Text = "Indent, cm:";
            // 
            // nudStart
            // 
            this.nudStart.Location = new System.Drawing.Point(99, 46);
            this.nudStart.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudStart.Name = "nudStart";
            this.nudStart.Size = new System.Drawing.Size(58, 20);
            this.nudStart.TabIndex = 2;
            this.nudStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudIndent
            // 
            this.nudIndent.DecimalPlaces = 1;
            this.nudIndent.Location = new System.Drawing.Point(99, 13);
            this.nudIndent.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudIndent.Name = "nudIndent";
            this.nudIndent.Size = new System.Drawing.Size(105, 20);
            this.nudIndent.TabIndex = 1;
            this.nudIndent.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // frmNumericList
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(377, 295);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.grpFormat);
            this.Controls.Add(this.grpStyle);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNumericList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Numeric List";
            this.grpStyle.ResumeLayout(false);
            this.grpStyle.PerformLayout();
            this.grpFormat.ResumeLayout(false);
            this.grpFormat.PerformLayout();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.GroupBox grpStyle;
        private System.Windows.Forms.RadioButton rdbUCRoman;
        private System.Windows.Forms.RadioButton rdbLCRoman;
        private System.Windows.Forms.RadioButton rdbUCLetter;
        private System.Windows.Forms.RadioButton rdbLCLetter;
        private System.Windows.Forms.RadioButton rdbArabic;
        private System.Windows.Forms.GroupBox grpFormat;
        private System.Windows.Forms.RadioButton rdbPlain;
        private System.Windows.Forms.RadioButton rdbParens;
        private System.Windows.Forms.RadioButton rdbPeriod;
        private System.Windows.Forms.RadioButton rdbParen;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.CheckBox chkHideNumbers;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblIndent;
        private System.Windows.Forms.NumericUpDown nudStart;
        private System.Windows.Forms.NumericUpDown nudIndent;
    }
}