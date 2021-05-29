using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.BLL
{
    public class Match
    {  
       public int match_id		               { get; set;  }
       public int match_gameNo                 { get; set;  }
       public string match_venue               { get; set;  }
       public GameOfficial match_referee1      { get; set;  }
       public GameOfficial match_referee2      { get; set;  }
       public Team         match_homeTeam      { get; set;  }
       public Team          match_guestTeam    { get; set;  }
       public string match_status              { get; set;  }
        public Tournament tournament           { get; set;  }

        public Match()
        {
            this.tournament = new Tournament();
            this.match_referee1  = new GameOfficial();
            this.match_referee2  = new GameOfficial();
            this.match_guestTeam = new Team();
            this.match_homeTeam  = new Team();
        }

 
        public bool checkIfMatchCreated()
        {
            var check = MatchHelper.LoadMatchList();
            int count = 0;
     
            foreach (var item in check)
            {

                count++;
            }

            if (count != 0)
            {
                MessageBox.Show("Match Has been Generated! You Can't Create Match for this year "+ DateTime.Now.Year,"Create Match",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public bool checkIfMatchEnd()
        {

            var matchList = MatchHelper.LoadMatchList();
            int count = 0;
            foreach (var match in matchList)
            {   
                if(match.match_status == "ON GOING")
                {
                    MessageBox.Show("You can't Generate the Award. You need to Record First All the Matches.", "Awards", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                count++;
            }

            if (count == 0)
            {
                MessageBox.Show("You can't Generate the Award, Please Create First The Match!", "Awards", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }



            return true;
        }
 
    }
}
