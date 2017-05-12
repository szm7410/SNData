using CommonLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInput
{
    public class InputDataService
    {
        public InputDataService()
        {

        }
        //该类用来从各个数据源来取得数据，包括用户的action数据，还有非用户行为数据，比如：绑定用户数、关注用户数、app授权范围等数据
        public bool PullData(DateTime StartTime,DateTime EndTime)
        {
            bool result = true;
            return result;
        }
        //取得用户的action数据
        public bool PullUserActionData(DateTime StartTime, DateTime EndTime)
        {
            bool result = true;
            UserActionData useractiondata = new UserActionData();
            result = useractiondata.PullRawUserActionData(StartTime, EndTime);
            result = useractiondata.PullUserActionSummaryData(StartTime, EndTime);
            return result;
        }
        //取得非用户行为数据
        public bool PullDGData(DateTime StartTime, DateTime EndTime)
        {
            bool result = true;
            CorpData corpdata = new CorpData();
            corpdata.GetCorpData();
            AppAllowUser allowuserdata = new AppAllowUser();
            allowuserdata.GetAllowUser();
            //以下两个函数暂时先不实现
            CriticalLog criticallogdata = new CriticalLog();
            criticallogdata.GetCriticalLogData();
            AlertData alertdata = new AlertData();
            alertdata.GetAlertData();
            return result;
        }
    }
}
