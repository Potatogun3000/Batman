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
    public  class PlayerStatHelper
    {
        public static void SavePlayerStat(PlayerStat playerStat)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {  
                                           new SqlParameter("@JerseyNo",           playerStat.player.player_jerseyNo),
                                           new SqlParameter("@playerName",         playerStat.player.player_name),
                                           new SqlParameter("@playerPosition",     playerStat.position.position_desc),
                                           new SqlParameter("@playerPoint",        playerStat.player_point),
                                           new SqlParameter("@playerReb",         playerStat.player_reb),
                                           new SqlParameter("@playerAssist",        playerStat.player_ft),
                                           new SqlParameter("@playerSteal",       playerStat.player_steal),
                                           new SqlParameter("@playerTurnOver",          playerStat.player_to),
                                           new SqlParameter("@playerFreeThrows",          playerStat.player_ft),
                                           new SqlParameter("@playerFouls",       playerStat.player_fouls),
                                           new SqlParameter("@teamDesc",          playerStat.team_desc),
                                           new SqlParameter("@match",              playerStat.match.match_id)
                                        
                                       };

                db_conn.ExecuteNonQuery("SavePlayerStat", param);
            }
        }

        public static List<PlayerStat> GetPlayerHT(SqlParameter[] p)
        {
            List<PlayerStat> list = null;
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetPlayerHT", p).Tables[0];

                list = new List<PlayerStat>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    PlayerStat playerStat = new PlayerStat();
                    playerStat.player_statId             = dr.Field<int>("playerStatId");
                    playerStat.player.player_jerseyNo    = dr.Field<string>("JerseyNo");
                    playerStat.position.position_desc    = dr.Field<string>("playerPosition");
                    playerStat.player.player_name        = dr.Field<string>("playerName");
                    playerStat.player_point              = dr.Field<int>("playerPoint");
                    playerStat.player_reb                = dr.Field<int>("playerReb");
                    playerStat.player_asst               = dr.Field<int>("playerAssist");
                    playerStat.player_steal              = dr.Field<int>("playerSteal");
                    playerStat.player_to                 = dr.Field<int>("playerTurnOver");
                    playerStat.player_ft                 = dr.Field<int>("playerFreethrows");
                    playerStat.player_fouls              = dr.Field<int>("playerFouls");
                    playerStat.team_desc                 = dr.Field<string>("teamDesc");
                    playerStat.match.match_id            = dr.Field<int>("match");

                    list.Add(playerStat);
                }
            }
            return list;
        }

        public static List<PlayerStat> GetPlayerGT(SqlParameter[] p)
        {
            List<PlayerStat> list = null;
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetPlayerGT", p).Tables[0];

                list = new List<PlayerStat>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    PlayerStat playerStat = new PlayerStat();
                    playerStat.player_statId            = dr.Field<int>("playerStatId");
                    playerStat.player.player_jerseyNo   = dr.Field<string>("JerseyNo");
                    playerStat.position.position_desc   = dr.Field<string>("playerPosition");
                    playerStat.player.player_name       = dr.Field<string>("playerName");
                    playerStat.player_point             = dr.Field<int>("playerPoint");
                    playerStat.player_reb               = dr.Field<int>("playerReb");
                    playerStat.player_asst              = dr.Field<int>("playerAssist");
                    playerStat.player_steal             = dr.Field<int>("playerSteal");
                    playerStat.player_to                = dr.Field<int>("playerTurnOver");
                    playerStat.player_ft                = dr.Field<int>("playerFreethrows");
                    playerStat.player_fouls             = dr.Field<int>("playerFouls");
                    playerStat.team_desc                = dr.Field<string>("teamDesc");
                    playerStat.match.match_id           = dr.Field<int>("match");

                    list.Add(playerStat);
                }
            }
            return list;
        }


        public static List<PlayerStat> getMVP(SqlParameter[] p)
        {
            List<PlayerStat> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("getMVP", p).Tables[0];

                list = new List<PlayerStat>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    PlayerStat playerStat = new PlayerStat();
                    playerStat.player_point = dr.Field<int>("MVP");
                    list.Add(playerStat);
                }
              }
            return list;
        }

        public static List<PlayerStat> getSF(SqlParameter[] p)
        {
            List<PlayerStat> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                try
                {
                    if (!dal.IsConnected) return null;
                    var data = dal.ExecuteQuery("getSF", p).Tables[0];

                    list = new List<PlayerStat>();

                    foreach (DataRow dr in data.AsEnumerable())
                    {
                        PlayerStat playerStat = new PlayerStat();
                        playerStat.player_point = dr.Field<int>("MVP");
                        list.Add(playerStat);
                    }
            
                }
                catch (Exception)
                {
                    
                
                }
             
            
            }
            return list;
        }


        public static List<PlayerStat> getPF(SqlParameter[] p)
        {
            List<PlayerStat> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                try
                {
                    if (!dal.IsConnected) return null;
                    var data = dal.ExecuteQuery("getPF", p).Tables[0];

                    list = new List<PlayerStat>();

                    foreach (DataRow dr in data.AsEnumerable())
                    {
                        PlayerStat playerStat = new PlayerStat();
                        playerStat.player_point = dr.Field<int>("MVP");
                        list.Add(playerStat);
                    }
                }
                catch (Exception)
                {
            
                }
            
            }
            return list;
        }


        public static List<PlayerStat> getPG(SqlParameter[] p)
        {
            List<PlayerStat> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                try
                {
                    if (!dal.IsConnected) return null;
                    var data = dal.ExecuteQuery("getPG", p).Tables[0];

                    list = new List<PlayerStat>();

                    foreach (DataRow dr in data.AsEnumerable())
                    {
                        PlayerStat playerStat = new PlayerStat();
                        playerStat.player_point = dr.Field<int>("MVP");
                        list.Add(playerStat);
                    }
                }
                catch (Exception)
                {
                    
                 
                }

            
            }
            return list;
        }

        public static List<PlayerStat> getSG(SqlParameter[] p)
        {
            List<PlayerStat> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                try
                {
                    if (!dal.IsConnected) return null;
                    var data = dal.ExecuteQuery("getSG", p).Tables[0];

                    list = new List<PlayerStat>();

                    foreach (DataRow dr in data.AsEnumerable())
                    {
                        PlayerStat playerStat = new PlayerStat();
                        playerStat.player_point = dr.Field<int>("MVP");
                        list.Add(playerStat);
                    }
                }
                catch (Exception)
                {
                    
                
                }

           
            }
            return list;
        }

        public static List<PlayerStat> getC(SqlParameter[] p)
        {
            List<PlayerStat> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                try
                {

                    if (!dal.IsConnected) return null;
                    var data = dal.ExecuteQuery("getC", p).Tables[0];

                    list = new List<PlayerStat>();

                    foreach (DataRow dr in data.AsEnumerable())
                    {
                        PlayerStat playerStat = new PlayerStat();
                        playerStat.player_point = dr.Field<int>("MVP");
                        list.Add(playerStat);
                    }
                }
                catch (Exception)
                {
                    
                 
                }

            }
            return list;
        }




        public static List<Player> getPlayerInfo(SqlParameter[] p)
        {
            List<Player> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                try
                {
                    if (!dal.IsConnected) return null;
                    var data = dal.ExecuteQuery("getPlayerInfo", p).Tables[0];

                    list = new List<Player>();

                    foreach (DataRow dr in data.AsEnumerable())
                    {
                        Player player = new Player();

                        player.player_jerseyNo = dr.Field<string>("jerseyNo");
                        player.player_name = dr.Field<string>("playerName");
                        player.player_photo = dr.Field<string>("playerImage");

                        player.position.position_desc = dr.Field<string>("positionDesc");
                        player.team.team_name = dr.Field<string>("teamName");
                        player.team.barangay.brgyName = dr.Field<string>("brgyName");

                        list.Add(player);
                    }
                }
                catch (Exception)
                {
                    
              
                }

           
            }

            return list;
        }

       
    
    
    }
}
