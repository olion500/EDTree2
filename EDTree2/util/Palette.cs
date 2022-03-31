using System.Drawing;

namespace EDTree2
{
    public class Palette
    {
        private static int alpha = 20;

        public static NamedColor colorUpper = new NamedColor(Color.Green, "Green");
        public static NamedColor colorLower = new NamedColor(Color.MediumBlue, "Blue");
        public static NamedColor colorBase = new NamedColor(Color.OrangeRed, "Red");
       

        public static NamedColor colorUpperTrans = NamedColorWithTransparent(colorUpper, "GreenTrans");
        public static NamedColor colorBaseTrans = NamedColorWithTransparent(colorBase, "RedTrans");
        public static NamedColor colorLowerTrans = NamedColorWithTransparent(colorLower, "BlueTrans");
        
        public static NamedColor colorRectLeft = new NamedColor(Color.Green, "Green");
        public static NamedColor colorRectRight = new NamedColor(Color.MediumBlue, "Blue");
        public static NamedColor colorRectAvg = new NamedColor(Color.OrangeRed, "Red");
        public static NamedColor colorRectMax = new NamedColor(Color.Brown, "Brown");
        public static NamedColor colorRectCommon = new NamedColor(Color.Aqua, "Aqua");
        public static NamedColor colorRectCommonTrans = NamedColorWithTransparent(colorRectCommon, "AquaTrans");

        /// <summary>
        /// Returns color with the given rect style.
        /// </summary>
        public static NamedColor FromRectStyle(RectStyle style)
        {
            switch (style)
            {
                case RectStyle.Left:
                    return colorRectLeft;
                case RectStyle.Right:
                    return colorRectRight;
                case RectStyle.Avg:
                    return colorRectAvg;
                case RectStyle.Max:
                    return colorRectMax;
            }

            return null;
        }
        
        /// <summary>
        /// Generate Namedcolor with transparency.
        /// </summary>
        private static NamedColor NamedColorWithTransparent(NamedColor color, string name)
        {
            return new NamedColor(Color.FromArgb(alpha, color.Color), name);
        }
        
            
    }
}