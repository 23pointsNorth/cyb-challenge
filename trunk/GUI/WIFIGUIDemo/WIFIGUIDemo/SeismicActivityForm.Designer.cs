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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series9 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.clearButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.seismicActivitybutton = new System.Windows.Forms.Button();
            this.SeismicActivityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.getValButton = new System.Windows.Forms.Button();
            this.getAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SeismicActivityChart)).BeginInit();
            this.SuspendLayout();
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(838, 5);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(100, 25);
            this.clearButton.TabIndex = 7;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(443, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(100, 25);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // seismicActivitybutton
            // 
            this.seismicActivitybutton.Location = new System.Drawing.Point(14, 5);
            this.seismicActivitybutton.Name = "seismicActivitybutton";
            this.seismicActivitybutton.Size = new System.Drawing.Size(164, 25);
            this.seismicActivitybutton.TabIndex = 5;
            this.seismicActivitybutton.Text = "Map Seismic Activity - Off";
            this.seismicActivitybutton.UseVisualStyleBackColor = true;
            this.seismicActivitybutton.Click += new System.EventHandler(this.seismicActivityButton_Click);
            // 
            // SeismicActivityChart
            // 
            this.SeismicActivityChart.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            chartArea3.AxisY.Maximum = 2D;
            chartArea3.AxisY.Minimum = -2D;
            chartArea3.Name = "ChartArea1";
            this.SeismicActivityChart.ChartAreas.Add(chartArea3);
            legend3.Enabled = false;
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend3.Name = "Legend1";
            this.SeismicActivityChart.Legends.Add(legend3);
            this.SeismicActivityChart.Location = new System.Drawing.Point(14, 34);
            this.SeismicActivityChart.Name = "SeismicActivityChart";
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "Accelx";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "Accely";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series9.ChartArea = "ChartArea1";
            series9.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series9.Legend = "Legend1";
            series9.Name = "Accelz";
            series9.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series9.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.SeismicActivityChart.Series.Add(series7);
            this.SeismicActivityChart.Series.Add(series8);
            this.SeismicActivityChart.Series.Add(series9);
            this.SeismicActivityChart.Size = new System.Drawing.Size(922, 251);
            this.SeismicActivityChart.TabIndex = 4;
            this.SeismicActivityChart.Text = "Light Tunnel Chart";
            title3.Name = "title";
            title3.Text = "Acceleration values in x,y,z-directions";
            this.SeismicActivityChart.Titles.Add(title3);
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(732, 5);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(100, 25);
            this.saveDataButton.TabIndex = 9;
            this.saveDataButton.Text = "Save Data";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // getValButton
            // 
            this.getValButton.Location = new System.Drawing.Point(185, 5);
            this.getValButton.Name = "getValButton";
            this.getValButton.Size = new System.Drawing.Size(120, 25);
            this.getValButton.TabIndex = 10;
            this.getValButton.Text = "Get Single Value";
            this.getValButton.UseVisualStyleBackColor = true;
            this.getValButton.Click += new System.EventHandler(this.getValButton_Click);
            // 
            // getAllButton
            // 
            this.getAllButton.Location = new System.Drawing.Point(314, 5);
            this.getAllButton.Name = "getAllButton";
            this.getAllButton.Size = new System.Drawing.Size(120, 25);
            this.getAllButton.TabIndex = 11;
            this.getAllButton.Text = "Get ALL Values";
            this.getAllButton.UseVisualStyleBackColor = true;
            this.getAllButton.Click += new System.EventHandler(this.getAllButton_Click);
            // 
            // SeismicActivityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(950, 295);
            this.Controls.Add(this.getAllButton);
            this.Controls.Add(this.getValButton);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.seismicActivitybutton);
            this.Controls.Add(this.SeismicActivityChart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "SeismicActivityForm";
            this.Text = "SeismicActivityForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RiverBedForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SeismicActivityChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button seismicActivitybutton;
        public System.Windows.Forms.DataVisualization.Charting.Chart SeismicActivityChart;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.Button getValButton;
        private System.Windows.Forms.Button getAllButton;
    }
}