using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace DataAccess
{
    public abstract class DataAccess<T, TID>
         where T : class, new()
    {

        #region private parameters

        /// <summary>
        /// target sql session, decide which session the sql is performed
        /// </summary>
        private SqlSession targetSqlSession = null;
        



        #endregion

        #region protected parameters

        /// <summary>
        /// database instance to manage sql sessions
        /// </summary>
        protected DataBase database;

        #endregion

        
    
        /// <summary>
        /// Get Target SqlSession
        /// </summary>
        /// <returns></returns>
        public SqlSession TargetSqlSession
        {
            get
            {
                return targetSqlSession;
            }
        }

      
        public DataAccess()
        {
            // initial the database instance to manage sql connections
            database = new DataBase();

            // default sql session
            targetSqlSession = database.SqlSession;
        }
        protected object GetValue(object val)
        {
            if (val == null) return DBNull.Value;
            return val;
        }

        public DataAccess(string DBConnectionString, string RedisConnectionString = "") : this()
        {
            // set target sql session for this access instance
            targetSqlSession = GetDatabase().CreateSqlSessionByConnectionString(DBConnectionString);
        }

        /// <summary>
        /// Get Database instance
        /// </summary>
        /// <returns></returns>
        public DataBase GetDatabase()
        {
            return database;
        }

        /// <summary>
        /// Set Target Sql Session
        /// </summary>
        /// <param name="session"></param>
        public void SetTargetSqlSession(SqlSession session)
        {
            targetSqlSession = session;
        }


        /// <summary>
        /// Query Items of T
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public virtual IEnumerable<T> QueryItems(Expression<Func<T, bool>> predicate)
        {
            if (targetSqlSession == null)
                throw new InvalidOperationException("targetSqlSession should be set before using SqlDataAccess");

            return targetSqlSession.QueryItems<T>(predicate);
        }

        /// <summary>
        /// Query Items of T Order By object
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="isOrderByASC">true means order by asc, false means order by desc</param>
        /// <param name="isThenByASC">true means order by asc, false means order by desc</param>
        /// <returns></returns>
        public virtual IEnumerable<T> QueryItems(Expression<Func<T, bool>> predicate, Tuple<bool, Expression<Func<T, object>>> isOrderByASC = null, Tuple<bool, Expression<Func<T, object>>> isThenByASC = null)
        {
            if (targetSqlSession == null)
                throw new InvalidOperationException("targetSqlSession should be set before using SqlDataAccess");

            return targetSqlSession.QueryItems<T>(predicate, isOrderByASC, isThenByASC);
        }





        /// <summary>
        /// Add Operation, return value means impacted rows
        /// </summary>
        /// <param name="item"></param>
        public abstract int AddItem(T item);

        /// <summary>
        /// Update Operation
        /// </summary>
        /// <param name="item"></param>
        public abstract int UpdateItem(T item);

        /// <summary>
        /// Delete Operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract int DeleteItem(TID id);

        /// <summary>
        /// GET Operation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public abstract T GetItem(TID id);

    }
}
