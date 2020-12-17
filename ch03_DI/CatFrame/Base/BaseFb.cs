using System;

namespace CatFrame.Base
{
    public class BaseFb : IDisposable
    {
        public BaseFb()
            => Console.WriteLine($"Instance of {GetType().Name} is created.");

        public void Dispose()
            => Console.WriteLine($"Instance of {GetType().Name} is disposed.");
    }
}
