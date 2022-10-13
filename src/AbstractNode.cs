using System;
using SplashKitSDK;
namespace CustomProgram
{
    public abstract class AbstractNode
    {
        private Coordinate _position;
        private Shape _shape;
        private int _size;
        private int _padding;
        public AbstractNode(int size, Coordinate coordinate)
        {
            _position = coordinate;
            _size = size;
            _padding = 2;
            _shape = new Rectangle(coordinate.Row * size + 1, coordinate.Column * size + 1, size - _padding, size - _padding);
        }
        public virtual void Draw()
        {
            _shape.Draw();
        }
        public abstract void ToPath();
        public abstract Color GetColor();
        public Coordinate Position
        {
            get { return _position; }
        }
        public Shape Shape
        {
            get { return _shape; }
        }
    }
}

