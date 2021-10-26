using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace Tracer
{
    public class Program
    {
        
        public static void traceEnder(TracerClass tracer)
        {
            tracer.endTrace();
            //threadList.list.methodList.Add(tracer);
           // threadList.methodList.Add(tracer);
        }
        public static MainList mainList = new MainList();
        static ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
        static void Main(string[] args)
        {
            //Stopwatch s=new Stopwatch();            s.Start();

            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);

            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            /**/
            tracer.miniMethodList.Add(Tracer.Program.DoSomething());

            tracer.miniMethodList.Add(Tracer.Program.DoSomething2());
            ThreadStart th = new ThreadStart(NotMainClass.DoSomethingButNotInMain);
            Thread thread = new Thread(th);
            thread.Start();
            Thread.Sleep(120);

            thread.Join();
            // s.Stop();
            Tracer.Program.traceEnder(tracer);
            threadList.methodList.Add(tracer);
            threadList.EndContdown();
            stopwatch.Stop();
            Xmlirise xml = new Xmlirise();
            xml.Serialize(mainList);
            Jsonise json = new Jsonise();
            json.Serialize(mainList);
            
            Console.WriteLine(stopwatch.ElapsedMilliseconds+" "+ Math.Abs(stopwatch.ElapsedMilliseconds - 3400));
            /* long timeSum = 0;
             for (int i = 0; i < mainList.list.Count; i++)
             {
                 timeSum += mainList.list[i].duration;
             }*/
            // Console.WriteLine(s.ElapsedMilliseconds+"   "+timeSum);
            //xml.EndSerialization();
        }
        static public TracerClass DoSomething()
        {
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            tracer.miniMethodList.Add( DoSomething2());
            Thread.Sleep(1280);
            traceEnder(tracer);
            return tracer;
        }
        static public TracerClass DoSomething2()
        {
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            Thread.Sleep(500);
            traceEnder(tracer);
            return tracer;
        }
    }
}
