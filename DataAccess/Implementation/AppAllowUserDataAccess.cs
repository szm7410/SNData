using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DataModel;

namespace DataAccess.Implementation
{
    public class AppAllowUserDataAccess : DataAccess.DataAccess<AppAllowUser, long>
    {
        public override int AddItem(AppAllowUser item)
        {
            if (item == null)
            {
                throw new ArgumentException("AppAllowUser");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        INSERT INTO [dbo].[AppAllowUser]
                                   ([APPID]
                                   ,[Corpid]
                                   ,[AllowUserCount]
                                   ,[Stage]
                                   ,[Querydate])
                             VALUES
                                   (@APPID
                                   ,@Corpid
                                   ,@AllowUserCount
                                   ,@Stage
                                   ,@Querydate)
                                   SELECT @output_id = SCOPE_IDENTITY();
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;


                command.Parameters.Add(new SqlParameter("@APPID", GetValue(item.APPID)));
                command.Parameters.Add(new SqlParameter("@Corpid", GetValue(item.Corpid)));
                command.Parameters.Add(new SqlParameter("@AllowUserCount", GetValue(item.AllowUserCount)));
                command.Parameters.Add(new SqlParameter("@Stage", GetValue(item.Stage)));
                command.Parameters.Add(new SqlParameter("@Querydate", GetValue(item.Querydate)));
                // output parameter
                SqlParameter paramOutputId = new SqlParameter("@output_id", SqlDbType.BigInt);
                paramOutputId.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramOutputId);

                // do query
                int iRows = this.TargetSqlSession.ExecuteNonQuery(command);
                int outputVal = 0;
                int.TryParse(paramOutputId.Value.ToString(), out outputVal);
                item.ID = outputVal;
                return iRows;
            }
        }

        public override int DeleteItem(long id)
        {
            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        DELETE FROM [dbo].[AppAllowUser]
                         WHERE [Id] = @Id;
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@Id", id));


                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }

        public override AppAllowUser GetItem(long id)
        {
            return this.TargetSqlSession.QueryItems<AppAllowUser>(u => u.ID == id).FirstOrDefault();
        }

        public override int UpdateItem(AppAllowUser item)
        {
            if (item == null)
            {
                throw new ArgumentException("AppAllowUser");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        UPDATE [dbo].[AppAllowUser]
                           SET [APPID] = @APPID
                              ,[Corpid] = @Corpid
                              ,[AllowUserCount] = @AllowUserCount
                              ,[Stage] = @Stage
                              ,[Querydate] = @Querydate
                         WHERE [Id] = @Id
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@APPID", GetValue(item.APPID)));
                command.Parameters.Add(new SqlParameter("@Corpid", GetValue(item.Corpid)));
                command.Parameters.Add(new SqlParameter("@AllowUserCount", GetValue(item.AllowUserCount)));
                command.Parameters.Add(new SqlParameter("@Stage", GetValue(item.Stage)));
                command.Parameters.Add(new SqlParameter("@Querydate", GetValue(item.Querydate)));
                command.Parameters.Add(new SqlParameter("@Id", item.ID));

                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }
    }
}
