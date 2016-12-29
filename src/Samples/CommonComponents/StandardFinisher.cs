namespace CommonComponents
{
    public class StandardFinisher : IFinisher
    {
        public string Beautify(string rhs)
        {
            return rhs + ".";
        }
    }
}