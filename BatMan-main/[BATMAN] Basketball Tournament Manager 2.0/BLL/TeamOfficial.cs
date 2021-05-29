using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.BLL
{
    public class TeamOfficial 
    { 
     
     public int       teamOfficial_id	       { get; set; }		
	 public string    teamOfficial_name	       { get; set; }		
     public string    teamOfficial_desc        { get; set; }
     public string    teamName                 { get; set; }


     public bool validateTeamOfficial(string coachfname, string coachlname, string asstfname, string asstlname,
                              string managerfname, string managerlname)
     {
         if (coachfname.Length == 0) { MessageBox.Show("Please Input Coach First Name", "Team Official", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
         if (coachlname.Length == 0) { MessageBox.Show("Please Input Coach Last Name", "Team Official", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
         if (asstfname.Length == 0) { MessageBox.Show("Please Input Assistant Coach First Name", "Team Official", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
         if (asstlname.Length == 0) { MessageBox.Show("Please Input Assistant Coach Last Name", "Team Official", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
         if (managerfname.Length == 0) { MessageBox.Show("Please Input Team Manager First Name", "Team Official", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
         if (managerlname.Length == 0) { MessageBox.Show("Please Input Team Manager Last Name", "Team Official", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
         if (teamOfficial_desc.Length == 0) { MessageBox.Show("Please Input the Team Name", "Team", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }


         string ValidateCoach     = coachfname   +  " " + coachlname + " ";
         string ValidateAsstCoach = asstfname    +  " " + asstlname  + " ";
         string ValidateManager   = managerfname +  " " + managerlname + " ";


         string checkCoach = null;
         string checkAsstCoach = null;
         string checkManager = null;

         var checkIfExistring = TeamOfficialHelper.GetTeamOfficialList();

         foreach (var list in checkIfExistring)
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
                     checkCoach += item + " ";
                     checkAsstCoach += ac[ctr2] + " ";
                     checkManager += m[ctr2] +" ";
                 }

                 if (ctr2 == 1)
                 {
                     checkCoach += item + " ";
                     checkAsstCoach += ac[ctr2] + " ";
                     checkManager += m[ctr2] + " ";
                 }
                 ctr2++;
             }
         }

         if (ValidateCoach == checkCoach)         { MessageBox.Show("Coach "+ ValidateCoach + " Already Exist on Other Team", "Team Official", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
         if (ValidateAsstCoach == checkAsstCoach) { MessageBox.Show("Assistant Coach " +  ValidateAsstCoach + " Already Exist on Other Team", "Team Official", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
         if (ValidateManager == checkManager)     { MessageBox.Show("Team Manager " + ValidateManager + " Already Exist on Other Team", "Team Official", MessageBoxButtons.OK, MessageBoxIcon.Information); return false; }
    
         return true;
       	}
   }
}

