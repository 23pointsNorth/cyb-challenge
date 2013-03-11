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
            InitializeComponent();
            mainForm = mForm;
            rover = theClient;
        }

        private void sendEmailButton_Click(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
            message.To.Add("kp015255@reading.ac.uk  ");
            message.Subject = "Hello message!";
            message.From = new System.Net.Mail.MailAddress("kp015255@reading.ac.uk");
            message.Body = MessageBox.Text;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.reading.ac.uk");
            smtp.Send(message);
        }
    }
}
