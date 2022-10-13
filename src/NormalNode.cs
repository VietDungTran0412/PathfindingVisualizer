using System;
using SplashKitSDK;
namespace CustomProgram
{
    public class NormalNode : AbstractNode
    {
        public NormalNode(int size, Coordinate coordinate) : base(size, coordinate)
        {
            this.Shape.Color = GetColor();
        }
        public override Color GetColor()
        {
            return Color.White;
        }
        public override void ToPath()
        {
            Shape.Color = Color.DeepPink;
        }

    }
}

