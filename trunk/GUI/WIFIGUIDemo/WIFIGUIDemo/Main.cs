﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using ServerLib;

namespace WIFIGUIDemo
{
    public partial class Main : Form
    {
        #region PRIVATE DATA MEMBERS
        //variable to use inputDialog box
        bool useDialog = true;

        //TCP Client variable from 
        TCPClient theClient;
        #endregion



        /// <summary>
        /// Main Form Constructor
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Main Form entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            theClient = new TCPClient();

            if (useDialog)
            {
                //On program entry open dialog box to enter IP Address
                /*inputDialog IPinput = new inputDialog();
                IPinput.ShowDialog();
                */
                try
                {
                    string IPinput = "10.215.2.15";
                    //Subscribe to message received event
                    theClient.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceived_Handler);

                    //Connect the Client to the server based on passed data
                    theClient.ConnectToServer(IPinput, 9760);

                    //Set the appropriate form elements
                    txtIPAddress.Text = IPinput;
                    txtPort.Text = "9760";

                    //Disable appropriate button and enable others
                    cmdConnect.Enabled = false;
                    cmdDisconnect.Enabled = true;
                }
                catch
                {
                    //Show a messagebox to the user saying that the program was unable to connect to the specified rover
                    MessageBox.Show("Unable to connect to Rover Server");

                    //Disable appropriate form elements and enable others
                    cmdConnect.Enabled = true;
                    cmdDisconnect.Enabled = false;
                    txtIPAddress.Enabled = true;
                    txtPort.Enabled = true;
                }
            }
            else
            {
                //Set appropriate form elements
                cmdConnect.Enabled = true;
                cmdDisconnect.Enabled = false;
                txtIPAddress.Enabled = true;
                txtPort.Enabled = true;
            }
        }

        /// <summary>
        /// Data received handler - when data is pushed from the rover to this program the event handler here
        /// parses the incoming data
        /// </summary>
        /// <param name="e"></param>
        /// 

        int ENCODER_SPEED = -100;
        double LEFT_PARAM = 1;
        double RIGHT_PARAM = 1.05f;
        bool activate_seq = false;
        bool initial_value = false;
        int left_encoder = 0;
        int right_encoder = 0;

        private void DataReceived_Handler(Client_Message_EventArgs e)
        {
            //Take the new data received and convert it into a more manageable format
            List<byte> NewData = e.RawMessage.ToList();

            if (NewData.Count > 3)
            {
                //Switch on the commandID set in the common.cs file
                switch (NewData[3])
                {
                    case (byte)CommandID.NullEcho:
                        break;
                    //If internal counter byte received
                    case (byte)CommandID.InternalCounter:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            txtCounter.Text = (NewData[4] + (NewData[5] << 8)).ToString();
                        }));
                        break;
                    //Command ID byte to show the switch and LED current status
                    case (byte)CommandID.SwitchLEDStatus:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            chkSwitch1Stat.Checked = ((NewData[4] & 0x01) == 0x01) ? true : false;
                            chkSwitch2Stat.Checked = ((NewData[4] & 0x02) == 0x02) ? true : false;
                            chkGreenStat.Checked = ((NewData[4] & 0x10) != 0x10) ? true : false;
                            chkRedStat.Checked = ((NewData[4] & 0x20) != 0x20) ? true : false;
                        }));
                        break;
                    case (byte)CommandID.MotorPosition:
                        {//Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                            {
                                /*PositionStatusBox.Text = NewData[4].ToString() + " " + // 256 - Speed //Left
                                     NewData[5].ToString() + " " + //Encoder lower part
                                     NewData[6].ToString() + " " + //Encoder upper
                                     NewData[7].ToString() + " " + // 256 - Speed // Right
                                     NewData[8].ToString() + " " + // lower encoder
                                     NewData[9].ToString();         // upper
                                */
                                int le = NewData[5] + (NewData[6] << 8);
                                int re = NewData[8] + (NewData[9] << 8);

                                leftEncoderLabel.Text = le.ToString();
                                rightEncoderLabel.Text = re.ToString();

                                if (!initial_value)
                                {
                                    left_encoder = NewData[5] + (NewData[6] << 8);
                                    right_encoder = NewData[8] + (NewData[9] << 8);
                                    initial_value = true;
                                    theClient.SendData(CommandID.SetMotorsSpeed,
                                        new byte[] { (byte)(ENCODER_SPEED * LEFT_PARAM), (byte)(ENCODER_SPEED * RIGHT_PARAM)});
                                }

                                if ((Math.Abs(left_encoder - le) >= int.Parse(PositionStatusBox.Text)) ||
                                    (Math.Abs(right_encoder - re) >= int.Parse(PositionStatusBox.Text)))
                                {
                                    theClient.SendData(CommandID.SetMotorsSpeed,
                                        new byte[] { 0, 0 });
                                    initial_value = false;
                                    reqInfo.Enabled = false;
                                }
                            }));
                            break;
                        }
                }
               /* if (NewData[3] == (byte)CommandID.SwitchLEDStatus)
                {
                    bool switch1 = ((NewData[4] & 0x01) == 0x01) ? true : false;
                    activate_seq = switch1;
                    idx = 0;

                }*/
            }
        }
       
        #region FORM CONTROL EVENT FUNCTIONS
        /// <summary>
        /// Connection function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            //assuming the client isn't already connected
            //if the client isn't connected an error will be thrown as no socket will be available
            if (!theClient.isConnected)
            {
                //then connect it using the parameters in the textbox
                theClient.ConnectToServer(txtIPAddress.Text, Convert.ToInt32(txtPort.Text));

                cmdConnect.Enabled = false;
                cmdDisconnect.Enabled = true;
            }
        }


        /// <summary>
        /// Disconnection function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdDisconnect_Click(object sender, EventArgs e)
        {
            if(theClient.isConnected)
                theClient.Disconnect();

            cmdConnect.Enabled = true;
            cmdDisconnect.Enabled = false;

            txtIPAddress.Enabled = true;
        }

        /// <summary>
        /// Function that is called when the Set LED button is pressed
        /// this sends the corresponding command ID to the rover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSetLEDs_Click(object sender, EventArgs e)
        {
            byte LEDs = 0;

            //If statement to check if the client is connected to a rover
            if (theClient.isConnected)
            {
                if (chkGreen.Checked) { LEDs |= 0x01; }
                if (chkRed.Checked) { LEDs |= 0x02; }

                theClient.SendData(CommandID.SetLEDs, new byte[] { LEDs });
            }
        }

        /// <summary>
        /// Function that is called when the Internal counter button is pressed
        /// this sends the corresponding command ID to the rover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cmdGetCount_Click(object sender, EventArgs e)
        {
            //If statement to check if the client is connected to a rover
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.InternalCounter, new byte[] { });
            }            
        }

        /// <summary>
        /// Function that is called when the LEDSwitch status packet button is pressed
        /// this sends the corresponding command ID to the rover
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdSwitchLedStatus_Click(object sender, EventArgs e)
        {
            //If statement to check if the client is connected to a rover
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.SwitchLEDStatus, new byte[] { });
            }
        }
        #endregion

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (theClient.isConnected)
                theClient.Disconnect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.InternalCounter, new byte[] { });
            }   
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //Ask for encoder values
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.MotorPosition, new byte[] { });
            }
        }

        private void setSpeed_Click(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                int left_speed = - int.Parse(leftMotorSpeed.Text);
                int right_speed = - int.Parse(rightMotorSpeed.Text);
                theClient.SendData(CommandID.SetMotorsSpeed, new byte[] { (byte)left_speed, (byte)right_speed });
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                leftMotorSpeed.Text = "0";
                rightMotorSpeed.Text = "0";
                theClient.SendData(CommandID.SetMotorsSpeed, new byte[] { 0, 0 });
            }
        }

        private void encoderValueButton_Click(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                reqInfo.Enabled = true;
                initial_value = false;
            }
        }

        private void leftSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                int left_speed = -leftSpeed.Value;
                theClient.SendData(CommandID.SetLeftMotorSpeed, new byte[] { (byte)left_speed});
            }
        }

        private void rightSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                int right_speed = -rightSpeed.Value;
                theClient.SendData(CommandID.SetRightMotorSpeed, new byte[] { (byte)right_speed });
            }
        }

        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            MessageBox.Show(e.KeyValue.ToString());
            if (e.KeyValue == (int)'a')
            {
                if (theClient.isConnected)
                {
                    int right_speed = -120;
                    theClient.SendData(CommandID.SetMotorsSpeed, new byte[] { (byte)right_speed, (byte)right_speed });
                }
            }
        }
    }
}
