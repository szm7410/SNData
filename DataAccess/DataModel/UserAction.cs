using SQLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    [SQLinqTable("UserAction")]
    public class UserAction
    {
        public long ID { get; set; }
        public string AppName { get; set; }
        public string OrgId { get; set; }
        public string UserId { get; set; }
        public string Action { get; set; }
        public string Parameter { get; set; }
        public DateTime DateTimeUTC { get; set; }
        public string ExtensionInfo { get; set; }
        public string RequestUrl { get; set; }
    }
}
