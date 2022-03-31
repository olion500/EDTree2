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

        public List<FittingLine> Lines { get; private set; }
        
        public AerialCD(Input input)
        {
            Order = 3;
            Input = input;
            Lines = new List<FittingLine>();
        }
        
        public AerialCD Calculate()
        {
            Lines.Clear();

            for (int i = 1; i < Cols; i++)
            {
                var line = new FittingLine(X, Input.Data[i], Order).Fit();
                Lines.Add(line);
            }
            return this;
        }
        
        /// <summary>
        /// Returns X points to draw lines. The lower step, more smooth line.
        /// </summary>
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