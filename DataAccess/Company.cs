using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public partial class Company
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public int Stage { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string Type { get; set; }
    }
}
