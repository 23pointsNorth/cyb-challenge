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
    public partial class LightTunnel : Form
    {
        TCPClient rover;
        Main mainForm;

        public LightTunnel(TCPClient theClient, Main main_form)
        {
            rover = theClient;
            mainForm = main_form;
            InitializeComponent();
        }

        const int offset_dist = 16368;

        public void AddDataPoint(double pos, double light)
        {
            //Add data to the datapoint
            lightIntensityChart.Series["lightPathPoint"].Points.AddXY(Math.Abs(pos - offset_dist), light);
           
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            lightIntensityChart.Series["lightPathPoint"].Points.Clear();
        }

        private void tunnelMapButton_Click(object sender, EventArgs e)
        {
            if (rover.isConnected)
            {
                rover.SendData(CommandID.DriveSteps, new byte[] { 255, 6 });
                lightPosTimer.Enabled = true;
            }
        }

        private void lightPosTimer_Tick(object sender, EventArgs e)
        {
            if (rover.isConnected)
            {
                rover.SendData(CommandID.LightPositionData, new byte[] { });
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (rover.isConnected)
            {
                rover.SendData(CommandID.SetMotorsSpeed, new byte[] { 0, 0 });
                lightPosTimer.Enabled = false;
            }
        }

        private void LightTunnel_KeyDown(object sender, KeyEventArgs e)
        {
            mainForm.Main_KeyDown(sender, e);
        }

        private void LightTunnel_KeyUp(object sender, KeyEventArgs e)
        {
            mainForm.Main_KeyUp(sender, e);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //lightIntensityChart.Series["lightPathPoint"].Points.OrderBy(p => p.XValue).ThenBy(p => p.YValues);

            System.IO.StreamWriter file_light = new System.IO.StreamWriter(mainForm.SAVE_DIR + "LightTunnelData.txt");
            System.IO.StreamWriter dist = new System.IO.StreamWriter(mainForm.SAVE_DIR + "LightDistData.txt");

            foreach (DataPoint light in lightIntensityChart.Series["lightPathPoint"].Points)
            {
                file_light.WriteLine(light.YValues[0].ToString());
                dist.WriteLine(light.XValue.ToString());
            }
            file_light.Close();
            dist.Close();
        }

    }
}
