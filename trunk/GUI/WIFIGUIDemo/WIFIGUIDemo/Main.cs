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
            this.KeyPreview = true;
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
                    string IPinput = "10.215.2.13";
                    //Subscribe to message received event
                    theClient.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceived_Handler);

                    //Connect the Client to the server based on passed data
                    //Commented lines for debugging
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

        const int MAX_SPEED = 127;
        const int MIN_SPEED = 50;


        int ENCODER_SPEED = -100;
        double LEFT_PARAM = 1.25f;
        double RIGHT_PARAM = 1.0f;
        bool activate_seq = false;
        bool initial_value = false;
        bool accel_start = false;
        int left_encoder = 0;
        int right_encoder = 0;


        int _1sec_l = 0;
        int _1sec_r = 0;

        private int to12BitConversion(int _2scomp)
        {
            int result;

            if (_2scomp < 2048)
            {
                result = _2scomp;
            }
            else
            {
                result = ~(_2scomp);
                result++;
                result &= 0xFFF;
                result = -result;
            }

            return result;
        }

        const int EDGE = 200;
        const int OFFLINE = 350;
        const int ONLINE = 30;

        /// <summary>
        /// Data received handler - when data is pushed from the rover to this program the event handler here
        /// parses the incoming data
        /// </summary>
        /// <param name="e"></param>
        /// 

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

                                if (driving)
                                {
                                    _1sec_l = le;
                                    _1sec_r = re;
                                }
                                else
                                {
                                    if (_1sec_l != 0 && _1sec_r != 0)
                                    {
                                        MessageBox.Show(_1sec_l.ToString() + " " + _1sec_r.ToString() + " : " + le.ToString() + " " + re.ToString());
                                    }
                                }

                            }));
                            break;
                        }
                    case (byte)CommandID.GetTermData:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {
                                int temp = Convert.ToUInt16(NewData[4]) + Convert.ToUInt16(NewData[5] << 8);
                                tempLabel.Text = temp.ToString();
                            }));
                            break;
                        }
                    case (byte)CommandID.GetLightAuxValue:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {
                                int light = Convert.ToUInt16(NewData[4] << 8) + Convert.ToUInt16(NewData[5]);
                                //int light = (int)((NewData[5] + NewData[4] << 8));
                                //UInt16 light = Convert.ToUInt16(NewData[5] + NewData[4] << 8);
                                int aux = Convert.ToUInt16(NewData[7]) + Convert.ToUInt16(NewData[6] << 8);
                                LightLabel.Text = light.ToString();
                                auxLabel.Text = aux.ToString();
                            }));
                            break;
                        }
                    case (byte)CommandID.GetMagnetValue:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {
                                int x = (Convert.ToUInt16(NewData[5]) +  Convert.ToUInt16(NewData[4] << 8));
                                int y = (Convert.ToUInt16(NewData[9]) +  Convert.ToUInt16(NewData[8] << 8));
                                int z = (Convert.ToUInt16(NewData[7]) +  Convert.ToUInt16(NewData[6] << 8));
                                getXlabel.Text = x.ToString();
                                getYlabel.Text = y.ToString();
                                getZlabel.Text = z.ToString();
                                xProgress.Value = x;
                                yProgress.Value = y;
                                zProgress.Value = z;  
                            }));
                            break;
                        }

                    case (byte)CommandID.GetAccelValue:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {
                                if (NewData.Count >= 10)
                                {
                                    float x = to12BitConversion((NewData[5]) + (NewData[4] << 8) >> 4);
                                    float y = to12BitConversion((NewData[7]) +  (NewData[6] << 8) >> 4);
                                    float z = to12BitConversion((NewData[9]) +  (NewData[8] << 8) >> 4);

                                    x = x / 1024;
                                    y = y / 1024;
                                    z = z / 1024;
                                    
                                    float x1 = (x * 100)+100;
                                    float y1 = (y * 100)+100;
                                    float z1 = (z * 100)+100;
                                    int xprogress = (int)(x1);
                                    int yprogress = (int)(y1);
                                    int zprogress = (int)(z1);

                                    double xsq = (x * x);
                                    double ysq = (y * y);
                                    double zsq = (z * z);

                                    double xresult = Math.Sqrt(ysq + zsq);
                                    xresult = x / xresult;
                                    double Ax = Math.Atan(xresult) * 180 / Math.PI;


                                    double yresult = Math.Sqrt(xsq + zsq);
                                    yresult = y / yresult;
                                    double Ay = Math.Atan(yresult) * 180 / Math.PI;

                                    double zresult = Math.Sqrt(xsq + ysq);
                                    zresult = z / zresult;
                                    double Az = Math.Atan(zresult) * 180 / Math.PI;

                                    x_angle.Text = Ax.ToString(".00");
                                    y_angle.Text = Ay.ToString(".00");
                                    z_angle.Text = Az.ToString(".00");

                                    accelXlabel.Text = x.ToString("0.00");
                                    accelYlabel.Text = y.ToString("0.00");
                                    accelZlabel.Text = z.ToString("0.00");

                                    //accelxProgress.Value = xprogress;
                                    //accelyProgress.Value = yprogress;
                                    //accelzProgress.Value = zprogress;
                                }
                            }));
                            break;
							}
                    case (byte)CommandID.LineFollowingData:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {
                                string thresh = null;
                                int leftval = NewData[5] + (NewData[6] << 8);
                                int rightval = NewData[7] + (NewData[8] << 8);
                                int linestatus = NewData[4];

                                leftIR.Text = leftval.ToString();
                                rightIR.Text = rightval.ToString();

                                int rs = 0;
                                int ls = 0;

                                if (follow_line)
                                {
                                    if (leftval > EDGE)
                                    {
                                        ls = (OFFLINE - leftval) / (OFFLINE - EDGE); 
                                    }
                                    else if (leftval < EDGE)
                                    {
                                        ls = (leftval - ONLINE) / (EDGE - ONLINE);
                                    }
                                    else
                                    {
                                        ls = 1;
                                    }


                                    if (rightval > EDGE)
                                    {
                                        rs = (OFFLINE - rightval) / (OFFLINE - EDGE);
                                    }
                                    else if (rightval < EDGE)
                                    {
                                        rs = (rightval - ONLINE) / (EDGE - ONLINE);
                                    }
                                    else
                                    {
                                        rs = 1;
                                    }
                                    /*
                                    if (leftval < rightval)
                                    {
                                        rs = 1;
                                        ls = (leftval / rightval);
                                    }
                                    else if (leftval > rightval)
                                    {
                                        ls = 1;
                                        rs = (rightval / leftval);
                                    }
                                    else
                                    {
                                        rs =1;
                                        ls =1;
                                    }
                                    */
                                    //MessageBox.Show(ls.ToString() + " " + rs.ToString());
                                    setMotorSpeed(MIN_SPEED + ls * (MAX_SPEED - MIN_SPEED), 
                                                 rs * (MAX_SPEED - MIN_SPEED) + MIN_SPEED);
                                    //Resend line data
                                    theClient.SendData(CommandID.LineFollowingData, new byte[] { });
                                }
                                threshLabel.Text = follow_line.ToString();
                            }));
                            break;
                        }
                    case (byte)CommandID.DriveSteps:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {
                                //MessageBox.Show("Moved!");
                            }));
                            break;
                        }
                    case (byte)CommandID.LightPositionData:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {
                                //lightTunnelForm.lightIntensityChart;
                                int light = Convert.ToUInt16(NewData[4] << 8) + Convert.ToUInt16(NewData[5]);
                                light -= 58000;
                                int le = NewData[8] + (NewData[9] << 8);
                                int re = NewData[10] + (NewData[11] << 8);
                                int avrgEncoder = (le + re) / 2;

                                lightTunnelForm.AddDataPoint(avrgEncoder, light);
                                
                            }));
                            break;
                        }
                }
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

                if (driving && _1sec_l != 0)
                {
                    setMotorSpeed(0, 0);
                    theClient.SendData(CommandID.MotorPosition, new byte[] { });
                    driving = false;
                    timer1.Enabled = false;
                }

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
                int left_speed = int.Parse(leftMotorSpeed.Text);
                int right_speed = int.Parse(rightMotorSpeed.Text);
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
                //reqInfo.Enabled = true;
                //initial_value = false;
                int distance = int.Parse(PositionStatusBox.Text);
                theClient.SendData(CommandID.DriveSteps, new byte[] { (byte)(distance), (byte)(distance >> 8) });
            }
        }

        private void leftSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                int left_speed = leftSpeed.Value;
                theClient.SendData(CommandID.SetLeftMotorSpeed, new byte[] { (byte)left_speed});
            }
        }

        private void rightSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                int right_speed = rightSpeed.Value;
                theClient.SendData(CommandID.SetRightMotorSpeed, new byte[] { (byte)right_speed });
            }
        }

        public void Main_KeyDown(object sender, KeyEventArgs e)
        {
            
            int speed_p = (e.Shift) ? 75 : 100;
            
            if (e.KeyCode.Equals(Keys.W))
            {
                forward(speed_p);
            }
            else if (e.KeyCode.Equals(Keys.S))
            {
                backwards(speed_p);
            }
            else if (e.KeyCode.Equals(Keys.A))
            {
                rotate_left(speed_p);
            }
            else if (e.KeyCode.Equals(Keys.D))
            {
                rotate_right(speed_p);
            }
            else
            {
                stop();
            }
            e.Handled = true;
        }

        bool dirSpeedMouseDown = false;
        private void directionalSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            dirSpeedMouseDown = true;
            setSpeeds(e);
            
        }

        private void directionalSpeed_MouseMove(object sender, MouseEventArgs e)
        {
            if (dirSpeedMouseDown)
            {
                setSpeeds(e);
            }
        }

        private void setSpeeds(MouseEventArgs e)
        {
            Point c = new Point(directionalSpeed.Width / 2, directionalSpeed.Height / 2);
            int power = (int)Math.Sqrt((e.Y - c.Y) * (e.Y - c.Y) + (e.X - c.X) * (e.X - c.X));
            double alpha = Math.Atan2(e.X - c.X, e.Y - c.Y) + Math.PI;
            if (alpha < 0) alpha += 2*Math.PI;
            if (alpha > 2*Math.PI) alpha -= 2*Math.PI;

            //MessageBox.Show(alpha.ToString());
            int left_speed = 0;
            int right_speed = 0; 
            if (alpha >= 0 && alpha < Math.PI / 2)
            {
                right_speed = MAX_SPEED * 1; // scale with power
                left_speed =(int) ((1 - ((double)(4.0 * alpha) / Math.PI)) * MAX_SPEED*1);
                //MessageBox.Show(left_speed.ToString() + " " + alpha.ToString());
            }
            else if (alpha >= Math.PI / 2 && alpha < Math.PI)
            {
                right_speed = (int)(3 - 4*alpha / Math.PI) * MAX_SPEED * 1; // scale with power
                left_speed = -1 * MAX_SPEED * 1;
            }
            else if (alpha >= Math.PI && alpha < 3 * Math.PI/2)
            {
                right_speed = -1 * MAX_SPEED * 1;
                left_speed = (int)((-3 + ((double)(4.0 * alpha) / Math.PI)) * MAX_SPEED * 1);
            }
            else if (alpha >= 3* Math.PI/2 && alpha < 2 * Math.PI)
            {
                right_speed = (int)((-5 + ((double)(4.0 * alpha) / Math.PI)) * MAX_SPEED * 1);
                left_speed = 1 * MAX_SPEED * 1;
            }

            //Draw line
            Bitmap img = new Bitmap(256, 256);
            using (System.Drawing.Graphics g = Graphics.FromImage(img))
            {
                Pen p = new Pen(System.Drawing.Color.Red, 2);

                g.DrawLine(p, e.Location, new Point(directionalSpeed.Width / 2, directionalSpeed.Height / 2));
            }
            directionalSpeed.Image = (Image)img;
            setMotorSpeed(left_speed, right_speed);
        }

        private void setMotorSpeed(int left, int right)
        {
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.SetMotorsSpeed, new byte[] { (byte)(left), (byte)(right) });
            }
        }

        private void directionalSpeed_MouseUp(object sender, MouseEventArgs e)
        {
            dirSpeedMouseDown = false;
            theClient.SendData(CommandID.SetMotorsSpeed, new byte[] { 0, 0 });
            Bitmap img = new Bitmap(256, 256);
            directionalSpeed.Image = (Image)img;
        }

        private void tempButton_Click(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.GetTermData, new byte[] {});
            }
        }

        private void lightLuxButton_Click(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.GetLightAuxValue, new byte[] { });
            }
        }

        bool driving = false;
        private void drive1secButton_Click(object sender, EventArgs e)
        {
            theClient.SendData(CommandID.MotorPosition, new byte[] { });
            setMotorSpeed(80, 80);
            timer1.Enabled = true;
            driving = true;
        }

        // change here 
        bool follow_line = false;
        private void lineData_Click(object sender, EventArgs e)
        {
            theClient.SendData(CommandID.LineFollowingData, new byte[] { });

            follow_line = !follow_line;
            if (!follow_line) setMotorSpeed(0, 0);
        }

        private void Main_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Moved to key down
        }

        const int speed = 120;
        private void forward(int speed_percentage)
        {
            if (theClient.isConnected)
            {
                int right_speed = (speed * speed_percentage)/100;
                int left_speed = (speed * speed_percentage)/100;
                setMotorSpeed(left_speed, right_speed);
            }
        }

        private void backwards(int speed_percentage)
        {
            if (theClient.isConnected)
            {
                int right_speed = -(speed * speed_percentage) / 100;
                int left_speed = -(speed * speed_percentage) / 100;
                setMotorSpeed(left_speed, right_speed);
            }
        }

        private void rotate_left(int speed_percentage)
        {
            if (theClient.isConnected)
            {
                int right_speed = (speed * speed_percentage) / 100;
                int left_speed = -(speed * speed_percentage) / 100;
                setMotorSpeed(left_speed, right_speed);
            }
        }

        private void rotate_right(int speed_percentage)
        {
            if (theClient.isConnected)
            {
                int right_speed = -(speed * speed_percentage) / 100;
                int left_speed = (speed * speed_percentage) / 100;
                setMotorSpeed(left_speed, right_speed);
            }
        }

        private void stop()
        {
            if (theClient.isConnected)
            {
                setMotorSpeed(0, 0);
            }
        }

        private void motoPositionTimer_Tick(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.MotorPosition, new byte[] { });
            }
        }

        private void motorPositionButton_Click(object sender, EventArgs e)
        {
            motoPositionTimer.Enabled = true;
        }

        public void Main_KeyUp(object sender, KeyEventArgs e)
        {
            stop();
        }

        private void getMagnet_Click(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.GetMagnetValue, new byte[] { });
            }
        }

        private void getAccelerometer_Click(object sender, EventArgs e)
        {
            if (theClient.isConnected)      //Starts the timer when clicked to refresh accel data
            {                               //Or stops it if it is running.
                theClient.SendData(CommandID.GetAccelValue, new byte[] { });    
                if (accel_start == false)
                {
                    accel_start = true;
                    accelTimer.Start();
                }
                else
                {
                    accel_start = false;
                    accelTimer.Stop();
                }
            }
        }

        private void accelTimer_Tick(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                theClient.SendData(CommandID.GetAccelValue, new byte[] { });    //Refreshe accel data when required.
            }
        }

        private void servoTrackBar_ValueChanged(object sender, EventArgs e)
        {
            if (theClient.isConnected)
            {
                //send new servo postion
                int pos = servoTrackBar.Value;
                //if (pos < 128) pos = - pos;
                //else pos = 255 - pos;
                pos = pos - 128;
                theClient.SendData(CommandID.SetServoPosition, new byte[] { (byte)pos });
            }
        }

        LightTunnel lightTunnelForm;
        private void lightTunnelButton_Click(object sender, EventArgs e)
        {
            lightTunnelForm = new LightTunnel(theClient, this);
            lightTunnelForm.Show();
        }

        RiverBedForm riverBedForm;
        private void riverBedButton_Click(object sender, EventArgs e)
        {
            riverBedForm = new RiverBedForm(this, theClient);
            riverBedForm.Show();
        }
    }
}
