using System;

namespace EDTree
{
    /// <summary>
    /// Calculate the maximum size of ellipse with the given FittingLines.
    /// </summary>
    public class FittingEllipse
    {
        /// <summary>
        /// A base tick for the Finding Ellipse Algorithm 
        /// </summary>
        private const double stepX = 0.01;

        private const double stepY = 0.001;
        
        /// <summary>
        /// Minimum boundary for calculation of finding max ellipse.
        /// </summary>
        public double MinX { get; }
        
        /// <summary>
        /// Maximum boundary for calculation of finding max ellipse.
        /// </summary>
        public double MaxX { get; }
        public EllipsePoint Ellipse { get; private set; }
        
        /// <summary>
        /// Geometrical upper line.
        /// </summary>
        private readonly FittingLine UpperLine;
        /// <summary>
        /// Geometrical lower line.
        /// </summary>
        private readonly FittingLine LowerLine;
        
        public FittingEllipse(double min, double max, FittingLine upperLine, FittingLine lowerLine)
        {
            MinX = min;
            MaxX = max;
            // divide upper and lower.
            if (upperLine.Evaluate(MinX) > lowerLine.Evaluate(MinX))
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
        
        /// <summary>
        /// Calculate the ellipse with the given input.
        /// The ellipse will be stored in 'Ellipse' member.
        /// </summary>
        public FittingEllipse Calculate()
        {
            PointD pointBottom = LowerLine.MaxY();
            Ellipse = FindMaxSizeEllipse(MinX, MaxX, pointBottom);
            return this;
        }

        private EllipsePoint FindMaxSizeEllipse(double minX, double maxX, PointD pointBottom)
        {
            EllipsePoint maxEllipse = new EllipsePoint(minX, pointBottom.Y, maxX, pointBottom.Y);

            var min = minX;
            var max = maxX;
            while (min < max)
            {
                var tmpEllipse = StretchHeightUntilTop(new EllipsePoint(min, maxEllipse.T, max, maxEllipse.B));
                if (tmpEllipse.Size > maxEllipse.Size)
                    maxEllipse = tmpEllipse;

                min += stepX;
                max -= stepX;
            }
            return maxEllipse;
        }

        private EllipsePoint StretchHeightUntilTop(EllipsePoint initEllipsePoint)
        {
            EllipsePoint ep = initEllipsePoint;
            while (true)
            {
                var epn = new EllipsePoint(
                    ep.L,
                    ep.T + stepY,
                    ep.R,
                    ep.B);
                if (!IsEllipseBelowOfUpperLine(epn)) break;

                if (epn.T > UpperLine.MaxY().Y) break;

                ep = epn;
            }

            return ep;
        }

        private bool IsEllipseBelowOfUpperLine(EllipsePoint ep)
        {
            Ellipse ellipse = EDTree.Ellipse.FromRect(ep.L, ep.T, ep.R, ep.B);
            for (double x = MinX; x <= MaxX; x += stepX)
            {
                if (!IsPointOutOfEllipse(ellipse, x, UpperLine.Evaluate(x))) return false;
            }

            return true;
        }

        private bool IsPointOutOfEllipse(Ellipse ellipse, double x, double y)
        {
            var sqX = Math.Pow(x - ellipse.CenterX, 2) / Math.Pow(ellipse.A, 2);
            var sqY = Math.Pow(y - ellipse.CenterY, 2) / Math.Pow(ellipse.B, 2);
            return sqX + sqY - 1.0 > 0;
        }

        /// <summary>
        /// Unused. Returns ellipse boundary for the given 3 points. 
        /// </summary>
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
        
        /// <summary>
        /// Unused. Return one ellipse equation for the given 3 points.
        /// </summary>
        private (double xc, double yc , double a, double b) FindMaxEllipse(PointD p1, PointD p2, PointD p3)
        {
            var (xc, yc, a, b) = CenterInfo(p1, p2, p3);
            var t = 0.001;
            (xc, yc, a, b) = AdjustMinorAxis(xc, yc, a, b, t);
            (xc, yc, a, b) = AdjustMajorAxis(xc, yc, a, b, t);
            
            return (xc, yc, a, b);
        }

        /// <summary>
        /// Unused. Stretch the circle on main axis until the circle is placed between the lines. 
        /// </summary>
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

        /// <summary>
        /// Unused. Stretch the circle on minor axis until the circle is placed between the lines. 
        /// </summary>
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

        /// <summary>
        /// Unused. Returns maximum value of given points.
        /// </summary>
        private PointD MaxPoint3(PointD p1, PointD p2, PointD p3)
        {
            return new PointD(
                Math.Max(Math.Max(p1.X, p2.X), p3.X),
                Math.Max(Math.Max(p1.Y, p2.Y), p3.Y)
            );
        }
        
        /// <summary>
        /// Unused. Returns minimum value of given points.
        /// </summary>
        private PointD MinPoint3(PointD p1, PointD p2, PointD p3)
        {
            return new PointD(
                Math.Min(Math.Min(p1.X, p2.X), p3.X),
                Math.Min(Math.Min(p1.Y, p2.Y), p3.Y)
            );
        }

        /// <summary>
        /// Unused. Returns center of three point.
        /// </summary>
        private (double cx, double cy, double a, double b) CenterInfo(PointD p1, PointD p2, PointD p3)
        {
            var minP = MinPoint3(p1, p2, p3);
            var maxP = MaxPoint3(p1, p2, p3);
            var lengthX = (maxP.X - minP.X) / 2.0;
            var lengthY = (maxP.Y - minP.Y) / 2.0;
            return (minP.X + lengthX, minP.Y + lengthY, lengthX, lengthY);
        }

        /// <summary>
        /// Unused. Check if all of ellipse is placed between two lines.
        /// </summary>
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
        
        /// <summary>
        /// Unused. Check if the given point is placed out of the ellipse.
        /// </summary>
        private bool IsPointOutOfEllipse(double xc, double yc, double a, double b, PointD p)
        {
            var sqX = Math.Pow(p.X - xc, 2) / Math.Pow(a, 2);
            var sqY = Math.Pow(p.Y - yc, 2) / Math.Pow(b, 2);
            return sqX + sqY - 1.0 > 0;
        }
    }
}