using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;

namespace Tracer
{
    public class NotMainClass
    {
        static ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
        public static void DoSomethingButNotInMain()
        {
            Program.mainList.list.Add(threadList);
            
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            //threadList.list.methodList.Add(tracer);
            threadList.methodList.Add(tracer);

            tracer.startTrace();
            Thread.Sleep(1000);
            
            Program.traceEnder(tracer);
            threadList.EndContdown();
            //list.Add(tracer.getResult());
        }
    }
}
