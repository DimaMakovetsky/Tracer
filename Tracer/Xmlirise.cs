using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace Tracer
{
    public class Xmlirise : ISerialization
    {
        
        public Xmlirise()
        {}
        public void Serialize(MainList list)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(MainList));
            FileStream fs = new FileStream("ses.xml", FileMode.Create);
            serializer.Serialize(fs, list);// traceData.getResult());
            fs.Close();
            serializer.Serialize(Console.Out, list);
        }
        
    }
}
