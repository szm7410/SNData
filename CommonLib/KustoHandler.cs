using System;
using Kusto.Data;
using Kusto.Data.Linq;

using System.Collections.Generic;


namespace CommonLib
{
    public class KustoHandler
    {
        public KustoConnectionStringBuilder KustoConnectionString;

        public KustoHandler(string tenantId, string token, string url)
        {
            KustoConnectionString = new KustoConnectionStringBuilder(url, tenantId)
            {
                UserID = tenantId,
                Password = token
            };
        }

        public List<CountOfFeatureUsedResult> QueryKusto(string query)
        {

            List<CountOfFeatureUsedResult> result = new List<CountOfFeatureUsedResult>();

            using (var kustoDataContext = new KustoDataContext(KustoConnectionString))
            {
                using (var reader = kustoDataContext.ExecuteQuery(query))
                {
                    while (reader.Read())
                    {
                        CountOfFeatureUsedResult row = new CountOfFeatureUsedResult
                        {
                            QueryTime = DateTime.Parse(reader.GetValue(0).ToString()),
                            CorpId = reader.GetValue(1).ToString(),
                            Count = int.Parse(reader.GetValue(2).ToString())
                        };

                        result.Add(row);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 返回查询结果
        /// 结果形式 date,count
        /// </summary>
        /// <param name="query"></param>
        public List<QueryResult> QueryData(string query)
        {
            List<QueryResult> result = new List<QueryResult>();

            using (var kustoDataContext = new KustoDataContext(KustoConnectionString))
            {
                using (var reader = kustoDataContext.ExecuteQuery(query))
                {
                    while (reader.Read())
                    {
                        QueryResult row = new QueryResult()
                        {
                            QueryTime = DateTime.Parse(reader.GetValue(0).ToString()),
                            Count = int.Parse(reader.GetValue(1).ToString())

                        };


                        result.Add(row);
                    }
                }
            }
            return result;
        }

        public List<UserAction> QueryUserAcion(string query)
        {
            List<UserAction> result = new List<UserAction>();
            string seletcolumn = "| project AppName=AppName, OrgId = OrgId, UserId = UserId, Action = Action, Parameter = Parameter, EventInfo_Time = EventInfo_Time, ExtensionInfo = ExtensionInfo, ProcessTime = ProcessTime";
            query += seletcolumn;
            using (var kustoDataContext = new KustoDataContext(KustoConnectionString))
            {
                using (var reader = kustoDataContext.ExecuteQuery(query))
                {
                    while (reader.Read())
                    {
                        UserAction row = new UserAction()
                        {
                            AppName = reader.GetValue(0).ToString(),
                            CorpId = reader.GetValue(1).ToString(),
                            UserId = reader.GetValue(2).ToString(),
                            Action = reader.GetValue(3).ToString(),
                            Parameter = reader.GetValue(4).ToString(),
                            ActionTime = reader.GetValue(5).ToString(),
                            ExtensionInfo = reader.GetValue(6).ToString(),
                            ProcessTime = reader.GetValue(7).ToString()
                        };
                        result.Add(row);
                    }
                }
            }
            return result;
        }
        

    }

    //feature used
    public class CountOfFeatureUsedResult
    {
        public DateTime QueryTime { get; set; }
        public string CorpId { get; set; }
        public int Count { get; set; }
    }

    public class QueryResult
    {
        public int Count { get; set; }
        public DateTime QueryTime { get; set; }
    }
    public class KustoParams
    {
        public const string AppSubId = "{appsubid}";
        public const string StartTime = "{starttime}";
        public const string EndTime = "{endtime}";
    }

    public class UserAction
    {
        public string AppName { get; set; }
        public string CorpId { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public string Parameter { get; set; }
        public string ActionTime { get; set; }
        public string ExtensionInfo { get; set; }
        public string ProcessTime { get; set; }
    }
}
