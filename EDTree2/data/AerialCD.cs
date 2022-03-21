using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;

namespace EDTree2
{
    public class AerialCD
    {
        private static double Step = 0.001;
        
        public Input Input { get; set; }
        public int Rows => Input.Data.First().Count;
        public int Cols => Input.Header.Length;
        
        public int Order { get; set; }
        
        public List<double> X { get; set; }
        public List<double[]> Fs { get; set; }
        public List<double> Rs { get; set; }

        public AerialCD()
        {
            Order = 3;

            X = new List<double>();
            Fs = new List<double[]>();
            Rs = new List<double>();
        }

        public void Calculate()
        {
            var start = Math.Min(Input.Data[0].First(), Input.Data[0].Last());
            var end = Math.Max(Input.Data[0].First(), Input.Data[0].Last());
            for (double k = start; k <= end; k += Step)
            {
                X.Add(k);
            }
            
            for (int i = 1; i < Cols; i++)
            {
                var y = Input.Data[i].ToArray();
                var f = Fit.Polynomial(Input.Data[0].ToArray(), y, Order);
                Fs.Add(f);
                
                
            }
            
            for (int i=0; i<Fs.Count; i++)
            {
                var r = GoodnessOfFit.RSquared(Input.Data[0].Select(x => Utils.LinearF(Fs[i], x)), Input.Data[i+1]);
                Rs.Add(r);
            }
        }
    }
}