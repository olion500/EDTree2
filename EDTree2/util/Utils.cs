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

        public static double PointDistance(PointF a, PointF b)
        {
            return Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
        }

        public static (double xc, double yc , double a, double b) FindMaxEllipse(PointF p1, PointF p2, PointF p3)
        {
            var (xc, yc, a, b) = CenterInfo(p1, p2, p3);
            var t = 0.0001;
            var ratio = a / b;
            
            while (true)
            {
                var at = a + ratio * t;
                var bt = b + t;
                var yct = yc + t;
                if (IsEllipseOutRange(xc, yct, at, bt, p1) && IsEllipseOutRange(xc, yct, at, bt, p2) &&
                    IsEllipseOutRange(xc, yct, at, bt, p3))
                {
                    a = at;
                    b = bt;
                    yc = yct;
                }
                else
                {
                    break;
                }
            }
            
            return (xc, yc, a, b);
        }

        public static PointF MaxPoint3(PointF p1, PointF p2, PointF p3)
        {
            return new PointF(
                Math.Max(Math.Max(p1.X, p2.X), p3.X),
                Math.Max(Math.Max(p1.Y, p2.Y), p3.Y)
            );
        }
        
        public static PointF MinPoint3(PointF p1, PointF p2, PointF p3)
        {
            return new PointF(
                Math.Min(Math.Min(p1.X, p2.X), p3.X),
                Math.Min(Math.Min(p1.Y, p2.Y), p3.Y)
            );
        }

        private static (double cx, double cy, double a, double b) CenterInfo(PointF p1, PointF p2, PointF p3)
        {
            var minP = MinPoint3(p1, p2, p3);
            var maxP = MaxPoint3(p1, p2, p3);
            var lengthX = (maxP.X - minP.X) / 2.0;
            var lengthY = (maxP.Y - minP.Y) / 2.0;
            return (minP.X + lengthX, minP.Y + lengthY, lengthX, lengthY);
        }

        private static bool IsEllipseOutRange(double xc, double yc, double a, double b, PointF p)
        {
            var sqX = Math.Pow(p.X - xc, 2) / Math.Pow(a, 2);
            var sqY = Math.Pow(p.Y - yc, 2) / Math.Pow(b, 2);
            return sqX + sqY - 1.0 > 0;
        }
    }
}