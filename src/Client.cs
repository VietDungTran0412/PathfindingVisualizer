using System;
using SplashKitSDK;
namespace CustomProgram
{
    // Main Client control every scene of the program
    public class Client
    {
        private IScene _scene;
        private Window _window;
        public Client()
        {
            _scene = new MenuScene(this);
            _window = new Window("Tim Duong Vao Tim Em", 800, 800);
        }
        // Display scene
        public void DisplayScene()
        {
            SplashKit.ClearScreen(Scene.GetBackgroundColor());
            Scene.Display();
        }
        // Turn off the program
        public void Close()
        {
            SplashKit.CloseWindow(_window);
        }
        public IScene Scene // Current scene
        {
            get { return _scene; }
            set { _scene = value; }
        }
    }
}

