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
    public partial class frmTeamList : Form
    {
        List<Team> listTeam = null;

        
        public frmTeamList()
        {
            InitializeComponent();
            initButtons();
            initTeamList();
            loadTeamList();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch ((int)button.Tag)
            {
                case 1:
                    registerTeam();
                    break;
                case 2:
                    updateTeam();
                    break;
                case 3:
                    deleteTeam();
                    break;
                case 4:
                    searchTeam();
                    break;
                case 5:
                    viewTeam();      
                    break;
                case 6:
                    refreshList();
                    break;
            }
        }

        private void initButtons()
        {
            btnRegisterTeam.Tag = 1;
            btnUpdate.Tag       = 2;
            btnDelete.Tag       = 3;
            btnSearchTeam.Tag   = 4;
            btnViewTeam.Tag     = 5;
            btnRefreshList.Tag  = 6;


            btnRegisterTeam.Click += ButtonClick;
            btnUpdate.Click += ButtonClick;
            btnDelete.Click += ButtonClick;
            btnSearchTeam.Click += ButtonClick;
            btnViewTeam.Click += ButtonClick;
            btnRefreshList.Click += ButtonClick;
        }


        private void initTeamList()
        {
            lvwTeamList.View = View.Details;
            lvwTeamList.GridLines = true;
            lvwTeamList.FullRowSelect = true;
            lvwTeamList.MultiSelect = false;
            lvwTeamList.HideSelection = false;
                                                                        
            lvwTeamList.Columns.Add("No.", 50, HorizontalAlignment.Center);
            lvwTeamList.Columns.Add("Id", 0);
            lvwTeamList.Columns.Add("Barangay", 140, HorizontalAlignment.Center);
            lvwTeamList.Columns.Add("Name", 190, HorizontalAlignment.Center);
            lvwTeamList.Columns.Add("Slogan", 190, HorizontalAlignment.Center);
            lvwTeamList.Columns.Add("Tournament Year", 170, HorizontalAlignment.Center);
            lvwTeamList.Columns.Add("Team Logo", 0, HorizontalAlignment.Center);
        }

        private void loadTeamList()
        {
            listTeam = TeamHelper.GetTeamList();
            ListViewItem item = null;
            int ctr = 0;
            lvwTeamList.Items.Clear();
          
            foreach (var list in listTeam)
            {
                item = lvwTeamList.Items.Add((++ctr).ToString());
                item.SubItems.Add(list.team_id.ToString());
                item.SubItems.Add(list.barangay.brgyName);
                item.SubItems.Add(list.team_name);
                item.SubItems.Add(list.team_slogan);
                item.SubItems.Add(list.tournament.tournament_year);
                item.SubItems.Add(list.team_logo);
            }
       }
    
        private void selectedTeamList() ////////////////////////////////////////
        {
            Team team = new Team();
            try { 
            int  si = lvwTeamList.SelectedItems[0].Index;
            string barangay = lvwTeamList.Items[si].SubItems[2].Text;
            string teamName = lvwTeamList.Items[si].SubItems[3].Text;
            string slogan   = lvwTeamList.Items[si].SubItems[4].Text;
            string logo     = lvwTeamList.Items[si].SubItems[6].Text;

                picTeamLogo.Image  = team.Base64ToImage(logo);
                lblTeamName.Text   = teamName;
                lblTeamBrgy.Text   = "Barangay," + barangay;
                lblTeamSlogan.Text = slogan;
                }
            catch
            {


            }
         }

        private void registerTeam()
        {
            Tournament tournamentRegistrationValidation = new Tournament();
            if (tournamentRegistrationValidation.tournamentRegistrationValidation() == false) return;

            frmRegistration register = new frmRegistration();
            register.ShowDialog();
            loadTeamList();
        }

        private void updateTeam()
        {
            Tournament t = new Tournament();
            if (t.CRUDValidation() == false) return;
            if (lvwTeamList.Items.Count == 0 || lvwTeamList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Team to Update", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int si = lvwTeamList.SelectedItems[0].Index;
            Team selectedTeam = listTeam[si];
            selectedTeamList();

            using (Form team = new frmTeamUpdate(selectedTeam))
            {
                team.StartPosition = FormStartPosition.CenterParent;
                team.ShowDialog();

                if (team.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    MessageBox.Show("Team successfully Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearTeamInfo();
                    loadTeamList();
                }
            }
       
        }

        private void searchTeam()
        {
         string search = txtSearchTeam.Text;
         if (search.Length == 0) { MessageBox.Show("Please input the word you want to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }


         SqlParameter[] p = {      
                                        new SqlParameter("@team_name",         search),
                                        new SqlParameter("@team_slogan",       search),
                                        new SqlParameter("@barangay",          search),
                                        new SqlParameter("@tournament",        search),
                               };


         listTeam = TeamHelper.SearchTeam(p);
         ListViewItem item = null;
         int ctr = 0;
         lvwTeamList.Items.Clear();

         foreach (var list in listTeam)
         {
             item = lvwTeamList.Items.Add((++ctr).ToString());
             item.SubItems.Add(list.team_id.ToString());
             item.SubItems.Add(list.barangay.brgyName);
             item.SubItems.Add(list.team_name);
             item.SubItems.Add(list.team_slogan);
             item.SubItems.Add(list.tournament.tournament_year);
             item.SubItems.Add(list.team_logo);
         }

         if (lvwTeamList.Items.Count == 0) { MessageBox.Show(search + " Cannot be found!", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); loadTeamList();}
        }   


        private void deleteTeam()
        {
            Tournament t = new Tournament();
           if (t.CRUDValidation() == false) return;
           
            if (lvwTeamList.Items.Count == 0 || lvwTeamList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Team to Delete", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
           int si = lvwTeamList.SelectedItems[0].Index;
           Team selectedTeam = listTeam[si];

            string msg = "Do you want to delete  Team [" + selectedTeam.team_name + "?] All Players and Team Official Compose of this Team will also Deleted." ;
            if (MessageBox.Show(msg, "Confirm delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.No)
                return;
   
            MessageBox.Show("Team " + selectedTeam.team_name + " successfully Deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            TeamHelper.DeleteTeam(selectedTeam.team_id);
            clearTeamInfo();
            loadTeamList();
        
       }
        private void viewTeam()
        {
            if (lvwTeamList.Items.Count == 0 || lvwTeamList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Team to View", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int si = lvwTeamList.SelectedItems[0].Index;
            int teamId = Convert.ToInt32(lvwTeamList.Items[si].SubItems[1].Text);
            Globals.PlayerInfo.teamId = teamId;
            frmViewTeam viewTeam = new frmViewTeam();
            viewTeam.ShowDialog();
        }   
    
        private void refreshList()
        {
            loadTeamList();
        }

        private void clearTeamInfo()
        {
            picTeamLogo.Image = null;
            lblTeamName.Text = "";
            lblTeamBrgy.Text = "";
            lblTeamSlogan.Text = "";
            //lblCoach.Text = "";
            //lblAssistantCoach.Text = "";
            //lblTeamManager.Text = "";
        }

        private void lvwTeamList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTeamList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

    }
}
