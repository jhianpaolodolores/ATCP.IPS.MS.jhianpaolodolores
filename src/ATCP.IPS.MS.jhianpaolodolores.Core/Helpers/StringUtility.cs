using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATCP.IPS.MS.jhianpaolodolores.Core.Helpers
{
    public static class StringUtility
    {
        public static string Concatenate(string s1, string s2, string delimiter)
        {
            string returnVal;
            if (string.IsNullOrEmpty(delimiter))
            {
                returnVal = $"{s1} {s2}";
            }
            else
            {
                returnVal = $"{s2}{delimiter} {s1}";
            }
            return returnVal;
        }
    }
}
