using System;
using SplashKitSDK;
namespace CustomProgram
{
    public class Rectangle : Shape
    {
        private int _width;
        private int _height;
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
        }
        public int Height
        {
            get { return _height; }
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

