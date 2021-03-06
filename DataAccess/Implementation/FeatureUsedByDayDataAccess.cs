﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DataAccess.DataModel;

namespace DataAccess.Implementation
{
    public class FeatureUsedByDayDataAccess : DataAccess.DataAccess<FeatureUsedByDay, long>
    {
        public override int AddItem(FeatureUsedByDay item)
        {
            if (item == null)
            {
                throw new ArgumentException("FeatureUsedByDay");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        INSERT INTO [dbo].[FeatureUsedByDay]
                                   ([QueryData]
                                   ,[AppID]
                                   ,[Corpid]
                                   ,[FeatureID]
                                   ,[UseCount]
                                   ,[UseUserCount]
                                   ,[UserDetailInfo])
                             VALUES
                                   (@QueryData
                                   ,@AppID
                                   ,@Corpid
                                   ,@FeatureID
                                   ,@UseCount
                                   ,@UseUserCount
                                   ,@UserDetailInfo)
                                   SELECT @output_id = SCOPE_IDENTITY();
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;


                command.Parameters.Add(new SqlParameter("@QueryData", GetValue(item.QueryData)));
                command.Parameters.Add(new SqlParameter("@AppID", GetValue(item.AppID)));
                command.Parameters.Add(new SqlParameter("@Corpid", GetValue(item.Corpid)));
                command.Parameters.Add(new SqlParameter("@FeatureID", GetValue(item.FeatureID)));
                command.Parameters.Add(new SqlParameter("@UseCount", GetValue(item.UseCount)));
                command.Parameters.Add(new SqlParameter("@UseUserCount", GetValue(item.UseUserCount)));
                command.Parameters.Add(new SqlParameter("@UserDetailInfo", GetValue(item.UserDetailInfo)));
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
                        DELETE FROM [dbo].[FeatureUsedByDay]
                         WHERE [Id] = @Id;
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@Id", id));


                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }

        public override FeatureUsedByDay GetItem(long id)
        {
            return this.TargetSqlSession.QueryItems<FeatureUsedByDay>(u => u.ID == id).FirstOrDefault();
        }

        public override int UpdateItem(FeatureUsedByDay item)
        {
            if (item == null)
            {
                throw new ArgumentException("FeatureUsedByDay");
            }

            using (SqlCommand command = new SqlCommand())
            {
                string query = @"
                        UPDATE [dbo].[FeatureUsedByDay]
                           SET [QueryData] = @QueryData
                              ,[AppID] = @AppID
                              ,[Corpid] = @Corpid
                              ,[FeatureID] = @FeatureID
                              ,[UseCount] = @UseCount
                              ,[UseUserCount] = @UseUserCount
                              ,[UserDetailInfo] = @UserDetailInfo
                         WHERE [Id] = @Id
                                ";

                command.CommandType = CommandType.Text;
                command.CommandText = query;
                command.Parameters.Add(new SqlParameter("@QueryData", GetValue(item.QueryData)));
                command.Parameters.Add(new SqlParameter("@AppID", GetValue(item.AppID)));
                command.Parameters.Add(new SqlParameter("@Corpid", GetValue(item.Corpid)));
                command.Parameters.Add(new SqlParameter("@FeatureID", GetValue(item.FeatureID)));
                command.Parameters.Add(new SqlParameter("@UseCount", GetValue(item.UseCount)));
                command.Parameters.Add(new SqlParameter("@UseUserCount", GetValue(item.UseUserCount)));
                command.Parameters.Add(new SqlParameter("@UserDetailInfo", GetValue(item.UserDetailInfo)));
                command.Parameters.Add(new SqlParameter("@Id", item.ID));

                return this.TargetSqlSession.ExecuteNonQuery(command);
            }
        }
    }
}
