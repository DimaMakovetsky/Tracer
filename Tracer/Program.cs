using System;
using System.Threading;
using System.Diagnostics;
using System.Reflection;

namespace Tracer
{
    class Program
    {
        static void Main(string[] args)
        {
            TracerClass tracer=new TracerClass();
            tracer.startTrace(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name , DateTime.Now);
            Thread.Sleep(1280);
            tracer.endTrace(DateTime.Now);
            tracer.printAll();
        }
    }
}
