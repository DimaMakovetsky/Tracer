using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;
using System.Text.Json;
using Newtonsoft.Json;

namespace Tracer
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

        //public JsonList list { get; set; }
        public List<TracerClass> methodList;
        public ThreadsClass(int id)
        {
            this.id = id;
            stopwatch = new Stopwatch();
            methodList = new List<TracerClass>();
            //list= new JsonList();
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
