using System;
using System.Linq;

namespace EDTree
{
    /// <summary>
    /// Calculate all types of rectangle with the given FittingLines.
    /// </summary>
    public class FittingRect
    {
        public double MinX { get; }
        public double MaxX { get; }
        /// <summary>
        /// Rect based on minX. If null, the rect cannot be drawn.
        /// </summary>
        public RectPoint RectLeft { get; private set; }
        /// <summary>
        /// Rect based on maxX. If null, the rect cannot be drawn.
        /// </summary>
        public RectPoint RectRight { get; private set; }
        /// <summary>
        /// Rect based on rectLeft, rectright. If null, the rect cannot be drawn.
        /// </summary>
        public RectPoint RectAvg { get; private set; }
        /// <summary>
        /// Maximum size of rect. Default : 0 size rectangle.
        /// </summary>
        public RectPoint RectMax { get; private set; }

        /// <summary>
        /// Geometrical upper line.
        /// </summary>
        private readonly FittingLine UpperLine;
        
        /// <summary>
        /// geometrical lower line.
        /// </summary>
        private readonly FittingLine LowerLine;

        /// <summary>
        /// The minimum width for drawing rectangle.
        /// </summary>
        private const double ToleranceX = 0.1;
        
        /// <summary>
        /// The minimum height for drawing rectangle.
        /// </summary>
        private const double ToleranceY = 0.0001;

        /// <summary>
        /// The value to add when the maximum rect is calculated with the iteration.
        /// </summary>
        private const double StepX = 0.01;

        public FittingRect(double min, double max, FittingLine upperLine, FittingLine lowerLine)
        {
            MinX = min;
            MaxX = max;
            
            // confirm which line is upper or lower by evaluate certain x value.
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
        /// Calculate all type of rectangles.
        /// </summary>
        /// <returns></returns>
        public FittingRect Calculate()
        {
            double l, t, r, b;

            l = MinX;
            t = UpperLine.Evaluate(l);
            r = UpperLine.FindXByY(t).Max();
            b = LowerLine.MaxY().Y;
            RectLeft = (IsNormalRectangle(l, t, r, b)) ? new RectPoint(l, t, r, b) : null;

            r = MaxX;
            t = UpperLine.Evaluate(r);
            l = UpperLine.FindXByY(t).Min();
            b = LowerLine.MaxY().Y;
            RectRight = (IsNormalRectangle(l, t, r, b)) ? new RectPoint(l, t, r, b) : null;

            // if either left or right rectangle is null, average rect cannot be calculated.
            if (RectLeft != null && RectRight != null)
            {
                RectAvg = new RectPoint(
                    (RectLeft.L + RectRight.L) / 2,
                    (RectLeft.T + RectRight.T) / 2,
                    (RectLeft.R + RectRight.R) / 2,
                    (RectLeft.B + RectRight.B) / 2
                );
            }
            else
            {
                RectAvg = null;
            }

            RectMax = null;
            b = LowerLine.MaxY().Y;
            for (double x = MinX; x <= MaxX; x+=StepX)
            {
                l = x;
                t = UpperLine.Evaluate(x);
                var xValues = UpperLine.FindXByY(t);
                var possibleR1 = xValues.Min();
                var possibleR2 = xValues.Max();

                RectMax = FindMaximumRect(l, t, possibleR1, b);
                RectMax = FindMaximumRect(l, t, possibleR2, b);
            }

            return this;
        }

        /// <summary>
        /// Returns Maximum Rect between RectMax and new rect based on the input.
        /// </summary>
        private RectPoint FindMaximumRect(double l, double t, double r, double b)
        {
            if (!IsNormalRectangle(l, t, r, b)) return RectMax;
            
            var newRect = new RectPoint(l, t, r, b);
            if (RectMax == null || newRect.Size > RectMax.Size)
            {
                return newRect;
            }

            return RectMax;
        }

        /// <summary>
        /// Check if the rectangle is bigger than tolerance value in each axis.
        /// </summary>
        private bool IsNormalRectangle(double l, double t, double r, double b)
        {
            // 좌우 길이가 너무 짧을때.
            if (Math.Abs(l - r) < ToleranceX) return false;
            
            // 상하 길이가 너무 짧을때.
            if (Math.Abs(t - b) < ToleranceY) return false;

            return true;
        }

        /// <summary>
        /// Returns rectangle by fitting type.
        /// </summary>
        public RectPoint GetRect(FittingType rectType)
        {
            switch (rectType)
            {
                case FittingType.Left:
                    return RectLeft;
                case FittingType.Right:
                    return RectRight;
                case FittingType.Average:
                    return RectAvg;
                case FittingType.Max:
                    return RectMax;
                default:
                    throw new ArgumentOutOfRangeException(nameof(rectType), rectType, null);
            }
        }
    }
}