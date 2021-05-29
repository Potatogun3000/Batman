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
    public partial class frmAwards : Form
    {
        public frmAwards()
        {
            InitializeComponent();
            loadTournamentInfo();
            loadMVP();
            loadSF();
            loadPF();
            loadPG();
            loadSG();
            loadC();
            loadTeamChampion();
            saveAwards();
        }

        private void loadTournamentInfo()
        {
            var checkTournamentList = TournamentHelper.CheckTournamentStatus();
            string year = "", sched = "", motto = "";

            foreach (var list in checkTournamentList)
            {
                year = list.tournament_year;
                sched = list.tournament_schedule;
                motto = list.tournament_motto;
            }
     
            lblTournamentYear.Text = year + " Inter-Barangay Tournament";
            lblSchedule.Text = sched;
            lblMotto.Text = motto;
        }
       
        private void loadMVP()
        {
            var playerList = PlayerHelper.GetPlayerList();

            int count = 0;
            foreach (var item in playerList)
            {
                count++;
            }

            int[]     mvpScore   = new int[count];
            string[]  playerName = new string[count];

            int store = 0;
            foreach (var item in playerList)
            {    
                SqlParameter[] p = { new SqlParameter("@player_name", item.player_name) };
                var score =  PlayerStatHelper.getMVP(p);

                playerName[store] = item.player_name;
                foreach (var list in score)
                {
                    mvpScore[store] = list.player_point;
                }

                store++;
            }

            int maxValue = mvpScore.Max();
            int maxIndex = mvpScore.ToList().IndexOf(maxValue);
    
            SqlParameter[] pname = { new SqlParameter("@player_name",playerName[maxIndex]) };

            Team team = new Team();
            var playerInfo = PlayerStatHelper.getPlayerInfo(pname);
            foreach (var list in playerInfo)
            {
                
                picMvp.Image         =  team.Base64ToImage(list.player_photo);
                mvpJ.Text            =  "Jeysey No. " + list.player_jerseyNo;
                lblmvpName.Text      =  list.player_name;
                lblmvpTeamName.Text  =  "Barangay "+  list.team.barangay.brgyName + " (" + list.team.team_name + ")";
             }

        }

        private void loadSF()
        {
            var playerList = PlayerHelper.GetPlayerList();

            int count = 0;
            foreach (var item in playerList)
            {
                count++;
            }

            int[] mvpScore = new int[count];
            string[] playerName = new string[count];

            int store = 0;
            foreach (var item in playerList)
            {
                SqlParameter[] p = { new SqlParameter("@player_name", item.player_name) };
                var score = PlayerStatHelper.getSF(p);

                playerName[store] = item.player_name;
                foreach (var list in score)
                {
                    mvpScore[store] = list.player_point;
                }

                store++;
            }

            int maxValue = mvpScore.Max();
            int maxIndex = mvpScore.ToList().IndexOf(maxValue);

            SqlParameter[] pname = { new SqlParameter("@player_name", playerName[maxIndex]) };

            Team team = new Team();
            var playerInfo = PlayerStatHelper.getPlayerInfo(pname);
            foreach (var list in playerInfo)
            {

                picSF.Image            = team.Base64ToImage(list.player_photo);
                sfJ.Text = "Jeysey No. " + list.player_jerseyNo;
                lblSFname.Text         =  list.player_name;
                lblSFTname.Text = "Barangay " + list.team.barangay.brgyName + " " + " (" + list.team.team_name + ")";
            }

        }


        private void loadPF()
        {
            var playerList = PlayerHelper.GetPlayerList();

            int count = 0;
            foreach (var item in playerList)
            {
                count++;
            }

            int[] mvpScore = new int[count];
            string[] playerName = new string[count];

            int store = 0;
            foreach (var item in playerList)
            {
                SqlParameter[] p = { new SqlParameter("@player_name", item.player_name) };
                var score = PlayerStatHelper.getPF(p);

                playerName[store] = item.player_name;
                foreach (var list in score)
                {
                    mvpScore[store] = list.player_point;
                }

                store++;
            }

            int maxValue = mvpScore.Max();
            int maxIndex = mvpScore.ToList().IndexOf(maxValue);

            SqlParameter[] pname = { new SqlParameter("@player_name", playerName[maxIndex]) };

            Team team = new Team();
            var playerInfo = PlayerStatHelper.getPlayerInfo(pname);
            foreach (var list in playerInfo)
            {

                picPF.Image = team.Base64ToImage(list.player_photo);
                pfJ.Text = "Jeysey No. " + list.player_jerseyNo;
                lblPFname.Text = list.player_name;
                lblPFTname.Text = "Barangay " + list.team.barangay.brgyName + " " + " (" + list.team.team_name + ")";
            }

        }

        private void loadPG()
        {
            var playerList = PlayerHelper.GetPlayerList();

            int count = 0;
            foreach (var item in playerList)
            {
                count++;
            }

            int[] mvpScore = new int[count];
            string[] playerName = new string[count];

            int store = 0;
            foreach (var item in playerList)
            {
                SqlParameter[] p = { new SqlParameter("@player_name", item.player_name) };
                var score = PlayerStatHelper.getPG(p);

                playerName[store] = item.player_name;
                foreach (var list in score)
                {
                    mvpScore[store] = list.player_point;
                }

                store++;
            }

            int maxValue = mvpScore.Max();
            int maxIndex = mvpScore.ToList().IndexOf(maxValue);

            SqlParameter[] pname = { new SqlParameter("@player_name", playerName[maxIndex]) };

            Team team = new Team();
            var playerInfo = PlayerStatHelper.getPlayerInfo(pname);
            foreach (var list in playerInfo)
            {

                picPG.Image = team.Base64ToImage(list.player_photo);
                pgJ.Text = "Jeysey No. " + list.player_jerseyNo;
                lblPGname.Text =  list.player_name;
                lblPGTname.Text = "Barangay " + list.team.barangay.brgyName + " " + " (" + list.team.team_name + ")";
            }

        }

        private void loadSG()
        {
            var playerList = PlayerHelper.GetPlayerList();

            int count = 0;
            foreach (var item in playerList)
            {
                count++;
            }

            int[] mvpScore = new int[count];
            string[] playerName = new string[count];

            int store = 0;
            foreach (var item in playerList)
            {
                SqlParameter[] p = { new SqlParameter("@player_name", item.player_name) };
                var score = PlayerStatHelper.getSG(p);

                playerName[store] = item.player_name;
                foreach (var list in score)
                {
                    mvpScore[store] = list.player_point;
                }

                store++;
            }

            int maxValue = mvpScore.Max();
            int maxIndex = mvpScore.ToList().IndexOf(maxValue);

            SqlParameter[] pname = { new SqlParameter("@player_name", playerName[maxIndex]) };

            Team team = new Team();
            var playerInfo = PlayerStatHelper.getPlayerInfo(pname);
            foreach (var list in playerInfo)
            {

                picSG.Image = team.Base64ToImage(list.player_photo);
                sgJ.Text = "Jeysey No. " + list.player_jerseyNo;
                lblSGname.Text =  list.player_name;
                lblSGTname.Text = "Barangay " + list.team.barangay.brgyName + " " + " (" + list.team.team_name + ")";
            }

        }

        private void loadC()
        {
            var playerList = PlayerHelper.GetPlayerList();

            int count = 0;
            foreach (var item in playerList)
            {
                count++;
            }

            int[] mvpScore = new int[count];
            string[] playerName = new string[count];

            int store = 0;
            foreach (var item in playerList)
            {
                SqlParameter[] p = { new SqlParameter("@player_name", item.player_name) };
                var score = PlayerStatHelper.getC(p);

                playerName[store] = item.player_name;
                foreach (var list in score)
                {
                    mvpScore[store] = list.player_point;
                }

                store++;
            }

            int maxValue = mvpScore.Max();
            int maxIndex = mvpScore.ToList().IndexOf(maxValue);

            SqlParameter[] pname = { new SqlParameter("@player_name", playerName[maxIndex]) };

            Team team = new Team();
            var playerInfo = PlayerStatHelper.getPlayerInfo(pname);
            foreach (var list in playerInfo)
            {
                picCenter.Image = team.Base64ToImage(list.player_photo);
                cJ.Text = "Jeysey No. " + list.player_jerseyNo;
                lblCname.Text =  list.player_name;
                lblTCname.Text = "Barangay " + list.team.barangay.brgyName + " " + " (" + list.team.team_name + ")";
            }

        }
        
        private void loadTeamChampion()
        {
            var teamList = TeamHelper.GetTeamList();

            int count = 0;
            foreach (var item in teamList)
            {
                count++;
            }

            int[]     teamChampionScore = new int[count];
            string[]  teamName          = new string[count];
            string[]  teamLogo          = new string[count];
            string[]  teamSlogan        = new string[count];
            string[]  barangay          = new string[count];

            int store = 0;
            foreach (var item in teamList)
            {
                SqlParameter[] p = { new SqlParameter("@team_name", item.team_name) };
                var championScore = TeamStatHelper.getTeamChampion(p);

                teamName[store]   = item.team_name;
                teamLogo[store]   = item.team_logo;
                teamSlogan[store] = item.team_slogan;
                barangay[store]   = item.barangay.brgyName;

                foreach (var list in championScore)
                {
                    teamChampionScore[store] = list.teamStat_totalScore;
                }

                store++;
            }

            int championFinalScore = teamChampionScore.Max();
            int championScoreIndex = teamChampionScore.ToList().IndexOf(championFinalScore);

            Team team = new Team();
            picTeamChampion.Image     = team.Base64ToImage(teamLogo[championScoreIndex]);
            lblChampionTeamName.Text  = teamName[championScoreIndex];
            lblChampionBrgy.Text      = "Barangay " +  barangay[championScoreIndex];
            lblChampionSlogan.Text    = teamSlogan[championScoreIndex];

            int highest = teamChampionScore[0];
            int secondHighest = teamChampionScore[1];

           for (int i = 1; i < teamChampionScore.Length; i++)
           {

               if (teamChampionScore[i] > highest)
               {

                   secondHighest = highest;
                   highest = teamChampionScore[i];



               }
               else if (teamChampionScore[i] > secondHighest)
               {
                   secondHighest = teamChampionScore[i];

               }
           }

           int largest = int.MinValue;
           int second = int.MinValue;
           foreach (int i in teamChampionScore)
           {
               if (i > largest)
               {
                   second = largest;
                   largest = i;
               }
               else if (i > second)
                   second = i;
           }

           int firstRunnerUp = Array.IndexOf(teamChampionScore, second);

           picFR.Image = team.Base64ToImage(teamLogo[firstRunnerUp]);
           lblFRTeamName.Text = teamName[firstRunnerUp];
           lblFRTbrgy.Text = "Barangay " + barangay[firstRunnerUp];
           lblFRTmotto.Text = teamSlogan[firstRunnerUp];
        }
        

        private void saveAwards()
        {
            var checkAward = AwardHelper.checkAward();

            foreach (var item in checkAward)
            {
                
                if(item.tournament.tournament_year == DateTime.Now.Year.ToString())
                {
                    return;
                }

            }


            string champion = lblChampionTeamName.Text;
            string frup = lblFRTeamName.Text;
            string mvp = lblmvpName.Text;
            string sf  = lblSFname.Text;
            string pf  = lblPFname.Text;
            string pg  = lblPGname.Text;
            string sg  = lblSGname.Text;
            string c   = lblCname.Text;

            Awards award = new Awards();
            award.awardChampionship = champion;
            award.awardFirstRunnerUp = frup;
            award.awardMVP = mvp;
            award.awardSF = sf;
            award.awardPF = pf;
            award.awardPG = pg;
            award.awardSG = sg;
            award.awardC  = c;

            var tournamentStatus = TournamentHelper.CheckTournamentStatus();
            foreach (var list in tournamentStatus)
            {
                award.tournament.tournament_id = list.tournament_id;
            }

             AwardHelper.SaveAwards(award);

             MessageBox.Show("Awards Successully Generated and Saved!","Awards",MessageBoxButtons.OK,MessageBoxIcon.Information);

        }

    }
}
