using System.Windows.Forms.DataVisualization.Charting;
namespace Herz.GUI
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eCGFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.segmentEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grBoxRawData = new System.Windows.Forms.GroupBox();
            this.rawDataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grBoxHRSignal = new System.Windows.Forms.GroupBox();
            this.hrSignalGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grBoxControls = new System.Windows.Forms.GroupBox();
            this.txtBoxMeanAbsFD2 = new System.Windows.Forms.TextBox();
            this.txtBoxMeanAbsFD = new System.Windows.Forms.TextBox();
            this.txtBoxDiffMM = new System.Windows.Forms.TextBox();
            this.txtBoxMaxX = new System.Windows.Forms.TextBox();
            this.txtBoxMinX = new System.Windows.Forms.TextBox();
            this.txtBoxMeanFDX = new System.Windows.Forms.TextBox();
            this.txtBoxStdX = new System.Windows.Forms.TextBox();
            this.txtBoxMeanX = new System.Windows.Forms.TextBox();
            this.lblMeanAbsFD2 = new System.Windows.Forms.Label();
            this.lblMeanAbsFD = new System.Windows.Forms.Label();
            this.lblDifMM = new System.Windows.Forms.Label();
            this.lblMaxX = new System.Windows.Forms.Label();
            this.lblMINX = new System.Windows.Forms.Label();
            this.lblMeanFDX = new System.Windows.Forms.Label();
            this.lblStdX = new System.Windows.Forms.Label();
            this.lblMeanX = new System.Windows.Forms.Label();
            this.cBoxSegments = new System.Windows.Forms.ComboBox();
            this.lblSegments = new System.Windows.Forms.Label();
            this.chkBoxFollowIncomingData = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLblX = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLblY = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip.SuspendLayout();
            this.grBoxRawData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rawDataGraph)).BeginInit();
            this.grBoxHRSignal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrSignalGraph)).BeginInit();
            this.grBoxControls.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFilesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(885, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // openFilesToolStripMenuItem
            // 
            this.openFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eCGFileToolStripMenuItem,
            this.segmentStartToolStripMenuItem,
            this.segmentEndToolStripMenuItem});
            this.openFilesToolStripMenuItem.Name = "openFilesToolStripMenuItem";
            this.openFilesToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.openFilesToolStripMenuItem.Text = "Open files";
            // 
            // eCGFileToolStripMenuItem
            // 
            this.eCGFileToolStripMenuItem.Name = "eCGFileToolStripMenuItem";
            this.eCGFileToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eCGFileToolStripMenuItem.Text = "ECG file";
            this.eCGFileToolStripMenuItem.Click += new System.EventHandler(this.eCGFileToolStripMenuItem_Click);
            // 
            // segmentStartToolStripMenuItem
            // 
            this.segmentStartToolStripMenuItem.Name = "segmentStartToolStripMenuItem";
            this.segmentStartToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.segmentStartToolStripMenuItem.Text = "Segment Start";
            this.segmentStartToolStripMenuItem.Click += new System.EventHandler(this.segmentStartToolStripMenuItem_Click);
            // 
            // segmentEndToolStripMenuItem
            // 
            this.segmentEndToolStripMenuItem.Name = "segmentEndToolStripMenuItem";
            this.segmentEndToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.segmentEndToolStripMenuItem.Text = "Segment End";
            this.segmentEndToolStripMenuItem.Click += new System.EventHandler(this.segmentEndToolStripMenuItem_Click);
            // 
            // grBoxRawData
            // 
            this.grBoxRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxRawData.Controls.Add(this.rawDataGraph);
            this.grBoxRawData.Location = new System.Drawing.Point(13, 28);
            this.grBoxRawData.Name = "grBoxRawData";
            this.grBoxRawData.Size = new System.Drawing.Size(597, 219);
            this.grBoxRawData.TabIndex = 2;
            this.grBoxRawData.TabStop = false;
            this.grBoxRawData.Text = "ECG Data";
            // 
            // rawDataGraph
            // 
            this.rawDataGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.rawDataGraph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.rawDataGraph.Legends.Add(legend1);
            this.rawDataGraph.Location = new System.Drawing.Point(13, 19);
            this.rawDataGraph.Margin = new System.Windows.Forms.Padding(10);
            this.rawDataGraph.Name = "rawDataGraph";
            this.rawDataGraph.Padding = new System.Windows.Forms.Padding(10);
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "ECG data";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series2";
            this.rawDataGraph.Series.Add(series1);
            this.rawDataGraph.Series.Add(series2);
            this.rawDataGraph.Size = new System.Drawing.Size(571, 194);
            this.rawDataGraph.TabIndex = 0;
            this.rawDataGraph.Text = "Raw data graph";
            this.rawDataGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.rawDataGraph_MouseMove);
            // 
            // grBoxHRSignal
            // 
            this.grBoxHRSignal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxHRSignal.Controls.Add(this.hrSignalGraph);
            this.grBoxHRSignal.Location = new System.Drawing.Point(13, 253);
            this.grBoxHRSignal.Name = "grBoxHRSignal";
            this.grBoxHRSignal.Size = new System.Drawing.Size(597, 219);
            this.grBoxHRSignal.TabIndex = 3;
            this.grBoxHRSignal.TabStop = false;
            this.grBoxHRSignal.Text = "HR signal";
            // 
            // hrSignalGraph
            // 
            this.hrSignalGraph.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.AxisY.Maximum = 0.7D;
            chartArea2.Name = "ChartArea1";
            this.hrSignalGraph.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.hrSignalGraph.Legends.Add(legend2);
            this.hrSignalGraph.Location = new System.Drawing.Point(13, 26);
            this.hrSignalGraph.Margin = new System.Windows.Forms.Padding(10);
            this.hrSignalGraph.Name = "hrSignalGraph";
            this.hrSignalGraph.Padding = new System.Windows.Forms.Padding(10);
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.hrSignalGraph.Series.Add(series3);
            this.hrSignalGraph.Series.Add(series4);
            this.hrSignalGraph.Size = new System.Drawing.Size(571, 180);
            this.hrSignalGraph.TabIndex = 0;
            this.hrSignalGraph.Text = "HR signal";
            this.hrSignalGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.hrSignalGraph_MouseMove);
            // 
            // grBoxControls
            // 
            this.grBoxControls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxControls.Controls.Add(this.txtBoxMeanAbsFD2);
            this.grBoxControls.Controls.Add(this.txtBoxMeanAbsFD);
            this.grBoxControls.Controls.Add(this.txtBoxDiffMM);
            this.grBoxControls.Controls.Add(this.txtBoxMaxX);
            this.grBoxControls.Controls.Add(this.txtBoxMinX);
            this.grBoxControls.Controls.Add(this.txtBoxMeanFDX);
            this.grBoxControls.Controls.Add(this.txtBoxStdX);
            this.grBoxControls.Controls.Add(this.txtBoxMeanX);
            this.grBoxControls.Controls.Add(this.lblMeanAbsFD2);
            this.grBoxControls.Controls.Add(this.lblMeanAbsFD);
            this.grBoxControls.Controls.Add(this.lblDifMM);
            this.grBoxControls.Controls.Add(this.lblMaxX);
            this.grBoxControls.Controls.Add(this.lblMINX);
            this.grBoxControls.Controls.Add(this.lblMeanFDX);
            this.grBoxControls.Controls.Add(this.lblStdX);
            this.grBoxControls.Controls.Add(this.lblMeanX);
            this.grBoxControls.Controls.Add(this.cBoxSegments);
            this.grBoxControls.Controls.Add(this.lblSegments);
            this.grBoxControls.Controls.Add(this.chkBoxFollowIncomingData);
            this.grBoxControls.Controls.Add(this.btnStop);
            this.grBoxControls.Controls.Add(this.btnStart);
            this.grBoxControls.Location = new System.Drawing.Point(616, 28);
            this.grBoxControls.Name = "grBoxControls";
            this.grBoxControls.Size = new System.Drawing.Size(257, 444);
            this.grBoxControls.TabIndex = 2;
            this.grBoxControls.TabStop = false;
            this.grBoxControls.Text = "Controls";
            // 
            // txtBoxMeanAbsFD2
            // 
            this.txtBoxMeanAbsFD2.Location = new System.Drawing.Point(88, 271);
            this.txtBoxMeanAbsFD2.Name = "txtBoxMeanAbsFD2";
            this.txtBoxMeanAbsFD2.ReadOnly = true;
            this.txtBoxMeanAbsFD2.Size = new System.Drawing.Size(103, 20);
            this.txtBoxMeanAbsFD2.TabIndex = 18;
            // 
            // txtBoxMeanAbsFD
            // 
            this.txtBoxMeanAbsFD.Location = new System.Drawing.Point(88, 245);
            this.txtBoxMeanAbsFD.Name = "txtBoxMeanAbsFD";
            this.txtBoxMeanAbsFD.ReadOnly = true;
            this.txtBoxMeanAbsFD.Size = new System.Drawing.Size(103, 20);
            this.txtBoxMeanAbsFD.TabIndex = 17;
            // 
            // txtBoxDiffMM
            // 
            this.txtBoxDiffMM.Location = new System.Drawing.Point(88, 219);
            this.txtBoxDiffMM.Name = "txtBoxDiffMM";
            this.txtBoxDiffMM.ReadOnly = true;
            this.txtBoxDiffMM.Size = new System.Drawing.Size(103, 20);
            this.txtBoxDiffMM.TabIndex = 16;
            // 
            // txtBoxMaxX
            // 
            this.txtBoxMaxX.Location = new System.Drawing.Point(88, 193);
            this.txtBoxMaxX.Name = "txtBoxMaxX";
            this.txtBoxMaxX.ReadOnly = true;
            this.txtBoxMaxX.Size = new System.Drawing.Size(103, 20);
            this.txtBoxMaxX.TabIndex = 15;
            // 
            // txtBoxMinX
            // 
            this.txtBoxMinX.Location = new System.Drawing.Point(88, 167);
            this.txtBoxMinX.Name = "txtBoxMinX";
            this.txtBoxMinX.ReadOnly = true;
            this.txtBoxMinX.Size = new System.Drawing.Size(103, 20);
            this.txtBoxMinX.TabIndex = 14;
            // 
            // txtBoxMeanFDX
            // 
            this.txtBoxMeanFDX.Location = new System.Drawing.Point(88, 141);
            this.txtBoxMeanFDX.Name = "txtBoxMeanFDX";
            this.txtBoxMeanFDX.ReadOnly = true;
            this.txtBoxMeanFDX.Size = new System.Drawing.Size(103, 20);
            this.txtBoxMeanFDX.TabIndex = 13;
            // 
            // txtBoxStdX
            // 
            this.txtBoxStdX.Location = new System.Drawing.Point(88, 115);
            this.txtBoxStdX.Name = "txtBoxStdX";
            this.txtBoxStdX.ReadOnly = true;
            this.txtBoxStdX.Size = new System.Drawing.Size(103, 20);
            this.txtBoxStdX.TabIndex = 12;
            // 
            // txtBoxMeanX
            // 
            this.txtBoxMeanX.Location = new System.Drawing.Point(88, 89);
            this.txtBoxMeanX.Name = "txtBoxMeanX";
            this.txtBoxMeanX.ReadOnly = true;
            this.txtBoxMeanX.Size = new System.Drawing.Size(103, 20);
            this.txtBoxMeanX.TabIndex = 1;
            // 
            // lblMeanAbsFD2
            // 
            this.lblMeanAbsFD2.AutoSize = true;
            this.lblMeanAbsFD2.Location = new System.Drawing.Point(7, 274);
            this.lblMeanAbsFD2.Name = "lblMeanAbsFD2";
            this.lblMeanAbsFD2.Size = new System.Drawing.Size(75, 13);
            this.lblMeanAbsFD2.TabIndex = 11;
            this.lblMeanAbsFD2.Text = "MeanAbsFD2:";
            // 
            // lblMeanAbsFD
            // 
            this.lblMeanAbsFD.AutoSize = true;
            this.lblMeanAbsFD.Location = new System.Drawing.Point(13, 248);
            this.lblMeanAbsFD.Name = "lblMeanAbsFD";
            this.lblMeanAbsFD.Size = new System.Drawing.Size(69, 13);
            this.lblMeanAbsFD.TabIndex = 10;
            this.lblMeanAbsFD.Text = "MeanAbsFD:";
            // 
            // lblDifMM
            // 
            this.lblDifMM.AutoSize = true;
            this.lblDifMM.Location = new System.Drawing.Point(38, 222);
            this.lblDifMM.Name = "lblDifMM";
            this.lblDifMM.Size = new System.Drawing.Size(44, 13);
            this.lblDifMM.TabIndex = 9;
            this.lblDifMM.Text = "DiffMM:";
            // 
            // lblMaxX
            // 
            this.lblMaxX.AutoSize = true;
            this.lblMaxX.Location = new System.Drawing.Point(45, 196);
            this.lblMaxX.Name = "lblMaxX";
            this.lblMaxX.Size = new System.Drawing.Size(37, 13);
            this.lblMaxX.TabIndex = 8;
            this.lblMaxX.Text = "MaxX:";
            // 
            // lblMINX
            // 
            this.lblMINX.AutoSize = true;
            this.lblMINX.Location = new System.Drawing.Point(48, 170);
            this.lblMINX.Name = "lblMINX";
            this.lblMINX.Size = new System.Drawing.Size(34, 13);
            this.lblMINX.TabIndex = 7;
            this.lblMINX.Text = "MinX:";
            // 
            // lblMeanFDX
            // 
            this.lblMeanFDX.AutoSize = true;
            this.lblMeanFDX.Location = new System.Drawing.Point(24, 144);
            this.lblMeanFDX.Name = "lblMeanFDX";
            this.lblMeanFDX.Size = new System.Drawing.Size(58, 13);
            this.lblMeanFDX.TabIndex = 6;
            this.lblMeanFDX.Text = "MeanFDX:";
            // 
            // lblStdX
            // 
            this.lblStdX.AutoSize = true;
            this.lblStdX.Location = new System.Drawing.Point(49, 118);
            this.lblStdX.Name = "lblStdX";
            this.lblStdX.Size = new System.Drawing.Size(33, 13);
            this.lblStdX.TabIndex = 5;
            this.lblStdX.Text = "StdX:";
            // 
            // lblMeanX
            // 
            this.lblMeanX.AutoSize = true;
            this.lblMeanX.Location = new System.Drawing.Point(38, 92);
            this.lblMeanX.Name = "lblMeanX";
            this.lblMeanX.Size = new System.Drawing.Size(44, 13);
            this.lblMeanX.TabIndex = 4;
            this.lblMeanX.Text = "MeanX:";
            // 
            // cBoxSegments
            // 
            this.cBoxSegments.FormattingEnabled = true;
            this.cBoxSegments.Location = new System.Drawing.Point(88, 49);
            this.cBoxSegments.Name = "cBoxSegments";
            this.cBoxSegments.Size = new System.Drawing.Size(156, 21);
            this.cBoxSegments.TabIndex = 1;
            this.cBoxSegments.SelectedIndexChanged += new System.EventHandler(this.cBoxSegments_SelectedIndexChanged);
            // 
            // lblSegments
            // 
            this.lblSegments.AutoSize = true;
            this.lblSegments.Location = new System.Drawing.Point(25, 52);
            this.lblSegments.Name = "lblSegments";
            this.lblSegments.Size = new System.Drawing.Size(57, 13);
            this.lblSegments.TabIndex = 1;
            this.lblSegments.Text = "Segments:";
            // 
            // chkBoxFollowIncomingData
            // 
            this.chkBoxFollowIncomingData.AutoSize = true;
            this.chkBoxFollowIncomingData.Checked = true;
            this.chkBoxFollowIncomingData.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxFollowIncomingData.Location = new System.Drawing.Point(19, 19);
            this.chkBoxFollowIncomingData.Name = "chkBoxFollowIncomingData";
            this.chkBoxFollowIncomingData.Size = new System.Drawing.Size(125, 17);
            this.chkBoxFollowIncomingData.TabIndex = 1;
            this.chkBoxFollowIncomingData.Text = "Follow incoming data";
            this.chkBoxFollowIncomingData.UseVisualStyleBackColor = true;
            this.chkBoxFollowIncomingData.CheckedChanged += new System.EventHandler(this.chkBoxFollowIncomingData_CheckedChanged);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Location = new System.Drawing.Point(160, 408);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(79, 408);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LabelX,
            this.toolStripLblX,
            this.labelY,
            this.toolStripLblY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(885, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // LabelX
            // 
            this.LabelX.Name = "LabelX";
            this.LabelX.Size = new System.Drawing.Size(17, 17);
            this.LabelX.Text = "X:";
            // 
            // toolStripLblX
            // 
            this.toolStripLblX.Name = "toolStripLblX";
            this.toolStripLblX.Size = new System.Drawing.Size(41, 17);
            this.toolStripLblX.Text = "xValue";
            // 
            // labelY
            // 
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(17, 17);
            this.labelY.Text = "Y:";
            // 
            // toolStripLblY
            // 
            this.toolStripLblY.Name = "toolStripLblY";
            this.toolStripLblY.Size = new System.Drawing.Size(43, 17);
            this.toolStripLblY.Text = "YValue";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 489);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.grBoxControls);
            this.Controls.Add(this.grBoxHRSignal);
            this.Controls.Add(this.grBoxRawData);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Pan-Tompkins QRS detector";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.grBoxRawData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rawDataGraph)).EndInit();
            this.grBoxHRSignal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hrSignalGraph)).EndInit();
            this.grBoxControls.ResumeLayout(false);
            this.grBoxControls.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.GroupBox grBoxRawData;
        private System.Windows.Forms.GroupBox grBoxHRSignal;
        private System.Windows.Forms.DataVisualization.Charting.Chart hrSignalGraph;
        private System.Windows.Forms.GroupBox grBoxControls;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private Chart rawDataGraph;
        private System.Windows.Forms.CheckBox chkBoxFollowIncomingData;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel LabelX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLblX;
        private System.Windows.Forms.ToolStripStatusLabel labelY;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLblY;
        private System.Windows.Forms.TextBox txtBoxMeanAbsFD2;
        private System.Windows.Forms.TextBox txtBoxMeanAbsFD;
        private System.Windows.Forms.TextBox txtBoxDiffMM;
        private System.Windows.Forms.TextBox txtBoxMaxX;
        private System.Windows.Forms.TextBox txtBoxMinX;
        private System.Windows.Forms.TextBox txtBoxMeanFDX;
        private System.Windows.Forms.TextBox txtBoxStdX;
        private System.Windows.Forms.TextBox txtBoxMeanX;
        private System.Windows.Forms.Label lblMeanAbsFD2;
        private System.Windows.Forms.Label lblMeanAbsFD;
        private System.Windows.Forms.Label lblDifMM;
        private System.Windows.Forms.Label lblMaxX;
        private System.Windows.Forms.Label lblMINX;
        private System.Windows.Forms.Label lblMeanFDX;
        private System.Windows.Forms.Label lblStdX;
        private System.Windows.Forms.Label lblMeanX;
        private System.Windows.Forms.ComboBox cBoxSegments;
        private System.Windows.Forms.Label lblSegments;
        private System.Windows.Forms.ToolStripMenuItem openFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eCGFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem segmentEndToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

