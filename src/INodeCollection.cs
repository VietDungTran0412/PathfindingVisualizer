using System;
using System.Collections.Generic;
namespace CustomProgram
{
    public interface INodeCollection
    {
        public GraphBuilder Builder { get; }
        public void Reset();
        public NodeIterator CreateDepthFirstIterator();
        public NodeIterator CreateBreadthFirstIterator();
        public AStarIterator CreateAStarIterator();
        public void UpdateEvent(bool running);
    }

}

