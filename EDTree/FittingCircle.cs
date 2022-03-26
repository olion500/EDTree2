using System;

namespace EDTree
{
    public class FittingCircle
    {

        public double BaseX
        {
            set => Rect.BaseX = value;
        }
        
        private FittingRect Rect;

        public FittingCircle(double baseX, FittingLine upperLine, FittingLine lowerLine, FittingType circleType = FittingType.Left)
        {
            Rect = new FittingRect(baseX, upperLine, lowerLine);
        }

        public FittingCircle(FittingRect rect)
        {
            Rect = rect;
        }

        public void Calculate()
        {
            throw new NotImplementedException();
        }
    }
}