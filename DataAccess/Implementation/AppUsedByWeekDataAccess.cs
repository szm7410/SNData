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
    public class AppUsedByWeekDataAccess : DataAccess<AppUsedByWeek, long>
    {
        public override int AddItem(AppUsedByWeek item)
        {
            if (item == null)
            {
                throw new ArgumentException("AppUsedByWeek");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        INSERT INTO [dbo].[AppUsedByWeek]
                                   ([QueryData]
                                   ,[Week]
                                   ,[AppID]
                                   ,[Corpid]
                                   ,[UseCount]
                                   ,[UseUserCount])
                             VALUES
                                   (@QueryData
                                   ,@Week
                                   ,@AppID
                                   ,@Corpid
                                   ,@UseCount
                                   ,@UseUserCount)
                                   SELECT @output_id = SCOPE_IDENTITY();
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;


                command.Parameters.Add(new SqlParameter("@QueryData", GetValue(item.QueryData)));
                command.Parameters.Add(new SqlParameter("@Week", GetValue(item.Week)));
                command.Parameters.Add(new SqlParameter("@AppID", GetValue(item.AppID)));
                command.Parameters.Add(new SqlParameter("@Corpid", GetValue(item.Corpid)));
                command.Parameters.Add(new SqlParameter("@UseCount", GetValue(item.UseCount)));
                command.Parameters.Add(new SqlParameter("@UseUserCount", GetValue(item.UseUserCount)));
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
                        DELETE FROM [dbo].[AppUsedByWeek]
                         WHERE [Id] = @Id;
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@Id", id));


                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }

        public override AppUsedByWeek GetItem(long id)
        {
            return this.TargetSqlSession.QueryItems<AppUsedByWeek>(u => u.ID == id).FirstOrDefault();
        }

        public override int UpdateItem(AppUsedByWeek item)
        {
            if (item == null)
            {
                throw new ArgumentException("AppUsedByWeek");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        UPDATE [dbo].[AppUsedByWeek]
                           SET [QueryData] = @QueryData
                              ,[Week] = @Week
                              ,[AppID] = @AppID
                              ,[Corpid] = @Corpid
                              ,[UseCount] = @UseCount
                              ,[UseUserCount] = @UseUserCount
                         WHERE [Id] = @Id
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@QueryData", GetValue(item.QueryData)));
                command.Parameters.Add(new SqlParameter("@Week", GetValue(item.Week)));
                command.Parameters.Add(new SqlParameter("@AppID", GetValue(item.AppID)));
                command.Parameters.Add(new SqlParameter("@Corpid", GetValue(item.Corpid)));
                command.Parameters.Add(new SqlParameter("@UseCount", GetValue(item.UseCount)));
                command.Parameters.Add(new SqlParameter("@UseUserCount", GetValue(item.UseUserCount)));
                command.Parameters.Add(new SqlParameter("@Id", item.ID));

                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }
    }
}
