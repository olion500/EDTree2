using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using EDTree;

namespace EDTree2
{
    public partial class MainForm
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

            if (CurrentScreen == ChartScreen.Intensity)
            {
                if (edt == null) return;
                
                // chart setting
                mainChart.ChartAreas[0].AxisY.IsLogarithmic = edtreeOption.IsLogY;           
                mainChart.ChartAreas[0].AxisX.Title = edt.LabelX;
                mainChart.ChartAreas[0].AxisX.Minimum = edt.X.Min();
                mainChart.ChartAreas[0].AxisY.Title = edt.LabelY;
                
                DrawIntensityLineChart(edt, Palette.colorUpper, Palette.colorBase, Palette.colorLower, true);
                DrawIntensityLineChart(edtCmp, Palette.colorUpperTrans, Palette.colorBaseTrans, Palette.colorLowerTrans, false);
            }
            else if (CurrentScreen == ChartScreen.Defocus || CurrentScreen == ChartScreen.Threshold)
            {
                var acd = (CurrentScreen == ChartScreen.Defocus) ? acdDefocus : acdThreshold;
                if (acd == null) return;
                
                mainChart.ChartAreas[0].AxisX.Title = acd.LabelX;
                mainChart.ChartAreas[0].AxisX.Minimum = acd.X.Min();
                mainChart.ChartAreas[0].AxisY.Title = acd.LabelY;

                var xPoints = acd.GetXPoints();
                for (int i = 0; i < acd.Lines.Count; i++)
                {
                    var line = acd.Lines[i];
                    Series sr = mainChart.Series.Add(acd.Header[i + 1]);
                    sr.ChartType = SeriesChartType.Line;

                    foreach (var x in xPoints)
                    {
                        sr.Points.AddXY(x, line.Evaluate(x));
                    }
                }
            }
        }

        private void DrawIntensityLineChart(EDTree edTree, NamedColor colorUpper, NamedColor colorBase, NamedColor colorLower, bool showLabel)
        {
            if (edTree == null) return;
            
            // draw lines.
            Series baseChart = mainChart.Series.Add("Base" + edTree.GetHashCode());
            Series upperChart = mainChart.Series.Add("Upper" + edTree.GetHashCode());
            Series lowerChart = mainChart.Series.Add("Lower" + edTree.GetHashCode());
            baseChart.ChartType = SeriesChartType.Line;
            upperChart.ChartType = SeriesChartType.Line;
            lowerChart.ChartType = SeriesChartType.Line;
            baseChart.Color = colorBase.Color;
            upperChart.Color = colorUpper.Color;
            lowerChart.Color = colorLower.Color;

            foreach (var x in edTree.GetXPoints())
            {
                baseChart.Points.AddXY(x, edTree.BaseLine.Evaluate(x));
                upperChart.Points.AddXY(x, edTree.UpperLine.Evaluate(x));
                lowerChart.Points.AddXY(x, edTree.LowerLine.Evaluate(x));
            }

            // Add label on the each line.
            if (showLabel)
            {
                PutChartNameOnPoint(baseChart.Points.Last(), edTree.Header[2], colorBase);
                PutChartNameOnPoint(upperChart.Points.Last(), edTree.Header[3], colorUpper);
                PutChartNameOnPoint(lowerChart.Points.Last(), edTree.Header[1], colorLower);
            }
        }

        private void PutChartNameOnPoint(DataPoint p, string label, NamedColor color)
        {
            p.Label = label;
            p.LabelForeColor = color.Color;
            p.Font = new Font(p.Font.FontFamily, 16);
        }

        private void MainChartOnPostPaint(object sender, ChartPaintEventArgs e)
        {
            if (CurrentScreen == ChartScreen.Intensity)
            {
                // draw text about polynomial equation.
                if (edtreeOption.IsShowEquation)
                {
                    DrawText(e, StringUtils.PolynomialString(edt.LowerLine.Coefficients) + ",  R² : " + edt.LowerLine.RSquare.ToString("0.###"), Palette.colorLower, 1);
                    DrawText(e, StringUtils.PolynomialString(edt.BaseLine.Coefficients) + ",  R² : " + edt.BaseLine.RSquare.ToString("0.###"), Palette.colorBase, 2);
                    DrawText(e, StringUtils.PolynomialString(edt.UpperLine.Coefficients) + ",  R² : " + edt.UpperLine.RSquare.ToString("0.###"), Palette.colorUpper, 3);
                }

                // draw rectangle of edt.
                foreach (var rs in edtreeOption.RectStyles)
                {
                    var rect = edt?.GetRectangles(rs);
                    if (rect == null) continue;
                    
                    var color = Palette.FromRectStyle(rs);
                    DrawRect(e, edt?.GetRectangles(rs), color);
                }
                
                // draw rectangle of edtCmp.
                foreach (var rs in edtreeOption.RectStyles)
                {
                    var rect = edtCmp?.GetRectangles(rs);
                    if (rect == null) continue;
                    
                    var color = Palette.FromRectStyleCmp(rs);
                    DrawRect(e, edtCmp?.GetRectangles(rs), color);
                }
                
                // draw common rect.
                var rectStyle = edtreeOption.RectStyles.FirstOrDefault();
                var commonRect = edt?.GetRectangles(rectStyle)?.Intersect(edtCmp?.GetRectangles(rectStyle));
                if (commonRect != null)
                {
                    DrawRect(e, commonRect, Palette.colorRectCommonTrans, true);
                }

                // draw ellipse.
                var ellipse = edt?.GetEllipse(edtreeOption.EllipseStyle);
                var ellipseCmp = edtCmp?.GetEllipse(edtreeOption.EllipseStyle);
                DrawCircle(e, ellipse, Palette.colorEllipse);
                DrawCircle(e, ellipseCmp, Palette.colorEllipseTrans);

            } 
            else if (CurrentScreen == ChartScreen.Defocus || CurrentScreen == ChartScreen.Threshold)
            {
                var acd = (CurrentScreen == ChartScreen.Defocus) ? acdDefocus : acdThreshold;
                if (acd == null) return;

                // draw polynomial equation on the chart.
                if (edtreeOption.IsShowEquation)
                {
                    var colors = Palette.GetAerialLineColors();
                    var n = 1;
                    foreach (var line in acd.Lines)
                    {
                        DrawText(e, StringUtils.PolynomialString(line.Coefficients) + ",  R² : " + line.RSquare.ToString("0.###"), colors[n-1], n);
                        n++;
                    }
                }
            }
        }

        /// <summary>
        /// Show polynomial Equations on the chart.
        /// </summary>
        private void DrawText(ChartPaintEventArgs e, string text, NamedColor color, int n)
        {
            e.ChartGraphics.Graphics.DrawString(text, new Font("Arial", 8), new SolidBrush(color.Color), 120, 20 * n);
        }

        /// <summary>
        /// Draw rectangle on the chart.
        /// </summary>
        /// <param name="fill">Whether the rectangle is filled or not.</param>
        private void DrawRect(ChartPaintEventArgs e, RectPoint rp, NamedColor color, bool fill=false)
        {
            if (rp == null) return;
            
            var l = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(rp.L);
            var t = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(rp.T);
            var r = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(rp.R);
            var b = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(rp.B);
            var rect = RectangleF.FromLTRB(Math.Min(l, r), Math.Min(t, b), Math.Max(l, r),Math.Max(t, b));
            if (fill)
                e.ChartGraphics.Graphics.FillRectangle(new SolidBrush(color.Color), rect.X, rect.Y, rect.Width, rect.Height);
            else
            {
                e.ChartGraphics.Graphics.DrawRectangle(new Pen(color.Color), rect.X, rect.Y, rect.Width, rect.Height);
            }
        }

        /// <summary>
        /// Draw Circle on the chart.
        /// </summary>
        private void DrawCircle(ChartPaintEventArgs e, EllipsePoint ep, NamedColor color)
        {
            if (ep == null) return;
            
            var l = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(ep.L);
            var t = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(ep.T);
            var r = (float) mainChart.ChartAreas[0].AxisX.ValueToPixelPosition(ep.R);
            var b = (float) mainChart.ChartAreas[0].AxisY.ValueToPixelPosition(ep.B);
            var rect = RectangleF.FromLTRB(Math.Min(l, r), Math.Min(t, b), Math.Max(l, r),Math.Max(t, b));
            e.ChartGraphics.Graphics.DrawEllipse(new Pen(color.Color), rect.X, rect.Y, rect.Width, rect.Height);
        }
    }
}