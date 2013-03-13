namespace WIFIGUIDemo
{
    partial class SeismicActivityForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.clearButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.seismicActivitybutton = new System.Windows.Forms.Button();
            this.SeismicActivityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.AccelDataLabel = new System.Windows.Forms.Label();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.getValButton = new System.Windows.Forms.Button();
            this.getAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SeismicActivityChart)).BeginInit();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(740, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(67, 22);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(380, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(87, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // seismicActivitybutton
            // 
            this.seismicActivitybutton.Location = new System.Drawing.Point(12, 5);
            this.seismicActivitybutton.Name = "seismicActivitybutton";
            this.seismicActivitybutton.Size = new System.Drawing.Size(141, 23);
            this.seismicActivitybutton.TabIndex = 5;
            this.seismicActivitybutton.Text = "Map Seismic Activity - Off";
            this.seismicActivitybutton.UseVisualStyleBackColor = true;
            this.seismicActivitybutton.Click += new System.EventHandler(this.seismicActivityButton_Click);
            // 
            // SeismicActivityChart
            // 
            chartArea1.Name = "ChartArea1";
            this.SeismicActivityChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            this.SeismicActivityChart.Legends.Add(legend1);
            this.SeismicActivityChart.Location = new System.Drawing.Point(12, 34);
            this.SeismicActivityChart.Name = "SeismicActivityChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Accelx";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Accely";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series3.Legend = "Legend1";
            series3.Name = "Accelz";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.SeismicActivityChart.Series.Add(series1);
            this.SeismicActivityChart.Series.Add(series2);
            this.SeismicActivityChart.Series.Add(series3);
            this.SeismicActivityChart.Size = new System.Drawing.Size(790, 251);
            this.SeismicActivityChart.TabIndex = 4;
            this.SeismicActivityChart.Text = "Light Tunnel Chart";
            title1.Name = "IR Intesity vs Distance";
            this.SeismicActivityChart.Titles.Add(title1);
            // 
            // AccelDataLabel
            // 
            this.AccelDataLabel.AutoSize = true;
            this.AccelDataLabel.Location = new System.Drawing.Point(473, 10);
            this.AccelDataLabel.Name = "AccelDataLabel";
            this.AccelDataLabel.Size = new System.Drawing.Size(60, 13);
            this.AccelDataLabel.TabIndex = 8;
            this.AccelDataLabel.Text = "Accel Data";
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(653, 4);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(81, 23);
            this.saveDataButton.TabIndex = 9;
            this.saveDataButton.Text = "Save Data";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // getValButton
            // 
            this.getValButton.Location = new System.Drawing.Point(159, 5);
            this.getValButton.Name = "getValButton";
            this.getValButton.Size = new System.Drawing.Size(104, 23);
            this.getValButton.TabIndex = 10;
            this.getValButton.Text = "Get Single Value";
            this.getValButton.UseVisualStyleBackColor = true;
            this.getValButton.Click += new System.EventHandler(this.getValButton_Click);
            // 
            // getAllButton
            // 
            this.getAllButton.Location = new System.Drawing.Point(269, 5);
            this.getAllButton.Name = "getAllButton";
            this.getAllButton.Size = new System.Drawing.Size(104, 23);
            this.getAllButton.TabIndex = 11;
            this.getAllButton.Text = "Get ALL Values";
            this.getAllButton.UseVisualStyleBackColor = true;
            this.getAllButton.Click += new System.EventHandler(this.getAllButton_Click);
            // 
            // SeismicActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 295);
            this.Controls.Add(this.getAllButton);
            this.Controls.Add(this.getValButton);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.AccelDataLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.seismicActivitybutton);
            this.Controls.Add(this.SeismicActivityChart);
            this.Name = "SeismicActivityForm";
            this.Text = "SeismicActivityForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RiverBedForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SeismicActivityChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button seismicActivitybutton;
        public System.Windows.Forms.DataVisualization.Charting.Chart SeismicActivityChart;
        private System.Windows.Forms.Label AccelDataLabel;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.Button getValButton;
        private System.Windows.Forms.Button getAllButton;
    }
}