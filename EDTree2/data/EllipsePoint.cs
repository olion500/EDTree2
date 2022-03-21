using System;
using System.Drawing;

namespace EDTree2
{
    public class EllipsePoint
    {
        public PointF Point1 { get; set; }
        public PointF Point2 { get; set; }
        public PointF Point3 { get; set; }
        
        public PointF Center { get; set; }
        public double RadiusA { get; set; }
        public double RadiusB { get; set; }

        public double L => Center.X - RadiusA;
        public double T => Center.Y - RadiusB;
        public double R => Center.X + RadiusA;
        public double B => Center.Y + RadiusB;
        
        public double Size => Math.Round(RadiusA * RadiusB * Math.PI, 3);
        public double Width => Math.Round(2 * RadiusA, 3);
        public double Height => Math.Round(2 * RadiusB, 3);

        public EllipsePoint(PointF point1, PointF point2, PointF point3)
        {
            Point1 = point1;
            Point2 = point2;
            Point3 = point3;

            var (xc, yc, a, b) = Utils.FindMaxEllipse(point1, point2, point3);
            Center = new PointF((float) xc, (float) yc);
            RadiusA = a;
            RadiusB = b;
        }
        
    }
}