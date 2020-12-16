using System;
using System.Collections.Generic;

namespace NetStandard
{
    public class UtilsStandard
    {
        public static void PrintAssemblyFullName()
        {
            Console.WriteLine(typeof(Dictionary<,>).Assembly.FullName);
            Console.WriteLine(typeof(SortedDictionary<,>).Assembly.FullName);
        }
    }
}
