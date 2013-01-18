using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herz.Algorithm;
using System.Windows.Forms.DataVisualization.Charting;
using Herz.Common;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;


namespace Herz.GUI
{
    public partial class MainForm : Form
    {
        BlockingCollection<ECGSample> rawQueue = new BlockingCollection<ECGSample>();
        BlockingCollection<ECGSample> filteredQueue = new BlockingCollection<ECGSample>();
        BlockingCollection<ECGSample> detectedQRSQueue = new BlockingCollection<ECGSample>();
        
        CSVReader reader;
        int plotFrequency;
        LowPassFilter lp = new LowPassFilter();
        DerivativeFilter derivative = new DerivativeFilter();
        SquareFilter square = new SquareFilter();
        MWI integrator = new MWI();
        Detector detector;
        Pipeline<ECGSample> PanTompkins;
        bool stop;


        bool followIncomingData = true;

        public MainForm()
        {
            InitializeComponent();
            InitializeGraphs(rawDataGraph, SeriesChartType.FastLine, -0.5, 0.8);
            InitializeGraphs(hrSignalGraph,SeriesChartType.FastLine, -0.03, 0.1);

            reader = new CSVReader("D:\\Fax\\Diplomski\\3.Semestar\\ISS\\ecg.csv", 250, 1250);
            reader.DataReady += new EventHandler<Herz.Common.DataReadyEventArgs>(reader_DataReady);

            PanTompkins = new Pipeline<ECGSample>(reader.Frequency);
            PanTompkins.Register(lp);
            PanTompkins.Register(derivative);
            PanTompkins.Register(square);
            PanTompkins.Register(integrator);
            PanTompkins.Register(new Delay(PanTompkins.FilterDelay));
            detector = new Detector(PanTompkins.samplingFrequency);
            

            // Plot data with 50 samples per second.
            plotFrequency = reader.Frequency / 50;

            TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.StartNew(() => reader.Read());
            Task.Factory.StartNew(() => PlotRaw(uiScheduler));
            Task.Factory.StartNew(() => PlotProcessed(uiScheduler));
            Task.Factory.StartNew(() => PlotDetectedQRS(uiScheduler));
        }

        private void PlotRaw(TaskScheduler uiScheduler)
        {
            foreach (var value in rawQueue.GetConsumingEnumerable())
            {
                ECGSample sample = new ECGSample(value.Index, value.Value);
                Task.Factory.StartNew(() =>
                {
                    if (sample.Index % plotFrequency == 0)
                    {
                        if (followIncomingData)
                            rawDataGraph.ChartAreas[0].AxisX.ScaleView.Scroll(rawDataGraph.ChartAreas[0].AxisX.Maximum);
                        rawDataGraph.Series[0].Points.AddXY(sample.Index, sample.Value);
                    }
                }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
            }
        }

        private void PlotProcessed(TaskScheduler uiScheduler)
        {
            foreach (var value in filteredQueue.GetConsumingEnumerable())
            {
                ECGSample sample = new ECGSample(value.Index, value.Value);
                Task.Factory.StartNew(() =>
                {
                    if (sample.Index % plotFrequency == 0 && sample.Index >= 0)
                    {
                        if (followIncomingData)
                            hrSignalGraph.ChartAreas[0].AxisX.ScaleView.Scroll(hrSignalGraph.ChartAreas[0].AxisX.Maximum);
                        hrSignalGraph.Series[0].Points.AddXY(sample.Index, sample.Value);
                    }
                }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
            }    
        }


        private void PlotDetectedQRS(TaskScheduler uiScheduler)
        {
            foreach (var value in detectedQRSQueue.GetConsumingEnumerable())
            {
                ECGSample qrs = new ECGSample(value.Index, value.Value);
                Task.Factory.StartNew(() =>
                {
                    hrSignalGraph.Series[1].Points.AddXY(qrs.Index, 1 / qrs.Value);
                }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
            }
        }


        void reader_DataReady(object sender, Herz.Common.DataReadyEventArgs e)
        {
            if (!stop)
            {
                foreach (ECGSample s in e.ECGSignalChunk)
                    if (!rawQueue.IsAddingCompleted)
                        rawQueue.Add(new ECGSample(s.Index, s.Value));

                List<ECGSample> filteredChunk = PanTompkins.Execute(e.ECGSignalChunk).ToList();

                foreach (ECGSample s in filteredChunk)
                {
                    if (!filteredQueue.IsAddingCompleted)
                        filteredQueue.Add(new ECGSample(s.Index, s.Value));
                }

                foreach (ECGSample s in detector.Execute(filteredChunk))
                {
                    if (!detectedQRSQueue.IsAddingCompleted)
                        detectedQRSQueue.Add(new ECGSample(s.Index, s.Value));
                }
            }

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop = true;
            rawQueue.CompleteAdding();
            filteredQueue.CompleteAdding();
            detectedQRSQueue.CompleteAdding();
        }

        private void InitializeGraphs(Chart chart, SeriesChartType type, double yMin, double yMax)
        {
            chart.Legends.Clear();

            var series = chart.Series[0];
            if(chart.Series.Count > 1)
                chart.Series[1].ChartType = SeriesChartType.Point;
            var chartArea = chart.ChartAreas[0];

            series.ChartType = type;
            
            
            series.XValueType = ChartValueType.Int32;
            
            chartArea.AxisX.ScrollBar.Enabled = true;
            chartArea.AxisX.ScrollBar.IsPositionedInside = false;
            chartArea.AxisX.ScaleView.Size = 10000;
            chartArea.AxisX.MajorTickMark.Interval = 1250;
            chartArea.AxisX.MajorGrid.Interval = 1250;
            chartArea.CursorX.AutoScroll = true;
            chartArea.CursorX.IsUserEnabled = true;
            chartArea.CursorX.IsUserSelectionEnabled = true;
            chartArea.AxisX.ScaleView.Zoomable = true;

            chartArea.AxisX.Minimum = 0;

            chartArea.AxisY.Minimum = yMin;
            chartArea.AxisY.Maximum = yMax;
        }

        private void chkBoxFollowIncomingData_CheckedChanged(object sender, EventArgs e)
        {
            followIncomingData = chkBoxFollowIncomingData.Checked;
        }

        private void rawDataGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.None)
                WriteLabels(e.Location, rawDataGraph);
        }

        private void hrSignalGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.None)
                WriteLabels(e.Location, hrSignalGraph);
        }

        private void WriteLabels(Point pos, Chart chart) 
        {
            chart.ChartAreas[0].RecalculateAxesScale();
            var pointXPixel = chart.ChartAreas[0].AxisX.PixelPositionToValue(pos.X);
            var pointYPixel = chart.ChartAreas[0].AxisY.PixelPositionToValue(pos.Y);

            toolStripLblX.Text = ((int)pointXPixel).ToString();
            toolStripLblY.Text = (Math.Floor((pointYPixel * 100000) + 0.5) / 100000).ToString();
        }
    }
}
