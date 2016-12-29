using Autofac;
using Autofac.Extras.Plugins;
using CommonComponents;

namespace GermanPlugin
{
    public class GermanModule : Module
    {
        const string Key = "GermanPlugin";
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<GermanHelloWorld>().AsPlugin().Provide<IHelloWorld>(Key);
            builder.RegisterType<GermanHello>().AsPlugin().Provide<IHello>(Key);
            builder.RegisterType<GermanWorld>().AsPlugin().Provide<IWorld>(Key);
            builder.RegisterType<GermanSeparator>().AsPlugin().Provide<ISeparator>(Key);
            builder.RegisterType<GermanFinisher>().AsPlugin().Override<IFinisher>(Key);
        }
    }
}