using System;
using System.Collections.Generic;
using System.Text;


namespace TracerLibrary1
{
    interface ITrace
    {
        void startTrace();
        void endTrace();
        TraceData getResult();

    }
}
