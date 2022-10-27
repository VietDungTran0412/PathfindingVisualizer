using System;
using SplashKitSDK;
namespace CustomProgram
{
    // Every essential constants
    public class Constants
    {
        private static Font _font = new Font("mainfont", "font/main.otf");
        private static Font _extra = new Font("extra", "font/MainFont1.otf");
        public static Font Font
        {
            get { return _font; }
        }
        public static Font ExtraFont
        {
            get { return _extra; }
        }
    }
}

