using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public interface INodeCollection
    {
        public int Size { get; }
        public void Reset();
        public Queue<AbstractNode> DestinationQueue { get; }
        public NodeIterator CreateDepthFirstIterator();
        public NodeIterator CreateBreadthFirstIterator();
        public AStarIterator CreateAStarIterator();
        public AbstractNode Fetch(Coordinate coordinate);
        public void UpdateEvent(bool running);
    }

}

