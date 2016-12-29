namespace Autofac.Extras.Plugins
{
    public class AutoTypedParameter : TypedParameter
    {
        public AutoTypedParameter(object value) : base(value.GetType(), value) {}
    }
}