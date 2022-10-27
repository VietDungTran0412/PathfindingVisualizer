using System;
using SplashKitSDK;
namespace CustomProgram
{
    // Rectangle shape used to draw different artwork
    public class Rectangle : Shape
    {
        public Rectangle() : this(0, 0, 0, 0) { }
        public Rectangle(double x, double y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public Rectangle(double x, double y, int width, int height, Color color) : base(color)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
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

