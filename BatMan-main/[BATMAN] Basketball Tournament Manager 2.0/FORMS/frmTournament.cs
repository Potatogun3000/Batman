using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmTournament : Form
    {
        Tournament tournament = null;
        public frmTournament(Tournament selectedTournament = null)
        {
            InitializeComponent();
            initializeTournamentInfo();
            this.tournament = selectedTournament;
            editTournament();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveTournament();
        }

        private void initializeTournamentInfo()
        {
            lblTournamentYear.Text = DateTime.Now.Year.ToString();
   

            dpkSched1.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            dpkSched1.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
       
            dpkSched2.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            dpkSched2.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            showSchedule();
        }

        private void saveTournament()
        {
            int tournamentId = tournament == null ? 0 : tournament.tournament_id;
            int month1  = dpkSched1.Value.Month,month2  = dpkSched2.Value.Month;
            int day1    = dpkSched1.Value.Day,day2    = dpkSched2.Value.Day;
            Tournament t = new Tournament()
            {   
                tournament_id       = tournamentId,
                tournament_year     = lblTournamentYear.Text,
                tournament_schedule = lblSchedule.Text,
                tournament_motto    = txtMotto.Text,
                tournament_status   = lblStatus.Text
            };
            
            if (t.tournamentValidation(month1,month2,day1,day2) == false) return;
      
            try
            {
                TournamentHelper.SaveTournament(t);
                t.tournamentStatusPrompt();
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }
        
        private void editTournament()
        { 
            if(tournament != null)
            {
                txtMotto.Text          = tournament.tournament_motto;
                lblSchedule.Text       = tournament.tournament_schedule;
                lblStatus.Text         = tournament.tournament_status;
                lblTournamentYear.Text = tournament.tournament_year;
                btnSave.Text           = "Update";
            }
        }
        private void dpkSched1_ValueChanged(object sender, EventArgs e) { showSchedule(); }
        private void dpkSched2_ValueChanged(object sender, EventArgs e) { showSchedule(); }
        

        private void showSchedule()
        {
            lblSchedule.Text = dpkSched1.Value.ToString("MMMM/dd/yyyy") + " to " + dpkSched2.Value.ToString("MMMM/dd/yyyy");

        }

        private void grpTournamentInfo_Enter(object sender, EventArgs e)
        {

        }

        private void frmTournament_Load(object sender, EventArgs e)
        {

        }
    }
}
