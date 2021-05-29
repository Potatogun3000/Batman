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
    public partial class frmAwardHistory : Form
    {
        public frmAwardHistory()
        {
            InitializeComponent();
            initializeAwardList();
            loadAwardList();
        }

      
        private void initializeAwardList()
        {
            lvwAwardHistory.View = View.Details;
            lvwAwardHistory.GridLines = true;
            lvwAwardHistory.FullRowSelect = true;

            lvwAwardHistory.Columns.Add("Id", 0);
            lvwAwardHistory.Columns.Add("No", 50);
            lvwAwardHistory.Columns.Add("Team Champion", 150, HorizontalAlignment.Center);
            lvwAwardHistory.Columns.Add("First Runner Up", 150, HorizontalAlignment.Center);
            lvwAwardHistory.Columns.Add("MVP", 150, HorizontalAlignment.Center);
            lvwAwardHistory.Columns.Add("Best Small Forward", 150, HorizontalAlignment.Center);
            lvwAwardHistory.Columns.Add("Best Power Forward", 150, HorizontalAlignment.Center);
            lvwAwardHistory.Columns.Add("Best Point Guard", 150, HorizontalAlignment.Center);
            lvwAwardHistory.Columns.Add("Best Shooting Guard", 150, HorizontalAlignment.Center);
            lvwAwardHistory.Columns.Add("Best Center", 150, HorizontalAlignment.Center);
            lvwAwardHistory.Columns.Add("Tournament Year", 150, HorizontalAlignment.Center);

        }

        private void loadAwardList()
        {

            var listAwards = AwardHelper.getAwardList();
            ListViewItem items = null;
            int ctr = 1;
            lvwAwardHistory.Items.Clear();
            foreach (var item in listAwards)
            {
                items = lvwAwardHistory.Items.Add(item.awardID.ToString());
                items.SubItems.Add(ctr++.ToString());
                items.SubItems.Add(item.awardChampionship);
                items.SubItems.Add(item.awardFirstRunnerUp);
                items.SubItems.Add(item.awardMVP);
                items.SubItems.Add(item.awardSF);
                items.SubItems.Add(item.awardPF);
                items.SubItems.Add(item.awardPG);
                items.SubItems.Add(item.awardSG);
                items.SubItems.Add(item.awardC);
                items.SubItems.Add(item.tournament.tournament_year);
            }
        }
    }
}
