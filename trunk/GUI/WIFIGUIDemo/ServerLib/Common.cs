﻿using System;
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
        InternalCounter = 0x03,
        MotorPosition = 0x04,
        SetLeftMotorSpeed = 0x05,
        SetRightMotorSpeed = 0x06,
        SetMotorsSpeed = 0x07,
        LineFollowingData = 0x08,
        SetLineThresholds = 0x09,
        GetLightAuxValue = 0x11,
        SetServoPosition = 0x17,
        GetTermData = 0x1B,
        GetCrashedRoverData = 0x1C,
        GetMagnetValue= 0x2D,
        GetAccelValue=0x28,
        DriveSteps = 0x80,
        LightPositionData = 0x81,
        IRDistanceData = 0x82,
        IRDataBuffer = 0x83,
        AutomaticIRBuffer = 0x84,
        AutomaticAccelBuffer = 0x85,
        AccDATABuffer = 0x86,
        AccDATABufferPacket = 0x87
    };
}
