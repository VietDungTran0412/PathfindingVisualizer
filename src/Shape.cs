using System;
using SplashKitSDK;
namespace CustomProgram
{
    // Abstract Shape
    public abstract class Shape
    {
        private Color _color;
        private double _x;
        private double _y;
        private int _width;
        private int _height;
        public Shape() : this(Color.White) { }
        public Shape(Color color)
        {
            _x = 0;
            _y = 0;
            _width = 0;
            _height = 0;
            _color = color;
        }
        public int Width
        {
            get => _width;
            set => _width = value;
        }
        public int Height
        {
            get => _height;
            set => _height = value; 
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; }
        }
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public abstract void Draw();
        public abstract bool IsAt();
    }

}

