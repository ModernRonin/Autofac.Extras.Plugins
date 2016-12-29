using CommonComponents;

namespace GermanPlugin
{
    public class GermanHelloWorld : AHelloWorld
    {
        public GermanHelloWorld(IHello hello, IWorld world, ISeparator separator, IFinisher finisher)
            : base(hello, world, separator, finisher) {}
        protected override string Language => "German";
    }
}