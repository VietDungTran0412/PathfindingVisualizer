using System;
using SplashKitSDK;
namespace CustomProgram
{
    // Abstract Node of the node collection
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
        // Draw the shape of node. Placed as virtual later, Destination Node has to draw number inside
        public virtual void Draw()
        {
            _shape.Draw();
        }
        // Square size of Node
        public int Size
        {
            get => _size;
        }
        // Higlight itself if it is in the path
        public abstract void ToPath();
        // Get Color of itself
        public abstract Color GetColor();
        // Coordinate position in the grid
        public Coordinate Position
        {
            get { return _position; }
        }
        // Shape of node
        public Shape Shape
        {
            get { return _shape; }
        }
    }
}

