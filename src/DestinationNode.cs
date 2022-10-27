using System;
using SplashKitSDK;

namespace CustomProgram
{
    // Node checkpoint/destination to travel
    public class DestinationNode : AbstractNode
    {
        private int _num;
        public DestinationNode(int size, Coordinate coordinate, int num):base(size,coordinate)
        {
            _num = num;
            Shape.Color = GetColor();
        }
        public override Color GetColor()
        {
            return Color.RGBColor(237,156,90);
        }
        public override void ToPath()
        {
            return;
        }
        public override void Draw()
        {
            base.Draw();
            Font font = Constants.ExtraFont;
            double fontMarginLeft = Size / 2 - 10;
            double fontMarginTop = Size / 2 -  SplashKit.TextHeight(_num.ToString(), font, 30)/2;
            SplashKit.DrawText(_num.ToString(), Color.Black, font, 30, Shape.X + fontMarginLeft, Shape.Y + fontMarginTop);
        }
    }
}

