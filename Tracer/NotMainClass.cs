using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;

namespace Tracer
{
    public class NotMainClass
    {
        public void DoSomethingButNotInMain()
        {
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            Thread.Sleep(2500);
            tracer.endTrace();
            
        }
    }
}
