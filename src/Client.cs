using System;
using SplashKitSDK;
namespace CustomProgram
{
    public class Client
    {
        private IScene _scene;
        public Client()
        {
            _scene = new MenuScene(this);
        }
        public void DisplayScene()
        {
            SplashKit.ClearScreen(Scene.GetBackgroundColor());
            Scene.Display();
        }
        public IScene Scene
        {
            get { return _scene; }
            set { _scene = value; }
        }
    }
}

