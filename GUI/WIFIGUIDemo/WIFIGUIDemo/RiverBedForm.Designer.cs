﻿namespace WIFIGUIDemo
{
    partial class RiverBedForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series10 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.clearButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.riverBedMapButton = new System.Windows.Forms.Button();
            this.IRIntensityDistanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.IRDataLabel = new System.Windows.Forms.Label();
            this.IRDataTimer = new System.Windows.Forms.Timer(this.components);
            this.saveDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IRIntensityDistanceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(590, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(67, 22);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(137, 5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(87, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // riverBedMapButton
            // 
            this.riverBedMapButton.Location = new System.Drawing.Point(12, 5);
            this.riverBedMapButton.Name = "riverBedMapButton";
            this.riverBedMapButton.Size = new System.Drawing.Size(119, 23);
            this.riverBedMapButton.TabIndex = 5;
            this.riverBedMapButton.Text = "Map River Bed - OFF";
            this.riverBedMapButton.UseVisualStyleBackColor = true;
            this.riverBedMapButton.Click += new System.EventHandler(this.riverBedMapButton_Click);
            // 
            // IRIntensityDistanceChart
            // 
            chartArea5.Name = "ChartArea1";
            this.IRIntensityDistanceChart.ChartAreas.Add(chartArea5);
            legend5.Enabled = false;
            legend5.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend5.Name = "Legend1";
            this.IRIntensityDistanceChart.Legends.Add(legend5);
            this.IRIntensityDistanceChart.Location = new System.Drawing.Point(12, 34);
            this.IRIntensityDistanceChart.Name = "IRIntensityDistanceChart";
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series9.Legend = "Legend1";
            series9.Name = "IRDataLeft";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series10.ChartArea = "ChartArea1";
            series10.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series10.Legend = "Legend1";
            series10.Name = "IRDataRight";
            series10.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series10.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            this.IRIntensityDistanceChart.Series.Add(series9);
            this.IRIntensityDistanceChart.Series.Add(series10);
            this.IRIntensityDistanceChart.Size = new System.Drawing.Size(645, 251);
            this.IRIntensityDistanceChart.TabIndex = 4;
            this.IRIntensityDistanceChart.Text = "Light Tunnel Chart";
            title5.Name = "IR Intesity vs Distance";
            this.IRIntensityDistanceChart.Titles.Add(title5);
            // 
            // IRDataLabel
            // 
            this.IRDataLabel.AutoSize = true;
            this.IRDataLabel.Location = new System.Drawing.Point(258, 10);
            this.IRDataLabel.Name = "IRDataLabel";
            this.IRDataLabel.Size = new System.Drawing.Size(42, 13);
            this.IRDataLabel.TabIndex = 8;
            this.IRDataLabel.Text = "IR data";
            // 
            // IRDataTimer
            // 
            this.IRDataTimer.Interval = 120;
            this.IRDataTimer.Tick += new System.EventHandler(this.IRDataTimer_Tick);
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(503, 4);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(81, 23);
            this.saveDataButton.TabIndex = 9;
            this.saveDataButton.Text = "Save Data";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // RiverBedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 295);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.IRDataLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.riverBedMapButton);
            this.Controls.Add(this.IRIntensityDistanceChart);
            this.Name = "RiverBedForm";
            this.Text = "RiverBedForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RiverBedForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.IRIntensityDistanceChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button riverBedMapButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart IRIntensityDistanceChart;
        private System.Windows.Forms.Label IRDataLabel;
        private System.Windows.Forms.Timer IRDataTimer;
        private System.Windows.Forms.Button saveDataButton;
    }
}