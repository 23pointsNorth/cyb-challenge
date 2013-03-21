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
        int max = int.MinValue;
        int min = int.MaxValue;

        double RANGE_COEF = 0.3;
        
        int ABS_ANGLE_VALUE = 3;
        int STEPS = 3;

        int angle;
        int angle_turned = 0;
        bool calibrate = false;
        bool turn_left = false;
        bool turn_back = false;

        public bool lineFollowing = false;
        int MAXSPEED = 95;
        int MINSPEED = 35;
        double LINE_FOLLOWING_COEF = 1.0; // 0..1
        double FORWARD_COEF = 0.3;

        public int range()
        {
            return (int)((max - min) * RANGE_COEF);
        }

        Main mainForm;
        TCPClient rover;

        public LineFollowingForm(Main mForm, TCPClient theClient)
        {
            mainForm = mForm;
            rover = theClient;
            InitializeComponent();

            rover.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceivedLine_Handler);
            angle = ABS_ANGLE_VALUE;
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


                            if (lineFollowing)
                            {
                                distanceChart.Series["left"].Points.AddY(left_motor);
                                distanceChart.Series["right"].Points.AddY(right_motor);

                                bool l_black = left_value - min < range();
                                bool r_black = right_value - min < range();
                                onLineStatusLabel.Text =
                                    "[" + ((l_black) ? "B" : "W") + "] " +
                                    "[" + ((r_black) ? "B" : "W") + "] ";
                                float ls = 0;
                                float rs = 0;

                                ls = calculate_line_follow_speed(left_value);
                                rs = calculate_line_follow_speed(right_value);
                                //ls = MINSPEED + ((MAXSPEED - MINSPEED) * (left_value / max));
                                //rs = MINSPEED + ((MAXSPEED - MINSPEED) * (right_value / max));

                                //if (!r_black && !l_black)
                                //{
                                //    mainForm.stop();
                                //}
                                //else
                                {
                                    rover.SendData(CommandID.SetMotorsSpeed, new byte[] { (byte)ls, (byte)(rs) });
                                }
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
                                maxCalibTextBox.Text = max.ToString();
                                minCalibTextBox.Text = min.ToString();

                                if ((angle_turned < Math.Abs(ABS_ANGLE_VALUE * STEPS)) && (turn_left == false))
                                {
                                    angle_turned += angle;
                                    turn_Calibrate(angle);

                                    if ((angle_turned >= 0) && turn_back)
                                    {
                                        calibrate = false;
                                        calibrationStatusLabel.Text = "Calibrated!";
                                    }
                                }
                                else
                                {
                                    turn_left = true;
                                    turn_back = true;
                                    angle = -ABS_ANGLE_VALUE;
                                }

                                if ((turn_left == true) && (angle_turned > -Math.Abs(ABS_ANGLE_VALUE * STEPS)))
                                {
                                    angle_turned += angle;
                                    turn_Calibrate(angle);
                                }
                                else
                                {
                                    angle = ABS_ANGLE_VALUE;
                                    turn_left = false;
                                }

                            }
                        }));
                        break;
                }
            }
        }

        private byte calculate_line_follow_speed(int value)
        {
            byte speed;

            if (value > (max - min) * FORWARD_COEF)
            {
                speed = (byte)(MINSPEED + (MAXSPEED - MINSPEED) * ((double)(value - min) / (max - min) * LINE_FOLLOWING_COEF));
            }
            else
            {
                speed = (byte)(-MINSPEED - (MAXSPEED - MINSPEED) * ((double)(value - min) / (max - min) * LINE_FOLLOWING_COEF));
            }
            return speed;
        }

        private void calibrateButton_Click(object sender, EventArgs e)
        {
            max = int.Parse(maxCalibTextBox.Text);
            min = int.Parse(minCalibTextBox.Text);
            calibrate = true;
            turn_left = false;
            turn_back = false; 
            angle_turned = 5;
            turn_Calibrate(ABS_ANGLE_VALUE);
            calibrationStatusLabel.Text = "Calibrating ...";
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
            mainForm.stop();
            turnTimer.Enabled = false;
        }

        private void LineFollowingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            rover.OnMessageReceived -= new ClientBase.ClientMessageReceivedEvent(DataReceivedLine_Handler);
        }

        private void followLineButton_Click(object sender, EventArgs e)
        {
            lineFollowing = !lineFollowing;
            if (lineFollowing)
            {
                max = int.Parse(maxCalibTextBox.Text);
                min = int.Parse(minCalibTextBox.Text);
                followLineButton.Text = "Stop Line Following";
                rover.SendData(CommandID.IRDistanceData, new byte[] { });
                calibrateButton.Enabled = false;
            }
            else
            {
                followLineButton.Text = "Follow Line";
                mainForm.stop();
                calibrateButton.Enabled = true;
            }
            
        }

        private void minCalibTextBox_TextChanged(object sender, EventArgs e)
        {
            min = int.Parse(minCalibTextBox.Text);
        }

        private void maxCalibTextBox_TextChanged(object sender, EventArgs e)
        {
            if (maxCalibTextBox.Text.Length != 0) max = int.Parse(maxCalibTextBox.Text);
        }
    }
}
