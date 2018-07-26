using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekFive
{
    public class Monitor
    {
        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;

        public Monitor()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        public string getCpuUsage()
        {
            return cpuCounter.NextValue().ToString();
        }

        public string getAvailableRAM()
        {
            return ramCounter.NextValue().ToString();
        }
    }
}
