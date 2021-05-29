using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmEditPlayers : Form
    {
        Player player = null;
        public frmEditPlayers(Player selectedPlayer = null)
        {
            InitializeComponent();
            this.player = selectedPlayer;
            getPositionList();
            loadPLayerToEdit();
        }

        private void getPositionList()
        {
            cmbPlayerPosition.DataSource = PositionHelper.GetAllPosition();
            cmbPlayerPosition.DisplayMember = "position_desc";
            cmbPlayerPosition.ValueMember = "position_id";
        }
       
        private void btnUpdatePlayer_Click(object sender, EventArgs e)
        {
            updatePlayer();
        }

        private void btnBrowsePhoto_Click(object sender, EventArgs e)
        {
            browsePlayerPhoto();
        }
     
        private void updatePlayer()
        {
            int position   = 0;
            string captain = "";
            bool isCaptain = false;
            int age = DateTime.Now.Year - dpkPlayerBirthdate.Value.Year;
            string name = player.player_name;
            string jerseyNo = player.player_jerseyNo;

            if (chkCaptain.Checked == true)
            {
                captain = "(Team Captain)";
                isCaptain = true;
                
            }

            if (cmbPlayerPosition.Text == "Point guard") position = 1;
            if (cmbPlayerPosition.Text == "Shooting guard") position = 2;
            if (cmbPlayerPosition.Text == "Small forward") position = 3;
            if (cmbPlayerPosition.Text == "Power forward") position = 4;
            if (cmbPlayerPosition.Text == "Center") position = 5;
            
            player.player_id            = player.player_id;
            player.player_name          = txtPlayerfname.Text + " " + txtPlayerlname.Text + " " + captain;
            player.player_jerseyNo      = cmbPlayerJerseyNo.Text;
            player.position.position_id = position;
            player.player_birthdate     = dpkPlayerBirthdate.Value.ToString("MMMM/dd/yyyy");
            player.player_address       = txtPlayerAddress.Text;
            player.player_isCaptain     = isCaptain;
            player.player_photo          = getImage();
            


            if (player.validatePlayer(txtPlayerfname.Text, txtPlayerlname.Text,age) == false) return;
            if (player.CheckPlayerOnTeam(name,jerseyNo) == false) return;
            
            try
            {
                PlayerHelper.UpdatePlayer(player);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
       }

        private void loadPLayerToEdit()
        {
            if (player != null)
            {
                if (player.player_name.Contains("(Team Captain)") == true) chkCaptain.Checked = true;
                
                string[] name = player.player_name.Split(' ');
                int ctr = 0;
                foreach (var list in name)
                {
                    if (ctr == 0) txtPlayerfname.Text = list;
                    if (ctr == 1) txtPlayerlname.Text = list;
                    ctr++;         
                }

                Player photo = new Player();

                cmbPlayerJerseyNo.Text = player.player_jerseyNo;
                cmbPlayerPosition.Text = player.position.position_desc; 
                txtPlayerAddress.Text  = player.player_address;
                picPlayerPhoto.Image   = photo.Base64ToImage(player.player_photo);
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


    }
}
