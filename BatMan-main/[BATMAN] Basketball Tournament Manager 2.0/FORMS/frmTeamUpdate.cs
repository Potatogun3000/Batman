using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmTeamUpdate : Form
    {
        Team team = null;
        public frmTeamUpdate(Team selectedTeam)
        {
            InitializeComponent();
            getBarangayList();
            this.team = selectedTeam;
            loadTeamToUpdate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateTeam();
        }

        private void btnBrowseLogo_Click(object sender, EventArgs e)
        {
            browseTeamLogo();
        }

        private void loadTeamToUpdate()
        {
            Team logo = new Team();

            if(team!= null)
            {
                cmbBarangay.Text     = team.barangay.brgyName;
                txtTeamName.Text     = team.team_name;
                txtSlogan.Text       = team.team_slogan;
                picTeamLogo.Image    = logo.Base64ToImage(team.team_logo);
            }
        }   

        private void getBarangayList()
        {
            cmbBarangay.DataSource      = BarangayHelper.GetAllBarangay();
            cmbBarangay.DisplayMember   = "brgy_name";
            cmbBarangay.ValueMember     = "brgy_id";
        }

        private void updateTeam()
        {
            Team update = new Team()
            {
                team_id      =  team.team_id,
                team_name    =  txtTeamName.Text,
                team_slogan  =  txtSlogan.Text,
                team_logo    =  getImage()
            };
            update.barangay.brgyID = Convert.ToInt32(cmbBarangay.SelectedValue);
            if (update.checkBrgyAndTeam(cmbBarangay.Text, update.team_name) == false) return;

            try
            {
                TeamHelper.UpdateTeam(update);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        
        }

        private string getImage()
        {
            string team_image = null;
            Team team = new Team();
            try
            {
                byte[] by = null;

                MemoryStream ms = new MemoryStream();
                by = ms.GetBuffer();
                ms.Close();
            }
            catch (Exception) { }
            return team_image = team.ImageToBase64(picTeamLogo.Image, System.Drawing.Imaging.ImageFormat.Png);
        }

        private void browseTeamLogo()
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.InitialDirectory = "C:/Picture/";
            openImage.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files(*.*)|*.*";
            openImage.Title = "Select Product Image";
            openImage.FilterIndex = 2;
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                picTeamLogo.Image = Image.FromFile(openImage.FileName);
                picTeamLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                picTeamLogo.BorderStyle = BorderStyle.Fixed3D;
            }
        }
    }
}
