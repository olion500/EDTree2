using System;
using System.Drawing;
using System.Linq;
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
                mainChart.ChartAreas[0].AxisX.Title = "Z step(um)";
                mainChart.ChartAreas[0].AxisX.Minimum = edt.Focus.Min();
                mainChart.ChartAreas[0].AxisY.Title = "Intensity";
                
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

        private void MainChartOnPostPaint(object sender, ChartPaintEventArgs e)
        {
            if (CurrentScreen == ChartScreen.Intensity)
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

                var circleColor = Color.Black;
                switch (edt.CircleStyle)
                {
                    case CircleStyle.Left:
                        DrawCircle(e, edt.RectLeft, circleColor);
                        break;
                    case CircleStyle.Right:
                        DrawCircle(e, edt.RectRight, circleColor);
                        break;
                    case CircleStyle.Average:
                        DrawCircle(e, edt.RectAverage, circleColor);
                        break;
                    case CircleStyle.Max:
                        DrawCircle(e, edt.RectMaximum, circleColor);
                        break;
                }
                
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

        private void DrawCircle(ChartPaintEventArgs e, RectanglePoint rp, Color color)
        {
            var l = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(rp.L);
            var t = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(rp.T);
            var r = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(rp.R);
            var b = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(rp.B);
            var rect = RectangleF.FromLTRB(Math.Min(l, r), Math.Min(t, b), Math.Max(l, r),Math.Max(t, b));
            
            PointF pl = new PointF(rect.X, rect.Y);
            PointF pr = new PointF(rect.X + rect.Width, rect.Y);
            PointF pb = new PointF(rect.X + rect.Width / 2, rect.Y + rect.Height);
            var pc = Utils.FindCircumcenter(pl, pr, pb);
            var radius = Utils.PointDistance(pc, pl);
            e.ChartGraphics.Graphics.DrawEllipse(new Pen(color), (float) (pc.X - radius), (float) (pc.Y - radius), (float) radius * 2, (float)radius * 2);
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
    }
}