namespace URSA.Template
{
	partial class BaseStationGUI
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
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSendCmd3 = new System.Windows.Forms.Button();
            this.richTextBoxInput = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelRecvCount = new System.Windows.Forms.Label();
            this.timerGUIUpdate = new System.Windows.Forms.Timer(this.components);
            this.labelRSSI = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBarRSSI = new System.Windows.Forms.ProgressBar();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.lultra = new System.Windows.Forms.Label();
            this.rultra = new System.Windows.Forms.Label();
            this.cmdtimer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.his3 = new System.Windows.Forms.Label();
            this.his2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(15, 12);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "buttonOpen";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(15, 41);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSendCmd3
            // 
            this.buttonSendCmd3.Location = new System.Drawing.Point(16, 19);
            this.buttonSendCmd3.Name = "buttonSendCmd3";
            this.buttonSendCmd3.Size = new System.Drawing.Size(118, 23);
            this.buttonSendCmd3.TabIndex = 3;
            this.buttonSendCmd3.Text = "buttonSendCmd";
            this.buttonSendCmd3.UseVisualStyleBackColor = true;
            this.buttonSendCmd3.Click += new System.EventHandler(this.buttonSendCmd3_Click);
            // 
            // richTextBoxInput
            // 
            this.richTextBoxInput.Location = new System.Drawing.Point(15, 225);
            this.richTextBoxInput.Name = "richTextBoxInput";
            this.richTextBoxInput.Size = new System.Drawing.Size(388, 126);
            this.richTextBoxInput.TabIndex = 4;
            this.richTextBoxInput.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelRecvCount);
            this.groupBox1.Controls.Add(this.buttonSendCmd3);
            this.groupBox1.Location = new System.Drawing.Point(136, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 57);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recv Count";
            // 
            // labelRecvCount
            // 
            this.labelRecvCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecvCount.Location = new System.Drawing.Point(140, 16);
            this.labelRecvCount.Name = "labelRecvCount";
            this.labelRecvCount.Size = new System.Drawing.Size(121, 27);
            this.labelRecvCount.TabIndex = 0;
            this.labelRecvCount.Text = "0";
            this.labelRecvCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerGUIUpdate
            // 
            this.timerGUIUpdate.Enabled = true;
            this.timerGUIUpdate.Tick += new System.EventHandler(this.timerGUIUpdate_Tick);
            // 
            // labelRSSI
            // 
            this.labelRSSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRSSI.Location = new System.Drawing.Point(13, 16);
            this.labelRSSI.Name = "labelRSSI";
            this.labelRSSI.Size = new System.Drawing.Size(248, 27);
            this.labelRSSI.TabIndex = 0;
            this.labelRSSI.Text = "0";
            this.labelRSSI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelRSSI);
            this.groupBox2.Location = new System.Drawing.Point(136, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 57);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "RSSI";
            // 
            // progressBarRSSI
            // 
            this.progressBarRSSI.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBarRSSI.Location = new System.Drawing.Point(0, 362);
            this.progressBarRSSI.Maximum = 255;
            this.progressBarRSSI.Name = "progressBarRSSI";
            this.progressBarRSSI.Size = new System.Drawing.Size(688, 16);
            this.progressBarRSSI.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(35, 81);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(21, 17);
            this.listBox1.TabIndex = 8;
            this.listBox1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 142);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(46, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 183);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(46, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Command byte:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Data byte:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(98, 183);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(46, 20);
            this.textBox5.TabIndex = 9;
            this.textBox5.Text = "-1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(432, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Left ultrasonic";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(425, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Right ultrasonic";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(522, 35);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(109, 13);
            this.progressBar1.TabIndex = 11;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(523, 72);
            this.progressBar2.Maximum = 1000;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(109, 13);
            this.progressBar2.TabIndex = 11;
            // 
            // lultra
            // 
            this.lultra.AutoSize = true;
            this.lultra.Location = new System.Drawing.Point(646, 36);
            this.lultra.Name = "lultra";
            this.lultra.Size = new System.Drawing.Size(13, 13);
            this.lultra.TabIndex = 12;
            this.lultra.Text = "0";
            // 
            // rultra
            // 
            this.rultra.AutoSize = true;
            this.rultra.Location = new System.Drawing.Point(646, 72);
            this.rultra.Name = "rultra";
            this.rultra.Size = new System.Drawing.Size(13, 13);
            this.rultra.TabIndex = 12;
            this.rultra.Text = "0";
            // 
            // cmdtimer
            // 
            this.cmdtimer.Interval = 750;
            this.cmdtimer.Tick += new System.EventHandler(this.cmdtimer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(507, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "hist2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(507, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "hist3";
            // 
            // his3
            // 
            this.his3.AutoSize = true;
            this.his3.Location = new System.Drawing.Point(548, 199);
            this.his3.Name = "his3";
            this.his3.Size = new System.Drawing.Size(35, 13);
            this.his3.TabIndex = 13;
            this.his3.Text = "label5";
            // 
            // his2
            // 
            this.his2.AutoSize = true;
            this.his2.Location = new System.Drawing.Point(548, 174);
            this.his2.Name = "his2";
            this.his2.Size = new System.Drawing.Size(35, 13);
            this.his2.TabIndex = 13;
            this.his2.Text = "label5";
            // 
            // BaseStationGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 378);
            this.Controls.Add(this.his3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.his2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.rultra);
            this.Controls.Add(this.lultra);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.progressBarRSSI);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBoxInput);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonOpen);
            this.Name = "BaseStationGUI";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseStationGUI_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonOpen;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSendCmd3;
		private System.Windows.Forms.RichTextBox richTextBoxInput;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label labelRecvCount;
		private System.Windows.Forms.Timer timerGUIUpdate;
		private System.Windows.Forms.Label labelRSSI;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ProgressBar progressBarRSSI;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.Label lultra;
        private System.Windows.Forms.Label rultra;
        private System.Windows.Forms.Timer cmdtimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label his3;
        private System.Windows.Forms.Label his2;
	}
}

