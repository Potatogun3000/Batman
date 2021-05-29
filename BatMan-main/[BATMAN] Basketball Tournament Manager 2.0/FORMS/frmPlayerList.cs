using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmPlayerList : Form
    {
       List <Player> listPlayers = null; 
        public frmPlayerList()
        {
            InitializeComponent();
            initializePlayerList();
            initButtons();
            loadPlayerList();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch ((int)button.Tag)
            {
                case 1:
                    editPlayer();
                    break;
                case 2:
                    searchPlayer();
                    break;
                case 3:
                    refreshList();
                    break;
            }
        }

        private void initButtons()
        {
            btnEdit.Tag = 1;
            btnSearch.Tag = 2;
            btnRefreshList.Tag = 3;

            btnEdit.Click += ButtonClick;
            btnSearch.Click += ButtonClick;
            btnRefreshList.Click += ButtonClick;
         }

        private void lvwPlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            showPlayerPhoto();
        }


        private void initializePlayerList()
        {

            lvwPlayerList.View = View.Details;
            lvwPlayerList.GridLines = true;
            lvwPlayerList.FullRowSelect = true;
           
            lvwPlayerList.Columns.Add("Id", 0);
            lvwPlayerList.Columns.Add("Team Id", 0);
            lvwPlayerList.Columns.Add("Player Name", 250, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Jersey No", 90, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Position", 100, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Birthdate", 100, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Address", 200, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Team Name", 150, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Player Photo", 0, HorizontalAlignment.Center);

        }

        private void loadPlayerList()
        {
            listPlayers = PlayerHelper.GetPlayerList();
            ListViewItem items = null;

            lvwPlayerList.Items.Clear();
            foreach (var player in listPlayers)
            {
                string captain = "";
                player.player_isCaptain = false;
                if (player.player_isCaptain == true) { captain = "(Team Captain)"; }

                items = lvwPlayerList.Items.Add(player.player_id.ToString());
                items.SubItems.Add(player.team.team_id.ToString());
                items.SubItems.Add(player.player_name + captain);
                items.SubItems.Add(player.player_jerseyNo);
                items.SubItems.Add(player.position.position_desc);
                items.SubItems.Add(player.player_birthdate);
                items.SubItems.Add(player.player_address);
                items.SubItems.Add(player.team.team_name);
                items.SubItems.Add(player.player_photo);
            }
        }


        private void editPlayer()
        {
            Tournament t = new Tournament();
            if (t.CRUDValidation() == false) return;

            if (lvwPlayerList.Items.Count == 0 || lvwPlayerList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Player to Edit", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int si = lvwPlayerList.SelectedItems[0].Index;
            Player selectedPlayer = listPlayers[si];

            using (Form editPlayer = new frmEditPlayers(selectedPlayer))
            {
                editPlayer.StartPosition = FormStartPosition.CenterParent;
                editPlayer.ShowDialog();

                if (editPlayer.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Player successfully Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadPlayerList();
                }
            }
        }

        private void searchPlayer()
        {
           string search = txtSearchTeamOfficial.Text;
           if (search.Length == 0) { MessageBox.Show("Please Input the Word you want to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

           SqlParameter[] p = { new SqlParameter("@player_jerseyNo", search),
                                new SqlParameter("@player_name", search),
                                new SqlParameter("@player_address", search),
                                new SqlParameter("@player_birthdate", search),
                                new SqlParameter("@position", search),
                                new SqlParameter("@team", search)
                              };

           listPlayers = PlayerHelper.SearchPlayer(p);
           ListViewItem items = null;

           lvwPlayerList.Items.Clear();
           foreach (var player in listPlayers)
           {
               string captain = "";
               player.player_isCaptain = false;
               if (player.player_isCaptain == true) { captain = "(Team Captain)"; }

               items = lvwPlayerList.Items.Add(player.player_id.ToString());
               items.SubItems.Add(player.team.team_id.ToString());
               items.SubItems.Add(player.player_name + captain);
               items.SubItems.Add(player.player_jerseyNo);
               items.SubItems.Add(player.position.position_desc);
               items.SubItems.Add(player.player_birthdate);
               items.SubItems.Add(player.player_address);
               items.SubItems.Add(player.team.team_name);
           }

           if (lvwPlayerList.Items.Count == 0) { MessageBox.Show(search + "Cannot be found!", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); loadPlayerList(); return; }
        }


        private void showPlayerPhoto()
        {
            try { 
            int    si    = lvwPlayerList.SelectedItems[0].Index;
            string name  = lvwPlayerList.Items[si].SubItems[2].Text;
            string position = lvwPlayerList.Items[si].SubItems[3].Text;
            string JerseyNo = lvwPlayerList.Items[si].SubItems[4].Text;
            string team  = lvwPlayerList.Items[si].SubItems[7].Text;
            string photo = lvwPlayerList.Items[si].SubItems[8].Text;
     
            Player player = new Player();
            picPlayerPhoto.Image = player.Base64ToImage(photo);
            lblPlayerName.Text = name;
            lblTeam.Text = team;
            lblJerseyNo.Text = "Jersey No: "  + JerseyNo;
            lblPosition.Text = "Position : "  + position;
            }
            catch { }
        }

        private void refreshList()
        {
            loadPlayerList();
        }
    }
}
