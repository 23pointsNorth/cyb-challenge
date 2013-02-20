﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ServerLib;
using System.Windows.Forms.DataVisualization.Charting;

namespace WIFIGUIDemo
{
    public partial class RiverBedForm : Form
    {
        TCPClient rover;
        Main mainForm;

        public RiverBedForm(Main mForm, TCPClient theClient)
        {
            rover = theClient;
            mainForm = mForm;
            InitializeComponent();
            rover.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceivedRiverBed_Handler);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            rover.SendData(CommandID.SetMotorsSpeed, new byte[] { 0, 0 });
            if (map_on) riverBedMapButton_Click(sender, e);
        }

        private void DataReceivedRiverBed_Handler(Client_Message_EventArgs e)
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
                            int IRl = NewData[5] + NewData[4] << 8;
                            int IRr = NewData[7] + NewData[6] << 8;
                            int le = NewData[8] + (NewData[9] << 8);
                            int re = NewData[10] + (NewData[11] << 8);
                            int avr_e = (le + re) / 2;

                            IRIntensityDistanceChart.Series["IRDataLeft"].Points.AddXY(IRl, avr_e);
                            IRIntensityDistanceChart.Series["IRDataRight"].Points.AddXY(IRr, avr_e);

                            if (map_on) rover.SendData(CommandID.IRDistanceData, new byte[] { });
                        }));
                        break;
                }
            }
        }

        private void RiverBedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Unsubscribe
            rover.OnMessageReceived -= new ClientBase.ClientMessageReceivedEvent(DataReceivedRiverBed_Handler);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            IRIntensityDistanceChart.Series["IRDataLeft"].Points.Clear();
            IRIntensityDistanceChart.Series["IRDataRight"].Points.Clear();
        }

        bool map_on = false;
        private void riverBedMapButton_Click(object sender, EventArgs e)
        {
            if (map_on)
            {
                map_on = false;
                riverBedMapButton.Text = "River Bed Map - OFF";
                stopButton_Click(sender, e);
            }
            else
            {
                map_on = true;
                riverBedMapButton.Text = "River Bed Map - ON";
                rover.SendData(CommandID.DriveSteps, new byte[] { 0, 255 });
            }
        }
    }
}
