using System.Drawing;

namespace EDTree2
{
    public class Palette
    {
        private static int alpha = 10;
            
        public static Color colorUpper = Color.Green;
        public static Color colorLower = Color.MediumBlue;
        public static Color colorBase = Color.OrangeRed;
        public static Color colorCircle = Color.Chocolate;

        public static Color colorUpperTrans = Color.FromArgb(alpha, colorUpper);
        public static Color colorBaseTrans = Color.FromArgb(alpha, colorBase);
        public static Color colorLowerTrans = Color.FromArgb(alpha, colorLower);
        
    }
}