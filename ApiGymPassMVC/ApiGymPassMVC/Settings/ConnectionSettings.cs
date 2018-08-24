using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiGymPassMVC.Settings
{
    public static class ConnectionSettings
    {
        static SqlConnection conn = null;

        public static SqlConnection AbrirConexao()
        {
            conn = new SqlConnection(ConnectionUtil.CONN_STRING);
            conn.Open();
            return conn;
        }
        public static SqlConnection FecharConexao()
        {
            conn.Close();
            return conn;
        }
    }
}