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

namespace URSA.Template
{
	public partial class BaseStationGUI : Form
	{
        int ul = 0;
        int ur = 0;
        int hist1;
        int hist2;
        
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
			
            
            /* Hookup a method written in this class to respond to the URSAport instance defined as 
                 * _port, this is semanticaly identical to the hookup of a button's click event.
                 * Visual Studio however hides the form control hookups in the BaseStationGUI.Designer.cs code
                 * behind file, this is accessable by expanding the form in the Solution Explorer */
          
            _port.onMessageReceived += new URSAport.MessageReceivedHandler(_port_onMessageReceived);
		}

        /// <summary>
        /// Close the port correctly when the form closing event fires
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BaseStationGUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_port != null)
            {
                if (cmdtimer.Enabled == true)
                {
                    cmdtimer.Stop();
                }
                _port.Close();
            }
        }
        
        /// <summary>
		/// The method fired in reply to the buttonOpen button being pressed
		/// </summary>
		/// <param name="sender">Originating button instance</param>
		/// <param name="e">Button event arguments</param>
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
            }
            else
            {
                MessageBox.Show("Could not find the dongle");
            }
                cmdtimer.Start();
		}

		/// <summary>
		/// This method fired in reply the URSAPort MessageReceived event, the event hookup is contained with the buttonOpen_Click
		/// method above
		/// </summary>
		/// <param name="sender">The URSAPort instance that originated this event</param>
		/// <param name="message">The byte array containing the reply from the dongle</param>
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
                    if(Convert.ToInt32(message.GetValue(0))>1)
					//Display RSSI
					labelRSSI.Text = message.GetValue(0).ToString();
					progressBarRSSI.Value = int.Parse(message.GetValue(0).ToString());

					if (command == CommandId.InternalCounter && message.Length == 4)
					{
						labelRecvCount.Text = message.GetValue(2).ToString();
					}
                    if(message.GetValue(1).ToString()=="16")
                    {
                        //lultra
                        ul = 0;
                        ul= (int)(message[3]);
                        ul = ul + (255*(int)message[2]);
                        lultra.Text = ul.ToString();
                        if (ul > 1000)
                        {
                            ul = 1000;
                        }
                        progressBar1.Value = ul;
                        //right ultra
                        ur = 0;
                        ur= (int)message[5];
                        ur = ur + (255*(int)message[4]);
                        rultra.Text = ur.ToString();
                        if (ur > 1000)
                        {
                            ur = 1000;
                        }
                        progressBar2.Value = ur;
                    }
                    if (message.GetValue(1).ToString() == "18")
                    {
                        hist1 = 0;
                        hist2 = 0;
                        hist1 = (int)message[2];
                        hist1 += (int)(255 * message[3]);
                        hist2 = (int)message[4];
                        hist2 += (int)(255 * message[5]);
                        his2.Text = hist1.ToString();
                        his3.Text = hist2.ToString();
                    }
				}
                
			}));
		}

		/// <summary>
		/// The method fired in reply to the buttonClose button being pressed
		/// </summary>
		/// <param name="sender">Originating button instance</param>
		/// <param name="e">Button event arguments</param>
		private void buttonClose_Click(object sender, EventArgs e)
		{
			if (_port != null)
			{
                if (cmdtimer.Enabled == true)
                {
                    cmdtimer.Stop();
                }
				_port.Close();
			}
		}

		/// <summary>
		/// The method fired in reply to the buttonSendCmd3 button being pressed
		/// </summary>
		/// <param name="sender">Originating button instance</param>
		/// <param name="e">Button event arguments</param>
		private void buttonSendCmd3_Click(object sender, EventArgs e)
		{
			/*  Send a packet with command id as defined by the enumeration top with an empty packet payload, 
                sending a two byte payload with that value of
                10 and 20 would be coded as _port.SendData((byte)CommandId.InternalCounter, new byte[] { 10,20 }); */
            if (textBox1.Text.ToString() != "0"&&textBox2.Text.ToString() !="-1")
            {
                    _port.SendData(Convert.ToByte(textBox1.Text.ToString()), new byte[] {Convert.ToByte(textBox2.Text.ToString()) });
            }
            else
            {
                if (textBox1.Text.ToString() != "0" && textBox2.Text.ToString() == "-1")
                {
                    _port.SendData(Convert.ToByte(textBox1.Text.ToString()), new byte[] { });
                }

                else
                {
                    _port.SendData((byte)CommandId.InternalCounter, new byte[] { });
                }
            }
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

        private void cmdtimer_Tick(object sender, EventArgs e)
        {
          /*  _port.SendData((byte)10, new byte[] {(byte)toggle});
            if (toggle == 1)
            {
                toggle = 0;
            }
            else
            {
                toggle++;
            }*/
     //       _port.SendData((byte)16);
            //insert auto opto code here
        } 
	}
}
