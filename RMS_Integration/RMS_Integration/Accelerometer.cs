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
using System.Data.SqlClient;


namespace RMS_Integration
{
    public partial class RMSApp : Form
    {

        private Thread arduinoThread;
        private SerialPort arduinoPort;

        private List<DataPoint> dataPointCo1 = new List<DataPoint>();
        private List<DataPoint> dataPointCo2 = new List<DataPoint>();
        private List<DataPoint> dataPointCo3 = new List<DataPoint>();
        private List<DataPoint> dataPointCo4 = new List<DataPoint>();
        private List<DataPoint> dataPointCo5 = new List<DataPoint>();
        private List<DataPoint> DataStorage = new List<DataPoint>();
        private DataTable Table = new DataTable();
        private DataColumn column;
        private DataRow RowV;
        private Stopwatch stopWatch = new Stopwatch();
        private double count = 0D; // the number of points in the data Array
        private int seriesNo = 0;
        private int seriesNo2 = 0;
        private int seriesNo3 = 0;
        private int seriesNo4 = 0;
        private int seriesNo5 = 0;
        private Series xaxis_series, temp_series, yaxis_series, alpha_series, beta_series;
        //private Series temp_series;
        //private Series yaxis_series;
        //private Series alpha_series;
        //private Series beta_series;
        private double pointsAfterR = 100D;
        private double pointInChart = 100D;
        private double pointsAfterRa = 50D;
        private double pointInCharta = 50D;
        private double[] _values = new double[6];
        private StringBuilder builtString = new StringBuilder();
        private string _settings = string.Empty;
        private string folderPath = string.Empty;

        double timeP;

        public RMSApp()
        {
            InitializeComponent();
            StopButton.Enabled = false; //Disable state at the begging
            StoreButton.Enabled = false;
            RefreshButton_Click(null, null);
            StartButton.Enabled = true;
            builtString.Append("<");

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

            //Acceleration in Y Chart Axis Labels
            YaxisChart.ChartAreas["ChartArea3"].AxisX.Title = "Samples (units)";
            YaxisChart.ChartAreas["ChartArea3"].AxisX.TitleAlignment = StringAlignment.Center;
            YaxisChart.ChartAreas["ChartArea3"].AxisX.TextOrientation = TextOrientation.Horizontal;
            //chart2.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 8, FontStyle.Bold);
            //chart2.ChartAreas["ChartArea1"].AxisX.Interval = 1; 
            YaxisChart.ChartAreas["ChartArea3"].AxisY.Title = "Acceleration Y-axis (mili-g)";
            YaxisChart.ChartAreas["ChartArea3"].AxisY.TitleAlignment = StringAlignment.Center;
            YaxisChart.ChartAreas["ChartArea3"].AxisY.TextOrientation = TextOrientation.Rotated270;
            //chart2.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 8, FontStyle.Bold); 

            //Acceleration in X Chart Axis Labels
            XaxisChart.ChartAreas["ChartArea2"].AxisX.Title = "Samples (units)";
            XaxisChart.ChartAreas["ChartArea2"].AxisX.TitleAlignment = StringAlignment.Center;
            XaxisChart.ChartAreas["ChartArea2"].AxisX.TextOrientation = TextOrientation.Horizontal;
            //MainChart.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 8, FontStyle.Bold);
            //MainChart.ChartAreas["ChartArea1"].AxisX.Interval = 1; 
            XaxisChart.ChartAreas["ChartArea2"].AxisY.Title = "Acceleration X-axis (mili-g)";
            XaxisChart.ChartAreas["ChartArea2"].AxisY.TitleAlignment = StringAlignment.Center;
            XaxisChart.ChartAreas["ChartArea2"].AxisY.TextOrientation = TextOrientation.Rotated270;
            //MainChart.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 8, FontStyle.Bold); 

            //Angle Alpha in X axis Labels
            AlphaChart.ChartAreas["ChartArea4"].AxisX.Title = "Samples (units)";
            AlphaChart.ChartAreas["ChartArea4"].AxisX.TitleAlignment = StringAlignment.Center;
            AlphaChart.ChartAreas["ChartArea4"].AxisX.TextOrientation = TextOrientation.Horizontal;
            //MainChart.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 8, FontStyle.Bold);
            //MainChart.ChartAreas["ChartArea1"].AxisX.Interval = 1; 
            AlphaChart.ChartAreas["ChartArea4"].AxisY.Title = "X-axis Rotation Angle (° arc)";
            AlphaChart.ChartAreas["ChartArea4"].AxisY.TitleAlignment = StringAlignment.Center;
            AlphaChart.ChartAreas["ChartArea4"].AxisY.TextOrientation = TextOrientation.Rotated270;
            //MainChart.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 8, FontStyle.Bold); 

            //Angle Beta in Y axis Labels
            BetaChart.ChartAreas["ChartArea5"].AxisX.Title = "Sample (units)";
            BetaChart.ChartAreas["ChartArea5"].AxisX.TitleAlignment = StringAlignment.Center;
            BetaChart.ChartAreas["ChartArea5"].AxisX.TextOrientation = TextOrientation.Horizontal;
            //MainChart.ChartAreas["ChartArea1"].AxisX.TitleFont = new Font("Arial", 8, FontStyle.Bold);
            //MainChart.ChartAreas["ChartArea1"].AxisX.Interval = 1; 
            BetaChart.ChartAreas["ChartArea5"].AxisY.Title = "Y-axis Rotation Angle (° arc)";
            BetaChart.ChartAreas["ChartArea5"].AxisY.TitleAlignment = StringAlignment.Center;
            BetaChart.ChartAreas["ChartArea5"].AxisY.TextOrientation = TextOrientation.Rotated270;
            //MainChart.ChartAreas["ChartArea1"].AxisY.TitleFont = new Font("Arial", 8, FontStyle.Bold); 
            #endregion

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
            ColumnName = "X-axis"
            };
            Table.Columns.Add(Column);

            //Create second column.
            Column = new DataColumn
            {
            DataType = Type.GetType("System.String"),
            ColumnName = "Y-axis"
            };
            Table.Columns.Add(Column);

            //Create fourth columnm.
            Column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Alpha-Angle"
            };
            Table.Columns.Add(Column);

            //Create fifth columnm.
            Column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Beta-Angle"
            };
            Table.Columns.Add(Column);

            //Create thrid columnm.
            Column = new DataColumn
            {
            DataType = Type.GetType("System.String"),
            ColumnName = "Temperature"
            };
            Table.Columns.Add(Column);

            ////Create fifth columnm.
            //Column = new DataColumn
            //{
            //    DataType = Type.GetType("System.String"),
            //    ColumnName = "Gamma-Angle"
            //};
            //Table.Columns.Add(Column);
            //Create sixth columnm.

            Column = new DataColumn
            {
                DataType = Type.GetType("System.String"),
                ColumnName = "Timer"
            };
            Table.Columns.Add(Column);

        }
        #endregion

        #region Baundrate Selector
        private static int SetPortBaudRate(int defaultPortBaudRate)
        {
            string baudRate;

            Console.Write("Baud Rate(default:{0}): ", defaultPortBaudRate);
            baudRate = Console.ReadLine();

            if (baudRate == "")
            {
                baudRate = defaultPortBaudRate.ToString();
            }

            return int.Parse(baudRate);
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

        #region Collect Data from SerialPort
        //Connect and Read Data
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
                var new_point4 = new DataPoint(Count, values[3]);
                dataPointCo4.Add(new_point4);
                var new_point5 = new DataPoint(Count, values[4]);
                dataPointCo5.Add(new_point5);

                Count++;

                if (XaxisChart.IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate { UpdateXvalues(dataPointCo1.ToArray()); UpdateXaxisChart_Maxium(); });
                }

                if (YaxisChart.IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate { UpdateYvalues(dataPointCo2.ToArray()); UpdateTempChart_Maxium(); });
                }

                if (AlphaChart.IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate { UpdateAlphavalues(dataPointCo3.ToArray()); UpdateAlphaChart_Maxium(); });
                }

                if (BetaChart.IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate { UpdateBetavalues(dataPointCo4.ToArray()); UpdateBetaChart_Maxium(); });
                }

                if (TempChart.IsHandleCreated)
                {
                    Invoke((MethodInvoker)delegate { UpdateTempvalues(dataPointCo5.ToArray()); UpdateYaxisChart_Maxium(); });
                }           
            }
        }
        private double[] Parse_Data_Line()
        {
            stopWatch.Start();
            //System.Timers.Timer aTimer = new System.Timers.Timer();
            try
            {
                string _line = arduinoPort.ReadLine();
                var stringList = _line.Trim().Split(null, 5);
            
                _values[0] = double.Parse(stringList[0]);
                _values[1] = double.Parse(stringList[1]);
                _values[2] = double.Parse(stringList[2]);
                _values[3] = double.Parse(stringList[3]);
                _values[4] = double.Parse(stringList[4]);
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
                double[] error = new double[5];
                error[0] = 0;
                error[1] = 0;
                error[2] = 0;
                error[3] = 0;
                error[4] = 0;
                return error;
            }
        }
        #endregion

        #region Update X-axis scale
        private void UpdateXaxisChart_Maxium()
        {
            XaxisChart.ResetAutoValues();
            if (XaxisChart.ChartAreas["ChartArea2"].AxisX.Maximum < Count)
            {
                XaxisChart.ChartAreas["ChartArea2"].AxisX.Maximum = Count;
            }
        }

        private void UpdateYaxisChart_Maxium()
        {
            YaxisChart.ResetAutoValues();
            if (YaxisChart.ChartAreas["ChartArea3"].AxisX.Maximum < Count)
            {
                YaxisChart.ChartAreas["ChartArea3"].AxisX.Maximum = Count;
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

        private void UpdateAlphaChart_Maxium()
        {
            AlphaChart.ResetAutoValues();
            if (AlphaChart.ChartAreas["ChartArea4"].AxisX.Maximum < Count)
            {
                AlphaChart.ChartAreas["ChartArea4"].AxisX.Maximum = Count;
            }
        }

        private void UpdateBetaChart_Maxium()
        {
            BetaChart.ResetAutoValues();
            if (BetaChart.ChartAreas["ChartArea5"].AxisX.Maximum < Count)
            {
                BetaChart.ChartAreas["ChartArea5"].AxisX.Maximum = Count;
            }
        }
        #endregion

        #region Draw Points into Series (Acceleration X-xis)
        //Plot data points from arduino for X axis
        private void UpdateXvalues(DataPoint[] array)
        {
            xaxis_series.Points.Clear();
            DataPointCollection dataA = xaxis_series.Points;

            for (int i = 0; i < array.LongLength - 1; i++)
            {
                dataA.Add(array[i]);
            }

            while (XaxisChart.Series[SeriesNo - 1].Points.Count > pointInChart)
            {
                while (XaxisChart.Series[SeriesNo - 1].Points.Count > pointsAfterR)
                {
                    XaxisChart.Series[SeriesNo - 1].Points.RemoveAt(0);
                }
                XaxisChart.ChartAreas["ChartArea2"].AxisX.Minimum = Count - pointsAfterR;
                XaxisChart.ChartAreas["ChartArea2"].AxisX.Maximum = XaxisChart.ChartAreas["ChartArea2"].AxisX.Minimum + pointInChart;
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

        #region Draw Points into Series (Acceleration Y-xis)
        //Plot data points from arduino for Y axis
        private void UpdateYvalues(DataPoint[] array3)
        {
            yaxis_series.Points.Clear();
            DataPointCollection dataAy = yaxis_series.Points;
            for (int i = 0; i < array3.LongLength - 1; i++)
            {
                dataAy.Add(array3[i]);
            }


            while (YaxisChart.Series[SeriesNo3 - 1].Points.Count > pointInChart)
            {
                while (YaxisChart.Series[SeriesNo3 - 1].Points.Count > pointsAfterR)
                {
                    YaxisChart.Series[SeriesNo3 - 1].Points.RemoveAt(0);
                }
                YaxisChart.ChartAreas["ChartArea3"].AxisX.Minimum = Count - pointsAfterR;
                YaxisChart.ChartAreas["ChartArea3"].AxisX.Maximum = YaxisChart.ChartAreas["ChartArea3"].AxisX.Minimum + pointInChart;
            }
        }
        #endregion

        #region Draw Points into Series (Alpha angle)
        private void UpdateAlphavalues(DataPoint[] array4)
        {
            alpha_series.Points.Clear();
            DataPointCollection dataA = alpha_series.Points;

            for (int i = 0; i < array4.LongLength - 1; i++)
            {
                dataA.Add(array4[i]);
            }

            while (AlphaChart.Series[SeriesNo4 - 1].Points.Count > pointInCharta)
            {
                while (AlphaChart.Series[SeriesNo4 - 1].Points.Count > pointsAfterRa)
                {
                    AlphaChart.Series[SeriesNo4 - 1].Points.RemoveAt(0);
                }
                AlphaChart.ChartAreas["ChartArea4"].AxisX.Minimum = Count - pointsAfterRa;
                AlphaChart.ChartAreas["ChartArea4"].AxisX.Maximum = AlphaChart.ChartAreas["ChartArea4"].AxisX.Minimum + pointInCharta;
            }
        }
        #endregion

        #region Draw Points into Series (Beta angle)
        private void UpdateBetavalues(DataPoint[] array5)
        {
            beta_series.Points.Clear();
            DataPointCollection dataB = beta_series.Points;

            for (int i = 0; i < array5.LongLength - 1; i++)
            {
                dataB.Add(array5[i]);
            }

            while (BetaChart.Series[SeriesNo5 - 1].Points.Count > pointInCharta)
            {
                while (BetaChart.Series[SeriesNo5 - 1].Points.Count > pointsAfterRa)
                {
                    BetaChart.Series[SeriesNo5 - 1].Points.RemoveAt(0);
                }
                BetaChart.ChartAreas["ChartArea5"].AxisX.Minimum = Count - pointsAfterRa;
                BetaChart.ChartAreas["ChartArea5"].AxisX.Maximum = BetaChart.ChartAreas["ChartArea5"].AxisX.Minimum + pointInCharta;
            }
        }
        #endregion

        #region Start Button
        private void StartButton_Click(object sender, EventArgs e)
        {
            SeriesNo++;
            SeriesNo2++;
            SeriesNo3++;
            SeriesNo4++;
            SeriesNo5++;
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
            dataPointCo4 = new List<DataPoint>();
            dataPointCo5 = new List<DataPoint>();

            if (SeriesNo == 1)
            {
                xaxis_series = XaxisChart.Series["Series" + SeriesNo.ToString()];
            }
            else
            {
                //Create new series
                xaxis_series = new Series("Series" + SeriesNo.ToString())
                {
                    ChartType = SeriesChartType.FastLine,
                    MarkerColor = Color.Green,
                    MarkerStyle = MarkerStyle.None
                };
                XaxisChart.Series.Add(xaxis_series);
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
                yaxis_series = YaxisChart.Series["Series" + SeriesNo3.ToString()];
                Thread.Sleep(0);
            }
            else
            {
                //Create new series
                yaxis_series = new Series("Series" + SeriesNo3.ToString())
                {
                    ChartType = SeriesChartType.FastLine,
                    MarkerColor = Color.Black,
                    MarkerStyle = MarkerStyle.None
                };
                YaxisChart.Series.Add(yaxis_series);
            }
            //Reset data counter to 0
            if (SeriesNo4 == 1)
            {
                alpha_series = AlphaChart.Series["Series" + SeriesNo4.ToString()];
                Thread.Sleep(0);
            }
            else
            {
                //Create new series
                alpha_series = new Series("Series" + SeriesNo4.ToString())
                {
                    ChartType = SeriesChartType.FastLine,
                    MarkerColor = Color.Black,
                    MarkerStyle = MarkerStyle.None
                };
                AlphaChart.Series.Add(alpha_series);
            }

            if (SeriesNo5 == 1)
            {
                beta_series = BetaChart.Series["Series" + SeriesNo5.ToString()];
                Thread.Sleep(0);
            }
            else
            {
                //Create new series
                beta_series = new Series("Series" + SeriesNo5.ToString())
                {
                    ChartType = SeriesChartType.FastLine,
                    MarkerColor = Color.Black,
                    MarkerStyle = MarkerStyle.None
                };
                BetaChart.Series.Add(beta_series);
            }
            Count = 0;
            arduinoThread.Start();
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

            XaxisChart.ResetAutoValues();
            YaxisChart.ResetAutoValues();
            TempChart.ResetAutoValues();
            AlphaChart.ResetAutoValues();
            BetaChart.ResetAutoValues();

            //Enable pick point buttons
            Stop_Arduino_Thread();

            //Errase string to arduino
            StringBuilder builtString = new StringBuilder();
            _settings = string.Empty;
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
            dataPointCo4 = new List<DataPoint>();
            dataPointCo5 = new List<DataPoint>();
            //stopWatch.Reset();

            //Clear graph plotting
            for (int i = 1; i <= SeriesNo; i++)
            {
                if (i == 1)
                {
                    XaxisChart.Series["Series" + i.ToString()].Points.Clear();
                }
                else
                {
                    XaxisChart.Series.Remove(XaxisChart.Series["Series" + i.ToString()]);
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
                    YaxisChart.Series["Series" + i.ToString()].Points.Clear();
                }
                else
                {
                    YaxisChart.Series.Remove(YaxisChart.Series["Series" + i.ToString()]);
                }
            }
            //Clear graph plotting
            for (int i = 1; i <= SeriesNo4; i++)
            {
                if (i == 1)
                {
                    AlphaChart.Series["Series" + i.ToString()].Points.Clear();
                }
                else
                {
                    AlphaChart.Series.Remove(AlphaChart.Series["Series" + i.ToString()]);
                }
            }
            //Clear graph plotting
            for (int i = 1; i <= SeriesNo5; i++)
            {
                if (i == 1)
                {
                    BetaChart.Series["Series" + i.ToString()].Points.Clear();
                }
                else
                {
                    BetaChart.Series.Remove(BetaChart.Series["Series" + i.ToString()]);
                }
            }
            //Clear count and seriesNo
            SeriesNo = 0;
            SeriesNo2 = 0;
            SeriesNo3 = 0;
            SeriesNo4 = 0;
            SeriesNo5 = 0;
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

        #region Call Python
        //Source https://medium.com/emoney-engineering/running-python-script-from-c-and-working-with-the-results-843e68d230e5
        private string Run_cmd(string cmd, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo
            {
                FileName = "Y:\\My Drive\\MSc Mario Soriano Documents\\VS_Code\\RMS_Integration_V13\\RMS_Integration\\CNN_Python\\DNN_Python_Method.py",
                Arguments = string.Format("\"{0}\" \"{1}\"", cmd, args),
                UseShellExecute = false,
                CreateNoWindow = true,
                //Any output, generated by application will be redirected back
                RedirectStandardOutput = true,
                //Any error in standard output will be redirected back (for example exceptions)
                RedirectStandardError = true
            };
            using (Process process = Process.Start(start))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    //Exceptions from Python script
                    string stderr = process.StandardError.ReadToEnd();
                    //Result of StdOut
                    string result = reader.ReadToEnd();
                    return result;
                }
            }
        }
        #endregion

        #region Save to Excel Sheet
        private void ExportDataToExcel(DataTable Dt, string Filepath)
        //private void ExportDataToExcel(Dt, string Filepath)
        {
            if (string.IsNullOrWhiteSpace(Filepath))
            {
                throw new ArgumentException("Filepath not found", nameof(Filepath));
            }

            object missing = Type.Missing;
            object misValue = System.Reflection.Missing.Value;

            //Editing and Formatting Excel Sheet
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb = excel.Workbooks.Add();
            Excel.Worksheet ws = wb.Sheets[1] as Excel.Worksheet;
            Excel.Worksheet ws2 = wb.Sheets[2] as Excel.Worksheet;
            ws.Range["A1", "A1"].EntireRow.Font.Bold = true;
            ws.Columns.AutoFit();
            ws.Application.ActiveWindow.SplitRow = 1;
            ws.Application.ActiveWindow.FreezePanes = true;

            //Populating the excel sheet
            int rowCount = 1;

            foreach (DataRow Dr in Table.Rows)
            {
                rowCount += 1;

                for (int i = 1; i < Dt.Columns.Count + 1; i++)
                {
                    if (rowCount == 2)
                    {
                        ws.Cells[1, i] = Dt.Columns[i - 1].ColumnName;
                        ws.Cells[1, i].Interior.Colorindex = 40;
                        // Add cell border
                        ws.Cells[1, i].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }

                    ws.Cells[rowCount, i] = Dr[i - 1].ToString();

                    ws.Cells[rowCount, i].Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }
            }

            Excel.Range range = (Excel.Range)ws.UsedRange;
            Console.Write(range.ToString());
        }
        #endregion

        public int SeriesNo3 { get => seriesNo3; set => seriesNo3 = value; }
        public int SeriesNo2 { get => seriesNo2; set => seriesNo2 = value; }
        public int SeriesNo { get => seriesNo; set => seriesNo = value; }
        public double Count { get => count; set => count = value; }
        public DataColumn Column { get => column; set => column = value; }
        public double[] Values { get => _values; set => _values = value; }
        public int SeriesNo4 { get => seriesNo4; set => seriesNo4 = value; }
        public int SeriesNo5 { get => seriesNo5; set => seriesNo5 = value; }

        private void Settings1_Click(object sender, EventArgs e)
        {
            builtString.Append(">");
            _settings = builtString.ToString();
        }

        private void Path1_Click(object sender, EventArgs e)
        {
            
        }

        private void CombRotation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string curItemValues = listRotation.SelectedItem.ToString();
            builtString.Append(combRotation.SelectedItem.ToString() + ",");
        }

        private void CombSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            builtString.Append(combSpeed.SelectedItem.ToString() + ",");
        }

        private void CombMaxSpeed_SelectedIndexChanged(object sender, EventArgs e)
        {
            builtString.Append(combMaxSpeed.SelectedItem.ToString() + ",");
        }

        private void CombAccel_SelectedIndexChanged(object sender, EventArgs e)
        {
            builtString.Append(combAccel.SelectedItem.ToString());
        }
    }

#region Save to Excel
    public static class My_DataTable_Extensions
    {

        // Export DataTable into an excel file with field names in the header line
        // - Save excel file without ever making it visible if filepath is given
        // - Don't save excel file, just make it visible if no filepath is given
        public static void ExportToExcel(this DataTable DataT, string excelFilePath = null)
        {
            try
            {
                if (DataT == null || DataT.Columns.Count == 0)
                    throw new Exception("ExportToExcel: Null or empty input table!\n");

                // load excel, and create a new workbook
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();

                // single worksheet
                Excel._Worksheet workSheet = excelApp.ActiveSheet;

                // column headings
                for (var i = 0; i < DataT.Columns.Count; i++)
                {
                    workSheet.Cells[1, i + 1] = DataT.Columns[i].ColumnName;
                }

                // rows
                for (var i = 0; i < DataT.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < DataT.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 2, j + 1] = DataT.Rows[i][j];
                    }
                }

                // check file path
                if (!string.IsNullOrEmpty(excelFilePath))
                {
                    try
                    {
                        workSheet.SaveAs(excelFilePath, 6);
                        workSheet.SaveAs(excelFilePath);
                        excelApp.Quit();
                        MessageBox.Show("Excel file saved!");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("ExportToExcel: Excel file could not be saved! Check filepath.\n"
                                            + ex.Message);
                    }
                }
                else
                { // no file path is given
                    //var folderBrowserDialog1 = new FolderBrowserDialog();
                    //string fullPath;
                    
                    //// Show the FolderBrowserDialog.
                    //DialogResult result = folderBrowserDialog1.ShowDialog();
                    //if (result == DialogResult.OK)
                    //{
                    //    excelFilePath = folderBrowserDialog1.SelectedPath;
                    //    fullPath = excelFilePath + "\\dataset";
                    //    workSheet.SaveAs(fullPath, 6);
                    //    excelApp.Quit();
                    //    MessageBox.Show("Excel file saved!");
                        //catch (Exception)
                        //{
                        //    string newFullPath;
                        //    if (File.Exists(fullPath))
                        //    {
                        //        int count = 1;
                        //        string extension = Path.GetExtension(fullPath);
                        //        do
                        //        {
                        //            count++;
                        //            //string tempFileName = string.Format("{0}({1})", "\\dataset", count++);
                        //            fullPath = Path.Combine(excelFilePath, string.Format("{0} ({1})", "\\dataset", count++));

                        //            //fullPath = Path.Combine(excelFilePath, tempFileName);
                        //        }
                        //        while (File.Exists(fullPath));
                        //    }
                        //    workSheet.SaveAs(fullPath, 6);
                        //    excelApp.Quit();
                        //    MessageBox.Show("Excel file saved!");
                        //}
                    //}
                    excelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
    }
    #endregion
}