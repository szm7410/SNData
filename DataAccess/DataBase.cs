using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DataBase
    {
        #region Members

        /// <summary>
        /// A cached instance of the sql connection string.
        /// </summary>
        private SqlSession _sqlSession;
        private SqlSession _telSqlSession;
        

        #endregion

        #region Properties

        /// <summary>
        /// Edu Sql Session
        /// </summary>
        public SqlSession SqlSession
        {
            get
            {
                SqlSession retval = this._sqlSession;
                if (retval == null)
                {
                    retval =
                        SqlSession.GetSession(GetConnectionString("DBConnectionString"));
                    this._sqlSession = retval;
                }
                return retval;
            }
        }

        public SqlSession CreateSqlSessionByConnectionString(string connectionString)
        {
            if (!string.IsNullOrEmpty(connectionString))
            {
                return SqlSession.GetSession(connectionString);

            }
            return null;
        }
        


        /// <summary>
        /// Edu Telemetry Sql Session
        /// </summary>
        public SqlSession TelSqlSession
        {
            get
            {
                SqlSession retval = this._telSqlSession;
                if (retval == null)
                {
                    retval =
                        SqlSession.GetSession(
                            GetConnectionString("TelemetryDBConnectionString"));
                    this._telSqlSession = retval;
                }
                return retval;
            }
        }


        #endregion

        #region Functions

       

        /// <summary>
        /// Fetch connection string from configuration file (either connection string section or appsettings section)
        /// </summary>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        private static string GetConnectionString(string connectionStringName)
        {
            string connVal = string.Empty;

            if (String.IsNullOrEmpty(connectionStringName))
            {
                throw new ArgumentNullException(connectionStringName);
            }

            //if (ConfigurationManager.ConnectionStrings[connectionStringName] != null)
            //{
            //    connVal = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            //}
            //else
            {
                connVal = ConfigurationManager.AppSettings[connectionStringName];
            }

            // build up Connection String add more property here if any
            SqlConnectionStringBuilder connectionStr = new SqlConnectionStringBuilder(connVal);
            return connectionStr.ToString();
        }

        #endregion
    }
}
