using System;
using System.Collections.Generic;
using System.Text;

namespace URSAtools
{
    /// <summary>
    /// Contains some useful functions
    /// </summary>
    public class Utilities
    {
        /// <summary>
        /// Returns the string representation of the bytes in hex form
        /// </summary>
        /// <param name="data">A number of bytes</param>
        /// <returns>A formatted string containing the bytes in hex representation</returns>
        public static string ConvertByteArrayToString(byte[] data)
        {
            string results = "";

            foreach (byte aByte in data)
            {
                results += string.Format("{0:x2} ", aByte);
            }

            return results;
        }
    }
}
