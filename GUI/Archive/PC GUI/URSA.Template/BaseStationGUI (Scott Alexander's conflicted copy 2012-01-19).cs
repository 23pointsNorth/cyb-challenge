using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using URSAtools.Comms;
using URSAtools;
using WebCam_Capture;
using System.Collections;
using System.Drawing.Imaging;
using System.Windows;

namespace URSA.Template
{
	public partial class BaseStationGUI : Form
	{
		private URSAport _port = new URSAport();

		/// <summary>
		/// Enumeration of commands, you will need to add to these using the data sheet provided.
		/// </summary>
		public enum CommandId : byte
		{
			InternalCounter = 3
		}

        /// <summary>
		/// Form default constructor
		/// </summary>
		public BaseStationGUI()
		{
			InitializeComponent();
            BaseStationGUI_FormOpening();
            
            /* Hookup a method written in this class to respond to the URSAport instance defined as 
                 * _port, this is semanticaly identical to the hookup of a button's click event.
                 * Visual Studio however hides the form control hookups in the BaseStationGUI.Designer.cs code
                 * behind file, this is accessable by expanding the form in the Solution Explorer */
          
            _port.onMessageReceived += new URSAport.MessageReceivedHandler(_port_onMessageReceived);
		}

        
        /// <summary>
        /// Form Opening Settings
        /// </summary>
        private void BaseStationGUI_FormOpening()
        {
            this.WebCamCapture.CaptureHeight = this.pictureBox1.Height;
            this.WebCamCapture.CaptureWidth = this.pictureBox1.Width;
        }

        /// <summary>
        /// Close the port correctly when the form closing event fires
        /// </summary>
        private void BaseStationGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_port != null)
            {
                _port.Close();
            }
            this.WebCamCapture.Stop();
        }

        /// <summary>
        /// Set Image to textbox on webcam capture inturupt
        /// </summary>
        private void WebCamCapture_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
        {
            this.pictureBox1.Image = e.WebCamImage;

        }

        /// <summary>
		/// The method fired in reply to the buttonOpen button being pressed
		/// </summary>
		private void buttonOpen_Click(object sender, EventArgs e)
		{
            FTDI_DEVICE_INFO_NODE[] aList = URSAport.ListDevices();
            foreach (FTDI_DEVICE_INFO_NODE aNode in aList)                  // add each of the discovered
            {                                                               // devices to the list
                listBox1.Items.Add(aNode.SerialNumber.ToString());
            }
            if (listBox1.Items.Count > 0) listBox1.SelectedIndex = 0;
            if (!_port.isOpen)
            {
                _port.OpenBySerialNumber(listBox1.SelectedItems[0].ToString());
                // change the capture time frame
                this.WebCamCapture.TimeToCapture_milliseconds = 20;
                //   timer1.Enabled = true;
                // start the video capture. let the control handle the
                // frame numbers.
                this.WebCamCapture.Start(0);
            }
            else
            {
                MessageBox.Show("Could not find the dongle");
            }
           
		}

		/// <summary>
		/// This method fired in reply the URSAPort MessageReceived event, the event hookup is contained with the buttonOpen_Click
		/// method above
		/// </summary>
		private void _port_onMessageReceived(object sender, byte[] message)
		{
			/* This method is called in responce to the MessageReceived event being fired from within the URSAPort class.
			 * The internal workings of the URSA port class are operating on a different thread to that of the GUI, we must therfore
			 * invoke any code that changes the GUI in the same thread as the GUI, this is what 'this.BeginInvoke' does for us.
			 * */
			this.BeginInvoke(new EventHandler(delegate
			{
				string stringRepresentation =  Utilities.ConvertByteArrayToString(message);

				richTextBoxInput.AppendText(string.Format("{0}\n", stringRepresentation));

				// Ensure the message is not malformed
				if (message.Length >= 2)
				{
					CommandId command = (CommandId)message.GetValue(1);

					//Display RSSI
					labelRSSI.Text = message.GetValue(0).ToString();
					progressBarRSSI.Value = int.Parse(message.GetValue(0).ToString());

					if (command == CommandId.InternalCounter && message.Length == 4)
					{
						labelRecvCount.Text = message.GetValue(2).ToString();
					}
				}
			}));
		}

		/// <summary>
		/// The method fired in reply to the buttonClose button being pressed
		/// </summary>
		private void buttonClose_Click(object sender, EventArgs e)
		{
			if (_port != null)
			{
				_port.Close();
                // stop the video capture
                this.WebCamCapture.Stop();
			}
		}

		/// <summary>
		/// The method fired in reply to the buttonSendCmd3 button being pressed
		/// </summary>
		private void buttonSendCmd3_Click(object sender, EventArgs e)
		{
			/*  Send a packet with command id as defined by the enumeration top with an empty packet payload, 
                sending a two byte payload with that value of
                10 and 20 would be coded as _port.SendData((byte)CommandId.InternalCounter, new byte[] { 10,20 }); */
            if (textBox1.Text.ToString() != "0")
            {
                    _port.SendData(Convert.ToByte(textBox1.Text.ToString()), new byte[] {Convert.ToByte(textBox2.Text.ToString()) });
            }
            
        //    _port.SendData((byte)CommandId.InternalCounter, new byte[] { });
		}

		/// <summary>
		/// Fires at intervals defined by the GUI timer control
		/// </summary>
		/// <param name="sender">Originating timer instance</param>
		/// <param name="e">Time event arguments</param>
		private void timerGUIUpdate_Tick(object sender, EventArgs e)
		{
			// Code to ensure buttons are only available when desired, based around the state of the port
			
			if (_port == null || !_port.isOpen)
			{
				buttonOpen.Enabled = true;
			}
			else
			{
				buttonOpen.Enabled = false;
			}

			buttonClose.Enabled = buttonSendCmd3.Enabled = !buttonOpen.Enabled;
		}

        private void label3_Click(object sender, EventArgs e)
        {

        }


      
	}
}
