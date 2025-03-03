
using LoginRegister.Interface;


namespace LoginRegister.Service
{
    internal class StringUtils : IStringUtils
    {
        public int? ConvertToInteger(string str)
        {
            if (!int.TryParse(str, out int val))
            {
                return null;
            }
            return val;
        }
    }
}
