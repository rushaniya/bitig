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
            this.cmbMainAlphabet = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnMainConfig = new System.Windows.Forms.ToolStripButton();
            this.btnMainKeyboard = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowTranslit = new System.Windows.Forms.ToolStripButton();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTranslitPanel = new System.Windows.Forms.ToolStripMenuItem();
            this.mniMainKeyboard = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mniExclusions = new System.Windows.Forms.ToolStripMenuItem();
            this.mniConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.mniCurrentMapping = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.pnlTranslit = new System.Windows.Forms.Panel();
            this.txtTranslit = new System.Windows.Forms.RichTextBox();
            this.pnlTranslitKeyboard = new System.Windows.Forms.Panel();
            this.tlsTranslit = new System.Windows.Forms.ToolStrip();
            this.cmbTranslit = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTranslitConfig = new System.Windows.Forms.ToolStripButton();
            this.btnTranslitKeyboard = new System.Windows.Forms.ToolStripButton();
            this.btnToMain = new System.Windows.Forms.ToolStripButton();
            this.btnFromMain = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.ctlMultiRtb1 = new Bitig.RtbControl.ctlMultiRtb();
            this.pnlMainKeyboard = new System.Windows.Forms.Panel();
            this.pnlTop = new System.Windows.Forms.FlowLayoutPanel();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.tlsMain.SuspendLayout();
            this.mnuMain.SuspendLayout();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            this.pnlTranslit.SuspendLayout();
            this.tlsTranslit.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsMain
            // 
            this.tlsMain.BackColor = System.Drawing.SystemColors.Window;
            this.tlsMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.tlsMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbMainAlphabet,
            this.toolStripSeparator2,
            this.btnMainConfig,
            this.btnMainKeyboard,
            this.toolStripSeparator3,
            this.btnShowTranslit});
            this.tlsMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tlsMain.Location = new System.Drawing.Point(0, 0);
            this.tlsMain.Name = "tlsMain";
            this.tlsMain.Size = new System.Drawing.Size(305, 39);
            this.tlsMain.TabIndex = 0;
            this.tlsMain.Text = "Main Panel";
            // 
            // cmbMainAlphabet
            // 
            this.cmbMainAlphabet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMainAlphabet.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbMainAlphabet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMainAlphabet.Name = "cmbMainAlphabet";
            this.cmbMainAlphabet.Size = new System.Drawing.Size(180, 39);
            this.cmbMainAlphabet.SelectedIndexChanged += new System.EventHandler(this.cmbMainAlphabet_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // btnMainConfig
            // 
            this.btnMainConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMainConfig.Image = global::Bitig.UI.Properties.Resources.settings;
            this.btnMainConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMainConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMainConfig.Name = "btnMainConfig";
            this.btnMainConfig.Size = new System.Drawing.Size(36, 36);
            this.btnMainConfig.Text = "Alphabet settings";
            this.btnMainConfig.Click += new System.EventHandler(this.btnMainConfig_Click);
            // 
            // btnMainKeyboard
            // 
            this.btnMainKeyboard.CheckOnClick = true;
            this.btnMainKeyboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnMainKeyboard.Image = global::Bitig.UI.Properties.Resources.keyboard;
            this.btnMainKeyboard.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMainKeyboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnMainKeyboard.Name = "btnMainKeyboard";
            this.btnMainKeyboard.Size = new System.Drawing.Size(36, 36);
            this.btnMainKeyboard.Text = "On-screen keyboard";
            this.btnMainKeyboard.CheckedChanged += new System.EventHandler(this.btnMainKeyboard_CheckedChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
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
            // mnuMain
            // 
            this.mnuMain.BackColor = System.Drawing.SystemColors.Window;
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
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
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniTranslitPanel,
            this.mniMainKeyboard});
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
            this.mniTranslitPanel.Size = new System.Drawing.Size(181, 22);
            this.mniTranslitPanel.Text = "Translit panel";
            this.mniTranslitPanel.CheckedChanged += new System.EventHandler(this.mniTranslitPanel_CheckedChanged);
            // 
            // mniMainKeyboard
            // 
            this.mniMainKeyboard.Checked = true;
            this.mniMainKeyboard.CheckOnClick = true;
            this.mniMainKeyboard.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mniMainKeyboard.Name = "mniMainKeyboard";
            this.mniMainKeyboard.Size = new System.Drawing.Size(181, 22);
            this.mniMainKeyboard.Text = "On-screen keyboard";
            this.mniMainKeyboard.CheckedChanged += new System.EventHandler(this.mniAlphabet_CheckedChanged);
            // 
            // mnuSettings
            // 
            this.mnuSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniExclusions,
            this.mniConfiguration,
            this.mniCurrentMapping});
            this.mnuSettings.Name = "mnuSettings";
            this.mnuSettings.Size = new System.Drawing.Size(61, 20);
            this.mnuSettings.Text = "Settings";
            // 
            // mniExclusions
            // 
            this.mniExclusions.Name = "mniExclusions";
            this.mniExclusions.Size = new System.Drawing.Size(165, 22);
            this.mniExclusions.Text = "Exclusions";
            this.mniExclusions.Click += new System.EventHandler(this.mniExclusions_Click);
            // 
            // mniConfiguration
            // 
            this.mniConfiguration.Name = "mniConfiguration";
            this.mniConfiguration.Size = new System.Drawing.Size(165, 22);
            this.mniConfiguration.Text = "Configuration";
            this.mniConfiguration.Click += new System.EventHandler(this.mniConfiguration_Click);
            // 
            // mniCurrentMapping
            // 
            this.mniCurrentMapping.Enabled = false;
            this.mniCurrentMapping.Name = "mniCurrentMapping";
            this.mniCurrentMapping.Size = new System.Drawing.Size(165, 22);
            this.mniCurrentMapping.Text = "Current mapping";
            this.mniCurrentMapping.Click += new System.EventHandler(this.mniCurrentMapping_Click);
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
            this.spltMain.Location = new System.Drawing.Point(0, 24);
            this.spltMain.Name = "spltMain";
            this.spltMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.Controls.Add(this.pnlTranslit);
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.pnlMain);
            this.spltMain.Panel2.Controls.Add(this.pnlTop);
            this.spltMain.Size = new System.Drawing.Size(853, 549);
            this.spltMain.SplitterDistance = 205;
            this.spltMain.SplitterWidth = 6;
            this.spltMain.TabIndex = 0;
            // 
            // pnlTranslit
            // 
            this.pnlTranslit.Controls.Add(this.txtTranslit);
            this.pnlTranslit.Controls.Add(this.pnlTranslitKeyboard);
            this.pnlTranslit.Controls.Add(this.tlsTranslit);
            this.pnlTranslit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTranslit.Location = new System.Drawing.Point(0, 0);
            this.pnlTranslit.Name = "pnlTranslit";
            this.pnlTranslit.Size = new System.Drawing.Size(853, 205);
            this.pnlTranslit.TabIndex = 4;
            this.pnlTranslit.SizeChanged += new System.EventHandler(this.pnlTranslit_SizeChanged);
            // 
            // txtTranslit
            // 
            this.txtTranslit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtTranslit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTranslit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTranslit.HideSelection = false;
            this.txtTranslit.Location = new System.Drawing.Point(0, 0);
            this.txtTranslit.Name = "txtTranslit";
            this.txtTranslit.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtTranslit.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtTranslit.Size = new System.Drawing.Size(853, 119);
            this.txtTranslit.TabIndex = 1;
            this.txtTranslit.Text = "";
            // 
            // pnlTranslitKeyboard
            // 
            this.pnlTranslitKeyboard.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTranslitKeyboard.Location = new System.Drawing.Point(0, 119);
            this.pnlTranslitKeyboard.Name = "pnlTranslitKeyboard";
            this.pnlTranslitKeyboard.Size = new System.Drawing.Size(853, 55);
            this.pnlTranslitKeyboard.TabIndex = 3;
            this.pnlTranslitKeyboard.Visible = false;
            // 
            // tlsTranslit
            // 
            this.tlsTranslit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tlsTranslit.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsTranslit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmbTranslit,
            this.toolStripSeparator1,
            this.btnTranslitConfig,
            this.btnTranslitKeyboard,
            this.btnToMain,
            this.btnFromMain});
            this.tlsTranslit.Location = new System.Drawing.Point(0, 174);
            this.tlsTranslit.Name = "tlsTranslit";
            this.tlsTranslit.Size = new System.Drawing.Size(853, 31);
            this.tlsTranslit.TabIndex = 2;
            this.tlsTranslit.Text = "Translit1";
            // 
            // cmbTranslit
            // 
            this.cmbTranslit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTranslit.Name = "cmbTranslit";
            this.cmbTranslit.Size = new System.Drawing.Size(200, 31);
            this.cmbTranslit.SelectedIndexChanged += new System.EventHandler(this.cmbTranslit_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // btnTranslitConfig
            // 
            this.btnTranslitConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslitConfig.Enabled = false;
            this.btnTranslitConfig.Image = global::Bitig.UI.Properties.Resources.advanced;
            this.btnTranslitConfig.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnTranslitConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslitConfig.Name = "btnTranslitConfig";
            this.btnTranslitConfig.Size = new System.Drawing.Size(28, 28);
            this.btnTranslitConfig.Text = "Alphabet settings";
            this.btnTranslitConfig.Click += new System.EventHandler(this.btnTranslitConfig_Click);
            // 
            // btnTranslitKeyboard
            // 
            this.btnTranslitKeyboard.CheckOnClick = true;
            this.btnTranslitKeyboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnTranslitKeyboard.Enabled = false;
            this.btnTranslitKeyboard.Image = global::Bitig.UI.Properties.Resources.keyboard16;
            this.btnTranslitKeyboard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTranslitKeyboard.Name = "btnTranslitKeyboard";
            this.btnTranslitKeyboard.Size = new System.Drawing.Size(23, 28);
            this.btnTranslitKeyboard.Text = "On-screen keyboard";
            this.btnTranslitKeyboard.CheckedChanged += new System.EventHandler(this.btnTranslitKeyboard_CheckedChanged);
            // 
            // btnToMain
            // 
            this.btnToMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnToMain.Image = global::Bitig.UI.Properties.Resources.down;
            this.btnToMain.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnToMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnToMain.Name = "btnToMain";
            this.btnToMain.Size = new System.Drawing.Size(28, 28);
            this.btnToMain.Click += new System.EventHandler(this.btnToMain_Click);
            // 
            // btnFromMain
            // 
            this.btnFromMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFromMain.Image = global::Bitig.UI.Properties.Resources.up;
            this.btnFromMain.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnFromMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFromMain.Name = "btnFromMain";
            this.btnFromMain.Size = new System.Drawing.Size(28, 28);
            this.btnFromMain.Click += new System.EventHandler(this.btnFromMain_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.ctlMultiRtb1);
            this.pnlMain.Controls.Add(this.pnlMainKeyboard);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 44);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(853, 294);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.SizeChanged += new System.EventHandler(this.pnlMain_SizeChanged);
            // 
            // ctlMultiRtb1
            // 
            this.ctlMultiRtb1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlMultiRtb1.Location = new System.Drawing.Point(0, 44);
            this.ctlMultiRtb1.Name = "ctlMultiRtb1";
            this.ctlMultiRtb1.Size = new System.Drawing.Size(853, 250);
            this.ctlMultiRtb1.TabIndex = 0;
            // 
            // pnlMainKeyboard
            // 
            this.pnlMainKeyboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainKeyboard.Location = new System.Drawing.Point(0, 0);
            this.pnlMainKeyboard.Name = "pnlMainKeyboard";
            this.pnlMainKeyboard.Size = new System.Drawing.Size(853, 44);
            this.pnlMainKeyboard.TabIndex = 1;
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.tlsMain);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(853, 44);
            this.pnlTop.TabIndex = 27;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(853, 573);
            this.Controls.Add(this.spltMain);
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
            this.tlsMain.ResumeLayout(false);
            this.tlsMain.PerformLayout();
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            this.spltMain.ResumeLayout(false);
            this.pnlTranslit.ResumeLayout(false);
            this.pnlTranslit.PerformLayout();
            this.tlsTranslit.ResumeLayout(false);
            this.tlsTranslit.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsMain;
        private System.Windows.Forms.ToolStripButton btnMainKeyboard;
        private System.Windows.Forms.ToolStripButton btnShowTranslit;
        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuView;
        private System.Windows.Forms.ToolStripMenuItem mnuSettings;
        private System.Windows.Forms.ToolStripMenuItem mnuHelp;
        //private System.Windows.Forms.ToolStripContainer tscMain;
        private System.Windows.Forms.SplitContainer spltMain;
        private System.Windows.Forms.RichTextBox txtTranslit;
        private System.Windows.Forms.ToolStripMenuItem mniExclusions;
        private System.Windows.Forms.ColorDialog dlgColor;
        private Bitig.RtbControl.ctlMultiRtb ctlMultiRtb1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FlowLayoutPanel pnlTop;
        private System.Windows.Forms.ToolStrip tlsTranslit;
        private System.Windows.Forms.ToolStripButton btnFromMain;
        private System.Windows.Forms.ToolStripButton btnToMain;
        private System.Windows.Forms.ToolStripButton btnTranslitConfig;
        private System.Windows.Forms.ToolStripButton btnTranslitKeyboard;
        private System.Windows.Forms.ToolStripMenuItem mniTranslitPanel;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mniAbout;
        private System.Windows.Forms.ToolStripMenuItem mniConfiguration;
        private System.Windows.Forms.Panel pnlTranslitKeyboard;
        private System.Windows.Forms.Panel pnlTranslit;
        private System.Windows.Forms.ToolStripMenuItem mniMainKeyboard;
        private System.Windows.Forms.ToolStripMenuItem mniCurrentMapping;
        private System.Windows.Forms.ToolStripComboBox cmbTranslit;
        private System.Windows.Forms.ToolStripComboBox cmbMainAlphabet;
        private System.Windows.Forms.ToolStripButton btnMainConfig;
        private System.Windows.Forms.Panel pnlMainKeyboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

