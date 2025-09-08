using System.Drawing;

namespace IntroWithAbstractClass
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
            this.Color = color;
            this.HeightInMm = heightInMm;
            this.WidthInMm = widthInMm;
            this.Position = position;
        }
    }
}
