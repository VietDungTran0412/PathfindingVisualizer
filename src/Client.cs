using System;
using SplashKitSDK;
namespace CustomProgram
{
    // Main Client control every scene of the program
    public class Client
    {
        private IScene _scene;
        private Window _window;
        public Client(Window window)
        {
            _scene = new MenuScene(this);
            _window = window;
        }
        // Display scene
        public void DisplayScene()
        {
            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Scene.GetBackgroundColor());
                Scene.Display();
                SplashKit.RefreshScreen(60);
            }

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

