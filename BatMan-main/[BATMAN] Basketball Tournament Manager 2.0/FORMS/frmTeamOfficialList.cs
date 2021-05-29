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
    public partial class frmTeamOfficialList : Form
    {
        public frmTeamOfficialList()
        {
            InitializeComponent();
            initButtons();
            initTeamOfficialList();
            loadTeamOfficialList();
        }
        int teamOfficialId = 0;
        private void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch ((int)button.Tag)
            {
                case 1:
                    updateTeamOfficial();
                    break;
                case 2:
                    editTeamOfficial();
                    break;
                case 3:
                    searchTeamOfficial();
                    break;
                case 4:
                    refreshList();
                    break;
                case 5:
                    cancel();
                    break;
            }
        }

        private void initButtons()
        {
            btnUpdate.Tag = 1;
            btnEdit.Tag = 2;
            btnSearch.Tag = 3;
            btnRefreshList.Tag = 4;
            btnCancel.Tag = 5;

            btnUpdate.Click += ButtonClick;
            btnEdit.Click += ButtonClick;
            btnSearch.Click += ButtonClick;
            btnRefreshList.Click += ButtonClick;
            btnCancel.Click += ButtonClick;
        }

        private void initTeamOfficialList()
        {
            lvwTeamOfficialList.View = View.Details;
            lvwTeamOfficialList.GridLines = true;
            lvwTeamOfficialList.FullRowSelect = true;
            lvwTeamOfficialList.MultiSelect = false;
            lvwTeamOfficialList.HideSelection = false;

            lvwTeamOfficialList.Columns.Add("No.", 50, HorizontalAlignment.Center);
            lvwTeamOfficialList.Columns.Add("Id", 0);
            lvwTeamOfficialList.Columns.Add("Name", 200, HorizontalAlignment.Center);
            lvwTeamOfficialList.Columns.Add("Description", 200, HorizontalAlignment.Center);
            lvwTeamOfficialList.Columns.Add("Team Name", 230, HorizontalAlignment.Center);
        }

        private void loadTeamOfficialList()
        {
            var teamOfficial = TeamOfficialHelper.GetTeamOfficialList();
            ListViewItem item = null;
            int i = 0;
            lvwTeamOfficialList.Items.Clear();

            foreach (var list in teamOfficial)
            {
                string[] name = list.teamOfficial_name.Split(',');
                string[] desc = list.teamOfficial_desc.Split(',');
                int ctr = 0;
                foreach (var official in name)
                {   
                    item = lvwTeamOfficialList.Items.Add((++i).ToString());
                    item.SubItems.Add(list.teamOfficial_id.ToString());
                    item.SubItems.Add(official);
                    item.SubItems.Add(desc[ctr]);        
                    item.SubItems.Add(list.teamName);
               
                    ctr++;
                }
             
             } 
         }
        
       private void updateTeamOfficial()
        {       
            TeamOfficial teamOfficial = new TeamOfficial();
            string coachfname = txtCoachFname.Text, coachlname = txtCoachLname.Text;
            string asstfname = txtAssistantCoachFname.Text, asstlname = txtAssistantCoachLname.Text;
            string managerfname = txtManagerFname.Text, managerlname = txtManagerLname.Text;

            string coach = coachfname + " " + coachlname;
            string asstCoach = asstfname + " " + asstlname;
            string manager = managerfname + " " + managerlname;


            teamOfficial.teamOfficial_id   = teamOfficialId;
            teamOfficial.teamOfficial_name = coach + "," + asstCoach + "," + manager;
            teamOfficial.teamOfficial_desc = "Coach,Assistant Coach,Manager";

            if (teamOfficial.validateTeamOfficial(coachfname, coachlname, asstfname, asstlname, managerfname, managerlname) == false) return;
            TeamOfficialHelper.UpdateTeamOfficial(teamOfficial);
            MessageBox.Show("Team Officials Succesfully Updated!", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadTeamOfficialList();
            cancel();
        }

        private void editTeamOfficial()
        {
            Tournament t = new Tournament();
            if (t.CRUDValidation() == false) return;
            if (lvwTeamOfficialList.Items.Count == 0 || lvwTeamOfficialList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Team Official to Edit", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
           
            int si = lvwTeamOfficialList.SelectedItems[0].Index;
            teamOfficialId = Convert.ToInt32(lvwTeamOfficialList.Items[si].SubItems[1].Text);
         
            SqlParameter[] p = { new SqlParameter("@teamOfficial_id", teamOfficialId) };
            
            var teamOfficials = TeamOfficialHelper.GetTeamOfficialtoUpdate(p);

            foreach (var list in teamOfficials)
            {
                string[] name = list.teamOfficial_name.Split(',');
                string coach = "", asstCoach = "", manager = "";
                int ctr = 0;
                int ctr2 = 0;
                foreach (var item in name)
                {
                    if (ctr == 0) coach = item;
                    if (ctr == 1) asstCoach = item;
                    if (ctr == 2) manager = item;
                    ctr++;
                }

                string[] c = coach.Split(' ');
                string[] ac = asstCoach.Split(' ');
                string[] m = manager.Split(' ');
                foreach (var item in c)
                {
                    if (ctr2 == 0)
                    {
                        txtCoachFname.Text = item;
                        txtAssistantCoachFname.Text = ac[ctr2];
                        txtManagerFname.Text = m[ctr2];
                    }

                    if (ctr2 == 1)
                    {
                        txtCoachLname.Text = item;
                        txtAssistantCoachLname.Text = ac[ctr2];
                        txtManagerLname.Text = m[ctr2];
                    }
                    ctr2++;
                }
            }
            grpTeamOfficialInfo.Enabled = true;
        }
        
        private void searchTeamOfficial()
        {
            string search = txtSearchTeamOfficial.Text;
            if (search.Length == 0) { MessageBox.Show("Please input the word you want to search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }


            SqlParameter[] p = {      
                                        new SqlParameter("@teamOfficial_name",        search),
                                        new SqlParameter("@teamOfficial_desc",        search),
                                        new SqlParameter("@team_name",                search)
                               };

            var teamOfficial = TeamOfficialHelper.SearchTeamOfficial(p);
            ListViewItem item = null;
            int i = 0;
            lvwTeamOfficialList.Items.Clear();

            foreach (var list in teamOfficial)
            {
                string[] name = list.teamOfficial_name.Split(',');
                string[] desc = list.teamOfficial_desc.Split(',');
                int ctr = 0;
                foreach (var official in name)
                {
                    item = lvwTeamOfficialList.Items.Add((++i).ToString());
                    item.SubItems.Add(list.teamOfficial_id.ToString());
                    item.SubItems.Add(official);
                    item.SubItems.Add(desc[ctr]);
                    item.SubItems.Add(list.teamName);

                    ctr++;
                }

            }

            if (lvwTeamOfficialList.Items.Count == 0) { MessageBox.Show(search + " Cannot be found!", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); loadTeamOfficialList(); }
        }

        private void refreshList()
        {
            loadTeamOfficialList();
        }

        private void cancel()
        {
            txtCoachFname.Text = "";
            txtCoachLname.Text = "";
            txtAssistantCoachFname.Text = "";
            txtAssistantCoachLname.Text = "";
            txtManagerFname.Text = "";
            txtManagerLname.Text = "";
            grpTeamOfficialInfo.Enabled = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        
     
    }
}
