using System;
using System.Linq;

namespace EDTree
{
    public class FittingCircle
    {
        public double BaseX { get; set; }
        public EllipsePoint EllipseLeft { get; set; }
        public EllipsePoint EllipseRight { get; set; }
        public EllipsePoint EllipseAvg { get; set; }
        public EllipsePoint EllipseMax { get; set; }
        
        private readonly FittingLine UpperLine;
        private readonly FittingLine LowerLine;
        
        public FittingCircle(double baseX, FittingLine upperLine, FittingLine lowerLine)
        {
            BaseX = baseX;
            // divide upper and lower.
            if (upperLine.Evaluate(baseX) > lowerLine.Evaluate(baseX))
            {
                UpperLine = upperLine;
                LowerLine = lowerLine;
            }
            else
            {
                UpperLine = lowerLine;
                LowerLine = upperLine;
            }
        }
        
        public FittingCircle Calculate()
        {
            double l, t, r, b;
            PointD pointBottom = LowerLine.MaxY();
            
            l = -BaseX;
            t = UpperLine.Evaluate(l);
            r = UpperLine.FindXByY(t).Max();
            EllipseLeft = FindEllipseWithinPoints(
                new PointD(l, t),
                new PointD(r, t),
                pointBottom
            );

            r = BaseX;
            t = UpperLine.Evaluate(r);
            l = UpperLine.FindXByY(t).Min();
            EllipseRight = FindEllipseWithinPoints(
                new PointD(l, t),
                new PointD(r, t),
                pointBottom
            );

            EllipseAvg = new EllipsePoint(
                (EllipseLeft.L + EllipseRight.L) / 2,
                (EllipseLeft.T + EllipseRight.T) / 2,
                (EllipseLeft.R + EllipseRight.R) / 2,
                (EllipseLeft.B + EllipseRight.B) / 2
            );
            
            var rectMax = new RectPoint(0, 0, 0, 0);
            b = LowerLine.MaxY().Y;
            for (double x = -BaseX; x <= BaseX; x++)
            {
                l = x;
                t = UpperLine.Evaluate(x);
                r = UpperLine.FindXByY(t).Max();
                var tmpRect = new RectPoint(l, t, r, b);
                if (tmpRect.Size > rectMax.Size) rectMax = tmpRect;
            }
            EllipseMax = FindEllipseWithinPoints(
                new PointD(rectMax.L, rectMax.T),
                new PointD(rectMax.R, rectMax.T),
                pointBottom
            );
            return this;
        }

        public EllipsePoint GetEllipse(FittingType rectType)
        {
            switch (rectType)
            {
                case FittingType.Left:
                    return EllipseLeft;
                case FittingType.Right:
                    return EllipseRight;
                case FittingType.Average:
                    return EllipseAvg;
                case FittingType.Max:
                    return EllipseMax;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rectType), rectType, null);
            }
        }

        private EllipsePoint FindEllipseWithinPoints(PointD p1, PointD p2, PointD p3)
        {
            var (xc, yc, a, b) = FindMaxEllipse(p1, p2, p3);
            return new EllipsePoint(
                xc - a,
                yc - b,
                xc + a,
                yc + b
            );
        }
        
        private (double xc, double yc , double a, double b) FindMaxEllipse(PointD p1, PointD p2, PointD p3)
        {
            var (xc, yc, a, b) = CenterInfo(p1, p2, p3);
            var t = 0.001;
            (xc, yc, a, b) = AdjustMinorAxis(xc, yc, a, b, t);
            (xc, yc, a, b) = AdjustMajorAxis(xc, yc, a, b, t);
            
            return (xc, yc, a, b);
        }

        private (double xc, double yc, double a, double b) AdjustMajorAxis(double xc, double yc, double a, double b, double t)
        {
            while (true)
            {
                var at = a + t;
                if (IsRangeOutOfEllipse(xc, yc, at, b))
                    a = at;
                else
                    break;
            }

            return (xc, yc, a, b);
        }

        private (double xc, double yc, double a, double b) AdjustMinorAxis(double xc, double yc, double a, double b, double t)
        {
            var ratio = a / b;
            
            while (true)
            {
                var at = a + ratio * t;
                var bt = b + t;
                var yct = yc + t;
                if (IsRangeOutOfEllipse(xc, yct, at, bt))
                {
                    a = at;
                    b = bt;
                    yc = yct;
                }
                else
                {
                    break;
                }
            }

            return (xc, yc, a, b);
        }

        private PointD MaxPoint3(PointD p1, PointD p2, PointD p3)
        {
            return new PointD(
                Math.Max(Math.Max(p1.X, p2.X), p3.X),
                Math.Max(Math.Max(p1.Y, p2.Y), p3.Y)
            );
        }
        
        private PointD MinPoint3(PointD p1, PointD p2, PointD p3)
        {
            return new PointD(
                Math.Min(Math.Min(p1.X, p2.X), p3.X),
                Math.Min(Math.Min(p1.Y, p2.Y), p3.Y)
            );
        }

        private (double cx, double cy, double a, double b) CenterInfo(PointD p1, PointD p2, PointD p3)
        {
            var minP = MinPoint3(p1, p2, p3);
            var maxP = MaxPoint3(p1, p2, p3);
            var lengthX = (maxP.X - minP.X) / 2.0;
            var lengthY = (maxP.Y - minP.Y) / 2.0;
            return (minP.X + lengthX, minP.Y + lengthY, lengthX, lengthY);
        }

        private bool IsRangeOutOfEllipse(double xc, double yc, double a, double b)
        {
            var minX = xc - a;
            var maxX = xc + a;
            var isAllOut = true;
            var p = new PointD();
            for (double x = minX; x <= maxX; x += 0.1)
            {
                p.X = x;
                p.Y = UpperLine.Evaluate(x);
                isAllOut = isAllOut && IsPointOutOfEllipse(xc, yc, a, b, p);
            }

            return isAllOut;
        }
        
        private bool IsPointOutOfEllipse(double xc, double yc, double a, double b, PointD p)
        {
            var sqX = Math.Pow(p.X - xc, 2) / Math.Pow(a, 2);
            var sqY = Math.Pow(p.Y - yc, 2) / Math.Pow(b, 2);
            return sqX + sqY - 1.0 > 0;
        }
    }
}