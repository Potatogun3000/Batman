﻿using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.DAL
{
    public class PlayerHelper
    {
        public static void SavePlayer(Player player)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {
                                           new SqlParameter("@jerseyNo",         player.player_jerseyNo),
                                           new SqlParameter("@playerName",       player.player_name),
                                           new SqlParameter("@playerAddress",    player.player_address),
                                           new SqlParameter("@playerBirthdate",  player.player_birthdate),
                                           new SqlParameter("@isCaptain",        player.player_isCaptain),
                                           new SqlParameter("@position",         player.position.position_id),
                                           new SqlParameter("@team",             player.team.team_id),
                                           new SqlParameter("@playerImage",      player.player_photo)
                                       };
                 db_conn.ExecuteNonQuery("SavePlayer", param);
            }
        }

        public static void UpdatePlayer(Player player)
        {
            using (DatabaseConnection db_conn = new DatabaseConnection())
            {
                if (!db_conn.IsConnected) return;
                SqlParameter[] param = {  
                                           new SqlParameter("@playerID",        player.player_id),
                                           new SqlParameter("@jerseyNo",        player.player_jerseyNo),
                                           new SqlParameter("@playerName",      player.player_name),
                                           new SqlParameter("@playerAddress",   player.player_address),
                                           new SqlParameter("@playerBirthdate", player.player_birthdate),
                                           new SqlParameter("@isCaptain",       player.player_isCaptain),
                                           new SqlParameter("@position",        player.position.position_id),
                                           new SqlParameter("@playerImage",     player.player_photo)
                                       };
                db_conn.ExecuteNonQuery("UpdatePlayer", param);
            }
        }

        public static List<Player> CheckPlayerList()
        {
            List<Player> list = null;
        
            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("CheckPlayerList").Tables[0];

                list = new List<Player>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Player player = new Player();
            
                    player.player_id                         = dr.Field<int>("playerID");
                    player.player_jerseyNo                   = dr.Field<string>("jerseyNo");
                    player.player_name                       = dr.Field<string>("playerName");
                    player.player_address                    = dr.Field<string>("playerAddress");
                    player.player_birthdate                  = dr.Field<string>("playerBirthdate");
                    player.player_isCaptain                  = dr.Field<bool>("isCaptain");
                    player.position.position_id              = dr.Field<int>("position");
                    player.team.team_id                      = dr.Field<int>("team");
                   
                    list.Add(player);
                }
           }

            return list;
        }

        public static List<Player> CheckPlayerOnTeam(SqlParameter[] p)
        {
            List<Player> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("CheckPlayerOnTeam",p).Tables[0];

                list = new List<Player>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Player player = new Player();

                    player.player_id = dr.Field<int>("playerID");
                    player.player_jerseyNo = dr.Field<string>("jerseyNo");
                    player.player_name = dr.Field<string>("playerName");
                    player.player_address = dr.Field<string>("playerAddress");
                    player.player_birthdate = dr.Field<string>("playerBirthdate");
                    player.player_isCaptain = dr.Field<bool>("isCaptain");
                    player.position.position_desc = dr.Field<string>("positionDesc");
                    player.team.team_id = dr.Field<int>("team");

                    list.Add(player);
                }
            }

            return list;
        }

        public static List<Player> GetPlayerList()
        {
            List<Player> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetPlayerList").Tables[0];

                list = new List<Player>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Player player = new Player();

                    player.player_id = dr.Field<int>("playerID");
                    player.player_jerseyNo = dr.Field<string>("jerseyNo");
                    player.player_name = dr.Field<string>("playerName");
                    player.player_address = dr.Field<string>("playerAddress");
                    player.player_birthdate = dr.Field<string>("playerBirthdate");
                    player.player_isCaptain = dr.Field<bool>("isCaptain");
                    player.position.position_desc = dr.Field<string>("positionDesc");
                    player.team.team_name = dr.Field<string>("teamName");
                    player.team.team_id   = dr.Field<int>("team");
                    player.player_photo = dr.Field<string>("playerImage");

                    list.Add(player);
                }

            }
            return list;
        }

        public static List<Player> SearchPlayer(SqlParameter[] p)
        {
            List<Player> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("SearchPlayer", p).Tables[0];

                list = new List<Player>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    Player player = new Player();
                    player.player_id = dr.Field<int>("playerID");
                    player.player_jerseyNo = dr.Field<string>("jerseyNo");
                    player.player_name = dr.Field<string>("playerName");
                    player.player_address = dr.Field<string>("playerAddress");
                    player.player_birthdate = dr.Field<string>("playerBirthdate");
                    player.position.position_desc = dr.Field<string>("positionDesc");
                    player.team.team_name = dr.Field<string>("teamName");
                    player.team.team_id = dr.Field<int>("teamID");
                    list.Add(player);
                }

            }
            return list;
        }

    
    
    }


}
