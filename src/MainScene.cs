using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    public class MainScene
    {
        private INodeCollection _collection;
        private GraphTraversal _graphTraversal;
        private bool _running;
        public MainScene(INodeCollection collection)
        {
            _collection = collection;
            _graphTraversal = new GraphTraversal(_collection);
        }
        public GraphTraversal GraphTraversal
        {
            get { return _graphTraversal; }
        }
        public void Display()
        {
            _collection.UpdateScreen();
            if(SplashKit.KeyDown(KeyCode.RKey) && _collection.GetDestinationQueue().Count == 2)
            {
                _running = true;
            }
            if (SplashKit.KeyDown(KeyCode.LKey)) _graphTraversal.RemoveAll();
            if (_running)
            {
                _graphTraversal.FindPath();
            }
            if(_collection.GetDestinationQueue().Count == 0 || _graphTraversal.IsEnd())
            {
                _running = false;
            }
            if (SplashKit.KeyDown(KeyCode.TKey))
            {
                GraphTraversal.Iterator = _collection.CreateAStarIterator();
            }
        }
    }
}

