using System;
using System.Diagnostics;
using System.Reflection;
using System.Linq;
using CatFrame.Base;
using CatFrame.Foobar;
using CatFrame.Frame;

namespace CatFrame
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("***************InterfaceReg()**************");
            InterfaceReg();
            Console.WriteLine("***************GenericReg()**************");
            GenericReg();
            Console.WriteLine("***************BaseReg()**************");
            BaseReg();
            Console.WriteLine("***************SubContainerReg()**************");
            SubContainerReg();

            Console.ReadLine();
        }

        private static void SubContainerReg()
        {
            using (var root = new Cat()
                .Register<IFoo, Foo>(Lifetime.Transient)
                .Register<IBar>(_ => new Bar(), Lifetime.Self)
                .Register<IBaz, Baz>(Lifetime.Root)
                .Register(Assembly.GetEntryAssembly()))
            {
                using(var cat = root.CreateChild())
                {
                    cat.GetService<IFoo>();
                    cat.GetService<IBar>();
                    cat.GetService<IBaz>();
                    cat.GetService<IQux>();
                    Console.WriteLine("Child cat is disposed.");
                }
                Console.WriteLine("Root cat is disposed.");
            }
        }

        private static void BaseReg()
        {
            var services = new Cat()
                .Register<BaseFb, Foo>(Lifetime.Transient)
                .Register<BaseFb, Bar>(Lifetime.Transient)
                .Register<BaseFb, Baz>(Lifetime.Transient)
                .GetServices<BaseFb>();

            Debug.Assert(services.OfType<Foo>().Any());
            Debug.Assert(services.OfType<Bar>().Any());
            Debug.Assert(services.OfType<Baz>().Any());
        }

        private static void GenericReg()
        {
            var root = new Cat()
                .Register<IFoo, Foo>(Lifetime.Transient)
                .Register<IBar, Bar>(Lifetime.Transient)
                .Register(typeof(IFoobar<,>), typeof(Foobar<,>), Lifetime.Transient);

            var foobar = (Foobar<IFoo, IBar>)root.GetService<IFoobar<IFoo, IBar>>();
            Debug.Assert(foobar.Foo is Foo);
            Debug.Assert(foobar.Bar is Bar);
        }

        private static void InterfaceReg()
        {
            var root = new Cat()
                .Register<IFoo, Foo>(Lifetime.Transient)
                .Register<IBar>(_ => new Bar(), Lifetime.Self)
                .Register<IBaz, Baz>(Lifetime.Root)
                .Register(Assembly.GetEntryAssembly());

            var cat1 = root.CreateChild();
            var cat2 = root.CreateChild();

            void GetServices<TService>(Cat cat)
            {
                cat.GetService<TService>();
                cat.GetService<TService>();
            }

            GetServices<IFoo>(cat1);
            GetServices<IBar>(cat1);
            GetServices<IBaz>(cat1);
            GetServices<IQux>(cat1);
            Console.WriteLine();
            GetServices<IFoo>(cat2);
            GetServices<IBar>(cat2);
            GetServices<IBaz>(cat2);
            GetServices<IQux>(cat2);

        }
    }
}
