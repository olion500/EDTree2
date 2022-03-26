using System;
using System.Linq;

namespace EDTree
{
    public class FittingRect
    {
        public double BaseX { get; set; }
        public RectPoint Rect { get; set; }
        public FittingType RectType { get; set; }

        private readonly FittingLine UpperLine;
        private readonly FittingLine LowerLine;

        public FittingRect(double baseX, FittingLine upperLine, FittingLine lowerLine, FittingType rectType = FittingType.Left)
        {
            BaseX = Math.Abs(baseX);
            if (upperLine.Evaluate(baseX) > lowerLine.Evaluate(baseX))
            {
                UpperLine = upperLine;
                LowerLine = lowerLine;
            }
            else
            {
                UpperLine = lowerLine;
                LowerLine = lowerLine;
            }
            RectType = rectType;
        }

        public void Calculate()
        {
            double l, t, r, b;

            l = -BaseX;
            t = UpperLine.Evaluate(l);
            r = UpperLine.FindXByY(t).Last();
            b = LowerLine.MaxY().y;
            var rectLeft = new RectPoint(l, t, r, b);

            r = BaseX;
            t = UpperLine.Evaluate(r);
            l = UpperLine.FindXByY(t).First();
            b = LowerLine.MaxY().y;
            var rectRight = new RectPoint(l, t, r, b);

            if (RectType == FittingType.Left) Rect = rectLeft;
            else if (RectType == FittingType.Right) Rect = rectRight;
            else if (RectType == FittingType.Average)
            {
                Rect = new RectPoint(
                    (rectLeft.L + rectRight.L) / 2,
                    (rectLeft.T + rectRight.T) / 2,
                    (rectLeft.R + rectRight.R) / 2,
                    (rectLeft.B + rectRight.B) / 2
                );
            }
            else if (RectType == FittingType.Max)
            {
                var rectMax = new RectPoint(0, 0, 0, 0);
                b = LowerLine.MaxY().y;
                for (double x = -BaseX; x <= BaseX; x++)
                {
                    l = x;
                    t = UpperLine.Evaluate(x);
                    r = UpperLine.FindXByY(x).Last();
                    var tmpRect = new RectPoint(l, t, r, b);
                    if (tmpRect.Size > rectMax.Size) rectMax = tmpRect;
                }
                Rect = rectMax;
            }
        }
    }
}