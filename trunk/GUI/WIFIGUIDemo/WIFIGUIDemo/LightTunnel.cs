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

        public void AddDataPoint(double pos, double light)
        {
            //Add data to the datapoint
            lightIntensityChart.Series["lightPathPoint"].Points.AddXY(pos, light);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            lightIntensityChart.Series["lighPathPoint"].Points.Clear();
        }

        private void tunnelMapButton_Click(object sender, EventArgs e)
        {
            if (rover.isConnected)
            {
                rover.SendData(CommandID.DriveSteps, new byte[] { 0, 255 });
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

    }
}
