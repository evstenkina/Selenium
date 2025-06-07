namespace Selenium.Framework.Models
{
    public class JSCoordinates
    {
        public class Coordinates
        {
            public int Top { get; }
            public int Left { get; }

            public Coordinates(int top, int left)
            {
                Top = top;
                Left = left;
            }
        }
    }
}