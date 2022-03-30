using System.Collections.Generic;
using System.Linq;
using EDTree;

namespace EDTree2
{
    public class EDTree
    {

        public Input Input { get; private set; }

        public List<double> X => Input.Data[0];
        public string[] Header => Input.Header;
        public string LabelX => Input.LabelX;
        public string LabelY => Input.LabelY;

        // Functions.
        public FittingLine UpperLine { get; private set; }
        public FittingLine BaseLine { get; private set; }
        public FittingLine LowerLine { get; private set; }
        
        // Rects.
        private FittingRect Rect;
        public FittingEllipse Ellipse;

        public EDTree(Input input)
        {
            Input = input;
        }
        
        private (List<double> upper, List<double> baseline, List<double> lower) DivideInputData()
        {
            var lines = new[] {Input.Data[1], Input.Data[2], Input.Data[3]};
            var orderedList = lines.OrderBy(v => v[0]).ToList();
            return (orderedList[0], orderedList[1], orderedList[2]);
        }

        public EDTree Calculate(int order, double zstep)
        {
            var (upper, baseline, lower) = DivideInputData();

            UpperLine = new FittingLine(X, upper, order).Fit();
            BaseLine = new FittingLine(X, baseline, order).Fit();
            LowerLine = new FittingLine(X, lower, order).Fit();

            Rect = new FittingRect(zstep, UpperLine, LowerLine).Calculate();
            Ellipse = new FittingEllipse(zstep, UpperLine, LowerLine).Calculate();

            return this;
        }

        public List<double> GetXPoints(double step = 0.001)
        {
            double start = X.Min();
            double end = X.Max();

            List<double> xPoints = new List<double>();
            for (double i = start; i <= end; i += step)
            {
                xPoints.Add(i);
            }

            return xPoints;
        }

        public RectPoint GetRectangles(FittingType type)
        {
            return Rect.GetRect(type);
        }

        public EllipsePoint GetEllipse(EllipseStyle style)
        {
            switch (style)
            {
                case EllipseStyle.Max:
                    return Ellipse.GetEllipse(FittingType.Max);
            }

            return null;
        }
    }
}