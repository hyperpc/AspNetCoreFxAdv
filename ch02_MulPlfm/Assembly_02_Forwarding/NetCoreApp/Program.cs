using System;
using NetLib;
using NetStandard;

namespace NetCoreApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(".Net Core 3.0");
            Utils.PrintAssemblyFullName();
            UtilsStandard.PrintAssemblyFullName();
        }
    }
}
