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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.getTempButton = new System.Windows.Forms.Button();
            this.volcanoTempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataTimer = new System.Windows.Forms.Timer(this.components);
            this.statusLabel = new System.Windows.Forms.Label();
            this.saveDataButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.volcanoTempChart)).BeginInit();
            this.SuspendLayout();
            // 
            // getTempButton
            // 
            this.getTempButton.Location = new System.Drawing.Point(12, 12);
            this.getTempButton.Name = "getTempButton";
            this.getTempButton.Size = new System.Drawing.Size(103, 34);
            this.getTempButton.TabIndex = 0;
            this.getTempButton.Text = "Get temperature";
            this.getTempButton.UseVisualStyleBackColor = true;
            this.getTempButton.Click += new System.EventHandler(this.getTempButton_Click);
            // 
            // volcanoTempChart
            // 
            this.volcanoTempChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea1.Name = "ChartArea1";
            this.volcanoTempChart.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend1.Name = "Legend1";
            this.volcanoTempChart.Legends.Add(legend1);
            this.volcanoTempChart.Location = new System.Drawing.Point(12, 54);
            this.volcanoTempChart.Name = "volcanoTempChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Temperature";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.volcanoTempChart.Series.Add(series1);
            this.volcanoTempChart.Size = new System.Drawing.Size(636, 251);
            this.volcanoTempChart.TabIndex = 5;
            this.volcanoTempChart.Text = "Volcano Temperature";
            title1.Name = "title";
            title1.Text = "Temperature (\'C)";
            this.volcanoTempChart.Titles.Add(title1);
            // 
            // dataTimer
            // 
            this.dataTimer.Interval = 200;
            this.dataTimer.Tick += new System.EventHandler(this.dataTimer_Tick);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(121, 23);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(68, 13);
            this.statusLabel.TabIndex = 6;
            this.statusLabel.Text = "Status: False";
            // 
            // saveDataButton
            // 
            this.saveDataButton.Location = new System.Drawing.Point(436, 14);
            this.saveDataButton.Name = "saveDataButton";
            this.saveDataButton.Size = new System.Drawing.Size(103, 34);
            this.saveDataButton.TabIndex = 7;
            this.saveDataButton.Text = "Save Data";
            this.saveDataButton.UseVisualStyleBackColor = true;
            this.saveDataButton.Click += new System.EventHandler(this.saveDataButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(545, 14);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(103, 34);
            this.clearButton.TabIndex = 8;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // VolcanoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 313);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.saveDataButton);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.volcanoTempChart);
            this.Controls.Add(this.getTempButton);
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
    }
}