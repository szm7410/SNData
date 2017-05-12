using SQLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    [SQLinqTable("AppAllowUser")]
    public class AppAllowUser
    {
        public long ID { get; set; }
        public int APPID { get; set; }
        public string Corpid { get; set; }
        public int AllowUserCount { get; set; }
        public int Stage { get; set; }
        public DateTime Querydate { get; set; }

    }
}
