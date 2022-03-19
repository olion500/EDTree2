using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MathNet.Numerics;

namespace EDTree2
{
    public partial class Form1 : Form
    {
        private EDTree edt;
        private Color colorGreen = Color.Green;
        private Color colorBlue = Color.MediumBlue;
        private Color colorRed = Color.OrangeRed;
        private Color colorEmpty = Color.Empty;
        
        public Form1()
        {
            edt = new EDTree();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Fetch data.
            var intensityInput = InputParser.Parse("input_intensity.txt");
            edt.Focus = intensityInput.Data[0].ToArray();
            edt.IntensityLower = intensityInput.Data[1].ToArray();
            edt.Intensity = intensityInput.Data[2].ToArray();
            edt.IntensityUpper = intensityInput.Data[3].ToArray();
            edt.Calculate();
            
            // Create Chart.
            CreateChart();

            // Create Data grid.
            CreateListView();
        }

        private void CreateListView()
        {
            listView1.BeginUpdate();
            listView1.Clear();
            
            ListViewItem item = new ListViewItem($"Green(BaseLine:{edt.Zstep}um)");
            item.ForeColor = colorGreen;
            item.SubItems.Add($"{edt.RectLeft.Size}(가로:{edt.RectLeft.Width}, 세로:{edt.RectLeft.Height})");
            listView1.Items.Add(item);

            item = new ListViewItem($"Blue(BaseLine:-{edt.Zstep}um)");
            item.ForeColor = colorBlue;
            item.SubItems.Add($"{edt.RectRight.Size}(가로:{edt.RectRight.Width}, 세로:{edt.RectRight.Height})");
            listView1.Items.Add(item);

            if (edt.RectStyle == RectStyle.Average)
            {
                item = new ListViewItem("Red(Average)");
                item.ForeColor = colorRed;
                item.SubItems.Add($"{edt.RectAverage.Size}(가로:{edt.RectAverage.Width}, 세로:{edt.RectAverage.Height})");
                listView1.Items.Add(item);
            }
            else if (edt.RectStyle == RectStyle.Maximum)
            {
                item = new ListViewItem("Red(Maximum)");
                item.ForeColor = colorRed;
                item.SubItems.Add($"{edt.RectMaximum.Size}(가로:{edt.RectMaximum.Width}, 세로:{edt.RectMaximum.Height})");
                listView1.Items.Add(item);
            }

            listView1.Columns.Add("Rect", 210);
            listView1.Columns.Add("Size", 210);

            listView1.EndUpdate();
            
            
            listView2.BeginUpdate();
            listView2.Clear();
            
            

            foreach (var x in edt.Focus)
            {
                ListViewItem row = new ListViewItem($"{x}");
                row.UseItemStyleForSubItems = false;
                row.SubItems.Add($"{Math.Round(Utils.LinearF(edt.Fl, x), 3)}").ForeColor = colorBlue;
                row.SubItems.Add($"{Math.Round(Utils.LinearF(edt.F, x), 3)}").ForeColor = colorRed;
                row.SubItems.Add($"{Math.Round(Utils.LinearF(edt.Fu, x), 3)}").ForeColor = colorGreen;
                listView2.Items.Add(row);
            }
            
            // listView2.Columns.Clear();
            listView2.Columns.Add("Focus", 60);
            listView2.Columns.Add($"-{edt.Percentage*100}%", 120);
            listView2.Columns.Add("0%", 120);
            listView2.Columns.Add($"+{edt.Percentage*100}%", 120);
            
            listView2.EndUpdate();
        }

        private void CreateChart()
        {
            mainChart.Series.Clear();
            
            // chart setting
            mainChart.ChartAreas[0].AxisX.Interval = 5;
            mainChart.ChartAreas[0].AxisX.Title = "Z step(um)";
            mainChart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            mainChart.ChartAreas[0].AxisX.Minimum = edt.Focus.First();
            
            mainChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            mainChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            mainChart.ChartAreas[0].AxisY.Title = "Intensity";

            mainChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            mainChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            
            // draw lines.
            Series baseChart = mainChart.Series.Add("Base");
            Series upperChart = mainChart.Series.Add("Upper");
            Series lowerChart = mainChart.Series.Add("Lower");
            baseChart.ChartType = SeriesChartType.Line;
            upperChart.ChartType = SeriesChartType.Line;
            lowerChart.ChartType = SeriesChartType.Line;
            baseChart.Color = colorRed;
            upperChart.Color = colorGreen;
            lowerChart.Color = colorBlue;

            foreach (var x in edt.PointX.Select((value, index) => (value, index)))
            {
                baseChart.Points.AddXY(x.value, edt.PointBase[x.index]);
                upperChart.Points.AddXY(x.value, edt.PointUpper[x.index]);
                lowerChart.Points.AddXY(x.value, edt.PointLower[x.index]);
            }

            // draw rects.
            mainChart.PostPaint += MainChartOnPostPaint;
        }

        private void MainChartOnPostPaint(object sender, ChartPaintEventArgs e)
        {
            DrawRect(e, edt.RectLeft, colorBlue);
            DrawRect(e, edt.RectRight, colorGreen);
            if (edt.RectStyle == RectStyle.BaseLine)
            {
                // do nothing.
            } 
            else if (edt.RectStyle == RectStyle.Average)
            {
                DrawRect(e, edt.RectAverage, colorRed);
            } 
            else if (edt.RectStyle == RectStyle.Maximum)
            {
                DrawRect(e, edt.RectMaximum, colorRed);
            }
            
        }

        private void DrawRect(ChartPaintEventArgs e, RectanglePoint rp, Color color)
        {
            var l = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(rp.L);
            var t = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(rp.T);
            var r = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(rp.R);
            var b = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(rp.B);
            var rect = RectangleF.FromLTRB(Math.Min(l, r), Math.Min(t, b), Math.Max(l, r),Math.Max(t, b));
            e.ChartGraphics.Graphics.DrawRectangle(new Pen(color), rect.X, rect.Y, rect.Width, rect.Height);
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            var chartSettingsForm = new ChartSettingsForm(edt);
            chartSettingsForm.Show();
            chartSettingsForm.ApplyChange += ApplyChange;
        }

        private void ApplyChange(EDTree changed)
        {
            edt = changed;
            edt.Calculate();
            
            // Create Chart.
            CreateChart();

            // Create Data grid.
            CreateListView();
        }

        private void buttonHome_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void buttonDefocus_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void buttonThreshold_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}