using System.Diagnostics;

namespace RealTimeSuite.Helper
{
    public class PerformanceMonitor
    {
        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;

        public PerformanceMonitor()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
        }
        public string getCpuUsage()
        {
            return cpuCounter.NextValue().ToString();
        }

        public string getMemoryUsage()
        {
            return ramCounter.NextValue().ToString();
        }
    }
}
