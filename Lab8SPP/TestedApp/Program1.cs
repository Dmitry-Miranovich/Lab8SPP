using System;
using Lab8SPP;
namespace TestedApp
{
    [ExportClass]
    public class Program1
    {
        public int Param;
        public string Param2;
        public Program1(int param1, string param2)
        {
            this.Param = param1;
            this.Param2 = param2;
        }
        public void Method1()
        {

        }
        public string Method2()
        {
            return "";
        }
    }
}
