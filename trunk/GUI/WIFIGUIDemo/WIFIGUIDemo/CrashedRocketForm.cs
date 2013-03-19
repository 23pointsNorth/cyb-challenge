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
    public partial class CrashedRocketForm : Form
    {
        Main mainForm;
        TCPClient rover;

        public CrashedRocketForm(Main mForm, TCPClient theClient)
        {
            mainForm = mForm;
            rover = theClient;
            InitializeComponent();

            rover.OnMessageReceived += new ClientBase.ClientMessageReceivedEvent(DataReceivedCrashed_Handler);
        }

        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add("kp015255@reading.ac.uk"); // s.gould@reading.ac.uk
            message.Subject = "Decoded Message from Crashed Rocket - Team CYB01";
            message.From = new System.Net.Mail.MailAddress("kp015255@reading.ac.uk");
            message.Body = "Hello Stephen Gould, \n\t We are happy to announce that we have reached the crashed rocket! " +
                "We recevied and decoded the following message: \n\n \t\t \"" + decodedMessage.Text + "\""+
                " \n\n \t Hope this helps the mission!" + "\n\n Best wishes,\n \t Project Nova\n \t Cyb01";
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.reading.ac.uk");
            smtp.Send(message);
        }

        private void requestMessageButton_Click(object sender, EventArgs e)
        {
            if (rover.isConnected)
            {
                rover.SendData(CommandID.GetCrashedRoverData, new byte[] { });
            }
            else
            {
                MessageBox.Show("Not connected!");
            }
        }


        private void DataReceivedCrashed_Handler(Client_Message_EventArgs e)
        {
            List<byte> NewData = e.RawMessage.ToList();

            if (NewData.Count > 3)
            {
                switch (NewData[3])
                {
                    case (byte)CommandID.GetCrashedRoverData:
                        {
                            //Invokation to allow cross thread manipulation
                            this.BeginInvoke(new EventHandler(delegate
                            {
                                for (int i = 4; i < NewData.Count; i++)
                                {
                                    CrashedMessageBox.Text += NewData[i] + " ";
                                    if (i % 2 == 0) decodedMessage.Text += ((char)(NewData[i] / 2));
                                }

                                for (int i = 4; i < NewData.Count; i++)
                                {
                                    int letter = NewData[i]/2;
                                    if (letter >= 32 && letter <= 127) { _2ndDecodeMsgTextBox.Text += (char)letter; }
                                }
                            }));
                            break;
                        }   
                }
            }
        }

        private void CrashedRocketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Unsubscribe
            rover.OnMessageReceived -= new ClientBase.ClientMessageReceivedEvent(DataReceivedCrashed_Handler);
        }

        private void clearMsgButton_Click(object sender, EventArgs e)
        {
            CrashedMessageBox.Clear();
            decodedMessage.Clear();
            _2ndDecodeMsgTextBox.Clear();
        }

    }
}
