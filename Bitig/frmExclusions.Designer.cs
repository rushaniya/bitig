namespace Bitig.UI
{
    partial class frmExclusions
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
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mainDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.directionIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matchCaseDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.matchBeginningDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.matchMiddleDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlButtons
            // 
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(0, 308);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(524, 100);
            this.pnlButtons.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.directionIDDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.matchCaseDataGridViewCheckBoxColumn,
            this.matchBeginningDataGridViewCheckBoxColumn,
            this.matchMiddleDataGridViewCheckBoxColumn});
            this.dataGridView1.DataSource = this.mainDataSetBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(524, 123);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellParsing += new System.Windows.Forms.DataGridViewCellParsingEventHandler(this.dataGridView1_CellParsing);
            this.dataGridView1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.dataGridView1.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridView1_RowsAdded);
            // 
            // mainDataSetBindingSource
            // 
            this.mainDataSetBindingSource.DataSource = typeof(Bitig.Logic.Model.Exclusion);
            // 
            // directionIDDataGridViewTextBoxColumn
            // 
            this.directionIDDataGridViewTextBoxColumn.DataPropertyName = "DirectionID";
            this.directionIDDataGridViewTextBoxColumn.HeaderText = "DirectionID";
            this.directionIDDataGridViewTextBoxColumn.Name = "directionIDDataGridViewTextBoxColumn";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SourceWord";
            this.dataGridViewTextBoxColumn1.HeaderText = "SourceWord";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TargetWord";
            this.dataGridViewTextBoxColumn2.HeaderText = "TargetWord";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // matchCaseDataGridViewCheckBoxColumn
            // 
            this.matchCaseDataGridViewCheckBoxColumn.DataPropertyName = "MatchCase";
            this.matchCaseDataGridViewCheckBoxColumn.HeaderText = "MatchCase";
            this.matchCaseDataGridViewCheckBoxColumn.Name = "matchCaseDataGridViewCheckBoxColumn";
            // 
            // matchBeginningDataGridViewCheckBoxColumn
            // 
            this.matchBeginningDataGridViewCheckBoxColumn.DataPropertyName = "MatchBeginning";
            this.matchBeginningDataGridViewCheckBoxColumn.HeaderText = "MatchBeginning";
            this.matchBeginningDataGridViewCheckBoxColumn.Name = "matchBeginningDataGridViewCheckBoxColumn";
            // 
            // matchMiddleDataGridViewCheckBoxColumn
            // 
            this.matchMiddleDataGridViewCheckBoxColumn.DataPropertyName = "MatchMiddle";
            this.matchMiddleDataGridViewCheckBoxColumn.HeaderText = "MatchMiddle";
            this.matchMiddleDataGridViewCheckBoxColumn.Name = "matchMiddleDataGridViewCheckBoxColumn";
            // 
            // frmExclusions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(524, 408);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pnlButtons);
            this.Name = "frmExclusions";
            this.Text = "frmExclusions";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmExclusions_FormClosing);
            this.Load += new System.EventHandler(this.frmExclusions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource mainDataSetBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn exclusionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceWordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetWordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDirectionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn directionIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn matchCaseDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn matchBeginningDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn matchMiddleDataGridViewCheckBoxColumn;
    }
}