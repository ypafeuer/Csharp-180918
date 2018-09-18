using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NWDB
{
    public abstract class BaseDB
    {
        protected SqlConnection conn;

        public BaseDB()
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "localhost";
            scsb.InitialCatalog = "中文北風";
            scsb.IntegratedSecurity = false;
            scsb.UserID = "SQLUser";
            scsb.Password = "1234";

            conn = new SqlConnection(scsb.ConnectionString);
        }

        public BaseDB(string userName, string password)
        {
            SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = "localhost";
            scsb.InitialCatalog = "中文北風";
            scsb.IntegratedSecurity = false;
            scsb.UserID = userName;
            scsb.Password = password;

            conn = new SqlConnection(scsb.ConnectionString);
        }

        public SqlConnection Conn
        {
            get { return this.conn; }
        }

        public void DbClose()
        {
            this.conn.Close();
            this.conn = null;
        }

    }
}
