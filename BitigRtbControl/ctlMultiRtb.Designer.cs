namespace Bitig.RtbControl
{
    partial class ctlMultiRtb
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ctxText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ctxiNumericList = new System.Windows.Forms.ToolStripMenuItem();
            this.dlgColor = new System.Windows.Forms.ColorDialog();
            this.tlsAdditional = new System.Windows.Forms.ToolStrip();
            this.btnBullet = new System.Windows.Forms.ToolStripButton();
            this.btnNumericList = new System.Windows.Forms.ToolStripButton();
            this.btnForecolor = new System.Windows.Forms.ToolStripButton();
            this.btnBackcolor = new System.Windows.Forms.ToolStripButton();
            this.btnIndent = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveIndent = new System.Windows.Forms.ToolStripButton();
            this.tlsBasic = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.cmbFont = new System.Windows.Forms.ToolStripComboBox();
            this.cmbFontSize = new System.Windows.Forms.ToolStripComboBox();
            this.btnItalic = new System.Windows.Forms.ToolStripButton();
            this.btnBold = new System.Windows.Forms.ToolStripButton();
            this.btnStrikeout = new System.Windows.Forms.ToolStripButton();
            this.btnUnderline = new System.Windows.Forms.ToolStripButton();
            this.btnAlignLeft = new System.Windows.Forms.ToolStripButton();
            this.btnAlignRight = new System.Windows.Forms.ToolStripButton();
            this.btnAlignCenter = new System.Windows.Forms.ToolStripButton();
            this.btnAlignJustified = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.rtbMain = new Bitig.RtbControl.CRichTextBox();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.mnuMultiRTB = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mniNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mniOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mniReopen = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUtf8 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUtf16 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUtf7 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUtf32 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniBigEndian = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAnsi = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAscii = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.mniNumericList = new System.Windows.Forms.ToolStripMenuItem();
            this.mniAnsi1251 = new System.Windows.Forms.ToolStripMenuItem();
            this.mniUtf8Bom = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDefaultEncoding = new System.Windows.Forms.ToolStripMenuItem();
            this.ctxText.SuspendLayout();
            this.tlsAdditional.SuspendLayout();
            this.tlsBasic.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.mnuMultiRTB.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctxText
            // 
            this.ctxText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctxiNumericList});
            this.ctxText.Name = "ctxText";
            this.ctxText.Size = new System.Drawing.Size(148, 26);
            // 
            // ctxiNumericList
            // 
            this.ctxiNumericList.Name = "ctxiNumericList";
            this.ctxiNumericList.Size = new System.Drawing.Size(147, 22);
            this.ctxiNumericList.Text = "Numeric list...";
            this.ctxiNumericList.Click += new System.EventHandler(this.ctxiNumericList_Click);
            // 
            // tlsAdditional
            // 
            this.tlsAdditional.BackColor = System.Drawing.SystemColors.Window;
            this.tlsAdditional.Dock = System.Windows.Forms.DockStyle.None;
            this.tlsAdditional.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsAdditional.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBullet,
            this.btnNumericList,
            this.btnForecolor,
            this.btnBackcolor,
            this.btnIndent,
            this.btnRemoveIndent});
            this.tlsAdditional.Location = new System.Drawing.Point(0, 3);
            this.tlsAdditional.Name = "tlsAdditional";
            this.tlsAdditional.Size = new System.Drawing.Size(37, 236);
            this.tlsAdditional.TabIndex = 0;
            // 
            // btnBullet
            // 
            this.btnBullet.CheckOnClick = true;
            this.btnBullet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBullet.Image = global::Bitig.RtbControl.Properties.Resources.bulleted_list;
            this.btnBullet.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBullet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBullet.Name = "btnBullet";
            this.btnBullet.Size = new System.Drawing.Size(35, 36);
            this.btnBullet.Text = "Bulleted list";
            this.btnBullet.Click += new System.EventHandler(this.btnBullet_Click);
            // 
            // btnNumericList
            // 
            this.btnNumericList.CheckOnClick = true;
            this.btnNumericList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNumericList.DoubleClickEnabled = true;
            this.btnNumericList.Image = global::Bitig.RtbControl.Properties.Resources.numeric_list;
            this.btnNumericList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNumericList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNumericList.Name = "btnNumericList";
            this.btnNumericList.Size = new System.Drawing.Size(35, 36);
            this.btnNumericList.Text = "Numeric list";
            this.btnNumericList.Click += new System.EventHandler(this.btnNumericList_Click);
            // 
            // btnForecolor
            // 
            this.btnForecolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnForecolor.Image = global::Bitig.RtbControl.Properties.Resources.forecolor;
            this.btnForecolor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnForecolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnForecolor.Name = "btnForecolor";
            this.btnForecolor.Size = new System.Drawing.Size(35, 36);
            this.btnForecolor.Text = "Text color";
            this.btnForecolor.Click += new System.EventHandler(this.btnForecolor_Click);
            // 
            // btnBackcolor
            // 
            this.btnBackcolor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBackcolor.Image = global::Bitig.RtbControl.Properties.Resources.backcolor;
            this.btnBackcolor.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBackcolor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBackcolor.Name = "btnBackcolor";
            this.btnBackcolor.Size = new System.Drawing.Size(35, 36);
            this.btnBackcolor.Text = "Background color";
            this.btnBackcolor.Click += new System.EventHandler(this.btnBackcolor_Click);
            // 
            // btnIndent
            // 
            this.btnIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIndent.Image = global::Bitig.RtbControl.Properties.Resources.indent;
            this.btnIndent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIndent.Name = "btnIndent";
            this.btnIndent.Size = new System.Drawing.Size(35, 36);
            this.btnIndent.Text = "Incease indent";
            this.btnIndent.Click += new System.EventHandler(this.btnIndent_Click);
            // 
            // btnRemoveIndent
            // 
            this.btnRemoveIndent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveIndent.Image = global::Bitig.RtbControl.Properties.Resources.indent_remove;
            this.btnRemoveIndent.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnRemoveIndent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveIndent.Name = "btnRemoveIndent";
            this.btnRemoveIndent.Size = new System.Drawing.Size(35, 36);
            this.btnRemoveIndent.Text = "Decrease indent";
            this.btnRemoveIndent.Click += new System.EventHandler(this.btnRemoveIndent_Click);
            // 
            // tlsBasic
            // 
            this.tlsBasic.BackColor = System.Drawing.SystemColors.Window;
            this.tlsBasic.Dock = System.Windows.Forms.DockStyle.None;
            this.tlsBasic.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsBasic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.btnSave,
            this.cmbFont,
            this.cmbFontSize,
            this.btnItalic,
            this.btnBold,
            this.btnStrikeout,
            this.btnUnderline,
            this.btnAlignLeft,
            this.btnAlignRight,
            this.btnAlignCenter,
            this.btnAlignJustified});
            this.tlsBasic.Location = new System.Drawing.Point(3, 0);
            this.tlsBasic.Name = "tlsBasic";
            this.tlsBasic.Size = new System.Drawing.Size(622, 39);
            this.tlsBasic.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = global::Bitig.RtbControl.Properties.Resources.open;
            this.btnOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(36, 36);
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::Bitig.RtbControl.Properties.Resources.save;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(36, 36);
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cmbFont
            // 
            this.cmbFont.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbFont.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbFont.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbFont.Name = "cmbFont";
            this.cmbFont.Size = new System.Drawing.Size(180, 39);
            this.cmbFont.SelectedIndexChanged += new System.EventHandler(this.cmbFont_SelectedIndexChanged);
            // 
            // cmbFontSize
            // 
            this.cmbFontSize.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.cmbFontSize.Name = "cmbFontSize";
            this.cmbFontSize.Size = new System.Drawing.Size(75, 39);
            this.cmbFontSize.SelectedIndexChanged += new System.EventHandler(this.cmbFontSize_SelectedIndexChanged);
            this.cmbFontSize.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbFontSize_KeyPress);
            // 
            // btnItalic
            // 
            this.btnItalic.CheckOnClick = true;
            this.btnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnItalic.Image = global::Bitig.RtbControl.Properties.Resources.italic;
            this.btnItalic.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnItalic.Name = "btnItalic";
            this.btnItalic.Size = new System.Drawing.Size(36, 36);
            this.btnItalic.Text = "Italic";
            this.btnItalic.CheckedChanged += new System.EventHandler(this.btnItalic_CheckedChanged);
            // 
            // btnBold
            // 
            this.btnBold.CheckOnClick = true;
            this.btnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnBold.Image = global::Bitig.RtbControl.Properties.Resources.bold;
            this.btnBold.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBold.Name = "btnBold";
            this.btnBold.Size = new System.Drawing.Size(36, 36);
            this.btnBold.Text = "Bold";
            this.btnBold.CheckedChanged += new System.EventHandler(this.btnBold_CheckedChanged);
            // 
            // btnStrikeout
            // 
            this.btnStrikeout.CheckOnClick = true;
            this.btnStrikeout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStrikeout.Image = global::Bitig.RtbControl.Properties.Resources.Strikeout;
            this.btnStrikeout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnStrikeout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStrikeout.Name = "btnStrikeout";
            this.btnStrikeout.Size = new System.Drawing.Size(36, 36);
            this.btnStrikeout.Text = "Strikeout";
            this.btnStrikeout.CheckedChanged += new System.EventHandler(this.btnStrikeout_CheckedChanged);
            // 
            // btnUnderline
            // 
            this.btnUnderline.CheckOnClick = true;
            this.btnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnUnderline.Image = global::Bitig.RtbControl.Properties.Resources.underline;
            this.btnUnderline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUnderline.Name = "btnUnderline";
            this.btnUnderline.Size = new System.Drawing.Size(36, 36);
            this.btnUnderline.Text = "Underline";
            this.btnUnderline.CheckedChanged += new System.EventHandler(this.btnUnderline_CheckedChanged);
            // 
            // btnAlignLeft
            // 
            this.btnAlignLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignLeft.Image = global::Bitig.RtbControl.Properties.Resources.align_left;
            this.btnAlignLeft.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAlignLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignLeft.Name = "btnAlignLeft";
            this.btnAlignLeft.Size = new System.Drawing.Size(36, 36);
            this.btnAlignLeft.Text = "Align left";
            this.btnAlignLeft.CheckedChanged += new System.EventHandler(this.btnAlignLeft_CheckedChanged);
            this.btnAlignLeft.Click += new System.EventHandler(this.btnAlignLeft_Click);
            // 
            // btnAlignRight
            // 
            this.btnAlignRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignRight.Image = global::Bitig.RtbControl.Properties.Resources.align_right;
            this.btnAlignRight.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAlignRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignRight.Name = "btnAlignRight";
            this.btnAlignRight.Size = new System.Drawing.Size(36, 36);
            this.btnAlignRight.Text = "Align right";
            this.btnAlignRight.CheckedChanged += new System.EventHandler(this.btnAlignRight_CheckedChanged);
            this.btnAlignRight.Click += new System.EventHandler(this.btnAlignRight_Click);
            // 
            // btnAlignCenter
            // 
            this.btnAlignCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignCenter.Image = global::Bitig.RtbControl.Properties.Resources.align_center;
            this.btnAlignCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAlignCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignCenter.Name = "btnAlignCenter";
            this.btnAlignCenter.Size = new System.Drawing.Size(36, 36);
            this.btnAlignCenter.Text = "Align center";
            this.btnAlignCenter.CheckedChanged += new System.EventHandler(this.btnAlignCenter_CheckedChanged);
            this.btnAlignCenter.Click += new System.EventHandler(this.btnAlignCenter_Click);
            // 
            // btnAlignJustified
            // 
            this.btnAlignJustified.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAlignJustified.Image = global::Bitig.RtbControl.Properties.Resources.align_justify;
            this.btnAlignJustified.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAlignJustified.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAlignJustified.Name = "btnAlignJustified";
            this.btnAlignJustified.Size = new System.Drawing.Size(36, 36);
            this.btnAlignJustified.Text = "Align justified";
            this.btnAlignJustified.CheckedChanged += new System.EventHandler(this.btnAlignJustified_CheckedChanged);
            this.btnAlignJustified.Click += new System.EventHandler(this.btnAlignJustified_Click);
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.rtbMain);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(798, 613);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 24);
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.tlsAdditional);
            this.toolStripContainer1.Size = new System.Drawing.Size(835, 652);
            this.toolStripContainer1.TabIndex = 28;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tlsBasic);
            // 
            // rtbMain
            // 
            this.rtbMain.ContextMenuStrip = this.ctxText;
            this.rtbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rtbMain.HideSelection = false;
            this.rtbMain.Location = new System.Drawing.Point(0, 0);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.Size = new System.Drawing.Size(798, 613);
            this.rtbMain.TabIndex = 0;
            this.rtbMain.Text = "";
            this.rtbMain.SelectionChanged += new System.EventHandler(this.rtbMain_SelectionChanged);
            this.rtbMain.Enter += new System.EventHandler(this.rtbMain_Enter);
            this.rtbMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbMain_MouseDown);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.FileName = "openFileDialog1";
            // 
            // mnuMultiRTB
            // 
            this.mnuMultiRTB.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuFormat});
            this.mnuMultiRTB.Location = new System.Drawing.Point(0, 0);
            this.mnuMultiRTB.Name = "mnuMultiRTB";
            this.mnuMultiRTB.Size = new System.Drawing.Size(835, 24);
            this.mnuMultiRTB.TabIndex = 1;
            this.mnuMultiRTB.Text = "Menu";
            this.mnuMultiRTB.Visible = false;
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniNew,
            this.mniOpen,
            this.mniSave,
            this.mniSaveAs,
            this.mniReopen});
            this.mnuFile.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "File";
            // 
            // mniNew
            // 
            this.mniNew.Name = "mniNew";
            this.mniNew.Size = new System.Drawing.Size(193, 22);
            this.mniNew.Text = "New";
            this.mniNew.Click += new System.EventHandler(this.mniNew_Click);
            // 
            // mniOpen
            // 
            this.mniOpen.Name = "mniOpen";
            this.mniOpen.Size = new System.Drawing.Size(193, 22);
            this.mniOpen.Text = "Open...";
            this.mniOpen.Click += new System.EventHandler(this.mniOpen_Click);
            // 
            // mniSave
            // 
            this.mniSave.Name = "mniSave";
            this.mniSave.Size = new System.Drawing.Size(193, 22);
            this.mniSave.Text = "Save";
            this.mniSave.Click += new System.EventHandler(this.mniSave_Click);
            // 
            // mniSaveAs
            // 
            this.mniSaveAs.Name = "mniSaveAs";
            this.mniSaveAs.Size = new System.Drawing.Size(193, 22);
            this.mniSaveAs.Text = "Save as...";
            this.mniSaveAs.Click += new System.EventHandler(this.mniSaveAs_Click);
            // 
            // mniReopen
            // 
            this.mniReopen.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniUtf8,
            this.mniUtf8Bom,
            this.mniUtf16,
            this.mniBigEndian,
            this.mniUtf7,
            this.mniUtf32,
            this.mniAnsi,
            this.mniAnsi1251,
            this.mniAscii,
            this.mniDefaultEncoding});
            this.mniReopen.Enabled = false;
            this.mniReopen.Name = "mniReopen";
            this.mniReopen.Size = new System.Drawing.Size(193, 22);
            this.mniReopen.Text = "Reopen with encoding";
            // 
            // mniUtf8
            // 
            this.mniUtf8.Name = "mniUtf8";
            this.mniUtf8.Size = new System.Drawing.Size(152, 22);
            this.mniUtf8.Text = "UTF-8";
            this.mniUtf8.Click += new System.EventHandler(this.mniUtf8_Click);
            // 
            // mniUtf16
            // 
            this.mniUtf16.Name = "mniUtf16";
            this.mniUtf16.Size = new System.Drawing.Size(152, 22);
            this.mniUtf16.Text = "UTF-16 LE";
            this.mniUtf16.Click += new System.EventHandler(this.mniUtf16_Click);
            // 
            // mniUtf7
            // 
            this.mniUtf7.Name = "mniUtf7";
            this.mniUtf7.Size = new System.Drawing.Size(152, 22);
            this.mniUtf7.Text = "UTF-7";
            this.mniUtf7.Click += new System.EventHandler(this.mniUtf7_Click);
            // 
            // mniUtf32
            // 
            this.mniUtf32.Name = "mniUtf32";
            this.mniUtf32.Size = new System.Drawing.Size(152, 22);
            this.mniUtf32.Text = "UTF-32";
            this.mniUtf32.Click += new System.EventHandler(this.mniUtf32_Click);
            // 
            // mniBigEndian
            // 
            this.mniBigEndian.Name = "mniBigEndian";
            this.mniBigEndian.Size = new System.Drawing.Size(152, 22);
            this.mniBigEndian.Text = "UTF-16 BE";
            this.mniBigEndian.Click += new System.EventHandler(this.mniBigEndian_Click);
            // 
            // mniAnsi
            // 
            this.mniAnsi.Name = "mniAnsi";
            this.mniAnsi.Size = new System.Drawing.Size(152, 22);
            this.mniAnsi.Text = "ANSI Latin";
            this.mniAnsi.Click += new System.EventHandler(this.mniAnsi_Click);
            // 
            // mniAscii
            // 
            this.mniAscii.Name = "mniAscii";
            this.mniAscii.Size = new System.Drawing.Size(152, 22);
            this.mniAscii.Text = "ASCII";
            this.mniAscii.Click += new System.EventHandler(this.mniAscii_Click);
            // 
            // mnuFormat
            // 
            this.mnuFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniNumericList});
            this.mnuFormat.Name = "mnuFormat";
            this.mnuFormat.Size = new System.Drawing.Size(57, 20);
            this.mnuFormat.Text = "Format";
            // 
            // mniNumericList
            // 
            this.mniNumericList.Name = "mniNumericList";
            this.mniNumericList.Size = new System.Drawing.Size(147, 22);
            this.mniNumericList.Text = "Numeric list...";
            this.mniNumericList.Click += new System.EventHandler(this.mniNumericList_Click);
            // 
            // mniAnsi1251
            // 
            this.mniAnsi1251.Name = "mniAnsi1251";
            this.mniAnsi1251.Size = new System.Drawing.Size(152, 22);
            this.mniAnsi1251.Text = "ANSI Cyrillic";
            this.mniAnsi1251.Click += new System.EventHandler(this.mniAnsi1251_Click);
            // 
            // mniUtf8Bom
            // 
            this.mniUtf8Bom.Name = "mniUtf8Bom";
            this.mniUtf8Bom.Size = new System.Drawing.Size(152, 22);
            this.mniUtf8Bom.Text = "UTF-8 BOM";
            this.mniUtf8Bom.Click += new System.EventHandler(this.mniUtf8Bom_Click);
            // 
            // mniDefaultEncoding
            // 
            this.mniDefaultEncoding.Name = "mniDefaultEncoding";
            this.mniDefaultEncoding.Size = new System.Drawing.Size(152, 22);
            this.mniDefaultEncoding.Text = "System default";
            this.mniDefaultEncoding.Click += new System.EventHandler(this.mniDefaultEncoding_Click);
            // 
            // ctlMultiRtb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.mnuMultiRTB);
            this.Name = "ctlMultiRtb";
            this.Size = new System.Drawing.Size(835, 676);
            this.Load += new System.EventHandler(this.ctlMultiRtb_Load);
            this.SizeChanged += new System.EventHandler(this.ctlMultiRtb_SizeChanged);
            this.ctxText.ResumeLayout(false);
            this.tlsAdditional.ResumeLayout(false);
            this.tlsAdditional.PerformLayout();
            this.tlsBasic.ResumeLayout(false);
            this.tlsBasic.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.mnuMultiRTB.ResumeLayout(false);
            this.mnuMultiRTB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private CRichTextBox rtbMain;
        private System.Windows.Forms.ToolStrip tlsAdditional;
        private System.Windows.Forms.ToolStrip tlsBasic;
        private System.Windows.Forms.ToolStripComboBox cmbFont;
        private System.Windows.Forms.ToolStripComboBox cmbFontSize;
        private System.Windows.Forms.ToolStripButton btnItalic;
        private System.Windows.Forms.ToolStripButton btnBold;
        private System.Windows.Forms.ToolStripButton btnStrikeout;
        private System.Windows.Forms.ToolStripButton btnUnderline;
        private System.Windows.Forms.ToolStripButton btnBullet;
        private System.Windows.Forms.ToolStripButton btnNumericList;
        private System.Windows.Forms.ToolStripButton btnIndent;
        private System.Windows.Forms.ToolStripButton btnRemoveIndent;
        private System.Windows.Forms.ColorDialog dlgColor;
        private System.Windows.Forms.ToolStripButton btnBackcolor;
        private System.Windows.Forms.ToolStripButton btnForecolor;
        private System.Windows.Forms.ToolStripButton btnAlignLeft;
        private System.Windows.Forms.ToolStripButton btnAlignRight;
        private System.Windows.Forms.ToolStripButton btnAlignCenter;
        private System.Windows.Forms.ToolStripButton btnAlignJustified;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.ContextMenuStrip ctxText;
        private System.Windows.Forms.ToolStripMenuItem ctxiNumericList;
        public System.Windows.Forms.MenuStrip mnuMultiRTB;
        private System.Windows.Forms.ToolStripMenuItem mniNew;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mniOpen;
        private System.Windows.Forms.ToolStripMenuItem mniSave;
        private System.Windows.Forms.ToolStripMenuItem mniSaveAs;
        private System.Windows.Forms.ToolStripMenuItem mnuFormat;
        private System.Windows.Forms.ToolStripMenuItem mniNumericList;
        private System.Windows.Forms.ToolStripMenuItem mniReopen;
        private System.Windows.Forms.ToolStripMenuItem mniUtf16;
        private System.Windows.Forms.ToolStripMenuItem mniUtf7;
        private System.Windows.Forms.ToolStripMenuItem mniUtf8;
        private System.Windows.Forms.ToolStripMenuItem mniUtf32;
        private System.Windows.Forms.ToolStripMenuItem mniBigEndian;
        private System.Windows.Forms.ToolStripMenuItem mniAnsi;
        private System.Windows.Forms.ToolStripMenuItem mniAscii;
        private System.Windows.Forms.ToolStripMenuItem mniAnsi1251;
        private System.Windows.Forms.ToolStripMenuItem mniUtf8Bom;
        private System.Windows.Forms.ToolStripMenuItem mniDefaultEncoding;
    }
}
