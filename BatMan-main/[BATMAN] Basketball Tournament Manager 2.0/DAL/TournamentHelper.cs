using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using System.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.DAL
{
    public class TournamentHelper
    {

        public static bool SaveTournament(Tournament tournament)
        {
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return false;

                SqlParameter[] param = { 
                                        new SqlParameter("@tournament_id",       tournament.tournament_id),
                                        new SqlParameter("@tournament_year",     tournament.tournament_year),
                                        new SqlParameter("@tournament_schedule", tournament.tournament_schedule),
                                        new SqlParameter("@tournament_motto",    tournament.tournament_motto),
                                        new SqlParameter("@tournament_status",   tournament.tournament_status)
                                        };

                                        dal.ExecuteNonQuery("SaveTournament", param);
                                        return true;
            }
         }

        public static List<Tournament> GetTournamentList()
        {
            List<Tournament> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTournamentList").Tables[0];

                list = new List<Tournament>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Tournament tournament = new Tournament();
                    tournament.tournament_id         = dr.Field<int>("tournament_id");
                    tournament.tournament_year       = dr.Field<string>("tournament_year");
                    tournament.tournament_schedule   = dr.Field<string>("tournament_schedule");
                    tournament.tournament_motto      = dr.Field<string>("tournament_motto");
                    tournament.tournament_status     = dr.Field<string>("tournament_status");

                    list.Add(tournament);
                }
            }
            return list;
          }


        public static bool DeleteTournament(int tournamentId)
        {
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return false;

                SqlParameter[] param = { new SqlParameter("@tournament_id", tournamentId) };
                dal.ExecuteNonQuery("DeleteTournament", param);
                return true;
            }
        }

        public static List<Tournament> SearchTournament(SqlParameter[] p)
        {
            List<Tournament> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("SearchTournament",p).Tables[0];

                list = new List<Tournament>();
                foreach (DataRow dr in data.AsEnumerable())
                {
                    Tournament tournament = new Tournament();
                    tournament.tournament_id        = dr.Field<int>("tournament_id");
                    tournament.tournament_year      = dr.Field<string>("tournament_year");
                    tournament.tournament_schedule  = dr.Field<string>("tournament_schedule");
                    tournament.tournament_motto     = dr.Field<string>("tournament_motto");
                    tournament.tournament_status    = dr.Field<string>("tournament_status");
                    list.Add(tournament);
                }
            }
            return list;
        }

        public static List<Tournament> CheckTournamentStatus()
        {
            List<Tournament> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("CheckTournamentStatus").Tables[0];

                list = new List<Tournament>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Tournament tournament = new Tournament();
                    tournament.tournament_id = dr.Field<int>("tournamentID");
                    tournament.tournament_year = dr.Field<string>("tournamentYear");
                    tournament.tournament_schedule = dr.Field<string>("tournamentSched");
                    tournament.tournament_motto = dr.Field<string>("tournamentMotto");
                    tournament.tournament_status = dr.Field<string>("tournamentStatus");
                    list.Add(tournament);
                }
            }
             return list;
          }

        public static List<Tournament> GetTournamentLatestRecord()
        {
            List<Tournament> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTournamentLatestRecord").Tables[0];

                list = new List<Tournament>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Tournament tournament = new Tournament();
                    tournament.tournament_id = dr.Field<int>("tournament_id");
                    list.Add(tournament);
                }

            }

            return list;
        }

        public static bool UpdateTournamentStatus(Tournament tournament)
        {
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return false;

                SqlParameter[] param = { 
                                        new SqlParameter("@tournament_id",       tournament.tournament_id),
                                        new SqlParameter("@tournament_status",   tournament.tournament_status)
                                        };

                dal.ExecuteNonQuery("UpdateTournamentStatus", param);
                return true;
            }
        }

  
    }
}
