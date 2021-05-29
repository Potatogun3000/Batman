using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmScoreSheet : Form
    {

        int homeTeamId  = 0;
        int guestTeamId = 0;
        public frmScoreSheet(int htId , int gtId)
        {
            InitializeComponent();
            displayTournamentInfo();
            this.homeTeamId = htId;
            this.guestTeamId = gtId;
            homeTeam();
            guestTeam();

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

        private void homeTeam()
        {
            lvwHome.View = View.Details;
            lvwHome.GridLines = true;
            lvwHome.FullRowSelect = false;
            
            lvwHome.Columns.Add("PLAYER NAME", 235, HorizontalAlignment.Center);
            lvwHome.Columns.Add("POINTS", 60, HorizontalAlignment.Center);
            lvwHome.Columns.Add("REB", 50, HorizontalAlignment.Center);
            lvwHome.Columns.Add("ASST", 50, HorizontalAlignment.Center);
            lvwHome.Columns.Add("STEALS", 70, HorizontalAlignment.Center);
            lvwHome.Columns.Add("T.O.", 50, HorizontalAlignment.Center);
            lvwHome.Columns.Add("F.T.", 50, HorizontalAlignment.Center);
            lvwHome.Columns.Add("FOUL", 50, HorizontalAlignment.Center);
            lvwHome.Columns.Add("O.T.", 50, HorizontalAlignment.Center);

            SqlParameter[] ht = { new SqlParameter("@team_id", homeTeamId) };
            var homeTeam = MatchHelper.GetMatchPlayer(ht);
            ListViewItem item = null;

        
            foreach (var list in homeTeam)
            {
                item = lvwHome.Items.Add(list.player_jerseyNo + " - "+list.player_name +" ["+ list.position.position_desc+"]");

                lblHomeTeam.Text = list.team.team_name; 
            }
        }


        private void guestTeam()
        {
            lvwGuest.View = View.Details;
            lvwGuest.GridLines = true;
            lvwGuest.FullRowSelect = false;

            lvwGuest.Columns.Add("PLAYER NAME", 235, HorizontalAlignment.Center);
            lvwGuest.Columns.Add("POINTS", 60, HorizontalAlignment.Center);
            lvwGuest.Columns.Add("REB", 50, HorizontalAlignment.Center);
            lvwGuest.Columns.Add("ASST", 50, HorizontalAlignment.Center);
            lvwGuest.Columns.Add("STEALS", 70, HorizontalAlignment.Center);
            lvwGuest.Columns.Add("T.O.", 50, HorizontalAlignment.Center);
            lvwGuest.Columns.Add("F.T.", 50, HorizontalAlignment.Center);
            lvwGuest.Columns.Add("FOUL", 50, HorizontalAlignment.Center);
            lvwGuest.Columns.Add("O.T.", 50, HorizontalAlignment.Center);

            SqlParameter[] gt = { new SqlParameter("@team_id", guestTeamId) };
            var guestTeam = MatchHelper.GetMatchPlayer(gt);
            ListViewItem item = null;

            foreach (var list in guestTeam)
            {
                item = lvwGuest.Items.Add(list.player_jerseyNo + " - " + list.player_name + " [" + list.position.position_desc + "]");
               lblGuestTeam.Text = list.team.team_name; 
            }
            
        }

           Bitmap memoryImage;
           private void CaptureScreen()
           {
               Graphics myGraphics = this.CreateGraphics();
               Size s = this.Size;
               memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
               Graphics memoryGraphics = Graphics.FromImage(memoryImage);
               memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, 5, 80, s);
           }

           private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
           {
               e.Graphics.DrawImage(memoryImage, e.PageBounds);
           }

           private void btnPrint_Click(object sender, EventArgs e)
           {
               try
               {
                   CaptureScreen();
                   printDocument1.Print();
                   printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
               }
               catch (Exception)
               {
                   this.Close();
                  
               }

               this.Close();
           }

           private void btnClose_Click(object sender, EventArgs e)
           {
               this.Close();
           }


    }
}
