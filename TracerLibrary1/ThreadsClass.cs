using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace TracerLibrary1
{
    [Serializable]
    
    public class ThreadsClass
    {
        [XmlElement(ElementName ="ID")]
        [JsonProperty("ID")]
        public int id { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        private Stopwatch stopwatch { get; set; }
        [XmlElement(ElementName = "Time")]
        [JsonProperty("Time")]
        public long duration { get; set; }
        public List<TracerClass> methodList;
        public List<ThreadsClass> threadList;
        public ThreadsClass(int id)
        {
            this.id = id;
            stopwatch = new Stopwatch();
            methodList = new List<TracerClass>();
            threadList = new List<ThreadsClass>();
            stopwatch.Start();
        }
        public ThreadsClass()
        {
        }
        public void EndContdown()
        {
            stopwatch.Stop();
            duration = stopwatch.ElapsedMilliseconds;
        }
    }
}
