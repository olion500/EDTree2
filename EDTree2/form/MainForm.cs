﻿using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EDTree2
{
    internal enum ChartScreen
    {
        Intensity, Defocus, Threshold
    }
    public partial class Form1 : Form
    {
        private const string filename_intensity = "input_intensity.txt";
        private const string filename_defocus = "input_defocus.txt";
        private const string filename_threshold = "input_threshold.txt";
        
        private EDTree edt;
        private AerialCD acdDefocus;
        private AerialCD acdThreshold;

        private ChartScreen CurrentScreen;
        
        private Color colorGreen = Color.Green;
        private Color colorBlue = Color.MediumBlue;
        private Color colorRed = Color.OrangeRed;
        private Color colorCircle = Color.Chocolate;
        private Color colorEmpty = Color.Empty;
        
        public Form1()
        {
            edt = new EDTree();
            acdDefocus = new AerialCD();
            acdThreshold = new AerialCD();
            
            // init screen.
            CurrentScreen = ChartScreen.Intensity;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Fetch data.
            var intensityInput = InputParser.Parse(filename_intensity);
            edt.LabelX = intensityInput.LabelX;
            edt.LabelY = intensityInput.LabelY;
            edt.Header = intensityInput.Header;
            edt.Focus = intensityInput.Data[0].ToArray();
            edt.IntensityLower = intensityInput.Data[1].ToArray();
            edt.Intensity = intensityInput.Data[2].ToArray();
            edt.IntensityUpper = intensityInput.Data[3].ToArray();
            edt.Calculate();

            acdDefocus.Input = InputParser.Parse(filename_defocus);
            acdDefocus.Calculate();
            
            acdThreshold.Input = InputParser.Parse(filename_threshold);
            acdThreshold.Calculate();
            
            DrawScreen();
        }

        private void DrawScreen()
        {
            // Create Chart.
            CreateChart();

            // Create Data grid.
            CreateListView();
            
            // add post paint event that draw rectangles.
            mainChart.PostPaint += MainChartOnPostPaint;
        }

        private void CreateListView()
        {
            listView1.BeginUpdate();
            listView1.Clear();

            if (CurrentScreen == ChartScreen.Intensity)
            {
                ListViewItem item = new ListViewItem($"Green(BaseLine:{edt.Zstep}um)");
                item.ForeColor = colorGreen;
                item.SubItems.Add($"{edt.RectLeft.Size}(가로:{edt.RectLeft.Width}, 세로:{edt.RectLeft.Height})");
                listView1.Items.Add(item);

                item = new ListViewItem($"Blue(BaseLine:-{edt.Zstep}um)");
                item.ForeColor = colorBlue;
                item.SubItems.Add($"{edt.RectRight.Size}(가로:{edt.RectRight.Width}, 세로:{edt.RectRight.Height})");
                listView1.Items.Add(item);

                // rects.
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

                // ellipse.
                EllipsePoint drawingCircle = edt.EllipseLeft;
                switch (edt.CircleStyle)
                {
                    case CircleStyle.Left:
                        drawingCircle = edt.EllipseLeft;
                        break;
                    case CircleStyle.Right:
                        drawingCircle = edt.EllipseRight;
                        break;
                    case CircleStyle.Average:
                        drawingCircle = edt.EllipseAverage;
                        break;
                    case CircleStyle.Max:
                        drawingCircle = edt.EllipseMaximum;
                        break;
                }

                if (edt.CircleStyle != CircleStyle.None)
                {
                    item = new ListViewItem($"Brown({edt.CircleStyle.ToString()})");
                    item.ForeColor = colorCircle;
                    item.SubItems.Add($"{drawingCircle.Size}(가로:{drawingCircle.Width}, 세로:{drawingCircle.Height})");
                    listView1.Items.Add(item);
                }

                listView1.Columns.Add("Rect", 210);
                listView1.Columns.Add("Size", 210);
            }
            listView1.EndUpdate();
            
            
            listView2.BeginUpdate();
            listView2.Clear();

            if (CurrentScreen == ChartScreen.Intensity)
            {
                for (int i=0; i<edt.Focus.Length; i++)
                {
                    ListViewItem row = new ListViewItem($"{edt.Focus[i]}");
                    row.UseItemStyleForSubItems = false;
                    row.SubItems.Add($"{edt.IntensityLower[i]}").ForeColor = colorBlue;
                    row.SubItems.Add($"{edt.Intensity[i]}").ForeColor = colorRed;
                    row.SubItems.Add($"{edt.IntensityUpper[i]}").ForeColor = colorGreen;
                    listView2.Items.Add(row);
                }

                foreach (var head in edt.Header)
                {
                    listView2.Columns.Add(head, 100);
                }
            } 
            else if (CurrentScreen == ChartScreen.Defocus || CurrentScreen == ChartScreen.Threshold)
            {
                var acd = (CurrentScreen == ChartScreen.Defocus) ? acdDefocus : acdThreshold;
                int rows = acd.Rows;
                int cols = acd.Cols;
                for (int i = 0; i < rows; i++)
                {
                    ListViewItem item = new ListViewItem($"{acd.Input.Data[0][i]}");
                    for (int j = 1; j < cols; j++)
                    {
                        item.SubItems.Add($"{acd.Input.Data[j][i]}");
                    }

                    listView2.Items.Add(item);
                }
                
                
                var colWidth = Math.Max(400 / acd.Input.Header.Length, 60);
                foreach (var col in acd.Input.Header)
                {
                    listView2.Columns.Add(col, colWidth);
                }
            }
            
            listView2.EndUpdate();
        }

        private void CreateChart()
        {
            mainChart.Series.Clear();
            
            // chart setting.
            mainChart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            mainChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            mainChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            mainChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            mainChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            mainChart.ChartAreas[0].AxisY.LogarithmBase = 2.0;
            mainChart.ChartAreas[0].AxisY.IsLogarithmic = false;

            if (CurrentScreen == ChartScreen.Intensity)
            {
                // chart setting
                mainChart.ChartAreas[0].AxisY.IsLogarithmic = edt.IsLogY;           
                mainChart.ChartAreas[0].AxisX.Title = edt.LabelX;
                mainChart.ChartAreas[0].AxisX.Minimum = edt.Focus.Min();
                mainChart.ChartAreas[0].AxisY.Title = edt.LabelY;
                
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
                
                // Add label on the each line.
                
                PutChartNameOnPoint(baseChart.Points.Last(), edt.Header[2], colorRed);
                PutChartNameOnPoint(upperChart.Points.Last(), edt.Header[3], colorGreen);
                PutChartNameOnPoint(lowerChart.Points.Last(), edt.Header[1], colorBlue);



            }
            else if (CurrentScreen == ChartScreen.Defocus || CurrentScreen == ChartScreen.Threshold)
            {
                var acd = (CurrentScreen == ChartScreen.Defocus) ? acdDefocus : acdThreshold;
                
                mainChart.ChartAreas[0].AxisX.Title = acd.Input.LabelX;
                mainChart.ChartAreas[0].AxisX.Minimum = acd.Input.Data[0].Min();
                mainChart.ChartAreas[0].AxisY.Title = acd.Input.LabelY;

                for (int i = 1; i < acd.Cols; i++)
                {
                    Series sr = mainChart.Series.Add(acd.Input.Header[i]);
                    sr.ChartType = SeriesChartType.Line;
                
                    foreach (var x in acd.X)
                    {
                        sr.Points.AddXY(x, Utils.LinearF(acd.Fs[i-1], x));
                    }
                }
            }
        }

        private void PutChartNameOnPoint(DataPoint p, string label, Color color)
        {
            p.Label = label;
            p.LabelForeColor = color;
            p.Font = new Font(p.Font.FontFamily, 16);
        }

        private void MainChartOnPostPaint(object sender, ChartPaintEventArgs e)
        {
            if (CurrentScreen == ChartScreen.Intensity)
            {
                DrawText(e, Utils.PolynomialString(edt.Fl) + ",  R² : " + edt.Rsl.ToString("0.###") , colorBlue, 1);
                DrawText(e, Utils.PolynomialString(edt.F) + ",  R² : " + edt.Rs.ToString("0.###"), colorRed, 2);
                DrawText(e, Utils.PolynomialString(edt.Fu) + ",  R² : " + edt.Rsu.ToString("0.###"), colorGreen, 3);
                
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

                switch (edt.CircleStyle)
                {
                    case CircleStyle.Left:
                        DrawCircle(e, edt.EllipseLeft, colorCircle);
                        break;
                    case CircleStyle.Right:
                        DrawCircle(e, edt.EllipseRight, colorCircle);
                        break;
                    case CircleStyle.Average:
                        DrawCircle(e, edt.EllipseAverage, colorCircle);
                        break;
                    case CircleStyle.Max:
                        DrawCircle(e, edt.EllipseMaximum, colorCircle);
                        break;
                }
                
            }
        }

        private void DrawText(ChartPaintEventArgs e, string text, Color color, int n)
        {
            e.ChartGraphics.Graphics.DrawString(text, new Font("Arial", 8), new SolidBrush(color), 100, 20 * n);
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

        private void DrawCircle(ChartPaintEventArgs e, EllipsePoint ep, Color color)
        {
            var l = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(ep.L);
            var t = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(ep.T);
            var r = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(ep.R);
            var b = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(ep.B);
            var rect = RectangleF.FromLTRB(Math.Min(l, r), Math.Min(t, b), Math.Max(l, r),Math.Max(t, b));
            e.ChartGraphics.Graphics.DrawEllipse(new Pen(color), rect.X, rect.Y, rect.Width, rect.Height);
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            if (CurrentScreen == ChartScreen.Intensity)
            {
                var chartSettingsForm = new ChartSettingsForm(edt);
                chartSettingsForm.Show();
                chartSettingsForm.ApplyChange += ApplyChange;
            }
            else
            {
                MessageBox.Show("설정을 지원하는 화면이 아닙니다.");
            }
            
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
            if (!ShouldScreenChanged(ChartScreen.Intensity)) return;
            CurrentScreen = ChartScreen.Intensity;
            DrawScreen();
        }

        private void buttonDefocus_Click(object sender, EventArgs e)
        {
            if (!ShouldScreenChanged(ChartScreen.Defocus)) return;
            CurrentScreen = ChartScreen.Defocus;
            DrawScreen();
        }

        private void buttonThreshold_Click(object sender, EventArgs e)
        {
            if (!ShouldScreenChanged(ChartScreen.Threshold)) return;
            CurrentScreen = ChartScreen.Threshold;
            DrawScreen();
        }

        private bool ShouldScreenChanged(ChartScreen changeScreen)
        {
            return (CurrentScreen != changeScreen);
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Filter = "csv (*.csv)|*.csv|txt (*txt)|*.txt|All files (*.*)|*.*";
            if (saveDlg.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            FileStream fs = new FileStream(saveDlg.FileName, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, Encoding.UTF8);

            if (CurrentScreen == ChartScreen.Intensity)
            {
                // write columns.
                string line = string.Join(",", edt.Header);
                sw.WriteLine(line);

                // write data.
                for (double x = edt.Focus.Min(); x <= edt.Focus.Max(); x += 0.1)
                {
                    x = Math.Round(x, 3);
                    line = String.Join(",", new[] {x, Utils.LinearF(edt.Fl, x), Utils.LinearF(edt.F, x), Utils.LinearF(edt.Fu, x)});
                    sw.WriteLine(line);
                }
            }
            else if (CurrentScreen == ChartScreen.Defocus || CurrentScreen == ChartScreen.Threshold)
            {
                var acd = (CurrentScreen == ChartScreen.Defocus) ? acdDefocus : acdThreshold;

                // write columns.
                string line = string.Join(",", acd.Input.Header);
                sw.WriteLine(line);
                
                var start = Math.Min(acd.Input.Data[0].First(), acd.Input.Data[0].Last());
                var end = Math.Max(acd.Input.Data[0].First(), acd.Input.Data[0].Last());
                for (double x = start; x <= end; x += 0.1)
                {
                    x = Math.Round(x, 3);
                    var y = acd.Fs.Select(f => Utils.LinearF(f, x));
                    line = string.Join(",", new[] {x}.Concat(y));
                    sw.WriteLine(line);
                }
            }

            sw.Close();
            fs.Close();
        }
    }
}