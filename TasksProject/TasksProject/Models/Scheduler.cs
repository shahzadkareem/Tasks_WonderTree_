using Quartz;
using Quartz.Impl;
using System;
using System.Threading.Tasks;
using TasksProject;
using TasksProject.Models;

public class Scheduler
{
    private IScheduler scheduler;

    public Scheduler()
    {
        scheduler = new StdSchedulerFactory().GetScheduler().Result;
    }

    public async Task Start()
    {
        await scheduler.Start();

        // Define the job details and trigger
        var jobDetail = JobBuilder.Create<LogJob>()
            .WithIdentity("logJob", "group1")
            .Build();

        var trigger = TriggerBuilder.Create()
            .WithIdentity("logTrigger", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(60)
                .RepeatForever())
            .Build();

        // Schedule the job
        await scheduler.ScheduleJob(jobDetail, trigger);
    }

    public async Task Stop()
    {
        await scheduler.Shutdown();
    }
}

public class LogJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        // Perform the logging task here
        string message = "Log entry created at " + DateTime.Now;

        using (var db = new ApplicationDbContext())
        {
            var logEntry = new Log
            {
                Timestamp = DateTime.Now,
                Message = message
            };

            db.Log.Add(logEntry);
            await db.SaveChangesAsync();
        }
    }
}








