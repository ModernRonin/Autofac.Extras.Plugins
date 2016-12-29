using Autofac;
using Autofac.Extras.Plugins;

namespace CommonComponents
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StandardFinisher>().AsPlugin().ProvideForAll<IFinisher>();
        }
    }
}