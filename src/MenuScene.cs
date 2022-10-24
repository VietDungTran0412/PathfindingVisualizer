using System;
using System.Collections.Generic;
using SplashKitSDK;
namespace CustomProgram
{
    // Menu Scene of the program
    public class MenuScene : IScene
    {
        private List<Button> _buttonList;
        private string _title;
        public MenuScene(Client client)
        {
            _title = "Pathfinding Visualizer";
            _buttonList = new List<Button>();
            _buttonList.Add(new Button(new Rectangle(), new OnClickDFS(client), "Depth First Search"));
            _buttonList.Add(new Button(new Rectangle(), new OnClickBFS(client), "Breadth First Search"));
            _buttonList.Add(new Button(new Rectangle(), new OnClickAStar(client), "A Star Search"));
            _buttonList.Add(new Button(new Rectangle(), new OnClickExit(client), "Exit"));
            Setup();
        }
        public void Display()
        {
            SplashKit.DrawText(_title, Color.Black, Constants.Font, 50, 150, 20);
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
        // Lazy Set up the size and position of button
        private void Setup()
        {
            int width = 220;
            int height = 70;
            double startY = 350;
            for (int i = 0; i < _buttonList.Count; i++)
            {
                _buttonList[i].Rectangle.Width = width;
                _buttonList[i].Rectangle.Height = height;
                _buttonList[i].Rectangle.Y = startY + i * 100;
                _buttonList[i].Rectangle.X = 300;
                _buttonList[i].Rectangle.Color = Color.RGBColor(76, 214, 245);
            }
        }
    }
}

