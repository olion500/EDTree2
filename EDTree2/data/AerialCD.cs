using System.Collections.Generic;
using System.Linq;
using EDTree;

namespace EDTree2
{
    public class AerialCD
    {
        public Input Input { get; set; }
        public List<double> X => Input.Data[0];
        public string[] Header => Input.Header;
        public string LabelX => Input.LabelX;
        public string LabelY => Input.LabelY;
        public int Rows => Input.Data.First().Count;
        public int Cols => Input.Header.Length;
        
        public int Order { get; set; }

        public FittingLine Line { get; private set; }
        
        public AerialCD(Input input)
        {
            Order = 3;

            Input = input;
        }
        
        public AerialCD Calculate()
        {
            Line = new FittingLine(X, Input.Data[1], Order).Fit();
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
    }
}