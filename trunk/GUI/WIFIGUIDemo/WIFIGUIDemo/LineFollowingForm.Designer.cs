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
            this.max_Label = new System.Windows.Forms.Label();
            this.min_Label = new System.Windows.Forms.Label();
            this.turnTimer = new System.Windows.Forms.Timer(this.components);
            this.waitTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // followLineButton
            // 
            this.followLineButton.Location = new System.Drawing.Point(32, 17);
            this.followLineButton.Name = "followLineButton";
            this.followLineButton.Size = new System.Drawing.Size(75, 23);
            this.followLineButton.TabIndex = 0;
            this.followLineButton.Text = "Follow Line";
            this.followLineButton.UseVisualStyleBackColor = true;
            this.followLineButton.Click += new System.EventHandler(this.followLineButton_Click);
            // 
            // calibrateButton
            // 
            this.calibrateButton.Location = new System.Drawing.Point(32, 46);
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
            this.leftValueLabel.Location = new System.Drawing.Point(124, 25);
            this.leftValueLabel.Name = "leftValueLabel";
            this.leftValueLabel.Size = new System.Drawing.Size(55, 13);
            this.leftValueLabel.TabIndex = 2;
            this.leftValueLabel.Text = "Left Value";
            // 
            // rightValueLabel
            // 
            this.rightValueLabel.AutoSize = true;
            this.rightValueLabel.Location = new System.Drawing.Point(185, 25);
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
            // max_Label
            // 
            this.max_Label.AutoSize = true;
            this.max_Label.Location = new System.Drawing.Point(32, 76);
            this.max_Label.Name = "max_Label";
            this.max_Label.Size = new System.Drawing.Size(27, 13);
            this.max_Label.TabIndex = 4;
            this.max_Label.Text = "Max";
            // 
            // min_Label
            // 
            this.min_Label.AutoSize = true;
            this.min_Label.Location = new System.Drawing.Point(72, 76);
            this.min_Label.Name = "min_Label";
            this.min_Label.Size = new System.Drawing.Size(24, 13);
            this.min_Label.TabIndex = 5;
            this.min_Label.Text = "Min";
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
            // LineFollowingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 311);
            this.Controls.Add(this.min_Label);
            this.Controls.Add(this.max_Label);
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
        private System.Windows.Forms.Label max_Label;
        private System.Windows.Forms.Label min_Label;
        private System.Windows.Forms.Timer turnTimer;
        private System.Windows.Forms.Timer waitTimer;
    }
}