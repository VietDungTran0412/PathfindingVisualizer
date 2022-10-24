using System;
using SplashKitSDK;
namespace CustomProgram
{
    // Rectangle shape used to draw different artwork
    public class Rectangle : Shape
    {
        private int _width;
        private int _height;
        public Rectangle() : this(0, 0, 0, 0) { }
        public Rectangle(double x, double y, int width, int height)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }
        public Rectangle(double x, double y, int width, int height, Color color) : base(color)
        {
            X = x;
            Y = y;
            _width = width;
            _height = height;
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public override void Draw()
        {
            SplashKit.FillRectangle(Color,X, Y, Width, Height);
        }
        public override bool IsAt()
        {
            double mouseX = SplashKit.MouseX();
            double mouseY = SplashKit.MouseY();
            return mouseX < Width + X && mouseX > X && mouseY > Y && mouseY < Y + Height;
        }

    }
}

