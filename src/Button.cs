using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    // Button if it is needed
    public class Button
    {
        private Shape _rect;
        private string _content;
        private IOnClick _onClick; // Different Behaviour of OnClick action -- Using Strategy Pattern
        public Button(Shape rect,IOnClick onClick ,string content)
        {
            _rect = rect;
            _onClick = onClick;
            _content = content;
        }
        public Shape Rectangle
        {
            get => _rect;
        }
        // Hover effect
        public void Hover()
        {
            int margin = 3;
            if (_rect.IsAt())
            {
                SplashKit.DrawRectangle(Color.Black, _rect.X - margin, _rect.Y - margin, _rect.Width + margin * 2, _rect.Height + margin * 2);
            }
        }
        // Click Action
        public void Click()
        {
            if(_rect.IsAt() && SplashKit.MouseClicked(MouseButton.LeftButton))
            {
                _onClick.Notify();
            }
        }
        public void Draw() // Draw the button
        {
            _rect.Draw();
            int paddingTop = 22;
            int paddingLeft = 15;
            Font font = Constants.Font;
            SplashKit.DrawText(_content, Color.White, font, 20, paddingLeft + _rect.X, paddingTop + _rect.Y);
        }
    }
}

