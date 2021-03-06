﻿using SQLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataModel
{
    [SQLinqTable("FeatureUsedByDay")]
    public class FeatureUsedByDay
    {
        public long ID { get; set; }

        public DateTime QueryData { get; set; }
        public int AppID { get; set; }
        public string Corpid { get; set; }

        public int FeatureID { get; set; }

        public int UseCount { get; set; }

        public int UseUserCount { get; set; }

        public string UserDetailInfo { get; set; }

    }
}
