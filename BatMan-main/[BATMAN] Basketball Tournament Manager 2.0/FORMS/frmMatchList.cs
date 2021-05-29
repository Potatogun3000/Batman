using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
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
    public partial class frmMatchList : Form
    {
        public frmMatchList()
        {
            InitializeComponent();
            loadTournamentYear();
            matchInfo();
            matchList();
        }

        private void btnGameSchedule_Click(object sender, EventArgs e)
        {
            gameSchedule();
        }

        private void btnPrintScoreSheet_Click(object sender, EventArgs e)
        {
            scoreSheet(); 
        }

        private void btnRecordResults_Click(object sender, EventArgs e)
        {
            recordResult();
        }

         private void btnViewResult_Click(object sender, EventArgs e)
        {
            viewResults();
        }

        private void matchInfo()
        {
            lvwMatchList.View = View.Details;
            lvwMatchList.GridLines = true;
            lvwMatchList.FullRowSelect = true;
      
            lvwMatchList.Columns.Add("Match Id", 0);
            lvwMatchList.Columns.Add("Game  No.", 90, HorizontalAlignment.Center);
            lvwMatchList.Columns.Add("Home Team", 150, HorizontalAlignment.Center);
            lvwMatchList.Columns.Add("", 40, HorizontalAlignment.Center);
            lvwMatchList.Columns.Add("Guest Team", 150, HorizontalAlignment.Center);
            lvwMatchList.Columns.Add("Referee 1", 150, HorizontalAlignment.Center);
            lvwMatchList.Columns.Add("Referee 2", 150, HorizontalAlignment.Center);
            lvwMatchList.Columns.Add("Venue", 100, HorizontalAlignment.Center);
            lvwMatchList.Columns.Add("Status", 100, HorizontalAlignment.Center);
        }

        private void loadTournamentYear(){
            cmbTournamentYear.DataSource      =  TournamentHelper.GetTournamentList();
            cmbTournamentYear.DisplayMember   = "tournament_year";
            cmbTournamentYear.ValueMember     = "tournament_id"; 
        }

        private void matchList()
        {
            var matchList = MatchHelper.LoadMatchList();
            ListViewItem items = null;
            lvwMatchList.Items.Clear();
            foreach (var match in matchList)
            {
                items = lvwMatchList.Items.Add(match.match_id.ToString());
                items.SubItems.Add(match.match_gameNo.ToString());
                items.SubItems.Add(match.match_homeTeam.team_name);
                items.SubItems.Add("VS");
                items.SubItems.Add(match.match_guestTeam.team_name);
                items.SubItems.Add(match.match_referee1.gameofficialName);
                items.SubItems.Add(match.match_referee2.gameofficialName);
                items.SubItems.Add(match.match_venue);
                items.SubItems.Add(match.match_status);
            }
        }


        private void cmbTournamentYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlParameter[] p =  {
            new SqlParameter("@tournament_year", cmbTournamentYear.Text)
            };
            var matchList = MatchHelper.GetMatchList(p);
            ListViewItem items = null;
  
            lvwMatchList.Items.Clear();
            foreach (var match in matchList)
            {
                items = lvwMatchList.Items.Add(match.match_id.ToString());
                items.SubItems.Add(match.match_gameNo.ToString());
                items.SubItems.Add(match.match_homeTeam.team_name);
                items.SubItems.Add("VS");
                items.SubItems.Add(match.match_guestTeam.team_name);
                items.SubItems.Add(match.match_referee1.gameofficialName);
                items.SubItems.Add(match.match_referee2.gameofficialName);
                items.SubItems.Add(match.match_venue);
                items.SubItems.Add(match.match_status);
            }
        }

       
        private void gameSchedule()
        {
            
            if(lvwMatchList.Items.Count == 0)
            { 
             MessageBox.Show(cmbTournamentYear.Text+" Does not have a Schedules! Please Create First the Matches.", "Game Schedules", MessageBoxButtons.OK, MessageBoxIcon.Error);
             return;
            }

            string msg = "Export to Excel" + cmbTournamentYear.Text + "  Game Schedules?";
            if (MessageBox.Show(msg, "Game Schedules", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.No)
                return;

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "*Excel File|.xlsx";
            saveFileDialog1.Title = "Save an Excel File";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
               (System.IO.FileStream)saveFileDialog1.OpenFile();

                using (ExcelPackage package = new ExcelPackage(fs))
                {
                    ExcelWorksheet ws = package.Workbook.Worksheets.Add("Game Schedules");

                    var tournament = TournamentHelper.CheckTournamentStatus();
                    string year = "", schedule = "";

                    foreach (var list in tournament)
                    {
                        year = list.tournament_year;
                        schedule = list.tournament_schedule;
                    }


                    ws.Cells["D2"].Value = year + " Inter-Barangay Basketball Tournament";
                    ws.Cells["D3"].Value = schedule;
                    ws.Cells["D5"].Value = "GAME SCHEDULES";
                    ws.Cells["D5"].Style.Font.Size = 14;
                    ws.Cells["D5"].Style.Font.Bold = true;


                    ws.Cells["D2:F2"].Merge = true;
                    ws.Cells["D3:F3"].Merge = true;
                    ws.Cells["D5:F5"].Merge = true;


                    ws.Cells["D2"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["D3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    ws.Cells["D5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                    ws.Cells["B7"].Value = "No.";
                    ws.Cells["C7"].Value = "Game";
                    ws.Cells["D7"].Value = "Home Team";
                    ws.Cells["E7"].Value = "vs";
                    ws.Cells["F7"].Value = "Guest Team";
                    ws.Cells["G7"].Value = "Time";
                    ws.Cells["B7:G7"].Style.Font.Bold = true;
                    ws.Cells["B7:G7"].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    ws.Cells["B7:G7"].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.WhiteSmoke);
                    ws.Cells[string.Format("B7:G7")].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);

                    ws.Cells["B7:G7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                    ws.Column(3).Width = 20;
                    ws.Column(4).Width = 30;
                    ws.Column(5).Width = 20;
                    ws.Column(5).Width = 5;
                    ws.Column(6).Width = 30;
                    ws.Column(7).Width = 20;


                    int startRow = 8;
                    for (int i = 0; i < lvwMatchList.Items.Count; i++)
                    {
                        
                        string gameNo     = lvwMatchList.Items[i].SubItems[1].Text;
                        string homeTeam   = lvwMatchList.Items[i].SubItems[2].Text;
                        string guestTeam  = lvwMatchList.Items[i].SubItems[4].Text;

                        ws.Cells[string.Format("B{0}", startRow)].Value = i+1;
                        ws.Cells[string.Format("B{0}", startRow)].Style.Font.Bold = true;
                        
                        ws.Cells[string.Format("C{0}", startRow)].Value = gameNo;
                        ws.Cells[string.Format("D{0}", startRow)].Value = homeTeam;
                        ws.Cells[string.Format("E{0}", startRow)].Value = "vs";
                        ws.Cells[string.Format("F{0}", startRow)].Value = guestTeam;

                        ws.Cells[string.Format("B{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        ws.Cells[string.Format("C{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        ws.Cells[string.Format("D{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        ws.Cells[string.Format("E{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        ws.Cells[string.Format("F{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                        ws.Cells[string.Format("G{0}", startRow)].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                       
                        ws.Cells[string.Format("B{0}:G{0}", startRow)].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        startRow++;
                    }

                    package.Save();
                }

                MessageBox.Show("Game Schedules Sucessfully Saved!", "Game Schedules", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void scoreSheet()
        {
            if (lvwMatchList.Items.Count == 0 || lvwMatchList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Match!","Score Sheet",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
                
            int si = lvwMatchList.SelectedItems[0].Index;

            string homeTeam   = lvwMatchList.Items[si].SubItems[2].Text;
            string guestTeam  = lvwMatchList.Items[si].SubItems[4].Text;
            int    matchId    = Convert.ToInt32(lvwMatchList.Items[si].SubItems[0].Text);
            string status = lvwMatchList.Items[si].SubItems[8].Text;

            if (status == "ENDED")
            {
                MessageBox.Show("You can't Print Scoree sheet for Match " + homeTeam + " VS " + guestTeam + " This  match is Already Ended!", "Score Sheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlParameter[] ht = { new SqlParameter("@team_name", homeTeam)  };
            SqlParameter[] gt = { new SqlParameter("@team_name", guestTeam) };

            var sqlhomeTeamId  = MatchHelper.GetTeamId(ht);
            var sqlguestTeamId = MatchHelper.GetTeamId(gt);
            int htId = 0 , gtId = 0;

            foreach (var item in sqlhomeTeamId)
            {
                htId = item.team_id;
            }

            foreach (var item in sqlguestTeamId)
            {
                gtId = item.team_id;
            }

            frmScoreSheet scoreSheet = new frmScoreSheet(htId,gtId);
            scoreSheet.ShowDialog();

            Match match = new Match();
            match.match_id = matchId;
            match.match_status = "IN PROGRESS";
            MatchHelper.UpdateMatchStatus(match);

            MessageBox.Show("Match Between "  +homeTeam + " VS " + guestTeam +" is In Progress", "Score Sheet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            matchList();  
        }

        private void recordResult()
        {
            if (lvwMatchList.Items.Count == 0 || lvwMatchList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Match!", "Score Sheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int    si        = lvwMatchList.SelectedItems[0].Index;
            int    matchId   = Convert.ToInt32(lvwMatchList.Items[si].SubItems[0].Text);
            string status    = lvwMatchList.Items[si].SubItems[8].Text;
            string homeTeam  = lvwMatchList.Items[si].SubItems[2].Text;
            string guestTeam = lvwMatchList.Items[si].SubItems[4].Text;

            if (status == "NOT STARTED")
            {
                MessageBox.Show("Please Print First The Score Sheet for  Match " + homeTeam + " VS " + guestTeam , "Record Result!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (status == "ENDED")
            {
                MessageBox.Show("The  Match for" + homeTeam + " VS " + guestTeam + " Already Recorded!", "Record Result!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
   
            SqlParameter[] ht = { new SqlParameter("@team_name", homeTeam) };
            SqlParameter[] gt = { new SqlParameter("@team_name", guestTeam) };

            var sqlhomeTeamId  = MatchHelper.GetTeamId(ht);
            var sqlguestTeamId = MatchHelper.GetTeamId(gt);
            int htId = 0, gtId = 0;

            foreach (var item in sqlhomeTeamId)
            {
                htId = item.team_id;
            }

            foreach (var item in sqlguestTeamId)
            {
                gtId = item.team_id;
            }
            
            frmRecordStats recordStats = new frmRecordStats(htId, gtId, matchId);
            recordStats.ShowDialog();
            matchList();
        }

        private void viewResults()
        {
            if (lvwMatchList.Items.Count == 0 || lvwMatchList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Match!", "Score Sheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int    si       = lvwMatchList.SelectedItems[0].Index;
            int    matchId  = Convert.ToInt32(lvwMatchList.Items[si].SubItems[0].Text);
            string status   = lvwMatchList.Items[si].SubItems[8].Text;
                
            if(status != "ENDED")
            {
                MessageBox.Show("You Need To Record First This Match", "Match Result", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmMatchResults matchResults = new frmMatchResults(matchId);
            matchResults.ShowDialog();
        }

    }
}
