using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;
using RealTimeSuite.Helper;

namespace RealTimeSuite
{
    [HubName("RealTimeHub")]
    public class RealTime : Hub
    {
        static PerformanceMonitor monitor = new PerformanceMonitor();
        Mail mail = new Mail();
        public RealTime()
        {

        }

        public void SendPerformanceMonitorData(string data)
        {
            Clients.All.sendPerformanceData(data);
        }

        public void SendEmailForCPUPeakLoad(string data)
        {
            mail.SendMail(data, "Notification on CPU in peak load", "CPU usage haved exceeded 90% of CPU on servers");
        }

        public void SendEmailForMemoryPeakLoad(string data)
        {
            mail.SendMail(data, "Notification on RAM in peak load", "CPU usage haved exceeded 85% of RAM on servers");
        }
    }
}
