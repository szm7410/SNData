using SQLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    [SQLinqTable("UserData")]
    public class UserData
    {
        public long ID { get; set; }
        public string Corpid { get; set; }
        public string corpname { get; set; }
        public int TotalUserCount { get; set; }
        public int FollowUserCount { get; set; }
        public int BoundUserCount { get; set; }
        public DateTime Querydate { get; set; }

    }
}
