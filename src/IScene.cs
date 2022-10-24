using System;
using SplashKitSDK;
namespace CustomProgram
{
    // Interface of scene
    public interface IScene
    {
        public void Display(); // Display artwork
        public Color GetBackgroundColor(); // Get background color
    }
}

