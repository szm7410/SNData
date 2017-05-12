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
    public class DataSourceDataAccess : DataAccess.DataAccess<DataSource, int>
    {
        public override int AddItem(DataSource item)
        {
            if (item == null)
            {
                throw new ArgumentException("DataSource");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        INSERT INTO [dbo].[DataSource]
                                   ([DataSoureType]
                                   ,[ConnectString]
                                   ,[QueryString]
                                   ,[CreateTime]
                                   ,[APPID]
                                   ,[SaveTo])
                             VALUES
                                   (@DataSoureType
                                   ,@ConnectString
                                   ,@QueryString
                                   ,@CreateTime
                                   ,@APPID
                                   ,@SaveTo)
                                   SELECT @output_id = SCOPE_IDENTITY();
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;


                command.Parameters.Add(new SqlParameter("@DataSoureType", GetValue(item.DataSoureType)));
                command.Parameters.Add(new SqlParameter("@ConnectString", GetValue(item.ConnectString)));
                command.Parameters.Add(new SqlParameter("@QueryString", GetValue(item.QueryString)));
                command.Parameters.Add(new SqlParameter("@CreateTime", GetValue(item.CreateTime)));
                command.Parameters.Add(new SqlParameter("@APPID", GetValue(item.APPID)));
                command.Parameters.Add(new SqlParameter("@SaveTo", GetValue(item.SaveTo)));
                // output parameter
                SqlParameter paramOutputId = new SqlParameter("@output_id", SqlDbType.BigInt);
                paramOutputId.Direction = ParameterDirection.Output;
                command.Parameters.Add(paramOutputId);

                // do query
                int iRows = this.TargetSqlSession.ExecuteNonQuery(command);
                int outputVal = 0;
                int.TryParse(paramOutputId.Value.ToString(), out outputVal);
                item.Id = outputVal;



                return iRows;
            }
        }

        public override int DeleteItem(int id)
        {
            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        DELETE FROM [dbo].[DataSource]
                         WHERE [Id] = @Id;
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@Id", id));


                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }

        public override DataSource GetItem(int id)
        {
            return this.TargetSqlSession.QueryItems<DataSource>(u => u.Id == id).FirstOrDefault();
        }

        public override int UpdateItem(DataSource item)
        {
            if (item == null)
            {
                throw new ArgumentException("DataSource");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        UPDATE [dbo].[DataSource]
                           SET [DataSoureType] = @DataSoureType
                              ,[ConnectString] = @ConnectString
                              ,[QueryString] = @QueryString
                              ,[CreateTime] = @CreateTime
                              ,[APPID] = @APPID
                              ,[SaveTo] = @SaveTo
                         WHERE [Id] = @Id
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@DataSoureType", GetValue(item.DataSoureType)));
                command.Parameters.Add(new SqlParameter("@ConnectString", GetValue(item.ConnectString)));
                command.Parameters.Add(new SqlParameter("@QueryString", GetValue(item.QueryString)));
                command.Parameters.Add(new SqlParameter("@CreateTime", GetValue(item.CreateTime)));
                command.Parameters.Add(new SqlParameter("@APPID", GetValue(item.APPID)));
                command.Parameters.Add(new SqlParameter("@SaveTo", GetValue(item.SaveTo)));
                command.Parameters.Add(new SqlParameter("@Id", item.Id));

                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }
    }
}
