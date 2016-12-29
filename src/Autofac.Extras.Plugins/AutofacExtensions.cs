using Autofac.Builder;

namespace Autofac.Extras.Plugins
{
    public static class AutofacExtensions
    {
        public static IRegistrationBuilder<TImplementation, SimpleActivatorData, SingleRegistrationStyle> AsPlugin
            <TImplementation>(
            this IRegistrationBuilder<TImplementation, SimpleActivatorData, SingleRegistrationStyle> self,
            string pluginKey)
        {
            return self.Keyed<TImplementation>(pluginKey);
        }
        public static AutofacPluginWrapper<TImplementation> AsPlugin<TImplementation>(
            this IRegistrationBuilder<TImplementation, ConcreteReflectionActivatorData, SingleRegistrationStyle> self)
        {
            return new AutofacPluginWrapper<TImplementation>(self);
        }
    }
}