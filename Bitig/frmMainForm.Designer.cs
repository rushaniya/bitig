namespace Bitig.UI
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.tlsMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowAlifba = new System.Windows.Forms.ToolStripButton();
            this.btnShowTranslit = new System.Windows.Forms.ToolStripButton();
            this.cmbSource = new System.Windows.Forms.ToolStripComboBox();
            this.lblTo = new System.Windows.Forms.ToolStripLabel();
            this.cmbTarget = new System.Windows.Forms.ToolStripComboBox();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUndo = new System.Windows.Forms.ToolStripMenuItem();
            this.mniRedo = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCut = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTranslitPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAlifba = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mniExclusions = new System.Windows.Forms.ToolStripMenuItem();
            this.mniConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.spltTranslitArea = new System.Windows.Forms.SplitContainer();
            this.pnlTranslit1 = new System.Windows.Forms.Panel();
            this.txtTranslit1 = new System.Windows.Forms.RichTextBox();
            this.pnlTranslit1Bottom = new System.Windows.Forms.Panel();
            this.tlsTarnslit1 = new System.Windows.Forms.ToolStrip();
            this.lblSource = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTranslit1Config = new System.Windows.Forms.ToolStripButton();
            this.btnT1Keyboard = new System.Windows.Forms.ToolStripButton();
            this.btnToYanalif = new System.Windows.Forms.ToolStripButton();
            this.btnTranslitAux = new System.Windows.Forms.ToolStripButton();
            this.pnlTranslit2 = new System.Windows.Forms.Panel();
            this.txtTranslit2 = new System.Windows.Forms.RichTextBox();
            this.pnlTranslit2Bottom = new System.Windows.Forms.Panel();
            this.tlsTranslit2 = new System.Windows.Forms.ToolStrip();
            this.lblTarget = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTranslit2Config = new System.Windows.Forms.ToolStripButton();
            this.btnT2Keyboard = new System.Windows.Forms.ToolStripButton();
            this.btnFromYanalif = new System.Windows.Forms.ToolStripButton();
            this.pnlYanalif = new System.Windows.Forms.Panel();
            this.ctlMultiRtb1 = new Bitig.RtbControl.ctlMultiRtb();
            this.ctlYanalif1 = new Bitig.UI.Controls.ctlYanalif();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.pnlTop = new System.Windows.Forms.FlowLayoutPanel();
            this.tlsMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            this.spltTranslitArea.Panel1.SuspendLayout();
            this.spltTranslitArea.Panel2.SuspendLayout();
            this.spltTranslitArea.SuspendLayout();
            this.pnlTranslit1.SuspendLayout();
            this.tlsTarnslit1.SuspendLayout();
            this.pnlTranslit2.SuspendLayout();
            this.tlsTranslit2.SuspendLayout();
            this.pnlYanalif.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsMain
            // 
            this.tlsMain.BackColor = System.Drawing.SystemColors.Window;
            this.tlsMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator2,
            this.btnShowAlifba,
            this.btnShowTranslit,
            this.cmbSource,
            this.lblTo,
            this.cmbTarget});
            this.tlsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(434, 39);
            this.tlsMain.TabIndex = 0;
            this.tlsMain.Text = "Main Panel";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnShowAlifba
            // 
            this.btnShowAlifba.CheckOnClick = true;
            this.btnShowAlifba.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowAlifba.Image = global::Bitig.UI.Properties.Resources.keyboard;
            this.btnShowAlifba.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowAlifba.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAlifba.Name = "btnShowAlifba";
            this.btnShowAlifba.Size = new System.Drawing.Size(36, 36);
            this.btnShowAlifba.Text = "Alifba";
            this.btnShowAlifba.CheckedChanged += new System.EventHandler(this.btnShowAlifba_CheckedChanged);
            // 
            // btnShowTranslit
            // 
            this.btnShowTranslit.Checked = true;
            this.btnShowTranslit.CheckOnClick = true;
            this.btnShowTranslit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.btnShowTranslit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowTranslit.Image = global::Bitig.UI.Properties.Resources.refresh;
            this.btnShowTranslit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowTranslit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowTranslit.Name = "btnShowTranslit";
            this.btnShowTranslit.Size = new System.Drawing.Size(36, 36);
            this.btnShowTranslit.Text = "Transliteration Window";
            this.btnShowTranslit.CheckedChanged += new System.EventHandler(this.btnShowTranslit_CheckedChanged);
            // 
            // cmbSource
            // 
            this.cmbSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSource.DropDownWidth = 121;
            this.cmbSource.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbSource.Name = "cmbSource";
            this.cmbSource.Size = new System.Drawing.Size(150, 39);
            this.cmbSource.SelectedIndexChanged += new System.EventHandler(this.cmbSource_SelectedIndexChanged);
            // 
            // lblTo
            // 
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(18, 36);
            this.lblTo.Text = "to";
            // 
            // cmbTarget
            // 
            this.cmbTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTarget.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbTarget.Name = "cmbTarget";
            this.cmbTarget.Size = new System.Drawing.Size(150, 39);
            this.cmbTarget.SelectedIndexChanged += new System.EventHandler(this.cmbTarget_SelectedIndexChanged);
            // 
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.SystemColors.Window;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuSettings,
            this.mnuHelp});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(853, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUndo,
            this.mniRedo,
            this.mniCut,
            this.mniCopy,
            this.mniPaste});
            this.mnuEdit.Enabled = false;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.Size = new System.Drawing.Size(39, 20);
            this.mnuEdit.Text = "Edit";
            // 
            // mniUndo
            // 
            this.mniUndo.Name = "mniUndo";
            this.mniUndo.Size = new System.Drawing.Size(103, 22);
            this.mniUndo.Text = "Undo";
            // 
            // mniRedo
            // 
            this.mniRedo.Name = "mniRedo";
            this.mniRedo.Size = new System.Drawing.Size(103, 22);
            this.mniRedo.Text = "Redo";
            // 
            // mniCut
            // 
            this.mniCut.Name = "mniCut";
            this.mniCut.Size = new System.Drawing.Size(103, 22);
            this.mniCut.Text = "Cut";
            // 
            // mniCopy
            // 
            this.mniCopy.Name = "mniCopy";
            this.mniCopy.Size = new System.Drawing.Size(103, 22);
            this.mniCopy.Text = "Copy";
            // 
            // mniPaste
            // 
            this.mniPaste.Name = "mniPaste";
            this.mniPaste.Size = new System.Drawing.Size(103, 22);
            this.mniPaste.Text = "Paste";
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniTranslitPanel,
            this.mniAlifba});
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 20);
            this.mnuView.Text = "View";
            // 
            // mniTranslitPanel
            // 
            this.mniTranslitPanel.Checked = true;
            this.mniTranslitPanel.CheckOnClick = true;
            this.mniTranslitPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mniTranslitPanel.Name = "mniTranslitPanel";
            this.mniTranslitPanel.Size = new System.Drawing.Size(144, 22);
            this.mniTranslitPanel.Text = "Translit Panel";
            this.mniTranslitPanel.CheckedChanged += new System.EventHandler(this.mniTranslitPanel_CheckedChanged);
            // 
            // mniAlifba
            // 
            this.mniAlifba.Checked = true;
            this.mniAlifba.CheckOnClick = true;
            this.mniAlifba.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mniAlifba.Name = "mniAlifba";
            this.mniAlifba.Size = new System.Drawing.Size(144, 22);
            this.mniAlifba.Text = "Alifba";
            this.mniAlifba.CheckedChanged += new System.EventHandler(this.mniAlifba_CheckedChanged);
            // 
            // mnuSettings
            // 
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniExclusions,
            this.mniConfiguration});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(61, 20);
            this.mnuSettings.Text = "Settings";
            // 
            // mniExclusions
            // 
            this.mniExclusions.Name = "mniExclusions";
            this.mniExclusions.Size = new System.Drawing.Size(157, 22);
            this.mniExclusions.Text = "Exclusions";
            this.mniExclusions.Click += new System.EventHandler(this.mniExclusions_Click);
            // 
            // mniConfiguration
            // 
            this.mniConfiguration.Name = "mniConfiguration";
            this.mniConfiguration.Size = new System.Drawing.Size(157, 22);
            this.mniConfiguration.Text = "Configuration...";
            this.mniConfiguration.Click += new System.EventHandler(this.mniConfiguration_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniAbout});
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 20);
            this.mnuHelp.Text = "Help";
            // 
            // mniAbout
            // 
            this.mniAbout.Name = "mniAbout";
            this.mniAbout.Size = new System.Drawing.Size(116, 22);
            this.mniAbout.Text = "About...";
            this.mniAbout.Click += new System.EventHandler(this.mniAbout_Click);
            // 
            // spltMain
            // 
            this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMain.Location = new System.Drawing.Point(0, 67);
            this.spltMain.Name = "spltMain";
            this.spltMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.Controls.Add(this.spltTranslitArea);
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.pnlYanalif);
            this.spltMain.Size = new System.Drawing.Size(853, 506);
            this.spltMain.SplitterDistance = 189;
            this.spltMain.SplitterWidth = 6;
            this.spltMain.TabIndex = 0;
            // 
            // spltTranslitArea
            // 
            this.spltTranslitArea.BackColor = System.Drawing.SystemColors.Window;
            this.spltTranslitArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.spltTranslitArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltTranslitArea.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.spltTranslitArea.Location = new System.Drawing.Point(0, 0);
            this.spltTranslitArea.Name = "spltTranslitArea";
            // 
            // spltTranslitArea.Panel1
            // 
            this.spltTranslitArea.Panel1.Controls.Add(this.pnlTranslit1);
            // 
            // spltTranslitArea.Panel2
            // 
            this.spltTranslitArea.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.spltTranslitArea.Panel2.Controls.Add(this.pnlTranslit2);
            this.spltTranslitArea.Size = new System.Drawing.Size(853, 189);
            this.spltTranslitArea.SplitterDistance = 460;
            this.spltTranslitArea.TabIndex = 0;
            // 
            // pnlTranslit1
            // 
            this.pnlTranslit1.Controls.Add(this.txtTranslit1);
            this.pnlTranslit1.Controls.Add(this.pnlTranslit1Bottom);
            this.pnlTranslit1.Controls.Add(this.tlsTarnslit1);
            this.pnlTranslit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranslit1.Location = new System.Drawing.Point(0, 0);
            this.pnlTranslit1.Name = "pnlTranslit1";
            this.pnlTranslit1.Size = new System.Drawing.Size(456, 185);
            this.pnlTranslit1.TabIndex = 4;
            this.pnlTranslit1.SizeChanged += new System.EventHandler(this.pnlTranslit1_SizeChanged);
            // 
            // txtTranslit1
            // 
            this.txtTranslit1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTranslit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTranslit1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTranslit1.HideSelection = false;
            this.txtTranslit1.Location = new System.Drawing.Point(0, 0);
            this.txtTranslit1.Name = "txtTranslit1";
            this.txtTranslit1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTranslit1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtTranslit1.Size = new System.Drawing.Size(456, 99);
            this.txtTranslit1.TabIndex = 1;
            this.txtTranslit1.Text = "";
            this.txtTranslit1.Enter += new System.EventHandler(this.txtTranslit1_Enter);
            // 
            // pnlTranslit1Bottom
            // 
            this.pnlTranslit1Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTranslit1Bottom.Location = new System.Drawing.Point(0, 99);
            this.pnlTranslit1Bottom.Name = "pnlTranslit1Bottom";
            this.pnlTranslit1Bottom.Size = new System.Drawing.Size(456, 55);
            this.pnlTranslit1Bottom.TabIndex = 3;
            this.pnlTranslit1Bottom.Visible = false;
            // 
            // tlsTarnslit1
            // 
            this.tlsTarnslit1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlsTarnslit1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsTarnslit1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSource,
            this.toolStripSeparator1,
            this.btnTranslit1Config,
            this.btnT1Keyboard,
            this.btnToYanalif,
            this.btnTranslitAux});
            this.tlsTarnslit1.Location = new System.Drawing.Point(0, 154);
            this.tlsTarnslit1.Name = "tlsTarnslit1";
            this.tlsTarnslit1.Size = new System.Drawing.Size(456, 31);
            this.tlsTarnslit1.TabIndex = 2;
            this.tlsTarnslit1.Text = "Translit1";
            // 
            // lblSource
            // 
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(43, 28);
            this.lblSource.Text = "Source";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnTranslit1Config
            // 
            this.btnTranslit1Config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslit1Config.Enabled = false;
            this.btnTranslit1Config.Image = global::Bitig.UI.Properties.Resources.advanced;
            this.btnTranslit1Config.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTranslit1Config.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslit1Config.Name = "btnTranslit1Config";
            this.btnTranslit1Config.Size = new System.Drawing.Size(28, 28);
            this.btnTranslit1Config.Text = "Settings";
            // 
            // btnT1Keyboard
            // 
            this.btnT1Keyboard.CheckOnClick = true;
            this.btnT1Keyboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnT1Keyboard.Enabled = false;
            this.btnT1Keyboard.Image = global::Bitig.UI.Properties.Resources.keyboard16;
            this.btnT1Keyboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnT1Keyboard.Name = "btnT1Keyboard";
            this.btnT1Keyboard.Size = new System.Drawing.Size(23, 28);
            this.btnT1Keyboard.Text = "Virtual Keyboard";
            this.btnT1Keyboard.CheckedChanged += new System.EventHandler(this.btnT1Keyboard_CheckedChanged);
            // 
            // btnToYanalif
            // 
            this.btnToYanalif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToYanalif.Image = global::Bitig.UI.Properties.Resources.down;
            this.btnToYanalif.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToYanalif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToYanalif.Name = "btnToYanalif";
            this.btnToYanalif.Size = new System.Drawing.Size(28, 28);
            this.btnToYanalif.Click += new System.EventHandler(this.btnToYanalif_Click);
            // 
            // btnTranslitAux
            // 
            this.btnTranslitAux.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslitAux.Image = global::Bitig.UI.Properties.Resources.right;
            this.btnTranslitAux.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTranslitAux.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslitAux.Name = "btnTranslitAux";
            this.btnTranslitAux.Size = new System.Drawing.Size(28, 28);
            this.btnTranslitAux.Click += new System.EventHandler(this.btnTranslitAux_Click);
            // 
            // pnlTranslit2
            // 
            this.pnlTranslit2.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTranslit2.Controls.Add(this.txtTranslit2);
            this.pnlTranslit2.Controls.Add(this.pnlTranslit2Bottom);
            this.pnlTranslit2.Controls.Add(this.tlsTranslit2);
            this.pnlTranslit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranslit2.Location = new System.Drawing.Point(0, 0);
            this.pnlTranslit2.Name = "pnlTranslit2";
            this.pnlTranslit2.Size = new System.Drawing.Size(385, 185);
            this.pnlTranslit2.TabIndex = 3;
            this.pnlTranslit2.SizeChanged += new System.EventHandler(this.pnlTranslit2_SizeChanged);
            // 
            // txtTranslit2
            // 
            this.txtTranslit2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTranslit2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTranslit2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTranslit2.HideSelection = false;
            this.txtTranslit2.Location = new System.Drawing.Point(0, 0);
            this.txtTranslit2.Name = "txtTranslit2";
            this.txtTranslit2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtTranslit2.Size = new System.Drawing.Size(385, 99);
            this.txtTranslit2.TabIndex = 0;
            this.txtTranslit2.Text = "";
            this.txtTranslit2.Enter += new System.EventHandler(this.txtTranslit2_Enter);
            // 
            // pnlTranslit2Bottom
            // 
            this.pnlTranslit2Bottom.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTranslit2Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTranslit2Bottom.Location = new System.Drawing.Point(0, 99);
            this.pnlTranslit2Bottom.Name = "pnlTranslit2Bottom";
            this.pnlTranslit2Bottom.Size = new System.Drawing.Size(385, 55);
            this.pnlTranslit2Bottom.TabIndex = 2;
            this.pnlTranslit2Bottom.Visible = false;
            // 
            // tlsTranslit2
            // 
            this.tlsTranslit2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlsTranslit2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsTranslit2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblTarget,
            this.toolStripSeparator4,
            this.btnTranslit2Config,
            this.btnT2Keyboard,
            this.btnFromYanalif});
            this.tlsTranslit2.Location = new System.Drawing.Point(0, 154);
            this.tlsTranslit2.Name = "tlsTranslit2";
            this.tlsTranslit2.Size = new System.Drawing.Size(385, 31);
            this.tlsTranslit2.TabIndex = 1;
            this.tlsTranslit2.Text = "Translit2";
            // 
            // lblTarget
            // 
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(40, 28);
            this.lblTarget.Text = "Target";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 31);
            // 
            // btnTranslit2Config
            // 
            this.btnTranslit2Config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslit2Config.Enabled = false;
            this.btnTranslit2Config.Image = global::Bitig.UI.Properties.Resources.advanced;
            this.btnTranslit2Config.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTranslit2Config.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslit2Config.Name = "btnTranslit2Config";
            this.btnTranslit2Config.Size = new System.Drawing.Size(28, 28);
            this.btnTranslit2Config.Text = "Settings";
            // 
            // btnT2Keyboard
            // 
            this.btnT2Keyboard.CheckOnClick = true;
            this.btnT2Keyboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnT2Keyboard.Enabled = false;
            this.btnT2Keyboard.Image = global::Bitig.UI.Properties.Resources.keyboard16;
            this.btnT2Keyboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnT2Keyboard.Name = "btnT2Keyboard";
            this.btnT2Keyboard.Size = new System.Drawing.Size(23, 28);
            this.btnT2Keyboard.Text = "Virtual Keyboard";
            this.btnT2Keyboard.CheckedChanged += new System.EventHandler(this.btnT2Keyboard_CheckedChanged);
            // 
            // btnFromYanalif
            // 
            this.btnFromYanalif.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFromYanalif.Image = global::Bitig.UI.Properties.Resources.up;
            this.btnFromYanalif.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFromYanalif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFromYanalif.Name = "btnFromYanalif";
            this.btnFromYanalif.Size = new System.Drawing.Size(28, 28);
            this.btnFromYanalif.Click += new System.EventHandler(this.btnFromYanalif_Click);
            // 
            // pnlYanalif
            // 
            this.pnlYanalif.Controls.Add(this.ctlMultiRtb1);
            this.pnlYanalif.Controls.Add(this.ctlYanalif1);
            this.pnlYanalif.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlYanalif.Location = new System.Drawing.Point(0, 0);
            this.pnlYanalif.Name = "pnlYanalif";
            this.pnlYanalif.Size = new System.Drawing.Size(853, 311);
            this.pnlYanalif.TabIndex = 2;
            this.pnlYanalif.SizeChanged += new System.EventHandler(this.pnlYanalif_SizeChanged);
            // 
            // ctlMultiRtb1
            // 
            this.ctlMultiRtb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlMultiRtb1.Location = new System.Drawing.Point(0, 40);
            this.ctlMultiRtb1.Name = "ctlMultiRtb1";
            this.ctlMultiRtb1.Size = new System.Drawing.Size(853, 271);
            this.ctlMultiRtb1.TabIndex = 0;
            // 
            // ctlYanalif1
            // 
            this.ctlYanalif1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlYanalif1.Location = new System.Drawing.Point(0, 0);
            this.ctlYanalif1.Name = "ctlYanalif1";
            this.ctlYanalif1.Size = new System.Drawing.Size(853, 40);
            this.ctlYanalif1.TabIndex = 1;
            this.ctlYanalif1.X_CustomSymbols = null;
            this.ctlYanalif1.VisibleChanged += new System.EventHandler(this.ctlYanalif1_VisibleChanged);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.tlsMain);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(853, 43);
            this.pnlTop.TabIndex = 27;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(853, 573);
            this.Controls.Add(this.spltMain);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.mnuMain);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::Bitig.UI.Properties.Settings.Default, "k_Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::Bitig.UI.Properties.Settings.Default.k_Location;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMainForm";
            this.Text = "Bitig";
            this.WindowState = global::Bitig.UI.Properties.Settings.Default.k_WindowState;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainForm_FormClosing);
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.Shown += new System.EventHandler(this.frmMainForm_Shown);
            this.SizeChanged += new System.EventHandler(this.frmMainForm_SizeChanged);
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            this.spltMain.ResumeLayout(false);
            this.spltTranslitArea.Panel1.ResumeLayout(false);
            this.spltTranslitArea.Panel2.ResumeLayout(false);
            this.spltTranslitArea.ResumeLayout(false);
            this.pnlTranslit1.ResumeLayout(false);
            this.pnlTranslit1.PerformLayout();
            this.tlsTarnslit1.ResumeLayout(false);
            this.tlsTarnslit1.PerformLayout();
            this.pnlTranslit2.ResumeLayout(false);
            this.pnlTranslit2.PerformLayout();
            this.tlsTranslit2.ResumeLayout(false);
            this.tlsTranslit2.PerformLayout();
            this.pnlYanalif.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton btnShowAlifba;
        private System.Windows.Forms.ToolStripButton btnShowTranslit;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuEdit;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        //private System.Windows.Forms.ToolStripContainer tscMain;
        private System.Windows.Forms.SplitContainer spltMain;
        private System.Windows.Forms.SplitContainer spltTranslitArea;
        private System.Windows.Forms.RichTextBox txtTranslit1;
        private System.Windows.Forms.RichTextBox txtTranslit2;
        private System.Windows.Forms.ToolStripMenuItem mniExclusions;
        private System.Windows.Forms.ColorDialog dlgColor;
        private Bitig.RtbControl.ctlMultiRtb ctlMultiRtb1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FlowLayoutPanel pnlTop;
        private System.Windows.Forms.ToolStrip tlsTarnslit1;
        private System.Windows.Forms.ToolStripButton btnTranslitAux;
        private System.Windows.Forms.ToolStripButton btnToYanalif;
        private System.Windows.Forms.ToolStrip tlsTranslit2;
        private System.Windows.Forms.ToolStripButton btnFromYanalif;
        private System.Windows.Forms.ToolStripButton btnTranslit1Config;
        private System.Windows.Forms.ToolStripButton btnTranslit2Config;
        private System.Windows.Forms.ToolStripButton btnT1Keyboard;
        private System.Windows.Forms.ToolStripMenuItem mniTranslitPanel;
        private System.Windows.Forms.ToolStripButton btnT2Keyboard;
        private System.Windows.Forms.ToolStripMenuItem mniUndo;
        private System.Windows.Forms.ToolStripMenuItem mniRedo;
        private System.Windows.Forms.ToolStripMenuItem mniCut;
        private System.Windows.Forms.ToolStripMenuItem mniCopy;
        private System.Windows.Forms.ToolStripMenuItem mniPaste;
        private System.Windows.Forms.Panel pnlYanalif;
        private System.Windows.Forms.ToolStripComboBox cmbTarget;
        private System.Windows.Forms.ToolStripLabel lblTo;
        private System.Windows.Forms.ToolStripComboBox cmbSource;
        private System.Windows.Forms.ToolStripLabel lblSource;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel lblTarget;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.ToolStripMenuItem mniConfiguration;
        private System.Windows.Forms.Panel pnlTranslit1Bottom;
        private System.Windows.Forms.Panel pnlTranslit2Bottom;
        private System.Windows.Forms.Panel pnlTranslit2;
        private System.Windows.Forms.Panel pnlTranslit1;
        private System.Windows.Forms.ToolStripMenuItem mniAlifba;
        private Bitig.UI.Controls.ctlYanalif ctlYanalif1;
    }
}

