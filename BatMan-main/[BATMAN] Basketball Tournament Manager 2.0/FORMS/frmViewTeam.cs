using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _BATMAN__Basketball_Tournament_Manager_2._0.FORMS;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using System.IO;
using System.Data.SqlClient;


namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmViewTeam : Form
    {
        public frmViewTeam()
        {
            InitializeComponent();
            initializePlayerList();
            displayTournamentInfo();
            showTeam();
            showPlayer();
        }

        int teamId = Globals.PlayerInfo.teamId;
        private void initializePlayerList()
        {
            lvwPlayerList.View = View.Details;
            lvwPlayerList.GridLines = true;
            lvwPlayerList.FullRowSelect = true;

            lvwPlayerList.Columns.Add("Player Name", 250, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Jersey No", 90, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Position", 150, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Birthdate", 150, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Address", 200, HorizontalAlignment.Center);
        }
   
        private void showTeam()
        {
            Team team = new Team();
    
            SqlParameter[] t = { new SqlParameter("@team_id", teamId) };
            var listTeam = TeamHelper.GetTeamListwLogo(t);

            foreach (var list in listTeam)
            {
                //lblTeamName.Text  = "Team " + list.team_name;        
                picTeamLogo.Image = team.Base64ToImage(list.team_logo);
                cmbBarangay.Text  = list.barangay.brgyName;
                txtTeamName.Text  = list.team_name;
                txtSlogan.Text    = list.team_slogan;

                string[] name =   list.teamOfficial.teamOfficial_name.Split(',');
                string   coach = "", asstCoach = "", manager = "";
                int ctr = 0;
                int ctr2 = 0;
                foreach (var item in name)
                {
                    if (ctr == 0) coach     = item;
                    if (ctr == 1) asstCoach = item;
                    if (ctr == 2) manager   = item;
                    ctr++;
                }
            
                string[] c = coach.Split(' ');
                string[] ac = asstCoach.Split(' ');
                string[] m = manager.Split(' ');
                foreach (var item in c)
                {
                    if (ctr2 == 0)
                    {
                        txtCoachFname.Text = item;
                        txtAssistantCoachFname.Text = ac[ctr2];
                        txtManagerFname.Text = m[ctr2];
                    }
                 
                    if (ctr2 == 1)
                    {
                        txtCoachLname.Text = item;
                        txtAssistantCoachLname.Text = ac[ctr2];
                        txtManagerLname.Text = m[ctr2];
                    }
                    ctr2++;
                }
            }
        }

        private void showPlayer()
        {

             SqlParameter[] p = { new SqlParameter("@team_id", teamId) };
             var listPlayers = TeamHelper.GetTeamPlayers(p);
             ListViewItem items = null;
             
             foreach (var player in listPlayers)
             {
                 string captain = "";
                 player.player_isCaptain = false;
                 if (player.player_isCaptain == true) { captain = "(Team Captain)";}
        
                 items = lvwPlayerList.Items.Add(player.player_name + captain);
                 items.SubItems.Add(player.player_jerseyNo);
                 items.SubItems.Add(player.position.position_desc);
                 items.SubItems.Add(player.player_birthdate);
                 items.SubItems.Add(player.player_address);


             }

        }

        private void displayTournamentInfo()
        {
            var tournamentInfo = TournamentHelper.CheckTournamentStatus();
            foreach (var info in tournamentInfo)
            {
              lblTournamentYear.Text = info.tournament_year + " Inter-Barangay Basketball Tournament";
              lblSchedule.Text = info.tournament_schedule;
            }
        }

     
       
    }
}
