
using LoginRegister.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
