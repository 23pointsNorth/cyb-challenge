namespace WIFIGUIDemo
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmdDisconnect = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.lbPort = new System.Windows.Forms.Label();
            this.lblIPAddress = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.getYlabel = new System.Windows.Forms.Label();
            this.getAccelerometerlabel = new System.Windows.Forms.Label();
            this.getAccelerometer = new System.Windows.Forms.Button();
            this.getXlabel = new System.Windows.Forms.Label();
            this.getMagnet = new System.Windows.Forms.Button();
            this.drive1secButton = new System.Windows.Forms.Button();
            this.auxLabel = new System.Windows.Forms.Label();
            this.LightLabel = new System.Windows.Forms.Label();
            this.lightLuxButton = new System.Windows.Forms.Button();
            this.tempLabel = new System.Windows.Forms.Label();
            this.tempButton = new System.Windows.Forms.Button();
            this.directionalSpeed = new System.Windows.Forms.PictureBox();
            this.rightSpeed = new System.Windows.Forms.TrackBar();
            this.leftSpeed = new System.Windows.Forms.TrackBar();
            this.rightEncoderLabel = new System.Windows.Forms.Label();
            this.leftEncoderLabel = new System.Windows.Forms.Label();
            this.driveSteps = new System.Windows.Forms.Button();
            this.PositionStatusBox = new System.Windows.Forms.TextBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.rightMotorSpeed = new System.Windows.Forms.TextBox();
            this.leftMotorSpeed = new System.Windows.Forms.TextBox();
            this.setSpeed = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkSwitch2Stat = new System.Windows.Forms.CheckBox();
            this.chkSwitch1Stat = new System.Windows.Forms.CheckBox();
            this.chkGreenStat = new System.Windows.Forms.CheckBox();
            this.chkRedStat = new System.Windows.Forms.CheckBox();
            this.txtCounter = new System.Windows.Forms.TextBox();
            this.chkRed = new System.Windows.Forms.CheckBox();
            this.chkGreen = new System.Windows.Forms.CheckBox();
            this.cmdSwitchLedStatus = new System.Windows.Forms.Button();
            this.cmdGetCount = new System.Windows.Forms.Button();
            this.cmdSetLEDs = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.reqInfo = new System.Windows.Forms.Timer(this.components);
            this.getZlabel = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.directionalSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftSpeed)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdDisconnect);
            this.groupBox1.Controls.Add(this.cmdConnect);
            this.groupBox1.Controls.Add(this.lbPort);
            this.groupBox1.Controls.Add(this.lblIPAddress);
            this.groupBox1.Controls.Add(this.txtPort);
            this.groupBox1.Controls.Add(this.txtIPAddress);
            this.groupBox1.Location = new System.Drawing.Point(821, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 118);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.Location = new System.Drawing.Point(15, 82);
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(75, 23);
            this.cmdDisconnect.TabIndex = 5;
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.UseVisualStyleBackColor = true;
            this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Enabled = false;
            this.cmdConnect.Location = new System.Drawing.Point(138, 82);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(75, 23);
            this.cmdConnect.TabIndex = 4;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(12, 57);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(60, 13);
            this.lbPort.TabIndex = 3;
            this.lbPort.Text = "Server Port";
            // 
            // lblIPAddress
            // 
            this.lblIPAddress.AutoSize = true;
            this.lblIPAddress.Location = new System.Drawing.Point(12, 31);
            this.lblIPAddress.Name = "lblIPAddress";
            this.lblIPAddress.Size = new System.Drawing.Size(92, 13);
            this.lblIPAddress.TabIndex = 2;
            this.lblIPAddress.Text = "Server IP Address";
            // 
            // txtPort
            // 
            this.txtPort.Enabled = false;
            this.txtPort.Location = new System.Drawing.Point(113, 54);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 20);
            this.txtPort.TabIndex = 1;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Enabled = false;
            this.txtIPAddress.Location = new System.Drawing.Point(113, 28);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(100, 20);
            this.txtIPAddress.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.getZlabel);
            this.groupBox2.Controls.Add(this.getYlabel);
            this.groupBox2.Controls.Add(this.getAccelerometerlabel);
            this.groupBox2.Controls.Add(this.getAccelerometer);
            this.groupBox2.Controls.Add(this.getXlabel);
            this.groupBox2.Controls.Add(this.getMagnet);
            this.groupBox2.Controls.Add(this.drive1secButton);
            this.groupBox2.Controls.Add(this.auxLabel);
            this.groupBox2.Controls.Add(this.LightLabel);
            this.groupBox2.Controls.Add(this.lightLuxButton);
            this.groupBox2.Controls.Add(this.tempLabel);
            this.groupBox2.Controls.Add(this.tempButton);
            this.groupBox2.Controls.Add(this.directionalSpeed);
            this.groupBox2.Controls.Add(this.rightSpeed);
            this.groupBox2.Controls.Add(this.leftSpeed);
            this.groupBox2.Controls.Add(this.rightEncoderLabel);
            this.groupBox2.Controls.Add(this.leftEncoderLabel);
            this.groupBox2.Controls.Add(this.driveSteps);
            this.groupBox2.Controls.Add(this.PositionStatusBox);
            this.groupBox2.Controls.Add(this.stopButton);
            this.groupBox2.Controls.Add(this.rightMotorSpeed);
            this.groupBox2.Controls.Add(this.leftMotorSpeed);
            this.groupBox2.Controls.Add(this.setSpeed);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(803, 498);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Visualisation";
            // 
            // getYlabel
            // 
            this.getYlabel.AutoSize = true;
            this.getYlabel.Location = new System.Drawing.Point(527, 277);
            this.getYlabel.Name = "getYlabel";
            this.getYlabel.Size = new System.Drawing.Size(14, 13);
            this.getYlabel.TabIndex = 21;
            this.getYlabel.Text = "Y";
            // 
            // getAccelerometerlabel
            // 
            this.getAccelerometerlabel.AutoSize = true;
            this.getAccelerometerlabel.Location = new System.Drawing.Point(486, 348);
            this.getAccelerometerlabel.Name = "getAccelerometerlabel";
            this.getAccelerometerlabel.Size = new System.Drawing.Size(75, 13);
            this.getAccelerometerlabel.TabIndex = 20;
            this.getAccelerometerlabel.Text = "Accelerometer";
            // 
            // getAccelerometer
            // 
            this.getAccelerometer.Location = new System.Drawing.Point(482, 367);
            this.getAccelerometer.Name = "getAccelerometer";
            this.getAccelerometer.Size = new System.Drawing.Size(108, 23);
            this.getAccelerometer.TabIndex = 19;
            this.getAccelerometer.Text = "Accelerometer";
            this.getAccelerometer.UseVisualStyleBackColor = true;
            // 
            // getXlabel
            // 
            this.getXlabel.AutoSize = true;
            this.getXlabel.Location = new System.Drawing.Point(490, 277);
            this.getXlabel.Name = "getXlabel";
            this.getXlabel.Size = new System.Drawing.Size(14, 13);
            this.getXlabel.TabIndex = 18;
            this.getXlabel.Text = "X";
            // 
            // getMagnet
            // 
            this.getMagnet.Location = new System.Drawing.Point(487, 294);
            this.getMagnet.Name = "getMagnet";
            this.getMagnet.Size = new System.Drawing.Size(101, 23);
            this.getMagnet.TabIndex = 17;
            this.getMagnet.Text = "Get Magnet";
            this.getMagnet.UseVisualStyleBackColor = true;
            this.getMagnet.Click += new System.EventHandler(this.getMagnet_Click);
            // 
            // drive1secButton
            // 
            this.drive1secButton.Location = new System.Drawing.Point(528, 70);
            this.drive1secButton.Name = "drive1secButton";
            this.drive1secButton.Size = new System.Drawing.Size(107, 30);
            this.drive1secButton.TabIndex = 16;
            this.drive1secButton.Text = "Drive for 1 sec";
            this.drive1secButton.UseVisualStyleBackColor = true;
            this.drive1secButton.Click += new System.EventHandler(this.drive1secButton_Click);
            // 
            // auxLabel
            // 
            this.auxLabel.AutoSize = true;
            this.auxLabel.Location = new System.Drawing.Point(527, 213);
            this.auxLabel.Name = "auxLabel";
            this.auxLabel.Size = new System.Drawing.Size(25, 13);
            this.auxLabel.TabIndex = 15;
            this.auxLabel.Text = "Aux";
            // 
            // LightLabel
            // 
            this.LightLabel.AutoSize = true;
            this.LightLabel.Location = new System.Drawing.Point(487, 213);
            this.LightLabel.Name = "LightLabel";
            this.LightLabel.Size = new System.Drawing.Size(30, 13);
            this.LightLabel.TabIndex = 14;
            this.LightLabel.Text = "Light";
            // 
            // lightLuxButton
            // 
            this.lightLuxButton.Location = new System.Drawing.Point(487, 235);
            this.lightLuxButton.Name = "lightLuxButton";
            this.lightLuxButton.Size = new System.Drawing.Size(101, 23);
            this.lightLuxButton.TabIndex = 13;
            this.lightLuxButton.Text = "Get Light Lux";
            this.lightLuxButton.UseVisualStyleBackColor = true;
            this.lightLuxButton.Click += new System.EventHandler(this.lightLuxButton_Click);
            // 
            // tempLabel
            // 
            this.tempLabel.AutoSize = true;
            this.tempLabel.Location = new System.Drawing.Point(490, 148);
            this.tempLabel.Name = "tempLabel";
            this.tempLabel.Size = new System.Drawing.Size(67, 13);
            this.tempLabel.TabIndex = 12;
            this.tempLabel.Text = "Temperature";
            // 
            // tempButton
            // 
            this.tempButton.Location = new System.Drawing.Point(490, 170);
            this.tempButton.Name = "tempButton";
            this.tempButton.Size = new System.Drawing.Size(101, 23);
            this.tempButton.TabIndex = 11;
            this.tempButton.Text = "Get Temperature";
            this.tempButton.UseVisualStyleBackColor = true;
            this.tempButton.Click += new System.EventHandler(this.tempButton_Click);
            // 
            // directionalSpeed
            // 
            this.directionalSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.directionalSpeed.Location = new System.Drawing.Point(194, 133);
            this.directionalSpeed.Name = "directionalSpeed";
            this.directionalSpeed.Size = new System.Drawing.Size(256, 256);
            this.directionalSpeed.TabIndex = 10;
            this.directionalSpeed.TabStop = false;
            this.directionalSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.directionalSpeed_MouseDown);
            this.directionalSpeed.MouseMove += new System.Windows.Forms.MouseEventHandler(this.directionalSpeed_MouseMove);
            this.directionalSpeed.MouseUp += new System.Windows.Forms.MouseEventHandler(this.directionalSpeed_MouseUp);
            // 
            // rightSpeed
            // 
            this.rightSpeed.Location = new System.Drawing.Point(79, 133);
            this.rightSpeed.Maximum = 128;
            this.rightSpeed.Minimum = -127;
            this.rightSpeed.Name = "rightSpeed";
            this.rightSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.rightSpeed.Size = new System.Drawing.Size(45, 258);
            this.rightSpeed.TabIndex = 9;
            this.rightSpeed.ValueChanged += new System.EventHandler(this.rightSpeed_ValueChanged);
            // 
            // leftSpeed
            // 
            this.leftSpeed.Location = new System.Drawing.Point(12, 133);
            this.leftSpeed.Maximum = 128;
            this.leftSpeed.Minimum = -127;
            this.leftSpeed.Name = "leftSpeed";
            this.leftSpeed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.leftSpeed.Size = new System.Drawing.Size(45, 256);
            this.leftSpeed.TabIndex = 8;
            this.leftSpeed.ValueChanged += new System.EventHandler(this.leftSpeed_ValueChanged);
            // 
            // rightEncoderLabel
            // 
            this.rightEncoderLabel.AutoSize = true;
            this.rightEncoderLabel.Location = new System.Drawing.Point(420, 31);
            this.rightEncoderLabel.Name = "rightEncoderLabel";
            this.rightEncoderLabel.Size = new System.Drawing.Size(75, 13);
            this.rightEncoderLabel.TabIndex = 7;
            this.rightEncoderLabel.Text = "Right Encoder";
            // 
            // leftEncoderLabel
            // 
            this.leftEncoderLabel.AutoSize = true;
            this.leftEncoderLabel.Location = new System.Drawing.Point(346, 30);
            this.leftEncoderLabel.Name = "leftEncoderLabel";
            this.leftEncoderLabel.Size = new System.Drawing.Size(68, 13);
            this.leftEncoderLabel.TabIndex = 6;
            this.leftEncoderLabel.Text = "Left Encoder";
            // 
            // driveSteps
            // 
            this.driveSteps.Location = new System.Drawing.Point(226, 47);
            this.driveSteps.Name = "driveSteps";
            this.driveSteps.Size = new System.Drawing.Size(113, 23);
            this.driveSteps.TabIndex = 5;
            this.driveSteps.Text = "Drive Steps";
            this.driveSteps.UseVisualStyleBackColor = true;
            this.driveSteps.Click += new System.EventHandler(this.encoderValueButton_Click);
            // 
            // PositionStatusBox
            // 
            this.PositionStatusBox.Location = new System.Drawing.Point(228, 22);
            this.PositionStatusBox.Name = "PositionStatusBox";
            this.PositionStatusBox.Size = new System.Drawing.Size(111, 20);
            this.PositionStatusBox.TabIndex = 4;
            this.PositionStatusBox.Text = "100";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(7, 77);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(117, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // rightMotorSpeed
            // 
            this.rightMotorSpeed.Location = new System.Drawing.Point(79, 20);
            this.rightMotorSpeed.Name = "rightMotorSpeed";
            this.rightMotorSpeed.Size = new System.Drawing.Size(45, 20);
            this.rightMotorSpeed.TabIndex = 2;
            this.rightMotorSpeed.Text = "50";
            // 
            // leftMotorSpeed
            // 
            this.leftMotorSpeed.Location = new System.Drawing.Point(7, 20);
            this.leftMotorSpeed.Name = "leftMotorSpeed";
            this.leftMotorSpeed.Size = new System.Drawing.Size(50, 20);
            this.leftMotorSpeed.TabIndex = 1;
            this.leftMotorSpeed.Text = "50";
            // 
            // setSpeed
            // 
            this.setSpeed.Location = new System.Drawing.Point(7, 47);
            this.setSpeed.Name = "setSpeed";
            this.setSpeed.Size = new System.Drawing.Size(117, 23);
            this.setSpeed.TabIndex = 0;
            this.setSpeed.Text = "Set Motor Speeds";
            this.setSpeed.UseVisualStyleBackColor = true;
            this.setSpeed.Click += new System.EventHandler(this.setSpeed_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkSwitch2Stat);
            this.groupBox3.Controls.Add(this.chkSwitch1Stat);
            this.groupBox3.Controls.Add(this.chkGreenStat);
            this.groupBox3.Controls.Add(this.chkRedStat);
            this.groupBox3.Controls.Add(this.txtCounter);
            this.groupBox3.Controls.Add(this.chkRed);
            this.groupBox3.Controls.Add(this.chkGreen);
            this.groupBox3.Controls.Add(this.cmdSwitchLedStatus);
            this.groupBox3.Controls.Add(this.cmdGetCount);
            this.groupBox3.Controls.Add(this.cmdSetLEDs);
            this.groupBox3.Location = new System.Drawing.Point(821, 136);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 374);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commands";
            // 
            // chkSwitch2Stat
            // 
            this.chkSwitch2Stat.AutoSize = true;
            this.chkSwitch2Stat.Enabled = false;
            this.chkSwitch2Stat.Location = new System.Drawing.Point(133, 243);
            this.chkSwitch2Stat.Name = "chkSwitch2Stat";
            this.chkSwitch2Stat.Size = new System.Drawing.Size(67, 17);
            this.chkSwitch2Stat.TabIndex = 11;
            this.chkSwitch2Stat.Text = "Switch 2";
            this.chkSwitch2Stat.UseVisualStyleBackColor = true;
            // 
            // chkSwitch1Stat
            // 
            this.chkSwitch1Stat.AutoSize = true;
            this.chkSwitch1Stat.Enabled = false;
            this.chkSwitch1Stat.Location = new System.Drawing.Point(28, 243);
            this.chkSwitch1Stat.Name = "chkSwitch1Stat";
            this.chkSwitch1Stat.Size = new System.Drawing.Size(67, 17);
            this.chkSwitch1Stat.TabIndex = 10;
            this.chkSwitch1Stat.Text = "Switch 1";
            this.chkSwitch1Stat.UseVisualStyleBackColor = true;
            // 
            // chkGreenStat
            // 
            this.chkGreenStat.AutoSize = true;
            this.chkGreenStat.Enabled = false;
            this.chkGreenStat.Location = new System.Drawing.Point(133, 219);
            this.chkGreenStat.Name = "chkGreenStat";
            this.chkGreenStat.Size = new System.Drawing.Size(79, 17);
            this.chkGreenStat.TabIndex = 9;
            this.chkGreenStat.Text = "Green LED";
            this.chkGreenStat.UseVisualStyleBackColor = true;
            // 
            // chkRedStat
            // 
            this.chkRedStat.AutoSize = true;
            this.chkRedStat.Enabled = false;
            this.chkRedStat.Location = new System.Drawing.Point(28, 219);
            this.chkRedStat.Name = "chkRedStat";
            this.chkRedStat.Size = new System.Drawing.Size(70, 17);
            this.chkRedStat.TabIndex = 8;
            this.chkRedStat.Text = "Red LED";
            this.chkRedStat.UseVisualStyleBackColor = true;
            // 
            // txtCounter
            // 
            this.txtCounter.Location = new System.Drawing.Point(15, 99);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.Size = new System.Drawing.Size(89, 20);
            this.txtCounter.TabIndex = 7;
            this.txtCounter.Text = "0";
            // 
            // chkRed
            // 
            this.chkRed.AutoSize = true;
            this.chkRed.Location = new System.Drawing.Point(133, 24);
            this.chkRed.Name = "chkRed";
            this.chkRed.Size = new System.Drawing.Size(70, 17);
            this.chkRed.TabIndex = 5;
            this.chkRed.Text = "Red LED";
            this.chkRed.UseVisualStyleBackColor = true;
            // 
            // chkGreen
            // 
            this.chkGreen.AutoSize = true;
            this.chkGreen.Location = new System.Drawing.Point(15, 24);
            this.chkGreen.Name = "chkGreen";
            this.chkGreen.Size = new System.Drawing.Size(79, 17);
            this.chkGreen.TabIndex = 4;
            this.chkGreen.Text = "Green LED";
            this.chkGreen.UseVisualStyleBackColor = true;
            // 
            // cmdSwitchLedStatus
            // 
            this.cmdSwitchLedStatus.Location = new System.Drawing.Point(62, 266);
            this.cmdSwitchLedStatus.Name = "cmdSwitchLedStatus";
            this.cmdSwitchLedStatus.Size = new System.Drawing.Size(100, 21);
            this.cmdSwitchLedStatus.TabIndex = 3;
            this.cmdSwitchLedStatus.Text = "Get Status";
            this.cmdSwitchLedStatus.UseVisualStyleBackColor = true;
            this.cmdSwitchLedStatus.Click += new System.EventHandler(this.cmdSwitchLedStatus_Click);
            // 
            // cmdGetCount
            // 
            this.cmdGetCount.Location = new System.Drawing.Point(113, 99);
            this.cmdGetCount.Name = "cmdGetCount";
            this.cmdGetCount.Size = new System.Drawing.Size(100, 21);
            this.cmdGetCount.TabIndex = 1;
            this.cmdGetCount.Text = "Counter";
            this.cmdGetCount.UseVisualStyleBackColor = true;
            this.cmdGetCount.Click += new System.EventHandler(this.cmdGetCount_Click);
            // 
            // cmdSetLEDs
            // 
            this.cmdSetLEDs.Location = new System.Drawing.Point(15, 47);
            this.cmdSetLEDs.Name = "cmdSetLEDs";
            this.cmdSetLEDs.Size = new System.Drawing.Size(198, 23);
            this.cmdSetLEDs.TabIndex = 0;
            this.cmdSetLEDs.Text = "Set LEDs";
            this.cmdSetLEDs.UseVisualStyleBackColor = true;
            this.cmdSetLEDs.Click += new System.EventHandler(this.cmdSetLEDs_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // reqInfo
            // 
            this.reqInfo.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // getZlabel
            // 
            this.getZlabel.AutoSize = true;
            this.getZlabel.Location = new System.Drawing.Point(574, 277);
            this.getZlabel.Name = "getZlabel";
            this.getZlabel.Size = new System.Drawing.Size(14, 13);
            this.getZlabel.TabIndex = 22;
            this.getZlabel.Text = "Z";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 522);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "Rover GUI";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.directionalSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rightSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.leftSpeed)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lblIPAddress;
        private System.Windows.Forms.Button cmdDisconnect;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button cmdSwitchLedStatus;
        private System.Windows.Forms.Button cmdGetCount;
        private System.Windows.Forms.Button cmdSetLEDs;
        private System.Windows.Forms.CheckBox chkRed;
        private System.Windows.Forms.CheckBox chkGreen;
        private System.Windows.Forms.TextBox txtCounter;
        private System.Windows.Forms.CheckBox chkSwitch2Stat;
        private System.Windows.Forms.CheckBox chkSwitch1Stat;
        private System.Windows.Forms.CheckBox chkGreenStat;
        private System.Windows.Forms.CheckBox chkRedStat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer reqInfo;
        private System.Windows.Forms.TextBox rightMotorSpeed;
        private System.Windows.Forms.TextBox leftMotorSpeed;
        private System.Windows.Forms.Button setSpeed;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button driveSteps;
        private System.Windows.Forms.TextBox PositionStatusBox;
        private System.Windows.Forms.Label leftEncoderLabel;
        private System.Windows.Forms.Label rightEncoderLabel;
        private System.Windows.Forms.TrackBar leftSpeed;
        private System.Windows.Forms.TrackBar rightSpeed;
        private System.Windows.Forms.PictureBox directionalSpeed;
        private System.Windows.Forms.Label tempLabel;
        private System.Windows.Forms.Button tempButton;
        private System.Windows.Forms.Label auxLabel;
        private System.Windows.Forms.Label LightLabel;
        private System.Windows.Forms.Button lightLuxButton;
        private System.Windows.Forms.Button drive1secButton;
        private System.Windows.Forms.Label getXlabel;
        private System.Windows.Forms.Button getMagnet;
        private System.Windows.Forms.Label getAccelerometerlabel;
        private System.Windows.Forms.Button getAccelerometer;
        private System.Windows.Forms.Label getYlabel;
        private System.Windows.Forms.Label getZlabel;
    }
}

