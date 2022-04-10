using System.Collections.Generic;
using System.Drawing;

namespace EDTree2
{
    public class Palette
    {
        // opacity value.
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
        
        // Aerial CD Colors
        public static NamedColor colorLine1 = new NamedColor(Color.FromArgb(65, 140, 241), "line1");
        public static NamedColor colorLine2 = new NamedColor(Color.FromArgb(252, 180, 64), "line2");
        public static NamedColor colorLine3 = new NamedColor(Color.FromArgb(224, 64, 10), "line3");
        public static NamedColor colorLine4 = new NamedColor(Color.FromArgb(204, 111, 79), "line4");
        public static NamedColor colorLine5 = new NamedColor(Color.FromArgb(18, 156, 220), "line5");
        public static NamedColor colorLine6 = new NamedColor(Color.FromArgb(193, 193, 193), "line6");
        public static NamedColor colorLine7 = new NamedColor(Color.FromArgb(1, 92, 219), "line7");
        public static NamedColor colorLine8 = new NamedColor(Color.FromArgb(26, 63,108), "line8");
        public static NamedColor colorLine9 = new NamedColor(Color.FromArgb(255, 226, 129), "line9");
        public static NamedColor colorLine10 = new NamedColor(Color.FromArgb(5,100, 146), "line10");
        

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
        /// Get Colors used in intensity line chart.
        /// Colors are ordered as lower, base, upper.
        /// </summary>
        public static List<NamedColor> GetIntensityColors()
        {
            return new List<NamedColor> {colorLower, colorBase, colorUpper};
        }

        /// <summary>
        /// Get Colors used in Aerial line chart.
        /// </summary>
        /// <returns></returns>
        public static List<NamedColor> GetAerialLineColors()
        {
            return new List<NamedColor> {colorLine1, colorLine2, colorLine3, colorLine4, colorLine5, colorLine6, colorLine7, colorLine8, colorLine9, colorLine10};
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