using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AwesomePortal
{
    class DebugFlag
    {
        private static bool DEBUG_FLAG = true;

        public static bool getValue()
        {
            return DEBUG_FLAG;
        }
    }
}
