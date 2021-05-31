﻿using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.DAL
{
   public  class TeamStatHelper
    {
       public static void SaveTeamStat(TeamStat teamStat)
       {
           using (DatabaseConnection db_conn = new DatabaseConnection())
           {
               if (!db_conn.IsConnected) return;
               SqlParameter[] param = {     
                                           new SqlParameter("@teamName",                 teamStat.team_name),
                                           new SqlParameter("@teamStatTScore",       teamStat.teamStat_totalScore),
                                           new SqlParameter("@teamQ1",               teamStat.team_statQ1),
                                           new SqlParameter("@teamQ2",               teamStat.team_statQ2),
                                           new SqlParameter("@teamQ3",               teamStat.team_statQ3),
                                           new SqlParameter("@teamQ4",               teamStat.team_statQ4),
                                           new SqlParameter("@teamDesc",                 teamStat.team_desc),
                                           new SqlParameter("@match",                     teamStat.match.match_id),
                                       };

               db_conn.ExecuteNonQuery("SaveTeamStat", param);
           }
       }

       public static List<TeamStat> GetHomeTeam(SqlParameter[] p)
       {
           List<TeamStat> list = null;
           using (DatabaseConnection dal = new DatabaseConnection())
           {
               if (!dal.IsConnected) return null;
               var data = dal.ExecuteQuery("GetHomeTeam", p).Tables[0];

               list = new List<TeamStat>();

               foreach (DataRow dr in data.AsEnumerable())
               {
                   TeamStat teamStat = new TeamStat();
                   teamStat.teamStat_id          = dr.Field<int>("teamStatID");
                   teamStat.teamStat_totalScore  = dr.Field<int>("teamStatTScore");
                   teamStat.team_statQ1          = dr.Field<int>("teamQ1");
                   teamStat.team_statQ2          = dr.Field<int>("teamQ2");
                   teamStat.team_statQ3          = dr.Field<int>("teamQ3");
                   teamStat.team_statQ4          = dr.Field<int>("teamQ4");
                   teamStat.team_desc            = dr.Field<string>("teamDesc");
                   teamStat.match.match_id       = dr.Field<int>("match");


                   list.Add(teamStat);
               }
           }
           return list;
       }

       public static List<TeamStat> GetGuestTeam(SqlParameter[] p)
       {
           List<TeamStat> list = null;
           using (DatabaseConnection dal = new DatabaseConnection())
           {
               if (!dal.IsConnected) return null;
               var data = dal.ExecuteQuery("GetGuestTeam", p).Tables[0];

               list = new List<TeamStat>();

               foreach (DataRow dr in data.AsEnumerable())
               {
                   TeamStat teamStat = new TeamStat();
                    teamStat.teamStat_id = dr.Field<int>("teamStatID");
                    teamStat.teamStat_totalScore = dr.Field<int>("teamStatTScore");
                    teamStat.team_statQ1 = dr.Field<int>("teamQ1");
                    teamStat.team_statQ2 = dr.Field<int>("teamQ2");
                    teamStat.team_statQ3 = dr.Field<int>("teamQ3");
                    teamStat.team_statQ4 = dr.Field<int>("teamQ4");
                    teamStat.team_desc = dr.Field<string>("teamDesc");
                    teamStat.match.match_id = dr.Field<int>("match");
                    list.Add(teamStat);
               }
           }
           return list;
       }


       public static List<TeamStat> getTeamChampion(SqlParameter[] p)
       {
           List<TeamStat> list = null;

           using (DatabaseConnection dal = new DatabaseConnection())
           {
               try
               {
                   if (!dal.IsConnected) return null;
                   var data = dal.ExecuteQuery("getTeamChampion", p).Tables[0];

                   list = new List<TeamStat>();

                   foreach (DataRow dr in data.AsEnumerable())
                   {
                       TeamStat teamPlayerStat = new TeamStat();
                       teamPlayerStat.teamStat_totalScore = dr.Field<int>("Champion");
                       list.Add(teamPlayerStat);
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
