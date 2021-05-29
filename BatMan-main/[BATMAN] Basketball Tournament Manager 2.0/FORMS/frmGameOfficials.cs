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
    public partial class frmGameOfficials : Form
    {
        int gameOfficialId = 0;
  
        public frmGameOfficials()
        {
            InitializeComponent();
            initButtons();
            initOfficialList();
            loadGameOfficialList();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch ((int)button.Tag)
            {
                case 1:
                    saveGameOfficial();
                    break;
                case 2:
                    updateGameOfficial();
                    break;
                case 3:
                    deleteGameOfficial();
                    break;
                case 4:
                    searchGameOfficial();
                    break;
                case 5:
                    refreshList();
                    break;
                case 6:
                    cancel();
                    break;
            }
        }

        private void initButtons()
        {
            btnSave.Tag = 1;
            btnUpdate.Tag = 2;
            btnDelete.Tag = 3;
            btnSearch.Tag = 4;
            btnRefreshList.Tag = 5;
            btnCancel.Tag = 6;

            btnSave.Click += ButtonClick;
            btnUpdate.Click += ButtonClick;
            btnDelete.Click += ButtonClick;
            btnSearch.Click += ButtonClick;
            btnRefreshList.Click += ButtonClick;
            btnCancel.Click += ButtonClick;
        }

        private void initOfficialList()
        {
            lvwGameOfficialList.View = View.Details;
            lvwGameOfficialList.GridLines = true;
            lvwGameOfficialList.FullRowSelect = true;
            lvwGameOfficialList.MultiSelect = false;
            lvwGameOfficialList.HideSelection = false;

            lvwGameOfficialList.Columns.Add("No.", 50, HorizontalAlignment.Center);
            lvwGameOfficialList.Columns.Add("Id", 0);
            lvwGameOfficialList.Columns.Add("Name", 320, HorizontalAlignment.Center);
            lvwGameOfficialList.Columns.Add("Description", 350, HorizontalAlignment.Center);
        }


        private void loadGameOfficialList()
        {
            var gameOfficial = GameOfficialsHelper.GetGameOfficialList();
            ListViewItem item = null;
            int ctr = 0;
            lvwGameOfficialList.Items.Clear();

            foreach (var list in gameOfficial)
            {
                item = lvwGameOfficialList.Items.Add((++ctr).ToString());
                item.SubItems.Add(list.gameofficialID.ToString());
                item.SubItems.Add(list.gameofficialName);
                item.SubItems.Add(list.gameofficialDesc);
            }
        }

        private void saveGameOfficial()
        {
            //Tournament tournamentRegistrationValidation = new Tournament();
            //if (tournamentRegistrationValidation.tournamentRegistrationValidation() == false) return;
            
            string firstName   = txtGameOfficialFname.Text, lastName = txtGameOfficialLname.Text;
            GameOfficial g = new GameOfficial()
            {   
                gameofficialID   = gameOfficialId,
                gameofficialName = firstName + " " + lastName,
                gameofficialDesc = cmbGameOfficialDesc.Text
            };
            if (g.validateofficialList(firstName,lastName) == false) return;
            if (g.isGameOfficialExist() == false) return;

            GameOfficialsHelper.SaveGameOfficial(g);

            if (gameOfficialId == 0) MessageBox.Show("Game Official Save!", "Game Official", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show("Game Official Updated!", "Game Official", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            btnSave.Text = "Save";
            txtGameOfficialFname.Text = "";
            txtGameOfficialLname.Text = "";
            cmbGameOfficialDesc.Text = "";
            gameOfficialId = 0;
            
            loadGameOfficialList();
        }

        private void updateGameOfficial()
        {
            Tournament tournamentRegistrationValidation = new Tournament();
            if (tournamentRegistrationValidation.tournamentRegistrationValidation() == false) return;
            
            btnSave.Text = "Update";
            if (lvwGameOfficialList.Items.Count == 0 || lvwGameOfficialList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Game Official to Update", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int si      = lvwGameOfficialList.SelectedItems[0].Index;
            gameOfficialId = Convert.ToInt32(lvwGameOfficialList.Items[si].SubItems[1].Text);
            string name = lvwGameOfficialList.Items[si].SubItems[2].Text;
            string desc = lvwGameOfficialList.Items[si].SubItems[3].Text;

            string[] word = name.Split(' ');
            int ctr = 0;
            foreach (string split in word)
            {   
                if(ctr == 0)
                txtGameOfficialFname.Text =  Convert.ToString(split);
                if (ctr == 1)
                txtGameOfficialLname.Text = Convert.ToString(split);
                ctr++;
            }
            cmbGameOfficialDesc.Text = desc;
        }

        private void deleteGameOfficial()
        {
            if (lvwGameOfficialList.Items.Count == 0 || lvwGameOfficialList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Game Official to Delete", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int si = lvwGameOfficialList.SelectedItems[0].Index;
            int gameOfficialId = Convert.ToInt32(lvwGameOfficialList.Items[si].SubItems[1].Text);
            string name = lvwGameOfficialList.Items[si].SubItems[2].Text;
            string desc = lvwGameOfficialList.Items[si].SubItems[3].Text;
            GameOfficialsHelper.DeleteGameOfficial(gameOfficialId);

            string msg = "Do you want to delete  [" + desc + " "  + name + "?]";
            if (MessageBox.Show(msg, "Confirm delete?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.No)
                return;

            MessageBox.Show("Game Official successfully Deleted!", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            loadGameOfficialList();
        }

        private void searchGameOfficial()
        {
            string search = txtSearchGameOfficial.Text;
            if (search.Length == 0) { MessageBox.Show("Please Enter the Word You want to Search.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            SqlParameter[] p = {      
                                        new SqlParameter("@gameOfficialName",         search),
                                        new SqlParameter("@gameOfficialDesc",         search),
                               };

            var listGameOfficial = GameOfficialsHelper.SearchGameOfficial(p);
            ListViewItem item = null;
            int ctr = 0;
             lvwGameOfficialList.Items.Clear();

             foreach (var list in listGameOfficial)
            {
                item = lvwGameOfficialList.Items.Add((++ctr).ToString());
                item.SubItems.Add(list.gameofficialID.ToString());
                item.SubItems.Add(list.gameofficialName);
                item.SubItems.Add(list.gameofficialDesc);
              }
             if (lvwGameOfficialList.Items.Count == 0) { MessageBox.Show(txtSearchGameOfficial.Text + " Can't Found!", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information); txtSearchGameOfficial.Text = ""; loadGameOfficialList(); }
        }

        private void refreshList()
        {
            loadGameOfficialList();
            txtSearchGameOfficial.Text = "";
        }

        private void cancel()
        {
            btnSave.Text = "Save";
            txtGameOfficialFname.Text = "";
            txtGameOfficialLname.Text = "";
            txtSearchGameOfficial.Text = "";
            cmbGameOfficialDesc.Text = "";
            gameOfficialId = 0;
        }

        private void grpGameOfficialList_Enter(object sender, EventArgs e)
        {

        }

    }
}
