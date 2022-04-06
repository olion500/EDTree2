using System;
using System.Collections.Generic;

namespace EDTree2
{
    public static class StringUtils
    {
        /// <summary>
        /// Convert polynomial coefficient to polynomial string. It supports degree 3 polynomials.
        /// </summary>
        /// <param name="f">Coefficients of polynomial equation.</param>
        public static string PolynomialString(IEnumerable<double> f)
        {
            var postfix = new [] {"", "x", "x²", "x³"};
            var pi = 0;
            
            string res = "";
            foreach (var v in f)
            {
                var op = (v < 0) ? "-" : "+";
                // if the value below 0.000001, then remove from the string.
                if (Math.Abs(v) > 0.000001)
                    res = op + v.ToString("0.######") + postfix[pi] + res;
                pi++;
            }
            return res.TrimStart('+');
        }
    }
}