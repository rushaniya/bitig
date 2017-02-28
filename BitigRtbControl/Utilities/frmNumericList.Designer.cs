namespace Bitig.RtbControl.Utilities
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
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.nudIndent = new System.Windows.Forms.NumericUpDown();
            this.lblIndent = new System.Windows.Forms.Label();
            this.nudStart = new System.Windows.Forms.NumericUpDown();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlParams = new System.Windows.Forms.Panel();
            this.pnlNumericParams = new System.Windows.Forms.Panel();
            this.lblOther = new System.Windows.Forms.Label();
            this.tblOtherStyles = new System.Windows.Forms.TableLayoutPanel();
            this.pnlNoNumber = new System.Windows.Forms.Panel();
            this.lblNoNumber2 = new System.Windows.Forms.Label();
            this.pnlFirstExtra = new System.Windows.Forms.Panel();
            this.lblFirstExtra3 = new System.Windows.Forms.Label();
            this.lblFirstExtra2 = new System.Windows.Forms.Label();
            this.lblFirstExtra1 = new System.Windows.Forms.Label();
            this.pnlSecondExtra = new System.Windows.Forms.Panel();
            this.lblSecondExtra3 = new System.Windows.Forms.Label();
            this.lblSecondExtra2 = new System.Windows.Forms.Label();
            this.lblSecondExtra1 = new System.Windows.Forms.Label();
            this.pnlThirdExtra = new System.Windows.Forms.Panel();
            this.lblThirdExtra3 = new System.Windows.Forms.Label();
            this.lblThirdExtra2 = new System.Windows.Forms.Label();
            this.lblThirdExtra1 = new System.Windows.Forms.Label();
            this.tblCurrentStyles = new System.Windows.Forms.TableLayoutPanel();
            this.pnlNo = new System.Windows.Forms.Panel();
            this.lblNo = new System.Windows.Forms.Label();
            this.pnlBullet = new System.Windows.Forms.Panel();
            this.lblBullet3 = new System.Windows.Forms.Label();
            this.lblBullet2 = new System.Windows.Forms.Label();
            this.lblBullet1 = new System.Windows.Forms.Label();
            this.pnlArabic = new System.Windows.Forms.Panel();
            this.lblArabic3 = new System.Windows.Forms.Label();
            this.lblArabic2 = new System.Windows.Forms.Label();
            this.lblArabic1 = new System.Windows.Forms.Label();
            this.pnlLCLetter = new System.Windows.Forms.Panel();
            this.lblLCLetter3 = new System.Windows.Forms.Label();
            this.lblLCLetter2 = new System.Windows.Forms.Label();
            this.lblLCLetter1 = new System.Windows.Forms.Label();
            this.pnlUCLetter = new System.Windows.Forms.Panel();
            this.lblUCLetter3 = new System.Windows.Forms.Label();
            this.lblUCLetter2 = new System.Windows.Forms.Label();
            this.lblUCLetter1 = new System.Windows.Forms.Label();
            this.pnlLCRoman = new System.Windows.Forms.Panel();
            this.lblLCRoman3 = new System.Windows.Forms.Label();
            this.lblLCRoman2 = new System.Windows.Forms.Label();
            this.lblLCRoman1 = new System.Windows.Forms.Label();
            this.pnlUCRoman = new System.Windows.Forms.Panel();
            this.lblUCRoman3 = new System.Windows.Forms.Label();
            this.lblUCRoman2 = new System.Windows.Forms.Label();
            this.lblUCRoman1 = new System.Windows.Forms.Label();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudIndent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart)).BeginInit();
            this.pnlTop.SuspendLayout();
            this.pnlParams.SuspendLayout();
            this.pnlNumericParams.SuspendLayout();
            this.tblOtherStyles.SuspendLayout();
            this.pnlNoNumber.SuspendLayout();
            this.pnlFirstExtra.SuspendLayout();
            this.pnlSecondExtra.SuspendLayout();
            this.pnlThirdExtra.SuspendLayout();
            this.tblCurrentStyles.SuspendLayout();
            this.pnlNo.SuspendLayout();
            this.pnlBullet.SuspendLayout();
            this.pnlArabic.SuspendLayout();
            this.pnlLCLetter.SuspendLayout();
            this.pnlUCLetter.SuspendLayout();
            this.pnlLCRoman.SuspendLayout();
            this.pnlUCRoman.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(6, 8);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(54, 13);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Start with:";
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnOK);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 376);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(352, 44);
            this.pnlBottom.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(265, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 28);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.Enter += new System.EventHandler(this.NotPanel_Enter);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(178, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(81, 28);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.Enter += new System.EventHandler(this.NotPanel_Enter);
            // 
            // nudIndent
            // 
            this.nudIndent.DecimalPlaces = 1;
            this.nudIndent.Location = new System.Drawing.Point(81, 12);
            this.nudIndent.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudIndent.Name = "nudIndent";
            this.nudIndent.Size = new System.Drawing.Size(97, 20);
            this.nudIndent.TabIndex = 7;
            this.nudIndent.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudIndent.Enter += new System.EventHandler(this.NotPanel_Enter);
            // 
            // lblIndent
            // 
            this.lblIndent.AutoSize = true;
            this.lblIndent.Location = new System.Drawing.Point(6, 14);
            this.lblIndent.Name = "lblIndent";
            this.lblIndent.Size = new System.Drawing.Size(60, 13);
            this.lblIndent.TabIndex = 0;
            this.lblIndent.Text = "Indent, cm:";
            // 
            // nudStart
            // 
            this.nudStart.Location = new System.Drawing.Point(81, 6);
            this.nudStart.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudStart.Name = "nudStart";
            this.nudStart.Size = new System.Drawing.Size(58, 20);
            this.nudStart.TabIndex = 8;
            this.nudStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStart.Enter += new System.EventHandler(this.NotPanel_Enter);
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlParams);
            this.pnlTop.Controls.Add(this.tblCurrentStyles);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(352, 376);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlParams
            // 
            this.pnlParams.Controls.Add(this.nudIndent);
            this.pnlParams.Controls.Add(this.lblIndent);
            this.pnlParams.Controls.Add(this.pnlNumericParams);
            this.pnlParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParams.Location = new System.Drawing.Point(0, 175);
            this.pnlParams.Name = "pnlParams";
            this.pnlParams.Size = new System.Drawing.Size(352, 201);
            this.pnlParams.TabIndex = 1;
            this.pnlParams.TabStop = true;
            // 
            // pnlNumericParams
            // 
            this.pnlNumericParams.Controls.Add(this.nudStart);
            this.pnlNumericParams.Controls.Add(this.lblStart);
            this.pnlNumericParams.Controls.Add(this.lblOther);
            this.pnlNumericParams.Controls.Add(this.tblOtherStyles);
            this.pnlNumericParams.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlNumericParams.Location = new System.Drawing.Point(0, 38);
            this.pnlNumericParams.Name = "pnlNumericParams";
            this.pnlNumericParams.Size = new System.Drawing.Size(352, 163);
            this.pnlNumericParams.TabIndex = 0;
            this.pnlNumericParams.TabStop = true;
            // 
            // lblOther
            // 
            this.lblOther.AutoSize = true;
            this.lblOther.Location = new System.Drawing.Point(6, 35);
            this.lblOther.Name = "lblOther";
            this.lblOther.Size = new System.Drawing.Size(65, 13);
            this.lblOther.TabIndex = 0;
            this.lblOther.Text = "Other styles:";
            // 
            // tblOtherStyles
            // 
            this.tblOtherStyles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblOtherStyles.ColumnCount = 4;
            this.tblOtherStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblOtherStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblOtherStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblOtherStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblOtherStyles.Controls.Add(this.pnlNoNumber, 3, 0);
            this.tblOtherStyles.Controls.Add(this.pnlFirstExtra, 0, 0);
            this.tblOtherStyles.Controls.Add(this.pnlSecondExtra, 1, 0);
            this.tblOtherStyles.Controls.Add(this.pnlThirdExtra, 2, 0);
            this.tblOtherStyles.Location = new System.Drawing.Point(0, 60);
            this.tblOtherStyles.Name = "tblOtherStyles";
            this.tblOtherStyles.RowCount = 1;
            this.tblOtherStyles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblOtherStyles.Size = new System.Drawing.Size(352, 88);
            this.tblOtherStyles.TabIndex = 0;
            this.tblOtherStyles.TabStop = true;
            // 
            // pnlNoNumber
            // 
            this.pnlNoNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNoNumber.Controls.Add(this.lblNoNumber2);
            this.pnlNoNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNoNumber.Location = new System.Drawing.Point(267, 3);
            this.pnlNoNumber.Name = "pnlNoNumber";
            this.pnlNoNumber.Size = new System.Drawing.Size(82, 82);
            this.pnlNoNumber.TabIndex = 12;
            this.pnlNoNumber.TabStop = true;
            this.pnlNoNumber.Click += new System.EventHandler(this.NoNumber_Click);
            this.pnlNoNumber.Enter += new System.EventHandler(this.NoNumber_Click);
            // 
            // lblNoNumber2
            // 
            this.lblNoNumber2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNoNumber2.AutoSize = true;
            this.lblNoNumber2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNoNumber2.Location = new System.Drawing.Point(5, 30);
            this.lblNoNumber2.Name = "lblNoNumber2";
            this.lblNoNumber2.Size = new System.Drawing.Size(71, 16);
            this.lblNoNumber2.TabIndex = 4;
            this.lblNoNumber2.Text = "No marker";
            this.lblNoNumber2.Click += new System.EventHandler(this.NoNumber_Click);
            // 
            // pnlFirstExtra
            // 
            this.pnlFirstExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFirstExtra.Controls.Add(this.lblFirstExtra3);
            this.pnlFirstExtra.Controls.Add(this.lblFirstExtra2);
            this.pnlFirstExtra.Controls.Add(this.lblFirstExtra1);
            this.pnlFirstExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFirstExtra.Location = new System.Drawing.Point(3, 3);
            this.pnlFirstExtra.Name = "pnlFirstExtra";
            this.pnlFirstExtra.Size = new System.Drawing.Size(82, 82);
            this.pnlFirstExtra.TabIndex = 9;
            this.pnlFirstExtra.TabStop = true;
            this.pnlFirstExtra.Click += new System.EventHandler(this.Paren_Click);
            this.pnlFirstExtra.Enter += new System.EventHandler(this.Paren_Click);
            // 
            // lblFirstExtra3
            // 
            this.lblFirstExtra3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFirstExtra3.AutoSize = true;
            this.lblFirstExtra3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstExtra3.Location = new System.Drawing.Point(2, 53);
            this.lblFirstExtra3.Name = "lblFirstExtra3";
            this.lblFirstExtra3.Size = new System.Drawing.Size(72, 16);
            this.lblFirstExtra3.TabIndex = 2;
            this.lblFirstExtra3.Text = "3. _____";
            this.lblFirstExtra3.Click += new System.EventHandler(this.Paren_Click);
            // 
            // lblFirstExtra2
            // 
            this.lblFirstExtra2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFirstExtra2.AutoSize = true;
            this.lblFirstExtra2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstExtra2.Location = new System.Drawing.Point(2, 28);
            this.lblFirstExtra2.Name = "lblFirstExtra2";
            this.lblFirstExtra2.Size = new System.Drawing.Size(72, 16);
            this.lblFirstExtra2.TabIndex = 1;
            this.lblFirstExtra2.Text = "2. _____";
            this.lblFirstExtra2.Click += new System.EventHandler(this.Paren_Click);
            // 
            // lblFirstExtra1
            // 
            this.lblFirstExtra1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblFirstExtra1.AutoSize = true;
            this.lblFirstExtra1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFirstExtra1.Location = new System.Drawing.Point(2, 3);
            this.lblFirstExtra1.Name = "lblFirstExtra1";
            this.lblFirstExtra1.Size = new System.Drawing.Size(72, 16);
            this.lblFirstExtra1.TabIndex = 0;
            this.lblFirstExtra1.Text = "1. _____";
            this.lblFirstExtra1.Click += new System.EventHandler(this.Paren_Click);
            // 
            // pnlSecondExtra
            // 
            this.pnlSecondExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSecondExtra.Controls.Add(this.lblSecondExtra3);
            this.pnlSecondExtra.Controls.Add(this.lblSecondExtra2);
            this.pnlSecondExtra.Controls.Add(this.lblSecondExtra1);
            this.pnlSecondExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSecondExtra.Location = new System.Drawing.Point(91, 3);
            this.pnlSecondExtra.Name = "pnlSecondExtra";
            this.pnlSecondExtra.Size = new System.Drawing.Size(82, 82);
            this.pnlSecondExtra.TabIndex = 10;
            this.pnlSecondExtra.TabStop = true;
            this.pnlSecondExtra.Click += new System.EventHandler(this.Parens_Click);
            this.pnlSecondExtra.Enter += new System.EventHandler(this.Parens_Click);
            // 
            // lblSecondExtra3
            // 
            this.lblSecondExtra3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSecondExtra3.AutoSize = true;
            this.lblSecondExtra3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondExtra3.Location = new System.Drawing.Point(2, 53);
            this.lblSecondExtra3.Name = "lblSecondExtra3";
            this.lblSecondExtra3.Size = new System.Drawing.Size(72, 16);
            this.lblSecondExtra3.TabIndex = 2;
            this.lblSecondExtra3.Text = "(3) ____";
            this.lblSecondExtra3.Click += new System.EventHandler(this.Parens_Click);
            // 
            // lblSecondExtra2
            // 
            this.lblSecondExtra2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSecondExtra2.AutoSize = true;
            this.lblSecondExtra2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecondExtra2.Location = new System.Drawing.Point(2, 28);
            this.lblSecondExtra2.Name = "lblSecondExtra2";
            this.lblSecondExtra2.Size = new System.Drawing.Size(72, 16);
            this.lblSecondExtra2.TabIndex = 1;
            this.lblSecondExtra2.Text = "(2) ____";
            this.lblSecondExtra2.Click += new System.EventHandler(this.Parens_Click);
            // 
            // lblSecondExtra1
            // 
            this.lblSecondExtra1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSecondExtra1.AutoSize = true;
            this.lblSecondExtra1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSecondExtra1.Location = new System.Drawing.Point(2, 3);
            this.lblSecondExtra1.Name = "lblSecondExtra1";
            this.lblSecondExtra1.Size = new System.Drawing.Size(72, 16);
            this.lblSecondExtra1.TabIndex = 0;
            this.lblSecondExtra1.Text = "(1) ____";
            // 
            // pnlThirdExtra
            // 
            this.pnlThirdExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThirdExtra.Controls.Add(this.lblThirdExtra3);
            this.pnlThirdExtra.Controls.Add(this.lblThirdExtra2);
            this.pnlThirdExtra.Controls.Add(this.lblThirdExtra1);
            this.pnlThirdExtra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlThirdExtra.Location = new System.Drawing.Point(179, 3);
            this.pnlThirdExtra.Name = "pnlThirdExtra";
            this.pnlThirdExtra.Size = new System.Drawing.Size(82, 82);
            this.pnlThirdExtra.TabIndex = 11;
            this.pnlThirdExtra.TabStop = true;
            this.pnlThirdExtra.Click += new System.EventHandler(this.Plain_Click);
            this.pnlThirdExtra.Enter += new System.EventHandler(this.Plain_Click);
            // 
            // lblThirdExtra3
            // 
            this.lblThirdExtra3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblThirdExtra3.AutoSize = true;
            this.lblThirdExtra3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThirdExtra3.Location = new System.Drawing.Point(2, 53);
            this.lblThirdExtra3.Name = "lblThirdExtra3";
            this.lblThirdExtra3.Size = new System.Drawing.Size(72, 16);
            this.lblThirdExtra3.TabIndex = 2;
            this.lblThirdExtra3.Text = "3 ______";
            this.lblThirdExtra3.Click += new System.EventHandler(this.Plain_Click);
            // 
            // lblThirdExtra2
            // 
            this.lblThirdExtra2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblThirdExtra2.AutoSize = true;
            this.lblThirdExtra2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThirdExtra2.Location = new System.Drawing.Point(2, 28);
            this.lblThirdExtra2.Name = "lblThirdExtra2";
            this.lblThirdExtra2.Size = new System.Drawing.Size(72, 16);
            this.lblThirdExtra2.TabIndex = 1;
            this.lblThirdExtra2.Text = "2 ______";
            this.lblThirdExtra2.Click += new System.EventHandler(this.Plain_Click);
            // 
            // lblThirdExtra1
            // 
            this.lblThirdExtra1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblThirdExtra1.AutoSize = true;
            this.lblThirdExtra1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblThirdExtra1.Location = new System.Drawing.Point(2, 3);
            this.lblThirdExtra1.Name = "lblThirdExtra1";
            this.lblThirdExtra1.Size = new System.Drawing.Size(72, 16);
            this.lblThirdExtra1.TabIndex = 0;
            this.lblThirdExtra1.Text = "1 ______";
            this.lblThirdExtra1.Click += new System.EventHandler(this.Plain_Click);
            // 
            // tblCurrentStyles
            // 
            this.tblCurrentStyles.ColumnCount = 4;
            this.tblCurrentStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCurrentStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCurrentStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCurrentStyles.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tblCurrentStyles.Controls.Add(this.pnlNo, 2, 1);
            this.tblCurrentStyles.Controls.Add(this.pnlBullet, 0, 0);
            this.tblCurrentStyles.Controls.Add(this.pnlArabic, 1, 0);
            this.tblCurrentStyles.Controls.Add(this.pnlLCLetter, 2, 0);
            this.tblCurrentStyles.Controls.Add(this.pnlUCLetter, 3, 0);
            this.tblCurrentStyles.Controls.Add(this.pnlLCRoman, 0, 1);
            this.tblCurrentStyles.Controls.Add(this.pnlUCRoman, 1, 1);
            this.tblCurrentStyles.Dock = System.Windows.Forms.DockStyle.Top;
            this.tblCurrentStyles.Location = new System.Drawing.Point(0, 0);
            this.tblCurrentStyles.Name = "tblCurrentStyles";
            this.tblCurrentStyles.RowCount = 2;
            this.tblCurrentStyles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCurrentStyles.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCurrentStyles.Size = new System.Drawing.Size(352, 175);
            this.tblCurrentStyles.TabIndex = 0;
            this.tblCurrentStyles.TabStop = true;
            // 
            // pnlNo
            // 
            this.pnlNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNo.Controls.Add(this.lblNo);
            this.pnlNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlNo.Location = new System.Drawing.Point(179, 90);
            this.pnlNo.Name = "pnlNo";
            this.pnlNo.Size = new System.Drawing.Size(82, 82);
            this.pnlNo.TabIndex = 6;
            this.pnlNo.TabStop = true;
            this.pnlNo.Click += new System.EventHandler(this.No_Click);
            this.pnlNo.Enter += new System.EventHandler(this.No_Click);
            // 
            // lblNo
            // 
            this.lblNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNo.AutoSize = true;
            this.lblNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblNo.Location = new System.Drawing.Point(27, 31);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(26, 16);
            this.lblNo.TabIndex = 1;
            this.lblNo.Text = "No";
            this.lblNo.Click += new System.EventHandler(this.No_Click);
            // 
            // pnlBullet
            // 
            this.pnlBullet.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBullet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBullet.Controls.Add(this.lblBullet3);
            this.pnlBullet.Controls.Add(this.lblBullet2);
            this.pnlBullet.Controls.Add(this.lblBullet1);
            this.pnlBullet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBullet.Location = new System.Drawing.Point(3, 3);
            this.pnlBullet.Name = "pnlBullet";
            this.pnlBullet.Size = new System.Drawing.Size(82, 81);
            this.pnlBullet.TabIndex = 0;
            this.pnlBullet.TabStop = true;
            this.pnlBullet.Click += new System.EventHandler(this.Bullet_Click);
            this.pnlBullet.Enter += new System.EventHandler(this.Bullet_Click);
            // 
            // lblBullet3
            // 
            this.lblBullet3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBullet3.AutoSize = true;
            this.lblBullet3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBullet3.Location = new System.Drawing.Point(2, 53);
            this.lblBullet3.Name = "lblBullet3";
            this.lblBullet3.Size = new System.Drawing.Size(72, 16);
            this.lblBullet3.TabIndex = 2;
            this.lblBullet3.Text = "• ______";
            this.lblBullet3.Click += new System.EventHandler(this.Bullet_Click);
            // 
            // lblBullet2
            // 
            this.lblBullet2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBullet2.AutoSize = true;
            this.lblBullet2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBullet2.Location = new System.Drawing.Point(2, 28);
            this.lblBullet2.Name = "lblBullet2";
            this.lblBullet2.Size = new System.Drawing.Size(72, 16);
            this.lblBullet2.TabIndex = 1;
            this.lblBullet2.Text = "• ______";
            this.lblBullet2.Click += new System.EventHandler(this.Bullet_Click);
            // 
            // lblBullet1
            // 
            this.lblBullet1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblBullet1.AutoSize = true;
            this.lblBullet1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblBullet1.Location = new System.Drawing.Point(2, 3);
            this.lblBullet1.Name = "lblBullet1";
            this.lblBullet1.Size = new System.Drawing.Size(72, 16);
            this.lblBullet1.TabIndex = 0;
            this.lblBullet1.Text = "• ______";
            this.lblBullet1.Click += new System.EventHandler(this.Bullet_Click);
            // 
            // pnlArabic
            // 
            this.pnlArabic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlArabic.Controls.Add(this.lblArabic3);
            this.pnlArabic.Controls.Add(this.lblArabic2);
            this.pnlArabic.Controls.Add(this.lblArabic1);
            this.pnlArabic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlArabic.Location = new System.Drawing.Point(91, 3);
            this.pnlArabic.Name = "pnlArabic";
            this.pnlArabic.Size = new System.Drawing.Size(82, 81);
            this.pnlArabic.TabIndex = 1;
            this.pnlArabic.TabStop = true;
            this.pnlArabic.Click += new System.EventHandler(this.Arabic_Click);
            this.pnlArabic.Enter += new System.EventHandler(this.Arabic_Click);
            // 
            // lblArabic3
            // 
            this.lblArabic3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblArabic3.AutoSize = true;
            this.lblArabic3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArabic3.Location = new System.Drawing.Point(2, 53);
            this.lblArabic3.Name = "lblArabic3";
            this.lblArabic3.Size = new System.Drawing.Size(72, 16);
            this.lblArabic3.TabIndex = 2;
            this.lblArabic3.Text = "3) _____";
            this.lblArabic3.Click += new System.EventHandler(this.Arabic_Click);
            // 
            // lblArabic2
            // 
            this.lblArabic2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblArabic2.AutoSize = true;
            this.lblArabic2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArabic2.Location = new System.Drawing.Point(2, 28);
            this.lblArabic2.Name = "lblArabic2";
            this.lblArabic2.Size = new System.Drawing.Size(72, 16);
            this.lblArabic2.TabIndex = 1;
            this.lblArabic2.Text = "2) _____";
            this.lblArabic2.Click += new System.EventHandler(this.Arabic_Click);
            // 
            // lblArabic1
            // 
            this.lblArabic1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblArabic1.AutoSize = true;
            this.lblArabic1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblArabic1.Location = new System.Drawing.Point(2, 3);
            this.lblArabic1.Name = "lblArabic1";
            this.lblArabic1.Size = new System.Drawing.Size(72, 16);
            this.lblArabic1.TabIndex = 0;
            this.lblArabic1.Text = "1) _____";
            this.lblArabic1.Click += new System.EventHandler(this.Arabic_Click);
            // 
            // pnlLCLetter
            // 
            this.pnlLCLetter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLCLetter.Controls.Add(this.lblLCLetter3);
            this.pnlLCLetter.Controls.Add(this.lblLCLetter2);
            this.pnlLCLetter.Controls.Add(this.lblLCLetter1);
            this.pnlLCLetter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLCLetter.Location = new System.Drawing.Point(179, 3);
            this.pnlLCLetter.Name = "pnlLCLetter";
            this.pnlLCLetter.Size = new System.Drawing.Size(82, 81);
            this.pnlLCLetter.TabIndex = 2;
            this.pnlLCLetter.TabStop = true;
            this.pnlLCLetter.Click += new System.EventHandler(this.LCLetter_Click);
            this.pnlLCLetter.Enter += new System.EventHandler(this.LCLetter_Click);
            // 
            // lblLCLetter3
            // 
            this.lblLCLetter3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLCLetter3.AutoSize = true;
            this.lblLCLetter3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCLetter3.Location = new System.Drawing.Point(2, 53);
            this.lblLCLetter3.Name = "lblLCLetter3";
            this.lblLCLetter3.Size = new System.Drawing.Size(72, 16);
            this.lblLCLetter3.TabIndex = 2;
            this.lblLCLetter3.Text = "c) _____";
            this.lblLCLetter3.Click += new System.EventHandler(this.LCLetter_Click);
            // 
            // lblLCLetter2
            // 
            this.lblLCLetter2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLCLetter2.AutoSize = true;
            this.lblLCLetter2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCLetter2.Location = new System.Drawing.Point(2, 28);
            this.lblLCLetter2.Name = "lblLCLetter2";
            this.lblLCLetter2.Size = new System.Drawing.Size(72, 16);
            this.lblLCLetter2.TabIndex = 1;
            this.lblLCLetter2.Text = "b) _____";
            this.lblLCLetter2.Click += new System.EventHandler(this.LCLetter_Click);
            // 
            // lblLCLetter1
            // 
            this.lblLCLetter1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLCLetter1.AutoSize = true;
            this.lblLCLetter1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCLetter1.Location = new System.Drawing.Point(2, 3);
            this.lblLCLetter1.Name = "lblLCLetter1";
            this.lblLCLetter1.Size = new System.Drawing.Size(72, 16);
            this.lblLCLetter1.TabIndex = 0;
            this.lblLCLetter1.Text = "a) _____";
            this.lblLCLetter1.Click += new System.EventHandler(this.LCLetter_Click);
            // 
            // pnlUCLetter
            // 
            this.pnlUCLetter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUCLetter.Controls.Add(this.lblUCLetter3);
            this.pnlUCLetter.Controls.Add(this.lblUCLetter2);
            this.pnlUCLetter.Controls.Add(this.lblUCLetter1);
            this.pnlUCLetter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUCLetter.Location = new System.Drawing.Point(267, 3);
            this.pnlUCLetter.Name = "pnlUCLetter";
            this.pnlUCLetter.Size = new System.Drawing.Size(82, 81);
            this.pnlUCLetter.TabIndex = 3;
            this.pnlUCLetter.TabStop = true;
            this.pnlUCLetter.Click += new System.EventHandler(this.UCLetter_Click);
            this.pnlUCLetter.Enter += new System.EventHandler(this.UCLetter_Click);
            // 
            // lblUCLetter3
            // 
            this.lblUCLetter3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUCLetter3.AutoSize = true;
            this.lblUCLetter3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCLetter3.Location = new System.Drawing.Point(2, 53);
            this.lblUCLetter3.Name = "lblUCLetter3";
            this.lblUCLetter3.Size = new System.Drawing.Size(72, 16);
            this.lblUCLetter3.TabIndex = 2;
            this.lblUCLetter3.Text = "C) _____";
            this.lblUCLetter3.Click += new System.EventHandler(this.UCLetter_Click);
            // 
            // lblUCLetter2
            // 
            this.lblUCLetter2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUCLetter2.AutoSize = true;
            this.lblUCLetter2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCLetter2.Location = new System.Drawing.Point(2, 28);
            this.lblUCLetter2.Name = "lblUCLetter2";
            this.lblUCLetter2.Size = new System.Drawing.Size(72, 16);
            this.lblUCLetter2.TabIndex = 1;
            this.lblUCLetter2.Text = "B) _____";
            this.lblUCLetter2.Click += new System.EventHandler(this.UCLetter_Click);
            // 
            // lblUCLetter1
            // 
            this.lblUCLetter1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUCLetter1.AutoSize = true;
            this.lblUCLetter1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCLetter1.Location = new System.Drawing.Point(2, 3);
            this.lblUCLetter1.Name = "lblUCLetter1";
            this.lblUCLetter1.Size = new System.Drawing.Size(72, 16);
            this.lblUCLetter1.TabIndex = 0;
            this.lblUCLetter1.Text = "A) _____";
            this.lblUCLetter1.Click += new System.EventHandler(this.UCLetter_Click);
            // 
            // pnlLCRoman
            // 
            this.pnlLCRoman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlLCRoman.Controls.Add(this.lblLCRoman3);
            this.pnlLCRoman.Controls.Add(this.lblLCRoman2);
            this.pnlLCRoman.Controls.Add(this.lblLCRoman1);
            this.pnlLCRoman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLCRoman.Location = new System.Drawing.Point(3, 90);
            this.pnlLCRoman.Name = "pnlLCRoman";
            this.pnlLCRoman.Size = new System.Drawing.Size(82, 82);
            this.pnlLCRoman.TabIndex = 4;
            this.pnlLCRoman.TabStop = true;
            this.pnlLCRoman.Click += new System.EventHandler(this.LCRoman_Click);
            this.pnlLCRoman.Enter += new System.EventHandler(this.LCRoman_Click);
            // 
            // lblLCRoman3
            // 
            this.lblLCRoman3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLCRoman3.AutoSize = true;
            this.lblLCRoman3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCRoman3.Location = new System.Drawing.Point(2, 53);
            this.lblLCRoman3.Name = "lblLCRoman3";
            this.lblLCRoman3.Size = new System.Drawing.Size(72, 16);
            this.lblLCRoman3.TabIndex = 2;
            this.lblLCRoman3.Text = "iii) ___";
            this.lblLCRoman3.Click += new System.EventHandler(this.LCRoman_Click);
            // 
            // lblLCRoman2
            // 
            this.lblLCRoman2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLCRoman2.AutoSize = true;
            this.lblLCRoman2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCRoman2.Location = new System.Drawing.Point(2, 28);
            this.lblLCRoman2.Name = "lblLCRoman2";
            this.lblLCRoman2.Size = new System.Drawing.Size(72, 16);
            this.lblLCRoman2.TabIndex = 1;
            this.lblLCRoman2.Text = "ii) ____";
            this.lblLCRoman2.Click += new System.EventHandler(this.LCRoman_Click);
            // 
            // lblLCRoman1
            // 
            this.lblLCRoman1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLCRoman1.AutoSize = true;
            this.lblLCRoman1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLCRoman1.Location = new System.Drawing.Point(2, 3);
            this.lblLCRoman1.Name = "lblLCRoman1";
            this.lblLCRoman1.Size = new System.Drawing.Size(72, 16);
            this.lblLCRoman1.TabIndex = 0;
            this.lblLCRoman1.Text = "i) _____";
            this.lblLCRoman1.Click += new System.EventHandler(this.LCRoman_Click);
            // 
            // pnlUCRoman
            // 
            this.pnlUCRoman.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUCRoman.Controls.Add(this.lblUCRoman3);
            this.pnlUCRoman.Controls.Add(this.lblUCRoman2);
            this.pnlUCRoman.Controls.Add(this.lblUCRoman1);
            this.pnlUCRoman.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlUCRoman.Location = new System.Drawing.Point(91, 90);
            this.pnlUCRoman.Name = "pnlUCRoman";
            this.pnlUCRoman.Size = new System.Drawing.Size(82, 82);
            this.pnlUCRoman.TabIndex = 5;
            this.pnlUCRoman.TabStop = true;
            this.pnlUCRoman.Click += new System.EventHandler(this.UCRoman_Click);
            this.pnlUCRoman.Enter += new System.EventHandler(this.UCRoman_Click);
            // 
            // lblUCRoman3
            // 
            this.lblUCRoman3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUCRoman3.AutoSize = true;
            this.lblUCRoman3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCRoman3.Location = new System.Drawing.Point(2, 53);
            this.lblUCRoman3.Name = "lblUCRoman3";
            this.lblUCRoman3.Size = new System.Drawing.Size(72, 16);
            this.lblUCRoman3.TabIndex = 2;
            this.lblUCRoman3.Text = "III) ___";
            this.lblUCRoman3.Click += new System.EventHandler(this.UCRoman_Click);
            // 
            // lblUCRoman2
            // 
            this.lblUCRoman2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUCRoman2.AutoSize = true;
            this.lblUCRoman2.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCRoman2.Location = new System.Drawing.Point(2, 28);
            this.lblUCRoman2.Name = "lblUCRoman2";
            this.lblUCRoman2.Size = new System.Drawing.Size(72, 16);
            this.lblUCRoman2.TabIndex = 1;
            this.lblUCRoman2.Text = "II) ____";
            this.lblUCRoman2.Click += new System.EventHandler(this.UCRoman_Click);
            // 
            // lblUCRoman1
            // 
            this.lblUCRoman1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblUCRoman1.AutoSize = true;
            this.lblUCRoman1.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUCRoman1.Location = new System.Drawing.Point(2, 3);
            this.lblUCRoman1.Name = "lblUCRoman1";
            this.lblUCRoman1.Size = new System.Drawing.Size(72, 16);
            this.lblUCRoman1.TabIndex = 0;
            this.lblUCRoman1.Text = "I) _____";
            this.lblUCRoman1.Click += new System.EventHandler(this.UCRoman_Click);
            // 
            // frmNumericList
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(352, 420);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNumericList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Numbering/bullets";
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudIndent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStart)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlParams.ResumeLayout(false);
            this.pnlParams.PerformLayout();
            this.pnlNumericParams.ResumeLayout(false);
            this.pnlNumericParams.PerformLayout();
            this.tblOtherStyles.ResumeLayout(false);
            this.pnlNoNumber.ResumeLayout(false);
            this.pnlNoNumber.PerformLayout();
            this.pnlFirstExtra.ResumeLayout(false);
            this.pnlFirstExtra.PerformLayout();
            this.pnlSecondExtra.ResumeLayout(false);
            this.pnlSecondExtra.PerformLayout();
            this.pnlThirdExtra.ResumeLayout(false);
            this.pnlThirdExtra.PerformLayout();
            this.tblCurrentStyles.ResumeLayout(false);
            this.pnlNo.ResumeLayout(false);
            this.pnlNo.PerformLayout();
            this.pnlBullet.ResumeLayout(false);
            this.pnlBullet.PerformLayout();
            this.pnlArabic.ResumeLayout(false);
            this.pnlArabic.PerformLayout();
            this.pnlLCLetter.ResumeLayout(false);
            this.pnlLCLetter.PerformLayout();
            this.pnlUCLetter.ResumeLayout(false);
            this.pnlUCLetter.PerformLayout();
            this.pnlLCRoman.ResumeLayout(false);
            this.pnlLCRoman.PerformLayout();
            this.pnlUCRoman.ResumeLayout(false);
            this.pnlUCRoman.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblIndent;
        private System.Windows.Forms.NumericUpDown nudStart;
        private System.Windows.Forms.NumericUpDown nudIndent;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.TableLayoutPanel tblCurrentStyles;
        private System.Windows.Forms.Panel pnlBullet;
        private System.Windows.Forms.Label lblBullet1;
        private System.Windows.Forms.Panel pnlNo;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Panel pnlArabic;
        private System.Windows.Forms.Panel pnlUCLetter;
        private System.Windows.Forms.Label lblUCLetter3;
        private System.Windows.Forms.Label lblUCLetter2;
        private System.Windows.Forms.Label lblUCLetter1;
        private System.Windows.Forms.Label lblArabic1;
        private System.Windows.Forms.Panel pnlParams;
        private System.Windows.Forms.TableLayoutPanel tblOtherStyles;
        private System.Windows.Forms.Label lblOther;
        private System.Windows.Forms.Label lblArabic3;
        private System.Windows.Forms.Label lblArabic2;
        private System.Windows.Forms.Label lblBullet3;
        private System.Windows.Forms.Label lblBullet2;
        private System.Windows.Forms.Panel pnlLCLetter;
        private System.Windows.Forms.Label lblLCLetter3;
        private System.Windows.Forms.Label lblLCLetter2;
        private System.Windows.Forms.Label lblLCLetter1;
        private System.Windows.Forms.Panel pnlLCRoman;
        private System.Windows.Forms.Label lblLCRoman3;
        private System.Windows.Forms.Label lblLCRoman2;
        private System.Windows.Forms.Label lblLCRoman1;
        private System.Windows.Forms.Panel pnlUCRoman;
        private System.Windows.Forms.Label lblUCRoman3;
        private System.Windows.Forms.Label lblUCRoman2;
        private System.Windows.Forms.Label lblUCRoman1;
        private System.Windows.Forms.Panel pnlFirstExtra;
        private System.Windows.Forms.Label lblFirstExtra3;
        private System.Windows.Forms.Label lblFirstExtra2;
        private System.Windows.Forms.Label lblFirstExtra1;
        private System.Windows.Forms.Panel pnlSecondExtra;
        private System.Windows.Forms.Label lblSecondExtra3;
        private System.Windows.Forms.Label lblSecondExtra2;
        private System.Windows.Forms.Label lblSecondExtra1;
        private System.Windows.Forms.Panel pnlThirdExtra;
        private System.Windows.Forms.Label lblThirdExtra3;
        private System.Windows.Forms.Label lblThirdExtra2;
        private System.Windows.Forms.Label lblThirdExtra1;
        private System.Windows.Forms.Panel pnlNumericParams;
        private System.Windows.Forms.Panel pnlNoNumber;
        private System.Windows.Forms.Label lblNoNumber2;
    }
}