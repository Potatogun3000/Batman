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
    public class MatchHelper
    {
        public static void SaveMatch(Match match)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {  
                                           new SqlParameter("@match_gameNo",       match.match_gameNo),
                                           new SqlParameter("@match_venue",        match.match_venue),
                                           new SqlParameter("@match_referee1",     match.match_referee1.gameofficialName),
                                           new SqlParameter("@match_referee2",     match.match_referee2.gameofficialName),
                                           new SqlParameter("@match_homeTeam",     match.match_homeTeam.team_name),
                                           new SqlParameter("@match_guestTeam",    match.match_guestTeam.team_name),
                                           new SqlParameter("@match_status",       match.match_status),
                                           new SqlParameter("@tournamentYear",     match.tournament.tournament_id)
                                       };

                db_conn.ExecuteNonQuery("SaveMatch", param);
            }
        }


        public static List<Team> GetTeamId(SqlParameter[] p)
        {
            List<Team> list = null;
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTeamId", p).Tables[0];

                list = new List<Team>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_id = dr.Field<int>("team_id");
                    list.Add(team);
                }
            }
            return list;
        }



        public static List<Match> GetMatchList(SqlParameter[] p)
        {
            List<Match> list = null;
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetMatchList", p).Tables[0];

                list = new List<Match>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Match match = new Match();
                    match.match_id = dr.Field<int>("match_id");
                    match.match_gameNo = dr.Field<int>("match_gameNo");
                    match.match_referee1.gameofficialName = dr.Field<string>("match_referee1");
                    match.match_referee2.gameofficialName = dr.Field<string>("match_referee2");
                    match.match_homeTeam.team_name = dr.Field<string>("match_homeTeam");
                    match.match_guestTeam.team_name = dr.Field<string>("match_guestTeam");
                    match.match_venue = dr.Field<string>("match_venue");
                    match.match_status = dr.Field<string>("match_status");
                    list.Add(match);
                }
            }
            return list;
        }

        public static List<Match> LoadMatchList()
        {
            List<Match> list = null;
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("LoadMatchList").Tables[0];

                list = new List<Match>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Match match = new Match();
                    match.match_id = dr.Field<int>("match_id");
                    match.match_gameNo                      = dr.Field<int>("match_gameNo");
                    match.match_referee1.gameofficialName   = dr.Field<string>("match_referee1");
                    match.match_referee2.gameofficialName   = dr.Field<string>("match_referee2");
                    match.match_homeTeam.team_name          = dr.Field<string>("match_homeTeam");
                    match.match_guestTeam.team_name         = dr.Field<string>("match_guestTeam");
                    match.match_venue                       = dr.Field<string>("match_venue");
                    match.match_status                      = dr.Field<string>("match_status");
                    list.Add(match);
                }
            }
            return list;
        }


        public static List<Player> GetMatchPlayer(SqlParameter[] p)
        {
            List<Player> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetMatchPlayer", p).Tables[0];

                list = new List<Player>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Player player = new Player();

                    player.player_jerseyNo        = dr.Field<string>("player_jerseyNo");
                    player.player_name            = dr.Field<string>("player_name");
                    player.team.team_name         = dr.Field<string>("team_name");
                    player.position.position_desc = dr.Field<string>("position_desc");

                    list.Add(player);
                }
            }

            return list;
        }

        public static void UpdateMatchStatus(Match match)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {  
                                           new SqlParameter("@match_id",      match.match_id),
                                           new SqlParameter("@match_status",  match.match_status)
                                       };

                db_conn.ExecuteNonQuery("UpdateMatchStatus", param);
            }
        }


        public static List<Match> getMatchName(SqlParameter[] p)
        {
            List<Match> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("getMatchName", p).Tables[0];

                list = new List<Match>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Match match = new Match();

                    match.match_homeTeam.team_name  = dr.Field<string>("match_homeTeam");
                    match.match_guestTeam.team_name = dr.Field<string>("match_guestTeam");
                    match.match_referee1.gameofficialName = dr.Field<string>("match_referee1");
                    match.match_referee2.gameofficialName = dr.Field<string>("match_referee2");
                    match.match_gameNo              = dr.Field<int>("match_gameNo");

                    list.Add(match);
                }
            }

            return list;
        }

        public static List<Team> getMatchTeamLogo(SqlParameter[] p)
        {
            List<Team> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("getMatchTeamLogo", p).Tables[0];

                list = new List<Team>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Team team = new Team();
                    team.team_logo = dr.Field<string>("team_logo");
                    list.Add(team);
                }

            }
            return list;
        }


    
        
    
    }
}
