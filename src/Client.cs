using System;
using SplashKitSDK;
namespace CustomProgram
{
    public class Client
    {
        private IScene _scene;
        private Window _window;
        public Client()
        {
            _scene = new MenuScene(this);
            _window = new Window("Tim Duong Vao Tim Em", 800, 800);
        }
        public void DisplayScene()
        {
            SplashKit.ClearScreen(Scene.GetBackgroundColor());
            Scene.Display();
        }
        public void Close()
        {
            SplashKit.CloseWindow(_window);
        }
        public IScene Scene
        {
            get { return _scene; }
            set { _scene = value; }
        }
    }
}

