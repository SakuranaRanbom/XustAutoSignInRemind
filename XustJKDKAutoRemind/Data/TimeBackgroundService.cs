using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using XustJKDKAutoRemind.Service;

namespace XustJKDKAutoRemind.Data
{
    public class TimeBackgroundService : BackgroundService
    {
        private readonly ILogger _logger;
        private static Timer aTimer;

        private IEnumerable<QQStu> QQStus { get; set; }
        private static void SetTimer()
        {
            aTimer = new System.Timers.Timer(60000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("The Elapsed event was raised at {0:yyyy-MM-dd:HH:mm:ss.fff}",
                              e.SignalTime.AddDays(1));
            string daystr = e.SignalTime.AddDays(1).ToString("yyyy-MM-dd");
            if ( (e.SignalTime.Hour.Equals(18) && e.SignalTime.Minute.Equals(30)) || (e.SignalTime.Hour.Equals(21) && e.SignalTime.Minute.Equals(00))||(e.SignalTime.Hour.Equals(20) && e.SignalTime.Minute.Equals(00)))
            {
                //调用接口
                ClientService client = new ClientService();

                //client.GetStuList(daystr);
                //client.GetOkList(daystr);
                client.SendBot(daystr);
                Console.WriteLine("18h\n");
            }
        }
        public TimeBackgroundService(ILogger<TimeBackgroundService> logger)
        {
            _logger = logger;
            //_QQStuService = qQStuService;
        }
        protected override Task ExecuteAsync(System.Threading.CancellationToken stoppingToken)
        {
            SetTimer();
            return Task.CompletedTask;
        }

        private void DoWork( object state)
        {
            _logger.LogInformation($"Info! - {DateTime.Now}");
        }
    }
}
