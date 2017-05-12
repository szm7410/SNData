using DataAnalysis;
using DataInput;
using DataOutput;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNData
{
    class Program
    {
        static void Main(string[] args)
        {
            InputDataService inputservice = new InputDataService();
            //time set just for test
            DateTime starttime = DateTime.Now.ToUniversalTime();
            DateTime endtime = DateTime.Now.ToUniversalTime();
            inputservice.PullData(starttime,endtime);

            DataAnalysisService analysisservice = new DataAnalysisService();

            DataOutputService outputservice = new DataOutputService();
            outputservice.OutputDataToPowerBI();

        }
    }
}
