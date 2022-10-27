using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    // Guidline scene to guidline user how to use the program
    public class GuidlineScene:IScene
    {
        private List<string> _readlines;
        private Button _backButton;
        private readonly Font _font;
        private readonly string _title;
        public GuidlineScene(Client client, string title)
        {
            _readlines = new List<string>();
            _backButton = new Button(new Rectangle(), new OnClickBack(client), "Back");
            _font = Constants.ExtraFont;
            _title = title;
            LazySetup();
        }
        private void LazySetup()
        {
            string[] message = new string[] { "Press 'Escape' to escape back to menu.", "Press 'Q' to run algorithm.",
                "Press 'D' to add checkpoint/destination.","Press 'W' to add Wall.","Double click on Wall to remove.",
                "Press '+' to increase annimation speed.","Press '-' to decrease annimation speed.",
                "Press 'T' generate random maze."
            };
            _readlines = new List<string>(message);
            _backButton.Rectangle.X = 275;
            _backButton.Rectangle.Y = 700;
            _backButton.Rectangle.Width = 220;
            _backButton.Rectangle.Height = 70;
            _backButton.Rectangle.Color = Color.RGBColor(76, 214, 245);
        }
        // Display readline tutorial
        private void DisplayReadLine()
        {
            double offsetX = 50;
            double offsetY = 100;
            double add = 60;
            for(int i = 0; i < _readlines.Count; i++)
            {
                SplashKit.DrawText(_readlines[i], Color.Black, _font, 30, offsetX, offsetY);
                offsetY += add;
            }
        }
        public Color GetBackgroundColor()
        {
            return Color.AliceBlue;
        }
        public void Display()
        {
            SplashKit.DrawText(_title, Color.Black, _font, 50, 20, 10);
            _backButton.Click();
            DisplayReadLine();
            _backButton.Draw();
            _backButton.Hover();
        }
    }
}

