using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using MathNet.Numerics;

namespace EDTree2
{
    public class Utils
    {
        public static string PolynomialString(IEnumerable<double> f)
        {
            var postfix = new [] {"", "x", "x²", "x³"};
            var pi = 0;
            
            string res = "";
            foreach (var v in f)
            {
                var op = (v < 0) ? "-" : "+";
                res = op + v.ToString("0.######") + postfix[pi] + res;
                pi++;
            }
            return res.TrimStart('+');
        }
    }
}