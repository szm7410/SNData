﻿using SQLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    [SQLinqTable("AppUsedByMonth")]
    public class AppUsedByMonth
    {
        public long ID { get; set; }

        public DateTime QueryData { get; set; }
        public string Month { get; set; }
        public int AppID { get; set; }
        public string Corpid { get; set; }
        public int UseCount { get; set; }
        public int UseUserCount { get; set; }
    }
}
