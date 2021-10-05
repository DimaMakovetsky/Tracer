using System;
using System.Threading;

namespace Tracer
{
    class Program
    {
        static void Main(string[] args)
        {
            TracerClass tracer=new TracerClass();
            tracer.startTrace("Main", "Programm", DateTime.Now);
            Thread.Sleep(1500);
            tracer.endTrace(DateTime.Now);
            tracer.printAll();
        }
    }
}
