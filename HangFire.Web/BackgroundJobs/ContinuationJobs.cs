using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HangFire.Web.BackgroundJobs
{
    public class ContinuationJobs
    {
        public static void WriteWatermarkStatusJob (string id,string filename) {

            Hangfire.BackgroundJob.ContinueJobWith(id, () => Debug.WriteLine($"{filename}:watermark added on picture"));

        }
    }
}
