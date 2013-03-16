using System;
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
    public partial class VortexForm : Form
    {
        Main mainForm;
        TCPClient rover;

        const int packets_count = 16;
        const int packet_size = 60;

        int[] mag_packet = new int[packets_count];

        public VortexForm(Main mForm, TCPClient theClient)
        {
            mainForm = mForm;
            rover = theClient;
            InitializeComponent();

            rover.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceivedVortex_Handler);
        }

        private void DataReceivedVortex_Handler(Client_Message_EventArgs e)
        {
            //Take the new data received and convert it into a more manageable format
            List<byte> NewData = e.RawMessage.ToList();

            if (NewData.Count > 3)
            {
                //Switch on the commandID set in the common.cs file
                switch (NewData[3])
                {
                    case (byte)CommandID.MagDATABuffer:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            if (NewData[4] == 1)
                            {
                                magDataLabel.Text = "Data received!";
                            }
                        }));
                        break;
                    case (byte)CommandID.MagDATABufferPacketX:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            int id = Convert.ToUInt16(NewData[4]);
                            for (int i = 0; i < packet_size * 2; i += 2)
                            {
                                double mag = mainForm.to12BitConversion((NewData[(5 + i)] << 8) + ((NewData[(6 + i)])));

                                SeismicActivityChart.Series["mag_x"].Points.AddXY(id * packet_size + i / 2, mag);
 
                            }

                            for (byte i = 0; i < packet_size; i++)
                            {
                                if (mag_packet[i] == 1)
                                {
                                    rover.SendData(CommandID.MagDATABufferPacketX, new byte[] { i });
                                    mag_packet[i] = 0;
                                    break;
                                }
                            }
 
                        }));
                        break;

                    case (byte)CommandID.MagDATABufferPacketY:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            int id = Convert.ToUInt16(NewData[4]);

                            for (int i = 0; i < packet_size * 2; i += 2)
                            {
                                double mag = mainForm.to12BitConversion(
                                    (NewData[(5 + i)] << 8) + ((NewData[(6 + i)])));

                                SeismicActivityChart.Series["mag_y"].Points.AddXY(id * packet_size + i / 2, mag);

                            }

                            if (id < packets_count)
                            {
                                rover.SendData(CommandID.MagDATABufferPacketY, new byte[] { (byte)(id + 1) });
                            }
                        }));
                        break;

                    case (byte)CommandID.MagDATABufferPacketZ:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            int id = Convert.ToUInt16(NewData[4]);

                            for (int i = 0; i < packet_size * 2; i += 2)
                            {
                                double mag = mainForm.to12BitConversion(
                                    (NewData[(5 + i)] << 8) + ((NewData[(6 + i)])));

                                SeismicActivityChart.Series["mag_z"].Points.AddXY(id * packet_size + i / 2, mag);

                            }

                            if (id < packets_count)
                            {
                                rover.SendData(CommandID.MagDATABufferPacketZ, new byte[] { (byte)(id + 1) });
                            }
                        }));
                        break;

                    case (byte)CommandID.GetMagnetValue:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {

                                int x = mainForm.to16BitConversion(Convert.ToUInt16(NewData[5]) + Convert.ToUInt16(NewData[4] << 8));
                                int y = mainForm.to16BitConversion(Convert.ToUInt16(NewData[9]) + Convert.ToUInt16(NewData[8] << 8));
                                int z = mainForm.to16BitConversion(Convert.ToUInt16(NewData[7]) + Convert.ToUInt16(NewData[6] << 8));
                                SeismicActivityChart.Series["mag_x"].Points.AddY(x);
                                SeismicActivityChart.Series["mag_y"].Points.AddY(y);
                                SeismicActivityChart.Series["mag_z"].Points.AddY(z);

                            }));
                            break;
                        }
                }
            }
        }

        private void VortexForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            rover.OnMessageReceived -= new ClientBase.ClientMessageReceivedEvent(DataReceivedVortex_Handler);
        }

        private void getMagButton_Click(object sender, EventArgs e)
        {
            //rover.SendData(CommandID.MagDATABuffer, new byte[] { });
            //magDataLabel.Text = "Waiting for data.";
            magDataLabel.Text = "Button disabled.";
        }

        private void receiveButton_Click(object sender, EventArgs e)
        {
            //X axis
            for (int p = 0; p < packets_count; p++)
            {
                mag_packet[p] = 1;
            }
            mag_packet[0] = 0;
            rover.SendData(CommandID.MagDATABufferPacketX, new byte[] { 0 });
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Y axis
            //for (int p = 0; p < packets_count; p++)
            {
                rover.SendData(CommandID.MagDATABufferPacketY, new byte[] { (byte)0 });
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Z axis
            //for (int p = 0; p < packets_count; p++)
            {
                rover.SendData(CommandID.MagDATABufferPacketZ, new byte[] { (byte)0 });
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            SeismicActivityChart.Series["mag_x"].Points.Clear();
            SeismicActivityChart.Series["mag_y"].Points.Clear();
            SeismicActivityChart.Series["mag_z"].Points.Clear();
        }

        private void singleValueButton_Click(object sender, EventArgs e)
        {
            rover.SendData(CommandID.GetMagnetValue, new byte[] { });
        }

        private void dataTimer_Tick(object sender, EventArgs e)
        {
            singleValueButton_Click(null, null);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter mag_x = new System.IO.StreamWriter("N:\\..University\\Year2\\Cybs Challenge\\Data\\MagDataX.txt");

            foreach (DataPoint left in SeismicActivityChart.Series["mag_x"].Points)
            {
                mag_x.WriteLine(left.YValues[0].ToString());
            }
            mag_x.Close();

            System.IO.StreamWriter mag_y = new System.IO.StreamWriter("N:\\..University\\Year2\\Cybs Challenge\\Data\\MagDataY.txt");

            foreach (DataPoint left in SeismicActivityChart.Series["mag_y"].Points)
            {
                mag_y.WriteLine(left.YValues[0].ToString());
            }
            mag_y.Close();

            System.IO.StreamWriter mag_z = new System.IO.StreamWriter("N:\\..University\\Year2\\Cybs Challenge\\Data\\MagDataZ.txt");

            foreach (DataPoint left in SeismicActivityChart.Series["mag_z"].Points)
            {
                mag_z.WriteLine(left.YValues[0].ToString());
            }
            mag_z.Close();
        }

        private void streamButton_Click(object sender, EventArgs e)
        {
            dataTimer.Enabled = !dataTimer.Enabled;
        }

    }
}
