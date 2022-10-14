using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SplashKitSDK;
namespace CustomProgram
{
    public class Program
    {

        public static void Main()
        {
            new Window("Tim Duong Vao Tim Em", 800, 800);
            INodeCollection grid = new Grid(new NodeFactory());
            MainScene scene = new MainScene(grid, new AStarSearch(grid));
            while (!SplashKit.QuitRequested())
            {
                // Handle input to adjust player movement
                SplashKit.ProcessEvents();

                // Redraw everything
                SplashKit.ClearScreen(Color.Black);
                // Draw to the screen
                //for (int i = 0; i < 20; i++)
                //{
                SplashKit.Delay(150);
                scene.Display();

                //    for (int j = 0; j < 20; j++)
                //    {
                //        SplashKit.FillRectangle(Color.White, i * 40 + 1, j * 40 + 1, 38, 38);
                //    }
                //}
                // as well as the player who can move


                // including something stationary - it doesn't move


                SplashKit.RefreshScreen(60);
            }
        }
    }
}
