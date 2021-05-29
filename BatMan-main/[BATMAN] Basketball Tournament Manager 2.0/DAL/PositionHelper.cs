using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.DAL
{
    class PositionHelper
    {

        public static List<Position> GetAllPosition()
        {
            List<Position> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetPositionList").Tables[0];

                list = new List<Position>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    int position_id = dr.Field<int>("positionID");
                    string position_desc = dr.Field<string>("positionDesc");

                    Position position = new Position() { position_id = position_id, position_desc = position_desc };
                    list.Add(position);
                }
            }
            return list;
        }
        
    
    }
}
