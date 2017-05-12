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
    public class UserDataDataAccess : DataAccess<UserData, long>
    {
        public override int AddItem(UserData item)
        {
            if(item==null)
            {
                throw new ArgumentException("UserData");
            }
            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        INSERT INTO [dbo].[UserData]
                                   ([Corpid]
                                   ,[corpname]
                                   ,[TotalUserCount]
                                   ,[FollowUserCount]
                                   ,[BoundUserCount]
                                   ,[Querydate])
                             VALUES
                                   (@Corpid
                                   ,@corpname
                                   ,@TotalUserCount
                                   ,@FollowUserCount
                                   ,@BoundUserCount
                                   ,@Querydate)
                                   SELECT @output_id = SCOPE_IDENTITY();
                                ";
                command.CommandType = CommandType.Text;
                command.CommandText = query;

                command.Parameters.Add(new SqlParameter("@Corpid",GetValue(item.Corpid)));
                command.Parameters.Add(new SqlParameter("@corpname", GetValue(item.corpname)));
                command.Parameters.Add(new SqlParameter("@TotalUserCount", GetValue(item.TotalUserCount)));
                command.Parameters.Add(new SqlParameter("@FollowUserCount", GetValue(item.FollowUserCount)));
                command.Parameters.Add(new SqlParameter("@BoundUserCount", GetValue(item.BoundUserCount)));
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
                        DELETE FROM [dbo].[UserData]
                         WHERE [Id] = @Id;
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@Id", id));


                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }

        public override UserData GetItem(long id)
        {
            return this.TargetSqlSession.QueryItems<UserData>(u => u.ID == id).FirstOrDefault();
        }

        public override int UpdateItem(UserData item)
        {
            if (item == null)
            {
                throw new ArgumentException("UserData");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        UPDATE [dbo].[UserData]
                           SET [Corpid] = @Corpid
                              ,[corpname] = @corpname
                              ,[TotalUserCount] = @TotalUserCount
                              ,[FollowUserCount] = @FollowUserCount
                              ,[BoundUserCount] = @BoundUserCount
                              ,[Querydate] = @Querydate
                         WHERE [Id] = @Id
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@Corpid", GetValue(item.Corpid)));
                command.Parameters.Add(new SqlParameter("@corpname", GetValue(item.corpname)));
                command.Parameters.Add(new SqlParameter("@TotalUserCount", GetValue(item.TotalUserCount)));
                command.Parameters.Add(new SqlParameter("@FollowUserCount", GetValue(item.FollowUserCount)));
                command.Parameters.Add(new SqlParameter("@BoundUserCount", GetValue(item.BoundUserCount)));
                command.Parameters.Add(new SqlParameter("@Querydate", GetValue(item.Querydate)));
                command.Parameters.Add(new SqlParameter("@Id", item.ID));

                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }
    }
}
