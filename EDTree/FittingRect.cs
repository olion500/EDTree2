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

            // l = MinX;
            // t = UpperLine.Evaluate(l);
            // r = UpperLine.FindXByY(t).Max();
            // b = LowerLine.MaxY().Y;
            // RectLeft = new RectPoint(l, t, r, b);
            RectLeft = null;

            r = MaxX;
            t = UpperLine.Evaluate(r);
            l = UpperLine.FindXByY(t).Min();
            b = LowerLine.MaxY().Y;
            RectRight = new RectPoint(l, t, r, b);

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
            
            RectMax = new RectPoint(0, 0, 0, 0);
            b = LowerLine.MaxY().Y;
            for (double x = MinX; x <= MaxX; x++)
            {
                l = x;
                t = UpperLine.Evaluate(x);
                r = UpperLine.FindXByY(t).Max();
                var tmpRect = new RectPoint(l, t, r, b);
                if (tmpRect.Size > RectMax.Size) RectMax = tmpRect;
            }

            return this;
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