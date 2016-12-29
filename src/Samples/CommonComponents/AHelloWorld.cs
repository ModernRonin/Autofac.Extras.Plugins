namespace CommonComponents
{
    public abstract class AHelloWorld : IHelloWorld
    {
        readonly IFinisher mFinisher;
        readonly IHello mHello;
        readonly ISeparator mSeparator;
        readonly IWorld mWorld;
        protected AHelloWorld(IHello hello, IWorld world, ISeparator separator, IFinisher finisher)
        {
            mHello = hello;
            mWorld = world;
            mSeparator = separator;
            mFinisher = finisher;
        }
        protected abstract string Language { get; }
        public string Greeting
        {
            get
            {
                var parts = new[] {mHello.Hello, mWorld.World};
                var greeting = mFinisher.Beautify(mSeparator.Separate(parts));
                return $"In {Language} the greeting looks like this:\r\n{greeting}";
            }
        }
    }
}