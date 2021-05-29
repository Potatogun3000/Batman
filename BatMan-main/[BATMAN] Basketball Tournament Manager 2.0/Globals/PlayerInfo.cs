using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.Globals
{
    class PlayerInfo
    {
        public static int    teamId             { get; set; }
        public static string player_jerseyNo    { get; set; }
        public static string player_name        { get; set; }
        public static string player_birthdate   { get; set; }
        public static int    player_age         { get; set; }
        public static string player_address     { get; set; }
        public static string player_postition   { get; set; }
        public static string player_photo       { get; set; }


        public static bool   isPlayerAdd        { get; set; }
        public static bool   isPlayerEdit       { get; set; }
        public static bool   isOnTable          { get; set; }
    }   
}
