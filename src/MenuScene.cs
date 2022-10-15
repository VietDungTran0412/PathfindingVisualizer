using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    public class MainScene
    {
        private INodeCollection _collection;
        private IGraphTraversal _path;
        private bool _running;
        public MainScene(INodeCollection collection, IGraphTraversal path)
        {
            _collection = collection;
            _path = path;
            _running = false;
        }
        public void Display()
        {
            _collection.UpdateScreen();
            if(SplashKit.KeyDown(KeyCode.RKey) && _collection.GetDestinationQueue().Count == 2)
            {
                _running = true;
            }
            if (SplashKit.KeyDown(KeyCode.LKey)) _path.RemoveAll();
            if (_running)
            {
                SplashKit.Delay(100);
                _path.FindPath();
            }
            if(_collection.GetDestinationQueue().Count == 0 || _path.IsEnd())
            {
                _running = false;
            }
        }
    }
}

