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
            doSomething();
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            Thread.Sleep(120);
            tracer.endTrace();
        }
        static public void doSomething()
        {
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            doSomething2();
            Thread.Sleep(1280);
            tracer.endTrace();
        }
        static public void doSomething2()
        {
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            Thread.Sleep(1500);
            tracer.endTrace();
        }
    }
}
