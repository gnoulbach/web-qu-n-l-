using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hangfire;
namespace demoapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : ControllerBase
    {
        // Lên lịch công việc lặp lại hàng ngày
        [HttpPost("schedule-daily-task")]
        public IActionResult ScheduleDailyTask()
        {
            RecurringJob.AddOrUpdate(
                "daily-task",
                () => Console.WriteLine("Daily task executed!"),
                Cron.Daily);
            return Ok("Daily task scheduled.");
        }

        // Lên lịch công việc theo giờ
        [HttpPost("schedule-hourly-task")]
        public IActionResult ScheduleHourlyTask()
        {
            RecurringJob.AddOrUpdate(
                "hourly-task",
                () => Console.WriteLine("Hourly task executed!"),
                Cron.Hourly);
            return Ok("Hourly task scheduled.");
        }

        // Lên lịch công việc theo phút
        [HttpPost("schedule-minute-task")]
        public IActionResult ScheduleMinuteTask()
        {
            RecurringJob.AddOrUpdate(
                "minute-task",
                () => Console.WriteLine("Minute task executed!"),
                Cron.MinuteInterval(1)); 
            return Ok("Minute task scheduled.");
        }

      
        [HttpPost("execute-once-task")]
        public IActionResult ExecuteOnceTask()
        {
            BackgroundJob.Enqueue(
                () => Console.WriteLine("This task will be executed once."));
            return Ok("Task enqueued for execution.");
        }

   
        [HttpPost("execute-delayed-task")]
        public IActionResult ExecuteDelayedTask()
        {
            BackgroundJob.Schedule(
                () => Console.WriteLine("This task will be executed after a delay."),
                TimeSpan.FromMinutes(1)); 
            return Ok("Task scheduled for execution after a delay.");
        }

    }
}
