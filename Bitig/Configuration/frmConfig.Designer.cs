namespace Bitig.UI.Configuration
{
    partial class frmConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpAlphabets = new System.Windows.Forms.TabPage();
            this.dgvAlphabets = new System.Windows.Forms.DataGridView();
            this.pnlAlphabetCommands = new System.Windows.Forms.Panel();
            this.btnAlphabetSymbols = new System.Windows.Forms.Button();
            this.btnDeleteAlphabet = new System.Windows.Forms.Button();
            this.btnEditAlphabet = new System.Windows.Forms.Button();
            this.btnAddAlphabet = new System.Windows.Forms.Button();
            this.tbpDirections = new System.Windows.Forms.TabPage();
            this.dgvDirections = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemoveDirection = new System.Windows.Forms.Button();
            this.btnEditDirection = new System.Windows.Forms.Button();
            this.btnAddDirection = new System.Windows.Forms.Button();
            this.tbpExclusions = new System.Windows.Forms.TabPage();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlphName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlphLayout = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRightToLeft = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlphFont = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAlifbaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bndAlphabet = new System.Windows.Forms.BindingSource(this.components);
            this.bndDirection = new System.Windows.Forms.BindingSource(this.components);
            this.colDirectionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSourceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssembly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbcMain.SuspendLayout();
            this.tbpAlphabets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlphabets)).BeginInit();
            this.pnlAlphabetCommands.SuspendLayout();
            this.tbpDirections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bndAlphabet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndDirection)).BeginInit();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpAlphabets);
            this.tbcMain.Controls.Add(this.tbpDirections);
            this.tbcMain.Controls.Add(this.tbpExclusions);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(679, 446);
            this.tbcMain.TabIndex = 0;
            // 
            // tbpAlphabets
            // 
            this.tbpAlphabets.Controls.Add(this.dgvAlphabets);
            this.tbpAlphabets.Controls.Add(this.pnlAlphabetCommands);
            this.tbpAlphabets.Location = new System.Drawing.Point(4, 22);
            this.tbpAlphabets.Name = "tbpAlphabets";
            this.tbpAlphabets.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAlphabets.Size = new System.Drawing.Size(671, 420);
            this.tbpAlphabets.TabIndex = 0;
            this.tbpAlphabets.Text = "Alphabets";
            this.tbpAlphabets.UseVisualStyleBackColor = true;
            // 
            // dgvAlphabets
            // 
            this.dgvAlphabets.AllowUserToAddRows = false;
            this.dgvAlphabets.AllowUserToDeleteRows = false;
            this.dgvAlphabets.AutoGenerateColumns = false;
            this.dgvAlphabets.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlphabets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlphabets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlphabets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAlphName,
            this.colAlphLayout,
            this.colAlphFont,
            this.colAlifbaID,
            this.colRightToLeft});
            this.dgvAlphabets.DataSource = this.bndAlphabet;
            this.dgvAlphabets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlphabets.Location = new System.Drawing.Point(3, 3);
            this.dgvAlphabets.MultiSelect = false;
            this.dgvAlphabets.Name = "dgvAlphabets";
            this.dgvAlphabets.ReadOnly = true;
            this.dgvAlphabets.RowHeadersVisible = false;
            this.dgvAlphabets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlphabets.Size = new System.Drawing.Size(665, 354);
            this.dgvAlphabets.TabIndex = 0;
            this.dgvAlphabets.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlphabets_RowEnter);
            // 
            // pnlAlphabetCommands
            // 
            this.pnlAlphabetCommands.Controls.Add(this.btnAlphabetSymbols);
            this.pnlAlphabetCommands.Controls.Add(this.btnDeleteAlphabet);
            this.pnlAlphabetCommands.Controls.Add(this.btnEditAlphabet);
            this.pnlAlphabetCommands.Controls.Add(this.btnAddAlphabet);
            this.pnlAlphabetCommands.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlAlphabetCommands.Location = new System.Drawing.Point(3, 357);
            this.pnlAlphabetCommands.Name = "pnlAlphabetCommands";
            this.pnlAlphabetCommands.Size = new System.Drawing.Size(665, 60);
            this.pnlAlphabetCommands.TabIndex = 1;
            // 
            // btnAlphabetSymbols
            // 
            this.btnAlphabetSymbols.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAlphabetSymbols.Enabled = false;
            this.btnAlphabetSymbols.Location = new System.Drawing.Point(365, 16);
            this.btnAlphabetSymbols.Name = "btnAlphabetSymbols";
            this.btnAlphabetSymbols.Size = new System.Drawing.Size(157, 30);
            this.btnAlphabetSymbols.TabIndex = 3;
            this.btnAlphabetSymbols.Text = "On-Screen Symbols...";
            this.btnAlphabetSymbols.UseVisualStyleBackColor = true;
            this.btnAlphabetSymbols.Click += new System.EventHandler(this.btnAlphabetSymbols_Click);
            // 
            // btnDeleteAlphabet
            // 
            this.btnDeleteAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteAlphabet.Enabled = false;
            this.btnDeleteAlphabet.Location = new System.Drawing.Point(245, 16);
            this.btnDeleteAlphabet.Name = "btnDeleteAlphabet";
            this.btnDeleteAlphabet.Size = new System.Drawing.Size(105, 30);
            this.btnDeleteAlphabet.TabIndex = 2;
            this.btnDeleteAlphabet.Text = "Remove";
            this.btnDeleteAlphabet.UseVisualStyleBackColor = true;
            this.btnDeleteAlphabet.Click += new System.EventHandler(this.btnDeleteAlphabet_Click);
            // 
            // btnEditAlphabet
            // 
            this.btnEditAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditAlphabet.Enabled = false;
            this.btnEditAlphabet.Location = new System.Drawing.Point(125, 16);
            this.btnEditAlphabet.Name = "btnEditAlphabet";
            this.btnEditAlphabet.Size = new System.Drawing.Size(105, 30);
            this.btnEditAlphabet.TabIndex = 1;
            this.btnEditAlphabet.Text = "Edit...";
            this.btnEditAlphabet.UseVisualStyleBackColor = true;
            this.btnEditAlphabet.Click += new System.EventHandler(this.btnEditAlphabet_Click);
            // 
            // btnAddAlphabet
            // 
            this.btnAddAlphabet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAlphabet.Location = new System.Drawing.Point(5, 16);
            this.btnAddAlphabet.Name = "btnAddAlphabet";
            this.btnAddAlphabet.Size = new System.Drawing.Size(105, 30);
            this.btnAddAlphabet.TabIndex = 0;
            this.btnAddAlphabet.Text = "New...";
            this.btnAddAlphabet.UseVisualStyleBackColor = true;
            this.btnAddAlphabet.Click += new System.EventHandler(this.btnAddAlphabet_Click);
            // 
            // tbpDirections
            // 
            this.tbpDirections.Controls.Add(this.dgvDirections);
            this.tbpDirections.Controls.Add(this.panel1);
            this.tbpDirections.Location = new System.Drawing.Point(4, 22);
            this.tbpDirections.Name = "tbpDirections";
            this.tbpDirections.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDirections.Size = new System.Drawing.Size(671, 420);
            this.tbpDirections.TabIndex = 1;
            this.tbpDirections.Text = "Directions";
            this.tbpDirections.UseVisualStyleBackColor = true;
            // 
            // dgvDirections
            // 
            this.dgvDirections.AllowUserToAddRows = false;
            this.dgvDirections.AllowUserToDeleteRows = false;
            this.dgvDirections.AutoGenerateColumns = false;
            this.dgvDirections.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDirections.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDirections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDirections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDirectionID,
            this.colSourceName,
            this.colTargetName,
            this.colAssembly,
            this.colTypeName});
            this.dgvDirections.DataSource = this.bndDirection;
            this.dgvDirections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDirections.Location = new System.Drawing.Point(3, 3);
            this.dgvDirections.MultiSelect = false;
            this.dgvDirections.Name = "dgvDirections";
            this.dgvDirections.ReadOnly = true;
            this.dgvDirections.RowHeadersVisible = false;
            this.dgvDirections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDirections.Size = new System.Drawing.Size(665, 354);
            this.dgvDirections.TabIndex = 2;
            this.dgvDirections.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDirections_RowEnter);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRemoveDirection);
            this.panel1.Controls.Add(this.btnEditDirection);
            this.panel1.Controls.Add(this.btnAddDirection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 60);
            this.panel1.TabIndex = 3;
            // 
            // btnRemoveDirection
            // 
            this.btnRemoveDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveDirection.Enabled = false;
            this.btnRemoveDirection.Location = new System.Drawing.Point(245, 16);
            this.btnRemoveDirection.Name = "btnRemoveDirection";
            this.btnRemoveDirection.Size = new System.Drawing.Size(105, 30);
            this.btnRemoveDirection.TabIndex = 2;
            this.btnRemoveDirection.Text = "Remove";
            this.btnRemoveDirection.UseVisualStyleBackColor = true;
            this.btnRemoveDirection.Click += new System.EventHandler(this.btnRemoveDirection_Click);
            // 
            // btnEditDirection
            // 
            this.btnEditDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditDirection.Enabled = false;
            this.btnEditDirection.Location = new System.Drawing.Point(125, 16);
            this.btnEditDirection.Name = "btnEditDirection";
            this.btnEditDirection.Size = new System.Drawing.Size(105, 30);
            this.btnEditDirection.TabIndex = 1;
            this.btnEditDirection.Text = "Edit...";
            this.btnEditDirection.UseVisualStyleBackColor = true;
            this.btnEditDirection.Click += new System.EventHandler(this.btnEditDirection_Click);
            // 
            // btnAddDirection
            // 
            this.btnAddDirection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddDirection.Location = new System.Drawing.Point(5, 16);
            this.btnAddDirection.Name = "btnAddDirection";
            this.btnAddDirection.Size = new System.Drawing.Size(105, 30);
            this.btnAddDirection.TabIndex = 0;
            this.btnAddDirection.Text = "New...";
            this.btnAddDirection.UseVisualStyleBackColor = true;
            this.btnAddDirection.Click += new System.EventHandler(this.btnAddDirection_Click);
            // 
            // tbpExclusions
            // 
            this.tbpExclusions.Location = new System.Drawing.Point(4, 22);
            this.tbpExclusions.Name = "tbpExclusions";
            this.tbpExclusions.Padding = new System.Windows.Forms.Padding(3);
            this.tbpExclusions.Size = new System.Drawing.Size(671, 420);
            this.tbpExclusions.TabIndex = 2;
            this.tbpExclusions.Text = "Exclusions";
            this.tbpExclusions.UseVisualStyleBackColor = true;
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 446);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(679, 73);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(580, 15);
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
            this.btnOK.Location = new System.Drawing.Point(474, 15);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 46);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DefaultFont";
            this.dataGridViewTextBoxColumn1.HeaderText = "Default Font";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // colAlphName
            // 
            this.colAlphName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAlphName.DataPropertyName = "FriendlyName";
            this.colAlphName.HeaderText = "Displayed Name";
            this.colAlphName.MinimumWidth = 50;
            this.colAlphName.Name = "colAlphName";
            this.colAlphName.ReadOnly = true;
            this.colAlphName.Width = 200;
            // 
            // colAlphLayout
            // 
            this.colAlphLayout.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colAlphLayout.DataPropertyName = "KeyboardLayoutName";
            this.colAlphLayout.HeaderText = "Keyboard Layout";
            this.colAlphLayout.MinimumWidth = 50;
            this.colAlphLayout.Name = "colAlphLayout";
            this.colAlphLayout.ReadOnly = true;
            this.colAlphLayout.Width = 200;
            // 
            // colRightToLeft
            // 
            this.colRightToLeft.DataPropertyName = "RightToLeft";
            this.colRightToLeft.HeaderText = "Right to Left";
            this.colRightToLeft.Name = "colRightToLeft";
            this.colRightToLeft.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DefaultFont";
            this.dataGridViewTextBoxColumn2.HeaderText = "Default Font";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // colAlphFont
            // 
            this.colAlphFont.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAlphFont.DataPropertyName = "DefaultFont";
            this.colAlphFont.HeaderText = "Default Font";
            this.colAlphFont.Name = "colAlphFont";
            this.colAlphFont.ReadOnly = true;
            // 
            // colAlifbaID
            // 
            this.colAlifbaID.DataPropertyName = "AlifbaID";
            this.colAlifbaID.HeaderText = "AlifbaID";
            this.colAlifbaID.Name = "colAlifbaID";
            this.colAlifbaID.ReadOnly = true;
            this.colAlifbaID.Visible = false;
            // 
            // bndAlphabet
            // 
            this.bndAlphabet.DataSource = typeof(Logic.Model.Alifba);
            // 
            // bndDirection
            // 
            this.bndDirection.DataSource = typeof(Bitig.Logic.DirectionConfig);
            // 
            // colDirectionID
            // 
            this.colDirectionID.DataPropertyName = "DirectionID";
            this.colDirectionID.HeaderText = "DirectionID";
            this.colDirectionID.Name = "colDirectionID";
            this.colDirectionID.ReadOnly = true;
            this.colDirectionID.Visible = false;
            // 
            // colSourceName
            // 
            this.colSourceName.DataPropertyName = "SourceName";
            this.colSourceName.HeaderText = "Source";
            this.colSourceName.Name = "colSourceName";
            this.colSourceName.ReadOnly = true;
            // 
            // colTargetName
            // 
            this.colTargetName.DataPropertyName = "TargetName";
            this.colTargetName.HeaderText = "Target";
            this.colTargetName.Name = "colTargetName";
            this.colTargetName.ReadOnly = true;
            // 
            // colAssembly
            // 
            this.colAssembly.DataPropertyName = "AssemblyFileName";
            this.colAssembly.HeaderText = "Library";
            this.colAssembly.Name = "colAssembly";
            this.colAssembly.ReadOnly = true;
            // 
            // colTypeName
            // 
            this.colTypeName.DataPropertyName = "DisplayedTypeName";
            this.colTypeName.HeaderText = "Type Name";
            this.colTypeName.Name = "colTypeName";
            this.colTypeName.ReadOnly = true;
            // 
            // frmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 519);
            this.Controls.Add(this.tbcMain);
            this.Controls.Add(this.pnlBottom);
            this.Name = "frmConfig";
            this.Text = "Configuration";
            this.Load += new System.EventHandler(this.frmConfig_Load);
            this.tbcMain.ResumeLayout(false);
            this.tbpAlphabets.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlphabets)).EndInit();
            this.pnlAlphabetCommands.ResumeLayout(false);
            this.tbpDirections.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bndAlphabet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndDirection)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpAlphabets;
        private System.Windows.Forms.TabPage tbpDirections;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TabPage tbpExclusions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnlAlphabetCommands;
        private System.Windows.Forms.Button btnAlphabetSymbols;
        private System.Windows.Forms.Button btnDeleteAlphabet;
        private System.Windows.Forms.Button btnEditAlphabet;
        private System.Windows.Forms.Button btnAddAlphabet;
        private System.Windows.Forms.DataGridView dgvAlphabets;
        private System.Windows.Forms.BindingSource bndAlphabet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource bndDirection;
        private System.Windows.Forms.DataGridView dgvDirections;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoveDirection;
        private System.Windows.Forms.Button btnEditDirection;
        private System.Windows.Forms.Button btnAddDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlphName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlphLayout;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlphFont;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlifbaID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colRightToLeft;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssembly;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}