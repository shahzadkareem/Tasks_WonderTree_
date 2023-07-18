using System;
using System.Threading.Tasks;
using System.Web.Mvc;

public class SchedulerController : Controller
{
    private static Scheduler scheduler;

    public async Task<ActionResult> Start()
    {
        try
        {
            scheduler = new Scheduler();
            await scheduler.Start();

            return Content("Scheduler started.");
        }
        catch (Exception ex)
        {
            return Content("An error occurred: " + ex.Message);
        }
    }

    public async Task<ActionResult> Stop()
    {
        try
        {
            if (scheduler != null)
            {
                await scheduler.Stop();
                scheduler = null;
            }

            return Content("Scheduler stopped.");
        }
        catch (Exception ex)
        {
            return Content("An error occurred: " + ex.Message);
        }
    }
}







