namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    partial class frmTeamList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTeamList));
            this.lvwTeamList = new System.Windows.Forms.ListView();
            this.picTeamLogo = new System.Windows.Forms.PictureBox();
            this.lblTeamName = new System.Windows.Forms.Label();
            this.lblTeamBrgy = new System.Windows.Forms.Label();
            this.lblTeamSlogan = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRegisterTeam = new System.Windows.Forms.Button();
            this.btnViewTeam = new System.Windows.Forms.Button();
            this.btnSearchTeam = new System.Windows.Forms.Button();
            this.grpTeamList = new System.Windows.Forms.GroupBox();
            this.txtSearchTeam = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpTeamInfo = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picTeamLogo)).BeginInit();
            this.grpTeamList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpTeamInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwTeamList
            // 
            this.lvwTeamList.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTeamList.Location = new System.Drawing.Point(16, 41);
            this.lvwTeamList.Name = "lvwTeamList";
            this.lvwTeamList.Size = new System.Drawing.Size(759, 271);
            this.lvwTeamList.TabIndex = 0;
            this.lvwTeamList.UseCompatibleStateImageBehavior = false;
            this.lvwTeamList.SelectedIndexChanged += new System.EventHandler(this.lvwTeamList_SelectedIndexChanged);
            // 
            // picTeamLogo
            // 
            this.picTeamLogo.BackColor = System.Drawing.Color.White;
            this.picTeamLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picTeamLogo.Location = new System.Drawing.Point(15, 28);
            this.picTeamLogo.Name = "picTeamLogo";
            this.picTeamLogo.Size = new System.Drawing.Size(175, 142);
            this.picTeamLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTeamLogo.TabIndex = 1;
            this.picTeamLogo.TabStop = false;
            // 
            // lblTeamName
            // 
            this.lblTeamName.AutoSize = true;
            this.lblTeamName.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamName.Location = new System.Drawing.Point(200, 35);
            this.lblTeamName.Name = "lblTeamName";
            this.lblTeamName.Size = new System.Drawing.Size(0, 21);
            this.lblTeamName.TabIndex = 2;
            // 
            // lblTeamBrgy
            // 
            this.lblTeamBrgy.AutoSize = true;
            this.lblTeamBrgy.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamBrgy.Location = new System.Drawing.Point(200, 73);
            this.lblTeamBrgy.Name = "lblTeamBrgy";
            this.lblTeamBrgy.Size = new System.Drawing.Size(0, 21);
            this.lblTeamBrgy.TabIndex = 3;
            // 
            // lblTeamSlogan
            // 
            this.lblTeamSlogan.AutoSize = true;
            this.lblTeamSlogan.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTeamSlogan.Location = new System.Drawing.Point(200, 110);
            this.lblTeamSlogan.Name = "lblTeamSlogan";
            this.lblTeamSlogan.Size = new System.Drawing.Size(0, 21);
            this.lblTeamSlogan.TabIndex = 4;
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnRefreshList.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRefreshList.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnRefreshList.Location = new System.Drawing.Point(801, 268);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(159, 62);
            this.btnRefreshList.TabIndex = 5;
            this.btnRefreshList.Text = "Refresh List";
            this.btnRefreshList.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnDelete.Location = new System.Drawing.Point(801, 431);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(159, 62);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUpdate.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnUpdate.Location = new System.Drawing.Point(801, 511);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(159, 62);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRegisterTeam
            // 
            this.btnRegisterTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnRegisterTeam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegisterTeam.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegisterTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnRegisterTeam.Location = new System.Drawing.Point(799, 588);
            this.btnRegisterTeam.Name = "btnRegisterTeam";
            this.btnRegisterTeam.Size = new System.Drawing.Size(161, 62);
            this.btnRegisterTeam.TabIndex = 8;
            this.btnRegisterTeam.Text = "Register Team...";
            this.btnRegisterTeam.UseVisualStyleBackColor = false;
            // 
            // btnViewTeam
            // 
            this.btnViewTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnViewTeam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnViewTeam.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnViewTeam.Location = new System.Drawing.Point(801, 349);
            this.btnViewTeam.Name = "btnViewTeam";
            this.btnViewTeam.Size = new System.Drawing.Size(159, 62);
            this.btnViewTeam.TabIndex = 9;
            this.btnViewTeam.Text = "View Team...";
            this.btnViewTeam.UseVisualStyleBackColor = false;
            // 
            // btnSearchTeam
            // 
            this.btnSearchTeam.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnSearchTeam.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearchTeam.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnSearchTeam.Location = new System.Drawing.Point(37, 121);
            this.btnSearchTeam.Name = "btnSearchTeam";
            this.btnSearchTeam.Size = new System.Drawing.Size(130, 43);
            this.btnSearchTeam.TabIndex = 10;
            this.btnSearchTeam.Text = "Search";
            this.btnSearchTeam.UseVisualStyleBackColor = false;
            // 
            // grpTeamList
            // 
            this.grpTeamList.Controls.Add(this.lvwTeamList);
            this.grpTeamList.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTeamList.Location = new System.Drawing.Point(12, 319);
            this.grpTeamList.Name = "grpTeamList";
            this.grpTeamList.Size = new System.Drawing.Size(781, 331);
            this.grpTeamList.TabIndex = 12;
            this.grpTeamList.TabStop = false;
            this.grpTeamList.Text = "Team List";
            // 
            // txtSearchTeam
            // 
            this.txtSearchTeam.Location = new System.Drawing.Point(6, 60);
            this.txtSearchTeam.Multiline = true;
            this.txtSearchTeam.Name = "txtSearchTeam";
            this.txtSearchTeam.Size = new System.Drawing.Size(206, 39);
            this.txtSearchTeam.TabIndex = 11;
            this.txtSearchTeam.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // grpTeamInfo
            // 
            this.grpTeamInfo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.grpTeamInfo.Controls.Add(this.picTeamLogo);
            this.grpTeamInfo.Controls.Add(this.lblTeamName);
            this.grpTeamInfo.Controls.Add(this.lblTeamBrgy);
            this.grpTeamInfo.Controls.Add(this.lblTeamSlogan);
            this.grpTeamInfo.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTeamInfo.Location = new System.Drawing.Point(240, 74);
            this.grpTeamInfo.Name = "grpTeamInfo";
            this.grpTeamInfo.Size = new System.Drawing.Size(514, 239);
            this.grpTeamInfo.TabIndex = 23;
            this.grpTeamInfo.TabStop = false;
            this.grpTeamInfo.Text = "TEAM INFO";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(760, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 103);
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtSearchTeam);
            this.groupBox1.Controls.Add(this.btnSearchTeam);
            this.groupBox1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 138);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(222, 175);
            this.groupBox1.TabIndex = 35;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SEARCH TEAM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(395, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 36);
            this.label4.TabIndex = 36;
            this.label4.Text = "Team List\r\n";
            // 
            // frmTeamList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(972, 662);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRegisterTeam);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnViewTeam);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnRefreshList);
            this.Controls.Add(this.grpTeamInfo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpTeamList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTeamList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Team List";
            ((System.ComponentModel.ISupportInitialize)(this.picTeamLogo)).EndInit();
            this.grpTeamList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpTeamInfo.ResumeLayout(false);
            this.grpTeamInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwTeamList;
        private System.Windows.Forms.PictureBox picTeamLogo;
        private System.Windows.Forms.Label lblTeamName;
        private System.Windows.Forms.Label lblTeamBrgy;
        private System.Windows.Forms.Label lblTeamSlogan;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRegisterTeam;
        private System.Windows.Forms.Button btnViewTeam;
        private System.Windows.Forms.Button btnSearchTeam;
        private System.Windows.Forms.GroupBox grpTeamList;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtSearchTeam;
        private System.Windows.Forms.GroupBox grpTeamInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
    }
}