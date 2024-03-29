﻿namespace WIFIGUIDemo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title3 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.getMagButton = new System.Windows.Forms.Button();
            this.magDataLabel = new System.Windows.Forms.Label();
            this.receiveButton = new System.Windows.Forms.Button();
            this.MagValueChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.clearButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.singleValueButton = new System.Windows.Forms.Button();
            this.dataTimer = new System.Windows.Forms.Timer(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.streamButton = new System.Windows.Forms.Button();
            this.absVectorChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.MagValueChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.absVectorChart)).BeginInit();
            this.SuspendLayout();
            // 
            // getMagButton
            // 
            this.getMagButton.Enabled = false;
            this.getMagButton.Location = new System.Drawing.Point(14, 10);
            this.getMagButton.Name = "getMagButton";
            this.getMagButton.Size = new System.Drawing.Size(134, 25);
            this.getMagButton.TabIndex = 0;
            this.getMagButton.Text = "Record Mag Data";
            this.getMagButton.UseVisualStyleBackColor = true;
            this.getMagButton.Click += new System.EventHandler(this.getMagButton_Click);
            // 
            // magDataLabel
            // 
            this.magDataLabel.AutoSize = true;
            this.magDataLabel.Location = new System.Drawing.Point(152, 20);
            this.magDataLabel.Name = "magDataLabel";
            this.magDataLabel.Size = new System.Drawing.Size(102, 13);
            this.magDataLabel.TabIndex = 1;
            this.magDataLabel.Text = "Mag Data Status";
            // 
            // receiveButton
            // 
            this.receiveButton.Enabled = false;
            this.receiveButton.Location = new System.Drawing.Point(14, 39);
            this.receiveButton.Name = "receiveButton";
            this.receiveButton.Size = new System.Drawing.Size(99, 25);
            this.receiveButton.TabIndex = 2;
            this.receiveButton.Text = "Receive X";
            this.receiveButton.UseVisualStyleBackColor = true;
            this.receiveButton.Click += new System.EventHandler(this.receiveButton_Click);
            // 
            // MagValueChart
            // 
            this.MagValueChart.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.MagValueChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea3.Name = "ChartArea1";
            this.MagValueChart.ChartAreas.Add(chartArea3);
            legend3.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend3.Name = "Legend1";
            this.MagValueChart.Legends.Add(legend3);
            this.MagValueChart.Location = new System.Drawing.Point(14, 70);
            this.MagValueChart.Name = "MagValueChart";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "mag_x";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series5.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "mag_y";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series6.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            series7.ChartArea = "ChartArea1";
            series7.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series7.Legend = "Legend1";
            series7.Name = "mag_z";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series7.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.MagValueChart.Series.Add(series5);
            this.MagValueChart.Series.Add(series6);
            this.MagValueChart.Series.Add(series7);
            this.MagValueChart.Size = new System.Drawing.Size(1027, 251);
            this.MagValueChart.TabIndex = 5;
            this.MagValueChart.Text = "Mag Values Chart";
            title3.Name = "title";
            title3.Text = "Magnetic Values (x,y,z)";
            this.MagValueChart.Titles.Add(title3);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(576, 10);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(90, 25);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(118, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 25);
            this.button1.TabIndex = 7;
            this.button1.Text = "Receive Y";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(222, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 25);
            this.button2.TabIndex = 8;
            this.button2.Text = "Receive Z";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // singleValueButton
            // 
            this.singleValueButton.Location = new System.Drawing.Point(379, 39);
            this.singleValueButton.Name = "singleValueButton";
            this.singleValueButton.Size = new System.Drawing.Size(130, 25);
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
            this.saveButton.Location = new System.Drawing.Point(930, 10);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(110, 25);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // streamButton
            // 
            this.streamButton.Location = new System.Drawing.Point(379, 10);
            this.streamButton.Name = "streamButton";
            this.streamButton.Size = new System.Drawing.Size(130, 25);
            this.streamButton.TabIndex = 11;
            this.streamButton.Text = "Continious Stream";
            this.streamButton.UseVisualStyleBackColor = true;
            this.streamButton.Click += new System.EventHandler(this.streamButton_Click);
            // 
            // absVectorChart
            // 
            this.absVectorChart.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.absVectorChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot;
            chartArea4.Name = "ChartArea1";
            this.absVectorChart.ChartAreas.Add(chartArea4);
            legend4.LegendStyle = System.Windows.Forms.DataVisualization.Charting.LegendStyle.Column;
            legend4.Name = "Legend1";
            this.absVectorChart.Legends.Add(legend4);
            this.absVectorChart.Location = new System.Drawing.Point(14, 327);
            this.absVectorChart.Name = "absVectorChart";
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.Legend = "Legend1";
            series8.Name = "absValue";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.UInt32;
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.absVectorChart.Series.Add(series8);
            this.absVectorChart.Size = new System.Drawing.Size(1027, 251);
            this.absVectorChart.TabIndex = 12;
            this.absVectorChart.Text = "Mag Vector Chart";
            title4.Name = "Absolute Value for Magnetic Vector";
            title4.Text = "Absolute Value for Magnetic Vector";
            this.absVectorChart.Titles.Add(title4);
            // 
            // VortexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1052, 585);
            this.Controls.Add(this.absVectorChart);
            this.Controls.Add(this.streamButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.singleValueButton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.MagValueChart);
            this.Controls.Add(this.receiveButton);
            this.Controls.Add(this.magDataLabel);
            this.Controls.Add(this.getMagButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "VortexForm";
            this.Text = "VortexForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VortexForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.MagValueChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.absVectorChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getMagButton;
        private System.Windows.Forms.Label magDataLabel;
        private System.Windows.Forms.Button receiveButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart MagValueChart;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button singleValueButton;
        private System.Windows.Forms.Timer dataTimer;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button streamButton;
        public System.Windows.Forms.DataVisualization.Charting.Chart absVectorChart;
    }
}