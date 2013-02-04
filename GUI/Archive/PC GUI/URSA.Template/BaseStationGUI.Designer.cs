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
            this.progressBarRSSI.Location = new System.Drawing.Point(0, 368);
            this.progressBarRSSI.Maximum = 255;
            this.progressBarRSSI.Name = "progressBarRSSI";
            this.progressBarRSSI.Size = new System.Drawing.Size(412, 16);
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
            // BaseStationGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 384);
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
	}
}

