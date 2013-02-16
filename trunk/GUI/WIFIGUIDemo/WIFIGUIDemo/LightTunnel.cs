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

        public LightTunnel(TCPClient theClient)
        {
            rover = theClient;
            InitializeComponent();
        }

        public void AddDataPoint(double pos, double light)
        {
            Series lightPathPoint = new Series();
            lightPathPoint.Points.AddXY(pos, light);
            //Add data to the datapoint
            lightIntensityChart.Series.Add(lightPathPoint);
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            lightIntensityChart.Series.Clear();
        }

        private void tunnelMapButton_Click(object sender, EventArgs e)
        {
            rover.SendData(CommandID.DriveSteps, new byte[] {10, 255});
        }

        private void lightPosTimer_Tick(object sender, EventArgs e)
        {
            rover.SendData(CommandID.LightPositionData, new byte[] { });
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            rover.SendData(CommandID.SetMotorsSpeed, new byte[] { 0, 0 });
        }
    }
}
