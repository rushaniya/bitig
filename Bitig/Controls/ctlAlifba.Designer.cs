namespace Bitig.UI.Controls
{
    partial class ctlAlifba
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
            this.tlsAlifba = new System.Windows.Forms.ToolStrip();
            this.btnCapitalize = new System.Windows.Forms.ToolStripButton();
            this.tlsAlifba.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlsAlifba
            // 
            this.tlsAlifba.BackColor = System.Drawing.SystemColors.Window;
            this.tlsAlifba.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlsAlifba.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCapitalize});
            this.tlsAlifba.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.tlsAlifba.Location = new System.Drawing.Point(0, 0);
            this.tlsAlifba.Name = "tlsAlifba";
            this.tlsAlifba.Size = new System.Drawing.Size(527, 39);
            this.tlsAlifba.TabIndex = 3;
            this.tlsAlifba.Text = "Alifba";
            // 
            // btnCapitalize
            // 
            this.btnCapitalize.CheckOnClick = true;
            this.btnCapitalize.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCapitalize.DoubleClickEnabled = true;
            this.btnCapitalize.Image = global::Bitig.UI.Properties.Resources.arrow_up;
            this.btnCapitalize.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnCapitalize.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCapitalize.Name = "btnCapitalize";
            this.btnCapitalize.Size = new System.Drawing.Size(36, 36);
            this.btnCapitalize.Text = "toolStripButton1";
            this.btnCapitalize.Visible = false;
            this.btnCapitalize.CheckedChanged += new System.EventHandler(this.btnCapitalize_CheckedChanged);
            this.btnCapitalize.DoubleClick += new System.EventHandler(this.btnCapitalize_DoubleClick);
            // 
            // ctlAlifba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tlsAlifba);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "ctlAlifba";
            this.Size = new System.Drawing.Size(527, 40);
            this.tlsAlifba.ResumeLayout(false);
            this.tlsAlifba.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tlsAlifba;
        private System.Windows.Forms.ToolStripButton btnCapitalize;


    }
}
