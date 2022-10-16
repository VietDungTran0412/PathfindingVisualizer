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
            if(_rect.IsAt() && SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                _onClick.Notify();
            }
        }
        public void Draw()
        {
            _rect.Draw();
            int padding = 25;
            SplashKit.DrawText(_content, Color.Black, padding + _rect.X, padding + _rect.Y);
        }
    }
}

