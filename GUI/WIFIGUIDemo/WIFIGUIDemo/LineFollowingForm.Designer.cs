namespace WIFIGUIDemo
{
    partial class LineFollowingForm
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
            this.followLineButton = new System.Windows.Forms.Button();
            this.calibrateButton = new System.Windows.Forms.Button();
            this.leftValueLabel = new System.Windows.Forms.Label();
            this.rightValueLabel = new System.Windows.Forms.Label();
            this.calibrationTimer = new System.Windows.Forms.Timer(this.components);
            this.dataTimer = new System.Windows.Forms.Timer(this.components);
            this.turnTimer = new System.Windows.Forms.Timer(this.components);
            this.waitTimer = new System.Windows.Forms.Timer(this.components);
            this.calibrationStatusLabel = new System.Windows.Forms.Label();
            this.maxCalibTextBox = new System.Windows.Forms.TextBox();
            this.minCalibTextBox = new System.Windows.Forms.TextBox();
            this.onLineStatusLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // followLineButton
            // 
            this.followLineButton.Location = new System.Drawing.Point(12, 12);
            this.followLineButton.Name = "followLineButton";
            this.followLineButton.Size = new System.Drawing.Size(75, 23);
            this.followLineButton.TabIndex = 0;
            this.followLineButton.Text = "Follow Line";
            this.followLineButton.UseVisualStyleBackColor = true;
            this.followLineButton.Click += new System.EventHandler(this.followLineButton_Click);
            // 
            // calibrateButton
            // 
            this.calibrateButton.Location = new System.Drawing.Point(12, 41);
            this.calibrateButton.Name = "calibrateButton";
            this.calibrateButton.Size = new System.Drawing.Size(75, 23);
            this.calibrateButton.TabIndex = 1;
            this.calibrateButton.Text = "Calibrate";
            this.calibrateButton.UseVisualStyleBackColor = true;
            this.calibrateButton.Click += new System.EventHandler(this.calibrateButton_Click);
            // 
            // leftValueLabel
            // 
            this.leftValueLabel.AutoSize = true;
            this.leftValueLabel.Location = new System.Drawing.Point(93, 12);
            this.leftValueLabel.Name = "leftValueLabel";
            this.leftValueLabel.Size = new System.Drawing.Size(55, 13);
            this.leftValueLabel.TabIndex = 2;
            this.leftValueLabel.Text = "Left Value";
            // 
            // rightValueLabel
            // 
            this.rightValueLabel.AutoSize = true;
            this.rightValueLabel.Location = new System.Drawing.Point(154, 12);
            this.rightValueLabel.Name = "rightValueLabel";
            this.rightValueLabel.Size = new System.Drawing.Size(62, 13);
            this.rightValueLabel.TabIndex = 3;
            this.rightValueLabel.Text = "Right Value";
            // 
            // calibrationTimer
            // 
            this.calibrationTimer.Interval = 300;
            // 
            // dataTimer
            // 
            this.dataTimer.Interval = 75;
            // 
            // turnTimer
            // 
            this.turnTimer.Interval = 1000;
            this.turnTimer.Tick += new System.EventHandler(this.turnTimer_Tick);
            // 
            // waitTimer
            // 
            this.waitTimer.Interval = 1000;
            this.waitTimer.Tick += new System.EventHandler(this.waitTimer_Tick);
            // 
            // calibrationStatusLabel
            // 
            this.calibrationStatusLabel.AutoSize = true;
            this.calibrationStatusLabel.Location = new System.Drawing.Point(9, 67);
            this.calibrationStatusLabel.Name = "calibrationStatusLabel";
            this.calibrationStatusLabel.Size = new System.Drawing.Size(73, 13);
            this.calibrationStatusLabel.TabIndex = 6;
            this.calibrationStatusLabel.Text = "Calibration Off";
            // 
            // maxCalibTextBox
            // 
            this.maxCalibTextBox.Location = new System.Drawing.Point(12, 83);
            this.maxCalibTextBox.Name = "maxCalibTextBox";
            this.maxCalibTextBox.Size = new System.Drawing.Size(28, 20);
            this.maxCalibTextBox.TabIndex = 7;
            this.maxCalibTextBox.Text = "520";
            this.maxCalibTextBox.TextChanged += new System.EventHandler(this.maxCalibTextBox_TextChanged);
            // 
            // minCalibTextBox
            // 
            this.minCalibTextBox.Location = new System.Drawing.Point(46, 83);
            this.minCalibTextBox.Name = "minCalibTextBox";
            this.minCalibTextBox.Size = new System.Drawing.Size(28, 20);
            this.minCalibTextBox.TabIndex = 8;
            this.minCalibTextBox.Text = "10";
            this.minCalibTextBox.TextChanged += new System.EventHandler(this.minCalibTextBox_TextChanged);
            // 
            // onLineStatusLabel
            // 
            this.onLineStatusLabel.AutoSize = true;
            this.onLineStatusLabel.Location = new System.Drawing.Point(12, 106);
            this.onLineStatusLabel.Name = "onLineStatusLabel";
            this.onLineStatusLabel.Size = new System.Drawing.Size(42, 13);
            this.onLineStatusLabel.TabIndex = 9;
            this.onLineStatusLabel.Text = "IR data";
            // 
            // LineFollowingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 311);
            this.Controls.Add(this.onLineStatusLabel);
            this.Controls.Add(this.minCalibTextBox);
            this.Controls.Add(this.maxCalibTextBox);
            this.Controls.Add(this.calibrationStatusLabel);
            this.Controls.Add(this.rightValueLabel);
            this.Controls.Add(this.leftValueLabel);
            this.Controls.Add(this.calibrateButton);
            this.Controls.Add(this.followLineButton);
            this.Name = "LineFollowingForm";
            this.Text = "LineFollowingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LineFollowingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button followLineButton;
        private System.Windows.Forms.Button calibrateButton;
        private System.Windows.Forms.Label leftValueLabel;
        private System.Windows.Forms.Label rightValueLabel;
        private System.Windows.Forms.Timer calibrationTimer;
        private System.Windows.Forms.Timer dataTimer;
        private System.Windows.Forms.Timer turnTimer;
        private System.Windows.Forms.Timer waitTimer;
        private System.Windows.Forms.Label calibrationStatusLabel;
        private System.Windows.Forms.TextBox maxCalibTextBox;
        private System.Windows.Forms.TextBox minCalibTextBox;
        private System.Windows.Forms.Label onLineStatusLabel;
    }
}