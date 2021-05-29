namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    partial class frmMatchList
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
            this.lvwMatchList = new System.Windows.Forms.ListView();
            this.btnGameSchedule = new System.Windows.Forms.Button();
            this.cmbTournamentYear = new System.Windows.Forms.ComboBox();
            this.btnPrintScoreSheet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRecordResults = new System.Windows.Forms.Button();
            this.btnViewResult = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwMatchList
            // 
            this.lvwMatchList.Location = new System.Drawing.Point(12, 49);
            this.lvwMatchList.Name = "lvwMatchList";
            this.lvwMatchList.Size = new System.Drawing.Size(875, 390);
            this.lvwMatchList.TabIndex = 0;
            this.lvwMatchList.UseCompatibleStateImageBehavior = false;
            // 
            // btnGameSchedule
            // 
            this.btnGameSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnGameSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGameSchedule.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGameSchedule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnGameSchedule.Location = new System.Drawing.Point(742, 445);
            this.btnGameSchedule.Name = "btnGameSchedule";
            this.btnGameSchedule.Size = new System.Drawing.Size(145, 57);
            this.btnGameSchedule.TabIndex = 40;
            this.btnGameSchedule.Text = "Game Schedule";
            this.btnGameSchedule.UseVisualStyleBackColor = false;
            this.btnGameSchedule.Click += new System.EventHandler(this.btnGameSchedule_Click);
            // 
            // cmbTournamentYear
            // 
            this.cmbTournamentYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTournamentYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbTournamentYear.FormattingEnabled = true;
            this.cmbTournamentYear.Location = new System.Drawing.Point(50, 7);
            this.cmbTournamentYear.Name = "cmbTournamentYear";
            this.cmbTournamentYear.Size = new System.Drawing.Size(155, 32);
            this.cmbTournamentYear.TabIndex = 42;
            this.cmbTournamentYear.SelectedIndexChanged += new System.EventHandler(this.cmbTournamentYear_SelectedIndexChanged);
            // 
            // btnPrintScoreSheet
            // 
            this.btnPrintScoreSheet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnPrintScoreSheet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrintScoreSheet.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintScoreSheet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnPrintScoreSheet.Location = new System.Drawing.Point(592, 445);
            this.btnPrintScoreSheet.Name = "btnPrintScoreSheet";
            this.btnPrintScoreSheet.Size = new System.Drawing.Size(144, 57);
            this.btnPrintScoreSheet.TabIndex = 43;
            this.btnPrintScoreSheet.Text = "Print Score Sheets";
            this.btnPrintScoreSheet.UseVisualStyleBackColor = false;
            this.btnPrintScoreSheet.Click += new System.EventHandler(this.btnPrintScoreSheet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Year:";
            // 
            // btnRecordResults
            // 
            this.btnRecordResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnRecordResults.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRecordResults.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecordResults.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnRecordResults.Location = new System.Drawing.Point(442, 445);
            this.btnRecordResults.Name = "btnRecordResults";
            this.btnRecordResults.Size = new System.Drawing.Size(144, 57);
            this.btnRecordResults.TabIndex = 45;
            this.btnRecordResults.Text = "Record Results";
            this.btnRecordResults.UseVisualStyleBackColor = false;
            this.btnRecordResults.Click += new System.EventHandler(this.btnRecordResults_Click);
            // 
            // btnViewResult
            // 
            this.btnViewResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnViewResult.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewResult.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnViewResult.Location = new System.Drawing.Point(292, 445);
            this.btnViewResult.Name = "btnViewResult";
            this.btnViewResult.Size = new System.Drawing.Size(144, 57);
            this.btnViewResult.TabIndex = 46;
            this.btnViewResult.Text = "View Result";
            this.btnViewResult.UseVisualStyleBackColor = false;
            this.btnViewResult.Click += new System.EventHandler(this.btnViewResult_Click);
            // 
            // frmMatchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(891, 510);
            this.Controls.Add(this.btnViewResult);
            this.Controls.Add(this.btnRecordResults);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPrintScoreSheet);
            this.Controls.Add(this.cmbTournamentYear);
            this.Controls.Add(this.btnGameSchedule);
            this.Controls.Add(this.lvwMatchList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMatchList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Match List";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwMatchList;
        private System.Windows.Forms.Button btnGameSchedule;
        private System.Windows.Forms.ComboBox cmbTournamentYear;
        private System.Windows.Forms.Button btnPrintScoreSheet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRecordResults;
        private System.Windows.Forms.Button btnViewResult;
    }
}