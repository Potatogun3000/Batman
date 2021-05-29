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
                                           new SqlParameter("@player_jno",         playerStat.player.player_jerseyNo),
                                           new SqlParameter("@player_name",        playerStat.player.player_name),
                                           new SqlParameter("@player_position",    playerStat.position.position_desc),
                                           new SqlParameter("@player_point",       playerStat.player_point),
                                           new SqlParameter("@player_reb",         playerStat.player_reb),
                                           new SqlParameter("@player_asst",        playerStat.player_ft),
                                           new SqlParameter("@player_steal",       playerStat.player_steal),
                                           new SqlParameter("@player_to",          playerStat.player_to),
                                           new SqlParameter("@player_ft",          playerStat.player_ft),
                                           new SqlParameter("@player_fouls",       playerStat.player_fouls),
                                           new SqlParameter("@team_desc",          playerStat.team_desc),
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
                    playerStat.player_statId             = dr.Field<int>("player_statId");
                    playerStat.player.player_jerseyNo    = dr.Field<string>("player_jno");
                    playerStat.position.position_desc     = dr.Field<string>("player_position");
                    playerStat.player.player_name        = dr.Field<string>("player_name");
                    playerStat.player_point          = dr.Field<int>("player_point");
                    playerStat.player_reb            = dr.Field<int>("player_reb");
                    playerStat.player_asst           = dr.Field<int>("player_asst");
                    playerStat.player_steal          = dr.Field<int>("player_steal");
                    playerStat.player_to             = dr.Field<int>("player_to");
                    playerStat.player_ft             = dr.Field<int>("player_ft");
                    playerStat.player_fouls          = dr.Field<int>("player_fouls");
                    playerStat.team_desc             = dr.Field<string>("team_desc");
                    playerStat.match.match_id        = dr.Field<int>("match");

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
                    playerStat.player_statId = dr.Field<int>("player_statId");
                    playerStat.player.player_jerseyNo = dr.Field<string>("player_jno");
                    playerStat.position.position_desc = dr.Field<string>("player_position");
                    playerStat.player.player_name = dr.Field<string>("player_name");
                    playerStat.player_point = dr.Field<int>("player_point");
                    playerStat.player_reb = dr.Field<int>("player_reb");
                    playerStat.player_asst = dr.Field<int>("player_asst");
                    playerStat.player_steal = dr.Field<int>("player_steal");
                    playerStat.player_to = dr.Field<int>("player_to");
                    playerStat.player_ft = dr.Field<int>("player_ft");
                    playerStat.player_fouls = dr.Field<int>("player_fouls");
                    playerStat.team_desc = dr.Field<string>("team_desc");
                    playerStat.match.match_id = dr.Field<int>("match");

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

                        player.player_jerseyNo = dr.Field<string>("player_jerseyNo");
                        player.player_name = dr.Field<string>("player_name");
                        player.player_photo = dr.Field<string>("player_photo");

                        player.position.position_desc = dr.Field<string>("position_desc");
                        player.team.team_name = dr.Field<string>("team_name");
                        player.team.barangay.brgyName = dr.Field<string>("brgy_name");

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
