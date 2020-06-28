using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO.Ports;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows;
using System.Collections.ObjectModel;
using Excel = Microsoft.Office.Interop.Excel;
using System.Timers;
using System.Globalization;

namespace RMS_Integration
{
    public partial class Pressure : Form
    {
        private Thread arduinoThread;
        private SerialPort arduinoPort;

        private DataTable Table = new DataTable();
        private DataColumn column;
        public DataColumn Column { get => column; set => column = value; }
        private DataRow RowV;
        private int seriesNo = 0;
        private int seriesNo2 = 0;
        private int seriesNo3 = 0;
        public int SeriesNo { get => seriesNo; set => seriesNo = value; }
        public int SeriesNo2 { get => seriesNo2; set => seriesNo2 = value; }
        public int SeriesNo3 { get => seriesNo3; set => seriesNo3 = value; }
        private List<DataPoint> dataPointCo1 = new List<DataPoint>();
        private List<DataPoint> dataPointCo2 = new List<DataPoint>();
        private List<DataPoint> dataPointCo3 = new List<DataPoint>();
        private Series kPa_series, pSi_series, temp_series;
        private string _settings = string.Empty;
        private string folderPath = string.Empty;
        private StringBuilder builtString = new StringBuilder();
        private double pointsAfterR = 100D;
        private double pointInChart = 100D;
        private double pointsAfterRa = 50D;
        private double pointInCharta = 50D;
        private double count = 0D;
        public double Count { get => count; set => count = value; }
        private double[] _values = new double[3];
        public double[] Values { get => _values; set => _values = value; }
        private Stopwatch stopWatch = new Stopwatch();
        double timeP;


        public Pressure()
        {
            #region Chart Properties
            //Temperature Chart Axis Labels
            TempChart.ChartAreas["ChartArea1"].AxisX.Title = "Samples (units)";
            TempChart.ChartAreas["ChartArea1"].AxisX.TitleAlignment = StringAlignment.Center;
            TempChart.ChartAreas["ChartArea1"].AxisX.TextOrientation = TextOrientation.Horizontal;
            //chart1.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 8, FontStyle.Bold);
            //chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1; 
            TempChart.ChartAreas["ChartArea1"].AxisY.Title = "Degree Celsius (°C)";
            TempChart.ChartAreas["ChartArea1"].AxisY.TitleAlignment = StringAlignment.Center;
            TempChart.ChartAreas["ChartArea1"].AxisY.TextOrientation = TextOrientation.Rotated270;
            //chart1.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 8, FontStyle.Bold); 

            //Pressure in kPa Labels
            kPaChart.ChartAreas["ChartArea3"].AxisX.Title = "Samples (units)";
            kPaChart.ChartAreas["ChartArea3"].AxisX.TitleAlignment = StringAlignment.Center;
            kPaChart.ChartAreas["ChartArea3"].AxisX.TextOrientation = TextOrientation.Horizontal;
            //chart2.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 8, FontStyle.Bold);
            //chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; 
            kPaChart.ChartAreas["ChartArea3"].AxisY.Title = "Pressure (kPa)";
            kPaChart.ChartAreas["ChartArea3"].AxisY.TitleAlignment = StringAlignment.Center;
            kPaChart.ChartAreas["ChartArea3"].AxisY.TextOrientation = TextOrientation.Rotated270;
            //chart2.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 8, FontStyle.Bold); 

            //Pressure in PSI Labels
            pSiChart.ChartAreas["ChartArea2"].AxisX.Title = "Samples (units)";
            pSiChart.ChartAreas["ChartArea2"].AxisX.TitleAlignment = StringAlignment.Center;
            pSiChart.ChartAreas["ChartArea2"].AxisX.TextOrientation = TextOrientation.Horizontal;
            //MainChart.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 8, FontStyle.Bold);
            //MainChart.ChartAreas["ChartArea1"].AxisX.Interval = 1; 
            pSiChart.ChartAreas["ChartArea2"].AxisY.Title = "Pressure (PSI)";
            pSiChart.ChartAreas["ChartArea2"].AxisY.TitleAlignment = StringAlignment.Center;
            pSiChart.ChartAreas["ChartArea2"].AxisY.TextOrientation = TextOrientation.Rotated270;
            //MainChart.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 8, FontStyle.Bold); 

            #endregion

            InitializeComponent();
            InitializeComponent();
            StopButton.Enabled = false; //Disable state at the begging
            StoreButton.Enabled = false;
            RefreshButton_Click(null, null);
            StartButton.Enabled = true;
            builtString.Append("<");

            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ResizeRedraw, true); //This prevent visual artifacts
            SetAutoSizeMode(AutoSizeMode.GrowOnly);
        }

        public void _newTable()
        {
            DataTable newTalble = new DataTable();
        }

        #region Create DataTable
        private void MakeDataTable()
        {
            //Create new DataColumn, set DataType, ColumnName and Add to DataTable.
            Column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Sensor Voltage"
            };
            Table.Columns.Add(Column);

            //Create second column.
            Column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Pressure kPa"
            };
            Table.Columns.Add(Column);

            //Create fourth columnm.
            Column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Pressure PSI"
            };
            Table.Columns.Add(Column);

            //Create fifth columnm.
            Column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Raw Output"
            };
            Table.Columns.Add(Column);

            //Create thrid columnm.
            Column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Temperature"
            };
            Table.Columns.Add(Column);

            Column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Timer"
            };
            Table.Columns.Add(Column);

        }
        #endregion

        #region Conect/Disconect to Serial Port
        //Find a Serial port that is connected to Arduino
        private void AutodetectSerialPort()
        {
            ArduinoCnx.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();
            foreach (string name in portNames)
            {
                ArduinoCnx.Items.Add(name);
            }
            if (portNames.Length == 0)
            {
                MessageBox.Show("No Serial Port Available");
            }
        }

        //Connect to Arduino Port
        private void Connect_Arduino()
        {
            try
            {
                if (!(arduinoPort.IsOpen))
                    arduinoPort.Open();
                arduinoPort.Write(_settings);
            }
            catch (Exception)
            {
                MessageBox.Show("Cloudn't connect to Arduino, check connection");
                arduinoThread.Abort();
            }
        }
        //Disconnect Arduino Port
        private void Stop_Arduino_Thread()
        {
            try
            {
                arduinoPort.Close();
                arduinoThread.Abort();
            }
            catch (Exception)
            {
                MessageBox.Show("Cloudn't disconnect to Arduino");
                arduinoThread.Abort();
            }
        }
        //Parse Arduino Line, should be 'Int Int'
        #endregion

        #region Collect data from arduino
        private void Start_Arduino_Thread()
        {
            Connect_Arduino();
            while (true)
            {
                double[] values = Parse_Data_Line();
                var new_point = new DataPoint(Count, values[0]);
                dataPointCo1.Add(new_point);
                var new_point2 = new DataPoint(Count, values[1]);
                dataPointCo2.Add(new_point2);
                var new_point3 = new DataPoint(Count, values[2]);
                dataPointCo3.Add(new_point3);

                Count++;

                if (kPaChart.IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate { UpdatekPavalues(dataPointCo1.ToArray()); UpdatekPaChart_Maxium(); });
                }

                if (pSiChart.IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate { UpdatePSIvalues(dataPointCo2.ToArray()); UpdatepSiChart_Maxium(); });
                }

                if (TempChart.IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate { UpdateTempvalues(dataPointCo3.ToArray()); UpdateTempChart_Maxium(); });
                }

            }
        }
        #endregion

        #region Update charts maximun values
        private void UpdatekPaChart_Maxium()
        {
            kPaChart.ResetAutoValues();
            if (kPaChart.ChartAreas["ChartArea3"].AxisX.Maximum < Count)
            {
                kPaChart.ChartAreas["ChartArea3"].AxisX.Maximum = Count;
            }
        }

        private void UpdatepSiChart_Maxium()
        {
            pSiChart.ResetAutoValues();
            if (pSiChart.ChartAreas["ChartArea2"].AxisX.Maximum < Count)
            {
                pSiChart.ChartAreas["ChartArea2"].AxisX.Maximum = Count;
            }
        }

        private void UpdateTempChart_Maxium()
        {
            TempChart.ResetAutoValues();
            if (TempChart.ChartAreas["ChartArea1"].AxisX.Maximum < Count)
            {
                TempChart.ChartAreas["ChartArea1"].AxisX.Maximum = Count;
            }
        }
        #endregion

        #region Parse Data
        private double[] Parse_Data_Line()
        {
            stopWatch.Start();
            //System.Timers.Timer aTimer = new System.Timers.Timer();
            try
            {
                string _line = arduinoPort.ReadLine();
                var stringList = _line.Trim().Split(null, 3);

                _values[0] = double.Parse(stringList[0]);
                _values[1] = double.Parse(stringList[1]);
                _values[2] = double.Parse(stringList[2]);
                stopWatch.Stop();
                timeP = stopWatch.Elapsed.TotalMilliseconds;

                RowV = Table.NewRow();
                RowV["X-axis"] = _values[0].ToString();
                RowV["Y-axis"] = _values[1].ToString();
                RowV["Alpha-Angle"] = _values[2].ToString();
                RowV["Beta-Angle"] = _values[3].ToString();
                RowV["Temperature"] = _values[4].ToString();
                RowV["Timer"] = timeP.ToString();
                Table.Rows.Add(RowV);
                return _values;
            }
            catch (Exception)
            {
                double[] error = new double[3];
                error[0] = 0;
                error[1] = 0;
                error[2] = 0;
                return error;
            }
        }
        #endregion

        #region Draw Points into Series (Pressure kPa)
        //Plot data points from arduino for kPa pressure values
        private void UpdatekPavalues(DataPoint[] array)
        {
            kPa_series.Points.Clear();
            DataPointCollection dataA = kPa_series.Points;

            for (int i = 0; i < array.LongLength - 1; i++)
            {
                dataA.Add(array[i]);
            }

            while (kPaChart.Series[SeriesNo - 1].Points.Count > pointInChart)
            {
                while (kPaChart.Series[SeriesNo - 1].Points.Count > pointsAfterR)
                {
                    kPaChart.Series[SeriesNo - 1].Points.RemoveAt(0);
                }
                kPaChart.ChartAreas["ChartArea3"].AxisX.Minimum = Count - pointsAfterR;
                kPaChart.ChartAreas["ChartArea3"].AxisX.Maximum = kPaChart.ChartAreas["ChartArea3"].AxisX.Minimum + pointInChart;
            }
        }
        #endregion

        #region Draw Points into Series (Pressure PSI)
        //Plot data points from arduino for Y axis
        private void UpdatePSIvalues(DataPoint[] array3)
        {
            pSi_series.Points.Clear();
            DataPointCollection dataAy = pSi_series.Points;
            for (int i = 0; i < array3.LongLength - 1; i++)
            {
                dataAy.Add(array3[i]);
            }


            while (pSiChart.Series[SeriesNo3 - 1].Points.Count > pointInChart)
            {
                while (pSiChart.Series[SeriesNo3 - 1].Points.Count > pointsAfterR)
                {
                    pSiChart.Series[SeriesNo3 - 1].Points.RemoveAt(0);
                }
                pSiChart.ChartAreas["ChartArea2"].AxisX.Minimum = Count - pointsAfterR;
                pSiChart.ChartAreas["ChartArea2"].AxisX.Maximum = pSiChart.ChartAreas["ChartArea2"].AxisX.Minimum + pointInChart;
            }
        }
        #endregion

        #region Draw Points into Series (Temperature)
        //Plot data points from arduino for Temperature
        private void UpdateTempvalues(DataPoint[] array2)
        {
            temp_series.Points.Clear();
            DataPointCollection dataT = temp_series.Points;

            for (int i = 0; i < array2.LongLength - 1; i++)
            {
                dataT.Add(array2[i]);
            }

            while (TempChart.Series[SeriesNo2 - 1].Points.Count > pointInChart)
            {
                while (TempChart.Series[SeriesNo2 - 1].Points.Count > pointsAfterR)
                {
                    TempChart.Series[SeriesNo2 - 1].Points.RemoveAt(0);
                }
                TempChart.ChartAreas["ChartArea1"].AxisX.Minimum = Count - pointsAfterR;
                TempChart.ChartAreas["ChartArea1"].AxisX.Maximum = TempChart.ChartAreas["ChartArea1"].AxisX.Minimum + pointInChart;
            }
        }
        #endregion

        #region Start Button
        private void StartButton_Click(object sender, EventArgs e)
        {
            SeriesNo++;
            SeriesNo2++;
            SeriesNo3++;

            //Enable-Disable start button
            StartButton.Enabled = false;
            StopButton.Enabled = true;
            ClearButton.Enabled = false;
            MakeDataTable();
            //Update_Chart_TimeSeries();

            //Inizialization parameters 300, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 74880
            arduinoPort = new SerialPort(ArduinoCnx.Items[ArduinoCnx.SelectedIndex].ToString())
            {
                BaudRate = 9600,
                DataBits = 8,
                StopBits = StopBits.One,
                Parity = 0
            };

            arduinoThread = new Thread(new ThreadStart(this.Start_Arduino_Thread))
            {
                IsBackground = true
            };

            //Clear data points for new series
            dataPointCo1 = new List<DataPoint>();
            dataPointCo2 = new List<DataPoint>();
            dataPointCo3 = new List<DataPoint>();

            if (SeriesNo == 1)
            {
                kPa_series = kPaChart.Series["Series" + SeriesNo.ToString()];
            }
            else
            {
                //Create new series
                kPa_series = new Series("Series" + SeriesNo.ToString())
                {
                    ChartType = SeriesChartType.FastLine,
                    MarkerColor = Color.Green,
                    MarkerStyle = MarkerStyle.None
                };
                kPaChart.Series.Add(kPa_series);
            }
            //Reset data counter to 0

            if (SeriesNo2 == 1)
            {
                temp_series = TempChart.Series["Series" + SeriesNo2.ToString()];
            }
            else
            {
                //Create new series
                temp_series = new Series("Series" + SeriesNo2.ToString())
                {
                    ChartType = SeriesChartType.FastLine,
                    MarkerColor = Color.Black,
                    MarkerStyle = MarkerStyle.None
                };
                TempChart.Series.Add(temp_series);
            }
            //Reset data counter to 0
            if (SeriesNo3 == 1)
            {
                pSi_series = pSiChart.Series["Series" + SeriesNo3.ToString()];
                Thread.Sleep(0);
            }
            else
            {
                //Create new series
                pSi_series = new Series("Series" + SeriesNo3.ToString())
                {
                    ChartType = SeriesChartType.FastLine,
                    MarkerColor = Color.Black,
                    MarkerStyle = MarkerStyle.None
                };
                pSiChart.Series.Add(pSi_series);
            }
            //Reset data counter to 0
            Count = 0;
            arduinoThread.Start();
        }
        #endregion

        #region Clear Button
        private void ClearButton_Click(object sender, EventArgs e)
        {
            //Disable-Enable stop and pick-points buttons
            StopButton.Enabled = false;
            StartButton.Enabled = true;
            Table = new DataTable();
            //Clear data array
            dataPointCo1 = new List<DataPoint>();
            dataPointCo2 = new List<DataPoint>();
            dataPointCo3 = new List<DataPoint>();
            //stopWatch.Reset();

            //Clear graph plotting
            for (int i = 1; i <= SeriesNo; i++)
            {
                if (i == 1)
                {
                    kPaChart.Series["Series" + i.ToString()].Points.Clear();
                }
                else
                {
                    kPaChart.Series.Remove(kPaChart.Series["Series" + i.ToString()]);
                }
            }
            //Clear graph plotting
            for (int i = 1; i <= SeriesNo2; i++)
            {
                if (i == 1)
                {
                    TempChart.Series["Series" + i.ToString()].Points.Clear();
                }
                else
                {
                    TempChart.Series.Remove(TempChart.Series["Series" + i.ToString()]);
                }
            }
            //Clear graph plotting
            for (int i = 1; i <= SeriesNo3; i++)
            {
                if (i == 1)
                {
                    pSiChart.Series["Series" + i.ToString()].Points.Clear();
                }
                else
                {
                    pSiChart.Series.Remove(pSiChart.Series["Series" + i.ToString()]);
                }
            }
            //Clear count and seriesNo
            SeriesNo = 0;
            SeriesNo2 = 0;
            SeriesNo3 = 0;
            Count = 0;

        }
        #endregion

        #region Refresh Button
        private void RefreshButton_Click(object sender, EventArgs e)
        {
            AutodetectSerialPort();
        }
        #endregion

        #region Store Button
        private void StoreButton_Click(object sender, EventArgs e)
        {
            Table.ExportToExcel(folderPath); //("C:\\Users\\Public\\Documents11");
            //MainChart.SaveImage("C:\\Users\\sork-\\Desktop\\RMS_Integration_V6\\RMS_Integration\\main_chart.png", ChartImageFormat.Png);
            //chart1.SaveImage("C:\\Users\\sork-\\Desktop\\RMS_Integration_V6\\RMS_Integration\\chart.png", ChartImageFormat.Png);
            //chart2.SaveImage("C:\\Users\\sork-\\Desktop\\RMS_Integration_V6\\RMS_Integration\\chart2.png", ChartImageFormat.Png);
        }
        #endregion

        #region Stop Button
        private void StopButton_Click(object sender, EventArgs e)
        {
            //Disable-Enable stop button
            StartButton.Enabled = true;
            StopButton.Enabled = false;
            ClearButton.Enabled = true;
            StoreButton.Enabled = true;
            stopWatch.Reset();
            //Table = new DataTable();

            kPaChart.ResetAutoValues();
            pSiChart.ResetAutoValues();
            TempChart.ResetAutoValues();

            //Enable pick point buttons
            Stop_Arduino_Thread();

            //Errase string to arduino
            StringBuilder builtString = new StringBuilder();
            _settings = string.Empty;
        }
        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Pressure_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
