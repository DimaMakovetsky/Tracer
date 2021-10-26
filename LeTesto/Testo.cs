using System;
using Xunit;
using Tracer;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace LeTesto
{
    public class Testo
    {

        public static MainList mainList = new MainList();
        static ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
        [Fact]
        public void Test1()
        {
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);

            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            /**/

            tracer.miniMethodList.Add(Tracer.Program.DoSomething2());
            
            // s.Stop();
            Tracer.Program.traceEnder(tracer);
            threadList.methodList.Add(tracer);
            threadList.EndContdown();

            Xmlirise xml = new Xmlirise();
            xml.Serialize(mainList);
            Jsonise json = new Jsonise();
            json.Serialize(mainList);
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds - 500) < 100);

        }
        [Fact]
        public void Test2()
        {
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);

            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            /**/

            tracer.miniMethodList.Add(Tracer.Program.DoSomething());

            // s.Stop();
            Tracer.Program.traceEnder(tracer);
            threadList.methodList.Add(tracer);
            threadList.EndContdown();

            Xmlirise xml = new Xmlirise();
            xml.Serialize(mainList);
            Jsonise json = new Jsonise();
            json.Serialize(mainList);
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds - 1800) < 100);

        }
        [Fact]
        public void Test3()
        {
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);

            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            /**/

            tracer.miniMethodList.Add(Tracer.Program.DoSomething());
            tracer.miniMethodList.Add(Tracer.Program.DoSomething2());
            // s.Stop();
            Tracer.Program.traceEnder(tracer);
            threadList.methodList.Add(tracer);
            threadList.EndContdown();

            Xmlirise xml = new Xmlirise();
            xml.Serialize(mainList);
            Jsonise json = new Jsonise();
            json.Serialize(mainList);
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds - 2300) < 100);

        }
        [Fact]
        public void Test4()
        {
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);

            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            /**/
            ThreadStart th = new ThreadStart(NotMainClass.DoSomethingButNotInMain);
            Thread thread = new Thread(th);
            thread.Start();
            tracer.miniMethodList.Add(Tracer.Program.DoSomething2());
            

            thread.Join();
            // s.Stop();
            Tracer.Program.traceEnder(tracer);
            threadList.methodList.Add(tracer);
            threadList.EndContdown();

            Xmlirise xml = new Xmlirise();
            xml.Serialize(mainList);
            Jsonise json = new Jsonise();
            json.Serialize(mainList);
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds - 1100) < 100);

        }
        [Fact]
        public void Test5()
        {
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

            Xmlirise xml = new Xmlirise();
            xml.Serialize(mainList);
            Jsonise json = new Jsonise();
            json.Serialize(mainList);
            stopwatch.Stop();
            Assert.True(Math.Abs( stopwatch.ElapsedMilliseconds- 3300)<100);
            
        }
        
    }
}
