using CommonLib;
using DataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInput
{
    public class CorpData
    {
        protected WebHelper WebHelper = new WebHelper();
        public CorpData()
        {

        }
        public void GetCorpData()
        {

        }
        //得到所有公司关注人数
        public Dictionary<Company, UserDetailList> GetUserDetails(Guid correlationId)
        {
            List<Company> wwCompanylist = Utility.GetCompanys("ww");
            List<Company> gtCompanylist = Utility.GetCompanys("gt");
            string appId = "DC71D0B3-4FD2-4B4C-8EB7-E4988B476D3D";
            string appSecret = "a7abe4ee-c790-4ec0-aaa3-79fb9129c58b";
            string wechatid = "GetAllowUser";
            Dictionary<Company, UserDetailList> list = new Dictionary<Company, UserDetailList>();
            #region ww
            foreach (var company in wwCompanylist)
            {
                //step1.get dgtoken
                string dgtoken = Utility.GetDgToken(appId, appSecret, company.Id, wechatid, correlationId);
                //step2. get userinfo
                string restapi = $"v1.0/wechat/departments/1/userdetailinfo?FetchChild=true&Status=1";
                string requestUrl = $"{Utility.DragonGateDomain}/{restapi}";
                Dictionary<string, string> headers = new Dictionary<string, string> { { "dgToken", dgtoken } };
                SNHttpWebResponse response = WebHelper.GetRequest(requestUrl, headers);
                UserDetailList result = JsonConvert.DeserializeObject<UserDetailList>(response.ResponseStream);

                list.Add(company, result);
            }
            #endregion ww
            //---------------------------------------------------------------------------------------
            #region gt  
            appId = "729578B4-31EC-46F5-A388-6341FE9F4E77";
            appSecret = "0d118ccf-6bd2-41ca-a573-7bf52b246588";
            foreach (var company in gtCompanylist)
            {

                if (company.Id == "wx3f239ee0f2c6e820")
                    continue;
                //step1.get dgtoken
                string dgtoken = Utility.GetDgToken(appId, appSecret, company.Id, wechatid, correlationId);
                //step2. get userinfo
                string restapi = $"v1.0/wechat/departments/1/userdetailinfo?FetchChild=true&Status=1";
                string requestUrl = $"{Utility.DragonGateDomain}/{restapi}";
                Dictionary<string, string> headers = new Dictionary<string, string> { { "dgToken", dgtoken } };
                SNHttpWebResponse response = WebHelper.GetRequest(requestUrl, headers);
                UserDetailList result = JsonConvert.DeserializeObject<UserDetailList>(response.ResponseStream);
                list.Add(company, result);
            }
            #endregion gt

            return list;
        }
    }
}
