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

            IRDataTimer.Enabled = false;
        }

        const int IR_data_buffer_size = 20;

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
                            int IRl = (NewData[4]) + (NewData[5] << 8);
                            int IRr = (NewData[6]) + (NewData[7] << 8);
                            int le = NewData[8] + (NewData[9] << 8);
                            int re = NewData[10] + (NewData[11] << 8);
                            //int IRl = Convert.ToUInt16(NewData[4]) + Convert.ToUInt16(NewData[5] << 8);
                           // int IRr = Convert.ToUInt16(NewData[6]) + Convert.ToUInt16(NewData[7] << 8);
                            //int le = Convert.ToUInt16(NewData[8]) + Convert.ToUInt16((NewData[9] << 8));
                            //int re = Convert.ToUInt16(NewData[10]) + Convert.ToUInt16((NewData[11] << 8));
                            int avr_e = (le + re) / 2;

                            IRIntensityDistanceChart.Series["IRDataLeft"].Points.AddXY(avr_e, IRl);
                            IRIntensityDistanceChart.Series["IRDataRight"].Points.AddXY(avr_e, IRr);

                            IRDataLabel.Text = IRl.ToString() + " " + IRr.ToString();
                            //if (map_on) rover.SendData(CommandID.IRDistanceData, new byte[] { });
                           
                        }));
                        break;
                    case (byte)CommandID.IRDataBuffer:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            //MessageBox.Show(" " + NewData[0] + " " + NewData[1] + " " + NewData[2] + " " + NewData[3]);
                            for (int i = 0; i < IR_data_buffer_size * 6 && i < NewData.Count - 9; i += 6)
                            {
                                int IRl = Convert.ToUInt16(NewData[4 + i]) + Convert.ToUInt16(NewData[5 + i] << 8);
                                
                                int IRr = Convert.ToUInt16(NewData[6 + i]) + Convert.ToUInt16(NewData[7 + i] << 8);
                                int avr_e = Convert.ToUInt16(NewData[8 + i]) + Convert.ToUInt16((NewData[9 + i] << 8));

                                IRIntensityDistanceChart.Series["IRDataLeft"].Points.AddXY(avr_e, IRl);
                                IRIntensityDistanceChart.Series["IRDataRight"].Points.AddXY(avr_e, IRr);

                                //MessageBox.Show(IRl.ToString() + " " + IRr.ToString());
                                IRDataLabel.Text = IRl.ToString() + " " + IRr.ToString() + " " + i.ToString();
                            }
                            //if (map_on) rover.SendData(CommandID.IRDistanceData, new byte[] { });

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
                IRDataTimer.Enabled = false;
            }
            else
            {
                map_on = true;
                riverBedMapButton.Text = "River Bed Map - ON";
                rover.SendData(CommandID.DriveSteps, new byte[] { 200, 2 });
                //rover.SendData(CommandID.IRDistanceData, new byte[] { });

                IRDataTimer.Enabled = true;
            }
        }

        private void IRDataTimer_Tick(object sender, EventArgs e)
        {
            //rover.SendData(CommandID.IRDistanceData, new byte[] { });
            rover.SendData(CommandID.IRDataBuffer, new byte[] { });
        }
    }
}
