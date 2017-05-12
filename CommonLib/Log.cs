using Microsoft.Shennong.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public static class Log
    {
        public static void Critical(Guid correlationId, string content, string action = "", string tag = "", string component = "", string hostName = "", string envInfo = "", bool ariaOn = false)
        {
            Logger2.Critical(correlationId, content, action, tag, component, hostName, envInfo);
        }
        public static void Error(Guid correlationId, string content, string action = "", string tag = "", string component = "", string hostName = "", string envInfo = "")
        {
            Logger2.Error(correlationId, content, action, tag, component, hostName, envInfo);
        }
        public static void Warning(Guid correlationId, string content, string action = "", string tag = "", string component = "", string hostName = "", string envInfo = "")
        {
            Logger2.Warning(correlationId, content, action, tag, component, hostName, envInfo);
        }
        public static void Information(Guid correlationId, string content, string action = "", string tag = "", string component = "", string hostName = "", string envInfo = "")
        {
            Logger2.Information(correlationId, content, action, tag, component, hostName, envInfo);
        }
        public static void Debug(Guid correlationId, string content, string action = "", string tag = "", string component = "", string hostName = "", string envInfo = "")
        {
            Logger2.Debug(correlationId, content, action, tag, component, hostName, envInfo);
        }


    }
}
