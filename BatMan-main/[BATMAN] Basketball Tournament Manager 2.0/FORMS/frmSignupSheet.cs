using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmSignupSheet : Form
    {
        public frmSignupSheet()
        {
            InitializeComponent();
            displayTournamentInfo();
            initializePlayerList();
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

        private void initializePlayerList()
        {
            lvwRegistrationSheet.View = View.Details;
            lvwRegistrationSheet.GridLines = true;
            lvwRegistrationSheet.FullRowSelect = false;

            lvwRegistrationSheet.Columns.Add("No", 50, HorizontalAlignment.Center);
            lvwRegistrationSheet.Columns.Add("Player Name", 150, HorizontalAlignment.Center);
            lvwRegistrationSheet.Columns.Add("Jersey No.", 70, HorizontalAlignment.Center);
            lvwRegistrationSheet.Columns.Add("Position", 100, HorizontalAlignment.Center);
            lvwRegistrationSheet.Columns.Add("Birth Date", 150, HorizontalAlignment.Center);
            lvwRegistrationSheet.Columns.Add("Address", 150, HorizontalAlignment.Center);

            SetHeight(lvwRegistrationSheet, 25);

            ListViewItem item = null;
            for (int ctr = 1; ctr <= 10; ctr++)
            {
                item = lvwRegistrationSheet.Items.Add((ctr).ToString());
            }
        }

           private void SetHeight(ListView listView, int height)
            {
                ImageList imgList = new ImageList();
                imgList.ImageSize = new Size(3, height);
                listView.SmallImageList = imgList;
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
               e.Graphics.DrawImage(bmp, 0 ,0);
               
               
           }

           Bitmap bmp;

           private void btnPrint_Click(object sender, EventArgs e)
           {
               try
               {
                   Graphics g = this.CreateGraphics();
                   bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
                   Graphics mg = Graphics.FromImage(bmp);
                   mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
                   printPreviewDialog1.ShowDialog();
                   
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

           private void pictureBox1_Click(object sender, EventArgs e)
           {
               
           }

           private void shapeContainer1_Load(object sender, EventArgs e)
           {

           }

           private void frmSignupSheet_Load(object sender, EventArgs e)
           {

           }
        
    }
}
