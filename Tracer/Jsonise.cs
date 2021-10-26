using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace Tracer
{
    public class Jsonise:ISerialization
    {
        public Jsonise() { }
        public void Serialize(MainList list)
        {
            string serialized = JsonConvert.SerializeObject(list,Formatting.Indented);
            //string serialized = JsonSerializer.Serialize(list);
            File.WriteAllText("PressXfor.json", serialized);
            /*FileStream fs = new FileStream("PressXfor.json", FileMode.OpenOrCreate);
            fs.w(serialized);*/
            //Console.WriteLine(serialized);    
        }
    }
}
