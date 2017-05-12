using CommonLib;
using Microsoft.Shennong.Common.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInput
{
    public class UserActionData
    {
        protected string tenantId = "";
        protected string token = "";
        protected string url = "";
        public UserActionData()
        {
            tenantId = ConfigHelper.GetValue("KusoTenantId");
            if (string.IsNullOrEmpty(tenantId))
                tenantId = "5e6656def08a4558a4c164a28cc3b004";
            token = ConfigHelper.GetValue("KusoToken");
            if (string.IsNullOrEmpty(token))
                token = "5e6656def08a4558a4c164a28cc3b004-80637e49-e9d8-49e9-9653-bf3ea6333021-7038";
            url = ConfigHelper.GetValue("KusoURL");
            if (string.IsNullOrEmpty(url))
                url = "https://kusto.aria.microsoft.com";
        }
        //取得用户原始的action数据，并写入SQL中，目前由于telemetry记录的内容很多，需要采取的数据才获取并写入SQL的方式
        //根据目前有的feature查询条件进行数据的筛选
        public bool PullRawUserActionData(DateTime StartTime, DateTime EndTime)
        {
            bool result = true;
            KustoHandler service = new KustoHandler(tenantId, token, url);
            return result;
        }
        //从arial中取得的按照每个featureid进行查询的结果，其中需要把用户的信息进行保留，以方便进行根据每天的数据进行每周、每月的数据汇总
        //其中用户的数据以文件的形式存在，数据库中保存文件路径
        //这个数据在第一个阶段不做数据更细致分析的阶段使用，优点是不依赖采集的数据，因为原始数据采集可能存在不可靠的情况，等数据采集模块稳定之后可以切换到从本地SQL生成数据的方式
        public bool PullUserActionSummaryData(DateTime StartTime, DateTime EndTime)
        {
            bool result = true;

            return result;
        }
    }
}
