using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Program
    {
        public static void Main()
        {
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(builder => builder.Configure(app => app
                    .Map("/foo", Foo)
                    .Map("/bar", Bar)
                    .Map("/baz", Baz)))
                .Build()
                .Run();

            static void Foo(IApplicationBuilder app) => app.Run(context => context.Response.WriteAsync("Endpoint foo is selected."));
            static void Bar(IApplicationBuilder app) => app.Run(context => context.Response.WriteAsync("Endpoint bar is selected."));
            static void Baz(IApplicationBuilder app) => app.Run(context => context.Response.WriteAsync("Endpoint baz is selected."));
        }
    }
}
