using System.Collections.Generic;
using System.Linq;
using EDTree;
using EDTree2.form.option;

namespace EDTree2
{
    public class EDTree
    {

        public Input Input { get; private set; }
        public EdtreeOption Option { get; private set; }

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

        /// <summary>
        /// Set Edtree option that contains user's input.
        /// </summary>
        public EDTree SetOption(EdtreeOption option)
        {
            Option = option;
            return this;
        }
        
        /// <summary>
        /// Calculate and create line equations, rectangles, and ellipses with the given option.
        /// </summary>
        public EDTree Calculate()
        {
            var (upper, baseline, lower) = DivideInputData();

            UpperLine = new FittingLine(X, upper, Option.Order).Fit();
            BaseLine = new FittingLine(X, baseline, Option.Order).Fit();
            LowerLine = new FittingLine(X, lower, Option.Order).Fit();

            Rect = new FittingRect(Option.ZstepMin, Option.ZstepMax, UpperLine, LowerLine).Calculate();
            Ellipse = new FittingEllipse(Option.EllipseMinX, Option.EllipseMaxX, UpperLine, LowerLine).Calculate();

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

        /// <summary>
        /// Return Rectangle with the given style.
        /// </summary>
        public RectPoint GetRectangles(RectStyle style)
        {
            switch (style)
            {
                case RectStyle.None:
                    return null;
                case RectStyle.Left:
                    return Rect.GetRect(FittingType.Left);
                case RectStyle.Right:
                    return Rect.GetRect(FittingType.Right);
                case RectStyle.Avg:
                    return Rect.GetRect(FittingType.Average);
                case RectStyle.Max:
                    return Rect.GetRect(FittingType.Max);
            }

            return null;
        }

        /// <summary>
        /// Return Ellipse with the given style.
        /// </summary>
        public EllipsePoint GetEllipse(EllipseStyle style)
        {
            switch (style)
            {
                case EllipseStyle.Max:
                    return Ellipse.Ellipse;
            }

            return null;
        }
        
        /// <summary>
        /// Paring Input to upper, base, lower lines.
        /// It assumes that the three lines are placed in order.
        /// </summary>
        /// <returns></returns>
        private (List<double> upper, List<double> baseline, List<double> lower) DivideInputData()
        {
            var lines = new[] {Input.Data[1], Input.Data[2], Input.Data[3]};
            var orderedList = lines.OrderBy(v => v[0]).ToList();
            return (orderedList[0], orderedList[1], orderedList[2]);
        }
    }
}