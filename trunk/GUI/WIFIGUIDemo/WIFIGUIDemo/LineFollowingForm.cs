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
                        }));
                        break;
                }
            }
        }

        private void calibrateButton_Click(object sender, EventArgs e)
        {
            rover.SendData(CommandID.IRDistanceData, new byte[] { });
        }

        private void LineFollowingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            rover.OnMessageReceived -= new ClientBase.ClientMessageReceivedEvent(DataReceivedLine_Handler);
        }
    }
}
