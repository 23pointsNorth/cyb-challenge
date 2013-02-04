using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RUSA.Tools;

namespace RUSA.Template
{
	public partial class BaseStationGUI : Form
	{
		private RUSAPort _port;
	    private int _channel = 10;

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
                _port.Dispose();
            }
        }
        
        /// <summary>
		/// The method fired in reply to the buttonOpen button being pressed
		/// </summary>
		/// <param name="sender">Originating button instance</param>
		/// <param name="e">Button event arguments</param>
		private void buttonOpen_Click(object sender, EventArgs e)
        {
            var useSerialPort = true;
            
            if (_port == null)
            {
                if (useSerialPort)
                {
                    //using commport
                    _port = Utilities.CreatePort(RUSAPort.SerialMode.COM, RUSAPort.PortName.COM1, _channel);
                }
                else
                {
                    //using dongle
                    _port = Utilities.CreatePort();
                }
                
                if (_port != null)
                {
                    /* Hookup a method written in this class to respond to the URSAport instance defined as 
                * _port, this is semanticaly identical to the hookup of a button's click event.
                * Visual Studio however hides the form control hookups in the BaseStationGUI.Designer.cs code
                * behind file, this is accessable by expanding the form in the Solution Explorer */
                    _port.OnMessageReceived += new RUSAPort.MessageReceivedHandler(_port_onMessageReceived);
                }
            }
            
            if (_port != null && _port.ScanForFTDISerial())
            {
                _port.Open(RUSAPort.PortName.COM1);
            }
            else
            {
                MessageBox.Show("Could not connect!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
					var command = (CommandId)message.GetValue(1);

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
		/// <param name="sender">Originating button instance</param>
		/// <param name="e">Button event arguments</param>
		private void buttonClose_Click(object sender, EventArgs e)
		{
			if (_port != null)
			{
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
            
            _port.SendData((byte)CommandId.InternalCounter, new byte[] { });
		}

		/// <summary>
		/// Fires at intervals defined by the GUI timer control
		/// </summary>
		/// <param name="sender">Originating timer instance</param>
		/// <param name="e">Time event arguments</param>
		private void timerGUIUpdate_Tick(object sender, EventArgs e)
		{
			// Code to ensure buttons are only available when desired, based around the state of the port
			
			if (_port == null || !_port.IsOpen)
			{
				buttonOpen.Enabled = true;
			}
			else
			{
				buttonOpen.Enabled = false;
			}

			buttonClose.Enabled = buttonSendCmd3.Enabled = !buttonOpen.Enabled;
		}
	}
}
