using System;

public static class Window
{
    public class WindowDimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public static WindowDimensions? Dimensions { get; set; } = new WindowDimensions();
}
