using System;
using System.Drawing;

namespace EDTree2
{
    public class RectanglePoint
    {
        public double L { get; set; }
        public double T { get; set; }
        public double R { get; set; }
        public double B { get; set; }

        public double Width => Math.Round(Math.Abs(R - L), 3);
        public double Height => Math.Round(Math.Abs(B - T), 3);
        public double Size => Math.Round(Width * Height, 3);

        public RectanglePoint(double l, double t, double r, double b)
        {
            L = l;
            T = t;
            R = r;
            B = b;
        }

    }
}