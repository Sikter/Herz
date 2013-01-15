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
        BlockingCollection<ECGSample> processedQueue = new BlockingCollection<ECGSample>();
        List<ECGSample> test = new List<ECGSample>();
        CSVReader reader;
        int plotFrequency;
        LowPassFilter lp = new LowPassFilter();
        DerivativeFilter derivative = new DerivativeFilter();
        SquareFilter square = new SquareFilter();
        MWI integrator = new MWI();
        Pipeline<ECGSample> PanTompkins = new Pipeline<ECGSample>();
        List<ECGSample> algorithmData = new List<ECGSample>();

        bool followIncomingData = true;

        public MainForm()
        {
            InitializeComponent();
            InitializeGraphs(rawDataGraph, -0.5, 0.8);
            InitializeGraphs(hrSignalGraph, -0.02, 0.1);
            
            PanTompkins.Register(lp);
            PanTompkins.Register(derivative);
            PanTompkins.Register(square);
            PanTompkins.Register(integrator);

            reader = new CSVReader("D:\\Fax\\Diplomski\\3.Semestar\\ISS\\ecg.csv", 100, 1250);
            reader.DataReady += new EventHandler<Herz.Common.DataReadyEventArgs>(reader_DataReady);

            // Plot data with 25 samples per second.
            plotFrequency = reader.Frequency / 1250;

            TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            Task.Factory.StartNew(() => { reader.Read(); });
            Task.Factory.StartNew( () => PlotRaw(uiScheduler) );
            Task.Factory.StartNew(() => PlotProcessed(uiScheduler));
           
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
            foreach (var value in processedQueue.GetConsumingEnumerable())
            {
                Task.Factory.StartNew(() =>
                {
                    if (followIncomingData)
                        hrSignalGraph.ChartAreas[0].AxisX.ScaleView.Scroll(hrSignalGraph.ChartAreas[0].AxisX.Maximum);
                    hrSignalGraph.Series[0].Points.AddXY(value.Index, value.Value);
                }, CancellationToken.None, TaskCreationOptions.None, uiScheduler);
            }
        }

        void reader_DataReady(object sender, Herz.Common.DataReadyEventArgs e)
        {
            foreach (ECGSample s in e.ECGSignalChunk) 
            {
                ECGSample sample = new ECGSample(s.Index, s.Value);
                if(!rawQueue.IsAddingCompleted)
                    rawQueue.Add(sample);
            }
            foreach (ECGSample s in PanTompkins.Execute(e.ECGSignalChunk))
            {
                ECGSample sample = new ECGSample(s.Index, s.Value);
                if (!processedQueue.IsAddingCompleted)
                    processedQueue.Add(sample);
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            rawQueue.CompleteAdding();
            processedQueue.CompleteAdding();
        }

        private void InitializeGraphs(Chart chart, double yMin, double yMax)
        {
            chart.Legends.Clear();

            var series = chart.Series[0];
            var chartArea = chart.ChartAreas[0];

            series.ChartType = SeriesChartType.FastLine;
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
            WriteLabels(e.Location, rawDataGraph);
        }

        private void hrSignalGraph_MouseMove(object sender, MouseEventArgs e)
        {
            WriteLabels(e.Location, hrSignalGraph);
        }

        private void WriteLabels(Point pos, Chart chart) 
        {
            var pointXPixel = chart.ChartAreas[0].AxisX.PixelPositionToValue(pos.X);
            var pointYPixel = chart.ChartAreas[0].AxisY.PixelPositionToValue(pos.Y);

            toolStripLblX.Text = ((int)pointXPixel).ToString();
            toolStripLblY.Text = (Math.Floor((pointYPixel * 100000) + 0.5) / 100000).ToString();
        }

        
    }
}
