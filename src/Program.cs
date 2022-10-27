// Custom Program in Object Oriented Programming COS20007 -- Semester 2
// Student's Name: Dung Tran
// Student ID: 103486496
// Tutorial Session: Friday - 2:30pm
// Tutor: Edward Greenaway
// Convenor: Dr Charlotte Pierce
// Creating  Pathfinding Visualizer Tool to visualize differnt pathfinding algorithm in a grid of 20x20
// Following OOP principle and Design Patterns << Builder, Iterator, Strategy, Observer, Factory >>
using System;
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
