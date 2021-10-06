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
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            NotMainClass notMain = new NotMainClass();
            tracer.startTrace();
            
            ThreadStart th = new ThreadStart(notMain.DoSomethingButNotInMain);
            Thread thread = new Thread(th);
            thread.Start();
            DoSomething();
            Thread.Sleep(120);
            //WaitHandle.WaitAll(thread);
            tracer.endTrace();
        }
        static public void DoSomething()
        {
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            DoSomething2();
            Thread.Sleep(1280);
            tracer.endTrace();
        }
        static public void DoSomething2()
        {
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            Thread.Sleep(500);
            tracer.endTrace();
        }
    }
}
