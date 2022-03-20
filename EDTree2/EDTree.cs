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
        
        public double[] Focus { get; set; }
        public double[] Intensity { get; set; }
        public double[] IntensityUpper { get; set; }
        public double[] IntensityLower { get; set; }
        public int Order { get; set; }
        public double Percentage { get; set; }
        public double Zstep { get; set; }
        public RectStyle RectStyle { get; set; }
        
        // Functions.
        public double[] F { get; set; }
        public double[] Fu { get; set; }
        public double[] Fl { get; set; }
        
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
        
        // Circle.
        public RectanglePoint CircleLeft { get; set; }

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
            RectLeft = new RectanglePoint(l, t, r, b);

            r = Zstep;
            t = Utils.LinearF(Fl, r);
            l = PointX[Utils.FindXIndex(PointLower, t).First()];
            b = PointUpper.Max();
            RectRight = new RectanglePoint(l, t, r, b);

            RectAverage = new RectanglePoint(
                (RectLeft.L + RectRight.L) / 2,
                (RectLeft.T + RectRight.T) / 2,
                (RectLeft.R + RectRight.R) / 2,
                (RectLeft.B + RectRight.B) / 2
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
        }

        private void CalculateLines()
        {
            F = Fit.Polynomial(Focus, Intensity, Order);
            Fu = Fit.Polynomial(Focus, IntensityUpper, Order);
            Fl = Fit.Polynomial(Focus, IntensityLower, Order);
            // Fu = Utils.MultiplyArray(F, (1 + Percentage));
            // Fl = Utils.MultiplyArray(F, (1 - Percentage));

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