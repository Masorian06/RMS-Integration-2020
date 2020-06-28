namespace RMS_Integration
{
    partial class RMSApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RMSApp));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.StoreButton = new System.Windows.Forms.Button();
            this.ArduinoCnx = new System.Windows.Forms.ComboBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TempChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.XaxisChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelBeta = new System.Windows.Forms.Label();
            this.labelAlpha = new System.Windows.Forms.Label();
            this.BetaChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.AlphaChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.YaxisChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.settings1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.combAccel = new System.Windows.Forms.ComboBox();
            this.combMaxSpeed = new System.Windows.Forms.ComboBox();
            this.combSpeed = new System.Windows.Forms.ComboBox();
            this.combRotation = new System.Windows.Forms.ComboBox();
            this.Path1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XaxisChart)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BetaChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YaxisChart)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(101, 240);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.Location = new System.Drawing.Point(101, 265);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 23);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(101, 294);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 2;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // StoreButton
            // 
            this.StoreButton.Location = new System.Drawing.Point(142, 323);
            this.StoreButton.Name = "StoreButton";
            this.StoreButton.Size = new System.Drawing.Size(75, 23);
            this.StoreButton.TabIndex = 3;
            this.StoreButton.Text = "Store";
            this.StoreButton.UseVisualStyleBackColor = true;
            this.StoreButton.Click += new System.EventHandler(this.StoreButton_Click);
            // 
            // ArduinoCnx
            // 
            this.ArduinoCnx.FormattingEnabled = true;
            this.ArduinoCnx.Location = new System.Drawing.Point(67, 70);
            this.ArduinoCnx.Name = "ArduinoCnx";
            this.ArduinoCnx.Size = new System.Drawing.Size(121, 21);
            this.ArduinoCnx.TabIndex = 4;
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(205, 70);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(75, 21);
            this.RefreshButton.TabIndex = 5;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(919, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 32);
            this.label2.TabIndex = 13;
            this.label2.Text = "Accelerometer";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(142, 353);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(108, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(28, 353);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(99, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            // 
            // TempChart
            // 
            this.TempChart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.TempChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TempChart.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            this.TempChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.TempChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.TempChart.BorderSkin.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.Name = "ChartArea1";
            this.TempChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.TempChart.Legends.Add(legend1);
            this.TempChart.Location = new System.Drawing.Point(41, 586);
            this.TempChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TempChart.Name = "TempChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.Red;
            series1.Name = "Series1";
            this.TempChart.Series.Add(series1);
            this.TempChart.Size = new System.Drawing.Size(1287, 254);
            this.TempChart.TabIndex = 1;
            this.TempChart.Text = "chart1";
            // 
            // XaxisChart
            // 
            this.XaxisChart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.XaxisChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.XaxisChart.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            this.XaxisChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.XaxisChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.XaxisChart.BorderSkin.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.Name = "ChartArea2";
            this.XaxisChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.XaxisChart.Legends.Add(legend2);
            this.XaxisChart.Location = new System.Drawing.Point(41, 18);
            this.XaxisChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.XaxisChart.Name = "XaxisChart";
            series2.ChartArea = "ChartArea2";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.MarkerColor = System.Drawing.Color.Red;
            series2.Name = "Series1";
            this.XaxisChart.Series.Add(series2);
            this.XaxisChart.Size = new System.Drawing.Size(812, 254);
            this.XaxisChart.TabIndex = 1;
            this.XaxisChart.Text = "chart1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelBeta);
            this.groupBox1.Controls.Add(this.labelAlpha);
            this.groupBox1.Controls.Add(this.BetaChart);
            this.groupBox1.Controls.Add(this.AlphaChart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.YaxisChart);
            this.groupBox1.Controls.Add(this.TempChart);
            this.groupBox1.Controls.Add(this.XaxisChart);
            this.groupBox1.Location = new System.Drawing.Point(298, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1351, 886);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acceleration and Temperature";
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.ForeColor = System.Drawing.Color.Black;
            this.labelBeta.Location = new System.Drawing.Point(860, 550);
            this.labelBeta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(59, 13);
            this.labelBeta.TabIndex = 32;
            this.labelBeta.Text = "Angle-Beta";
            // 
            // labelAlpha
            // 
            this.labelAlpha.AutoSize = true;
            this.labelAlpha.ForeColor = System.Drawing.Color.Black;
            this.labelAlpha.Location = new System.Drawing.Point(860, 274);
            this.labelAlpha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAlpha.Name = "labelAlpha";
            this.labelAlpha.Size = new System.Drawing.Size(64, 13);
            this.labelAlpha.TabIndex = 31;
            this.labelAlpha.Text = "Angle-Alpha";
            // 
            // BetaChart
            // 
            this.BetaChart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.BetaChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BetaChart.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            this.BetaChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.BetaChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.BetaChart.BorderSkin.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea3.AxisX.MajorGrid.Enabled = false;
            chartArea3.AxisY.MajorGrid.Enabled = false;
            chartArea3.Name = "ChartArea5";
            this.BetaChart.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.BetaChart.Legends.Add(legend3);
            this.BetaChart.Location = new System.Drawing.Point(863, 294);
            this.BetaChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BetaChart.Name = "BetaChart";
            series3.ChartArea = "ChartArea5";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Color = System.Drawing.Color.Black;
            series3.Legend = "Legend1";
            series3.MarkerColor = System.Drawing.Color.Red;
            series3.Name = "Series1";
            this.BetaChart.Series.Add(series3);
            this.BetaChart.Size = new System.Drawing.Size(465, 254);
            this.BetaChart.TabIndex = 30;
            this.BetaChart.Text = "chart2";
            // 
            // AlphaChart
            // 
            this.AlphaChart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AlphaChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.AlphaChart.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            this.AlphaChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.AlphaChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.AlphaChart.BorderSkin.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea4.AxisX.MajorGrid.Enabled = false;
            chartArea4.AxisY.MajorGrid.Enabled = false;
            chartArea4.Name = "ChartArea4";
            this.AlphaChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.AlphaChart.Legends.Add(legend4);
            this.AlphaChart.Location = new System.Drawing.Point(863, 18);
            this.AlphaChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AlphaChart.Name = "AlphaChart";
            series4.ChartArea = "ChartArea4";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series4.Color = System.Drawing.Color.Blue;
            series4.Legend = "Legend1";
            series4.MarkerColor = System.Drawing.Color.Red;
            series4.Name = "Series1";
            this.AlphaChart.Series.Add(series4);
            this.AlphaChart.Size = new System.Drawing.Size(465, 254);
            this.AlphaChart.TabIndex = 29;
            this.AlphaChart.Text = "chart1";
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
            this.label9.Size = new System.Drawing.Size(36, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "Y-Axis";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(38, 274);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "X-Axis";
            // 
            // YaxisChart
            // 
            this.YaxisChart.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.YaxisChart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.YaxisChart.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.Unscaled;
            this.YaxisChart.BackSecondaryColor = System.Drawing.Color.Transparent;
            this.YaxisChart.BorderSkin.BackColor = System.Drawing.Color.Transparent;
            this.YaxisChart.BorderSkin.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Center;
            chartArea5.AxisX.MajorGrid.Enabled = false;
            chartArea5.Name = "ChartArea3";
            this.YaxisChart.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.YaxisChart.Legends.Add(legend5);
            this.YaxisChart.Location = new System.Drawing.Point(41, 294);
            this.YaxisChart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.YaxisChart.Name = "YaxisChart";
            series5.ChartArea = "ChartArea3";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series5.Color = System.Drawing.Color.Black;
            series5.Legend = "Legend1";
            series5.MarkerColor = System.Drawing.Color.Red;
            series5.Name = "Series1";
            this.YaxisChart.Series.Add(series5);
            this.YaxisChart.Size = new System.Drawing.Size(812, 254);
            this.YaxisChart.TabIndex = 1;
            this.YaxisChart.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Rotation Selection";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(5, 45);
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
            this.label5.Location = new System.Drawing.Point(5, 72);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Set Max Speed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(5, 99);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Set Acceleration";
            // 
            // settings1
            // 
            this.settings1.Location = new System.Drawing.Point(196, 55);
            this.settings1.Name = "settings1";
            this.settings1.Size = new System.Drawing.Size(75, 23);
            this.settings1.TabIndex = 35;
            this.settings1.Text = "Set Values";
            this.settings1.UseVisualStyleBackColor = true;
            this.settings1.Click += new System.EventHandler(this.Settings1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.combAccel);
            this.groupBox2.Controls.Add(this.combMaxSpeed);
            this.groupBox2.Controls.Add(this.combSpeed);
            this.groupBox2.Controls.Add(this.combRotation);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.settings1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(9, 97);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 137);
            this.groupBox2.TabIndex = 36;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mechatronic System Settings (Accelerometer)";
            // 
            // combAccel
            // 
            this.combAccel.FormattingEnabled = true;
            this.combAccel.Items.AddRange(new object[] {
            "150.0",
            "200.0",
            "250.0",
            "300.0",
            "350.0",
            "400.0",
            "450.0",
            "500.0",
            "550.0",
            "600.0",
            "700.0",
            "800.0",
            "900.0",
            "1000.0"});
            this.combAccel.Location = new System.Drawing.Point(101, 96);
            this.combAccel.Name = "combAccel";
            this.combAccel.Size = new System.Drawing.Size(78, 21);
            this.combAccel.TabIndex = 40;
            this.combAccel.SelectedIndexChanged += new System.EventHandler(this.CombAccel_SelectedIndexChanged);
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
            this.combMaxSpeed.SelectedIndexChanged += new System.EventHandler(this.CombMaxSpeed_SelectedIndexChanged);
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
            this.combSpeed.SelectedIndexChanged += new System.EventHandler(this.CombSpeed_SelectedIndexChanged);
            // 
            // combRotation
            // 
            this.combRotation.FormattingEnabled = true;
            this.combRotation.Items.AddRange(new object[] {
            "525",
            "1050",
            "1575",
            "2100",
            "-525",
            "-1050",
            "-1575",
            "-2100"});
            this.combRotation.Location = new System.Drawing.Point(101, 14);
            this.combRotation.Name = "combRotation";
            this.combRotation.Size = new System.Drawing.Size(78, 21);
            this.combRotation.TabIndex = 37;
            this.combRotation.SelectedIndexChanged += new System.EventHandler(this.CombRotation_SelectedIndexChanged);
            // 
            // Path1
            // 
            this.Path1.Location = new System.Drawing.Point(61, 323);
            this.Path1.Name = "Path1";
            this.Path1.Size = new System.Drawing.Size(75, 23);
            this.Path1.TabIndex = 37;
            this.Path1.Text = "Select Path";
            this.Path1.UseVisualStyleBackColor = false;
            this.Path1.Click += new System.EventHandler(this.Path1_Click);
            // 
            // RMSApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1676, 967);
            this.Controls.Add(this.Path1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RefreshButton);
            this.Controls.Add(this.ArduinoCnx);
            this.Controls.Add(this.StoreButton);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.StopButton);
            this.Name = "RMSApp";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TempChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XaxisChart)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BetaChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlphaChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YaxisChart)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button StoreButton;
        private System.Windows.Forms.ComboBox ArduinoCnx;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart TempChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart XaxisChart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart YaxisChart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelBeta;
        private System.Windows.Forms.Label labelAlpha;
        private System.Windows.Forms.DataVisualization.Charting.Chart BetaChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart AlphaChart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button settings1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox combRotation;
        private System.Windows.Forms.ComboBox combSpeed;
        private System.Windows.Forms.ComboBox combAccel;
        private System.Windows.Forms.ComboBox combMaxSpeed;
        private System.Windows.Forms.Button Path1;
    }
}

