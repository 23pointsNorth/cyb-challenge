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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.lightIntensityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tunnelMapButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.lightPosTimer = new System.Windows.Forms.Timer(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.lightIntensityChart)).BeginInit();
            this.SuspendLayout();
            // 
            // lightIntensityChart
            // 
            this.lightIntensityChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.Name = "ChartArea1";
            this.lightIntensityChart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend3.Name = "Legend1";
            this.lightIntensityChart.Legends.Add(legend3);
            this.lightIntensityChart.Location = new System.Drawing.Point(12, 41);
            this.lightIntensityChart.Name = "lightIntensityChart";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "lightPathPoint";
            this.lightIntensityChart.Series.Add(series3);
            this.lightIntensityChart.Size = new System.Drawing.Size(645, 251);
            this.lightIntensityChart.TabIndex = 0;
            this.lightIntensityChart.Text = "Light Tunnel Chart";
            title3.Name = "Title1";
            title3.Text = "Light Intensity vs Distance Graph";
            this.lightIntensityChart.Titles.Add(title3);
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
            // LightTunnel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 304);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tunnelMapButton;
        private System.Windows.Forms.Button stopButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart lightIntensityChart;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Timer lightPosTimer;
        private System.Windows.Forms.Button saveButton;
    }
}