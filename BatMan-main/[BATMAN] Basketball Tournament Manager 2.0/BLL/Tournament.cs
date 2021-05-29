using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.BLL
{
    public class Tournament
    {
        public int     tournament_id             { get; set; }
        public string  tournament_year           { get; set; }
        public string  tournament_schedule       { get; set; }
        public string  tournament_motto          { get; set; }
        public string  tournament_status         { get; set; }
 

        public bool tournamentValidation(int month1 , int month2 , int day1 , int day2)
        {
            bool   validate = true;
            string status = null;

            if (tournament_motto.Length == 0){MessageBox.Show("Please Input the Tournament's Motto", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (tournament_schedule.Length == 0){MessageBox.Show("Please Input the Tournament's Schedule", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (month1 > month2 || month1 == month2 && day1 == day2 || month1 == month2 && day1 > day2) {MessageBox.Show("Schedule is Wrong, The Second Month Can't be Greater than the 1st Month", "Schedule", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (tournament_status.Length == 0){MessageBox.Show("Please Input the Tournament's Status", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
      
            
               var checkStatus = TournamentHelper.CheckTournamentStatus();
               foreach (var list in checkStatus)
               {
                   status =  list.tournament_status;
               }

             if (tournament_status == "Active" && status != "Open" || tournament_status == "Closed" && status !="Open") { MessageBox.Show("Open First the Tournament!", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }   
              
             return validate;
         }
    
         public void tournamentStatusPrompt()
         {      
                var prompt = TournamentHelper.CheckTournamentStatus();
                foreach (var list in prompt)
	            {       
                    if(list.tournament_status == "Open"){MessageBox.Show("[TOURNAMENT IS OPEN!] - Registration is in progress.", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                    if(list.tournament_status == "Active"){MessageBox.Show("[TOURNAMENT IS ACTIVE!] - Tournament started and is on going.", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information);}
                    if(list.tournament_status == "Closed"){ MessageBox.Show("[TOURNAMENT IS CLOSED!] - Tournament has ended.", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information);}
	            }
         }

        public bool tournamentCheckStatus()
        {
            var check = TournamentHelper.CheckTournamentStatus();
            string status = "";

            foreach (var list in check)
                {
                    status = list.tournament_status;
                }

            if(status == "Open")
            {

             var checkGameOfficial = GameOfficialsHelper.GetGameOfficialList();
             int countGO = 0;
             foreach (var item in checkGameOfficial)
                {
                    countGO++;
                }

              if (countGO == 0)
                {
                    MessageBox.Show("You can't Set The Tournament to ACTIVE, Without a Game Official Please Add Game Official.", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
                }


            var checkRoasterTeam = TeamHelper.checkRoasterTeamList();
            int counter = 0;
            string teamName = "";
            foreach (var team in checkRoasterTeam)
            {
                teamName = team.team_name;
                counter++;
            }
            if (counter <= 1) { MessageBox.Show("You can't Set The Tournament to ACTIVE, Without a Team or a Team without atleast 1 Opponent.", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false; }

            int tournament_id = 0;
            string tournament_status = "Active";
            var getLatestTournament = TournamentHelper.GetTournamentLatestRecord();

            foreach (var list in getLatestTournament)
            {
                tournament_id = list.tournament_id;
            }

            Tournament tournament           = new Tournament();
            tournament.tournament_id        = tournament_id;
            tournament.tournament_status    = tournament_status;
            TournamentHelper.UpdateTournamentStatus(tournament);
            tournamentStatusPrompt();
            return false;
            }
        
            if(status == "Active")
            {
                var match = MatchHelper.LoadMatchList();

                foreach (var item in match)
                {
                    if (item.match_status == "NOT STARTED" || item.match_status == "ON GOING")
                    { MessageBox.Show("You can't Set The Tournament to Close! You need to Record first all Matches.", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Warning);  return false; }
                }

                int tournament_id = 0;
                string tournament_status = "Closed";
                var getLatestTournament = TournamentHelper.GetTournamentLatestRecord();

                foreach (var list in getLatestTournament)
                {
                    tournament_id = list.tournament_id;
                }

                Tournament tournament = new Tournament();
                tournament.tournament_id = tournament_id;
                tournament.tournament_status = tournament_status;
                TournamentHelper.UpdateTournamentStatus(tournament);
                tournamentStatusPrompt();
                return false;
            }
            if(status == "Closed")
            {
                MessageBox.Show("Tournament is still Closed, the Tournament will be Open Once a year.", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Warning); return false;
            }

            return true;
	    }

        public bool tournamentRegistrationValidation()
        {
            bool validate = true;
            string status = null;

            var checkStatus = TournamentHelper.CheckTournamentStatus();
            foreach (var list in checkStatus)
            {
                status = list.tournament_status;
            }

            if (status != "Open" && status !="Active" ){ MessageBox.Show("Create First, This " + DateTime.Now.Year.ToString() + " Tournament." , "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (status == "Active") { MessageBox.Show("Tournament is already Active and On going You can't Register, Edit and Delete The Tournament or any Teams , Players ,Team Official and Game Officials", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (status == "Closed") { MessageBox.Show("Tournament is already Closed and On going You can't Register, Edit and Delete The Tournament or any Teams , Players ,Team Official and Game Officials", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }

            return validate;
        }

        public bool CRUDValidation()
        {
            bool validate = true;
            string status = null;

            var checkStatus = TournamentHelper.CheckTournamentStatus();
            foreach (var list in checkStatus)
            {
                status = list.tournament_status;
            }

            if (status == "Active") { MessageBox.Show("Tournament is already Active and On going You can't Register, Edit and Delete The Tournament or any Teams , Players ,Team Official and Game Officials", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (status == "Closed") { MessageBox.Show("Tournament is already Closed and On going You can't Register, Edit and Delete The Tournament or any Teams , Players ,Team Official and Game Officials", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            return validate;
        }


        public bool ifActiveValidation()
        {
            bool validate = true;
            string status = null;

            var checkStatus = TournamentHelper.CheckTournamentStatus();
            foreach (var list in checkStatus)
            {
                status = list.tournament_status;
            }

            if (status != "Active") { MessageBox.Show("You Need To Activate First The Tournament.", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            return validate;
        }

        public bool ifCloseValidation()
        {
            bool validate = true;
            string status = null;

            var checkStatus = TournamentHelper.CheckTournamentStatus();
            foreach (var list in checkStatus)
            {
                status = list.tournament_status;
            }

            if (status != "Closed") { MessageBox.Show("You Need To Close First The Tournament. Before Generating the Awards", "Tournament", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            return validate;
        }




        public void importToExcel(int tournament_id)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "*Excel File|.xlsx";
            saveFileDialog1.Title  = "Save an Excel File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                 System.IO.FileStream fs =
                (System.IO.FileStream)saveFileDialog1.OpenFile();
                
                using (ExcelPackage package = new ExcelPackage(fs))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("Team Roster Form");


                    SqlParameter[] team = { new SqlParameter("@tournament_id", tournament_id), };
                    SqlParameter[] player = { new SqlParameter("@tournament_id", tournament_id), };

                    var teamRoster = TeamHelper.getRosterTeamList(team);
                    var playerRoster = TeamHelper.getRosterPlayerList(player);
                    string year = "", schedule = "";

                    foreach (var list in teamRoster)
                    {
                        year = list.tournament.tournament_year;
                        schedule = list.tournament.tournament_schedule;
                    }


                    ws.Cells["D1"].Value = year + " Inter-Barangay Basketball Tournament";
                    ws.Cells["D2"].Value = schedule;
                    ws.Cells["D5"].Value = "OFFICIAL TEAM ROSTER FORM";
                    ws.Cells["D5"].Style.Font.Bold = true;
                    ws.Cells["D1:E1"].Merge = true;
                    ws.Cells["D2:E2"].Merge = true;
                    ws.Cells["D5:E5"].Merge = true;


                    ws.Cells["D1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["D5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["D2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells["B8"].Value = "No.";
                    ws.Cells["C8"].Value = "Team Name";
                    ws.Cells["D8"].Value = "Coach";
                    ws.Cells["E8"].Value = "Jersey No.";
                    ws.Cells["F8"].Value = "Players";
                    ws.Cells["B8:F8"].Style.Font.Bold = true;

                    ws.Column(3).Width = 20;
                    ws.Column(4).Width = 30;
                    ws.Column(5).Width = 20;
                    ws.Column(6).Width = 30;

                    ws.Cells["B8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["C8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["D8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["E8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["F8"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Cells["B8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    ws.Cells["C8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    ws.Cells["D8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    ws.Cells["E8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    ws.Cells["F8"].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);


                    int startRow = 9;
                    int teamOffRow = 9;
                    int playerRow = 9;
                    int ctr = 0;
                    string playerName = "";
                    string teamName = "";
                    string jerseyNo = "";

                    foreach (var list in teamRoster)
                    {       
                        ws.Cells[string.Format("B{0}", startRow)].Value = (++ctr).ToString();
                        ws.Cells[string.Format("C{0}", startRow)].Value = list.team_name;

                        ws.Cells[string.Format("B{0}", startRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        ws.Cells[string.Format("C{0}", startRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        ws.Cells[string.Format("B{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        ws.Cells[string.Format("C{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                        string[] tOName = list.teamOfficial.teamOfficial_name.Split(',');
                        foreach (var item in tOName)
                        {

                            ws.Cells[string.Format("D{0}", teamOffRow)].Value = item;
                            ws.Cells[string.Format("D{0}", teamOffRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                            ws.Cells[string.Format("D{0}", teamOffRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        }

                        foreach (var item in playerRoster)
                        {
                            teamName = item.team.team_name;
                            jerseyNo = item.player_jerseyNo;
                            playerName = item.player_name;

                            if (list.team_name == teamName)
                            {
                                ws.Cells[string.Format("E{0}", playerRow)].Value = jerseyNo;
                                ws.Cells[string.Format("F{0}", playerRow)].Value = playerName;

                                ws.Cells[string.Format("E{0}", playerRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                ws.Cells[string.Format("F{0}", playerRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                                ws.Cells[string.Format("B{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                ws.Cells[string.Format("C{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                ws.Cells[string.Format("D{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                ws.Cells[string.Format("E{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                                ws.Cells[string.Format("F{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                                playerRow++;
                                teamOffRow++;
                                startRow++;
                            }
                        }
                    }
                    package.Save();
                }

                MessageBox.Show("Team Roster Form Sucessfully Saved!", "Team Roster Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    
    }


}
