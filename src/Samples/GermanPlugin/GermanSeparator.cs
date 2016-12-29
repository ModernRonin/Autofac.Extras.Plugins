using System.Collections.Generic;
using CommonComponents;

namespace GermanPlugin
{
    public class GermanSeparator : ISeparator
    {
        public string Separate(IEnumerable<string> parts)
        {
            return string.Join(", ", parts);
        }
    }
}