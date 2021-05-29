using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using _BATMAN__Basketball_Tournament_Manager_2._0.BLL;
using _BATMAN__Basketball_Tournament_Manager_2._0.DAL;


namespace _BATMAN__Basketball_Tournament_Manager_2._0.DAL
{
    public class BarangayHelper
    {
        public static List<Barangay> GetAllBarangay()
        {
            List<Barangay> list = null;

            using (DatabaseConnection dal = new DatabaseConnection())
            {
                if (!dal.IsConnected) return null;
                var data = dal.ExecuteQuery("GetBarangayList").Tables[0];

                list = new List<Barangay>();

                foreach (DataRow dr in data.AsEnumerable())
                {
                    int brgy_id = dr.Field<int>("brgyID");
                    string brgy_name = dr.Field<string>("brgyName");

                    Barangay brgy = new Barangay() { brgyID = brgy_id, brgyName = brgy_name };
                    list.Add(brgy);
                }
            }
            return list;
        }
    
    }
}
