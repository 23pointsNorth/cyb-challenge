namespace WIFIGUIDemo
{
    partial class VolcanoForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.getTempButton = new System.Windows.Forms.Button();
            this.volcanoTempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataTimer = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.Label();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.lastTempLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.volcanoTempChart)).BeginInit();
            this.SuspendLayout();
            // 
            // getTempButton
            // 
            this.getTempButton.Location = new System.Drawing.Point(14, 12);
            this.getTempButton.Name = "getTempButton";
            this.getTempButton.Size = new System.Drawing.Size(120, 34);
            this.getTempButton.TabIndex = 0;
            this.getTempButton.Text = "Get temperature";
            this.getTempButton.UseVisualStyleBackColor = true;
            this.getTempButton.Click += new System.EventHandler(this.getTempButton_Click);
            // 
            // volcanoTempChart
            // 
            this.volcanoTempChart.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.volcanoTempChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea2.Name = "ChartArea1";
            this.volcanoTempChart.ChartAreas.Add(chartArea2);
            legend2.Enabled = false;
            legend2.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend2.Name = "Legend1";
            this.volcanoTempChart.Legends.Add(legend2);
            this.volcanoTempChart.Location = new System.Drawing.Point(14, 54);
            this.volcanoTempChart.Name = "volcanoTempChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Temperature";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.volcanoTempChart.Series.Add(series2);
            this.volcanoTempChart.Size = new System.Drawing.Size(742, 251);
            this.volcanoTempChart.TabIndex = 5;
            this.volcanoTempChart.Text = "Volcano Temperature";
            title2.Name = "title";
            title2.Text = "Temperature (\'C)";
            this.volcanoTempChart.Titles.Add(title2);
            // 
            // dataTimer
            // 
            this.dataTimer.Interval = 200;
            this.dataTimer.Tick += new System.EventHandler(this.dataTimer_Tick);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(141, 14);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(149, 13);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Data Collection Stopped.";
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(509, 14);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(120, 34);
            this.saveDataButton.TabIndex = 7;
            this.saveDataButton.Text = "Save Data";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(636, 14);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(120, 34);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // lastTempLabel
            // 
            this.lastTempLabel.AutoSize = true;
            this.lastTempLabel.Location = new System.Drawing.Point(141, 35);
            this.lastTempLabel.Name = "lastTempLabel";
            this.lastTempLabel.Size = new System.Drawing.Size(66, 13);
            this.lastTempLabel.TabIndex = 9;
            this.lastTempLabel.Text = "Last Temp";
            // 
            // VolcanoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(763, 313);
            this.Controls.Add(this.lastTempLabel);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.volcanoTempChart);
            this.Controls.Add(this.getTempButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "VolcanoForm";
            this.Text = "VolcanoForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VolcanoForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.volcanoTempChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getTempButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart volcanoTempChart;
        private System.Windows.Forms.Timer dataTimer;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.Button saveDataButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Label lastTempLabel;
    }
}