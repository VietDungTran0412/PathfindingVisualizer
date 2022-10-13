using System;
using SplashKitSDK;

namespace CustomProgram
{
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
            return Color.RGBColor(250, 136, 105);
        }
        public override void ToPath()
        {
            return;
        }
        public int Val
        {
            get { return _num; }
            set { _num = value; }
        }
        public override void Draw()
        {
            base.Draw();
            Font font = Constants.Font;
            double fontMarginLeft = SplashKit.TextWidth(_num.ToString(),font,25)/1.5;
            double fontMarginTop = SplashKit.TextHeight(_num.ToString(), font, 25)/4;
            SplashKit.DrawText(_num.ToString(), Color.Black, font, 25, Shape.X + fontMarginLeft, Shape.Y + fontMarginTop);
        }
    }
}

