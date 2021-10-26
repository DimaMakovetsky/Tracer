using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Text.Json.Serialization;

namespace Tracer
{
    [Serializable]
    [XmlRoot]

    public class MainList
    {
        [XmlArray("threads")]
        [JsonPropertyName("threads")]
        public List<ThreadsClass> list { get; set; }
        public MainList()
        {
            list = new List<ThreadsClass>();
        }
    }
}
