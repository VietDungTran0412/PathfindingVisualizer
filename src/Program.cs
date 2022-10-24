using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
namespace CustomProgram
{
    // Main program
    public class Program
    {
        public static void Main()
        {
            Client client = new Client();
            while (!SplashKit.QuitRequested())
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen(Color.Black);

                // Client Display
                client.DisplayScene();


                SplashKit.RefreshScreen(60);
            }
        }
    }
}
