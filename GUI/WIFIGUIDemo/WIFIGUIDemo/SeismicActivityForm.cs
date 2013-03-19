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
    public partial class SeismicActivityForm : Form
    {
        TCPClient rover;
        Main mainForm;

        public SeismicActivityForm(Main mForm, TCPClient theClient)
        {
            rover = theClient;
            mainForm = mForm;
            InitializeComponent();
            rover.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceivedSeismicActivity_Handler);
        }

        private void stopButton_Click(object sender, EventArgs e)
        {

            if (data_on) seismicActivityButton_Click(sender, e);
        }

        const int accel_data_buffer_size = 10;
        const int offset_dist = 16368;

        const int acc_packet_size = 17;
        const int acc_packet_buffer_size = 60;

        const int packets_count = 17;
        const int packet_size = 60;

        bool done_packet_transfer = true;

        private void DataReceivedSeismicActivity_Handler(Client_Message_EventArgs e)
        {
             //Take the new data received and convert it into a more manageable format
            List<byte> NewData = e.RawMessage.ToList();

            if (NewData.Count > 3)
            {
                //Switch on the commandID set in the common.cs file
                switch (NewData[3])
                {
                    case (byte)CommandID.GetAccelValue:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            if (NewData.Count > 10)
                            {
                                float Accelx = mainForm.to12BitConversion((NewData[5]) + (NewData[4] << 8) >> 4);
                                float Accely = mainForm.to12BitConversion((NewData[7]) + (NewData[6] << 8) >> 4);
                                float Accelz = mainForm.to12BitConversion((NewData[9]) + (NewData[8] << 8) >> 4);

                                Accelx = Accelx / 1024; // for 2g , divide by 1024; 4g -> /512; 8g -> /256
                                Accely = Accely / 1024;
                                Accelz = Accelz / 1024;

                                //Find angle
                                float x1 = (Accelx * 100) + 100;
                                float y1 = (Accely * 100) + 100;
                                float z1 = (Accelz * 100) + 100;
                                int xprogress = (int)(x1);
                                int yprogress = (int)(y1);
                                int zprogress = (int)(z1);

                                double xsq = (Accelx * Accelx);
                                double ysq = (Accely * Accely);
                                double zsq = (Accelz * Accelz);

                                double xresult = Math.Sqrt(ysq + zsq);
                                xresult = Accelx / xresult;
                                double Ax = Math.Atan(xresult) * 180 / Math.PI;


                                double yresult = Math.Sqrt(xsq + zsq);
                                yresult = Accely / yresult;
                                double Ay = Math.Atan(yresult) * 180 / Math.PI;

                                double zresult = Math.Sqrt(xsq + ysq);
                                zresult = Accelz / zresult;
                                double Az = Math.Atan(zresult) * 180 / Math.PI;

                                AccelDataLabel.Text = Ax.ToString(".00") + " " + Ay.ToString(".00") + " " + Az.ToString(".00");
                                /*
                                SeismicActivityChart.Series["AccelDataX"].Points.AddXY(avr_e, Accelx);
                                SeismicActivityChart.Series["AccelDataY"].Points.AddXY(avr_e, Accely);
                                SeismicActivityChart.Series["AccelDataZ"].Points.AddXY(avr_e, Accelz);
                                */

                            }
                        }));
                        break;

                    case (byte)CommandID.AutomaticAccelBuffer:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            for (int i = 0; i < accel_data_buffer_size * 8 && i < NewData.Count - 11; i += 8)
                            {
                                float Accelx = mainForm.to12BitConversion((NewData[5 + i]) + (NewData[4 + i] << 8) >> 4);
                                float Accely = mainForm.to12BitConversion((NewData[7 + i]) + (NewData[6 + i] << 8) >> 4);
                                float Accelz = mainForm.to12BitConversion((NewData[9 + i]) + (NewData[8 + i] << 8) >> 4);
                                int ms_id = Convert.ToUInt16(NewData[11 + i]) + Convert.ToUInt16(NewData[10 + i] << 8);
                                
                                Accelx = Accelx / 1024; // for 2g , divide by 1024; 4g -> /512; 8g -> /256
                                Accely = Accely / 1024;
                                Accelz = Accelz / 1024;

                                SeismicActivityChart.Series["Accelx"].Points.AddXY(ms_id, Accelx);
                                SeismicActivityChart.Series["Accely"].Points.AddXY(ms_id, Accely);
                                SeismicActivityChart.Series["Accelz"].Points.AddXY(ms_id, Accelz);
                            }
                        }));
                        break;


                    case (byte)CommandID.AccDATABuffer:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            /*
                            int id = Convert.ToUInt16(NewData[4]);

                            for (int i = 0; i < accel_data_buffer_size - 1; i+=2)
                            {
                                double Accelz = mainForm.to12BitConversion(NewData[(5 + i)]  + (NewData[(6 + i)] << 8));
                                Accelz = Accelz / 1024.0; // normilize in +- 2g

                                SeismicActivityChart.Series["Accelz"].Points.AddXY(id * acc_packet_buffer_size + i, Accelz);
                            }
                            
                            if (id == acc_packet_size - 1) seismicActivityButton_Click(null, null);
                             */
                            seismicActivityButton_Click(null, null);
                            AccelDataLabel.Text = "Data Collected on the rover.";
                        }));
                        break;


                    case (byte)CommandID.DriveSteps:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            rover.SendData(CommandID.AutomaticIRBuffer, new byte[] { 0 });
                        }));
                        break;

                    case (byte)CommandID.AccDATABufferPacket:
                        //Invokation to allow cross thread manipulation
                        this.BeginInvoke(new EventHandler(delegate
                        {
                            int id = Convert.ToUInt16(NewData[4]);

                            for (int i = 0; i < packet_size * 2; i+=2)
                            {
                                double Accelz = mainForm.to12BitConversion(NewData[(5 + i)] + (NewData[(6 + i)] << 8));
                                Accelz = Accelz / 1024.0; // normilize in +- 2g

                                SeismicActivityChart.Series["Accelz"].Points.AddXY(id * packet_size + i/2, Accelz);
                            }

                            done_packet_transfer = true;
                            
                        }));
                        break;
                }
            }
        }

        private void RiverBedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Unsubscribe
            rover.OnMessageReceived -= new ClientBase.ClientMessageReceivedEvent(DataReceivedSeismicActivity_Handler);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            SeismicActivityChart.Series["Accelx"].Points.Clear();
            SeismicActivityChart.Series["Accely"].Points.Clear();
            SeismicActivityChart.Series["Accelz"].Points.Clear();
        }

        bool data_on = false;
        private void seismicActivityButton_Click(object sender, EventArgs e)
        {
            if (data_on)
            {
                data_on = false;
                seismicActivitybutton.Text = "Map Seismic Activity - Off";
                stopButton_Click(sender, e);
                //rover.SendData(CommandID.AutomaticAccelBuffer, new byte[] { 0 });
            }
            else
            {
                data_on = true;
                seismicActivitybutton.Text = "Map Seismic Activity - On";

                rover.SendData(CommandID.AccDATABuffer, new byte[] { });
                //rover.SendData(CommandID.AutomaticAccelBuffer, new byte[] { 1 });
            }
        }


        private void saveDataButton_Click(object sender, EventArgs e)
        {

            // Write the string to a file.
            System.IO.StreamWriter acc_z = new System.IO.StreamWriter(mainForm.SAVE_DIR + "SeismicData.txt");

            foreach (DataPoint left in SeismicActivityChart.Series["Accelz"].Points)
            {
                acc_z.WriteLine(left.YValues[0].ToString());
            }
            acc_z.Close();

        }

        private void getValButton_Click(object sender, EventArgs e)
        {
            if (rover.isConnected)
            {
                rover.SendData(CommandID.GetAccelValue, new byte[] { });
            }

        }

        private void getAllButton_Click(object sender, EventArgs e)
        {
            done_packet_transfer = true;
            for (int p = 0; p < packets_count; p++)
            {
                //while (!done_packet_transfer) {  }
                if (done_packet_transfer)
                {
                    //done_packet_transfer = false;
                    rover.SendData(CommandID.AccDATABufferPacket, new byte[] { (byte)p });
                }
            }
        }
    }
}
