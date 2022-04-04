using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFMR_CloudServer.Util
{
    public static class ASCII
    {
        public static byte ConvertToHex(byte element)
        {
            if (IsNumberic(element))
            {
                return (byte)(element - '0');
            }
            else if (IsAlphabetUpper(element))
            {
                return (byte)(element - 'A' + 10);
            }
            else if (IsAlphabetLower(element))
            {
                return (byte)(element - 'a' + 10);
            }
            else 
            {
                return 0xFF;
            }
        }
        private static bool IsNumberic(byte element)
        {
            if (element >= 48 && element <= 57)
            {
                return true;
            }
            return false;
        }
        private static bool IsAlphabetUpper(byte element)
        {
            if (element >= 65 && element <= 90)
            {
                return true;
            }
            return false;
        }
        private static bool IsAlphabetLower(byte element)
        {
            if (element >= 97 && element <= 122)
            {
                return true;
            }
            return false;
        }
    }
}
