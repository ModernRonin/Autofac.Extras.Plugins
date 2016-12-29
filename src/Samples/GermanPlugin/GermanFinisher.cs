using CommonComponents;

namespace GermanPlugin
{
    public class GermanFinisher :IFinisher
    {
        public string Beautify(string rhs)
        {
            return rhs + "!";
        }
    }
}