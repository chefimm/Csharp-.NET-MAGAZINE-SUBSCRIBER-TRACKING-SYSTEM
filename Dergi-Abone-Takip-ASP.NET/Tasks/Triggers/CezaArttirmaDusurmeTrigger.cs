using Dergi_Abone_Takip_ASP.NET.Tasks.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dergi_Abone_Takip_ASP.NET.Tasks.Triggers
{
    public class CezaArttirmaDusurmeTrigger
    {
        public static void Baslat() 
        {
            IScheduler zamanlayici = StdSchedulerFactory.GetDefaultScheduler();
            if(!zamanlayici.IsStarted) 
            {
                zamanlayici.Start();
            }
            IJobDetail gorev = JobBuilder.Create<CezaArttirmaDusurmeJob>().Build();

            ICronTrigger tetikleyici = (ICronTrigger)TriggerBuilder.Create().WithIdentity("CezaArttirmaDusurmeJob", "null").WithCronSchedule("0 0 17 * * ? *").Build();
            zamanlayici.ScheduleJob(gorev, tetikleyici);
        }
    }
}