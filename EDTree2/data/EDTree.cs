using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MathNet.Numerics;

namespace EDTree2
{
    public class EDTree
    {

        private double Step = 0.001;
        
        public bool IsLogY { get; set; }
        public string[] Header { get; set; }
        public double[] Focus { get; set; }
        public double[] Intensity { get; set; }
        public double[] IntensityUpper { get; set; }
        public double[] IntensityLower { get; set; }
        public int Order { get; set; }
        public double Percentage { get; set; }
        public double Zstep { get; set; }
        public RectStyle RectStyle { get; set; }
        public CircleStyle CircleStyle { get; set; }
        
        // Functions.
        public double[] F { get; set; }
        public double[] Fu { get; set; }
        public double[] Fl { get; set; }
        
        // R Squares.
        public double Rs { get; set; }
        public double Rsu { get; set; }
        public double Rsl { get; set; }
        
        // Points.
        public List<double> PointBase { get; set; }
        public List<double> PointUpper { get; set; }
        public List<double> PointLower { get; set; }
        public List<double> PointX { get; set; }
        
        // Rects.
        public RectanglePoint RectLeft { get; set; }
        public RectanglePoint RectRight { get; set; }
        public RectanglePoint RectAverage { get; set; }
        public RectanglePoint RectMaximum { get; set; }
        
        // Ellipse.
        public EllipsePoint EllipseLeft { get; set; }
        public EllipsePoint EllipseRight { get; set; }
        public EllipsePoint EllipseAverage { get; set; }
        public EllipsePoint EllipseMaximum { get; set; }

        public EDTree()
        {
            Focus = null;
            Intensity = null;
            ResetValues();

            PointBase = new List<double>();
            PointUpper = new List<double>();
            PointLower = new List<double>();
            PointX = new List<double>();
        }

        public void ResetValues()
        {
            Order = 2;
            Percentage = 0.1;
            Zstep = 10;
            RectStyle = RectStyle.BaseLine;
            CircleStyle = CircleStyle.None;
            IsLogY = false;
        }

        public void Calculate()
        {
            CalculateLines();
            CalculateShapes();
        }

        private void CalculateShapes()
        {
            double l = -Zstep;
            double t = Utils.LinearF(Fl, l);
            double r = PointX[Utils.FindXIndex(PointLower, t).Last()];
            double b = PointUpper.Max();
            double bx = PointX[PointUpper.IndexOf(b)];
            RectLeft = new RectanglePoint(l, t, r, b);
            EllipseLeft = new EllipsePoint(
                new PointF((float) l, (float) t), new PointF((float) r, (float) t), new PointF((float) bx, (float) b)
            );

            r = Zstep;
            t = Utils.LinearF(Fl, r);
            l = PointX[Utils.FindXIndex(PointLower, t).First()];
            b = PointUpper.Max();
            bx = PointX[PointUpper.IndexOf(b)];
            RectRight = new RectanglePoint(l, t, r, b);
            EllipseRight = new EllipsePoint(
                new PointF((float) l, (float) t), new PointF((float) r, (float) t), new PointF((float) bx, (float) b)
            );

            RectAverage = new RectanglePoint(
                (RectLeft.L + RectRight.L) / 2,
                (RectLeft.T + RectRight.T) / 2,
                (RectLeft.R + RectRight.R) / 2,
                (RectLeft.B + RectRight.B) / 2
            );
            var xs = Utils.FindXIndex(PointUpper, RectAverage.B);
            bx = PointX[xs[xs.Count / 2]];
            EllipseAverage = new EllipsePoint(
                new PointF((float) RectAverage.L, (float) RectAverage.T), new PointF((float) RectAverage.R, (float) RectAverage.T), new PointF((float) bx, (float) RectAverage.B)
            );

            RectMaximum = new RectanglePoint(0, 0, 0, 0);
            for (double v = -Zstep; v <= Zstep; v += 0.1)
            {
                l = v;
                t = Utils.LinearF(Fl, l);
                r = PointX[Utils.FindXIndex(PointLower, t).Last()];
                b = PointUpper.Max();
                var tmpRect = new RectanglePoint(l, t, r, b);
                if (tmpRect.Size > RectMaximum.Size) RectMaximum = tmpRect;
            }
            bx = PointX[PointUpper.IndexOf(RectMaximum.B)];
            EllipseMaximum = new EllipsePoint(
                new PointF((float) RectMaximum.L, (float) RectMaximum.T), new PointF((float) RectMaximum.R, (float) RectMaximum.T), new PointF((float) bx, (float) RectMaximum.B)
            );
        }

        private void CalculateLines()
        {
            F = Fit.Polynomial(Focus, Intensity, Order);
            Fu = Fit.Polynomial(Focus, IntensityUpper, Order);
            Fl = Fit.Polynomial(Focus, IntensityLower, Order);

            Rs = GoodnessOfFit.RSquared(Focus.Select(x => Utils.LinearF(F, x)), Intensity);
            Rsu = GoodnessOfFit.RSquared(Focus.Select(x => Utils.LinearF(Fu, x)), IntensityUpper);
            Rsl = GoodnessOfFit.RSquared(Focus.Select(x => Utils.LinearF(Fl, x)), IntensityLower);

            PointX.Clear();
            PointBase.Clear();
            PointLower.Clear();
            PointUpper.Clear();
            for (double k = Focus.First(); k <= Focus.Last(); k += Step)
            {
                PointX.Add(k);
                PointBase.Add(Utils.LinearF(F, k));
                PointLower.Add(Utils.LinearF(Fl, k));
                PointUpper.Add(Utils.LinearF(Fu, k));
            }
        }
    }
}