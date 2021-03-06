using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.DAL
{
    public class AwardHelper
    {

        public static void SaveAwards(Awards award)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {  
                                           new SqlParameter("@award_champion",      award.awardChampionship),
                                           new SqlParameter("@award_mvp",           award.awardMVP),
                                           new SqlParameter("@award_firstRunnerUp",           award.awardFirstRunnerUp),
                                           new SqlParameter("@award_sf",            award.awardSF),
                                           new SqlParameter("@award_pf",            award.awardPF),
                                           new SqlParameter("@award_pg",            award.awardPG),
                                           new SqlParameter("@award_sg",            award.awardSG),
                                           new SqlParameter("@award_c",             award.awardC),
                                           new SqlParameter("@tournamentYear",      award.tournament.tournament_id)
                                       };
                db_conn.ExecuteNonQuery("SaveAwards", param);
            }
        }

        public static List<Awards> getAwardList()
        {
            List<Awards> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("getAwardList").Tables[0];

                list = new List<Awards>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Awards awards = new Awards();

                    awards.awardID = dr.Field<int>("awardID");
                    awards.awardChampionship = dr.Field<string>("awardChamp");
                    awards.awardFirstRunnerUp = dr.Field<string>("awardFirstRunner");
                    awards.awardMVP = dr.Field<string>("awardMVP");
                    awards.awardSF = dr.Field<string>("awardSF");
                    awards.awardPF = dr.Field<string>("awardPF");
                    awards.awardPG = dr.Field<string>("awardPG");
                    awards.awardSG = dr.Field<string>("awardSG");
                    awards.awardC = dr.Field<string>("awardC");
                    awards.tournament.tournament_id = dr.Field<int>("tournamentYear");
                    list.Add(awards);
                }
            }

            return list;
        }

        public static List<Awards> checkAward()
        {
            List<Awards> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("checkAward").Tables[0];

                list = new List<Awards>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Awards awards = new Awards();
                    awards.tournament.tournament_id = dr.Field<int>("tournamentYear");
                    list.Add(awards);
                }
            }

            return list;
        }


    
    
    }
}
