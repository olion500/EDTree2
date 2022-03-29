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

        // options.
        public RectStyle RectStyle { get; set; }
        public EllipseStyle EllipseStyle { get; set; }
        public int Order { get; set; }
        public double Zstep { get; set; }
        public bool IsShowEquation { get; set; }
        public bool IsLogY { get; set; }
        
        // Functions.
        public FittingLine UpperLine { get; private set; }
        public FittingLine BaseLine { get; private set; }
        public FittingLine LowerLine { get; private set; }
        
        // Rects.
        private FittingRect Rect;
        public FittingCircle Ellipse;

        public EDTree(Input input)
        {
            Input = input;
            
            // init options.
            ResetOptions();
        }

        public void ResetOptions()
        {
            RectStyle = RectStyle.BaseLine;
            EllipseStyle = EllipseStyle.None;
            Order = 2;
            Zstep = 10;
            IsShowEquation = true;
            IsLogY = false;
        }
        
        private (List<double> upper, List<double> baseline, List<double> lower) DivideInputData()
        {
            var lines = new[] {Input.Data[1], Input.Data[2], Input.Data[3]};
            var orderedList = lines.OrderBy(v => v[0]).ToList();
            return (orderedList[0], orderedList[1], orderedList[2]);
        }

        public EDTree Calculate()
        {
            var (upper, baseline, lower) = DivideInputData();

            UpperLine = new FittingLine(X, upper, Order).Fit();
            BaseLine = new FittingLine(X, baseline, Order).Fit();
            LowerLine = new FittingLine(X, lower, Order).Fit();

            Rect = new FittingRect(Zstep, UpperLine, LowerLine).Calculate();
            Ellipse = new FittingCircle(Zstep, UpperLine, LowerLine).Calculate();

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
                case EllipseStyle.Left:
                    return Ellipse.GetEllipse(FittingType.Left);
                case EllipseStyle.Right:
                    return Ellipse.GetEllipse(FittingType.Right);
                case EllipseStyle.Average:
                    return Ellipse.GetEllipse(FittingType.Average);
                case EllipseStyle.Max:
                    return Ellipse.GetEllipse(FittingType.Max);
            }

            return null;
        }
    }
}