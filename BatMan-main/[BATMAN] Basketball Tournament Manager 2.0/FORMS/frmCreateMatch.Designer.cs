namespace _BATMAN__Basketball_Tournament_Manager_2._0
{
    partial class frmCreateMatch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateMatch));
            this.btnSaveMatch = new System.Windows.Forms.Button();
            this.btnGenerateMatch = new System.Windows.Forms.Button();
            this.lblSchedule = new System.Windows.Forms.Label();
            this.lblTournamentYear = new System.Windows.Forms.Label();
            this.lblMotto = new System.Windows.Forms.Label();
            this.picNagaCityLogo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwMatch = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.picNagaCityLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSaveMatch
            // 
            this.btnSaveMatch.Location = new System.Drawing.Point(877, 603);
            this.btnSaveMatch.Name = "btnSaveMatch";
            this.btnSaveMatch.Size = new System.Drawing.Size(147, 58);
            this.btnSaveMatch.TabIndex = 41;
            this.btnSaveMatch.Text = "Save Match";
            this.btnSaveMatch.UseVisualStyleBackColor = true;
            this.btnSaveMatch.Click += new System.EventHandler(this.btnSaveMatch_Click);
            // 
            // btnGenerateMatch
            // 
            this.btnGenerateMatch.Location = new System.Drawing.Point(724, 603);
            this.btnGenerateMatch.Name = "btnGenerateMatch";
            this.btnGenerateMatch.Size = new System.Drawing.Size(147, 58);
            this.btnGenerateMatch.TabIndex = 42;
            this.btnGenerateMatch.Text = "Generate Match";
            this.btnGenerateMatch.UseVisualStyleBackColor = true;
            this.btnGenerateMatch.Click += new System.EventHandler(this.btnGenerateMatch_Click);
            // 
            // lblSchedule
            // 
            this.lblSchedule.AutoSize = true;
            this.lblSchedule.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedule.Location = new System.Drawing.Point(390, 29);
            this.lblSchedule.Name = "lblSchedule";
            this.lblSchedule.Size = new System.Drawing.Size(118, 21);
            this.lblSchedule.TabIndex = 44;
            this.lblSchedule.Text = "dsadsadasd";
            // 
            // lblTournamentYear
            // 
            this.lblTournamentYear.AutoSize = true;
            this.lblTournamentYear.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTournamentYear.Location = new System.Drawing.Point(400, 8);
            this.lblTournamentYear.Name = "lblTournamentYear";
            this.lblTournamentYear.Size = new System.Drawing.Size(118, 21);
            this.lblTournamentYear.TabIndex = 43;
            this.lblTournamentYear.Text = "dsadsadasd";
            // 
            // lblMotto
            // 
            this.lblMotto.AutoSize = true;
            this.lblMotto.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotto.Location = new System.Drawing.Point(453, 50);
            this.lblMotto.Name = "lblMotto";
            this.lblMotto.Size = new System.Drawing.Size(118, 21);
            this.lblMotto.TabIndex = 45;
            this.lblMotto.Text = "dsadsadasd";
            // 
            // picNagaCityLogo
            // 
            this.picNagaCityLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picNagaCityLogo.Image = ((System.Drawing.Image)(resources.GetObject("picNagaCityLogo.Image")));
            this.picNagaCityLogo.Location = new System.Drawing.Point(265, 6);
            this.picNagaCityLogo.Name = "picNagaCityLogo";
            this.picNagaCityLogo.Size = new System.Drawing.Size(119, 102);
            this.picNagaCityLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNagaCityLogo.TabIndex = 46;
            this.picNagaCityLogo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(471, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 21);
            this.label1.TabIndex = 48;
            this.label1.Text = "ROUND ROBIN";
            // 
            // lvwMatch
            // 
            this.lvwMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwMatch.Location = new System.Drawing.Point(12, 114);
            this.lvwMatch.Name = "lvwMatch";
            this.lvwMatch.Size = new System.Drawing.Size(1012, 483);
            this.lvwMatch.TabIndex = 50;
            this.lvwMatch.UseCompatibleStateImageBehavior = false;
            // 
            // frmCreateMatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1036, 673);
            this.Controls.Add(this.lvwMatch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picNagaCityLogo);
            this.Controls.Add(this.lblMotto);
            this.Controls.Add(this.lblSchedule);
            this.Controls.Add(this.lblTournamentYear);
            this.Controls.Add(this.btnGenerateMatch);
            this.Controls.Add(this.btnSaveMatch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCreateMatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Match";
            ((System.ComponentModel.ISupportInitialize)(this.picNagaCityLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveMatch;
        private System.Windows.Forms.Button btnGenerateMatch;
        private System.Windows.Forms.Label lblSchedule;
        private System.Windows.Forms.Label lblTournamentYear;
        private System.Windows.Forms.Label lblMotto;
        private System.Windows.Forms.PictureBox picNagaCityLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwMatch;
    }
}