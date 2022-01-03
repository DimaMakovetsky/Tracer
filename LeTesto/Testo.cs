using System;
using Xunit;
using Tracer;
using System.Threading;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using TracerLibrary1;

namespace LeTesto
{
    public class Testo
    {
        [Fact]
        public void Test1()
        {
            MainList mainList = new MainList();
            ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            tracer.miniMethodList.Add(Tracer.Program.DoSomething2());
            tracer.endTrace();
            threadList.methodList.Add(tracer);
            threadList.EndContdown();
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds -mainList.list[0].duration) < 100);
        }
        [Fact]
        public void Test12()
        {
            MainList mainList = new MainList();
            ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            tracer.miniMethodList.Add(Tracer.Program.DoSomething2());
            tracer.endTrace();
            threadList.methodList.Add(tracer);
            threadList.EndContdown();
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds - mainList.list[0].duration) < 100);
        }

        [Fact]
        public void Test2()
        {
            MainList mainList = new MainList();
            ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            tracer.miniMethodList.Add(Tracer.Program.DoSomething());
            tracer.endTrace();
            threadList.methodList.Add(tracer);
            threadList.EndContdown();
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds -mainList.list[0].duration) < 100);
        }
        [Fact]
        public void Test3()
        {
            MainList mainList = new MainList();
            ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            tracer.miniMethodList.Add(Tracer.Program.DoSomething2());
            tracer.miniMethodList.Add(Tracer.Program.DoSomething());
            Thread.Sleep(120);
            tracer.endTrace();
            threadList.methodList.Add(tracer);
            threadList.EndContdown();
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds - mainList.list[0].duration) < 100);
        }
        
        [Fact]
        public void Test4()
        {
         MainList mainList = new MainList();
            ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            ThreadsClass threads = null;
            Thread thread = new Thread(() =>
            {
                threads = NotMainClass.DoSomethingButNotInMain();
            });
            thread.Start();
            Thread.Sleep(120);
            thread.Join();
            mainList.list.Add(threads);
            tracer.endTrace();
            threadList.methodList.Add(tracer);
            threadList.EndContdown();
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds -mainList.list[0].duration) < 100);
        }
        [Fact]
        public void Test5()
        {
            MainList mainList = new MainList();
            ThreadsClass threadList = new ThreadsClass(Thread.CurrentThread.ManagedThreadId);
            Stopwatch stopwatch = new Stopwatch(); stopwatch.Start();
            mainList.list.Add(threadList);
            TracerClass tracer = new TracerClass(MethodBase.GetCurrentMethod().Name, MethodBase.GetCurrentMethod().DeclaringType.Name);
            tracer.startTrace();
            ThreadsClass threads = null;
            tracer.miniMethodList.Add(Tracer.Program.DoSomething());
            Thread thread = new Thread(() =>
            {
                threads = NotMainClass.DoSomethingButNotInMain();
            });
            thread.Start();
            Thread.Sleep(120);
            thread.Join();
            mainList.list.Add(threads);
            tracer.endTrace();
            threadList.methodList.Add(tracer);
            threadList.EndContdown();
            stopwatch.Stop();
            Assert.True(Math.Abs(stopwatch.ElapsedMilliseconds - mainList.list[0].duration) < 100);
        }
    }
}
