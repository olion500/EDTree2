using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;

namespace EDTree
{
    public class FittingLine
    {
        public List<double> X { get; set; }
        public List<double> Y { get; set; }
        public int Order { get; set; }
        
        public double Step { get; set; }
        
        public Polynomial F { get; private set; }
        public double[] Coefficients => F.Coefficients;
        public double RSquare { get; private set; }
        
        private List<double> PointX { get; set; }
        private List<double> PointY { get; set; }
        
        public FittingLine(List<double> x, List<double> y, int order=2, double step = 0.001)
        {
            X = x;
            Y = y;
            Order = order;
            Step = step;

            PointX = new List<double>();
            PointY = new List<double>();
        }

        public FittingLine Fit()
        {
            // generate polynomial equation.
            F = new Polynomial(MathNet.Numerics.Fit.Polynomial(X.ToArray(), Y.ToArray(), Order));
            RSquare = GoodnessOfFit.RSquared(X.Select(x => F.Evaluate(x)), Y);

            // pre-calculate points on the equation.
            PointX.Clear();
            PointY.Clear();
            var min = X.Min();
            var max = X.Max();
            for (var x = min; x <= max; x+=Step)
            {
                PointX.Add(x);
                PointY.Add(F.Evaluate(x));
            }

            return this;
        }

        public double Evaluate(double x)
        {
            return F.Evaluate(x);
        }

        public PointD MaxY()
        {
            var ymax = PointY.Max();
            var x = PointX[PointY.IndexOf(ymax)];
            return new PointD(x, ymax);
        }

        public List<double> FindXByY(double y, double maximumAbsoluteError = 0.0001)
        {
            var res = new List<double>();

            for (var i = 0; i < PointX.Count; i++)
            {
                
                if (PointY[i].AlmostEqual(y, maximumAbsoluteError))
                    res.Add(PointX[i]);
            }

            return res;
        }
    }
}