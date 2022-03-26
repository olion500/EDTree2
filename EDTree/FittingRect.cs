using System;
using System.Linq;

namespace EDTree
{
    public class FittingRect
    {
        public double BaseX { get; set; }
        public RectPoint RectLeft { get; set; }
        public RectPoint RectRight { get; set; }
        public RectPoint RectAvg { get; set; }
        public RectPoint RectMax { get; set; }

        private readonly FittingLine UpperLine;
        private readonly FittingLine LowerLine;

        public FittingRect(double baseX, FittingLine upperLine, FittingLine lowerLine)
        {
            BaseX = Math.Abs(baseX);
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

        public FittingRect Calculate()
        {
            double l, t, r, b;

            l = -BaseX;
            t = UpperLine.Evaluate(l);
            r = UpperLine.FindXByY(t).Max();
            b = LowerLine.MaxY().y;
            RectLeft = new RectPoint(l, t, r, b);

            r = BaseX;
            t = UpperLine.Evaluate(r);
            l = UpperLine.FindXByY(t).Min();
            b = LowerLine.MaxY().y;
            RectRight = new RectPoint(l, t, r, b);
            
            RectAvg = new RectPoint(
                (RectLeft.L + RectRight.L) / 2,
                (RectLeft.T + RectRight.T) / 2,
                (RectLeft.R + RectRight.R) / 2,
                (RectLeft.B + RectRight.B) / 2
            );
            
            RectMax = new RectPoint(0, 0, 0, 0);
            b = LowerLine.MaxY().y;
            for (double x = -BaseX; x <= BaseX; x++)
            {
                l = x;
                t = UpperLine.Evaluate(x);
                r = UpperLine.FindXByY(t).Max();
                var tmpRect = new RectPoint(l, t, r, b);
                if (tmpRect.Size > RectMax.Size) RectMax = tmpRect;
            }

            return this;
        }

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