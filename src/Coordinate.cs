using System;
namespace CustomProgram
{
    // Coordinate of object in the grid or node collection
    public class Coordinate
    {
        private int _row;
        private int _col;
        public Coordinate(int row, int col)
        {
            _row = row;
            _col = col;
        }
        public int Row
        {
            get { return _row; }
        }
        public int Column
        {
            get { return _col; }
        }
    }
}

