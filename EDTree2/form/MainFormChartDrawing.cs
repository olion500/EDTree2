using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EDTree;

namespace EDTree2
{
    public partial class Form1
    {
        private void CreateChart()
        {
            mainChart.Series.Clear();
            
            // chart setting.
            mainChart.ChartAreas[0].AxisX.Interval = (CurrentScreen == ChartScreen.Threshold) ? 0.01 : 1;
            mainChart.ChartAreas[0].AxisX.LabelAutoFitStyle = LabelAutoFitStyles.DecreaseFont;
            mainChart.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            mainChart.ChartAreas[0].AxisY.IsStartedFromZero = false;
            mainChart.ChartAreas[0].AxisY.IntervalAutoMode = IntervalAutoMode.VariableCount;
            mainChart.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            mainChart.ChartAreas[0].AxisY.MajorGrid.Enabled = false;

            mainChart.ChartAreas[0].AxisY.LogarithmBase = 2.0;
            mainChart.ChartAreas[0].AxisY.IsLogarithmic = false;

            if (CurrentScreen == ChartScreen.Intensity && edt != null)
            {
                // chart setting
                mainChart.ChartAreas[0].AxisY.IsLogarithmic = edt.IsLogY;           
                mainChart.ChartAreas[0].AxisX.Title = edt.LabelX;
                mainChart.ChartAreas[0].AxisX.Minimum = edt.X.Min();
                mainChart.ChartAreas[0].AxisY.Title = edt.LabelY;
                
                // draw lines.
                Series baseChart = mainChart.Series.Add("Base");
                Series upperChart = mainChart.Series.Add("Upper");
                Series lowerChart = mainChart.Series.Add("Lower");
                baseChart.ChartType = SeriesChartType.Line;
                upperChart.ChartType = SeriesChartType.Line;
                lowerChart.ChartType = SeriesChartType.Line;
                baseChart.Color = Palette.colorBase;
                upperChart.Color = Palette.colorUpper;
                lowerChart.Color = Palette.colorLower;

                foreach (var x in edt.GetXPoints())
                {
                    baseChart.Points.AddXY(x, edt.BaseLine.Evaluate(x));
                    upperChart.Points.AddXY(x, edt.UpperLine.Evaluate(x));
                    lowerChart.Points.AddXY(x, edt.LowerLine.Evaluate(x));
                }

                // Add label on the each line.
                PutChartNameOnPoint(baseChart.Points.Last(), edt.Header[2], Palette.colorBase);
                PutChartNameOnPoint(upperChart.Points.Last(), edt.Header[3], Palette.colorUpper);
                PutChartNameOnPoint(lowerChart.Points.Last(), edt.Header[1], Palette.colorLower);
            }
            else if (CurrentScreen == ChartScreen.Defocus || CurrentScreen == ChartScreen.Threshold)
            {
                var acd = (CurrentScreen == ChartScreen.Defocus) ? acdDefocus : acdThreshold;
                if (acd == null) return;
                
                mainChart.ChartAreas[0].AxisX.Title = acd.LabelX;
                mainChart.ChartAreas[0].AxisX.Minimum = acd.X.Min();
                mainChart.ChartAreas[0].AxisY.Title = acd.LabelY;

                Series sr = mainChart.Series.Add(acd.Header[1]);
                sr.ChartType = SeriesChartType.Line;

                foreach (var x in acd.GetXPoints())
                {
                    sr.Points.AddXY(x, acd.Line.Evaluate(x));
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
            if (CurrentScreen == ChartScreen.Intensity && edt != null)
            {
                if (edt.IsShowEquation)
                {
                    DrawText(e, Utils.PolynomialString(edt.LowerLine.Coefficients) + ",  R² : " + edt.LowerLine.RSquare.ToString("0.###"), Palette.colorLower, 1);
                    DrawText(e, Utils.PolynomialString(edt.BaseLine.Coefficients) + ",  R² : " + edt.BaseLine.RSquare.ToString("0.###"), Palette.colorBase, 2);
                    DrawText(e, Utils.PolynomialString(edt.UpperLine.Coefficients) + ",  R² : " + edt.UpperLine.RSquare.ToString("0.###"), Palette.colorUpper, 3);
                }
                
                DrawRect(e, edt.GetRectangles(FittingType.Left), Palette.colorLower);
                DrawRect(e, edt.GetRectangles(FittingType.Right), Palette.colorUpper);
                if (edt.RectStyle == RectStyle.BaseLine)
                {
                    // do nothing.
                } 
                else if (edt.RectStyle == RectStyle.Average)
                {
                    DrawRect(e, edt.GetRectangles(FittingType.Average), Palette.colorBase);
                } 
                else if (edt.RectStyle == RectStyle.Maximum)
                {
                    DrawRect(e, edt.GetRectangles(FittingType.Max), Palette.colorBase);
                }

                var ellipse = edt.GetEllipse(edt.EllipseStyle);
                if (ellipse != null)
                    DrawCircle(e, ellipse, Palette.colorCircle);

            } 
            else if (CurrentScreen == ChartScreen.Defocus || CurrentScreen == ChartScreen.Threshold)
            {
                var acd = (CurrentScreen == ChartScreen.Defocus) ? acdDefocus : acdThreshold;
                if (acd == null) return;
                
                DrawText(e, Utils.PolynomialString(acd.Line.Coefficients) + ",  R² : " + acd.Line.RSquare.ToString("0.###"), Palette.colorUpper, 1);
            }
        }

        private void DrawText(ChartPaintEventArgs e, string text, Color color, int n)
        {
            e.ChartGraphics.Graphics.DrawString(text, new Font("Arial", 8), new SolidBrush(color), 100, 20 * n);
        }

        private void DrawRect(ChartPaintEventArgs e, RectPoint rp, Color color)
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
    }
}