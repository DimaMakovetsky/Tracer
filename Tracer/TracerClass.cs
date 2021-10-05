using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer
{
    public class TracerClass
    {
        TraceData traced;
        public void startTrace(string methodName, string className, DateTime startTime)
        {
            traced.className = className;
            traced.methodName = methodName;
            traced.startTime = startTime;
        }
        public void endTrace(DateTime endTime)
        {
            traced.workingMilliseconds = endTime.Millisecond - traced.startTime.Millisecond;
            traced.workingSeconds = endTime.Second - traced.startTime.Second;
            //traced.resultTime = endTime;
        }
        
        public void printAll()
        {
            Console.WriteLine(traced.className+" "+ traced.methodName + " " + traced.workingSeconds+"s "+traced.workingMilliseconds+"ms"); 
        }
    }
    struct TraceData
    {
        public string methodName { get; set; }
        public string className { get; set; }
        public DateTime startTime { get; set; }
        //public DateTime endTime { get; set; }
        //public DateTime resultTime { get; set; }
        public int workingMilliseconds { get; set; }
        public int workingSeconds { get; set; }
    }
}
