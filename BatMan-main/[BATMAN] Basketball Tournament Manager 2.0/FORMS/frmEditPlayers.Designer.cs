namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    partial class frmEditPlayers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEditPlayers));
            this.btnUpdatePlayer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picPlayerPhoto = new System.Windows.Forms.PictureBox();
            this.btnBrowsePhoto = new System.Windows.Forms.Button();
            this.chkCaptain = new System.Windows.Forms.CheckBox();
            this.dpkPlayerBirthdate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPlayerPosition = new System.Windows.Forms.ComboBox();
            this.txtPlayerfname = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPlayerJerseyNo = new System.Windows.Forms.ComboBox();
            this.txtPlayerlname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlayerAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerPhoto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdatePlayer
            // 
            this.btnUpdatePlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnUpdatePlayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePlayer.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdatePlayer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnUpdatePlayer.Location = new System.Drawing.Point(571, 357);
            this.btnUpdatePlayer.Name = "btnUpdatePlayer";
            this.btnUpdatePlayer.Size = new System.Drawing.Size(231, 59);
            this.btnUpdatePlayer.TabIndex = 15;
            this.btnUpdatePlayer.Text = "Update ";
            this.btnUpdatePlayer.UseVisualStyleBackColor = false;
            this.btnUpdatePlayer.Click += new System.EventHandler(this.btnUpdatePlayer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picPlayerPhoto);
            this.groupBox1.Controls.Add(this.btnUpdatePlayer);
            this.groupBox1.Controls.Add(this.btnBrowsePhoto);
            this.groupBox1.Controls.Add(this.chkCaptain);
            this.groupBox1.Controls.Add(this.dpkPlayerBirthdate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbPlayerPosition);
            this.groupBox1.Controls.Add(this.txtPlayerfname);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbPlayerJerseyNo);
            this.groupBox1.Controls.Add(this.txtPlayerlname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPlayerAddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Cooper Black", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 151);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 428);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Info";
            // 
            // picPlayerPhoto
            // 
            this.picPlayerPhoto.BackColor = System.Drawing.Color.White;
            this.picPlayerPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picPlayerPhoto.Location = new System.Drawing.Point(6, 44);
            this.picPlayerPhoto.Name = "picPlayerPhoto";
            this.picPlayerPhoto.Size = new System.Drawing.Size(192, 173);
            this.picPlayerPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPlayerPhoto.TabIndex = 21;
            this.picPlayerPhoto.TabStop = false;
            // 
            // btnBrowsePhoto
            // 
            this.btnBrowsePhoto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.btnBrowsePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowsePhoto.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowsePhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.btnBrowsePhoto.Location = new System.Drawing.Point(6, 230);
            this.btnBrowsePhoto.Name = "btnBrowsePhoto";
            this.btnBrowsePhoto.Size = new System.Drawing.Size(192, 67);
            this.btnBrowsePhoto.TabIndex = 22;
            this.btnBrowsePhoto.Text = "Browse Player\r\n Photo";
            this.btnBrowsePhoto.UseVisualStyleBackColor = false;
            this.btnBrowsePhoto.Click += new System.EventHandler(this.btnBrowsePhoto_Click);
            // 
            // chkCaptain
            // 
            this.chkCaptain.AutoSize = true;
            this.chkCaptain.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCaptain.Location = new System.Drawing.Point(571, 121);
            this.chkCaptain.Name = "chkCaptain";
            this.chkCaptain.Size = new System.Drawing.Size(140, 23);
            this.chkCaptain.TabIndex = 14;
            this.chkCaptain.Text = "Team Captain";
            this.chkCaptain.UseVisualStyleBackColor = true;
            // 
            // dpkPlayerBirthdate
            // 
            this.dpkPlayerBirthdate.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpkPlayerBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkPlayerBirthdate.Location = new System.Drawing.Point(321, 234);
            this.dpkPlayerBirthdate.Name = "dpkPlayerBirthdate";
            this.dpkPlayerBirthdate.Size = new System.Drawing.Size(228, 27);
            this.dpkPlayerBirthdate.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(216, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 19);
            this.label5.TabIndex = 7;
            this.label5.Text = "Jersey No:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(216, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 19);
            this.label7.TabIndex = 11;
            this.label7.Text = "Birth Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(219, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // cmbPlayerPosition
            // 
            this.cmbPlayerPosition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayerPosition.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlayerPosition.FormattingEnabled = true;
            this.cmbPlayerPosition.Location = new System.Drawing.Point(321, 180);
            this.cmbPlayerPosition.Name = "cmbPlayerPosition";
            this.cmbPlayerPosition.Size = new System.Drawing.Size(228, 27);
            this.cmbPlayerPosition.TabIndex = 10;
            // 
            // txtPlayerfname
            // 
            this.txtPlayerfname.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayerfname.Location = new System.Drawing.Point(321, 36);
            this.txtPlayerfname.Name = "txtPlayerfname";
            this.txtPlayerfname.Size = new System.Drawing.Size(228, 27);
            this.txtPlayerfname.TabIndex = 1;
            this.txtPlayerfname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(216, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 9;
            this.label6.Text = "Position:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(372, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "First Name";
            // 
            // cmbPlayerJerseyNo
            // 
            this.cmbPlayerJerseyNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlayerJerseyNo.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlayerJerseyNo.FormattingEnabled = true;
            this.cmbPlayerJerseyNo.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "45",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55"});
            this.cmbPlayerJerseyNo.Location = new System.Drawing.Point(321, 119);
            this.cmbPlayerJerseyNo.Name = "cmbPlayerJerseyNo";
            this.cmbPlayerJerseyNo.Size = new System.Drawing.Size(228, 27);
            this.cmbPlayerJerseyNo.TabIndex = 8;
            // 
            // txtPlayerlname
            // 
            this.txtPlayerlname.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayerlname.Location = new System.Drawing.Point(563, 36);
            this.txtPlayerlname.Name = "txtPlayerlname";
            this.txtPlayerlname.Size = new System.Drawing.Size(239, 27);
            this.txtPlayerlname.TabIndex = 3;
            this.txtPlayerlname.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(656, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name";
            // 
            // txtPlayerAddress
            // 
            this.txtPlayerAddress.Font = new System.Drawing.Font("Constantia", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlayerAddress.Location = new System.Drawing.Point(220, 330);
            this.txtPlayerAddress.Multiline = true;
            this.txtPlayerAddress.Name = "txtPlayerAddress";
            this.txtPlayerAddress.Size = new System.Drawing.Size(324, 86);
            this.txtPlayerAddress.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cooper Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(216, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 19);
            this.label4.TabIndex = 5;
            this.label4.Text = "Address:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cooper Black", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(64)))), ((int)(((byte)(139)))));
            this.label8.Location = new System.Drawing.Point(293, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(218, 40);
            this.label8.TabIndex = 43;
            this.label8.Text = "Edit Player";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(620, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(200, 118);
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(178, 118);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // frmEditPlayers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(200)))), ((int)(((byte)(82)))));
            this.ClientSize = new System.Drawing.Size(832, 583);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmEditPlayers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Players";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPlayerPhoto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdatePlayer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picPlayerPhoto;
        private System.Windows.Forms.Button btnBrowsePhoto;
        private System.Windows.Forms.CheckBox chkCaptain;
        private System.Windows.Forms.DateTimePicker dpkPlayerBirthdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPlayerPosition;
        private System.Windows.Forms.TextBox txtPlayerfname;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPlayerJerseyNo;
        private System.Windows.Forms.TextBox txtPlayerlname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlayerAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}