using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    public class Grid : INodeCollection
    {
        private GraphBuilder _builder;
        public Grid(GraphBuilder builder)
        {
            _builder = builder;
        }
        public void UpdateEvent(bool running)
        {
            _builder.Draw();
            if (SplashKit.KeyDown(KeyCode.WKey) && !running) _builder.AddWall();
            if (SplashKit.KeyDown(KeyCode.DKey) && !running) _builder.AddDestination();
            if (SplashKit.KeyDown(KeyCode.RKey) && !running) _builder.Clear();
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && !running) _builder.RemoveAt();
        }
        public void Reset()
        {
            _builder.Clear();
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
        public int Size
        {
            get => _builder.Size;
        }
        public AbstractNode Fetch(Coordinate coordinate)
        {
            if(coordinate.Column < 0 || coordinate.Column >= Size || coordinate.Row >= Size || coordinate.Row < 0)
            {
                return null;
            }
            return _builder.Graph[coordinate.Row, coordinate.Column];
        }
        public Queue<AbstractNode> DestinationQueue
        {
            get => _builder.DestinationQ;
        }
    }
}

