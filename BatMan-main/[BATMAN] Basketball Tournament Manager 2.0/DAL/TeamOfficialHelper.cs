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
    public class TeamOfficialHelper
    {

        public static void SaveTeamOfficial(TeamOfficial teamOfficial)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {  
                                           new SqlParameter("@teamOfficial_name",   teamOfficial.teamOfficial_name),
                                           new SqlParameter("@teamOfficial_desc",   teamOfficial.teamOfficial_desc),
                                       };

                db_conn.ExecuteNonQuery("SaveTeamOfficial", param);
            }
        }


        public static void UpdateTeamOfficial(TeamOfficial teamOfficial)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {  
                                           new SqlParameter("@teamOfficial_id",     teamOfficial.teamOfficial_id),
                                           new SqlParameter("@teamOfficial_name",   teamOfficial.teamOfficial_name),
                                           new SqlParameter("@teamOfficial_desc",   teamOfficial.teamOfficial_desc)
                                       };
                db_conn.ExecuteNonQuery("UpdateTeamOfficial", param);
            }
        }

        public static List<TeamOfficial> GetTeamOfficialLatestRecord()
        {
            List<TeamOfficial> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTeamOfficialLatestRecord").Tables[0];

                list = new List<TeamOfficial>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    TeamOfficial teamOfficial = new TeamOfficial();
                    teamOfficial.teamOfficial_id    = dr.Field<int>("teamOfficialID");
                    teamOfficial.teamOfficial_name  = dr.Field<string>("teamOfficialName");
                    teamOfficial.teamOfficial_desc  = dr.Field<string>("teamOfficialDesc");
                    list.Add(teamOfficial);
                }

            }

            return list;
        }


        public static List<TeamOfficial> GetTeamOfficialList()
        {
            List<TeamOfficial> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTeamOfficialList").Tables[0];

                list = new List<TeamOfficial>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    TeamOfficial teamOfficial      = new TeamOfficial();
                    teamOfficial.teamOfficial_id   = dr.Field<int>   ("teamOfficialID");
                    teamOfficial.teamOfficial_name = dr.Field<string>("teamOfficialName");
                    teamOfficial.teamOfficial_desc = dr.Field<string>("teamOfficialDesc");
                    teamOfficial.teamName          = dr.Field<string>("teamName");
                    list.Add(teamOfficial);
                }

            }

            return list;
        }

        public static List<TeamOfficial> GetTeamOfficialtoUpdate(SqlParameter[] p)
        {
            List<TeamOfficial> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetTeamOfficialtoUpdate",p).Tables[0];

                list = new List<TeamOfficial>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    TeamOfficial teamOfficial      = new TeamOfficial();
                    teamOfficial.teamOfficial_id = dr.Field<int>("teamOfficialID");
                    teamOfficial.teamOfficial_name = dr.Field<string>("teamOfficialName");
                    teamOfficial.teamOfficial_desc = dr.Field<string>("teamOfficialDesc");
                    list.Add(teamOfficial);
                }

            }

            return list;
        }


        public static List<TeamOfficial> SearchTeamOfficial(SqlParameter[] p)
        {
            List<TeamOfficial> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("SearchTeamOffcial",p).Tables[0];

                list = new List<TeamOfficial>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    TeamOfficial teamOfficial      = new TeamOfficial();
                    teamOfficial.teamOfficial_id = dr.Field<int>("teamOfficialID");
                    teamOfficial.teamOfficial_name = dr.Field<string>("teamOfficialName");
                    teamOfficial.teamOfficial_desc = dr.Field<string>("teamOfficialDesc");
                    teamOfficial.teamName = dr.Field<string>("teamName");
                    list.Add(teamOfficial);
                }

            }

            return list;
        }
    

    }
}
