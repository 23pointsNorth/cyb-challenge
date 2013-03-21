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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.distanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // followLineButton
            // 
            this.followLineButton.Location = new System.Drawing.Point(14, 12);
            this.followLineButton.Name = "followLineButton";
            this.followLineButton.Size = new System.Drawing.Size(87, 23);
            this.followLineButton.TabIndex = 0;
            this.followLineButton.Text = "Follow Line";
            this.followLineButton.UseVisualStyleBackColor = true;
            this.followLineButton.Click += new System.EventHandler(this.followLineButton_Click);
            // 
            // calibrateButton
            // 
            this.calibrateButton.Location = new System.Drawing.Point(14, 41);
            this.calibrateButton.Name = "calibrateButton";
            this.calibrateButton.Size = new System.Drawing.Size(87, 23);
            this.calibrateButton.TabIndex = 1;
            this.calibrateButton.Text = "Calibrate";
            this.calibrateButton.UseVisualStyleBackColor = true;
            this.calibrateButton.Click += new System.EventHandler(this.calibrateButton_Click);
            // 
            // leftValueLabel
            // 
            this.leftValueLabel.AutoSize = true;
            this.leftValueLabel.Location = new System.Drawing.Point(108, 12);
            this.leftValueLabel.Name = "leftValueLabel";
            this.leftValueLabel.Size = new System.Drawing.Size(65, 13);
            this.leftValueLabel.TabIndex = 2;
            this.leftValueLabel.Text = "Left Value";
            // 
            // rightValueLabel
            // 
            this.rightValueLabel.AutoSize = true;
            this.rightValueLabel.Location = new System.Drawing.Point(180, 12);
            this.rightValueLabel.Name = "rightValueLabel";
            this.rightValueLabel.Size = new System.Drawing.Size(73, 13);
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
            this.calibrationStatusLabel.Location = new System.Drawing.Point(10, 67);
            this.calibrationStatusLabel.Name = "calibrationStatusLabel";
            this.calibrationStatusLabel.Size = new System.Drawing.Size(88, 13);
            this.calibrationStatusLabel.TabIndex = 6;
            this.calibrationStatusLabel.Text = "Calibration Off";
            // 
            // maxCalibTextBox
            // 
            this.maxCalibTextBox.Location = new System.Drawing.Point(14, 83);
            this.maxCalibTextBox.Name = "maxCalibTextBox";
            this.maxCalibTextBox.Size = new System.Drawing.Size(32, 20);
            this.maxCalibTextBox.TabIndex = 7;
            this.maxCalibTextBox.Text = "320";
            this.maxCalibTextBox.TextChanged += new System.EventHandler(this.maxCalibTextBox_TextChanged);
            // 
            // minCalibTextBox
            // 
            this.minCalibTextBox.Location = new System.Drawing.Point(54, 83);
            this.minCalibTextBox.Name = "minCalibTextBox";
            this.minCalibTextBox.Size = new System.Drawing.Size(32, 20);
            this.minCalibTextBox.TabIndex = 8;
            this.minCalibTextBox.Text = "20";
            this.minCalibTextBox.TextChanged += new System.EventHandler(this.minCalibTextBox_TextChanged);
            // 
            // onLineStatusLabel
            // 
            this.onLineStatusLabel.AutoSize = true;
            this.onLineStatusLabel.Location = new System.Drawing.Point(14, 106);
            this.onLineStatusLabel.Name = "onLineStatusLabel";
            this.onLineStatusLabel.Size = new System.Drawing.Size(49, 13);
            this.onLineStatusLabel.TabIndex = 9;
            this.onLineStatusLabel.Text = "IR data";
            // 
            // distanceChart
            // 
            chartArea4.Name = "ChartArea1";
            this.distanceChart.ChartAreas.Add(chartArea4);
            legend4.Enabled = false;
            legend4.Name = "Legend1";
            this.distanceChart.Legends.Add(legend4);
            this.distanceChart.Location = new System.Drawing.Point(111, 41);
            this.distanceChart.Name = "distanceChart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series7.Legend = "Legend1";
            series7.Name = "left";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series8.Legend = "Legend1";
            series8.Name = "right";
            this.distanceChart.Series.Add(series7);
            this.distanceChart.Series.Add(series8);
            this.distanceChart.Size = new System.Drawing.Size(300, 210);
            this.distanceChart.TabIndex = 10;
            this.distanceChart.Text = "chart1";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(14, 228);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(87, 23);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // LineFollowingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(425, 261);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.distanceChart);
            this.Controls.Add(this.onLineStatusLabel);
            this.Controls.Add(this.minCalibTextBox);
            this.Controls.Add(this.maxCalibTextBox);
            this.Controls.Add(this.calibrationStatusLabel);
            this.Controls.Add(this.rightValueLabel);
            this.Controls.Add(this.leftValueLabel);
            this.Controls.Add(this.calibrateButton);
            this.Controls.Add(this.followLineButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "LineFollowingForm";
            this.Text = "LineFollowingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LineFollowingForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.distanceChart)).EndInit();
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
        private System.Windows.Forms.DataVisualization.Charting.Chart distanceChart;
        private System.Windows.Forms.Button clearButton;
    }
}