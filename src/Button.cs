using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    public class Button
    {
        private Rectangle _rect;
        private string _content;
        private IOnClick _onClick;
        public Button(Rectangle rect,IOnClick onClick ,string content)
        {
            _rect = rect;
            _onClick = onClick;
            _content = content;
        }
        public Rectangle Rectangle
        {
            get { return _rect; }
        }
        public void Hover()
        {
            int margin = 3;
            if (_rect.IsAt())
            {
                SplashKit.DrawRectangle(Color.Black, _rect.X - margin, _rect.Y - margin, _rect.Width + margin * 2, _rect.Height + margin * 2);
            }
        }
        public void Click()
        {
            if(_rect.IsAt() && SplashKit.MouseDown(MouseButton.LeftButton))
            {
                _onClick.Notify();
            }
        }
        public void Draw()
        {
            _rect.Draw();
            int paddingTop = 22;
            int paddingLeft = 15;
            Font font = Constants.Font;
            SplashKit.DrawText(_content, Color.White, font, 20, paddingLeft + _rect.X, paddingTop + _rect.Y);
        }
    }
}

