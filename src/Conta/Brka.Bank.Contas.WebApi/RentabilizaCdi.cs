using Quartz;
using Quartz.Impl;

namespace Brka.Bank.Contas.WebApi
{
    public static class RentabilizaCdi
    {
        public static IScheduler ObtemSchedulerStart()
        {
            StdSchedulerFactory factory = new StdSchedulerFactory();
            IScheduler scheduler = factory.GetScheduler().Result;
            scheduler.Start().Wait();
            return scheduler;
        }

        public static void Start()
        {
            //var data = DateTime.Now
            //var horaFechamentoMercado = new DateTime(data.Year, data.Month, data.Day, 17, 31, 0)
            var scheduler = ObtemSchedulerStart();

            IJobDetail job = JobBuilder.Create<RentabilizaContaCorrenteCdiFechamentoJob>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                //.StartAt(horaFechamentoMercado)
                .StartNow()
                .WithSimpleSchedule(x => x
                    //.WithIntervalInHours(24)
                    .WithIntervalInMinutes(10)
                    .RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger).Wait();
        }
        
    }
}