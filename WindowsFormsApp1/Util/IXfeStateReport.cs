using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adam.Util
{
    public interface IXfeStateReport
    {
        void On_Transfer_Complete(XfeCrossZone xfe);
        void On_LoadPort_Complete(string PortName);
        void On_UnLoadPort_Complete(string PortName);
    }
}
