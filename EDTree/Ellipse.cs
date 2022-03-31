using System;

namespace EDTree
{
    public class Ellipse
    {
        public double CenterX { get; set; }
        public double CenterY { get; set; }
        /// <summary>
        /// The length of X-axis.
        /// </summary>
        public double A { get; set; }
        /// <summary>
        /// The length of Y-axis.
        /// </summary>
        public double B { get; set; }

        public Ellipse(double centerX, double centerY, double a, double b)
        {
            CenterX = centerX;
            CenterY = centerY;
            A = a;
            B = b;
        }

        /// <summary>
        /// Returns ellipse from outside boundary of ellipse.
        /// </summary>
        public static Ellipse FromRect(double L, double T, double R, double B)
        {
            return new Ellipse(
                Average(L, R),
                Average(T, B),
                Distance(L, R) / 2.0,
                Distance(T, B) / 2.0
                );
        }

        private static double Average(double x, double y)
        {
            return (x + y) / 2.0;
        }

        private static double Distance(double x, double y)
        {
            return Math.Abs(x - y);
        }
    }
}