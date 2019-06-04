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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tbpAlphabets = new System.Windows.Forms.TabPage();
            this.dgvAlphabets = new System.Windows.Forms.DataGridView();
            this.colAlphName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlAlphabetCommands = new System.Windows.Forms.Panel();
            this.btnAlphabetSymbols = new System.Windows.Forms.Button();
            this.btnDeleteAlphabet = new System.Windows.Forms.Button();
            this.btnEditAlphabet = new System.Windows.Forms.Button();
            this.btnAddAlphabet = new System.Windows.Forms.Button();
            this.tbpDirections = new System.Windows.Forms.TabPage();
            this.dgvDirections = new System.Windows.Forms.DataGridView();
            this.colSourceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTargetName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAssembly = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bndDirection = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnExclusions = new System.Windows.Forms.Button();
            this.btnRemoveDirection = new System.Windows.Forms.Button();
            this.btnEditDirection = new System.Windows.Forms.Button();
            this.btnAddDirection = new System.Windows.Forms.Button();
            this.tbpKeyboardLayouts = new System.Windows.Forms.TabPage();
            this.dgvKeyboardLayouts = new System.Windows.Forms.DataGridView();
            this.colKblFriendlyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bndKblSummary = new System.Windows.Forms.BindingSource(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRemoveKeyboard = new System.Windows.Forms.Button();
            this.btnEditKeyboard = new System.Windows.Forms.Button();
            this.btnNewKeboard = new System.Windows.Forms.Button();
            this.bndAlphabet = new System.Windows.Forms.BindingSource(this.components);
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tbcMain.SuspendLayout();
            this.tbpAlphabets.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlphabets)).BeginInit();
            this.pnlAlphabetCommands.SuspendLayout();
            this.tbpDirections.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDirections)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndDirection)).BeginInit();
            this.panel1.SuspendLayout();
            this.tbpKeyboardLayouts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyboardLayouts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndKblSummary)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bndAlphabet)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tbpAlphabets);
            this.tbcMain.Controls.Add(this.tbpDirections);
            this.tbcMain.Controls.Add(this.tbpKeyboardLayouts);
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
            this.dgvAlphabets.ColumnHeadersVisible = false;
            this.dgvAlphabets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAlphName});
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
            this.dgvAlphabets.DoubleClick += new System.EventHandler(this.btnEditAlphabet_Click);
            // 
            // colAlphName
            // 
            this.colAlphName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colAlphName.DataPropertyName = "FriendlyName";
            this.colAlphName.HeaderText = "Displayed Name";
            this.colAlphName.MinimumWidth = 50;
            this.colAlphName.Name = "colAlphName";
            this.colAlphName.ReadOnly = true;
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
            this.btnAlphabetSymbols.Size = new System.Drawing.Size(105, 30);
            this.btnAlphabetSymbols.TabIndex = 3;
            this.btnAlphabetSymbols.Text = "Symbols...";
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
            this.dgvDirections.DoubleClick += new System.EventHandler(this.btnEditDirection_Click);
            // 
            // colSourceName
            // 
            this.colSourceName.DataPropertyName = "Source";
            this.colSourceName.HeaderText = "Source";
            this.colSourceName.Name = "colSourceName";
            this.colSourceName.ReadOnly = true;
            // 
            // colTargetName
            // 
            this.colTargetName.DataPropertyName = "Target";
            this.colTargetName.HeaderText = "Target";
            this.colTargetName.Name = "colTargetName";
            this.colTargetName.ReadOnly = true;
            // 
            // colAssembly
            // 
            this.colAssembly.DataPropertyName = "AssemblyFileName";
            this.colAssembly.HeaderText = "Assembly";
            this.colAssembly.Name = "colAssembly";
            this.colAssembly.ReadOnly = true;
            // 
            // colTypeName
            // 
            this.colTypeName.DataPropertyName = "TypeName";
            this.colTypeName.HeaderText = "Type Name";
            this.colTypeName.Name = "colTypeName";
            this.colTypeName.ReadOnly = true;
            // 
            // bndDirection
            // 
            this.bndDirection.DataSource = typeof(Bitig.Logic.Model.Direction);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExclusions);
            this.panel1.Controls.Add(this.btnRemoveDirection);
            this.panel1.Controls.Add(this.btnEditDirection);
            this.panel1.Controls.Add(this.btnAddDirection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 357);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 60);
            this.panel1.TabIndex = 3;
            // 
            // btnExclusions
            // 
            this.btnExclusions.Location = new System.Drawing.Point(365, 16);
            this.btnExclusions.Name = "btnExclusions";
            this.btnExclusions.Size = new System.Drawing.Size(110, 30);
            this.btnExclusions.TabIndex = 11;
            this.btnExclusions.Text = "Exclusions...";
            this.btnExclusions.UseVisualStyleBackColor = true;
            this.btnExclusions.Click += new System.EventHandler(this.btnExclusions_Click);
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
            // tbpKeyboardLayouts
            // 
            this.tbpKeyboardLayouts.Controls.Add(this.dgvKeyboardLayouts);
            this.tbpKeyboardLayouts.Controls.Add(this.panel2);
            this.tbpKeyboardLayouts.Location = new System.Drawing.Point(4, 22);
            this.tbpKeyboardLayouts.Name = "tbpKeyboardLayouts";
            this.tbpKeyboardLayouts.Size = new System.Drawing.Size(671, 420);
            this.tbpKeyboardLayouts.TabIndex = 2;
            this.tbpKeyboardLayouts.Text = "Keyboard Layouts";
            this.tbpKeyboardLayouts.UseVisualStyleBackColor = true;
            // 
            // dgvKeyboardLayouts
            // 
            this.dgvKeyboardLayouts.AllowUserToAddRows = false;
            this.dgvKeyboardLayouts.AllowUserToDeleteRows = false;
            this.dgvKeyboardLayouts.AutoGenerateColumns = false;
            this.dgvKeyboardLayouts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKeyboardLayouts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvKeyboardLayouts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeyboardLayouts.ColumnHeadersVisible = false;
            this.dgvKeyboardLayouts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colKblFriendlyName});
            this.dgvKeyboardLayouts.DataSource = this.bndKblSummary;
            this.dgvKeyboardLayouts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvKeyboardLayouts.Location = new System.Drawing.Point(0, 0);
            this.dgvKeyboardLayouts.MultiSelect = false;
            this.dgvKeyboardLayouts.Name = "dgvKeyboardLayouts";
            this.dgvKeyboardLayouts.ReadOnly = true;
            this.dgvKeyboardLayouts.RowHeadersVisible = false;
            this.dgvKeyboardLayouts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKeyboardLayouts.Size = new System.Drawing.Size(671, 360);
            this.dgvKeyboardLayouts.TabIndex = 3;
            this.dgvKeyboardLayouts.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKeyboardLayouts_RowEnter);
            this.dgvKeyboardLayouts.DoubleClick += new System.EventHandler(this.btnEditKeyboard_Click);
            // 
            // colKblFriendlyName
            // 
            this.colKblFriendlyName.DataPropertyName = "FriendlyName";
            this.colKblFriendlyName.HeaderText = "Friendly Name";
            this.colKblFriendlyName.Name = "colKblFriendlyName";
            this.colKblFriendlyName.ReadOnly = true;
            // 
            // bndKblSummary
            // 
            this.bndKblSummary.DataSource = typeof(Bitig.Logic.Model.KeyboardLayoutSummary);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRemoveKeyboard);
            this.panel2.Controls.Add(this.btnEditKeyboard);
            this.panel2.Controls.Add(this.btnNewKeboard);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 360);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(671, 60);
            this.panel2.TabIndex = 4;
            // 
            // btnRemoveKeyboard
            // 
            this.btnRemoveKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveKeyboard.Enabled = false;
            this.btnRemoveKeyboard.Location = new System.Drawing.Point(245, 16);
            this.btnRemoveKeyboard.Name = "btnRemoveKeyboard";
            this.btnRemoveKeyboard.Size = new System.Drawing.Size(105, 30);
            this.btnRemoveKeyboard.TabIndex = 2;
            this.btnRemoveKeyboard.Text = "Remove";
            this.btnRemoveKeyboard.UseVisualStyleBackColor = true;
            this.btnRemoveKeyboard.Click += new System.EventHandler(this.btnRemoveKeyboard_Click);
            // 
            // btnEditKeyboard
            // 
            this.btnEditKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEditKeyboard.Enabled = false;
            this.btnEditKeyboard.Location = new System.Drawing.Point(125, 16);
            this.btnEditKeyboard.Name = "btnEditKeyboard";
            this.btnEditKeyboard.Size = new System.Drawing.Size(105, 30);
            this.btnEditKeyboard.TabIndex = 1;
            this.btnEditKeyboard.Text = "Edit...";
            this.btnEditKeyboard.UseVisualStyleBackColor = true;
            this.btnEditKeyboard.Click += new System.EventHandler(this.btnEditKeyboard_Click);
            // 
            // btnNewKeboard
            // 
            this.btnNewKeboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNewKeboard.Location = new System.Drawing.Point(5, 16);
            this.btnNewKeboard.Name = "btnNewKeboard";
            this.btnNewKeboard.Size = new System.Drawing.Size(105, 30);
            this.btnNewKeboard.TabIndex = 0;
            this.btnNewKeboard.Text = "New...";
            this.btnNewKeboard.UseVisualStyleBackColor = true;
            this.btnNewKeboard.Click += new System.EventHandler(this.btnNewKeboard_Click);
            // 
            // bndAlphabet
            // 
            this.bndAlphabet.AllowNew = false;
            this.bndAlphabet.DataSource = typeof(Bitig.Logic.Model.Alifba);
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
            ((System.ComponentModel.ISupportInitialize)(this.bndDirection)).EndInit();
            this.panel1.ResumeLayout(false);
            this.tbpKeyboardLayouts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyboardLayouts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bndKblSummary)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bndAlphabet)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tbpAlphabets;
        private System.Windows.Forms.TabPage tbpDirections;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel pnlAlphabetCommands;
        private System.Windows.Forms.Button btnAlphabetSymbols;
        private System.Windows.Forms.Button btnDeleteAlphabet;
        private System.Windows.Forms.Button btnEditAlphabet;
        private System.Windows.Forms.Button btnAddAlphabet;
        private System.Windows.Forms.DataGridView dgvAlphabets;
        private System.Windows.Forms.BindingSource bndAlphabet;
        private System.Windows.Forms.BindingSource bndDirection;
        private System.Windows.Forms.DataGridView dgvDirections;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRemoveDirection;
        private System.Windows.Forms.Button btnEditDirection;
        private System.Windows.Forms.Button btnAddDirection;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSourceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTargetName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAssembly;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTypeName;
        private System.Windows.Forms.Button btnExclusions;
        private System.Windows.Forms.TabPage tbpKeyboardLayouts;
        private System.Windows.Forms.DataGridView dgvKeyboardLayouts;
        private System.Windows.Forms.BindingSource bndKblSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKblFriendlyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAlphName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRemoveKeyboard;
        private System.Windows.Forms.Button btnEditKeyboard;
        private System.Windows.Forms.Button btnNewKeboard;
    }
}