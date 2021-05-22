using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerGame.DatabaseClass
{
    public class Connection : IDisposable
    {
        SqlConnection sqlConn = null;
        public bool IsConnected { get; private set; }

        public Connection()
        {
            sqlConn = new SqlConnection();
            sqlConn.ConnectionString = "Server=tcp:lucky9.database.windows.net,1433;Initial Catalog=Lucky9DB;Persist Security Info=False;User ID=lucky9Admin;Password=@l03e1t3;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"; ;

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
