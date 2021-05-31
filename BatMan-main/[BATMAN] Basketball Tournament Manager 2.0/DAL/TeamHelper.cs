using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.DAL
{
    public class TeamHelper
    {
        public static void SaveTeam(Team team)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {  
                                           new SqlParameter("@team_name",    team.team_name),
                                           new SqlParameter("@team_slogan",  team.team_slogan),
                                           new SqlParameter("@team_logo",    team.team_logo),
                                           new SqlParameter("@barangay",     team.barangay.brgyID),
                                           new SqlParameter("@teamOfficial", team.teamOfficial.teamOfficial_id),
                                           new SqlParameter("@tournament",   team.tournament.tournament_id)
                                       };

                db_conn.ExecuteNonQuery("SaveTeam", param);
            }
        }

        public static void UpdateTeam(Team team)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {  
                                           new SqlParameter("@team_id",       team.team_id),
                                           new SqlParameter("@team_name",    team.team_name),
                                           new SqlParameter("@team_slogan",  team.team_slogan),
                                           new SqlParameter("@team_logo",    team.team_logo),
                                           new SqlParameter("@barangay",     team.barangay.brgyID)
                                       };

                db_conn.ExecuteNonQuery("UpdateTeam", param);
            }
        }


        public static List<Team> GetTeamLatestRecord()
        {
            List<Team> list = null;
 
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTeamLatestRecord").Tables[0];

                list = new List<Team>();
                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_id = dr.Field<int>("teamID");
                    list.Add(team);
                }
            }
            return list;
        }

        public static List<Team> CheckTeamList()
        {
            List<Team> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("CheckTeamList").Tables[0];

                list = new List<Team>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_id                            = dr.Field<int>("teamID");
                    team.team_name                          = dr.Field<string>("teamName");
                    team.team_slogan                        = dr.Field<string>("teamSlogan");
                    team.team_logo                          = dr.Field<string>("teamLogo");
                    team.barangay.brgyID                   = dr.Field<int>("barangay");
                    team.teamOfficial.teamOfficial_id       = dr.Field<int>("teamOfficial");
                    team.tournament.tournament_id           = dr.Field<int>("tournament");
                    list.Add(team);
                }

            }
            return list;
        }

        public static List<Team> GetTeamList()
        {
            List<Team> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTeamList").Tables[0];

                list = new List<Team>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_id                            = dr.Field<int>("teamID");
                    team.team_name                          = dr.Field<string>("teamName");
                    team.team_slogan                        = dr.Field<string>("teamSlogan");
                    team.team_logo                          = dr.Field<string>("teamLogo");
                    team.barangay.brgyName                 = dr.Field<string>("brgyName");
                    team.teamOfficial.teamOfficial_name     = dr.Field<string>("teamOfficialName");
                    team.teamOfficial.teamOfficial_desc     = dr.Field<string>("teamOfficialDesc");
                    team.tournament.tournament_year         = dr.Field<string>("tournamentYear");
                    list.Add(team);
                }

            }
            return list;
        }

        public static List<Team> GetTeamListwLogo(SqlParameter[] p)
        {
            List<Team> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTeamListwLogo", p).Tables[0];

                list = new List<Team>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_id                        = dr.Field<int>("teamID");
                    team.team_name                      = dr.Field<string>("teamName");
                    team.team_slogan                    = dr.Field<string>("teamSlogan");
                    team.team_logo                      = dr.Field<string>("teamLogo");
                    team.barangay.brgyName             = dr.Field<string>("brgyName");
                    team.teamOfficial.teamOfficial_name = dr.Field<string>("teamOfficialName");
                    team.teamOfficial.teamOfficial_desc = dr.Field<string>("teamOfficialDesc");
                    team.tournament.tournament_year     = dr.Field<string>("tournamentYear");
                    list.Add(team);
                }

            }
            return list;
        }

        public static List<Player> GetTeamPlayers(SqlParameter[] p)
        {
            List<Player> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTeamPlayers", p).Tables[0];

                list = new List<Player>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Player player = new Player();
                    
                    player.player_id              = dr.Field<int>("playerID");
                    player.player_jerseyNo        = dr.Field<string>("jerseyNo");
                    player.player_name            = dr.Field<string>("playerName");
                    player.player_address         = dr.Field<string>("playerAddress");
                    player.player_birthdate       = dr.Field<string>("playerBirthdate");
                    player.player_isCaptain       = dr.Field<bool>("isCaptain");
                    player.position.position_desc = dr.Field<string>("positionDesc");
                

                    list.Add(player);
                }

            }
            return list;
        }


        public static List<Team> SearchTeam(SqlParameter[] p)
        {
            List<Team> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("SearchTeam", p).Tables[0];

                list = new List<Team>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_id = dr.Field<int>("teamID");
                    team.team_name = dr.Field<string>("teamName");
                    team.team_slogan = dr.Field<string>("teamSlogan");
                    team.team_logo = dr.Field<string>("teamLogo");
                    team.barangay.brgyName = dr.Field<string>("brgyName");
                    team.teamOfficial.teamOfficial_name = dr.Field<string>("teamOfficialName");
                    team.teamOfficial.teamOfficial_desc = dr.Field<string>("teamOfficialDesc");
                    team.tournament.tournament_year = dr.Field<string>("tournamentYear");
                    list.Add(team);
                }

            }
            return list;
        }


        public static bool DeleteTeam(int team_id)
        {
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return false;

                SqlParameter[] param = { new SqlParameter("@team_id", team_id) };
                dal.ExecuteNonQuery("DeleteTeam", param);
                return true;
            }
        }

        public static List<Team> checkRoasterTeamList()
        {
            List<Team> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("checkRoasterTeamList").Tables[0];

                list = new List<Team>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_id = dr.Field<int>("teamID");
                    team.team_name = dr.Field<string>("teamName");
                    team.team_slogan = dr.Field<string>("teamSlogan");
                    team.team_logo = dr.Field<string>("teamLogo");
                    team.barangay.brgyName = dr.Field<string>("brgyName");
                    team.teamOfficial.teamOfficial_name = dr.Field<string>("teamOfficialName");
                    team.teamOfficial.teamOfficial_desc = dr.Field<string>("teamOfficialDesc");
                    team.tournament.tournament_year = dr.Field<string>("tournamentYear");
                    list.Add(team);
                }

            }
            return list;
        }

        public static List<Team> getRosterTeamList(SqlParameter[] p)
        {
            List<Team> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("getRosterTeamList",p).Tables[0];

                list = new List<Team>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_name                       = dr.Field<string>("teamName");
                    team.teamOfficial.teamOfficial_name  = dr.Field<string>("teamOfficialName");
                    team.tournament.tournament_year      = dr.Field<string>("tournamentYear");
                    team.tournament.tournament_schedule  = dr.Field<string>("tournamentSched");
                   
                    list.Add(team);
                }

            }
            return list;
        }

        public static List<Player> getRosterPlayerList(SqlParameter[] p)
        {
            List<Player> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("getRosterPlayerList",p).Tables[0];

                list = new List<Player>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Player player = new Player();
                   
                    player.team.team_name  = dr.Field<string>("teamName");
                    player.player_jerseyNo = dr.Field<string>("jerseyNo");
                    player.player_name     = dr.Field<string>("playerName");

                    list.Add(player);
                }

            }
            return list;
        }

        public static List<Team> getTeamForMatch()
        {
            List<Team> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("getTeamForMatch").Tables[0];

                list = new List<Team>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_name = dr.Field<string>("teamName");
                    team.teamOfficial.teamOfficial_name = dr.Field<string>("teamOfficialName");
       
                    list.Add(team);
                }

            }
            return list;
        }



    }
}
