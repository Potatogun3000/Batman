using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _BATMAN__Basketball_Tournament_Manager_2._0.FORMS;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using System.IO;


namespace _BATMAN__Basketball_Tournament_Manager_2._0.FORMS
{
    public partial class frmRegistration : Form
    {
        public frmRegistration()
        {
            InitializeComponent();
            initButtons();
            initializePlayerList();
            getBarangayList();
            displayTournamentInfo();
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            switch ((int)button.Tag)
            {
                case 1:
                    addPlayer();
                    break;
                case 2:
                    editPlayer();
                    break;
                case 3:
                    removePlayer();
                    break;
                case 4:
                    browseTeamLogo();
                    break;
                 case 5:
                    saveTeam();
                    break;
            }
        }

        private void initButtons()
        {
            btnAddPlayer.Tag        = 1;
            btnEditPlayer.Tag       = 2;
            btnRemovePlayer.Tag     = 3;
            btnBrowseLogo.Tag       = 4;
            btnSaveTeam.Tag = 5;
          

            btnAddPlayer.Click      += ButtonClick;
            btnEditPlayer.Click     += ButtonClick;
            btnRemovePlayer.Click   += ButtonClick;
            btnBrowseLogo.Click     += ButtonClick;
            btnSaveTeam.Click += ButtonClick;
       }

        private void initializePlayerList()
        {
            lvwPlayerList.View = View.Details;
            lvwPlayerList.GridLines = true;
            lvwPlayerList.FullRowSelect = true;

            lvwPlayerList.Columns.Add("Player Name", 270, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Jersey No", 90, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Position", 150, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Birthdate", 200, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Address", 250, HorizontalAlignment.Center);
            lvwPlayerList.Columns.Add("Player Photo", 0, HorizontalAlignment.Center);
        }

        private void getBarangayList()
        {
            cmbBarangay.DataSource      =  BarangayHelper.GetAllBarangay();
            cmbBarangay.DisplayMember   = "brgyName";
            cmbBarangay.ValueMember     = "brgyID"; 
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

        private void addPlayer()
        {
            ListViewItem item = null;
            int ctr = lvwPlayerList.Items.Count + 1;
            if (ctr > 10) { MessageBox.Show("You Can't add more Player. Every Team has a Maximum of 10 Players!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            int si = 11;

            Globals.PlayerInfo.isPlayerEdit = false;
            Globals.PlayerInfo.isOnTable = false;
            Globals.PlayerInfo.isPlayerAdd  = true;
            frmAddPlayer player = new frmAddPlayer();
            player.ShowDialog();

            if (ifPlayerExisting(si) == false) return;
            
            if(Globals.PlayerInfo.isPlayerAdd == false)
            {
                item = lvwPlayerList.Items.Add(Globals.PlayerInfo.player_name);
                item.SubItems.Add(Globals.PlayerInfo.player_jerseyNo);
                item.SubItems.Add(Globals.PlayerInfo.player_postition);
                item.SubItems.Add(Globals.PlayerInfo.player_birthdate);
                item.SubItems.Add(Globals.PlayerInfo.player_address);
                item.SubItems.Add(Globals.PlayerInfo.player_photo);
            }
        }

        private void editPlayer()
        {
            if (lvwPlayerList.Items.Count == 0 || lvwPlayerList.SelectedItems.Count == 0) { MessageBox.Show("Please Choose Player to Edit", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }

            Globals.PlayerInfo.isPlayerAdd  = true;
            Globals.PlayerInfo.isPlayerEdit = true;
            Globals.PlayerInfo.isOnTable    = true;
            int si = lvwPlayerList.SelectedItems[0].Index;
            
            Globals.PlayerInfo.player_name      = lvwPlayerList.Items[si].SubItems[0].Text;
            Globals.PlayerInfo.player_postition = lvwPlayerList.Items[si].SubItems[1].Text;
            Globals.PlayerInfo.player_postition = lvwPlayerList.Items[si].SubItems[2].Text;
            Globals.PlayerInfo.player_birthdate = lvwPlayerList.Items[si].SubItems[3].Text;
            Globals.PlayerInfo.player_address   = lvwPlayerList.Items[si].SubItems[4].Text;
            Globals.PlayerInfo.player_photo     = lvwPlayerList.Items[si].SubItems[5].Text;

            frmAddPlayer player = new frmAddPlayer();
            player.ShowDialog();

            if (ifPlayerExisting(si) == false) return;

            lvwPlayerList.Items[si].SubItems[0].Text = Globals.PlayerInfo.player_name;
            lvwPlayerList.Items[si].SubItems[1].Text = Globals.PlayerInfo.player_jerseyNo;
            lvwPlayerList.Items[si].SubItems[2].Text = Globals.PlayerInfo.player_postition;
            lvwPlayerList.Items[si].SubItems[3].Text = Globals.PlayerInfo.player_birthdate;
            lvwPlayerList.Items[si].SubItems[4].Text = Globals.PlayerInfo.player_address;
        }

        private void removePlayer()
        {
            if (lvwPlayerList.Items.Count == 0 || lvwPlayerList.SelectedItems.Count == 0){MessageBox.Show("Please Choose Player to Remove", "Remove", MessageBoxButtons.OK, MessageBoxIcon.Information);return;}
            int si = lvwPlayerList.SelectedItems[0].Index;
            string playerName = lvwPlayerList.Items[si].SubItems[0].Text;
        
            string msg = "Do you want to remove player  [" + playerName + "?]";
            if (MessageBox.Show(msg, "Confirm Remove?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) ==
                System.Windows.Forms.DialogResult.No)
                return;
                lvwPlayerList.Items.RemoveAt(si);
        }

        private void browseTeamLogo()
        {
            OpenFileDialog openImage = new OpenFileDialog();
            openImage.InitialDirectory = "C:/Picture/";
            openImage.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg|All files(*.*)|*.*";
            openImage.Title = "Select Product Image";
            openImage.FilterIndex = 2;
            if (openImage.ShowDialog() == DialogResult.OK)
            {
                picTeamLogo.Image = Image.FromFile(openImage.FileName);
                picTeamLogo.SizeMode = PictureBoxSizeMode.StretchImage;
                picTeamLogo.BorderStyle = BorderStyle.Fixed3D;
            }
        }

        private void saveTeam()
        {   
            //
            Team team = new Team();
            team.team_name                 = txtTeamName.Text;
            team.team_slogan               = txtSlogan.Text;
            team.team_logo                 = getImage();
            team.barangay.brgyID          = Convert.ToInt32(cmbBarangay.SelectedValue);
          
            if(team.validateTeam(cmbBarangay.Text) == false) return;
            //

            //SAVE TEAM OFFICIAL
            TeamOfficial teamOfficial = new TeamOfficial();
            string coachfname = txtCoachFname.Text , coachlname = txtCoachLname.Text;
            string asstfname  = txtAssistantCoachFname.Text , asstlname = txtAssistantCoachLname.Text;
            string managerfname = txtManagerFname.Text, managerlname = txtManagerLname.Text;

            string coach     = coachfname   + " " + coachlname;
            string asstCoach = asstfname    + " " + asstlname;
            string manager   = managerfname + " " + managerlname;
          
            teamOfficial.teamOfficial_name =  coach + "," +  asstCoach + "," + manager;
            teamOfficial.teamOfficial_desc = "Coach,Assistant Coach,Manager";  
            
            if (teamOfficial.validateTeamOfficial(coachfname, coachlname, asstfname, asstlname, managerfname, managerlname) == false) return;
            if (checkPlayers() == false) return;
        
            TeamOfficialHelper.SaveTeamOfficial(teamOfficial);
            //
            
     
            //SAVE TEAM
            var teamOfficialLatestRecord = TeamOfficialHelper.GetTeamOfficialLatestRecord();
            foreach (var list in teamOfficialLatestRecord)
            {
                team.teamOfficial.teamOfficial_id = list.teamOfficial_id;        
            }

            var tournamentStatus = TournamentHelper.CheckTournamentStatus();
            foreach (var list in tournamentStatus)
            {
                team.tournament.tournament_id = list.tournament_id;
            }
     
            TeamHelper.SaveTeam(team);
            //

          
            //SAVE PLAYERS
            for (int i = 0; i < lvwPlayerList.Items.Count; i++)
            {
              string playerName       =  lvwPlayerList.Items[i].SubItems[0].Text;
              string jerseyNo         =  lvwPlayerList.Items[i].SubItems[1].Text;
              string positionDesc     =  lvwPlayerList.Items[i].SubItems[2].Text;
              string birhtdate        =  lvwPlayerList.Items[i].SubItems[3].Text;
              string address          =  lvwPlayerList.Items[i].SubItems[4].Text;
              string photo            =  lvwPlayerList.Items[i].SubItems[5].Text;
              bool isCaptain          = false;
              int position = 0;

             if(positionDesc == "Point guard")    position   = 1;
             if(positionDesc == "Shooting guard") position   = 2;
	         if(positionDesc == "Small forward")  position   = 3;
             if(positionDesc == "Power forward")  position   = 4;
             if(positionDesc == "Center")         position   = 5; 


              Player player = new Player();
              player.player_name          = playerName;
              player.player_jerseyNo      = jerseyNo;
              player.position.position_id = position;
              player.player_birthdate     = birhtdate;
              player.player_address       = address;
              //if (playerName.Contains("Team Captain") == true) isCaptain = true;    
              player.player_isCaptain     = isCaptain;
              player.player_photo         = photo;
              
              var teamId = TeamHelper.GetTeamLatestRecord();
              foreach (var list in teamId)
              {
                  player.team.team_id = list.team_id;
              }
              
               PlayerHelper.SavePlayer(player);
            }
            //
        
            MessageBox.Show("Team " + team.team_name + " Successfully Save!", "Team", MessageBoxButtons.OK, MessageBoxIcon.Information);

            picTeamLogo.Image = null;
            txtTeamName.Text  = "";
            txtSlogan.Text    = "";
            txtCoachFname.Text = "";
            txtCoachLname.Text = "";
            txtAssistantCoachFname.Text = "";
            txtAssistantCoachLname.Text = "";
            txtManagerFname.Text = "";
            txtManagerLname.Text = "";
            lvwPlayerList.Items.Clear();
        
        }

        private string getImage()
        {
            string team_image = null;
            Team team = new Team();
            try
            {
                byte[] by = null;

                MemoryStream ms = new MemoryStream();
                by = ms.GetBuffer();
                ms.Close();
            }
            catch (Exception) { }
            return team_image = team.ImageToBase64(picTeamLogo.Image, System.Drawing.Imaging.ImageFormat.Png);
        }
      
        private bool checkPlayers()
        {
            bool check = true;
            if (lvwPlayerList.Items.Count == 0)  { MessageBox.Show("Please Add Players.", "Player", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }
            if (lvwPlayerList.Items.Count < 2)  { MessageBox.Show("Please Add More Player, Every Team Has 2 Players.", "Player", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return false; }
     
            for (int i = 0; i < lvwPlayerList.Items.Count; i++)
            {
                string playerName = lvwPlayerList.Items[i].SubItems[0].Text;
                if (playerName.Contains("(Team Captain)") == false) check = false;
                else
                {
                    check = true;
                    break;
                 }
            }

            if (check == false) { MessageBox.Show("Please assign Team Captain. Every Team has One Team Captain.", "Player", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);}
            return check;
        }
        
        private bool ifPlayerExisting(int si)
        {   
            bool   result   = true; 
            string name     = Globals.PlayerInfo.player_name;
            string jerseyNo = Globals.PlayerInfo.player_jerseyNo;
            string editName = "";
            string editJN   = "";


           if(Globals.PlayerInfo.isPlayerAdd == false)
            {
              if (Globals.PlayerInfo.isOnTable == true)
                {
                  
                   try
                    {   
                        editName = lvwPlayerList.Items[si].SubItems[0].Text;
                        editJN   = lvwPlayerList.Items[si].SubItems[1].Text;
                    }
                   catch {  }
             
                  string[] words   = name.Split(' ');
                  string[] words2  = name.Split(' ');
                  string temp  = "";
                  string temp2 = "";

                   for (int i = 0; i < words.Length; i++)
                   {
                       if (i > 1) break;
                       temp  += words[i] + " ";
                   }

                   for (int i = 0; i < words2.Length; i++)
                   {
                       if (i > 1) break;
                       temp2 += words2[i] + " ";
                   }

                   if (temp2 == temp && editJN == jerseyNo) return true;
                }

            for(int i=0;i<lvwPlayerList.Items.Count;i++)
            {       
                string n = lvwPlayerList.Items[i].SubItems[0].Text;
                string j = lvwPlayerList.Items[i].SubItems[1].Text;
          
                if (name.Trim() == n.Trim())                                                                                                                         { MessageBox.Show("Player " + n + " already added", "Player", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Globals.PlayerInfo.player_name = ""; return false; }
                if (n.Contains(name) == true)                                                                                                                        { MessageBox.Show("Player " + name + " already added", "Player", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Globals.PlayerInfo.player_name = ""; return false; } 
                if (Globals.PlayerInfo.player_name.Contains("(Team Captain)") && n.Contains("(Team Captain)"))                                                       { MessageBox.Show("There's already a Team Captain!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Globals.PlayerInfo.player_name = ""; return false; }
                if (jerseyNo == j)                                                                                                                                   { MessageBox.Show("Jersey no. " + jerseyNo + " already taken", "Player", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); Globals.PlayerInfo.player_jerseyNo = ""; return false; }
            }
            
            }
            return result;
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveTeams_Click(object sender, EventArgs e)
        {

        }
    
    }
}
