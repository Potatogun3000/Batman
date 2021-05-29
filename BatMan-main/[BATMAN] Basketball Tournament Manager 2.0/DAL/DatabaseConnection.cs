using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _BATMAN__Basketball_Tournament_Manager_2._0.DAL
{
    public class DatabaseConnection : IDisposable
    {
        SqlConnection sqlConn = null;
        public bool IsConnected { get; private set; }

        public DatabaseConnection()
        {
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = @"Server=DESKTOP-6UB0R6I\SQLEXPRESS; Integrated Security = True; Database = BATMAN";

            IsConnected = false;
            try
            {
                sqlConn.Open();
                IsConnected = true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        void IDisposable.Dispose()
        {
            sqlConn.Close();
        }

        public DataSet ExecuteQuery(string spName, SqlParameter[] param = null)
        {
            using (SqlCommand cmd = new SqlCommand(spName, sqlConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                    cmd.Parameters.AddRange(param);

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);

                return ds;
            }
        }

        public void ExecuteNonQuery(string spName, SqlParameter[] param = null)
        {
            using (SqlCommand cmd = new SqlCommand(spName, sqlConn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (param != null)
                    cmd.Parameters.AddRange(param);
                cmd.ExecuteNonQuery();
            }
        }
   
    }
}
