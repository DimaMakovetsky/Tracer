using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace TracerLibrary1
{
    [Serializable]
    //[JsonArray(false)]
    public class TracerClass:ITrace
    {
        
        public TraceData trace;
        [XmlIgnore]
        [JsonIgnore]
        public Stopwatch duration { get; set; }
        [XmlArray]
        [JsonProperty]
        public List<TracerClass> miniMethodList;
        public List<ThreadsClass> threadsList;
        
        public TracerClass(string methodName, string className)
        {
            trace.className = className;
            trace.methodName = methodName;
            duration = new Stopwatch();
            miniMethodList = new List<TracerClass>();
        }
        public TracerClass()
        {
        }
        public void startTrace()
        {
            duration.Start();
        }
        public void endTrace()
        {
            duration.Stop();
            trace.fullDuration = duration.ElapsedMilliseconds;
        }
        public TraceData getResult()
        {
            return trace;
        }
    }
    [Serializable]
    
    public struct TraceData
    {
        [JsonProperty]
        public string methodName { get; set; }
        [JsonProperty]
        public string className { get; set; }
        [JsonProperty("Time")]
        public long fullDuration { get; set; }
    }
    
}
