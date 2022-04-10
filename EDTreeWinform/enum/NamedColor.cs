using System.Drawing;

namespace EDTree2
{
    public class NamedColor
    {
        public Color Color { get; }
        public string Name { get; }

        public NamedColor(Color color, string name)
        {
            Color = color;
            Name = name;
        }
    }
}