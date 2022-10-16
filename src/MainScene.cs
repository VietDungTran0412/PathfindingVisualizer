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
        private Client _client;
        public MainScene(Client client)
        {
            _collection = new Grid(new NodeFactory());
            _graphTraversal = new GraphTraversal(_collection);
            _running = false;
            _client = client;
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
            _collection.UpdateEvent();
            if(SplashKit.KeyDown(KeyCode.QKey) && _collection.GetDestinationQueue().Count == 2)
            {
                _running = true;
            }
            if (SplashKit.KeyDown(KeyCode.RKey)) _graphTraversal.RemoveAll();
            if (_running)
            {
                SplashKit.Delay(75);
                GraphTraversal.FindPath();
            }
            if(_collection.GetDestinationQueue().Count == 0 || _graphTraversal.IsEnd())
            {
                _running = false;
            }
            if (SplashKit.KeyDown(KeyCode.EscapeKey))
            {
                //NodeCollection.Reset();
                //_animationSpeed = 0;
                _client.Scene = new MenuScene(_client);
            }
        }
    }
}

