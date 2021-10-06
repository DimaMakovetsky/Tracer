using System;
using System.Collections.Generic;
using System.Text;

namespace Tracer
{
    interface ITrace
    {
        void startTrace();
        void endTrace();
        TraceData getResult();

    }
}
