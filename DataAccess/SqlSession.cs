using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SQLinq;
using SQLinq.Dapper;

namespace DataAccess
{
    public class SqlSession
    {
        private string m_ConnectionString;
        public string ConnectionString
        {
            get { return m_ConnectionString; }
        }

        public SqlSession(string connectionString)
        {
            m_ConnectionString = connectionString;
        }

        public static SqlSession GetSession(string connectionString)
        {
            return new SqlSession(connectionString);
        }

        protected virtual SqlConnection OpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(m_ConnectionString); ;
            try
            {
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return sqlConnection;
        }

        protected virtual void CloseConnection(SqlConnection sqlConnection)
        {
            sqlConnection.Close();
        }

        public DataTable ReTrieveDataTable(string query, List<SqlParameter> sqlParams)
        {
            SqlConnection sqlConnection = OpenConnection();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);
            foreach (var param in sqlParams)
            {
                sqlDataAdapter.SelectCommand.Parameters.Add(param);
            }

            DataSet ds = new DataSet();
            try
            {
                sqlDataAdapter.Fill(ds, "finally");
                return ds.Tables["finally"];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlDataAdapter.SelectCommand.Connection = null;
                if (sqlConnection != null)
                    CloseConnection(sqlConnection);
            }
        }

        public SqlDataReader ExecuteReader(SqlCommand command, CommandBehavior behavior)
        {
            SqlDataReader sqlDataReader = null;
            SqlConnection sqlConnection = OpenConnection();

            try
            {
                command.Connection = sqlConnection;

                sqlDataReader = command.ExecuteReader(behavior);
            }
            catch (Exception ex)
            {
                command.Connection = null;
                if (sqlConnection != null)
                    CloseConnection(sqlConnection);
                throw ex;
            }
            return sqlDataReader;
        }

        public int ExecuteNonQuery(SqlCommand command)
        {
            int iRows = -1;
            SqlConnection sqlConnection = null;
            if (null == command)
            {
                throw new ArgumentNullException("command");
            }
            try
            {
                sqlConnection = OpenConnection();
                command.Connection = sqlConnection;
                iRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection = null;
                if (sqlConnection != null)
                    CloseConnection(sqlConnection);
            }

            return iRows;
        }

        public IEnumerable<T> QueryItems<T>(Expression<Func<T, bool>> predicate)
            where T : class, new()
        {
            try
            {
                SQLinq<T> query = new SQLinq<T>().Where(predicate);
                using (IDbConnection dbConnection = new SqlConnection(this.ConnectionString))
                {
                    dbConnection.Open();

                    return dbConnection.Query<T>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<T> QueryItems<T>(Expression<Func<T, bool>> predicate, Tuple<bool, Expression<Func<T, object>>> isOrderByASC = null, Tuple<bool, Expression<Func<T, object>>> isThenByASC = null)
            where T : class, new()
        {
            try
            {
                SQLinq<T> query = new SQLinq<T>().Where(predicate);

                if (isOrderByASC != null)
                {
                    if (isOrderByASC.Item1)
                        query.OrderBy(isOrderByASC.Item2);
                    else
                        query.OrderByDescending(isOrderByASC.Item2);
                }

                if (isThenByASC != null)
                {
                    if (isThenByASC != null)
                        query.ThenBy(isThenByASC.Item2);
                    else
                        query.ThenByDescending(isThenByASC.Item2);
                }

                using (IDbConnection dbConnection = new SqlConnection(this.ConnectionString))
                {
                    dbConnection.Open();

                    return dbConnection.Query<T>(query);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void LogException(Exception ex, SqlCommand command)
        {

        }
    }
}
