using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Tracer
{
    public class TracerClass:ITrace
    {
        TraceData traced;
        public TracerClass(string methodName, string className)
        {
            traced.className = className;
            traced.methodName = methodName;
            traced.duration = new Stopwatch();
        }
        public void startTrace()
        {
            traced.duration.Start();
        }
        public void endTrace()
        {
            traced.duration.Stop();
            printAll();
        }
        public TraceData getResult()
        {
            return traced;
        }
        public void printAll()
        {
            Console.WriteLine(traced.className+" "+ traced.methodName + " " +(int)traced.duration.Elapsed.TotalMilliseconds+"ms"); 
        }
    }
    public struct TraceData
    {
        public string methodName { get; set; }
        public string className { get; set; }
        public Stopwatch duration { get; set; }
    }
}
