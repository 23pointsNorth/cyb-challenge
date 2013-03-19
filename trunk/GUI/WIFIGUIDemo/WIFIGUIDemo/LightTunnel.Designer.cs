namespace WIFIGUIDemo
{
    partial class LightTunnel
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lightIntensityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tunnelMapButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.lightPosTimer = new System.Windows.Forms.Timer(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.forwardDirectionRadioButton = new System.Windows.Forms.RadioButton();
            this.backwardsDirectionRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.lightIntensityChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lightIntensityChart
            // 
            this.lightIntensityChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.Name = "ChartArea1";
            this.lightIntensityChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            this.lightIntensityChart.Legends.Add(legend1);
            this.lightIntensityChart.Location = new System.Drawing.Point(12, 41);
            this.lightIntensityChart.Name = "lightIntensityChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "lightPathPoint";
            this.lightIntensityChart.Series.Add(series1);
            this.lightIntensityChart.Size = new System.Drawing.Size(645, 251);
            this.lightIntensityChart.TabIndex = 0;
            this.lightIntensityChart.Text = "Light Tunnel Chart";
            title1.Name = "Title1";
            title1.Text = "Light Intensity vs Distance Graph";
            this.lightIntensityChart.Titles.Add(title1);
            // 
            // tunnelMapButton
            // 
            this.tunnelMapButton.Location = new System.Drawing.Point(12, 12);
            this.tunnelMapButton.Name = "tunnelMapButton";
            this.tunnelMapButton.Size = new System.Drawing.Size(92, 23);
            this.tunnelMapButton.TabIndex = 1;
            this.tunnelMapButton.Text = "Map Tunnel";
            this.tunnelMapButton.UseVisualStyleBackColor = true;
            this.tunnelMapButton.Click += new System.EventHandler(this.tunnelMapButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(110, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(87, 22);
            this.stopButton.TabIndex = 2;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(590, 12);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(67, 22);
            this.clearButton.TabIndex = 3;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // lightPosTimer
            // 
            this.lightPosTimer.Interval = 20;
            this.lightPosTimer.Tick += new System.EventHandler(this.lightPosTimer_Tick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(509, 12);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 22);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save to file";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.backwardsDirectionRadioButton);
            this.groupBox1.Controls.Add(this.forwardDirectionRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(203, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(157, 32);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Direction";
            // 
            // forwardDirectionRadioButton
            // 
            this.forwardDirectionRadioButton.AutoSize = true;
            this.forwardDirectionRadioButton.Checked = true;
            this.forwardDirectionRadioButton.Location = new System.Drawing.Point(6, 12);
            this.forwardDirectionRadioButton.Name = "forwardDirectionRadioButton";
            this.forwardDirectionRadioButton.Size = new System.Drawing.Size(63, 17);
            this.forwardDirectionRadioButton.TabIndex = 0;
            this.forwardDirectionRadioButton.TabStop = true;
            this.forwardDirectionRadioButton.Text = "Forward";
            this.forwardDirectionRadioButton.UseVisualStyleBackColor = true;
            this.forwardDirectionRadioButton.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // backwardsDirectionRadioButton
            // 
            this.backwardsDirectionRadioButton.AutoSize = true;
            this.backwardsDirectionRadioButton.Location = new System.Drawing.Point(75, 12);
            this.backwardsDirectionRadioButton.Name = "backwardsDirectionRadioButton";
            this.backwardsDirectionRadioButton.Size = new System.Drawing.Size(78, 17);
            this.backwardsDirectionRadioButton.TabIndex = 1;
            this.backwardsDirectionRadioButton.Text = "Backwards";
            this.backwardsDirectionRadioButton.UseVisualStyleBackColor = true;
            this.backwardsDirectionRadioButton.CheckedChanged += new System.EventHandler(this.backwardsDirectionRadioButton_CheckedChanged);
            // 
            // LightTunnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 304);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.tunnelMapButton);
            this.Controls.Add(this.lightIntensityChart);
            this.Name = "LightTunnel";
            this.Text = "LightTunnel";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LightTunnel_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LightTunnel_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.lightIntensityChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tunnelMapButton;
        private System.Windows.Forms.Button stopButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart lightIntensityChart;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Timer lightPosTimer;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton backwardsDirectionRadioButton;
        private System.Windows.Forms.RadioButton forwardDirectionRadioButton;
    }
}