using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDQ.EntityFramework.Updates
{
    public class xUpdateService
    {
        public static void xDoUpdate(Decimal sentVersion)
        {
            if (sentVersion < 1.6M)
            {
                Update016000.xDoUpdate();
            }

            if (sentVersion < 1.7M)
            {
                Update017000.xDoUpdate();
            }
        }
    }
}
