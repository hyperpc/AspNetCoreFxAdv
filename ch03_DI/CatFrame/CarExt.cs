using System;
using System.Linq;

namespace CatFrame
{
    public class CarExt
    {
        public static Cat Register(this Cat cat, Type from, Type to, Lifetime lifetime){
            Func<Cat, Type[], object> factory = (_, arguments)=>Create(_, to, arguments);
            cat.Register(new ServiceRegistry(from, lifetime, factory));
            return cat;
        }
        private static object Create(Cat cat, Type type, Type[] genericArguments){
            if(genericArguments.Length>0){
                type=type.MakeGenericType(genericArguments);
            }
            var constructors = type.GetConstructors();
            if(constructors.Length==0){
                throw new InvalidOperationException($"Cannot create the instance of (type) which does not have a public constructor.");
            }
            var constructor = constructors.FirstOrDefault(it => it.GetCustomAttributes(false).OfType<InjectionAttribute>().Any());
            constructor??=constructors.First();
            var parameters = constructor.GetParameters();
            if(parameters.Length==0){
                return Activator.CreateInstance(type);
            }
            var arguments = new object[parameters.Length];
            for(int index=0; index<arguments.Length; index++){
                arguments[index]=cat.GetService(parameters[index].ParameterType);
            }
            return constructor.Invoke(arguments);
        }
    }
}