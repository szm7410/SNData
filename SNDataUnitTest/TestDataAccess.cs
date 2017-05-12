using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccess;
using DataAccess.DataModel;
using DataAccess.Implementation;

namespace SNDataUnitTest
{
    [TestClass]
    public class TestUserActionDataAccess
    {
        [TestMethod]
        public void TestUserAction()
        {

            UserActionDataAccess dal = new UserActionDataAccess();

            UserAction userAction = new UserAction()
            {
                Action = "action",
                AppName = "通讯录",
                DateTimeUTC = DateTime.UtcNow,
                ExtensionInfo = "info",
                OrgId = "wx8c4dc9f541649ba8",
                Parameter = "userid",
                RequestUrl = "none",
                UserId = "userid"
            };
            //add
            dal.AddItem(userAction);
            //update
            userAction.AppName = "微软小秘";
            dal.UpdateItem(userAction);
            //get
            UserAction ua = dal.GetItem(userAction.ID);
            //delete
            dal.DeleteItem(ua.ID);
        }

    }

    [TestClass]
    public class TestAppAllowUserDataAccess
    {
        [TestMethod]
        public void TestAppAllowUser()
        {
            AppAllowUserDataAccess dal = new AppAllowUserDataAccess();

            AppAllowUser user = new AppAllowUser()
            {
                AllowUserCount = 10,
                APPID = 1,
                Corpid = "wx8c4dc9f541649ba8",
                Querydate = DateTime.UtcNow,
                Stage = 3
            };
            //add
            dal.AddItem(user);
            //update
            user.AllowUserCount = 20;
            dal.UpdateItem(user);
            //get
            AppAllowUser u = dal.GetItem(user.ID);
            //delete
            dal.DeleteItem(u.ID);
        }
    }

    [TestClass]
    public class TestAppUsedByDayDataAccess
    {
        [TestMethod]
        public void TestAppUsedByDay()
        {
            AppUsedByDayDataAccess dal = new AppUsedByDayDataAccess();

            AppUsedByDay appUsed = new AppUsedByDay()
            {
                AppID = 2,
                Corpid = "wx8c4dc9f541649ba8",
                QueryData = DateTime.UtcNow,
                UseCount = 30,
                UseUserCount = 2
            };
            //add
            dal.AddItem(appUsed);
            //update
            appUsed.UseUserCount = 9;
            dal.UpdateItem(appUsed);
            //get
            AppUsedByDay a = dal.GetItem(appUsed.ID);
            //delete
            dal.DeleteItem(a.ID);
        }
    }
    [TestClass]
    public class TestAppUsedByMonthDataAccess
    {
        [TestMethod]
        public void TestAppUsedByMonth()
        {
            AppUsedByMonthDataAccess dal = new AppUsedByMonthDataAccess();

            AppUsedByMonth appUsed = new AppUsedByMonth()
            {
                AppID = 2,
                Corpid = "wx8c4dc9f541649ba8",
                QueryData = DateTime.UtcNow,
                Month = "17/05",
                UseCount = 30,
                UseUserCount = 2
            };
            //add
            dal.AddItem(appUsed);
            //update
            appUsed.UseUserCount = 9;
            dal.UpdateItem(appUsed);
            //get
            AppUsedByMonth a = dal.GetItem(appUsed.ID);
            //delete
            dal.DeleteItem(a.ID);
        }
    }
    [TestClass]
    public class TestAppUsedByWeekDataAccess
    {
        [TestMethod]
        public void TestAppUsedByWeek()
        {
            AppUsedByWeekDataAccess dal = new AppUsedByWeekDataAccess();

            AppUsedByWeek appUsed = new AppUsedByWeek()
            {
                AppID = 2,
                Corpid = "wx8c4dc9f541649ba8",
                QueryData = DateTime.UtcNow,
                Week = "17/05",
                UseCount = 30,
                UseUserCount = 2
            };
            //add
            dal.AddItem(appUsed);
            //update
            appUsed.UseUserCount = 9;
            dal.UpdateItem(appUsed);
            //get
            AppUsedByWeek a = dal.GetItem(appUsed.ID);
            //delete
            dal.DeleteItem(a.ID);
        }
    }

    [TestClass]
    public class TestDataSourceDataAccess
    {
        [TestMethod]
        public void TestDataSource()
        {
            DataSourceDataAccess dal = new DataSourceDataAccess();

            DataSource item = new DataSource()
            {
                APPID = 2,
                ConnectString = "connectionstring",
                CreateTime = DateTime.UtcNow,
                DataSoureType = "DG",
                QueryString = "select count(*) from BindingUser where corpid in ()",
                SaveTo = DateTime.Now.ToString("yy-MM-dd") + ".txt"
            };
            //add
            dal.AddItem(item);
            //update
            item.APPID = 9;
            dal.UpdateItem(item);
            //get
            DataSource ds = dal.GetItem(item.Id);
            //delete
            dal.DeleteItem(ds.Id);
        }
    }

    [TestClass]
    public class TestFeatureUsedByDayDataAccess
    {
        [TestMethod]
        public void TestFeatureUsedByDay()
        {
            FeatureUsedByDayDataAccess dal = new FeatureUsedByDayDataAccess();

            FeatureUsedByDay item = new FeatureUsedByDay()
            {
                AppID = 2,
                Corpid = "wx8c4dc9f541649ba8",
                FeatureID = 9,
                QueryData = DateTime.UtcNow,
                UseCount = 23,
                UserDetailInfo = DateTime.Now.ToString("yy-MM-dd") + ".txt",
                UseUserCount = 234
            };
            //add
            dal.AddItem(item);
            //update
            item.UseUserCount = 897;
            dal.UpdateItem(item);
            //get
            FeatureUsedByDay f = dal.GetItem(item.ID);
            //delete
            dal.DeleteItem(f.ID);
        }
    }

    [TestClass]
    public class TestFeatureUsedByMonthDataAccess
    {

        [TestMethod]
        public void TestFeatureUsedByMonth()
        {
            FeatureUsedByMonthDataAccess dal = new FeatureUsedByMonthDataAccess();

            FeatureUsedByMonth item = new FeatureUsedByMonth()
            {
                AppID = 2,
                Corpid = "wx8c4dc9f541649ba8",
                FeatureID = 9,
                QueryData = DateTime.UtcNow,
                Month = "17/05",
                UseCount = 23,
                UserDetailInfo = DateTime.Now.ToString("yy-MM-dd") + ".txt",
                UseUserCount = 234
            };
            //add
            dal.AddItem(item);
            //update
            item.FeatureID = 12;
            dal.UpdateItem(item);
            //get
            FeatureUsedByMonth f = dal.GetItem(item.ID);
            //delete
            dal.DeleteItem(f.ID);
        }

    }
    [TestClass]
    public class TestFeatureUsedByWeekDataAccess
    {
        [TestMethod]
        public void TestFeatureUsedByWeek()
        {
            FeatureUsedByWeekDataAccess dal = new FeatureUsedByWeekDataAccess();
            FeatureUsedByWeek item = new FeatureUsedByWeek() {
                AppID = 2,
                Corpid = "wx8c4dc9f541649ba8",
                FeatureID = 9,
                QueryData = DateTime.UtcNow,
                Week = "17/05",
                UseCount = 23,
                UserDetailInfo = DateTime.Now.ToString("yy-MM-dd") + ".txt",
                UseUserCount = 234
            };
            //add
            dal.AddItem(item);
            //update
            item.FeatureID = 12;
            dal.UpdateItem(item);
            //get
            FeatureUsedByWeek f = dal.GetItem(item.ID);
            //delete
            dal.DeleteItem(f.ID);
        }
    }

    [TestClass]
    public class TestUserDataDataAccess
    {
        [TestMethod]
        public void TestUserData()
        {
            UserDataDataAccess dal = new UserDataDataAccess();

            UserData item = new UserData() {
                BoundUserCount=12,
                Corpid= "wx8c4dc9f541649ba8",
                corpname="文思海辉",
                FollowUserCount=123,
                Querydate=DateTime.UtcNow,
                TotalUserCount=5000
            };

            //add
            dal.AddItem(item);
            //update
            item.TotalUserCount = 6000;
            dal.UpdateItem(item);
            //get
            UserData u = dal.GetItem(item.ID);
            //delete
            dal.DeleteItem(u.ID);
        }

    }
}
