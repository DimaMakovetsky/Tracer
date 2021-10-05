using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Tracer
{
    public class TracerClass:ITrace
    {
        TraceData traced;
        Stopwatch stopwatch = new Stopwatch();
        public void startTrace(string methodName, string className, DateTime startTime)
        {
            traced.className = className;
            traced.methodName = methodName;
            stopwatch.Start();
        }
        public void endTrace(DateTime endTime)
        {
            stopwatch.Stop();
            traced.resultTime = stopwatch.Elapsed;
        }
        public TraceData getResult()
        {
            return traced;
        }
        public void printAll()
        {
            Console.WriteLine(traced.className+" "+ traced.methodName + " " +(int)traced.resultTime.TotalMilliseconds+"ms"); 
        }
    }
    public struct TraceData
    {
        public string methodName { get; set; }
        public string className { get; set; }
        public TimeSpan resultTime { get; set; }
    }
}
