using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CommonLib;
using System.Collections.Generic;

namespace SNDataUnitTest
{
    [TestClass]
    public class TestKusto
    {
        [TestMethod]
        public void TestQueryUserAcion()
        {
            string tenantId = "5e6656def08a4558a4c164a28cc3b004";
            string token = "5e6656def08a4558a4c164a28cc3b004-80637e49-e9d8-49e9-9653-bf3ea6333021-7038";
            string url = "https://kusto.aria.microsoft.com";
            KustoHandler service = new KustoHandler(tenantId, token, url);
            string querystring = "dg_app_telemetry | where EventInfo_Time > datetime(2017-05-10 03:18:05.1340000) | limit 100";
            List<UserAction> useraciont = service.QueryUserAcion(querystring);
            Assert.AreEqual(100,useraciont.Count);
        }
    }
}
