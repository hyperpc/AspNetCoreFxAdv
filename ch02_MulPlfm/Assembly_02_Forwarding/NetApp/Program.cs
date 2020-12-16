using NetLib;
using System;
using NetStandard;

namespace NetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".Net Framework 4.7.2");
            Utils.PrintAssemblyFullName();
            UtilsStandard.PrintAssemblyFullName();
        }
    }
}
