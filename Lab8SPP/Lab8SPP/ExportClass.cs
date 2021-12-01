using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8SPP
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ExportClass : System.Attribute
    {
        public ExportClass() { }
    }
}
