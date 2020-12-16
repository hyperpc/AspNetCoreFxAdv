using System.Diagnostics;
using System.Reflection;
using System;

namespace Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test1();
            //Test2();
            //Test3();
            //Test4();
            Console.ReadLine();
        }
        private static void Test4(){
            using(var root = new Cat().Register<IFoo, Foo>(Lifetime.Transient)
                            .Register<IBar>(_=>new Bar(), Lifetime.Self)
                            .Register<IBaz, Baz>(Lifetime.Root)
                            .Register(Assembly.GetEntryAssembly())){
                using(var cat = root.CreateChild()){
                    cat.GetService<IFoo>();
                    cat.GetService<IBar>();
                    cat.GetService<IBaz>();
                    cat.GetService<IQux>();
                    Console.WriteLine("Child cat is disposed!");
                }
                Console.WriteLine("Root cat is disposed!");
            }
        }
        private static void Test3(){
            var services = new Cat().Register<Base, Foo>(Lifetime.Transient)
                            .Register<Base, Bar>(Lifetime.Transient)
                            .Register<Base, Baz>(Lifetime.Transient)
                            .GetServices<Base>();
            
            Debug.Assert(services.OfType<Foo>().Any());
            Debug.Assert(services.OfType<Bar>().Any());
            Debug.Assert(services.OfType<Baz>().Any());
        }

        private static void Test2(){
            var cat = new Cat().Register<IFoo, Foo>(Lifetime.Transient)
                            .Register<IBar, Bar>(Lifetime.Transient)
                            .Register(typeof(IFoobar<,>), typeof(Foobar<,>), Lifetime.Transient);
            
            var foobar = (Foobar<IFoo, IBar>)cat.GetService<IFoobar<IFoo, IBar>>();
            Debug.Assert(foobar.Foo is Foo);
            Debug.Assert(foobar.Bar is Bar);
        }

        private static void Test1(){
            var root = new Cat.Register<IFoo, Foo>(Lifetime.Transient)
                            .Register<IBar>(_=>new Bar(), Lifetime.Self)
                            .Register<IBaz, Baz>(Lifetime.Root)
                            .Register(Assembly.GetEntryAssembly());
            var cat1 = root.CreateChild();
            var cat2 = root.CreateChild();

            void GetServices<TService>(Cat cat){
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
