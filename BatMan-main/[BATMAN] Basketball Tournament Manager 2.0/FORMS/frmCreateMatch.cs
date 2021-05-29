using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0
{
    public partial class frmCreateMatch : Form
    {
        public frmCreateMatch()
        {
            InitializeComponent();
            loadTournamentInfo();
            loadMatchInfo();
        }
      
        private void btnGenerateMatch_Click(object sender, EventArgs e)
        {
            generateMatch();
        }

        private void btnSaveMatch_Click(object sender, EventArgs e)
        {
            saveMatch();
        }


        private void loadMatchInfo()
        {

            lvwMatch.View = View.Details;
            lvwMatch.GridLines = true;
            lvwMatch.FullRowSelect = true;
            lvwMatch.MultiSelect = false;
            lvwMatch.HideSelection = false;

            lvwMatch.Columns.Add("Round No.", 90, HorizontalAlignment.Center);
            lvwMatch.Columns.Add("Game No.", 90, HorizontalAlignment.Center);
            lvwMatch.Columns.Add("Home Team", 160, HorizontalAlignment.Center);
            lvwMatch.Columns.Add(" ", 50, HorizontalAlignment.Center);
            lvwMatch.Columns.Add("Guest Team", 160, HorizontalAlignment.Center);
            lvwMatch.Columns.Add("Venue", 100, HorizontalAlignment.Center);
            lvwMatch.Columns.Add("Referee 1", 180, HorizontalAlignment.Center);
            lvwMatch.Columns.Add("Referee 2", 180, HorizontalAlignment.Center);

        }

        private void loadTournamentInfo()
        {
            var checkTournamentList = TournamentHelper.CheckTournamentStatus();
            string year = "", sched = "" , motto = "";

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


         string[] Teams  = new string[0];
         private void generateMatch()
        {
            ListViewItem listMatch = null;
            lvwMatch.Items.Clear();
                   
                   //MessageBox.Show("Match Successfully Generated!", "Match", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   //Get Game Official and Venue
                   string[] venue = { "JMR Coliseum", "Plaza Quezon" };
                   int countGameOfficial = 0;
                   var gameOfficial = GameOfficialsHelper.GetGameOfficialReferee();
                   foreach (var item in gameOfficial)
                   {
                       countGameOfficial++;
                   }
                   string[] gameOfficialName = new string[countGameOfficial];

                   int storeGameOfficial = 0;
                   foreach (var item in gameOfficial)
                   {
                       gameOfficialName[storeGameOfficial] = item.gameofficialName;
                       storeGameOfficial++;
                   }
                   string randomVenue = venue[new Random().Next(0, venue.Length)];

                   //


                   //Count Team and Get Team store to 1d Array
                   var team = TeamHelper.getTeamForMatch();
                   int noTeams = 0;
                   int countTeam = 0;

                   foreach (var list in team)
                   {
                       countTeam++;
                   }

                   //is Even
                   int ctr = 0;
                   if (countTeam % 2 == 0)
                       noTeams = countTeam;
                   else
                   {
                       ctr = 1;
                       noTeams = countTeam + 1;
                   }

                   string[] teamName = new string[noTeams];
                   foreach (var item in team)
                   {
                       teamName[ctr] = item.team_name;
                       ctr++;
                   }

                   //
                   int roundNo = noTeams - 1;
                   int gameNo = noTeams / 2;
                   int participatingTeams = noTeams - 1;
                   int rotation = 1;


                   Teams = new string[noTeams];
                   string[] matchingTeams = new string[noTeams];


                   //Storing on the Array
                   for (int i = 0; i < noTeams; i++)
                   {
                       //Check if Even
                       if (countTeam % 2 == 0)
                       {
                           Teams[i] = teamName[i];
                       }
                       else
                       {
                           if (Teams[i] == Teams[0])
                           {
                               Teams[i] = "bye";
                           }
                           else Teams[i] = teamName[i];
                       }
                   }

                   int gm = 0;
                   string isVenueExisting = "";
                   //Initializing Round Robin
                   int r = 0;
                   for (int round = 0; round < roundNo; round++)
                   {

                       listMatch = lvwMatch.Items.Add((round + 1).ToString());
                       listMatch.SubItems.Add("-");
                       listMatch.SubItems.Add("-");
                       listMatch.SubItems.Add("-");
                       listMatch.SubItems.Add("-");
                       listMatch.SubItems.Add("-");
                       listMatch.SubItems.Add("-");
                       listMatch.SubItems.Add("-"); 

                       if (round == 0)
                       {
                           for (int teamCtr = 0; teamCtr < noTeams; teamCtr++)
                           {
                               matchingTeams[teamCtr] = Teams[teamCtr];
                           }
                       }
                       else
                       {
                           for (int teamCtr = 0; teamCtr < noTeams; teamCtr++)
                           {
                               matchingTeams[(teamCtr + rotation) % noTeams] = Teams[teamCtr];
                           }
                           SwapString(matchingTeams, 0, 1);
                       }

                       for (int teamCtr = 0; teamCtr < noTeams; teamCtr++)
                       {
                           Teams[teamCtr] = matchingTeams[teamCtr];
                       }

                       int vs = participatingTeams;
                       
                       for (int pteamCtr = 0; pteamCtr < gameNo; pteamCtr++)
                       {
                           listMatch = lvwMatch.Items.Add("-");
                           listMatch.SubItems.Add(Convert.ToString(gm + pteamCtr+1));
                           listMatch.SubItems.Add(Teams[pteamCtr]);
                           listMatch.SubItems.Add("VS");
                           listMatch.SubItems.Add(Teams[vs]);

                           //Venue
                           while (randomVenue == isVenueExisting)
                           {
                               randomVenue = venue[new Random().Next(0, venue.Length)];
                           }

                           listMatch.SubItems.Add(randomVenue);
                           isVenueExisting = randomVenue;

                           //Referees
                           string isGOExisting = gameOfficialName[new Random().Next(0, gameOfficialName.Length)];
                           for (int i = 0; i < 2; i++)
                           {
                               string randomGO = gameOfficialName[new Random().Next(0, gameOfficialName.Length)];

                               while (randomGO == isGOExisting)
                               {
                                   randomGO = gameOfficialName[new Random().Next(0, gameOfficialName.Length)];
                               }
                               listMatch.SubItems.Add(randomGO);
                               isGOExisting = randomGO;
                           }

                           listMatch.SubItems.Add(isGOExisting);
                           
                           vs--;
                           r++;
                       }

                       gm = gm + gameNo;
                       
                   }
        }

        public void saveMatch()
        {
            if (lvwMatch.Items.Count == 0)
            {
                MessageBox.Show("Please Generate First The Matches.", "Matches", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string msg = "Do you want to Save the Generated Game Schedules? Once You Save it. You can't change it or Generate another Schedule for This Year Tournament.";
            if (MessageBox.Show(msg, "Game Schedules", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.No)
                return;

            int countMatch = lvwMatch.Items.Count;
            var team = TeamHelper.getTeamForMatch();

            int noTeams = 0;
            int countTeam = 0;

            foreach (var list in team)
            {
                countTeam++;
            }


            if (countTeam % 2 == 0)
                noTeams = countTeam;
            else
            {
                noTeams = countTeam + 1;
            }

            string roundNo;
            string gameNo;
            string homeTeam;
            string guestTeam;
            string venue;
            string ref1;
            string ref2;
            int gNo = noTeams / 2;

            int rNo = 0;
            for (int i = 0; i < countMatch; i++)
            {
                    roundNo   = lvwMatch.Items[i].SubItems[0].Text;
                    gameNo    = lvwMatch.Items[i].SubItems[1].Text;
                    homeTeam  = lvwMatch.Items[i].SubItems[2].Text;
                    guestTeam = lvwMatch.Items[i].SubItems[4].Text;
                    venue     = lvwMatch.Items[i].SubItems[5].Text;
                    ref1      = lvwMatch.Items[i].SubItems[6].Text;
                    ref2      = lvwMatch.Items[i].SubItems[7].Text;
                    

                    if(roundNo != "-")
                    {
                        rNo = Convert.ToInt32(lvwMatch.Items[i].SubItems[0].Text);
                    }
                        
                    if (roundNo == "-")
                    {
                        Match match = new Match();
                        match.match_gameNo    = Convert.ToInt32(gameNo);
                        match.match_homeTeam.team_name  = homeTeam;
                        match.match_guestTeam.team_name = guestTeam;
                        match.match_venue = venue;
                        match.match_referee1.gameofficialName = ref1;
                        match.match_referee2.gameofficialName = ref2;
                        match.match_status   = "NOT STARTED";
                            
                        var tournamentStatus = TournamentHelper.CheckTournamentStatus();
                        foreach (var list in tournamentStatus)
                        {
                            match.tournament.tournament_id = list.tournament_id;
                        }
                        MatchHelper.SaveMatch(match);
                    }
              }

             MessageBox.Show("Matches Successfully Save!", "Matches", MessageBoxButtons.OK, MessageBoxIcon.Information);
             this.Close();
        }

        public void SwapString(string[] array, int position1, int position2)
        {
            string temp = array[position1]; // Copy the first position's element
            array[position1] = array[position2]; // Assign to the second element
            array[position2] = temp; // Assign to the first element
        }
    
    }
}
