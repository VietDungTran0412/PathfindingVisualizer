using System;
using SplashKitSDK;
namespace CustomProgram
{
    public class Constants
    {
        private static Font _font = new Font("mainfont", "font/main.otf");
        public static Font Font
        {
            get { return _font; }
        }
    }
}

