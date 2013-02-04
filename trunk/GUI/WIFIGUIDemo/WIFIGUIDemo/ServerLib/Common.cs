using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerLib
{
    /// <summary>
    /// Public enumerable containing information about packet headers
    /// </summary>
    public enum CommandID : int
    {
        NullEcho = 0x00,
        SwitchLEDStatus = 0x01,
        SetLEDs = 0x02,
        InternalCounter = 0x03
    };
}
