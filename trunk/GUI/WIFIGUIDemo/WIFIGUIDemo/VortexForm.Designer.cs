namespace WIFIGUIDemo
{
    partial class VortexForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.getMagButton = new System.Windows.Forms.Button();
            this.magDataLabel = new System.Windows.Forms.Label();
            this.receiveButton = new System.Windows.Forms.Button();
            this.SeismicActivityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clearButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.singleValueButton = new System.Windows.Forms.Button();
            this.dataTimer = new System.Windows.Forms.Timer(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SeismicActivityChart)).BeginInit();
            this.SuspendLayout();
            // 
            // getMagButton
            // 
            this.getMagButton.Location = new System.Drawing.Point(14, 14);
            this.getMagButton.Name = "getMagButton";
            this.getMagButton.Size = new System.Drawing.Size(112, 23);
            this.getMagButton.TabIndex = 0;
            this.getMagButton.Text = "Record Mag Data";
            this.getMagButton.UseVisualStyleBackColor = true;
            this.getMagButton.Click += new System.EventHandler(this.getMagButton_Click);
            // 
            // magDataLabel
            // 
            this.magDataLabel.AutoSize = true;
            this.magDataLabel.Location = new System.Drawing.Point(442, 19);
            this.magDataLabel.Name = "magDataLabel";
            this.magDataLabel.Size = new System.Drawing.Size(87, 13);
            this.magDataLabel.TabIndex = 1;
            this.magDataLabel.Text = "Mag Data Status";
            // 
            // receiveButton
            // 
            this.receiveButton.Location = new System.Drawing.Point(131, 14);
            this.receiveButton.Name = "receiveButton";
            this.receiveButton.Size = new System.Drawing.Size(83, 23);
            this.receiveButton.TabIndex = 2;
            this.receiveButton.Text = "Receive X";
            this.receiveButton.UseVisualStyleBackColor = true;
            this.receiveButton.Click += new System.EventHandler(this.receiveButton_Click);
            // 
            // SeismicActivityChart
            // 
            chartArea2.Name = "ChartArea1";
            this.SeismicActivityChart.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            this.SeismicActivityChart.Legends.Add(legend2);
            this.SeismicActivityChart.Location = new System.Drawing.Point(12, 43);
            this.SeismicActivityChart.Name = "SeismicActivityChart";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "mag_x";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "mag_y";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "mag_z";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.SeismicActivityChart.Series.Add(series4);
            this.SeismicActivityChart.Series.Add(series5);
            this.SeismicActivityChart.Series.Add(series6);
            this.SeismicActivityChart.Size = new System.Drawing.Size(790, 251);
            this.SeismicActivityChart.TabIndex = 5;
            this.SeismicActivityChart.Text = "Light Tunnel Chart";
            title2.Name = "IR Intesity vs Distance";
            this.SeismicActivityChart.Titles.Add(title2);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(535, 11);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(75, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Receive Y";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(309, 14);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Receive Z";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // singleValueButton
            // 
            this.singleValueButton.Location = new System.Drawing.Point(616, 11);
            this.singleValueButton.Name = "singleValueButton";
            this.singleValueButton.Size = new System.Drawing.Size(75, 23);
            this.singleValueButton.TabIndex = 9;
            this.singleValueButton.Text = "Single Value";
            this.singleValueButton.UseVisualStyleBackColor = true;
            this.singleValueButton.Click += new System.EventHandler(this.singleValueButton_Click);
            // 
            // dataTimer
            // 
            this.dataTimer.Tick += new System.EventHandler(this.dataTimer_Tick);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(697, 11);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // VortexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 318);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.singleValueButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.SeismicActivityChart);
            this.Controls.Add(this.receiveButton);
            this.Controls.Add(this.magDataLabel);
            this.Controls.Add(this.getMagButton);
            this.Name = "VortexForm";
            this.Text = "VortexForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VortexForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SeismicActivityChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getMagButton;
        private System.Windows.Forms.Label magDataLabel;
        private System.Windows.Forms.Button receiveButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart SeismicActivityChart;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button singleValueButton;
        private System.Windows.Forms.Timer dataTimer;
        private System.Windows.Forms.Button saveButton;
    }
}