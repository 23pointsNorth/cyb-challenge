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
    public partial class VolcanoForm : Form
    {
        Main mainForm;
        TCPClient rover;

        public VolcanoForm(Main mForm, TCPClient theClient)
        {
            mainForm = mForm;
            rover = theClient;
            InitializeComponent();

            rover.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceivedVolcano_Handler);
        }

        int temp_id = 0;

        private void DataReceivedVolcano_Handler(Client_Message_EventArgs e)
        {
            List<byte> NewData = e.RawMessage.ToList();

            if (NewData.Count > 3)
            {
                switch (NewData[3])
                {
                    case (byte)CommandID.GetTermData:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {
                                int temp = Convert.ToUInt16(NewData[4]) + Convert.ToUInt16(NewData[5] << 8);
                                double temp_celsius = mainForm.ConvertToTemperature(temp);
                                volcanoTempChart.Series["Temperature"].Points.AddXY(
                                    (temp_id * dataTimer.Interval)/1000.0 ,temp_celsius);
                                lastTempLabel.Text = "Last Temp: " + temp_celsius.ToString("00.0") + "'C";
                            }));
                            break;
                        }
                }
            }
        }

        private void VolcanoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            rover.OnMessageReceived -= new ClientBase.ClientMessageReceivedEvent(DataReceivedVolcano_Handler);
        }

        private void getTempButton_Click(object sender, EventArgs e)
        {
            dataTimer.Enabled = !dataTimer.Enabled;
            if (dataTimer.Enabled)
            {
                statusLabel.Text = "Collecting data!";
            }
            else statusLabel.Text = "Data Collection Stopped.";
        }

        private void dataTimer_Tick(object sender, EventArgs e)
        {
            rover.SendData(CommandID.GetTermData, new byte[] { });
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            volcanoTempChart.Series["Temperature"].Points.Clear();
        }

        private void saveDataButton_Click(object sender, EventArgs e)
        {
            System.IO.StreamWriter temp_data = new System.IO.StreamWriter(mainForm.SAVE_DIR + "TempData.txt");

            foreach (DataPoint left in volcanoTempChart.Series["Temperature"].Points)
            {
                temp_data.WriteLine(left.YValues[0].ToString());
            }
            temp_data.Close();
        }
    }
}
