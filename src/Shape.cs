using System;
using SplashKitSDK;
namespace CustomProgram
{
    public abstract class Shape
    {
        private Color _color;
        private double _x;
        private double _y;
        public Shape() : this(Color.White) { }
        public Shape(Color color)
        {
            _color = color;
            _x = 0;
            _y = 0;
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

