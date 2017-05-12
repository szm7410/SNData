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
    public class UserActionDataAccess : DataAccess.DataAccess<UserAction, long>
    {
        public override int AddItem(UserAction item)
        {
            if (item == null)
            {
                throw new ArgumentException("UserAction");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        INSERT INTO [dbo].[UserAction]
                                   ([AppName]
                                   ,[OrgId]
                                   ,[UserId]
                                   ,[Action]
                                   ,[Parameter]
                                   ,[DateTimeUTC]
                                   ,[ExtensionInfo]
                                   ,[RequestUrl])
                             VALUES
                                   (@AppName
                                   ,@OrgId
                                   ,@UserId
                                   ,@Action
                                   ,@Parameter
                                   ,@DateTimeUTC
                                   ,@ExtensionInfo
                                   ,@RequestUrl)
                                   SELECT @output_id = SCOPE_IDENTITY();
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;


                command.Parameters.Add(new SqlParameter("@AppName", GetValue(item.AppName)));
                command.Parameters.Add(new SqlParameter("@OrgId", GetValue(item.OrgId)));
                command.Parameters.Add(new SqlParameter("@UserId", GetValue(item.UserId)));
                command.Parameters.Add(new SqlParameter("@Action", GetValue(item.Action)));
                command.Parameters.Add(new SqlParameter("@Parameter", GetValue(item.Parameter)));
                command.Parameters.Add(new SqlParameter("@DateTimeUTC", GetValue(item.DateTimeUTC)));
                command.Parameters.Add(new SqlParameter("@ExtensionInfo", GetValue(item.ExtensionInfo)));
                command.Parameters.Add(new SqlParameter("@RequestUrl", GetValue(item.RequestUrl)));
                // output parameter
                SqlParameter paramOutputId = new SqlParameter("@output_id", SqlDbType.BigInt);
                paramOutputId.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramOutputId);

                // do query
                int iRows = this.TargetSqlSession.ExecuteNonQuery(command);
                long outputVal = 0;
                long.TryParse(paramOutputId.Value.ToString(), out outputVal);
                item.ID = outputVal;



                return iRows;
            }
        }

        public override int DeleteItem(long id)
        {
            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        DELETE FROM [dbo].[UserAction]
                         WHERE [Id] = @Id;
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@Id", id));
                

                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }

        public override UserAction GetItem(long id)
        {
            return this.TargetSqlSession.QueryItems<UserAction>(u => u.ID == id).FirstOrDefault();
        }

        public override int UpdateItem(UserAction item)
        {
            if (item == null)
            {
                throw new ArgumentException("UserAction");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        UPDATE [dbo].[UserAction]
                           SET [AppName] = @AppName
                              ,[OrgId] = @OrgId
                              ,[UserId] = @UserId
                              ,[Action] = @Action
                              ,[Parameter] = @Parameter
                              ,[DateTimeUTC] = @DateTimeUTC
                              ,[ExtensionInfo] = @ExtensionInfo
                              ,[RequestUrl] = @RequestUrl
                         WHERE [Id] = @Id
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@AppName", GetValue(item.AppName)));
                command.Parameters.Add(new SqlParameter("@OrgId", GetValue(item.OrgId)));
                command.Parameters.Add(new SqlParameter("@UserId", GetValue(item.UserId)));
                command.Parameters.Add(new SqlParameter("@Action", GetValue(item.Action)));
                command.Parameters.Add(new SqlParameter("@Parameter", GetValue(item.Parameter)));
                command.Parameters.Add(new SqlParameter("@DateTimeUTC", GetValue(item.DateTimeUTC)));
                command.Parameters.Add(new SqlParameter("@ExtensionInfo", GetValue(item.ExtensionInfo)));
                command.Parameters.Add(new SqlParameter("@RequestUrl", GetValue(item.RequestUrl)));
                command.Parameters.Add(new SqlParameter("@Id", item.ID));

                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }
    }
}
