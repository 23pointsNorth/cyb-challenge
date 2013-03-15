using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ServerLib;

namespace WIFIGUIDemo
{
    public partial class LineFollowingForm : Form
    {
        int max = 0, min = 500;
        int angle = 5;
        int angle_turned = 0;
        bool calibrate = false;
        bool turn_left = false;
        public bool lineFollowing = false;
        int maxspeed = 127, minspeed = 50;

        
        Main mainForm;
        TCPClient rover;

        public LineFollowingForm(Main mForm, TCPClient theClient)
        {
            mainForm = mForm;
            rover = theClient;
            InitializeComponent();

            rover.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceivedLine_Handler);
        }


        private void DataReceivedLine_Handler(Client_Message_EventArgs e)
        {
            //Take the new data received and convert it into a more manageable format
            List<byte> NewData = e.RawMessage.ToList();

            if (NewData.Count > 3)
            {
                //Switch on the commandID set in the common.cs file
                switch (NewData[3])
                {
                    case (byte)CommandID.IRDistanceData:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            int left_value = Convert.ToUInt16(NewData[4]) + Convert.ToUInt16(NewData[5] << 8);
                            int right_value = Convert.ToUInt16(NewData[6]) + Convert.ToUInt16(NewData[7] << 8);
                            int left_motor = Convert.ToUInt16(NewData[8]) + Convert.ToUInt16(NewData[9] << 8);
                            int right_motor = Convert.ToUInt16(NewData[10]) + Convert.ToUInt16(NewData[11] << 8);

                            leftValueLabel.Text = left_value.ToString();
                            rightValueLabel.Text = right_value.ToString();

                            float ls = 0;
                            float rs = 0;

                            if (lineFollowing)
                            {
                                ls = minspeed + ((maxspeed - minspeed) * (left_value / max));
                                rs = minspeed + ((maxspeed - minspeed) * (right_value / max));

                                rover.SendData(CommandID.SetMotorsSpeed, new byte[] { (byte)ls, (byte)(rs) });
                                rover.SendData(CommandID.IRDistanceData, new byte[] { });
                            }

                            if (calibrate)
                            {
                                if (left_value > max)
                                    max = left_value;
                                if (right_value > max)
                                    max = right_value;
                                if (left_value < min)
                                    min = left_value;
                                if (right_value < min)
                                    min = right_value;
                                max_Label.Text = max.ToString();
                                min_Label.Text = min.ToString();

                                if ((angle_turned < 45) && (turn_left==false))
                                {
                                    angle_turned = angle_turned + 5;
                                    turn_Calibrate(angle);
                                    if (angle_turned == 0)
                                        calibrate = false;
                                }
                                else
                                {
                                    turn_left = true;
                                    angle = -5;
                                }

                                if ((turn_left == true) && (angle_turned > -45))
                                {
                                    angle_turned = angle_turned - 5;
                                    turn_Calibrate(angle);
                                }
                                else
                                {
                                    angle = +5;
                                    turn_left = false;
                                }

                            }
                        }));
                        break;
                }
            }
        }

        private void calibrateButton_Click(object sender, EventArgs e)
        {
            max = 0;
            min = 500;
            calibrate = true;
            turn_left = false;
            angle_turned = 5;
            turn_Calibrate(angle);
/*           for (int i = 0; i < 9; i++)
            {
                finished = false;
                turn_Degrees(angle);

                rover.SendData(CommandID.IRDistanceData, new byte[] { });
            }
            angle = -5;
            for (int i = 0; i < 18; i++)
            {
                finished = false;
                turn_Degrees(angle);
                rover.SendData(CommandID.IRDistanceData, new byte[] { });

                while (!finished) { }
            }
            angle = 5;
            
            for (int i = 0; i < 9; i++)
            {
                finished = false;
                turn_Degrees(angle);
                rover.SendData(CommandID.IRDistanceData, new byte[] { });

                while (!finished) { }
            }*/
        }

        private void turn_Calibrate(int angle)
        {
           turnTimer.Interval = (int)(Math.Abs(angle) * Main._360_TURN_COEF) / 360;
           turnTimer.Enabled = true;
           waitTimer.Enabled = true;

           int ls = Main.TURN_SPEED * Math.Sign(angle);
           int rs = -ls;

           rover.SendData(CommandID.SetMotorsSpeed, new byte[] { (byte)ls, (byte)(rs) });
        }

        private void waitTimer_Tick(object sender, EventArgs e)
        {
            rover.SendData(CommandID.IRDistanceData, new byte[] { });
            turnTimer.Enabled = false;
        }

        private void turnTimer_Tick(object sender, EventArgs e)
        {
            rover.SendData(CommandID.SetMotorsSpeed, new byte[] { 0, 0 });
            turnTimer.Enabled = false;
        }

        private void LineFollowingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            rover.OnMessageReceived -= new ClientBase.ClientMessageReceivedEvent(DataReceivedLine_Handler);
        }

        private void followLineButton_Click(object sender, EventArgs e)
        {
            lineFollowing = !lineFollowing;
            rover.SendData(CommandID.IRDistanceData, new byte[] { });
        }
    }
}
