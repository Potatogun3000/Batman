namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    partial class frmAwardHistory
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
            this.lvwAwardHistory = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // lvwAwardHistory
            // 
            this.lvwAwardHistory.Location = new System.Drawing.Point(12, 31);
            this.lvwAwardHistory.Name = "lvwAwardHistory";
            this.lvwAwardHistory.Size = new System.Drawing.Size(795, 475);
            this.lvwAwardHistory.TabIndex = 0;
            this.lvwAwardHistory.UseCompatibleStateImageBehavior = false;
            // 
            // awardHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 518);
            this.Controls.Add(this.lvwAwardHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "awardHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Award History";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwAwardHistory;
    }
}