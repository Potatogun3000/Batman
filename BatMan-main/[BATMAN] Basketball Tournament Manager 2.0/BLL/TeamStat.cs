using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.BLL
{
    public class TeamStat
    {
        public string  team_name             { get; set; }
        public int     teamStat_totalScore   { get; set; }
        public int     teamStat_id           { get; set; }
        public int     team_statQ1           { get; set; }
        public int     team_statQ2           { get; set; }
        public int     team_statQ3           { get; set; }
        public int     team_statQ4           { get; set; }
        public string  team_desc             { get; set; }
        public Match   match                 { get; set; }

        public TeamStat()
        {
            this.match = new Match();
        } 
	  
    }
}
