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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choseDataSourceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grBoxRawData = new System.Windows.Forms.GroupBox();
            this.rawDataGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grBoxHRSignal = new System.Windows.Forms.GroupBox();
            this.hrSignalGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grBoxControls = new System.Windows.Forms.GroupBox();
            this.chkBoxFollowIncomingData = new System.Windows.Forms.CheckBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.LabelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLblX = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLblY = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.startToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(885, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip";
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.choseDataSourceToolStripMenuItem});
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.startToolStripMenuItem.Text = "Options";
            // 
            // choseDataSourceToolStripMenuItem
            // 
            this.choseDataSourceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.otherToolStripMenuItem});
            this.choseDataSourceToolStripMenuItem.Name = "choseDataSourceToolStripMenuItem";
            this.choseDataSourceToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.choseDataSourceToolStripMenuItem.Text = "Chose data source";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.otherToolStripMenuItem.Text = "Other";
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
            this.rawDataGraph.Series.Add(series1);
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
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.hrSignalGraph.Series.Add(series2);
            this.hrSignalGraph.Size = new System.Drawing.Size(571, 180);
            this.hrSignalGraph.TabIndex = 0;
            this.hrSignalGraph.Text = "HR signal";
            this.hrSignalGraph.MouseMove += new System.Windows.Forms.MouseEventHandler(this.hrSignalGraph_MouseMove);
            // 
            // grBoxControls
            // 
            this.grBoxControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btnStop.Location = new System.Drawing.Point(176, 408);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(95, 408);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
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
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem choseDataSourceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
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
    }
}

