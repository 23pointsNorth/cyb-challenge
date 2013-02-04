using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.IO.Ports;
using System.Threading;

using FTD2XX_NET;

namespace URSAtools.Comms
{

    /// <summary>
    /// An FTDI device wrapper to handle communications between PC and URSA dongle
    /// </summary>
    public partial class URSAport
    {
        #region myVariables
        FTDI myDevice = null;

        Thread myRXthread = null;
        bool myRXthreadTerminated = false;

        Queue<byte> myRXqueue = new Queue<byte>();

        bool _getHeader = true;
        bool _getRest = false;
        byte _getExpectedBytes = 0;
        
        bool _debug = false;
        #endregion

        /// <summary>
        /// Default constructor. Don't forget to assign ReceiveMessage eventhandler
        /// </summary>
        public URSAport()
        {
            myDevice = new FTDI();
        }

        /// <summary>
        /// Just in case we can catch out the unended thread..
        /// </summary>
        ~URSAport()
        {
            this.Close();   //just in case this wasn't done properly
        }

        /// <summary>
        /// Returns true if the device is opened already, false otherwise
        /// </summary>
        public bool isOpen
        {
            get { if (myDevice != null) return myDevice.IsOpen; else return false; }
        }

        /// <summary>
        /// Enable this property to get console output of raw incoming bytes from the Dongle
        /// </summary>
        public bool showDebugInformationOnConsole
        {
            get { return _debug; }
            set { _debug = value; }
        }

        /// <summary>
        /// Discover all FTDI devices attached to the computer
        /// </summary>
        /// <returns>Array of device descriptions</returns>
        public static FTDI_DEVICE_INFO_NODE[] ListDevices()
        {
            FTDI myFtdiDevice = new FTDI();
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
            UInt32 ftdiDeviceCount = 0;
            List<FTDI_DEVICE_INFO_NODE> lstDevices = new List<FTDI_DEVICE_INFO_NODE>();

            // Determine the number of FTDI devices connected to the machine
            ftStatus = myFtdiDevice.GetNumberOfDevices(ref ftdiDeviceCount);
            // Check status
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                throw new Exception("Error occured in URSAport: " + Enum.GetName(typeof(FTDI.FT_STATUS), ftStatus));
            }

            if (ftdiDeviceCount > 0)
            {
                FTDI.FT_DEVICE_INFO_NODE[] ftdiDeviceList = new FTDI.FT_DEVICE_INFO_NODE[ftdiDeviceCount];

                ftStatus = myFtdiDevice.GetDeviceList(ftdiDeviceList);

                if (ftStatus == FTDI.FT_STATUS.FT_OK)
                {
                    for (UInt32 i = 0; i < ftdiDeviceCount; i++)
                    {
                        FTDI_DEVICE_INFO_NODE aNode = new FTDI_DEVICE_INFO_NODE();
                        aNode.Flags = ftdiDeviceList[i].Flags;
                        aNode.Type = ftdiDeviceList[i].Type.ToString();
                        aNode.ID = ftdiDeviceList[i].ID;
                        aNode.LocID = ftdiDeviceList[i].LocId;
                        aNode.SerialNumber = ftdiDeviceList[i].SerialNumber;
                        aNode.Description = ftdiDeviceList[i].Description;
                        lstDevices.Add(aNode);
                    }
                }

            }


            return lstDevices.ToArray();
        }


        /// <summary>
        /// Send a message to the processor board with payload
        /// </summary>
        /// <param name="CommandByte">Command byte</param>
        /// <param name="Payload">Array of payload bytes</param>
        /// <param name="numBytesToSendFromPayload">Number of items to send from the payload array</param>
        public void SendData(byte CommandByte, byte[] Payload, byte numBytesToSendFromPayload)
        {
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
            UInt32 numBytesWritten = 0;

            if ((3 + numBytesToSendFromPayload) > 99) throw new Exception("Error occured in URSAport: Cannot send a message over 99 bytes in length.");
            
            byte[] toSend = new byte[numBytesToSendFromPayload + 3];
            toSend[0] = 0xFF;                           //header
            toSend[1] = (byte)(numBytesToSendFromPayload + 1);  //payload length
            toSend[2] = CommandByte;                    //command

            for (int i = 0; i < numBytesToSendFromPayload; i++) toSend[3 + i] = Payload[i];

            // Note that the Write method is overloaded, so can write string or byte array data
            ftStatus = myDevice.Write(toSend, numBytesToSendFromPayload+3, ref numBytesWritten);
            if ((ftStatus != FTDI.FT_STATUS.FT_OK) || (numBytesWritten != (numBytesToSendFromPayload+3)))
            {
                throw new Exception("Error occured in URSAport: " + Enum.GetName(typeof(FTDI.FT_STATUS), ftStatus));
            }
        }

        /// <summary>
        /// Send a message to the processor board with exact payload array
        /// </summary>
        /// <param name="CommandByte"></param>
        /// <param name="Payload"></param>
        public void SendData(byte CommandByte, byte[] Payload)
        {
            if (Payload.Length > 254) throw new Exception("Error occured in URSAport: the Payload argument is too large");
            SendData(CommandByte, Payload, (byte)Payload.Length);
        }

        /// <summary>
        /// Send a message to the processor board without a payload
        /// </summary>
        /// <param name="CommandByte">Command byte</param>
        public void SendData(byte CommandByte)
        {
            SendData(CommandByte, new byte[] { }, 0);
        }

        /// <summary>
        /// Open the communications to a specific device. Use the ListDevices function to discover available devices
        /// </summary>
        /// <param name="SerialNumber">The serial number of the FTDI device to connect to</param>
        public void OpenBySerialNumber(string SerialNumber)
        {
            if (myDevice != null) if (myDevice.IsOpen) 
                throw new Exception("Error occured in URSAport: The device is already open");

            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;

            ftStatus = myDevice.OpenBySerialNumber(SerialNumber);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                throw new Exception("Error occured in URSAport: " + Enum.GetName(typeof(FTDI.FT_STATUS), ftStatus));
            }

            ftStatus = myDevice.SetBaudRate(4800);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                myDevice.Close();
                throw new Exception("Error occured in URSAport: " + Enum.GetName(typeof(FTDI.FT_STATUS), ftStatus));
            }

            // Set data characteristics - Data bits, Stop bits, Parity
            ftStatus = myDevice.SetDataCharacteristics(FTDI.FT_DATA_BITS.FT_BITS_8, FTDI.FT_STOP_BITS.FT_STOP_BITS_1, FTDI.FT_PARITY.FT_PARITY_NONE);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                myDevice.Close();
                throw new Exception("Error occured in URSAport: " + Enum.GetName(typeof(FTDI.FT_STATUS), ftStatus));
            }

            // Set flow control - set RTS/CTS flow control
            ftStatus = myDevice.SetFlowControl(FTDI.FT_FLOW_CONTROL.FT_FLOW_NONE, 0x11, 0x13);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                myDevice.Close();
                throw new Exception("Error occured in URSAport: " + Enum.GetName(typeof(FTDI.FT_STATUS), ftStatus));
            }

            // Set read timeout to 5 seconds, write timeout to infinite
            ftStatus = myDevice.SetTimeouts(1000, 0);
            if (ftStatus != FTDI.FT_STATUS.FT_OK)
            {
                myDevice.Close();
                throw new Exception("Error occured in URSAport: " + Enum.GetName(typeof(FTDI.FT_STATUS), ftStatus));
            }

            //we were successful, so start reading thread to process incoming bytes
            myDevice.Purge(FTDI.FT_PURGE.FT_PURGE_RX);              //empty the incoming bytes buffer

            myRXthreadTerminated = false;
            myRXthread = new Thread(new ThreadStart(rxThread));
            myRXthread.Start();

        }

        /// <summary>
        /// Closes an open communication port
        /// </summary>
        public void Close()
        {
            if (myRXthread != null)
            {
                myRXthreadTerminated = true;            //signal the RX thread to stop
                if (myRXthread.ThreadState != System.Threading.ThreadState.Stopped) myRXthread.Join();                      //wait for the thread to die
                if (myRXthread.ThreadState == System.Threading.ThreadState.Stopped) myRXthread = null;
            }
            if (myDevice != null) if (myDevice.IsOpen) myDevice.Close();
        }

        private void rxThread()
        {
            FTDI.FT_STATUS ftStatus = FTDI.FT_STATUS.FT_OK;
            UInt32 numBytesAvailable = 0;
            UInt32 numBytesRead = 0;
            byte[] readData = new byte[255];


            while (!myRXthreadTerminated && myDevice.IsOpen)       //until we're interrupted
            {
                ftStatus = myDevice.GetRxBytesAvailable(ref numBytesAvailable);
                if (ftStatus != FTDI.FT_STATUS.FT_OK)
                {
                    // Wait for a key press
                    myRXthreadTerminated = true;
                    myDevice.Close();

                    System.Windows.Forms.MessageBox.Show("URSAport: Failed to communicate with the device (error code: "+ ftStatus.ToString() +")");
                    //Try to handle things more carefully
                    //throw new Exception("URSAport: Failed to get number of bytes available to read (error " + ftStatus.ToString() + ")");
                }

                if (numBytesAvailable > 0)
                {
                    ftStatus = myDevice.Read(readData, numBytesAvailable, ref numBytesRead);
                    if (numBytesRead > 0)
                        for (int i = 0; i < numBytesRead; i++) processBytes(readData[i]);
                }
                Thread.Sleep(1);
            }
        }

        private void processBytes(byte p)
        {
            if (_getHeader && !_getRest)
            {
                if (_debug) Console.Write("\n");

                if (p == 255) _getRest = true;
                myRXqueue.Clear();
            } else
                if (_getHeader && _getRest)
                {
                    _getExpectedBytes = p;
                    _getHeader = false;
                } else
                    if (_getRest)
                    {
                        myRXqueue.Enqueue(p);

                        if (myRXqueue.Count == _getExpectedBytes)
                        {
                            _getRest = false; _getHeader = true;
                            
                            //fire event
                            FireMessageReceived(myRXqueue.ToArray());

                        } else
                            if (myRXqueue.Count > _getExpectedBytes)
                            {
                                //there was an error, so lets do header only
                                _getRest = false; _getHeader = true;
                            }
                    }

            if (_debug) Console.Write(string.Format("{0:x2}", p));
        }

        /// <summary>
        /// EventHandler for the MessageReceived event
        /// </summary>
        /// <param name="sender">Reference to the instance of URSAport</param>
        /// <param name="message">Payload of the message 0-RSSI, 1-Type, 2->payload</param>
        public delegate void MessageReceivedHandler(object sender, byte[] message);
        /// <summary>
        /// This event is fired when a complete message has been received from the URSA dongle
        /// </summary>
        public event MessageReceivedHandler onMessageReceived;
        /// <summary>
        /// Function to call in order to fire the event
        /// </summary>
        /// <param name="data"></param>
        protected virtual void FireMessageReceived(byte[] data)
        {
            if (onMessageReceived != null)
                onMessageReceived(this, data);
        }
 
    }


    /// <summary>
    /// Structure which holds FTDI Device relevant information
    /// </summary>
    public struct FTDI_DEVICE_INFO_NODE
    {
        /// <summary>
        /// Device Flags - refer to the FTDI user manual for further information
        /// </summary>
        public uint Flags;
        /// <summary>
        /// Device type - the Name of the FTDI device
        /// </summary>
        public string Type;
        /// <summary>
        /// Device ID
        /// </summary>
        public uint ID;
        /// <summary>
        /// Device's USB LocationID
        /// </summary>
        public uint LocID;
        /// <summary>
        /// Device's SerialNumber, unique to each device
        /// </summary>
        public string SerialNumber;
        /// <summary>
        /// Device Description
        /// </summary>
        public string Description;
    }

}
