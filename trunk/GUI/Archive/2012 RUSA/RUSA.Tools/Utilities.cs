using System;
using System.Collections.Generic;
using System.Text;
using RUSA.Tools;

namespace RUSA.Tools
{
    /// <summary>
    /// Contains some useful functions
    /// </summary>
    public class Utilities
    {
		/// <summary>
		/// Scan for, connect and return a URSA USB port instance.
		/// </summary>
		/// <param name="serialOverride">In the case of multiple dongles connected to the pc, 
		/// the method will return the first it find, use the dongle's serial to override this.
		/// Most of the time there will only by a single dongle connected so this can be ignored.
		/// </param>
		/// <returns>The port connected to the usb dongle</returns>
		public static RUSAPort CreatePort(string serialOverride = null)
		{
		    return  new RUSAPort(serialOverride) { ShowDebugInformationOnConsole = true };
		}

        public static RUSAPort CreatePort(RUSAPort.SerialMode serialMode, RUSAPort.PortName commPort, int channelId)
        {
            var newPort = new RUSAPort(serialMode) { ShowDebugInformationOnConsole = true };

            newPort.Open(commPort);

            if (!newPort.IsOpen)
            {
                return null;
            }

            newPort.SelectChannel(channelId);

            return newPort;
        }

        public static RUSAPort CreatePort(RUSAPort.SerialMode serialMode, int channelId)
        {
            return CreatePort(serialMode, RUSAPort.PortName.COM1, channelId);
        }

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
