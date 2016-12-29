using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using CommonComponents;
using EnglishPlugin;
using GermanPlugin;

namespace Net46Console
{
    class Program
    {
        static IEnumerable<Assembly> Assemblies
        {
            get
            {
                yield return typeof(CommonModule).Assembly;
                // instead of directly linking against the plugin assemblies you could also load them from the current directory
                yield return typeof(GermanModule).Assembly;
                yield return typeof(EnglishModule).Assembly;
            }
        }
        static void Main()
        {
            var log = (Action<string>) Console.WriteLine;

            log("Loading and using all plugins:");

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(Assemblies.ToArray());
            var container = builder.Build();

            var allHelloWorlds = container.Resolve<IEnumerable<IHelloWorld>>();
            foreach (var helloWorld in allHelloWorlds) { log(helloWorld.Greeting); }

            log("Press <Enter> to exit...");
            Console.ReadLine();
        }
    }
}