using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    public class Grid : INodeCollection
    {
        private NodeFactory _factory;
        public Grid(NodeFactory factory)
        {
            _factory = factory;
        }
        public void UpdateScreen()
        {
            _factory.Draw();
            if (SplashKit.KeyDown(KeyCode.AKey)) _factory.AddWall();
            if (SplashKit.KeyDown(KeyCode.DKey)) _factory.AddDestination();
            if (SplashKit.KeyDown(KeyCode.LKey)) _factory.Clear();
        }
        public void Reset()
        {
            _factory.Clear();
        }
        public NodeIterator CreateDepthFirstIterator()
        {
            return new DepthFirstIterator(this);
        }
        public NodeIterator CreateBreadthFirstIterator()
        {
            return new BreadthFirstIterator(this);
        }
        public AStarIterator CreateAStarIterator()
        {
            return new AStarIterator(this);
        }
        public int GetSize()
        {
            return _factory.Size;
        }
        public AbstractNode Fetch(Coordinate coordinate)
        {
            if(coordinate == null) return null;
            if(coordinate.Column < 0 || coordinate.Column >= GetSize() || coordinate.Row >= GetSize() || coordinate.Row < 0)
            {
                return null;
            }
            return _factory.Graph[coordinate.Row, coordinate.Column];
        }
        public Queue<AbstractNode> GetDestinationQueue()
        {
            return _factory.DestinationQ;
        }
    }
}

