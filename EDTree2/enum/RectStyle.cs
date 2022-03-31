using EDTree;

namespace EDTree2
{
    /// <summary>
    /// The option that the user choose to which rectangle is shown.
    /// </summary>
    public enum RectStyle
    {
        None,
        Left,
        Right,
        Avg,
        Max
    }

    public static class RectStyleExtension
    {
        public static FittingType? ToFittingType(this RectStyle rs)
        {
            switch (rs)
            {
                case RectStyle.None:
                    return null;
                case RectStyle.Left:
                    return FittingType.Left;
                case RectStyle.Right:
                    return FittingType.Right;
                case RectStyle.Avg:
                    return FittingType.Average;
                case RectStyle.Max:
                    return FittingType.Max;
            }

            return null;
        }
    }
}