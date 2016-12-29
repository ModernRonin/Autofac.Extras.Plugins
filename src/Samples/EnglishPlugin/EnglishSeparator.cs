using System.Collections.Generic;
using CommonComponents;

namespace EnglishPlugin
{
    public class EnglishSeparator : ISeparator
    {
        public string Separate(IEnumerable<string> parts) => string.Join(" ", parts);
    }
}