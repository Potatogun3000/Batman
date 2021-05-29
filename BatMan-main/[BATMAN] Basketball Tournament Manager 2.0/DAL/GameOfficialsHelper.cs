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
    public class GameOfficialsHelper
    {
        public static bool SaveGameOfficial(GameOfficial gameOfficial)
        {
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return false;

                SqlParameter[] param = { 
                                        new SqlParameter("@gameOfficialId",       gameOfficial.gameofficialID),
                                        new SqlParameter("@gameOfficialName",     gameOfficial.gameofficialName),
                                        new SqlParameter("@gameOfficialDesc",     gameOfficial.gameofficialDesc),
                                        };
                dal.ExecuteNonQuery("SaveGameOfficial", param);
                return true;
            }
        }

        public static List<GameOfficial> GetGameOfficialList()
        {
            List<GameOfficial> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetGameOfficialList").Tables[0];

                list = new List<GameOfficial>();
                foreach (DataRow dr in data.AsEnumerable())
                {
                    GameOfficial gameOfficial       = new GameOfficial();
                    gameOfficial.gameofficialID     = dr.Field<int>("gameOfficialId");
                    gameOfficial.gameofficialName   = dr.Field<string>("gameOfficialName");
                    gameOfficial.gameofficialDesc   = dr.Field<string>("gameOfficialDesc");
                  
                    list.Add(gameOfficial);
                }

            }
            return list;
        }
        public static List<GameOfficial> GetGameOfficialReferee()
        {
            List<GameOfficial> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetGameOfficialReferee").Tables[0];

                list = new List<GameOfficial>();
                foreach (DataRow dr in data.AsEnumerable())
                {
                    GameOfficial gameOfficial = new GameOfficial();
                    gameOfficial.gameofficialID = dr.Field<int>("gameOfficialId");
                    gameOfficial.gameofficialName = dr.Field<string>("gameOfficialName");
                    gameOfficial.gameofficialDesc = dr.Field<string>("gameOfficialDesc");

                    list.Add(gameOfficial);
                }

            }
            return list;
        }

        public static bool DeleteGameOfficial(int gameOfficialId)
        {
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return false;

                SqlParameter[] param = { new SqlParameter("@gameOfficialId", gameOfficialId) };
                dal.ExecuteNonQuery("DeleteGameOfficial", param);
                return true;
            }
        }

        public static List<GameOfficial> SearchGameOfficial(SqlParameter[] p)
        {
            List<GameOfficial> list = null;
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("SearchGameOfficial", p).Tables[0];

                list = new List<GameOfficial>();
                foreach (DataRow dr in data.AsEnumerable())
                {
                    GameOfficial gameOfficial = new GameOfficial();
                    gameOfficial.gameofficialID = dr.Field<int>("gameOfficialId");
                    gameOfficial.gameofficialName = dr.Field<string>("gameOfficialName");
                    gameOfficial.gameofficialDesc = dr.Field<string>("gameOfficialDesc");

                    list.Add(gameOfficial);
                }
            }
            return list;
        }
    
    
    }
}
