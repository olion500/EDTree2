using System.Collections.Generic;

namespace EDTree2.form.option
{
    /// <summary>
    /// The option that the user manipulates the main chart.
    /// </summary>
    public class EdtreeOption
    {
        /// <summary>
        /// The rect styles to draw in the chart. If only None exist or empty, none of rect will be drawn.
        /// </summary>
        public List<RectStyle> RectStyles { get; private set; }
        
        /// <summary>
        /// The ellipse style to draw in the chart.
        /// </summary>
        public EllipseStyle EllipseStyle { get; set; }
        
        /// <summary>
        /// The minimum value of ellipse's main axis.
        /// </summary>
        public double EllipseMinX { get; set; }
        
        /// <summary>
        /// The maximum value of ellipse's main axis.
        /// </summary>
        public double EllipseMaxX { get; set; }
        
        /// <summary>
        /// The degree of the calculated polynomials.
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// The min value of rectangle drawing.
        /// </summary>
        public double ZstepMin { get; set; }
        
        /// <summary>
        /// The max value of rectangle drawing.
        /// </summary>
        public double ZstepMax { get; set; }
        
        /// <summary>
        /// Whether the equation is shown in the chart.
        /// </summary>
        public bool IsShowEquation { get; set; }
        
        /// <summary>
        /// Whether the Y-axis is log scale or not.
        /// </summary>
        public bool IsLogY { get; set; }

        public EdtreeOption()
        {
            ResetValues();
        }

        public void ResetValues()
        {
            // init values.
            RectStyles = new List<RectStyle>(new []{RectStyle.None});
            EllipseStyle = EllipseStyle.Max;
            EllipseMinX = -10;
            EllipseMaxX = 10;
            Order = 2;
            ZstepMin = -10;
            ZstepMax = 10;
            IsShowEquation = false;
            IsLogY = false;
        }

        /// <summary>
        /// Add Rectangle style. When `None`, remove all styles.
        /// </summary>
        public void AddRectStyle(RectStyle rs)
        {
            if (rs == RectStyle.None)
            {
                RectStyles.Clear();
            }
            else
            {
                RectStyles.Remove(RectStyle.None);
            }
            RectStyles.Add(rs);            
            
            // sort list.
            RectStyles.Sort();
        }

        /// <summary>
        /// Remove rectangle style list.
        /// </summary>
        public void RemoveRectStyle(RectStyle rs)
        {
            RectStyles.Remove(rs);
        }

        /// <summary>
        /// Remove all rectangle style from the list.
        /// </summary>
        public void ClearRectStyle()
        {
            RectStyles.Clear();
        }
    }
}