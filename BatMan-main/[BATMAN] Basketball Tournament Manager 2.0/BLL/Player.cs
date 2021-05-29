using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.BLL
{
    public class Player 
    {
       public   int       player_id             { get; set; } 	
	   public   string    player_jerseyNo       { get; set; } 	
	   public   string    player_name	        { get; set; }  
	   public   string    player_birthdate      { get; set; }
       public   string    player_address        { get; set; }
       public   bool      player_isCaptain      { get; set; }
       public   string    player_photo          { get; set; } 
       public   Position  position		        { get; set; }
       public   Team      team                  { get; set; }



       public Player()
       {
           this.position = new Position();
           this.team     = new Team();
       }

       public bool validatePlayer(string fname,string lname,int age)
       {
           bool validate = true;
           if (player_photo.Length == 0)     { MessageBox.Show("Please Select Player Photo", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
           if (fname.Length == 0)            { MessageBox.Show("Please Input the Player  First Name", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
           if (lname.Length == 0)            { MessageBox.Show("Please Input the Player  Last  Name", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
           if (player_jerseyNo.Length == 0)  { MessageBox.Show("Please Input the Player  Jersey No.", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
           if (player_birthdate.Length == 0) { MessageBox.Show("Please Input the Player Birth Date", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
           if (age > 25)                     { MessageBox.Show("The Player is Over Age!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
           if (player_address.Length == 0)   { MessageBox.Show("Please Input the Player Address", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }

           return validate;
       }

       public bool isPlayerExisting()
       {
           bool check = true;

           var player = PlayerHelper.CheckPlayerList();

           foreach (var list in player)
           {
               if (player_name     == list.player_name) { MessageBox.Show("Player " + player_name + " Already existing on The Other Team.", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
           }
           return check;
       }
       
       public bool CheckPlayerOnTeam(string name , string jerseyNo)
       {
           SqlParameter[] p = { new SqlParameter("@team_id", team.team_id) };
           var checkPlayer = PlayerHelper.CheckPlayerOnTeam(p);
           foreach (var list in checkPlayer)
           {
               if (player_name == list.player_name && player_name != name) 
               {
                   MessageBox.Show("Player " + player_name + " Already existing On the Team!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; 
               }

               if (player_jerseyNo == list.player_jerseyNo && player_jerseyNo != jerseyNo)
               {
                   MessageBox.Show("Jersey No. " + player_jerseyNo + " Already existing On the other Player on Team!", "Player", MessageBoxButtons.OK, MessageBoxIcon.Information); return false;
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
