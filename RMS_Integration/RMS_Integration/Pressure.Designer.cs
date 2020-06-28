namespace RMS_Integration
{
    partial class Pressure
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pressure));
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pSiChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.kPaChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.combMaxSpeed = new System.Windows.Forms.ComboBox();
            this.combSpeed = new System.Windows.Forms.ComboBox();
            this.combRotation = new System.Windows.Forms.ComboBox();
            this.settings1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.ArduinoCnx = new System.Windows.Forms.ComboBox();
            this.Path1 = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StoreButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSiChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kPaChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(704, 28);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 32);
            this.label2.TabIndex = 14;
            this.label2.Text = "Preussure Sensor";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.pSiChart);
            this.groupBox1.Controls.Add(this.TempChart);
            this.groupBox1.Controls.Add(this.kPaChart);
            this.groupBox1.Location = new System.Drawing.Point(327, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(972, 886);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pressure and Temperature";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(38, 842);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Temperature";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(38, 558);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "PSI";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(38, 274);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "kPa";
            // 
            // pSiChart
            // 
            this.pSiChart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.pSiChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pSiChart.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            this.pSiChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.pSiChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.pSiChart.BorderSkin.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea2";
            this.pSiChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.pSiChart.Legends.Add(legend1);
            this.pSiChart.Location = new System.Drawing.Point(40, 302);
            this.pSiChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pSiChart.Name = "pSiChart";
            series1.ChartArea = "ChartArea2";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Black;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Red;
            series1.Name = "Series1";
            this.pSiChart.Series.Add(series1);
            this.pSiChart.Size = new System.Drawing.Size(812, 254);
            this.pSiChart.TabIndex = 1;
            this.pSiChart.Text = "chart1";
            // 
            // TempChart
            // 
            this.TempChart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.TempChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TempChart.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            this.TempChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.TempChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.TempChart.BorderSkin.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea1";
            this.TempChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.TempChart.Legends.Add(legend2);
            this.TempChart.Location = new System.Drawing.Point(40, 586);
            this.TempChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TempChart.Name = "TempChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Red;
            series2.Legend = "Legend1";
            series2.MarkerColor = System.Drawing.Color.Red;
            series2.Name = "Series1";
            this.TempChart.Series.Add(series2);
            this.TempChart.Size = new System.Drawing.Size(812, 254);
            this.TempChart.TabIndex = 1;
            this.TempChart.Text = "chart1";
            // 
            // kPaChart
            // 
            this.kPaChart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.kPaChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.kPaChart.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            this.kPaChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.kPaChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.kPaChart.BorderSkin.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea3.AxisX.IsLabelAutoFit = false;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea3";
            this.kPaChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.kPaChart.Legends.Add(legend3);
            this.kPaChart.Location = new System.Drawing.Point(40, 14);
            this.kPaChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.kPaChart.Name = "kPaChart";
            series3.ChartArea = "ChartArea3";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Blue;
            series3.Legend = "Legend1";
            series3.MarkerColor = System.Drawing.Color.Red;
            series3.Name = "Series1";
            this.kPaChart.Series.Add(series3);
            this.kPaChart.Size = new System.Drawing.Size(812, 254);
            this.kPaChart.TabIndex = 1;
            this.kPaChart.Text = "chart1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.combMaxSpeed);
            this.groupBox2.Controls.Add(this.combSpeed);
            this.groupBox2.Controls.Add(this.combRotation);
            this.groupBox2.Controls.Add(this.settings1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(26, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 110);
            this.groupBox2.TabIndex = 39;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mechatronic System Settings (Pressure Sensor)";
            // 
            // combMaxSpeed
            // 
            this.combMaxSpeed.FormattingEnabled = true;
            this.combMaxSpeed.Items.AddRange(new object[] {
            "150",
            "200",
            "250",
            "300",
            "350",
            "400",
            "450",
            "500",
            "550",
            "600",
            "700",
            "800",
            "900",
            "1000"});
            this.combMaxSpeed.Location = new System.Drawing.Point(101, 69);
            this.combMaxSpeed.Name = "combMaxSpeed";
            this.combMaxSpeed.Size = new System.Drawing.Size(78, 21);
            this.combMaxSpeed.TabIndex = 39;
            // 
            // combSpeed
            // 
            this.combSpeed.FormattingEnabled = true;
            this.combSpeed.Items.AddRange(new object[] {
            "150",
            "200",
            "250",
            "350",
            "400",
            "450",
            "500"});
            this.combSpeed.Location = new System.Drawing.Point(101, 42);
            this.combSpeed.Name = "combSpeed";
            this.combSpeed.Size = new System.Drawing.Size(78, 21);
            this.combSpeed.TabIndex = 38;
            // 
            // combRotation
            // 
            this.combRotation.FormattingEnabled = true;
            this.combRotation.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20"});
            this.combRotation.Location = new System.Drawing.Point(101, 14);
            this.combRotation.Name = "combRotation";
            this.combRotation.Size = new System.Drawing.Size(78, 21);
            this.combRotation.TabIndex = 37;
            // 
            // settings1
            // 
            this.settings1.Location = new System.Drawing.Point(196, 40);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(75, 23);
            this.settings1.TabIndex = 35;
            this.settings1.Text = "Set Values";
            this.settings1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Stroke length";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(7, 50);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Set Speed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 77);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Set Max Speed";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(225, 75);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 21);
            this.RefreshButton.TabIndex = 38;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ArduinoCnx
            // 
            this.ArduinoCnx.FormattingEnabled = true;
            this.ArduinoCnx.Location = new System.Drawing.Point(87, 75);
            this.ArduinoCnx.Name = "ArduinoCnx";
            this.ArduinoCnx.Size = new System.Drawing.Size(121, 21);
            this.ArduinoCnx.TabIndex = 37;
            // 
            // Path1
            // 
            this.Path1.Location = new System.Drawing.Point(89, 339);
            this.Path1.Name = "Path1";
            this.Path1.Size = new System.Drawing.Size(75, 23);
            this.Path1.TabIndex = 46;
            this.Path1.Text = "Select Path";
            this.Path1.UseVisualStyleBackColor = false;
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(129, 256);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 40;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(56, 369);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 45;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(170, 369);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 44;
            this.pictureBox1.TabStop = false;
            // 
            // StoreButton
            // 
            this.StoreButton.Location = new System.Drawing.Point(170, 339);
            this.StoreButton.Name = "StoreButton";
            this.StoreButton.Size = new System.Drawing.Size(75, 23);
            this.StoreButton.TabIndex = 43;
            this.StoreButton.Text = "Store";
            this.StoreButton.UseVisualStyleBackColor = true;
            this.StoreButton.Click += new System.EventHandler(this.StoreButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(129, 310);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 42;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(129, 281);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 41;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // Pressure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 968);
            this.Controls.Add(this.Path1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.StoreButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.ArduinoCnx);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Name = "Pressure";
            this.Text = "Pressure";
            this.Load += new System.EventHandler(this.Pressure_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pSiChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kPaChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataVisualization.Charting.Chart pSiChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart TempChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart kPaChart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox combMaxSpeed;
        private System.Windows.Forms.ComboBox combSpeed;
        private System.Windows.Forms.ComboBox combRotation;
        private System.Windows.Forms.Button settings1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.ComboBox ArduinoCnx;
        private System.Windows.Forms.Button Path1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button StoreButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button StopButton;
    }
}