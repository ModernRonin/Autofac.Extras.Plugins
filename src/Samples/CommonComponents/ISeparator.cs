using System.Collections.Generic;

namespace CommonComponents
{
    public interface ISeparator
    {
        string Separate(IEnumerable<string> parts);
    }
}