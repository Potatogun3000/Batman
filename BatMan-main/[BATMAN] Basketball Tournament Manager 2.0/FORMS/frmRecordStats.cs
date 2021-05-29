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
    public partial class frmRecordStats : Form
    {
        int teamId = 0;
        int guestId = 0;
        int matchId = 0;

        public frmRecordStats(int team1, int team2 , int mId)
        {
            InitializeComponent();

            this.teamId  = team1;
            this.guestId = team2;
            this.matchId = mId;
            initHomeTeamList();
            initGuestList();
        }


        private static int i;
        private static int x;
        bool check = false;

        DataTable hOt = new DataTable();
        DataTable gOt = new DataTable();
        private void btnAddOtHome_Click(object sender, EventArgs e)
        {
            i++;
            hOt.Columns.Add("Overtime " + i.ToString(), typeof(int));
            dgvOtHome.DataSource = hOt;
        }

        private void btnAddOtGuest_Click(object sender, EventArgs e)
        {
            x++;
            gOt.Columns.Add("Overtime " + x.ToString(), typeof(int));
            dgvOtGuest.DataSource = gOt;
        }

        private void btnFillScore_Click(object sender, EventArgs e)
        {
            fillScores();
        }
        private void btnCheckCompute_Click(object sender, EventArgs e)
        {   
            if( btnCheckCompute.Text != "Edit Scores")
            {
            int hfinalScore = 0;
            foreach (DataGridViewRow row in dgvHomeTeam.Rows)
            {
                hfinalScore += Convert.ToInt32(row.Cells["Points"].Value) + Convert.ToInt32(row.Cells["Free Throw"].Value);
            }


            int gfinalScore = 0;
            foreach (DataGridViewRow row in dgvGuestTeam.Rows)
            {
                gfinalScore += Convert.ToInt32(row.Cells["Points"].Value) + Convert.ToInt32(row.Cells["Free Throw"].Value);

            }


            //OVER TIME CODE
      
            foreach (DataGridViewRow row in dgvOtHome.Rows)
            {   
                hfinalScore += Convert.ToInt32(row.Cells["Overtime"].Value);
            }

            foreach (DataGridViewRow row in dgvOtGuest.Rows)
            {
                gfinalScore += Convert.ToInt32(row.Cells["Overtime"].Value);
            }

            
            txtHFinalScore.Text = hfinalScore.ToString();
            txtGFinalScore.Text = gfinalScore.ToString();
            check = true;

            btnCheckCompute.Text = "Edit Scores";
                grpHomeTeam.Enabled = false;
                grpGuestTeam.Enabled = false;
                btnFillScore.Enabled = false;
                check = true;

                string homeName  = lblHomeTeam.Text;
                string guestName = lblGuestTeam.Text;
                string winner = "";

                if (hfinalScore > gfinalScore) winner = homeName;
                else  winner = guestName;

                if(hfinalScore != gfinalScore)
                    MessageBox.Show("Match Successfully Checked! TEAM " +winner+ " WON THIS MATCH!","Match",MessageBoxButtons.OK,MessageBoxIcon.Information);
                else
                    MessageBox.Show("Match Successfully Checked!  MATCH FOR " + homeName + " VS " + guestName + " IS TIE!", "Match", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                grpHomeTeam.Enabled =  true;
                grpGuestTeam.Enabled = true;
                btnFillScore.Enabled = true;

                check = false;
               btnCheckCompute.Text = "Check and Compute";
            }

        }

        private void btnSaveStats_Click(object sender, EventArgs e)
        {
            saveStats();
        }

        DataTable tableH = new DataTable();
        private void initHomeTeamList()
        {
            txtHFinalScore.Text = "0";
            txtHQ1.Text = "0";
            txtHQ2.Text = "0";
            txtHQ3.Text = "0";
            txtHQ4.Text = "0";
      
            tableH.Columns.Add("Jersey No", typeof(string));
            tableH.Columns.Add("Player Name",typeof(string));
            tableH.Columns.Add("Position", typeof(string));
            tableH.Columns.Add("Points", typeof(int));
            tableH.Columns.Add("Rebounds", typeof(int));
            tableH.Columns.Add("Assists", typeof(int));
            tableH.Columns.Add("Steals", typeof(int));
            tableH.Columns.Add("Turn Over", typeof(int));
            tableH.Columns.Add("Free Throw", typeof(int));
            tableH.Columns.Add("Fouls", typeof(int));

            SqlParameter[] players = { new SqlParameter("team_id", teamId) };
            var player = MatchHelper.GetMatchPlayer(players);
       
            foreach (var item in player)
            {
                tableH.Rows.Add(item.player_jerseyNo, item.player_name, item.position.position_desc, 0, 0, 0, 0, 0, 0 ,0);
                lblHomeTeam.Text = item.team.team_name;
            }

            dgvHomeTeam.DataSource = tableH;
            dgvHomeTeam.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;


            hOt.Columns.Add("Overtime", typeof(int));
            dgvOtHome.DataSource = hOt;
        }
    

        DataTable tableG = new DataTable();
        private void initGuestList()
        {
            txtGFinalScore.Text = "0";
            txtGQ1.Text = "0";
            txtGQ2.Text = "0";
            txtGQ3.Text = "0";
            txtGQ4.Text = "0";

           
            tableG.Columns.Add("Jersey No", typeof(string));
            tableG.Columns.Add("Player Name", typeof(string));
            tableG.Columns.Add("Position", typeof(string));
            tableG.Columns.Add("Points", typeof(int));
            tableG.Columns.Add("Rebounds", typeof(int));
            tableG.Columns.Add("Assists", typeof(int));
            tableG.Columns.Add("Steals", typeof(int));
            tableG.Columns.Add("Turn Over", typeof(int));
            tableG.Columns.Add("Free Throw", typeof(int));
            tableG.Columns.Add("Fouls", typeof(int));
         
            SqlParameter[] players = { new SqlParameter("team_id", guestId) };
            var player = MatchHelper.GetMatchPlayer(players);

            foreach (var item in player)
            {   
                tableG.Rows.Add(item.player_jerseyNo, item.player_name, item.position.position_desc,0,0,0,0,0,0,0);
                lblGuestTeam.Text = item.team.team_name;

            }

            dgvGuestTeam.DataSource = tableG;
            dgvGuestTeam.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.TopCenter;

         

            gOt.Columns.Add("Overtime", typeof(int));
            dgvOtGuest.DataSource = gOt;

        }


        private void dgvHomeTeam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvHomeTeam.Rows)
            {
                row.Cells["Jersey No"].ReadOnly = true;
                row.Cells["Player Name"].ReadOnly = true;
                row.Cells["Position"].ReadOnly = true;
            }
        }

        private void dgvGuestTeam_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dgvGuestTeam.Rows)
            {
                row.Cells["Jersey No"].ReadOnly = true;
                row.Cells["Player Name"].ReadOnly = true;
                row.Cells["Position"].ReadOnly = true;
            }
        }


        private void fillScores()
        {
            //fill Scores
            tableH.Rows.Clear();
            tableG.Rows.Clear();
            Random random = new Random();
            int Hp          = random.Next(5,20);
            int Hreb        = random.Next(4, 20);
            int Hasst       = random.Next(2, 30);
            int Hsteals     = random.Next(5, 30);
            int Hto         = random.Next(1, 20);
            int HFt         = random.Next(6, 10);
            int HF          = random.Next(1,5);

            int Gp = random.Next(6, 20);
            int Greb = random.Next(4, 20);
            int Gasst = random.Next(6, 20);
            int Gsteals = random.Next(3, 10);
            int Gto = random.Next(2, 20);
            int GFt = random.Next(0, 10);
            int GF = random.Next(1, 5);

            SqlParameter[] players = { new SqlParameter("team_id", teamId) };
            var player = MatchHelper.GetMatchPlayer(players);

            int hctr = 0;
            int fctr = 0;
            foreach (var item in player)
            {
                tableH.Rows.Add(item.player_jerseyNo, item.player_name, item.position.position_desc, Hp + hctr, Hreb + hctr, Hsteals + hctr, Hto + hctr, Gto + hctr, HFt + hctr, HF +fctr);
                lblHomeTeam.Text = item.team.team_name;

                fctr = random.Next(1, 3); 
                hctr = random.Next(1, 10);
                hctr +=2;
            }

            dgvHomeTeam.DataSource = tableH;


            SqlParameter[] p = { new SqlParameter("team_id", guestId) };
            var pl = MatchHelper.GetMatchPlayer(p);
            
          
            foreach (var item in pl)
            {
                tableG.Rows.Add(item.player_jerseyNo, item.player_name, item.position.position_desc, Hp + hctr, Hreb + hctr, Hsteals + hctr, Hto + hctr, Gto + hctr, HFt + hctr, HF +fctr);
                lblGuestTeam.Text = item.team.team_name;

                fctr = random.Next(1, 3);
                hctr = random.Next(1, 5);
                hctr += 2;
            }

            dgvGuestTeam.DataSource = tableG;
           ////

            
                // Compute Final Score
                int hfinalScore = 0;
                foreach (DataGridViewRow row in dgvHomeTeam.Rows)
                {
                    hfinalScore += Convert.ToInt32(row.Cells["Points"].Value) + Convert.ToInt32(row.Cells["Free Throw"].Value);
                }


                int gfinalScore = 0;
                foreach (DataGridViewRow row in dgvGuestTeam.Rows)
                {
                    gfinalScore += Convert.ToInt32(row.Cells["Points"].Value) + Convert.ToInt32(row.Cells["Free Throw"].Value);

                }

                txtHFinalScore.Text = hfinalScore.ToString();
                txtGFinalScore.Text = gfinalScore.ToString();
                ///


                Random rg = new Random();
                int[] nums = new int[4];
                while (nums.Sum() != hfinalScore)
                {
                    for (int x = 0; x < 4; ++x)
                    {
                        int r = rg.Next(1, 100);
                        if (nums.Contains(r))
                        {
                            --x;
                            continue;
                        }
                        nums[x] = r;
                    }
                }
                Array.Sort(nums);
                int ctr = 0;
                foreach (int d in nums)
                {
                    if (ctr == 0) txtHQ1.Text = d.ToString();
                    if (ctr == 1) txtHQ2.Text = d.ToString();
                    if (ctr == 2) txtHQ3.Text = d.ToString();
                    if (ctr == 3) txtHQ4.Text = d.ToString();

                    ctr++;
                }

                Random rg2 = new Random();
                int[] nums2 = new int[4];
                while (nums2.Sum() != gfinalScore)
                {
                    for (int x = 0; x < 4; ++x)
                    {
                        int r = rg2.Next(1, 100);
                        if (nums2.Contains(r))
                        {
                            --x;
                            continue;
                        }
                        nums2[x] = r;
                    }
                }
                Array.Sort(nums2);
                int ctr2 = 0;
                foreach (int d in nums2)
                {
                    if (ctr2 == 0) txtGQ1.Text = d.ToString();
                    if (ctr2 == 1) txtGQ2.Text = d.ToString();
                    if (ctr2 == 2) txtGQ3.Text = d.ToString();
                    if (ctr2 == 3) txtGQ4.Text = d.ToString();
                
                    ctr2++;
                }

        }
        private void saveStats()
        {
            if (check == false)
            {
                MessageBox.Show("Check and Compute First The Scores", "Record Stat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            //HOME TEAM
            TeamStat teamStat = new TeamStat();
            teamStat.team_name           = lblHomeTeam.Text;
            teamStat.teamStat_totalScore = Convert.ToInt32(txtHFinalScore.Text);
            teamStat.team_statQ1         = Convert.ToInt32(txtHQ1.Text);
            teamStat.team_statQ2         = Convert.ToInt32(txtHQ2.Text);
            teamStat.team_statQ3         = Convert.ToInt32(txtHQ3.Text);
            teamStat.team_statQ4         = Convert.ToInt32(txtHQ4.Text);
            teamStat.team_desc           = "HT";
            teamStat.match.match_id      = matchId;
            TeamStatHelper.SaveTeamStat(teamStat);
            
            //GUEST TEAM
            TeamStat GteamStat = new TeamStat();
            GteamStat.team_name           = lblGuestTeam.Text;
            GteamStat.teamStat_totalScore = Convert.ToInt32(txtGFinalScore.Text);
            GteamStat.team_statQ1 = Convert.ToInt32(txtGQ1.Text);
            GteamStat.team_statQ2 = Convert.ToInt32(txtGQ2.Text);
            GteamStat.team_statQ3 = Convert.ToInt32(txtGQ3.Text);
            GteamStat.team_statQ4 = Convert.ToInt32(txtGQ4.Text);
            GteamStat.team_desc = "GT";
            GteamStat.match.match_id = matchId;
            TeamStatHelper.SaveTeamStat(GteamStat);



            PlayerStat playerStat = new PlayerStat();
            int countRow = dgvGuestTeam.RowCount - 1;
            int checkHRow = 0, checkGRow = 0;
            foreach (DataGridViewRow row in dgvHomeTeam.Rows)
            {
                if (checkHRow == countRow)
                   {
                       break;
                   }

                   playerStat.player.player_jerseyNo = row.Cells["Jersey No"].Value.ToString();
                   playerStat.player.player_name = row.Cells["Player Name"].Value.ToString();
                   playerStat.position.position_desc = row.Cells["Position"].Value.ToString();
                   playerStat.player_point = Convert.ToInt32(row.Cells["Points"].Value);
                   playerStat.player_reb = Convert.ToInt32(row.Cells["Rebounds"].Value);
                   playerStat.player_asst = Convert.ToInt32(row.Cells["Assists"].Value);
                   playerStat.player_steal = Convert.ToInt32(row.Cells["Steals"].Value);
                   playerStat.player_to = Convert.ToInt32(row.Cells["Turn Over"].Value);
                   playerStat.player_ft = Convert.ToInt32(row.Cells["Free Throw"].Value);
                   playerStat.player_fouls = Convert.ToInt32(row.Cells["Fouls"].Value);
                   playerStat.match.match_id = matchId;
                   playerStat.team_desc = "HT";

                   PlayerStatHelper.SavePlayerStat(playerStat);
                   checkHRow++;
            }
            foreach (DataGridViewRow row in dgvGuestTeam.Rows)
            {
               if (checkGRow == countRow)
                {
                    break;
                }
                playerStat.player.player_jerseyNo               = row.Cells["Jersey No"].Value.ToString();
                playerStat.player.player_name                   = row.Cells["Player Name"].Value.ToString();
                playerStat.position.position_desc               = row.Cells["Position"].Value.ToString();
                playerStat.player_point                         = Convert.ToInt32(row.Cells["Points"].Value);
                playerStat.player_reb                           = Convert.ToInt32(row.Cells["Rebounds"].Value);
                playerStat.player_asst                          = Convert.ToInt32(row.Cells["Assists"].Value);
                playerStat.player_steal                         = Convert.ToInt32(row.Cells["Steals"].Value);
                playerStat.player_to                            = Convert.ToInt32(row.Cells["Turn Over"].Value);
                playerStat.player_ft                            = Convert.ToInt32(row.Cells["Free Throw"].Value);
                playerStat.player_fouls                         = Convert.ToInt32(row.Cells["Fouls"].Value);
                playerStat.match.match_id                       = matchId;
                playerStat.team_desc = "GT";

                PlayerStatHelper.SavePlayerStat(playerStat);
                checkGRow++;
            }

            Match match = new Match();
            match.match_id = matchId;
            match.match_status = "ENDED";
            MatchHelper.UpdateMatchStatus(match);
  
            MessageBox.Show("Match Stats Successfully Recorded!","Record Stat",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.Close();
        }


    }
}
