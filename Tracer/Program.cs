using System;
using System.Threading;
using System.Diagnostics;
using System.Reflection;
using TracerLibrary1;

namespace Tracer
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainList mainList = new MainList();
            ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);

            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);

            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            
            tracer.miniMethodList.Add(DoSomething2());
            tracer.miniMethodList.Add(DoSomething());
            /*ThreadsClass threads = null;
            Thread thread = new Thread(() =>
              {
                  threads = NotMainClass.DoSomethingButNotInMain();
              });
            thread.Start();*/
            ThreadsClass threads = null;
            Thread thread = new Thread(() =>
            {
                threads = DoSomethingWithThread();
            });
            thread.Start();
            Thread.Sleep(120);

            thread.Join();
            tracer.miniThreadsList.Add(threads);
            //mainList.list.Add(threads);
            tracer.endTrace();
            threadList.methodList.Add(tracer);
            threadList.EndContdown();
            stopwatch.Stop();
            Xmlirise xml = new Xmlirise();
            xml.Serialize(mainList);
            
            Jsonise json = new Jsonise();
            json.Serialize(mainList);
            Console.WriteLine(stopwatch.ElapsedMilliseconds+" "+ Math.Abs(stopwatch.ElapsedMilliseconds - mainList.list[0].duration));
        }
        static public TracerClass DoSomething()
        {
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            tracer.miniMethodList.Add( DoSomething2());
            Thread.Sleep(1280);
            tracer.endTrace();
            return tracer;
        }
        static public TracerClass DoSomething2()
        {
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            Thread.Sleep(500);
            tracer.endTrace();
            return tracer;
        }
        static public ThreadsClass DoSomethingWithThread()
        {
            ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
            
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();

            tracer.miniMethodList.Add(DoSomething2());
            tracer.miniMethodList.Add(DoSomething());
            /*ThreadsClass threads = null;

            Thread thread = new Thread(() =>
            {
                threads = NotMainClass.DoSomethingButNotInMain();
            });
            thread.Start();
            Thread.Sleep(120);

            thread.Join();
            mainList.list.Add(threads);*/
            //threadList.methodList.Add(tracer);
            tracer.endTrace();
            
            threadList.EndContdown();
            for (int i = 0; i < tracer.miniMethodList.Count; i++)
            {
                threadList.methodList.Add(tracer.miniMethodList[i]);
            }
            //tracer.miniThreadsList.Add(threadList);
            return threadList;
        }
    }
}
