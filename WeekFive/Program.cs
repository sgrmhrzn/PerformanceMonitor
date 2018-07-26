using Microsoft.AspNet.SignalR.Client;
using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WeekFive
{
    public class Program
    {
        private static HubConnection _hub;
        private static IHubProxy _proxy;

        static void Main(string[] args)
        {
            Monitor monitor = new Monitor();

            while (true)
            {
                var currentCPUUsage = monitor.getCpuUsage();
                var availableRAM = Convert.ToDecimal(monitor.getAvailableRAM());
                var totalRAM = Convert.ToDecimal((new ComputerInfo().TotalPhysicalMemory / (Math.Pow(1024, 2))) + 0.5);
                var currentRAMUsage = totalRAM - availableRAM;
                string path = @"\logs.txt";
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(DateTime.Now + "     CPU Usage   " + currentCPUUsage + "%      Memory Usage   " + currentRAMUsage + " MB");
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(DateTime.Now + "     CPU Usage   " + currentCPUUsage + "%      Memory Usage   " + currentRAMUsage + " MB");
                    }
                }
                var ramUsagePercent = currentRAMUsage / totalRAM * 100;
                PublishUsages(new MonitorDataModel { CPUUsage = currentCPUUsage, RAMUsage = ramUsagePercent.ToString(), Date = DateTime.Now });
                Thread.Sleep(10000);
            }
        }

        public static async void PublishUsages(MonitorDataModel usageData)
        {
            var data = JsonConvert.SerializeObject(usageData);
            _hub = new HubConnection("http://localhost:60569");
            _proxy = _hub.CreateHubProxy("RealTimeHub");
            await _hub.Start();
            await _proxy.Invoke("SendPerformanceMonitorData", data);
        }
    }
}
