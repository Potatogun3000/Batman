using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.BLL
{
    public class Team 
    {  
        public int             team_id                   { get; set; }
        public string          team_name                 { get; set; }
        public string          team_slogan               { get; set; }
        public string          team_logo                 { get; set; }
      
        public Barangay        barangay                  { get; set; }
        public TeamOfficial    teamOfficial              { get; set; }
        public Tournament      tournament                { get; set; }

        public Team()
        {
            this.barangay     = new Barangay();
            this.teamOfficial = new TeamOfficial();
            this.tournament   = new Tournament();
        }

        public bool validateTeam(string brgy)
        {
            bool validate = true;
       
            if (team_logo.Length     == 0) { MessageBox.Show("Please Choose Team Logo", "Team", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (team_name.Length     == 0) { MessageBox.Show("Please Input the Team Name", "Team", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            if (team_slogan.Length   == 0) { MessageBox.Show("Please Input the Team Slogan", "Team", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }

            
            var team  = TeamHelper.CheckTeamList();
            int brgy_id = barangay.brgyID;

            foreach (var list in team)
            {   
                if (team_name == list.team_name)      { MessageBox.Show("Team Name Already Taken. Please Choose Another One.", "Team", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
                if (brgy_id == list.barangay.brgyID) { MessageBox.Show("Barangay " + brgy + " Already have a team.", "Team", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
            }

            return validate;
        }

        public bool checkBrgyAndTeam(string barangay , string team)
        {
            var check = TeamHelper.GetTeamList();

            foreach (var list in check)
            {
                if (team == list.team_name && barangay != list.barangay.brgyName)
                {
                    MessageBox.Show("Team Name," + team + " has Already a Taken by another Team", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
             return true;
        }


        public string ImageToBase64(Image image,
        System.Drawing.Imaging.ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                byte[] imageBytes;
                string base64String = "";
                try
                {
                    if (image != null) {
                    // Convert Image to byte[]
                    image.Save(ms, format);
                    imageBytes = ms.ToArray();
                    // Convert byte[] to Base64 String
                    base64String = Convert.ToBase64String(imageBytes);
                    }
                }
                catch (Exception) { }

                return base64String;
            }
        }

        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
  
    }
}
