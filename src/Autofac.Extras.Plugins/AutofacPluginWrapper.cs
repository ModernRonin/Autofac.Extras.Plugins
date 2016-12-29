using System;
using System.Reflection;
using Autofac.Builder;

namespace Autofac.Extras.Plugins
{
    public class AutofacPluginWrapper<TImplementation>
    {
        const string CommonKey = "Common";
        readonly IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            mBuilder;
        public AutofacPluginWrapper(
            IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> builder)
        {
            mBuilder = builder;
        }
        public IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> Provide(
            string pluginKey)
        {
            return mBuilder.AsSelf()
                .Keyed<TImplementation>(pluginKey)
                .WithParameter(ParameterSelector, ValueProviderFactory(pluginKey));
        }
        public IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> Provide
            <TInterface>(string pluginKey)
        {
            return mBuilder.AsSelf()
                .As<TInterface>()
                .Keyed<TInterface>(pluginKey)
                .WithParameter(ParameterSelector, ValueProviderFactory(pluginKey));
        }
        public IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> Override(
            string pluginKey) => Provide(MakeOverrideKey(pluginKey));
        public IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> Override
            <TInterface>(string pluginKey) => Provide<TInterface>(MakeOverrideKey(pluginKey));
        public IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ProvideForAll() => Provide(CommonKey);
        public IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle>
            ProvideForAll<TInterface>() => Provide<TInterface>(CommonKey);
        static string MakeOverrideKey(string pluginKey)
        {
            return $"{pluginKey}Override";
        }
        static bool ParameterSelector(ParameterInfo parameterInfo, IComponentContext componentContext) => true;
        static Func<ParameterInfo, IComponentContext, object> ValueProviderFactory(string specificKey)
        {
            return ValueProviderFactory(specificKey, $"{specificKey}Override", CommonKey);
        }
        static Func<ParameterInfo, IComponentContext, object> ValueProviderFactory(
            string specificKey,
            string overrideKey,
            string commonKey)
        {
            return (parameter, context) =>
            {
                var type = parameter.ParameterType;
                if (context.IsRegisteredWithKey(specificKey, type)) return context.ResolveKeyed(specificKey, type);
                if (context.IsRegisteredWithKey(overrideKey, type)) return context.ResolveKeyed(overrideKey, type);
                if (context.IsRegisteredWithKey(commonKey, type)) return context.ResolveKeyed(commonKey, type);
                return context.Resolve(type);
            };
        }
    }
}