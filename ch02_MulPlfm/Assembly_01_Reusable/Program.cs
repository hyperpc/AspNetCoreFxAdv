using System;
using System.Data;
using System.Xml;

namespace Assembly_01_Reusable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            System.Console.WriteLine(typeof(int).Assembly.FullName);
            System.Console.WriteLine(typeof(string).Assembly.FullName);
            System.Console.WriteLine(typeof(Func<>).Assembly.FullName);
            System.Console.WriteLine(typeof(XmlDocument).Assembly.FullName);
            System.Console.WriteLine(typeof(DataSet).Assembly.FullName);
        }
    }
}
