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
    public partial class frmMatchResults : Form
    {

        int matchId = 0;
        public frmMatchResults(int mId)
        {
            InitializeComponent();
            this.matchId = mId;
            initGuestList();
            initHomeList();
            checkWinner();
            loadTeamLogo();
        }


        private void initHomeList()
        {
            lvwHomeTeam.View = View.Details;
            lvwHomeTeam.GridLines = true;
            lvwHomeTeam.FullRowSelect = true;
            lvwHomeTeam.MultiSelect = false;
            lvwHomeTeam.HideSelection = false;

            lvwHomeTeam.Columns.Add("JN", 50, HorizontalAlignment.Center);
            lvwHomeTeam.Columns.Add("Position", 90 , HorizontalAlignment.Center);
            lvwHomeTeam.Columns.Add("Name", 180, HorizontalAlignment.Center);
            lvwHomeTeam.Columns.Add("Score", 50, HorizontalAlignment.Center);
            lvwHomeTeam.Columns.Add("Reb", 50, HorizontalAlignment.Center);
            lvwHomeTeam.Columns.Add("Assst", 50, HorizontalAlignment.Center);
            lvwHomeTeam.Columns.Add("Steals", 50, HorizontalAlignment.Center);
            lvwHomeTeam.Columns.Add("T.O.", 50, HorizontalAlignment.Center);
            lvwHomeTeam.Columns.Add("F.T.", 50, HorizontalAlignment.Center);
            lvwHomeTeam.Columns.Add("F", 50, HorizontalAlignment.Center);

            SqlParameter[] h =  {
            new SqlParameter("@match_id", matchId)
            };
            var matchStat      = PlayerStatHelper.GetPlayerHT(h);
            ListViewItem items = null;

            lvwHomeTeam.Items.Clear();
            foreach (var list in matchStat)
            {
                items = lvwHomeTeam.Items.Add(list.player.player_jerseyNo);
                items.SubItems.Add(list.position.position_desc);
                items.SubItems.Add(list.player.player_name);
                items.SubItems.Add(list.player_point.ToString());
                items.SubItems.Add(list.player_reb.ToString());
                items.SubItems.Add(list.player_asst.ToString());
                items.SubItems.Add(list.player_steal.ToString());
                items.SubItems.Add(list.player_to.ToString());
                items.SubItems.Add(list.player_ft.ToString());
                items.SubItems.Add(list.player_fouls.ToString());
            } 
                 
            SqlParameter[] h2 =  {
            new SqlParameter("@match_id", matchId)
            };

            var hTeam = TeamStatHelper.GetHomeTeam(h2);

            foreach (var item in hTeam)
            {
                lblHFinalScore.Text = item.teamStat_totalScore.ToString();
                lblHQ1.Text = "Q1: " +  item.team_statQ1.ToString();
                lblHQ2.Text = "Q2: " + item.team_statQ2.ToString();
                lblHQ3.Text = "Q3: " + item.team_statQ3.ToString();
                lblHQ4.Text = "Q4: " + item.team_statQ4.ToString();
            }

        }

        private void initGuestList()
        {
            lvwGuestTeam.View = View.Details;
            lvwGuestTeam.GridLines = true;
            lvwGuestTeam.FullRowSelect = true;
            lvwGuestTeam.MultiSelect = false;
            lvwGuestTeam.HideSelection = false;

            lvwGuestTeam.Columns.Add("JN", 50, HorizontalAlignment.Center);
            lvwGuestTeam.Columns.Add("Position", 90, HorizontalAlignment.Center);
            lvwGuestTeam.Columns.Add("Name", 180, HorizontalAlignment.Center);
            lvwGuestTeam.Columns.Add("Score", 50, HorizontalAlignment.Center);
            lvwGuestTeam.Columns.Add("Reb", 50, HorizontalAlignment.Center);
            lvwGuestTeam.Columns.Add("Assst", 50, HorizontalAlignment.Center);
            lvwGuestTeam.Columns.Add("Steals", 50, HorizontalAlignment.Center);
            lvwGuestTeam.Columns.Add("T.O.", 50, HorizontalAlignment.Center);
            lvwGuestTeam.Columns.Add("F.T.", 50, HorizontalAlignment.Center);
            lvwGuestTeam.Columns.Add("F", 50, HorizontalAlignment.Center);

            SqlParameter[] g =  {
            new SqlParameter("@match_id", matchId)
            };
            var matchStat = PlayerStatHelper.GetPlayerGT(g);
            ListViewItem items = null;

            lvwGuestTeam.Items.Clear();
            foreach (var list in matchStat)
            {
                items = lvwGuestTeam.Items.Add(list.player.player_jerseyNo);
                items.SubItems.Add(list.position.position_desc);
                items.SubItems.Add(list.player.player_name);
                items.SubItems.Add(list.player_point.ToString());
                items.SubItems.Add(list.player_reb.ToString());
                items.SubItems.Add(list.player_asst.ToString());
                items.SubItems.Add(list.player_steal.ToString());
                items.SubItems.Add(list.player_to.ToString());
                items.SubItems.Add(list.player_ft.ToString());
                items.SubItems.Add(list.player_fouls.ToString());
            }
          
            SqlParameter[] g2 =  {
            new SqlParameter("@match_id", matchId)
            };

            var gTeam = TeamStatHelper.GetGuestTeam(g2);

            foreach (var item in gTeam)
            {
                lblGFinalScore.Text = item.teamStat_totalScore.ToString();
                lblGQ1.Text = "Q1: " + item.team_statQ1.ToString();
                lblGQ2.Text = "Q2: " + item.team_statQ2.ToString();
                lblGQ3.Text = "Q3: " + item.team_statQ3.ToString();
                lblGQ4.Text = "Q4: " + item.team_statQ4.ToString();
            }

         }

        private void checkWinner()
        {
            SqlParameter[] id =  {
            new SqlParameter("@match_id", matchId)
            };

            var match = MatchHelper.getMatchName(id);

            string hName = "";
            string gName = "";
            string refe1 = "";
            string refe2 = "";
            int  gameNo = 0;
            foreach (var item in match)
            {
                refe1        = item.match_referee1.gameofficialName;
                refe2        = item.match_referee2.gameofficialName;
                hName        = item.match_homeTeam.team_name;
                gName        = item.match_guestTeam.team_name;
                gameNo       = item.match_gameNo;
            }

            lblHTeamName.Text  = hName;
            lblGTeamName.Text  = gName;
            ref1.Text = refe1;
            ref2.Text = refe2;
            lblGameNo.Text = "Game no: " + gameNo.ToString();

            int hfinalScore = Convert.ToInt32(lblHFinalScore.Text);
            int gfinalScore = Convert.ToInt32(lblGFinalScore.Text);

            if (hfinalScore > gfinalScore) lblwinner.Text = hName;
            else lblwinner.Text = gName;
        
        }

        private void loadTeamLogo()
        {   
            SqlParameter[] home =  {
            new SqlParameter("@team_name", lblHTeamName.Text)
            };

            SqlParameter[] guest =  {
            new SqlParameter("@team_name", lblGTeamName.Text)
            };

            var h = MatchHelper.getMatchTeamLogo(home);
            var g = MatchHelper.getMatchTeamLogo(guest);

            Team team = new Team();

            foreach (var item in h)
            {
                picHomeTeam.Image = team.Base64ToImage(item.team_logo);
            }

            foreach (var item in g)
            {
                picGuestTeam.Image = team.Base64ToImage(item.team_logo);
             
            }

        }
    
    }
}
