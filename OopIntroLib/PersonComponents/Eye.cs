using System.Drawing;

namespace OopIntroLib.PersonComponents
{
    public enum Position
    {
        Left,
        Right
    }

    public class Eye
    {
        public Color Color { get; set; }
        public int HeightInMm { get; set; }
        public int WidthInMm { get; set; }
        public Position Position { get; set; }

        public Eye(Color color, int heightInMm, int widthInMm, Position position)
        {
            Color = color;
            HeightInMm = heightInMm;
            WidthInMm = widthInMm;
            Position = position;
        }
    }
}
