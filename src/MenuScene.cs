using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    public class MenuScene : IScene
    {
        private List<Button> _buttonList;
        public MenuScene(Client client)
        {
            _buttonList = new List<Button>();
            _buttonList.Add(new Button(new Rectangle(), new OnClickDFS(client), "Depth First Search"));
            _buttonList.Add(new Button(new Rectangle(), new OnClickBFS(client), "Breadth First Search"));
            _buttonList.Add(new Button(new Rectangle(), new OnClickAStar(client), "A Star Search"));
            Setup();
        }
        public void Display()
        {
            foreach (Button button in _buttonList)
            {
                button.Draw();
                button.Click();
                button.Hover();
            }
        }
        public Color GetBackgroundColor()
        {
            return Color.White;
        }
        private void Setup()
        {
            int width = 200;
            int height = 70;
            double startY = 400;
            for (int i = 0; i < _buttonList.Count; i++)
            {
                _buttonList[i].Rectangle.Width = width;
                _buttonList[i].Rectangle.Height = height;
                _buttonList[i].Rectangle.Y = startY + i * 125;
                _buttonList[i].Rectangle.X = 300;
                _buttonList[i].Rectangle.Color = Color.Azure;
            }
        }
    }
}

