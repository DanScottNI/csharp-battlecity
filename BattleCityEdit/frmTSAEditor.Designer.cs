namespace BattleCityEdit
{
    partial class frmTSAEditor
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
            this.picPatternTable = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picPatternTable)).BeginInit();
            this.SuspendLayout();
            // 
            // picPatternTable
            // 
            this.picPatternTable.Location = new System.Drawing.Point(0, 0);
            this.picPatternTable.Name = "picPatternTable";
            this.picPatternTable.Size = new System.Drawing.Size(256, 256);
            this.picPatternTable.TabIndex = 0;
            this.picPatternTable.TabStop = false;
            this.picPatternTable.Paint += new System.Windows.Forms.PaintEventHandler(this.picPatternTable_Paint);
            this.picPatternTable.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picPatternTable_MouseUp);
            // 
            // frmTSAEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 256);
            this.Controls.Add(this.picPatternTable);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTSAEditor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TSA Editor";
            this.Load += new System.EventHandler(this.frmTSAEditor_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmTSAEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picPatternTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPatternTable;
    }
}