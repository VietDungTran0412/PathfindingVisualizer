using System;
using SplashKitSDK;

namespace CustomProgram
{
    public class WallNode : AbstractNode
    {
        public WallNode() : this(-1, new Coordinate(-1, -1)) { }
        public WallNode(int size, Coordinate coordinate):base(size,coordinate)
        {
            Shape.Color = GetColor();
        }
        public override Color GetColor()
        {
            return Color.Black;
        }
        // Wall node so can not be highlighted as path
        public override void ToPath()
        {
            return;
        }
    }
}

