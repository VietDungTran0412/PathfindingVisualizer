using System;
using SplashKitSDK;
namespace CustomProgram
{
    // Normal Node in the Node collection
    public class NormalNode : AbstractNode
    {
        public NormalNode(int size, Coordinate coordinate) : base(size, coordinate)
        {
            Shape.Color = GetColor();
        }
        public override Color GetColor()
        {
            return Color.White;
        }
        public override void ToPath()
        {
            Shape.Color = Color.DeepPink; // highlight if it is in path
        }

    }
}

