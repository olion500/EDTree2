using System;

namespace EDTree
{
    public class RectPoint
    {
        public double L { get; set; }
        public double T { get; set; }
        public double R { get; set; }
        public double B { get; set; }

        public double Width => Math.Round(Math.Abs(R - L), 3);
        public double Height => Math.Round(Math.Abs(B - T), 3);
        public double Size => Math.Round(Width * Height, 3);

        public RectPoint(double l, double t, double r, double b)
        {
            L = l;
            T = t;
            R = r;
            B = b;
        }

        /// <summary>
        /// Calculate intersected Rectangle between given two RectPoint.
        /// </summary>
        /// <returns>RectPoint. If there's no intersection, return null.</returns>
        public RectPoint Intersect(RectPoint other)
        {
            if (other == null) return null;

            // case 1. 왼쪽으로 벗어난 경우.
            if (L > other.R) return null;
            
            // case 2. 오른쪽으로 벗어난 경우.
            if (R < other.L) return null;
            
            // case 3. 위쪽으로 벗어난 경우.
            if (B > other.T) return null;
            
            // case 4. 아래쪽으로 벗어난 경우.
            if (T < other.B) return null;

            return new RectPoint(
                Math.Max(L, other.L),
                Math.Min(T, other.T),
                Math.Min(R, other.R),
                Math.Max(B, other.B)
            );
        }

    }
}