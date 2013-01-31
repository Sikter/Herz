using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Herz.Algorithm;
using Herz.Estimator;
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

        string ecgFile;
        string segmentStartFile;
        string segmentStopFile;

        CSVReader reader;
        int bufferSize = 250;
        int samplingFrequency = 1250;
        int plotFrequency;
        LowPassFilter lp = new LowPassFilter();
        DerivativeFilter derivative = new DerivativeFilter();
        SquareFilter square = new SquareFilter();
        MWI integrator = new MWI();
        Pipeline<ECGSample> PanTompkins;
        Detector detector;
        Estimator.Estimator estimator;

        bool stop;


        bool followIncomingData = true;

        public MainForm()
        {
            InitializeComponent();
            InitializeGraphs(rawDataGraph, SeriesChartType.FastLine, -0.5, 0.8);
            InitializeGraphs(hrSignalGraph,SeriesChartType.FastLine, -0.03, 0.1);
            
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
                    //hrSignalGraph.Series[1].Points.AddXY(qrs.Index, 1 / qrs.Value);
                    rawDataGraph.Series[1].Points.AddXY(qrs.Index, 1 / qrs.Value);
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
                    {
                        detectedQRSQueue.Add(new ECGSample(s.Index, s.Value));
                        estimator.RRPeaks.Add(new ECGSample(s.Index, s.Value));
                        RecalculateFeatures();
                    }
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

            //chartArea.AxisY.Minimum = yMin;
            //chartArea.AxisY.Maximum = yMax;
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

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ecgFile) || String.IsNullOrEmpty(segmentStartFile) || String.IsNullOrEmpty(segmentStopFile)) 
            {
                MessageBox.Show("Load all neccesary files", "Missing files", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //"D:\\Fax\\Diplomski\\3.Semestar\\ISS\\data\\S_04_ecg.csv"
                reader = new CSVReader(ecgFile, bufferSize, samplingFrequency);
                reader.DataReady += new EventHandler<Herz.Common.DataReadyEventArgs>(reader_DataReady);

                PanTompkins = new Pipeline<ECGSample>(reader.Frequency);
                PanTompkins.Register(lp);
                PanTompkins.Register(derivative);
                PanTompkins.Register(square);
                PanTompkins.Register(integrator);
                PanTompkins.Register(new Delay(PanTompkins.FilterDelay));

                detector = new Detector(samplingFrequency, bufferSize);
                estimator = EstimatorFactory.CreateEstimatorFromFile(segmentStartFile, segmentStopFile, samplingFrequency);

                cBoxSegments.DataSource = estimator.Segments;
                cBoxSegments.DisplayMember = "Index";
                cBoxSegments.ValueMember = "Index";

                

                // Plot data with 50 samples per second.
                plotFrequency = reader.Frequency / 50;

                TaskScheduler uiScheduler = TaskScheduler.FromCurrentSynchronizationContext();
                Task.Factory.StartNew(() => reader.Read());
                Task.Factory.StartNew(() => PlotRaw(uiScheduler));
                //Task.Factory.StartNew(() => PlotProcessed(uiScheduler));
                Task.Factory.StartNew(() => PlotDetectedQRS(uiScheduler));
            }
        }

        private void eCGFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) 
            {
                ecgFile = openFileDialog.FileName;
                eCGFileToolStripMenuItem.DropDownItems.Clear();
                eCGFileToolStripMenuItem.DropDownItems.Add(ecgFile);
            }
        }

        private void segmentStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                segmentStartFile = openFileDialog.FileName;
                segmentStartToolStripMenuItem.DropDownItems.Clear();
                segmentStartToolStripMenuItem.DropDownItems.Add(segmentStartFile);
            }
        }

        private void segmentEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                segmentStopFile = openFileDialog.FileName;
                segmentEndToolStripMenuItem.DropDownItems.Clear();
                segmentEndToolStripMenuItem.DropDownItems.Add(segmentStopFile);
            }
        }

        private void cBoxSegments_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecalculateFeatures();
        }

        private void RecalculateFeatures()
        {
            this.Invoke((MethodInvoker)delegate()
            {
                txtBoxMeanX.Text = estimator.CalcMeanX((cBoxSegments.SelectedItem as Segment).Index).ToString();
                txtBoxStdX.Text = estimator.CalcStdX((cBoxSegments.SelectedItem as Segment).Index).ToString();
                txtBoxMinX.Text = estimator.CalcMinX((cBoxSegments.SelectedItem as Segment).Index).ToString();
                txtBoxMaxX.Text = estimator.CalcMaxX((cBoxSegments.SelectedItem as Segment).Index).ToString();
                txtBoxDiffMM.Text = estimator.CalcDiffMMX((cBoxSegments.SelectedItem as Segment).Index).ToString();
                txtBoxMeanAbsFD.Text = estimator.CalcMeanAbsFD((cBoxSegments.SelectedItem as Segment).Index).ToString();
                txtBoxMeanAbsFD2.Text = estimator.CalcMeanAbsFD2((cBoxSegments.SelectedItem as Segment).Index).ToString();
            });
            
        }
    }
}
