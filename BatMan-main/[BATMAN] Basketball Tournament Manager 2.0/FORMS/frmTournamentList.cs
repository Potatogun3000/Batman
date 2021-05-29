using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using Microsoft.VisualBasic.PowerPacks;
using System.Data.SqlClient;
namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmTournamentList : Form
    {
        List<Tournament> listTournament = null;

        public frmTournamentList()
        {
            InitializeComponent();
            initButtons();
            initTournamentList();
            loadTournamentList();
            initTournamentInfo(); 
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch ((int)button.Tag)
            {
                case 1:
                    createTournament();
                    break;
                case 2:
                    updateTournament();
                    break;
                case 3:
                    deleteTournament();
                    break;
                case 4:
                    searchTournament();
                    break;
                case 5:
                    refreshList();
                    break;
                case 6:
                    rosterForm();
                    break;
            }
        }

        private void initButtons()
        {
            btnCreateTournament.Tag = 1;
            btnUpdate.Tag = 2;
            btnDelete.Tag = 3;
            btnTournamentSearch.Tag = 4;
            btnRefreshList.Tag = 5;
            btnPrintTeamRosterForm.Tag = 6;

            btnCreateTournament.Click += ButtonClick;
            btnUpdate.Click += ButtonClick;
            btnDelete.Click += ButtonClick;
            btnTournamentSearch.Click += ButtonClick;
            btnRefreshList.Click += ButtonClick;
            btnPrintTeamRosterForm.Click += ButtonClick;
        }

        private void initTournamentList()
        {
            lvwTournamentList.View = View.Details;
            lvwTournamentList.GridLines = true;
            lvwTournamentList.FullRowSelect = true;
            lvwTournamentList.MultiSelect = false;
            lvwTournamentList.HideSelection = false;

            lvwTournamentList.Columns.Add("No.", 50, HorizontalAlignment.Center);
            lvwTournamentList.Columns.Add("Id", 0);
            lvwTournamentList.Columns.Add("Year",  90, HorizontalAlignment.Center );
            lvwTournamentList.Columns.Add("Motto", 150, HorizontalAlignment.Center);
            lvwTournamentList.Columns.Add("Schedule", 250, HorizontalAlignment.Center);
            lvwTournamentList.Columns.Add("Status", 150, HorizontalAlignment.Center);

        }

        private void loadTournamentList()
        {
            listTournament = TournamentHelper.GetTournamentList();
            ListViewItem item = null;
            int ctr = 0;
            lvwTournamentList.Items.Clear();

            foreach (var list in listTournament)
            {
                item = lvwTournamentList.Items.Add((++ctr).ToString());
                item.SubItems.Add(list.tournament_id.ToString());
                item.SubItems.Add(list.tournament_year);
                item.SubItems.Add(list.tournament_motto);
                item.SubItems.Add(list.tournament_schedule);
                item.SubItems.Add(list.tournament_status);

           }
        }

        private void createTournament()
        {
            Tournament checkTournamentStatus = new Tournament();
            if (checkTournamentStatus.tournamentCheckStatus() == false) return;

            using (Form tournament = new frmTournament())
             {
                 tournament.ShowDialog();
                 if (tournament.DialogResult == System.Windows.Forms.DialogResult.OK)
                 {
                     Tournament statusPrompt = new Tournament();
                     loadTournamentList();
                     initTournamentInfo();
                 }
             }
        }
    
        private void updateTournament()
        {

            Tournament t = new Tournament();
            if (t.CRUDValidation() == false) return;

            if (lvwTournamentList.Items.Count == 0 || lvwTournamentList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Tournament to Update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int si = lvwTournamentList.SelectedItems[0].Index;
            Tournament selectedTournament = listTournament[si];

            using (Form tournament = new frmTournament(selectedTournament))
            {
                tournament.StartPosition = FormStartPosition.CenterParent;
                tournament.ShowDialog();

                if (tournament.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Tournament successfully Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadTournamentList();
                    initTournamentInfo();

                }
            }
        }

        private void deleteTournament()
        {
            Tournament t = new Tournament();
            if (t.CRUDValidation() == false) return;

            if (lvwTournamentList.Items.Count == 0 || lvwTournamentList.SelectedItems.Count == 0){ MessageBox.Show("Please Choose Tournament to Delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);return;}
            int si     = lvwTournamentList.SelectedItems[0].Index;
            Tournament selectedTournament = listTournament[si];

            string msg = "Do you want to delete  [" + selectedTournament.tournament_year + " Tournament?]" 
                           + " All Team Associated to this Tournament's Year will be Deleted.";           
            if (MessageBox.Show(msg, "Confirm delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.No)
                return;

            MessageBox.Show("Tournament successfully Deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TournamentHelper.DeleteTournament(selectedTournament.tournament_id);
            loadTournamentList();
            initTournamentInfo();
        }


        private void searchTournament()
        {
            string search = txtTournamentSearch.Text;
            if (search.Length == 0) { MessageBox.Show("Please Enter the Word You want to Search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            SqlParameter[] p = {      
                                        new SqlParameter("@tournament_year",         search),
                                        new SqlParameter("@tournament_schedule",     search),
                                        new SqlParameter("@tournament_venue",        search),
                                        new SqlParameter("@tournament_motto",        search),
                                        new SqlParameter("@tournament_status",       search),
                               };

            listTournament = TournamentHelper.SearchTournament(p);
            ListViewItem item = null;
            int ctr = 0;
            lvwTournamentList.Items.Clear();

            foreach (var list in listTournament)
            {
                item = lvwTournamentList.Items.Add((++ctr).ToString());
                item.SubItems.Add(list.tournament_id.ToString());
                item.SubItems.Add(list.tournament_year);
                item.SubItems.Add(list.tournament_motto);
                item.SubItems.Add(list.tournament_schedule);
                item.SubItems.Add(list.tournament_status);
            }
            if (lvwTournamentList.Items.Count == 0) { MessageBox.Show(txtTournamentSearch.Text + " Can't Found!", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); txtTournamentSearch.Text = ""; loadTournamentList();}
       }

        private void refreshList()
        {
             loadTournamentList();
        }

        private void rosterForm()
        {
            Tournament tournament = new Tournament();
            if (tournament.ifActiveValidation() == false) return;

            if (lvwTournamentList.Items.Count == 0 || lvwTournamentList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Tournament.", "Roster Form", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            int si           = lvwTournamentList.SelectedItems[0].Index;
            int tournament_id = Convert.ToInt32(lvwTournamentList.Items[si].SubItems[1].Text);
    
            tournament.importToExcel(tournament_id);
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
            btnCreateTournament.Text = "Create Tournament";
            btnCreateTournament.BackColor = Color.Blue;

            var checkTournamentList = TournamentHelper.CheckTournamentStatus();
            foreach (var list in checkTournamentList)
            {
                lblStatus.Text      = list.tournament_status;
                lblYear.Text        = list.tournament_year;
                lblMotto.Text       = list.tournament_motto;
                lblSchedule.Text    = list.tournament_schedule;


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
