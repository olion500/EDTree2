using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MathNet.Numerics;

namespace EDTree2
{
    public class Utils
    {
        public static double LinearF(double[] coefficients, double x)
        {
            double result = 0;
            double power = 0;

            foreach (double cef in coefficients)
            {
                result += cef * Math.Pow(x, power);
                power += 1;
            }

            return Math.Round(result, 5);
        }

        public static double[] MultiplyArray(double[] array, double multiplier)
        {
            return array.Select(x => x * multiplier).ToArray();
        }

        public static List<int> FindXIndex(List<double> points, double y, int decimalPlace=3)
        {
            List<int> result = new List<int>();
            int index = 0;
            
            foreach (double p in points)
            {
                if (p.AlmostEqualRelative(y, decimalPlace))
                    result.Add(index);
                index++;
            }

            return result;
        }

        public static PointF FindCircumcenter(PointF a, PointF b, PointF c)
        {
            var d = 2 * (a.X * (b.Y - c.Y) + b.X * (c.Y - a.Y) + c.X * (a.Y - b.Y));
            var ux = ((a.X * a.X + a.Y * a.Y) * (b.Y - c.Y) + (b.X * b.X + b.Y * b.Y) * (c.Y - a.Y) +
                      (c.X * c.X + c.Y * c.Y) * (a.Y - b.Y)) / d;
            var uy = ((a.X * a.X + a.Y * a.Y) * (c.X - b.X) + (b.X * b.X + b.Y * b.Y) * (a.X - c.X) +
                      (c.X * c.X + c.Y * c.Y) * (b.X - a.X)) / d;
            return new PointF(ux, uy);
        }
    }
}