using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DemoCRPushModel.Dao
{
    public class DbConfig : IDisposable
    {

        protected IDbConnection conn { get; private set; }

        public DbConfig()
        {            
            var dbName = System.IO.Directory.GetCurrentDirectory() + "\\DbSiswa.db";

            var providerName = "System.Data.SQLite";
            var connectionString = "Data Source=" + dbName;

            conn = GetOpenConnection(providerName, connectionString);

        }

        private IDbConnection GetOpenConnection(string providerName, string connectionString)
        {
            DbConnection conn = null;

            try
            {

                DbProviderFactory provider = DbProviderFactories.GetFactory(providerName);
                conn = provider.CreateConnection();
                conn.ConnectionString = connectionString;
                conn.Open();

            }
            catch (Exception)
            {
            }

            return conn;
        }

        public void Dispose()
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();
            }
            finally
            {
                conn.Dispose();
                conn.Dispose();
            }

            GC.SuppressFinalize(this);
        }

    }
}
