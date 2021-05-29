using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.BLL
{
    public class PlayerStat
    {

        public int       player_statId        { get; set; }
        public int       player_point         { get; set; }
        public int       player_reb           { get; set; }
        public int       player_asst          { get; set; }
        public int       player_steal         { get; set; }
        public int       player_to            { get; set; }
        public int       player_ft            { get; set; }
        public int       player_fouls         { get; set; }
        public string    team_desc            { get; set; }
        public Match     match                { get; set; }
        public Player    player               { get; set; }
        public Position  position             { get; set; }  


        public PlayerStat()
        {
            this.player = new Player();
            this.match    = new Match();
            this.position = new Position();
        }

    }
}
