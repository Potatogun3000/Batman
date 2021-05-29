using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System.IO;


namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmAddPlayer : Form
    {
        public frmAddPlayer()
        {
            InitializeComponent();
            getPositionList();
            editPlayer();
        }

        private void btnAddPlayer_Click(object sender, EventArgs e)
        {
            AddPlayer();
        }

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            browsePlayerPhoto();
        }

        private void getPositionList()
        {
            cmbPlayerPosition.DataSource    = PositionHelper.GetAllPosition();
            cmbPlayerPosition.DisplayMember = "position_desc";
            cmbPlayerPosition.ValueMember   = "position_id";
        }

        private void AddPlayer()    
        {   
            int    age    = DateTime.Now.Year - dpkPlayerBirthdate.Value.Year;
            string birthdate  = dpkPlayerBirthdate.Value.ToString("MMMM/dd/yyyy");
            string fname  = txtPlayerfname.Text, lname = txtPlayerlname.Text;
            string captain = "";


            if (cbCaptain.Checked == true)
            { 
                captain = "Team Captain";
            }
            
            
            Player player = new Player()
            {   
                player_name         = fname + " " + lname + " " + captain,
                player_jerseyNo     = cmbPlayerJerseyNo.Text,
                player_birthdate    = birthdate,
                player_address      = txtPlayerAddress.Text,
                player_photo        = getImage()
            };
            
            if (player.validatePlayer(fname,lname,age) == false)
                return; 
                
            if (player.isPlayerExisting() == false)
                return;
               
                if(Globals.PlayerInfo.isPlayerAdd == true)
                {   
                    Globals.PlayerInfo.player_name      = fname + " " + lname + " " + captain;
                    Globals.PlayerInfo.player_jerseyNo  = cmbPlayerJerseyNo.Text;
                    Globals.PlayerInfo.player_postition = cmbPlayerPosition.Text;
                    Globals.PlayerInfo.player_birthdate = birthdate;
                    Globals.PlayerInfo.player_age       = age;
                    Globals.PlayerInfo.player_address   = txtPlayerAddress.Text;
                    Globals.PlayerInfo.player_photo     = getImage();
                }


               Globals.PlayerInfo.isPlayerAdd  = false;
               if (Globals.PlayerInfo.isPlayerEdit == true) { Globals.PlayerInfo.isPlayerEdit = false;}
               this.Close();
        }
       
        private void editPlayer()
        {
            if (Globals.PlayerInfo.isPlayerEdit == true)
            {
                this.Text = "Update Player";
                btnAddPlayer.Text = "Update";
                
                string playerName = Globals.PlayerInfo.player_name;
                if (playerName.Contains("(Team Captain)")) cbCaptain.Checked = true;

                string[] words = playerName.Split(' ');
                int ctr = 0;
                foreach (string word in words)
                {
                    if (ctr == 0) txtPlayerfname.Text = word;
                    if (ctr == 1) txtPlayerlname.Text = word; 
                    ctr++;
                }
                Player player = new Player();
                
                cmbPlayerJerseyNo.Text = Globals.PlayerInfo.player_jerseyNo;
                cmbPlayerPosition.Text = Globals.PlayerInfo.player_postition;
                txtPlayerAddress.Text  = Globals.PlayerInfo.player_address;
                picPlayerPhoto.Image   = player.Base64ToImage(Globals.PlayerInfo.player_photo);
            }
        }

        private string getImage()
        {
            string team_image = null;
            Player player = new Player();
            try
            {
                byte[] by = null;

                MemoryStream ms = new MemoryStream();
                by = ms.GetBuffer();
                ms.Close();     
            }
            catch (Exception) { }
            return team_image = player.ImageToBase64(picPlayerPhoto.Image, System.Drawing.Imaging.ImageFormat.Png);
        }


        private void browsePlayerPhoto()
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.InitialDirectory = "C:/Picture/";
            openImage.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files(*.*)|*.*";
            openImage.Title = "Select Product Image";
            openImage.FilterIndex = 2;
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                picPlayerPhoto.Image = Image.FromFile(openImage.FileName);
                picPlayerPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                picPlayerPhoto.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void frmAddPlayer_Load(object sender, EventArgs e)
        {

        }
  }
}
