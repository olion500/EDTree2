using System.Drawing;

namespace EDTree2
{
    public class Palette
    {
        private static int alpha = 20;

        // line colors.
        public static NamedColor colorUpper = new NamedColor(Color.Green, "Green");
        public static NamedColor colorLower = new NamedColor(Color.MediumBlue, "Blue");
        public static NamedColor colorBase = new NamedColor(Color.OrangeRed, "Red");

        // comparison line color
        public static NamedColor colorUpperTrans = NamedColorWithTransparent(colorUpper, "GreenTrans");
        public static NamedColor colorBaseTrans = NamedColorWithTransparent(colorBase, "RedTrans");
        public static NamedColor colorLowerTrans = NamedColorWithTransparent(colorLower, "BlueTrans");
        
        // rectangle color
        public static NamedColor colorRectLeft = new NamedColor(Color.Green, "Green");
        public static NamedColor colorRectLeftTrans = NamedColorWithTransparent(colorRectLeft, "GreenCmp");
        public static NamedColor colorRectRight = new NamedColor(Color.MediumBlue, "Blue");
        public static NamedColor colorRectRightTrans = NamedColorWithTransparent(colorRectRight, "BlueCmp");
        public static NamedColor colorRectAvg = new NamedColor(Color.OrangeRed, "Red");
        public static NamedColor colorRectAvgTrans = NamedColorWithTransparent(colorRectAvg, "RedCmp");
        public static NamedColor colorRectMax = new NamedColor(Color.Brown, "Brown");
        public static NamedColor colorRectMaxTrans = NamedColorWithTransparent(colorRectMax, "BrownCmp");
        public static NamedColor colorRectCommon = new NamedColor(Color.Aqua, "Aqua");
        public static NamedColor colorRectCommonTrans = NamedColorWithTransparent(colorRectCommon, "AquaTrans");
        
        // ellipse color
        public static NamedColor colorEllipse = new NamedColor(Color.Goldenrod, "Gold");
        public static NamedColor colorEllipseTrans = NamedColorWithTransparent(colorEllipse, "GoldTrans");

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
        /// Returns Compared color with the given rect style.
        /// </summary>
        public static NamedColor FromRectStyleCmp(RectStyle style)
        {
            switch (style)
            {
                case RectStyle.Left:
                    return colorRectLeftTrans;
                case RectStyle.Right:
                    return colorRectRightTrans;
                case RectStyle.Avg:
                    return colorRectAvgTrans;
                case RectStyle.Max:
                    return colorRectMaxTrans;
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