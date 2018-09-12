using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adam.Util
{
    class Tools
    {

        public static int GetSlotCount(string NodeType)
        {
            int result = 0;
            switch (NodeType)
            {
                case "LOADPORT":
                    result = 25;
                    break;
                case "ROBOT":
                    result = 2;
                    break;
                case "ALIGNER":
                    result = 1;
                    break;
            }
            return result;
        }
    }
}
