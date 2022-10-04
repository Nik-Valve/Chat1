using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat1.ClassHelper
{
    internal class AppData
    {
        public static EF.ChatNevEntities Context { get; } = new EF.ChatNevEntities();
    }
}
