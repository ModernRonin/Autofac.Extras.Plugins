using CommonComponents;

namespace EnglishPlugin
{
    public class EnglishHelloWorld : AHelloWorld
    {
        public EnglishHelloWorld(IHello hello, IWorld world, ISeparator separator, IFinisher finisher)
            : base(hello, world, separator, finisher) {}
        protected override string Language => "English";
    }
}