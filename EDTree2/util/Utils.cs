using System;
using System.Collections.Generic;
using EDTree;

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
        
        public static RectPoint CommonRect(RectPoint r1, RectPoint r2)
        {
            if (r1 == null || r2 == null) return null;

            if (r1.L > r2.R
                || r1.T > r2.B
                || r1.R > r2.R
                || r1.B < r2.T) return null;

            return new RectPoint(
                Math.Max(r1.L, r2.L),
                Math.Min(r1.T, r2.T),
                Math.Min(r1.R, r2.R),
                Math.Max(r1.B, r2.B)
            );
        }
    }
}