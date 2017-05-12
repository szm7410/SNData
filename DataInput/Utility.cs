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
    public class Utility
    {
        public static string DragonGateDomain = "https://msdg.live.com";
        protected static WebHelper WebHelper = new WebHelper();

        public Utility()
        {

        }

        //获取DgToken
        public static string GetDgToken(string appId, string appSecret, string corpid, string wechatid, Guid correlationId)
        {
            string dgtoken;
            try
            {
                string requestUrl = $"{DragonGateDomain}/v1.0/dgtoken";
                Dictionary<string, string> headers = new Dictionary<string, string> { { "appId", appId }, { "appSecret", appSecret }, { "subscriberUniqueId", corpid }, { "wechatId", wechatid } };
                SNHttpWebResponse response = WebHelper.GetRequest(requestUrl, headers);
                dynamic result = JsonConvert.DeserializeObject(response.ResponseStream);

                dgtoken = result.token.ToString();

            }
            catch (Exception e)
            {
                Log.Error(correlationId, JsonConvert.SerializeObject(e), "GetDgToken");
                throw;
            }
            return dgtoken;
        }
        //获取公司列表
        public static List<Company> GetCompanys(string type)
        {
            return null;
            //CompanyDataAccess dal = new CompanyDataAccess();
            //try
            //{
            //    var list = dal.GetAll(c => c.IsActive.Value && c.Type == type).ToList();
            //    return list;
            //}
            //catch (Exception ex)
            //{
            //    return null;
            //}

        }
    }
}
