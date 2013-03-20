namespace WIFIGUIDemo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.clearButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.riverBedMapButton = new System.Windows.Forms.Button();
            this.IRIntensityDistanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.IRDataTimer = new System.Windows.Forms.Timer(this.components);
            this.saveDataButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.IRIntensityDistanceChart)).BeginInit();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(688, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(78, 22);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(160, 5);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(101, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // riverBedMapButton
            // 
            this.riverBedMapButton.Location = new System.Drawing.Point(14, 5);
            this.riverBedMapButton.Name = "riverBedMapButton";
            this.riverBedMapButton.Size = new System.Drawing.Size(139, 23);
            this.riverBedMapButton.TabIndex = 5;
            this.riverBedMapButton.Text = "Map River Bed - OFF";
            this.riverBedMapButton.UseVisualStyleBackColor = true;
            this.riverBedMapButton.Click += new System.EventHandler(this.riverBedMapButton_Click);
            // 
            // IRIntensityDistanceChart
            // 
            this.IRIntensityDistanceChart.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            chartArea3.Name = "ChartArea1";
            this.IRIntensityDistanceChart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend3.Name = "Legend1";
            this.IRIntensityDistanceChart.Legends.Add(legend3);
            this.IRIntensityDistanceChart.Location = new System.Drawing.Point(14, 34);
            this.IRIntensityDistanceChart.Name = "IRIntensityDistanceChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series5.Legend = "Legend1";
            series5.Name = "IRDataLeft";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series6.Legend = "Legend1";
            series6.Name = "IRDataRight";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            this.IRIntensityDistanceChart.Series.Add(series5);
            this.IRIntensityDistanceChart.Series.Add(series6);
            this.IRIntensityDistanceChart.Size = new System.Drawing.Size(752, 251);
            this.IRIntensityDistanceChart.TabIndex = 4;
            this.IRIntensityDistanceChart.Text = "Light Tunnel Chart";
            title3.Name = "title";
            title3.Text = "IR Intesity vs Distance";
            this.IRIntensityDistanceChart.Titles.Add(title3);
            // 
            // IRDataTimer
            // 
            this.IRDataTimer.Interval = 120;
            this.IRDataTimer.Tick += new System.EventHandler(this.IRDataTimer_Tick);
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(587, 4);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(94, 23);
            this.saveDataButton.TabIndex = 9;
            this.saveDataButton.Text = "Save Data";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // RiverBedForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(779, 295);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.riverBedMapButton);
            this.Controls.Add(this.IRIntensityDistanceChart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "RiverBedForm";
            this.Text = "RiverBedForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RiverBedForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.IRIntensityDistanceChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button riverBedMapButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart IRIntensityDistanceChart;
        private System.Windows.Forms.Timer IRDataTimer;
        private System.Windows.Forms.Button saveDataButton;
    }
}