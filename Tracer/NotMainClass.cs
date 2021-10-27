using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Reflection;

namespace Tracer
{
    public class NotMainClass
    {
        static 
        public ThreadsClass DoSomethingButNotInMain()
        {
            ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            threadList.methodList.Add(tracer);
            tracer.startTrace();
            Thread.Sleep(1000);
            tracer.endTrace();
            threadList.EndContdown();
            return threadList;
        }
    }
}
