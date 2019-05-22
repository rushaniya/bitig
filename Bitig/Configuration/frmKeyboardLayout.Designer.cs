namespace Bitig.UI.Configuration
{
    partial class frmKeyboardLayout
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
            this.lblKeyboardType = new System.Windows.Forms.Label();
            this.cmbKeyboardType = new System.Windows.Forms.ComboBox();
            this.dgvKeyCombinations = new System.Windows.Forms.DataGridView();
            this.colFull_Combination = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFull_Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFull_Capital = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bndKeyCombinations = new System.Windows.Forms.BindingSource(this.components);
            this.dgvMagicKeyCombinations = new System.Windows.Forms.DataGridView();
            this.colMagic_Symbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMagic_WithMagic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bndMagicKeyCombinations = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMagicKey = new System.Windows.Forms.Label();
            this.txtMagicKey = new System.Windows.Forms.TextBox();
            this.pnlFullKeyboard = new System.Windows.Forms.Panel();
            this.pnlMagicKeyboard = new System.Windows.Forms.Panel();
            this.pnlMagicKey = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFriendlyName = new System.Windows.Forms.Label();
            this.txtFriendlyName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyCombinations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndKeyCombinations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMagicKeyCombinations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndMagicKeyCombinations)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlFullKeyboard.SuspendLayout();
            this.pnlMagicKeyboard.SuspendLayout();
            this.pnlMagicKey.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblKeyboardType
            // 
            this.lblKeyboardType.AutoSize = true;
            this.lblKeyboardType.Location = new System.Drawing.Point(12, 12);
            this.lblKeyboardType.Name = "lblKeyboardType";
            this.lblKeyboardType.Size = new System.Drawing.Size(106, 13);
            this.lblKeyboardType.TabIndex = 0;
            this.lblKeyboardType.Text = "Keyboard layout type";
            // 
            // cmbKeyboardType
            // 
            this.cmbKeyboardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyboardType.FormattingEnabled = true;
            this.cmbKeyboardType.Location = new System.Drawing.Point(124, 9);
            this.cmbKeyboardType.Name = "cmbKeyboardType";
            this.cmbKeyboardType.Size = new System.Drawing.Size(215, 21);
            this.cmbKeyboardType.TabIndex = 1;
            this.cmbKeyboardType.SelectedIndexChanged += new System.EventHandler(this.cmbKeyboardType_SelectedIndexChanged);
            // 
            // dgvKeyCombinations
            // 
            this.dgvKeyCombinations.AllowUserToResizeRows = false;
            this.dgvKeyCombinations.AutoGenerateColumns = false;
            this.dgvKeyCombinations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKeyCombinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeyCombinations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colFull_Combination,
            this.colFull_Symbol,
            this.colFull_Capital});
            this.dgvKeyCombinations.DataSource = this.bndKeyCombinations;
            this.dgvKeyCombinations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKeyCombinations.Location = new System.Drawing.Point(0, 0);
            this.dgvKeyCombinations.Name = "dgvKeyCombinations";
            this.dgvKeyCombinations.Size = new System.Drawing.Size(727, 496);
            this.dgvKeyCombinations.TabIndex = 2;
            // 
            // colFull_Combination
            // 
            this.colFull_Combination.DataPropertyName = "Combination";
            this.colFull_Combination.HeaderText = "Key combination";
            this.colFull_Combination.Name = "colFull_Combination";
            // 
            // colFull_Symbol
            // 
            this.colFull_Symbol.DataPropertyName = "Symbol";
            this.colFull_Symbol.HeaderText = "Symbol";
            this.colFull_Symbol.Name = "colFull_Symbol";
            // 
            // colFull_Capital
            // 
            this.colFull_Capital.DataPropertyName = "Capital";
            this.colFull_Capital.HeaderText = "Capital";
            this.colFull_Capital.Name = "colFull_Capital";
            // 
            // bndKeyCombinations
            // 
            this.bndKeyCombinations.DataSource = typeof(Bitig.UI.Configuration.Model.KeyCombinationConfig);
            // 
            // dgvMagicKeyCombinations
            // 
            this.dgvMagicKeyCombinations.AllowUserToResizeRows = false;
            this.dgvMagicKeyCombinations.AutoGenerateColumns = false;
            this.dgvMagicKeyCombinations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMagicKeyCombinations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMagicKeyCombinations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMagic_Symbol,
            this.colMagic_WithMagic});
            this.dgvMagicKeyCombinations.DataSource = this.bndMagicKeyCombinations;
            this.dgvMagicKeyCombinations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMagicKeyCombinations.Location = new System.Drawing.Point(0, 36);
            this.dgvMagicKeyCombinations.Name = "dgvMagicKeyCombinations";
            this.dgvMagicKeyCombinations.Size = new System.Drawing.Size(727, 348);
            this.dgvMagicKeyCombinations.TabIndex = 3;
            // 
            // colMagic_Symbol
            // 
            this.colMagic_Symbol.DataPropertyName = "Symbol";
            this.colMagic_Symbol.HeaderText = "Source symbol";
            this.colMagic_Symbol.Name = "colMagic_Symbol";
            // 
            // colMagic_WithMagic
            // 
            this.colMagic_WithMagic.DataPropertyName = "WithMagic";
            this.colMagic_WithMagic.HeaderText = "With magic key";
            this.colMagic_WithMagic.Name = "colMagic_WithMagic";
            // 
            // bndMagicKeyCombinations
            // 
            this.bndMagicKeyCombinations.DataSource = typeof(Bitig.Base.MagicKeyCombination);
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 423);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(727, 73);
            this.pnlBottom.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(628, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 46);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(522, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 46);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMagicKey
            // 
            this.lblMagicKey.AutoSize = true;
            this.lblMagicKey.Location = new System.Drawing.Point(3, 10);
            this.lblMagicKey.Name = "lblMagicKey";
            this.lblMagicKey.Size = new System.Drawing.Size(56, 13);
            this.lblMagicKey.TabIndex = 6;
            this.lblMagicKey.Text = "Magic key";
            // 
            // txtMagicKey
            // 
            this.txtMagicKey.Location = new System.Drawing.Point(65, 7);
            this.txtMagicKey.Name = "txtMagicKey";
            this.txtMagicKey.Size = new System.Drawing.Size(123, 20);
            this.txtMagicKey.TabIndex = 7;
            // 
            // pnlFullKeyboard
            // 
            this.pnlFullKeyboard.Controls.Add(this.dgvKeyCombinations);
            this.pnlFullKeyboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFullKeyboard.Location = new System.Drawing.Point(0, 0);
            this.pnlFullKeyboard.Name = "pnlFullKeyboard";
            this.pnlFullKeyboard.Size = new System.Drawing.Size(727, 496);
            this.pnlFullKeyboard.TabIndex = 8;
            // 
            // pnlMagicKeyboard
            // 
            this.pnlMagicKeyboard.Controls.Add(this.dgvMagicKeyCombinations);
            this.pnlMagicKeyboard.Controls.Add(this.pnlMagicKey);
            this.pnlMagicKeyboard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMagicKeyboard.Location = new System.Drawing.Point(0, 39);
            this.pnlMagicKeyboard.Name = "pnlMagicKeyboard";
            this.pnlMagicKeyboard.Size = new System.Drawing.Size(727, 384);
            this.pnlMagicKeyboard.TabIndex = 9;
            // 
            // pnlMagicKey
            // 
            this.pnlMagicKey.Controls.Add(this.lblMagicKey);
            this.pnlMagicKey.Controls.Add(this.txtMagicKey);
            this.pnlMagicKey.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMagicKey.Location = new System.Drawing.Point(0, 0);
            this.pnlMagicKey.Name = "pnlMagicKey";
            this.pnlMagicKey.Size = new System.Drawing.Size(727, 36);
            this.pnlMagicKey.TabIndex = 0;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.txtFriendlyName);
            this.pnlTop.Controls.Add(this.lblFriendlyName);
            this.pnlTop.Controls.Add(this.lblKeyboardType);
            this.pnlTop.Controls.Add(this.cmbKeyboardType);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(727, 39);
            this.pnlTop.TabIndex = 10;
            // 
            // lblFriendlyName
            // 
            this.lblFriendlyName.AutoSize = true;
            this.lblFriendlyName.Location = new System.Drawing.Point(364, 12);
            this.lblFriendlyName.Name = "lblFriendlyName";
            this.lblFriendlyName.Size = new System.Drawing.Size(35, 13);
            this.lblFriendlyName.TabIndex = 0;
            this.lblFriendlyName.Text = "Name";
            // 
            // txtFriendlyName
            // 
            this.txtFriendlyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFriendlyName.Location = new System.Drawing.Point(405, 10);
            this.txtFriendlyName.Name = "txtFriendlyName";
            this.txtFriendlyName.Size = new System.Drawing.Size(310, 20);
            this.txtFriendlyName.TabIndex = 2;
            // 
            // frmKeyboardLayout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 496);
            this.Controls.Add(this.pnlMagicKeyboard);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlFullKeyboard);
            this.Name = "frmKeyboardLayout";
            this.Text = "Keyboard layout";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyCombinations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndKeyCombinations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMagicKeyCombinations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndMagicKeyCombinations)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlFullKeyboard.ResumeLayout(false);
            this.pnlMagicKeyboard.ResumeLayout(false);
            this.pnlMagicKey.ResumeLayout(false);
            this.pnlMagicKey.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblKeyboardType;
        private System.Windows.Forms.ComboBox cmbKeyboardType;
        private System.Windows.Forms.DataGridView dgvKeyCombinations;
        private System.Windows.Forms.DataGridView dgvMagicKeyCombinations;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMagicKey;
        private System.Windows.Forms.TextBox txtMagicKey;
        private System.Windows.Forms.Panel pnlFullKeyboard;
        private System.Windows.Forms.Panel pnlMagicKeyboard;
        private System.Windows.Forms.Panel pnlMagicKey;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.BindingSource bndKeyCombinations;
        private System.Windows.Forms.BindingSource bndMagicKeyCombinations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFull_Combination;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFull_Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFull_Capital;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMagic_Symbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMagic_WithMagic;
        private System.Windows.Forms.TextBox txtFriendlyName;
        private System.Windows.Forms.Label lblFriendlyName;
    }
}