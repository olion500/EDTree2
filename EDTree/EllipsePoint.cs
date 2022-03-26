using System;

namespace EDTree
{
    public class EllipsePoint : RectPoint
    {
        public new double Size => Math.Round((Width / 2) * (Height / 2) * Math.PI, 3);
        
        public EllipsePoint(double l, double t, double r, double b) : base(l, t, r, b)
        {
        }
    }
}