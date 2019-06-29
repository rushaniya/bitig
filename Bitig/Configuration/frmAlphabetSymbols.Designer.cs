using Bitig.Logic.Model;

namespace Bitig.UI.Configuration
{
    partial class frmAlphabetSymbols
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
            this.dgvSymbols = new System.Windows.Forms.DataGridView();
            this.bndSymbol = new System.Windows.Forms.BindingSource(this.components);
            this.pnlYanalifSettings = new System.Windows.Forms.Panel();
            this.chkShowAllYanalifLetters = new System.Windows.Forms.CheckBox();
            this.colSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplaySymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDisplayUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsAlphabetic = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colIsOnScreen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndSymbol)).BeginInit();
            this.pnlYanalifSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 312);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(582, 73);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(483, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 46);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(377, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 46);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dgvSymbols
            // 
            this.dgvSymbols.AutoGenerateColumns = false;
            this.dgvSymbols.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSymbols.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSymbols.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSymbol,
            this.colDisplaySymbol,
            this.colUpper,
            this.colDisplayUpper,
            this.colIsAlphabetic,
            this.colIsOnScreen});
            this.dgvSymbols.DataSource = this.bndSymbol;
            this.dgvSymbols.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSymbols.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvSymbols.Location = new System.Drawing.Point(0, 0);
            this.dgvSymbols.Name = "dgvSymbols";
            this.dgvSymbols.Size = new System.Drawing.Size(582, 278);
            this.dgvSymbols.TabIndex = 0;
            // 
            // bndSymbol
            // 
            this.bndSymbol.DataSource = typeof(Bitig.Logic.Model.AlphabetSymbol);
            // 
            // pnlYanalifSettings
            // 
            this.pnlYanalifSettings.Controls.Add(this.chkShowAllYanalifLetters);
            this.pnlYanalifSettings.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlYanalifSettings.Location = new System.Drawing.Point(0, 278);
            this.pnlYanalifSettings.Name = "pnlYanalifSettings";
            this.pnlYanalifSettings.Size = new System.Drawing.Size(582, 34);
            this.pnlYanalifSettings.TabIndex = 2;
            this.pnlYanalifSettings.Visible = false;
            // 
            // chkShowAllYanalifLetters
            // 
            this.chkShowAllYanalifLetters.AutoSize = true;
            this.chkShowAllYanalifLetters.Enabled = false;
            this.chkShowAllYanalifLetters.Location = new System.Drawing.Point(3, 8);
            this.chkShowAllYanalifLetters.Name = "chkShowAllYanalifLetters";
            this.chkShowAllYanalifLetters.Size = new System.Drawing.Size(166, 17);
            this.chkShowAllYanalifLetters.TabIndex = 0;
            this.chkShowAllYanalifLetters.Text = "Always show all Yanalif letters";
            this.chkShowAllYanalifLetters.UseVisualStyleBackColor = true;
            // 
            // colSymbol
            // 
            this.colSymbol.DataPropertyName = "ActualText";
            this.colSymbol.HeaderText = "Symbol";
            this.colSymbol.Name = "colSymbol";
            // 
            // colDisplaySymbol
            // 
            this.colDisplaySymbol.DataPropertyName = "DisplayText";
            this.colDisplaySymbol.HeaderText = "Displayed symbol (if different)";
            this.colDisplaySymbol.Name = "colDisplaySymbol";
            // 
            // colUpper
            // 
            this.colUpper.DataPropertyName = "CapitalizedText";
            this.colUpper.HeaderText = "Upper symbol (optional)";
            this.colUpper.Name = "colUpper";
            // 
            // colDisplayUpper
            // 
            this.colDisplayUpper.DataPropertyName = "CapitalizedDisplayText";
            this.colDisplayUpper.HeaderText = "Displayed upper symbol (if different)";
            this.colDisplayUpper.Name = "colDisplayUpper";
            // 
            // colIsAlphabetic
            // 
            this.colIsAlphabetic.DataPropertyName = "IsAlphabetic";
            this.colIsAlphabetic.HeaderText = "Alphabetic";
            this.colIsAlphabetic.Name = "colIsAlphabetic";
            // 
            // colIsOnScreen
            // 
            this.colIsOnScreen.DataPropertyName = "IsOnScreen";
            this.colIsOnScreen.HeaderText = "On screen";
            this.colIsOnScreen.Name = "colIsOnScreen";
            // 
            // frmAlphabetSymbols
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 385);
            this.Controls.Add(this.dgvSymbols);
            this.Controls.Add(this.pnlYanalifSettings);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmAlphabetSymbols";
            this.Text = "Custom On-Screen Symbols";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymbols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndSymbol)).EndInit();
            this.pnlYanalifSettings.ResumeLayout(false);
            this.pnlYanalifSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dgvSymbols;
        private System.Windows.Forms.BindingSource bndSymbol;
        private System.Windows.Forms.Panel pnlYanalifSettings;
        private System.Windows.Forms.CheckBox chkShowAllYanalifLetters;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplaySymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDisplayUpper;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsAlphabetic;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsOnScreen;
    }
}