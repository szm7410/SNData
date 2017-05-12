using SQLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    [SQLinqTable("DataSource")]
    public class DataSource
    {
        public int Id { get; set; }
        public string DataSoureType { get; set; }
        public string ConnectString { get; set; }
        public string QueryString { get; set; }
        public DateTime CreateTime { get; set; }
        public int APPID { get; set; }
        public string SaveTo { get; set; }
    }
}
