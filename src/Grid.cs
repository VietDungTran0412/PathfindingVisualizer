using System;
using SplashKitSDK;
using System.Collections.Generic;
namespace CustomProgram
{
    // Implements the interface INodeCollection and control the process of building the graph
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
            if (SplashKit.KeyDown(KeyCode.WKey) && !running)
            {
                _builder.AddWall();
            }
            if (SplashKit.KeyDown(KeyCode.DKey) && !running)
            {
                _builder.AddDestination();
            }
            if (SplashKit.KeyDown(KeyCode.RKey) && !running)
            {
                _builder.Clear();
            }
            if (SplashKit.KeyDown(KeyCode.TKey) && !running)
            {
                _builder.SetRandomMaze();
            }
            if (SplashKit.MouseClicked(MouseButton.LeftButton) && !running)
            {
                _builder.RemoveAt();
            }
        }
        public GraphBuilder Builder
        {
            get => _builder;
        }
        public void Reset()
        {
            _builder.Clear();
        }
        // Create different Iterator
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
    }
}

