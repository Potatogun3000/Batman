using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using _BATMAN__Basketball_Tournament_Manager_2._0.FORMS;
using Microsoft.VisualBasic.PowerPacks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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

namespace _BATMAN__Basketball_Tournament_Manager_2._0
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
            initTournamentInfo();
            initButtons();
            checkAwards();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch ((int)button.Tag)
            {
                case 1:
                    ceateTournament();
                    break;
                case 2:
                    tournamentList();
                    break;
                case 3:
                    registerGameOfficial();
                    break;
                case 4:
                    printTournamentSignupSheet();
                    break;
                case 5:
                    registerTeam();
                    break;
                case 6:
                    teamList();
                    break;
                case 7:
                    teamOfficialList();
                    break;
                case 8:
                    playerList();
                    break;
                case 9:
                    createMatch();
                    break;
                case 10:
                    matchList();
                    break;
                case 11:
                    GenerateAward();
                    break;
                case 12:
                    awardHistory();
                    break;
            }
        }

        
        private void initButtons()
        {
            btnCreateTournament.Tag = 1;
            btnTournamentList.Tag = 2;
            btnRegisterGameOfficial.Tag = 3;
            btnPrintTournamentSignUpSheet.Tag = 4;
            btnRegisterTeam.Tag = 5;
            btnTeamList.Tag = 6;
            btnTeamOfficialList.Tag = 7;
            btnPlayerList.Tag = 8;
            btnCreateMatch.Tag = 9;
            btnMatchList.Tag = 10;
            btnGenerateAward.Tag = 11;
            btnAwardHistory.Tag = 12; 
                
            btnCreateTournament.Click             += ButtonClick;
            btnTournamentList.Click               += ButtonClick;
            btnRegisterGameOfficial.Click         += ButtonClick;
            btnPrintTournamentSignUpSheet.Click   += ButtonClick;
            btnRegisterTeam.Click                 += ButtonClick;
            btnTeamList.Click                     += ButtonClick;
            btnTeamOfficialList.Click             += ButtonClick;
            btnPlayerList.Click                   += ButtonClick;
            btnCreateMatch.Click                  += ButtonClick;
            btnMatchList.Click                    += ButtonClick;
            btnGenerateAward.Click                += ButtonClick;
            btnAwardHistory.Click                 += ButtonClick;
        }

        private void ceateTournament()
        {   
            Tournament checkTournamentStatus = new Tournament();
            if (checkTournamentStatus.tournamentCheckStatus() == false) { initTournamentInfo(); return; };
            
            frmTournament tournament = new frmTournament();
            tournament.ShowDialog();
            initTournamentInfo();    
        }
       
        private void tournamentList()
        {   
            frmTournamentList tournamentList = new frmTournamentList();
            tournamentList.ShowDialog();
            initTournamentInfo();
        }
        
        private void registerGameOfficial()
        {
            frmGameOfficials gameOfficials = new frmGameOfficials();
            gameOfficials.ShowDialog();
        }
        
        private void printTournamentSignupSheet()
        {
            Tournament tournamentRegistrationValidation = new Tournament();
            if (tournamentRegistrationValidation.tournamentRegistrationValidation() == false) return;

            frmSignupSheet sheet = new frmSignupSheet();
            sheet.ShowDialog();
        }

        private void registerTeam()
        {
            Tournament tournamentRegistrationValidation = new Tournament();
            if (tournamentRegistrationValidation.tournamentRegistrationValidation() == false) return;
            frmRegistration register = new frmRegistration();
            register.ShowDialog();
        }

        private void teamList()
        {
           frmTeamList teamlist = new frmTeamList();
           teamlist.ShowDialog();
           initTournamentInfo(); 
        }


        private void teamOfficialList()
        {
            frmTeamOfficialList teamOfficialList = new frmTeamOfficialList();
            teamOfficialList.ShowDialog();
        }

        private void playerList()
        {
            frmPlayerList playerList = new frmPlayerList();
            playerList.ShowDialog();
       }

       private void createMatch()
        {
            Tournament tournament = new Tournament();
            if (tournament.ifActiveValidation() == false) return;

            Match match = new Match();
            if (match.checkIfMatchCreated() == false) return;
            
           frmCreateMatch createMatch = new frmCreateMatch();
            createMatch.ShowDialog();
        }

       private void matchList()
       {    
           frmMatchList matchList = new frmMatchList();
           matchList.ShowDialog();
       
       }

       private void GenerateAward()
       {    
           Tournament tournament = new Tournament();
           if (tournament.ifCloseValidation() == false) return;
      
           frmAwards awards = new frmAwards();
           awards.ShowDialog();

           checkAwards(); 

       }
        
       private void checkAwards()
       {
           var checkAward = AwardHelper.checkAward();

           foreach (var item in checkAward)
           {
               if (item.tournament.tournament_year == DateTime.Now.Year.ToString())
               {
                   btnGenerateAward.Text = "Awardees";
               }
           }
       }
     
        private void awardHistory()
       {
           frmAwardHistory awardHistory = new frmAwardHistory();
           awardHistory.ShowDialog();
       }

       private void initTournamentInfo()
       {
           lblStatus.Text = "Tournament is Open";
           lblSchedule.Text = "";
           lblMotto.Text = "";


           ovalIndicator.FillStyle = FillStyle.Solid;
           ovalIndicator.FillGradientStyle = FillGradientStyle.Central;
           ovalIndicator.FillColor = Color.Black;
           ovalIndicator.FillGradientColor = Color.White;

           var checkTournamentList = TournamentHelper.CheckTournamentStatus();
           foreach (var list in checkTournamentList)
           {
               lblStatus.Text = list.tournament_status;
               lblYear.Text = list.tournament_year;
               lblMotto.Text = list.tournament_motto;
               lblSchedule.Text = list.tournament_schedule;
               btnCreateTournament.Text = "Create Tournament";
               btnCreateTournament.BackColor = Color.Blue;


               if (list.tournament_status == "Open")
               {
                   lblStatus.Text = "Registration is in Progress."; ovalIndicator.FillColor = Color.Blue; ovalIndicator.FillGradientColor = Color.Blue;
                   btnCreateTournament.Text = "Activate Tournament";
                   btnCreateTournament.BackColor = Color.YellowGreen;
               }
               if (list.tournament_status == "Active")
               {
                   lblStatus.Text = "Tournament is Started and On going."; ovalIndicator.FillColor = Color.Green; ovalIndicator.FillGradientColor = Color.LightGreen;
                   btnCreateTournament.Text = "Close Tournament";
                   btnCreateTournament.BackColor = Color.Red;

               }
               if (list.tournament_status == "Closed")
               {
                   lblStatus.Text = "Tournament is Closed"; ovalIndicator.FillColor = Color.Red; ovalIndicator.FillGradientColor = Color.Red;
               }
           }
       }

     }
}
