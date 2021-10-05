using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer
{
    interface ITrace
    {
        void startTrace(string methodName, string className, DateTime startTime);
        void endTrace(DateTime endTime);
        TraceData getResult();

    }
}
