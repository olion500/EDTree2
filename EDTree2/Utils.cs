using System;
using System.Collections.Generic;
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
    }
}