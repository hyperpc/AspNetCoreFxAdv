using System;
using System.Xml;
using System.Threading.Tasks;

namespace NetLib
{
    public class Utils
    {
        public static void PrintAssemblyFullName(){
            System.Console.WriteLine(typeof(Task).Assembly.FullName);
            System.Console.WriteLine(typeof(Uri).Assembly.FullName);
            System.Console.WriteLine(typeof(XmlWriter).Assembly.FullName);
        }
    }
}
