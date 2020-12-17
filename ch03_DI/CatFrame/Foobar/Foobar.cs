using CatFrame.Base;
using CatFrame.Frame;

namespace CatFrame.Foobar
{
    public class Foo : BaseFb, IFoo { }
    public class Bar : BaseFb, IBar { }
    public class Baz : BaseFb, IBaz { }
    [MapTo(typeof(IQux), Lifetime.Root)]
    public class Qux : BaseFb, IQux { }
    public class Foobar<T1, T2> : IFoobar<T1, T2>
    {
        public IFoo Foo { get; }
        public IBar Bar { get; }
        public Foobar(IFoo foo, IBar bar)
        {
            Foo = foo;
            Bar = bar;
        }
    }
}
