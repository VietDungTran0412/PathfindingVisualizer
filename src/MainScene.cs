using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    public class MainScene:IScene
    {
        private INodeCollection _collection;
        private GraphTraversal _graphTraversal;
        private bool _running;
        public MainScene()
        {
            _collection = new Grid(new NodeFactory());
            _graphTraversal = new GraphTraversal(_collection);
            _running = false;
        }
        public INodeCollection NodeCollection
        {
            get { return _collection; }
        }
        public Color GetBackgroundColor()
        {
            return Color.Black;
        }
        public GraphTraversal GraphTraversal
        {
            get { return _graphTraversal; }
            set { _graphTraversal = value; }
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
                GraphTraversal.FindPath();
            }
            if(_collection.GetDestinationQueue().Count == 0 || _graphTraversal.IsEnd())
            {
                _running = false;
            }
        }
    }
}

